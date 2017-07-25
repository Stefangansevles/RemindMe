using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity;
using System.IO;

namespace RemindMe
{
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //TODO: Find a way to call RefreshList() whenever the SQLite database changes(if possible)
    //Currently, there is a custom method SaveAndCloseDataBase() which saves the pending changes, closes the database, and refreshes the list
    //It would be much nicer  if there was some kind of listener for SQLite database changes, but i couldn't find any
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// This class handles reminders in the database.
    /// </summary>
    public abstract class DLReminders
    {        
        //Instead of connecting with the database everytime, we fill this list and return it when the user calls GetReminders(). 
        private static List<Reminder> localReminders;

        /// <summary>
        /// Gets all reminders from the database
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetReminders()
        {            
            //If the list  is still null, it means GetReminders() hasn't been called yet. So, we give it a value once. Then, the list will only
            //be altered when the database changes. This way we minimize wthe amount of database calls
            if (localReminders == null)            
                RefreshCacheList();            

            //If the list was null, it now returns the list of reminders from the database.
            //If it wasn't null, it will return the list as it was last known, which should be how the database is.
            return localReminders;
        }

        /// <summary>
        /// Gives the localReminders list a new value after the database has changed.
        /// </summary>
        private static void RefreshCacheList()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {                
                localReminders = (from g in db.Reminder select g).ToList();
                db.Dispose();                
            }
        }

        /// <summary>
        /// Creates the database with associated tables
        /// </summary>
        public static void CreateDatabase()
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "data source = " + Variables.IOVariables.databaseFile;
            conn.Open();

            SQLiteCommand tableReminder = new SQLiteCommand();
            SQLiteCommand tableSettings = new SQLiteCommand();
            SQLiteCommand tableSongs = new SQLiteCommand();
            tableReminder.CommandText = "CREATE TABLE [Reminder] ([Id] INTEGER NOT NULL, [Name]text NOT NULL, [Date]text NOT NULL, [RepeatType]text NOT NULL, [Note]text NOT NULL, [Enabled]bigint NOT NULL, [EveryXCustom] bigint NULL, [RepeatDays] text NULL, [SoundFilePath] text NULL, [PostponeDate] text NULL, CONSTRAINT[sqlite_master_PK_Reminder] PRIMARY KEY([Id]));";
            tableSettings.CommandText = "CREATE TABLE [Settings] ([Id] INTEGER NOT NULL, [AlwaysOnTop]bigint NOT NULL, [StickyForm]bigint NOT NULL, CONSTRAINT[sqlite_master_PK_Settings] PRIMARY KEY([Id]));";
            tableSongs.CommandText = "CREATE TABLE [Songs] ( [Id] INTEGER NOT NULL, [SongFileName]text NOT NULL, [SongFilePath]text NOT NULL, CONSTRAINT[sqlite_master_PK_Songs] PRIMARY KEY([Id]));";

            tableReminder.Connection = conn;
            tableSettings.Connection = conn;
            tableSongs.Connection = conn;

            tableReminder.ExecuteNonQuery();
            tableSettings.ExecuteNonQuery();
            tableSongs.ExecuteNonQuery();
            conn.Close();

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

