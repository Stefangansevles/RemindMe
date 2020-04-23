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
            new Thread(() =>
            {
                if (!HasInternetAccess())
                    return;

                Settings set = BLSettings.Settings;
                try
                {
                    //Change a 200-character string to a 10 character string. saves db space and 200 is just unnecesary
                    if (set.UniqueString != null && set.UniqueString.Length == 200)
                    {
                        string uniqueStringOld = set.UniqueString;

                        set.UniqueString = GenerateString();

                        while (!BLOnlineDatabase.IsUniqueString(set.UniqueString))
                        {
                            set.UniqueString = GenerateString();
                        }
                        
                        DLOnlineDatabase.TransformUniqueString(uniqueStringOld, set.UniqueString, IOVariables.RemindMeVersion);
                    }
                    else if (string.IsNullOrWhiteSpace(set.UniqueString))
                    {
                        string uniqueString = GenerateString();

                        Log("No unique string detected. Generated unique string.");


                        while (!BLOnlineDatabase.IsUniqueString(uniqueString))
                        {
                            //This shouldn't even happen, because the likelihood is insanely small, but hey, if it does happen, generate a new ID
                            Log("unique string NOT unique. generating new id...");
                            uniqueString = GenerateString();
                        }
                        set.UniqueString = uniqueString;
                    }
                    else
                        Log("WriteUniqueString() ignored.");
                }
                catch (Exception ex)
                {
                    Log("WriteUniqueString failed -> " + ex.GetType().ToString());
                    WriteError(ex, "WriteUniqueString failed -> " + ex.GetType().ToString(), true);
                }

                BLSettings.UpdateSettings(set);
            }).Start();
        }
        private static string GenerateString()
        {            
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
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
                    systemLog.Add(noInternetNotLoggedCounter + " \"No internet access\" messages blocked");                    
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


        public static int DumpLogTxt()
        {
            try
            {

                Directory.CreateDirectory(Path.GetDirectoryName(IOVariables.systemLog));

                File.WriteAllText(IOVariables.systemLog, ""); //Clear log

                using (FileStream fs = new FileStream(IOVariables.systemLog, FileMode.Append))
                {


                    using (StreamWriter sw = new StreamWriter(fs)) //Write log
                    {
                        foreach (string line in systemLog)
                            sw.WriteLine(line);
                    }
                }
                return systemLog.Count;
            }
            catch (Exception ex)
            {
                systemLog.Add("[" + DateTime.Now.ToString() + "]  BLIO.DumpLogTxt() FAILED  -> " + ex.GetType().ToString());
                return -1;
            }
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
                try
                {
                    //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
                    //that has an bunifu control in it(like a button), while there shouldn't be an exception.
                    if ((ex is System.Runtime.InteropServices.ExternalException) && ex.Source == "System.Drawing" && ex.Message.Contains("GDI+"))
                        return;

                    if (sendToOnlineDatabase && HasInternetAccess())
                    {
                        BLOnlineDatabase.AddException(ex, DateTime.Now, IOVariables.systemLog);
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
                }
                catch { }

            }).Start();
           
        }     
       
    }
}
