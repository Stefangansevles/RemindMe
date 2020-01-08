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
        private static int noInternetNotLoggedCounter = 0;               
        public static List<string> systemLog = new List<string>();                
        private BLIO() { }

        /// <summary>
        /// Writes an unique string to string.txt in the RemindMe folder if it does not exists
        /// </summary>
        public static void WriteUniqueString()
        {
            Settings set = BLSettings.Settings;
            if (string.IsNullOrWhiteSpace(set.UniqueString))
            {
                string uniqueString = "";
                Random random = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                uniqueString = new string(Enumerable.Repeat(chars, 200)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                Log("No unique string detected. Generated unique string.");
                set.UniqueString = uniqueString.ToString();
                BLSettings.UpdateSettings(set);                
            }
        }

        /// <summary>
        /// Log an entry to the system log
        /// </summary>
        /// <param name="entry"></param>
        public static void Log(string entry)
        {
            if (systemLog.Count > 0 && systemLog[systemLog.Count - 1] == "No internet access!") //Let's not spam "no internet access" if there is no internet access
            {
                noInternetNotLoggedCounter++;
                return;
            }
            else
            {
                if (noInternetNotLoggedCounter > 0)
                {
                    Log(noInternetNotLoggedCounter + " \"No internet access\" messages blocked");
                    noInternetNotLoggedCounter = 0; //reset
                }
            }
                                              
            systemLog.Add("[" + DateTime.Now.ToString() + "]  " + entry);
        }

        public static string LastLogMessage
        {
            get { return systemLog[systemLog.Count - 1]; }
        }

        /// <summary>
        /// Checks for internet connectivity
        /// </summary>
        /// <returns>True if you have internet access, false if not</returns>
        public static bool HasInternetAccess()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                Log("No internet access!");
                return false;
            }
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

        /// <summary>
        /// Look at RemindMe's github page(html) and check the version number of "SetupRemindMe.msi"
        /// </summary>
        public static Version GetGithubVersion()
        {
            try
            {                
                if(!LastLogMessage.Contains("No new version."))
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

                if (lines.Count > 0 && !LastLogMessage.Contains("No new version."))
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
                        catch { Log("ERROR Could not get the raw version from SetupRemindMe17.vdproj from github..."); }


                    }
                }
            }
            catch(Exception ex)
            {
                Log("BLIO.GetGithubVersion() failed: " + ex.ToString());
            }
            return null;
        }

        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        /// <param name="sendToOnlineDatabase">Determines wether WriteError() is allowed to send the error to the online database this is true by default</param>
        public static void WriteError(Exception ex, string message,bool sendToOnlineDatabase = true)
        {            
            new Thread(() =>
            {
                //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
                //that has an bunifu control in it(like a button), while there shouldn't be an exception.
                if ((ex is System.Runtime.InteropServices.ExternalException) && ex.Source == "System.Drawing" && ex.Message.Contains("GDI+"))
                    return;

                if (sendToOnlineDatabase && HasInternetAccess())
                {
                    BLOnlineDatabase.AddException(ex, DateTime.Now, GetLogTxtPath());
                }
                else
                {
                    //Only write to the errorlog.txt if writing to the database failed, since we insert the errorlog into the database
                    //at a different time when above doesn't fail
                    using (FileStream fs = new FileStream(IOVariables.errorLog, FileMode.Append))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {                        
                        sw.WriteLine("[" + DateTime.Now + "] - " + message + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                    }
                }

            }).Start();
           
        }

        /// <summary>
        /// Creates the .bat file neccesary to install the new update of RemindMe, uninstall the old one and re-run RemindMe
        /// </summary>
        public static void WriteUpdateBatch(string remindMePath)
        {
            new Thread(() =>
            {
                Log("Writing batch script...");
                string batchString = "@echo off\r\necho Installing the new version of RemindMe.... Please do not close this window\r\n@echo on" + Environment.NewLine;
                string productCode = GetProductCode("RemindMe"); //This call really does take a pretty long time. Good thing we can thread that
                
                batchString += "msiexec /qb /i \"" + IOVariables.rootFolder + "SetupRemindMe.msi\"" + Environment.NewLine;
                batchString += "msiexec /x " + productCode + " /qn" + Environment.NewLine;                
                batchString += "start /d \"" + remindMePath + "\" RemindMe.exe";

                using (FileStream fs = new FileStream(IOVariables.rootFolder + "install.bat", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(batchString);
                    Log("Writing batch script complete!");
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

        /// <summary>
        /// Gets the product code of the installed version of RemindMe on the target comuter. Will look something like this: {026AD2C2-A1B9-4D88-91FE-D0E8C55594D8}
        /// </summary>
        /// <param name="productName">The product name</param>
        /// <returns></returns>
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