        /// <summary>
        /// Checks if the user's .db file has all the columns from the database model.
        /// </summary>
        /// <returns></returns>
        public static bool HasAllColumns()
        {
            var names = typeof(Reminder).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in names)
            {
                if (!HasColumn(columnName))                                   
                    return false; //aww damn! the user has an outdated .db file!                
            }
            return true;
        }

        /// <summary>
        /// This method will insert missing columns into the table reminder. Will only be called if HasallColumns() returns false. This means the user has an outdated .db file
        /// </summary>
        public static void InsertNewColumns()
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
                SaveAndCloseDataBase(db);
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




        /// <summary>
        /// Inserts a new reminder into the database
        /// </summary>
        /// <param name="name">The name of the reminder</param>
        /// <param name="date">The date the reminder should pop up</param>
        /// <param name="repeatingType"></param>        
        /// <param name="dayOfWeek">The day of the week this reminder should pop up at each week. Use null if the reminder isn't weekly</param>
        /// <param name="everyXDays">The amount of x. example: every 5 days</param>
        /// <param name="commaSeperatedDays">a string with days seperated by a comma. example: monday,friday,sunday</param>
        /// <param name="note">The optional note of this reminder</param>
        /// <param name="enabled">Wether this reminder is enabled or not. 1 = enabled   0 = not enabled</param>
        /// <param name="soundPath">The path to the sound effect that should play when this reminder pops up</param>
        /// <returns>Returns the ID of the newly inserted reminder</returns>
        public static long InsertReminder(string name, string date, string repeatingType, long? everyXDays,string commaSeperatedDays, string note, bool enabled, string soundPath)
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date;
            
            
            rem.RepeatType = repeatingType.ToString();

            //below are nullable parameters. a reminder can have a dayofmonth, if it does, it won't have a everyXDays.            

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
            return rem.Id;          
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
                SaveAndCloseDataBase(db);
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
                    rem.Date = BLDateTime.GetNextReminderWorkDay(rem).ToString();                                    

                if (rem.RepeatType == ReminderRepeatType.DAILY.ToString())    //Add a day to the reminder                                   
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1).ToString();                


                if (rem.RepeatType == ReminderRepeatType.MONTHLY.ToString())
                {                                       
                    if(rem.Date.Split(',').Length > 1)
                    {
                        List<DateTime> reminderDates = new List<DateTime>();
                       
                        foreach (string date in rem.Date.Split(',')) //go through each date. with monthly reminders, it can have multiple dates, seperated by comma's
                        {

                            if (Convert.ToDateTime(date) < DateTime.Now)//get the next day of the monthly day of the date. example: 10-6-2017 -> 10-7-2017 BUT 31-1-2017 -> 31-3-2017, since february doesnt have 31 days                            
                                reminderDates.Add(Convert.ToDateTime(BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(date).Day).ToShortDateString() + " " + Convert.ToDateTime(date).ToShortTimeString()));                                                            
                            else                            
                                reminderDates.Add(Convert.ToDateTime(date)); //Date in the future? good! do nothing with it.   

                                                     
                            
                        }
                        //have to make sure the first date is in front.
                        reminderDates.Sort();

                        //Now, we're going to put the (sorted) dates in a string
                        string newDateString = "";
                        foreach (DateTime date in reminderDates)
                            newDateString += date.ToString() + ",";

                        rem.Date = newDateString.Remove(newDateString.Length - 1, 1);
                    }
                    else
                    {//There's only one date in this string.                        
                        rem.Date = BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(rem.Date).Day).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString() + ",";
                    }
                }

                if(rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())                
                    rem.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(rem.RepeatDays)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();

                if (rem.EveryXCustom != null)
                { 
                    while (Convert.ToDateTime(rem.Date) < DateTime.Now)
                    {
                        //The user has a custom reminder, every x minutes,hours,days,weeks, or months
                        switch (rem.RepeatType.ToLower())
                        {
                            case "minutes": rem.Date = Convert.ToDateTime(rem.Date).AddMinutes((double)rem.EveryXCustom).ToString();
                                break;
                            case "hours": rem.Date = Convert.ToDateTime(rem.Date).AddHours((double)rem.EveryXCustom).ToString();
                                break;
                            case "days": rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom).ToString();
                                break;
                            case "weeks": rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom * 7).ToString();
                                break;
                            case "months": rem.Date = Convert.ToDateTime(rem.Date).AddMonths((int)rem.EveryXCustom).ToString();
                                break;
                        }
                    }
                    
                }

                //finally, Write the changes to the database  
                if(rem.RepeatType != ReminderRepeatType.NONE.ToString())              
                    EditReminder(rem);
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
                    SaveAndCloseDataBase(db);
                }
            }
            else
                RemindMeBox.Show("Could not edit that reminder, it doesn't exist.", RemindMeBoxIcon.EXCLAMATION);
        }

        /// <summary>
        /// Deletes a single reminder from the database
        /// </summary>
        /// <param name="rem">The reminder you wish to remove</param>
        public static void DeleteReminder(Reminder rem)
        {
            if (GetReminderById(rem.Id) != null) //Check if the reminder exists
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.Reminder.Attach(rem);
                    db.Reminder.Remove(rem);
                    SaveAndCloseDataBase(db);
                }
            }
        }

        /// <summary>
        /// Deletes a single reminder from the database
        /// </summary>
        /// <param name="reminderId">The id of the reminder you wish to remove</param>
        public static void DeleteReminder(int reminderId)
        {
            if (GetReminderById(reminderId) != null) //Check if the reminder exists
            {
                Reminder toRemoveReminder = GetReminderById(reminderId);
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.Reminder.Attach(toRemoveReminder);
                    db.Reminder.Remove(toRemoveReminder);
                    SaveAndCloseDataBase(db);
                }
            }
        }

        /// <summary>
        /// Deletes multiple reminders from the database. 
        /// </summary>
        /// <param name="rems"></param>
        public static void DeleteReminders(List<Reminder> rems)
        {
            //We use this method so we can attach and remove the reminders in a foreach loop, and save changes to the database after the loop.
            //If you use the DeleteReminder method in a foreach loop, it will open and close the database each time
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
                SaveAndCloseDataBase(db);
            }
                
            
        }
        /// <summary>
        /// Saves pending changes to the database, disposes it, and refreshes the local cache list
        /// </summary>
        /// <param name="db"></param>
        private static void SaveAndCloseDataBase(RemindMeDbEntities db)
        {
            db.SaveChanges();
            RefreshCacheList();
            db.Dispose();
        }
    }
}
