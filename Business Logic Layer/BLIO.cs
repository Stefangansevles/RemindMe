using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// Goes through every reminder in the database and prints them comma seperated to a file
        /// </summary>
        /// <param name="path">The path where the file should be created</param>
        /// <returns>IOException if path is an empty string or the file already exists</returns>
        public static Exception ExportRemindersToFile(string path)
        {
            if (!File.Exists(path) && path != "")
            {
                using (FileStream fs = new FileStream(path, FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string reminder in BLReminder.ExportReminders())
                        sw.WriteLine(reminder);
                }
                return null;
            }
            else
            {
                if(File.Exists(path))
                    return new IOException("File already exists");
                if(path == "")
                    return new IOException("Backup cancelled.");
                else
                    return new IOException("Unknown.");
            }
        }

        /// <summary>
        /// Reads comma seperated reminders from a .remindme file and puts them in a list of reminders. returns null if something failed.
        /// </summary>
        /// <param name="path">Path to the .remindme file</param>
        /// <returns>List of reminders when succeeded. null if something failed.</returns>
        public static List<Reminder> ReadRemindersFromFile(string path)
        {
            List<Reminder> reminders = new List<Reminder>();
            Reminder rem;
            if (IsValidRemindMeFile(path))
            {
                try
                {
                    List<string> commaSeperatedReminder = new List<string>();
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            //multiple dates are also seperated by a comma, this will result in [2] and [3] etc being a date too                            
                            commaSeperatedReminder = sr.ReadLine().Split(',').ToList();
                            string datestring = commaSeperatedReminder[1] + ",";
                            bool doneParsing = false;
                            while (!doneParsing)
                            {
                                try
                                {
                                    DateTime date = Convert.ToDateTime(commaSeperatedReminder[2]);
                                    datestring += date.ToString() + ",";

                                    commaSeperatedReminder.RemoveAt(2);
                                }
                                catch (FormatException ex)
                                {
                                    doneParsing = true;

                                    if (datestring[datestring.Length - 1] == ',')
                                        datestring = datestring.Remove(datestring.Length - 1, 1); //remove the last comma
                                }
                            }

                            /*
                            [0] = Name
                            [1] = Date
                            [2] = RepeatType
                            [3] = Note
                            [4] = Enabled
                            [5] = EveryXCustom
                            [6] = RepeatDays  
                            [7] = SoundFilePath
                            [8] = PostponeDate
                            */
                            rem = new Reminder();

                            rem.Name = commaSeperatedReminder[0].ToString();

                            rem.Date = datestring;

                            rem.RepeatType = commaSeperatedReminder[2].ToString();

                            if (commaSeperatedReminder[3] != "null")
                                rem.Note = commaSeperatedReminder[3].ToString();
                            else
                                rem.Note = "";

                            rem.Enabled = Convert.ToInt64(commaSeperatedReminder[4].ToString());

                            if (commaSeperatedReminder[5] != "null")
                                rem.EveryXCustom = Convert.ToInt64(commaSeperatedReminder[5].ToString());
                            else
                                rem.EveryXCustom = null;

                            if (commaSeperatedReminder[6] != "null")
                                rem.RepeatDays = commaSeperatedReminder[6].ToString();
                            else
                                rem.RepeatDays = null;

                            if (commaSeperatedReminder[7] != "null")
                                rem.SoundFilePath = commaSeperatedReminder[7].ToString();
                            else
                                rem.SoundFilePath = null;

                            if (commaSeperatedReminder[8] != "null")
                                rem.PostponeDate = commaSeperatedReminder[8].ToString();
                            else
                                rem.PostponeDate = null;

                            reminders.Add(rem);

                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
                return null;

            return reminders;            
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
