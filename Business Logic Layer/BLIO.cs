using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;
using System.Threading;
using System.Timers;

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
    }
}
