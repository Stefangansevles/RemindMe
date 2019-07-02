using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Net;
using HtmlAgilityPack;
using System.Management;

namespace Business_Logic_Layer
{
    public class BLIO
    {
        //Checks if we can send an e-mail, when users come accross an error, they tend to try it multiple times. We don't want to spam e-mails.
        private static bool allowEmail = true;
        private static System.Windows.Forms.Timer tmrAllowEmail = null;
        public static List<string> systemLog = new List<string>();

        public static void Log(string entry)
        {
            systemLog.Add("[" + DateTime.Now.ToString() + "]  " + entry);
        }
        public static void Log(List<string> entries)
        {
            foreach (string entry in entries)
                Log(entry);
        }
        /// <summary>
        /// Saves the current log to a temporary path in .txt format and returns the path to the file
        /// </summary>
        /// <returns>The path to the .txt log file</returns>
        public static string GetLogTxtPath()
        {
            string path = System.IO.Path.GetTempPath() + "SystemLog.txt";

            if (File.Exists(path)) File.Delete(path);

            using (FileStream fs = new FileStream(path, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach(string line in systemLog)                
                    sw.WriteLine(line);                
                
            }
            return path;
        }
        private static void StartTimer()
        {
            if (tmrAllowEmail == null)
            {
                tmrAllowEmail = new System.Windows.Forms.Timer();
                tmrAllowEmail.Interval = 30000; //30 seconds
                tmrAllowEmail.Tick += TmrAllowEmail_Tick; //subscribe to tick event
            }


            if(!tmrAllowEmail.Enabled) //Not running? run.
                tmrAllowEmail.Start();
        }


        private static void TmrAllowEmail_Tick(object sender, EventArgs e)
        {
            if (!allowEmail) //Not allowed? allow.
                allowEmail = true;

            tmrAllowEmail.Stop();
        }

        private BLIO() { }
        /// <summary>
        /// Creates the folders and files needed by RemindMe. This should only occur once, during first use.
        /// </summary>
        public static void CreateSettings()
        {                        
            Directory.CreateDirectory(IOVariables.rootFolder);            
        }        
        /// <summary>
        /// If the user deleted the .db file, or if the user is using RemindMe for the first time, this method created the neccesary database + tables.
        /// </summary>
        public static void CreateDatabaseIfNotExist()
        {
            if (!System.IO.File.Exists(IOVariables.databaseFile))            
                DLDatabase.CreateDatabase();            
            else
            {
                //great! the .db file exists. Now lets check if the user's .db file is up-to-date. let's see if the reminder table has all the required columns.
                if (DLDatabase.HasAllTables())
                {
                    if (!DLDatabase.HasAllColumns())
                        DLDatabase.InsertNewColumns(); //not up to date. insert !
                }
                else
                {
                    DLDatabase.InsertMissingTables();
                    //re-run the method, since the .db file **should** now have all the tables.
                    CreateDatabaseIfNotExist();
                }
                                
            }

            
        }

        /// <summary>
        /// Determines wether the .remindme file is valid.
        /// </summary>
        /// <returns></returns>
        public static bool IsValidRemindMeFile(string path)
        {
            if (path == null || path == "")
                return false;

            return Path.GetExtension(path) == ".remindme";            
        }

        /// <summary>
        /// Creates a batch file, puts the batch script into the file and runs it.
        /// </summary>
        /// <param name="batch">The batch script you want to execute</param>
        public static void ExecuteBatch(string batch)
        {
            if (!Directory.Exists(Path.GetDirectoryName(IOVariables.batchFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(IOVariables.batchFile));

            using (StreamWriter wr = new StreamWriter(IOVariables.batchFile))
            {
                wr.Write("@echo **Executing advanced reminder script (RemindMe)**\r\n" + batch);
            }

            if(!File.Exists(IOVariables.batchFile))
                throw new FileNotFoundException("Could not found the file neccesary to execute a batch script");

            System.Diagnostics.Process.Start(IOVariables.batchFile);
        }

        
        //Used in CheckRemindMeVersion
        private static List<HtmlNode> GetTagsWithClass(string html, List<string> @class)
        {            
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var result = doc.DocumentNode.Descendants()
                .Where(x => x.Attributes.Contains("class") && @class.Contains(x.Attributes["class"].Value)).ToList();
            return result;
        }
        /// <summary>
        /// Look at RemindMe's github page(html) and check the version number of "SetupRemindMe.msi"
        /// </summary>
        public static Version GetGithubVersion()
        {
            try
            {
                Log("Starting the process of checking the live version on github...");
                //Lets thread this process. It has no priority and we dont want to slow RemindMe down.            
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                List<string> lines = new List<string>();

                string html;
                using (var client = new WebClient())
                {
                    html = client.DownloadString("https://raw.githubusercontent.com/Stefangansevles/RemindMe/master/SetupRemindMe17/SetupRemindMe17.vdproj");
                    lines = html.Split(new[] { "\n" }, StringSplitOptions.None).ToList();
                }

                if (lines.Count > 0)
                    Log("Sucessfully loaded raw SetupRemindMe17.vdproj from github");

                foreach (string line in lines)
                {
                    if (line.Contains("\"ProductVersion\""))
                    {
                        string splitLine = line.Replace(" ", "").Replace("\"", "");
                        int colonIndex = splitLine.IndexOf(':');

                        //Get version
                        try
                        {                            
                            return new Version(splitLine.Substring(colonIndex + 1));
                        }
                        catch (Exception ex) { Log("ERROR Could not get the raw version from SetupRemindMe17.vdproj from github..."); }


                    }
                }
            }
            catch(Exception ex)
            {
                Log("BLIO.NewVersionOnGithub() failed: " + ex.ToString());
            }
            return null;
        }

        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message)
        {
            //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
            //that has an bunifu control in it(like a button), while there shouldn't be an exception.
            if ((ex is System.Runtime.InteropServices.ExternalException) && ex.Source == "System.Drawing" && ex.Message.Contains("GDI+"))
                return;

            using (FileStream fs = new FileStream(IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }               
        }

        /// <summary>
        /// Creates the .bat file neccesary to install the new update of RemindMe, uninstall the old one and re-run RemindMe
        /// </summary>
        public static void WriteUpdateBatch(string remindMePath)
        {
            new Thread(() =>
            {
                string batchString = "@echo off\r\necho Installing the new version of RemindMe.... Please do not close this window\r\n@echo on" + Environment.NewLine;
                string productCode = GetProductCode("RemindMe"); //This call really does take a pretty long time. Good thing we can thread that
                
                batchString += "msiexec /qb /i \"" + IOVariables.rootFolder + "SetupRemindMe.msi\"" + Environment.NewLine;
                batchString += "msiexec /x " + productCode + " /qn" + Environment.NewLine;                
                batchString += "start /d \"" + remindMePath + "\" RemindMe.exe";

                using (FileStream fs = new FileStream(IOVariables.rootFolder + "install.bat", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(batchString);
                }
            }).Start();
        }

        /// <summary>
        /// Gets the MSI file version that is to be installed from the msi, before installing it.
        /// source: https://www.codeproject.com/Articles/31021/Getting-version-from-MSI-without-installing-it
        /// </summary>
        /// <param name="msi"></param>
        /// <returns></returns>
        public static string GetMsiVersion(string msi)
        {
            Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");

            WindowsInstaller.Installer installer = (WindowsInstaller.Installer)

            Activator.CreateInstance(type);

            WindowsInstaller.Database db = installer.OpenDatabase(msi, 0);

            WindowsInstaller.View dv = db.OpenView(
                 "SELECT `Value` FROM `Property` WHERE `Property`='ProductVersion'");

            WindowsInstaller.Record record = null;

            dv.Execute(record);

            record = dv.Fetch();

            return record.get_StringData(1).ToString();            
        }

        public static string GetProductCode(string productName)
        {
            string query = string.Format("select * from Win32_Product where Name='{0}'", productName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject product in searcher.Get())
                    return product["IdentifyingNumber"].ToString();
            }
            return null;
        }




    }
}
