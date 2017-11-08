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
        private static void startTimer()
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

            if (Path.GetExtension(path) == ".remindme")            
                return true;            
            else
                return false;
        }


       
                                       
        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message)
        {                        
            using (FileStream fs = new FileStream(IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }   
            try
            {
                //Try to send an e-mail containing the error. This will help fix bugs in the future. Let's make sure we do it on a new thread.
                if (allowEmail)
                {
                    Thread sendMailThread = new Thread(() => BLEmail.SendEmail("Error Report: " + ex.GetType().ToString(), "Oops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString()));
                    sendMailThread.Start();
                    allowEmail = false;
                }

                //Start the timer that allows sending of an e-mail 30 seconds later
                startTimer();
            }   
            catch(Exception)
            {
                //dont do anything if something goes wrong
            }
        }              
    }
}
