using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;

namespace Business_Logic_Layer
{
    public abstract class BLIO
    {
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
                DLReminders.CreateDatabase();            
            else
            {
                //great! the .db file exists. Now lets check if the user's .db file is up-to-date. let's see if the reminder table has all the required columns.
                if(!DLReminders.HasAllColumns())
                    DLReminders.InsertNewColumns(); //not up to date. insert !
                                
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
            {
                return true;
            }
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
            
        }

        /// <summary>
        /// Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="description">A custom description of the error</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message, string description)
        {
            using (FileStream fs = new FileStream(IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }
            
        }
    }
}
