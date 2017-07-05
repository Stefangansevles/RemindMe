using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity;

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
        /// Checks wether the table Reminder has column x
        /// </summary>
        /// <param name="columnName">The column you want to check on</param>
        /// <returns></returns>
        public static bool HasColumn(string columnName)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                try
                {
                    var t = db.Database.SqlQuery<object>("SELECT " + columnName + " FROM Reminder").ToList();
                    db.Dispose();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    db.Dispose();
                    //if (ex.Message.ToLower().Contains("no such column"))
                    //{
                        return false;
                    //}                                        
                }
            }
        }

        public static bool HasAllColumns()
        {
            var names = typeof(Reminder).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in names)
            {
                if (!HasColumn(columnName))
                {
                    //aww damn! the user has an outdated .db file!
                    return false;                    
                }
            }
            return true;
        }

        /// <summary>
        /// This method will insert missing columns into the table reminder. Will only be called if HasallColumns() returns false. This means the user has an outdated .db file
        /// </summary>
        public static void InsertNewcolumns()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                //every column that SHOULD exist
                var names = typeof(Reminder).GetProperties().Select(property => property.Name).ToArray();

                foreach(string column in names)
                {
                    if (!HasColumn(column))                    
                        db.Database.ExecuteSqlCommand("ALTER TABLE REMINDER ADD COLUMN " + column + " " + GetColumnSqlType(column));                    
                }
                
                db.Dispose();
            }
        }

        /// <summary>
        /// Gets the SQLite data types of the columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch(columnName)
            {
                case "Id": return "INTEGER NOT NULL";                    
                case "Name": return "text NOT NULL DEFAULT ''";
                case "Date": return "text NOT NULL DEFAULT '1-1-1990'";
                case "RepeatType": return "text NOT NULL DEFAULT 'none'";
                case "Note": return "text NULL ";
                case "Enabled": return "bigint NOT NULL DEFAULT '1'";
                case "DayOfWeek": return "bigint NULL";
                case "DayOfMonth": return "bigint NULL";
                case "EveryXCustom": return "bigint NULL";
                case "RepeatDays": return "text NULL";
                case "SoundFilePath": return "text NULL";
                case "PostponeDate": return "text NULL";
                default: return "text NULL";
            }
        }





        public static void InsertReminder(string name, DateTime date, string repeatingType, int? dayOfMonth, int? dayOfWeek, int? everyXDays,string commaSeperatedDays, string note, bool enabled, string soundPath)
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date.ToString();
            rem.RepeatType = repeatingType.ToString();

            //below are nullable parameters. a reminder can have a dayofweek, if it does, it won't have a dayofmonth.
            if(dayOfWeek.HasValue)
                rem.DayOfWeek = dayOfWeek;

            if (dayOfMonth.HasValue)
                rem.DayOfMonth = dayOfMonth;

            if(everyXDays.HasValue)
                rem.EveryXCustom = everyXDays;

            //will containall selected days. example: "monday,thursday,saturday"          
            if(commaSeperatedDays != null && commaSeperatedDays != "")
                rem.RepeatDays = commaSeperatedDays;            
            
            rem.Note = note;
            rem.SoundFilePath = soundPath;
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;
            PushReminderToDatabase(rem);            
        }


        

        

        

        /// <summary>
        /// Inserts the reminder into the database.
        /// </summary>
        /// <param name="rem">The reminder you want added into the database</param>
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
                    DeleteReminder(rem);

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

                if(rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())                
                    rem.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(rem.RepeatDays)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();                

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
