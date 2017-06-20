using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //TODO: Find a way to call RefreshList() whenever the SQLite database changes(if possible). Currently, we just call RefreshList() in every method that alters the database
    //It would be much nicer  if there was some kind of listener for SQLite database changes, but i couldn't find any
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// This class handles reminders in the database.
    /// </summary>
    public abstract class DLReminders
    {        
        //Instead of connecting with the database everytime, we fill this list and return it when the user calls GetReminders(). 
        static List<Reminder> localReminders;

        /// <summary>
        /// Gets all reminders from the database
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetReminders()
        {
            //If the list  is still null, it means GetReminders() hasn't been called yet. So, we give it a value once. Then, the list will only
            //be altered when the database changes. This way we minimize the amount of database calls
            if (localReminders == null)            
                RefreshList();            

            //If the list was null, it now returns the list of reminders from the database.
            //If it wasn't null, it will return the list as it was last known, which should be how the database is.
            return localReminders;
        }

        /// <summary>
        /// Gives the localReminders list a new value after the database has changed.
        /// </summary>
        private static void RefreshList()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                localReminders = (from g in db.Reminder select g).ToList();
                db.Dispose();
            }
        }



        /// <summary>
        /// Inserts an reminder in the database.
        /// </summary>
        /// <param name="name">The name of the reminder</param>
        /// <param name="date">The date it should pop up</param>
        /// <param name="repeatingType">The type of repeat</param>
        /// <param name="note">The optionaln ote</param>
        /// <param name="enabled"></param>
        /// <param name="soundPath">The path to the sound file that plays when this reminder pops up</param>
        public static void InsertReminder(string name, DateTime date, string repeatingType, string note, bool enabled, string soundPath)
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date.ToString();
            rem.RepeatType = repeatingType.ToString();
            rem.Note = note;
            rem.SoundFilePath = soundPath;
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.Reminder.Count() > 0)
                    rem.Id = db.Reminder.Max(i => i.Id) + 1;
                else
                    rem.Id = 0;
                
                db.Reminder.Add(rem);
                db.SaveChanges();
                RefreshList();
                db.Dispose();                
            }

        }


        
        public static void InsertReminder(string name, DateTime date, string repeatingType, int dayOfMonth, string note, bool enabled, string soundPath) 
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date.ToString();
            rem.RepeatType = repeatingType.ToString();
            rem.DayOfMonth = dayOfMonth;
            rem.Note = note;
            rem.SoundFilePath = soundPath;
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;
            PushReminderToDatabase(rem);
        }

        public static void InsertReminder(string name, DateTime date, string repeatingType, string note, int dayOfWeek, bool enabled, string soundPath)
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date.ToString();
            rem.RepeatType = repeatingType.ToString();
            rem.DayOfWeek = dayOfWeek;
            rem.Note = note;
            rem.SoundFilePath = soundPath;
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;
            PushReminderToDatabase(rem);
        }

        public static void InsertReminder(string name, DateTime date, string repeatingType, string note, bool enabled, int everyXDays, string soundPath) 
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date.ToString();
            rem.RepeatType = repeatingType.ToString();
            rem.EveryXCustom = everyXDays;
            rem.Note = note;
            rem.SoundFilePath = soundPath;
            
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;
            PushReminderToDatabase(rem);
        }

        private static void PushReminderToDatabase(Reminder rem)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.Reminder.Count() > 0)
                    rem.Id = db.Reminder.Max(i => i.Id) + 1;
                else
                    rem.Id = 0;

                db.Reminder.Add(rem);
                db.SaveChanges();
                RefreshList();
                db.Dispose();
            }
        }

        /// <summary>
        /// Gets an reminder with the matching unique id.
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns>Reminder that matches the given id. null if no reminder was found</returns>
        public static Reminder GetReminderById(long id)
        {
            Reminder rem = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                rem = (from g in db.Reminder select g).Where(i => i.Id == id).SingleOrDefault();
                db.Dispose();
            }
            return rem;
        }

        /// <summary>
        /// Gives a new value to a reminder based on it's repeating type, and inserts it into the database
        /// </summary>
        /// <param name="rem"></param>
        public static void UpdateReminder(Reminder rem)
        {
            if (rem != null)
            {
                //Enable the reminder again
                rem.Enabled = 1;

                if (rem.RepeatType == ReminderRepeatType.NONE.ToString())
                    DLReminders.DeleteReminder(rem);

                if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString()) //Add days to the reminder so that the next date will be a new workday      
                    ReminderManager.SetNextReminderWorkDay(rem);                                    

                if (rem.RepeatType == ReminderRepeatType.DAILY.ToString())    //Add a day to the reminder                                   
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1).ToString();                

                if (rem.RepeatType == ReminderRepeatType.WEEKLY.ToString())
                {
                    //Add a week to the reminder
                    //No matter what date the time was set to, the new date will be the date of the next x. x being the day of the week of the reminder.
                    //Like this, you won't get multiple popups if RemindMe hasnt been launched in a while, one popup for every week. 
                    rem.Date = Convert.ToDateTime(BLDateTime.GetDateOfNextDay(BLDateTime.GetDayOfWeekFromInt((int)rem.DayOfWeek)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString();                    
                }

                if (rem.RepeatType == ReminderRepeatType.MONTHLY.ToString())
                {
                    //Add a month. Change this while into: date = Datetime.Today.THISMONTH + addMonth(1);  ? maybe.
                    while (Convert.ToDateTime(rem.Date) < DateTime.Now)
                        rem.Date = Convert.ToDateTime(rem.Date).AddMonths(1).ToString();                    
                }

                if (rem.EveryXCustom != null)
                {
                    //The user has a custom reminder, every x minutes,hours,days,weeks, or months
                    switch(rem.RepeatType.ToLower())
                    {
                        case "minutes":
                            rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddMinutes((double)rem.EveryXCustom).ToString();
                            break;
                        case "hours":
                            rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddHours((double)rem.EveryXCustom).ToString();
                            break;
                        case "days":
                            rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays((double)rem.EveryXCustom).ToString();
                            break;
                        case "weeks":
                            rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays( ((double)rem.EveryXCustom * 7)).ToString();
                            break;
                        case "months":
                            rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddMonths((int)rem.EveryXCustom).ToString();
                            break;
                    }
                    
                }

                //finally, Write the changes to the database  
                if(rem.RepeatType != ReminderRepeatType.NONE.ToString())              
                    DLReminders.EditReminder(rem);
            }
            else
                throw new ArgumentNullException("parameter rem in UpdateReminder is null.");
        }

        /// <summary>
        /// Update an existing reminder.
        /// </summary>
        /// <param name="rem">The altered reminder</param>
        public static void EditReminder(Reminder rem)
        {
            if (GetReminderById(rem.Id) != null) //Check if the reminder exists
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.Reminder.Attach(rem);
                    var entry = db.Entry(rem);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    db.SaveChanges();                                      //push to database
                    RefreshList();
                    db.Dispose();
                }
            }
            else
                RemindMeBox.Show("Could not edit that reminder, it doesn't exist.", RemindMeBoxIcon.EXCLAMATION);
        }

        public static void DeleteReminder(Reminder rem)
        {
            if (GetReminderById(rem.Id) != null) //Check if the reminder exists
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.Reminder.Attach(rem);
                    db.Reminder.Remove(rem);                                              
                    db.SaveChanges();
                    RefreshList();
                    db.Dispose();
                }
            }
        }

        public static void DeleteReminders(List<Reminder> rems)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                foreach (Reminder rem in rems)
                {
                    if (GetReminderById(rem.Id) != null) //Check if the reminder exists
                    {
                        db.Reminder.Attach(rem);
                        db.Reminder.Remove(rem);                        
                    }
                }
                db.SaveChanges();
                RefreshList();
                db.Dispose();
            }
                
            
        }

    }
}
