using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity;
using System.IO;
using Database.Entity;
using RemindMe;

namespace Data_Access_Layer
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

        public static readonly string DB_FILE = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db";

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
            conn.ConnectionString = "data source = " + DB_FILE;
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
        /// Inserts the reminder into the database.
        /// </summary>
        /// <param name="rem">The reminder you want added into the database</param>
        public static long PushReminderToDatabase(Reminder rem)
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
            return rem.Id;
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
        /// Update an existing reminder.
        /// </summary>
        /// <param name="rem">The altered reminder</param>
        public static void EditReminder(Reminder rem)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                db.Reminder.Attach(rem);
                var entry = db.Entry(rem);
                entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                SaveAndCloseDataBase(db);
            }
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
