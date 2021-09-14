﻿using Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLDatabase
    {
        private DLDatabase() { }

        private static readonly string DB_FILE = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db";

        //The neccesary query to execute to create the table Reminder
        private const string TABLE_REMINDER = "CREATE TABLE [Reminder] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Deleted] bigint DEFAULT(0) NOT NULL, [Name] text NOT NULL, [Date] text NOT NULL, [RepeatType] text NOT NULL, [Note] text NOT NULL, [Enabled] bigint NOT NULL, [DayOfMonth]bigint NULL, [EveryXCustom] bigint NULL, [RepeatDays] text NULL, [SoundFilePath] text NULL, [PostponeDate] text NULL, [Hide] bigint DEFAULT(0) NULL, [Corrupted] bigint DEFAULT(0) NULL, [EnableAdvancedReminder] bigint DEFAULT(1) NOT NULL, [UpdateTime] bigint DEFAULT(0) NOT NULL);";

        //The neccesary query to execute to create the table Settings
        private const string TABLE_SETTINGS = "CREATE TABLE [Settings] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [PopupType] text NOT NULL, [StickyForm] bigint NOT NULL, [EnableReminderCountPopup] bigint DEFAULT(1) NOT NULL, [EnableHourBeforeReminder] bigint DEFAULT(1) NOT NULL, [HideReminderConfirmation] bigint DEFAULT(0) NULL, [EnableQuickTimer] bigint DEFAULT(1) NOT NULL, [LastVersion] text NULL, [DefaultTimerSound] text NULL, [EnableAdvancedReminders] bigint NULL, [UniqueString] text NULL, [RemindMeTheme] text DEFAULT('Default') NOT NULL, [DrawerUseColors] bigint DEFAULT(0) NULL, [DrawerHighlight] bigint DEFAULT(1) NULL, [DrawerBackground] bigint DEFAULT(0) NULL, [CurrentTheme] bigint DEFAULT(-1) NULL, [MaterialDesign] bigint DEFAULT(1) NULL, [AutoUpdate] bigint DEFAULT(1) NOT NULL, [TimerVolume] bigint DEFAULT(100) NOT NULL);";

        //The neccesary query to execute to create the table Songs
        private const string TABLE_SONGS = "CREATE TABLE [Songs] ( [Id] INTEGER NOT NULL, [SongFileName]text NOT NULL, [SongFilePath]text NOT NULL, CONSTRAINT[sqlite_master_PK_Songs] PRIMARY KEY([Id]));";

        //The neccesary query to execute to create the table PopupDimensions
        private const string TABLE_POPUP_DIMENSIONS = "CREATE TABLE [PopupDimensions] ([Id] INTEGER NOT NULL, [FormWidth]bigint NOT NULL, [FormHeight]bigint NOT NULL, [FontTitleSize]bigint NOT NULL, [FontNoteSize]bigint NOT NULL, CONSTRAINT[sqlite_master_PK_PopupDimensions] PRIMARY KEY([Id]));";

        //The neccesary query to execute to create the table Listview_Column_sizes
        private const string TABLE_LISTVIEW_COLUMN_SIZES = "CREATE TABLE[ListviewColumnSizes] ([Id]INTEGER NOT NULL, [Title]bigint NOT NULL, [Date]bigint NOT NULL, [Repeating]bigint NOT NULL, [Enabled]bigint NOT NULL, CONSTRAINT[sqlite_master_PK_ListviewColumnSizes] PRIMARY KEY([Id]));";

        //The neccesary query to execute to create the table Listview_Column_sizes
        private const string TABLE_HOTKEYS = "CREATE TABLE [Hotkeys] ([Id] INTEGER NOT NULL, [Name]text NOT NULL, [Key]text NOT NULL, [Modifiers]text NOT NULL, CONSTRAINT[sqlite_master_PK_Hotkeys] PRIMARY KEY([Id]));";
    
        //AVR = Advanced reminder. Table contains advanced reminder properties. Has a foreign key to TABLE_REMINDER
        private const string TABLE_AVR_PROPERTIES = "CREATE TABLE [AdvancedReminderProperties] ([Id] INTEGER NOT NULL, [Remid]bigint NOT NULL, [BatchScript]text NULL, [ShowReminder] bigint DEFAULT 1  NULL, CONSTRAINT[sqlite_master_PK_AdvancedReminderProperties] PRIMARY KEY([Id]));";

        //Contains the files/folders and their actions, example: delete folder x. open file x. Has a foreign key to TABLE_REMINDER
        private const string TABLE_AVR_FILES_FOLDERS = "CREATE TABLE [AdvancedReminderFilesFolders] ([Id] INTEGER NOT NULL, [Remid]bigint NOT NULL, [Path]text NOT NULL, [Action]text NOT NULL, CONSTRAINT[sqlite_master_PK_AdvancedReminderFilesFolders] PRIMARY KEY([Id]));";

        //The neccesary query to execute to create the table ReadMessages
        private const string TABLE_READ_MESSAGES = "CREATE TABLE [ReadMessages] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [ReadMessageId] bigint NOT NULL, [ReadDate] text NOT NULL, [MessageText] text NULL);";

        //The neccesary query to execute to create the table ButtonSpaces
        private const string TABLE_BUTTONSPACES = "CREATE TABLE [ButtonSpaces] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Reminders] bigint DEFAULT(5) NOT NULL, [Timer] bigint DEFAULT(5) NOT NULL, [BackupImport] bigint DEFAULT(5) NOT NULL, [Settings] bigint DEFAULT(5) NOT NULL, [SoundEffects] bigint DEFAULT(5) NOT NULL, [ResizePopup] bigint DEFAULT(5) NOT NULL, [MessageCenter] bigint DEFAULT(5) NOT NULL, [DebugMode] bigint DEFAULT(5) NOT NULL);";

        //The neccesary query to execute to create the table ButtonSpaces
        private const string TABLE_THEMES = "CREATE TABLE [Themes] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Primary] bigint DEFAULT(0) NOT NULL, [DarkPrimary] bigint DEFAULT(0) NOT NULL, [LightPrimary] bigint DEFAULT(0) NOT NULL, [Accent] bigint DEFAULT(0) NOT NULL, [TextShade] bigint DEFAULT(0) NOT NULL, [Mode] bigint DEFAULT(0) NULL, [ThemeName] text NULL, [IsDefault] bigint DEFAULT(0) NOT NULL);";

        //The neccesary query to execute to create the table HttpRequests
        private const string TABLE_HTTP = "CREATE TABLE [HttpRequests] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [reminderId] bigint NOT NULL, [URL] text NOT NULL, [Type] text NOT NULL, [AcceptHeader] text NOT NULL, [ContentTypeHeader] text NOT NULL, [OtherHeaders] text NOT NULL, [Body] text NOT NULL, [Interval] bigint NOT NULL, [AfterPopup] text DEFAULT('Stop') NOT NULL);";

        //The neccesary query to execute to create the table HttpRequestCondition
        private const string TABLE_HTTP_CONDITION = "CREATE TABLE [HttpRequestCondition] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [RequestId] bigint NOT NULL, [Condition] text NOT NULL, [DataType] text NOT NULL, [Property] text NOT NULL, [Operator] text NOT NULL, [Value] text NOT NULL);";

        //The neccesary query to execute to create the table RemindMeColorThemes, used to give RemindMe multiple color scheme
        //private const string TABLE_REMINDME_COLOR_SCHEMES = "CREATE TABLE [RemindMeColorScheme] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [ThemeName] text NOT NULL, [PrimaryBottomLeft] text NOT NULL, [PrimaryBottomRight] text NOT NULL, [PrimaryTopLeft] text NOT NULL, [PrimaryTopRight] text NOT NULL, [SecondaryBottomLeft] text NOT NULL, [SecondaryBottomRight] text NOT NULL, [SecondaryTopLeft] text NOT NULL, [SecondaryTopRight] text NOT NULL);";


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
            SQLiteCommand tablePopupDimensions = new SQLiteCommand();
            SQLiteCommand tableListviewColumnSizes = new SQLiteCommand();
            SQLiteCommand tableHotkeys = new SQLiteCommand();
            SQLiteCommand tableAvrProperties = new SQLiteCommand();
            SQLiteCommand tableAvrFilesFolders = new SQLiteCommand();
            SQLiteCommand tableReadMessages = new SQLiteCommand();
            SQLiteCommand tableButtonSpaces = new SQLiteCommand();
            SQLiteCommand tableThemes = new SQLiteCommand();
            SQLiteCommand tableHttp = new SQLiteCommand();
            SQLiteCommand tableHttpCon = new SQLiteCommand();
            //SQLiteCommand tableRemindMeColorSchemes = new SQLiteCommand();


            tableReminder.CommandText = TABLE_REMINDER;
            tableSettings.CommandText = TABLE_SETTINGS;
            tableSongs.CommandText = TABLE_SONGS;
            tablePopupDimensions.CommandText = TABLE_POPUP_DIMENSIONS;
            tableListviewColumnSizes.CommandText = TABLE_LISTVIEW_COLUMN_SIZES;
            tableHotkeys.CommandText = TABLE_HOTKEYS;
            tableAvrProperties.CommandText = TABLE_AVR_PROPERTIES;
            tableAvrFilesFolders.CommandText = TABLE_AVR_FILES_FOLDERS;
            tableReadMessages.CommandText = TABLE_READ_MESSAGES;
            tableButtonSpaces.CommandText = TABLE_BUTTONSPACES;
            tableThemes.CommandText = TABLE_THEMES;
            tableHttp.CommandText = TABLE_HTTP;
            tableHttpCon.CommandText = TABLE_HTTP_CONDITION;
            //tableRemindMeColorSchemes.CommandText = TABLE_REMINDME_COLOR_SCHEMES;

            tableReminder.Connection = conn;
            tableSettings.Connection = conn;
            tableSongs.Connection = conn;
            tablePopupDimensions.Connection = conn;
            tableListviewColumnSizes.Connection = conn;
            tableHotkeys.Connection = conn;
            tableAvrProperties.Connection = conn;
            tableAvrFilesFolders.Connection = conn;
            tableReadMessages.Connection = conn;
            tableButtonSpaces.Connection = conn;
            tableThemes.Connection = conn;
            tableHttp.Connection = conn;
            tableHttpCon.Connection = conn;
            //tableRemindMeColorSchemes.Connection = conn;

            tableReminder.ExecuteNonQuery();
            tableSettings.ExecuteNonQuery();
            tableSongs.ExecuteNonQuery();
            tablePopupDimensions.ExecuteNonQuery();
            tableListviewColumnSizes.ExecuteNonQuery();
            tableHotkeys.ExecuteNonQuery();
            tableAvrProperties.ExecuteNonQuery();
            tableAvrFilesFolders.ExecuteNonQuery();
            tableReadMessages.ExecuteNonQuery();
            tableButtonSpaces.ExecuteNonQuery();
            tableThemes.ExecuteNonQuery();
            tableHttp.ExecuteNonQuery();
            tableHttpCon.ExecuteNonQuery();
            //tableRemindMeColorSchemes.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
        }
        /// <summary>
        /// Checks wether the table x has column x
        /// </summary>
        /// <param name="columnName">The column you want to check on</param>
        /// <param name="table">The table you want to check on</param>
        /// <returns></returns>
        public static bool HasColumn(string columnName, string table)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                try
                {
                    var t = db.Database.SqlQuery<object>("SELECT " + columnName + " FROM [" + table + "]").ToList();
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
            var reminderNames = typeof(Reminder).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in reminderNames)
            {
                if (!HasColumn(columnName, "reminder"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var settingNames = typeof(Settings).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in settingNames)
            {                
                if (!HasColumn(columnName, "settings"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var songNames = typeof(Songs).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in songNames)
            {
                if (!HasColumn(columnName, "songs"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var popupDimensionNames = typeof(PopupDimensions).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in popupDimensionNames)
            {
                if (!HasColumn(columnName, "PopupDimensions"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var lvColumnNames = typeof(ListviewColumnSizes).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in lvColumnNames)
            {
                if (!HasColumn(columnName, "ListviewColumnSizes"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var hotkeys = typeof(Hotkeys).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in hotkeys)
            {
                if (!HasColumn(columnName, "Hotkeys"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var AVR_Properties = typeof(AdvancedReminderProperties).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in AVR_Properties)
            {
                if (!HasColumn(columnName, "AdvancedReminderProperties"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var AVR_Files_Folders = typeof(AdvancedReminderFilesFolders).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in AVR_Files_Folders)
            {
                if (!HasColumn(columnName, "AdvancedReminderFilesFolders"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var readMessages = typeof(ReadMessages).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in readMessages)
            {
                if (!HasColumn(columnName, "ReadMessages"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var buttonSpaces = typeof(ButtonSpaces).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in buttonSpaces)
            {
                if (!HasColumn(columnName, "ButtonSpaces"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var themes = typeof(Themes).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in themes)
            {
                if (!HasColumn("["+columnName+"]", "Themes"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var http = typeof(HttpRequests).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in http)
            {
                if (!HasColumn("[" + columnName + "]", "HttpRequests"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var httpCon = typeof(HttpRequestCondition).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in httpCon)
            {
                if (!HasColumn("[" + columnName + "]", "HttpRequestCondition"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            /*This was testing a custom color scheme
            var remindMeColorSchemes = typeof(RemindMeColorScheme).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in remindMeColorSchemes)
            {
                if (!HasColumn(columnName, "RemindMeColorScheme"))
                    return false; //aww damn! the user has an outdated .db file!                
            }*/

            return true;
        }

        /// <summary>
        /// Checks if the database has the given table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static bool HasTable(string table,RemindMeDbEntities db)
        {
            try
            {
                var result = db.Database.ExecuteSqlCommand("select * from [" + table + "]");
                return true;
            }
            catch(SQLiteException)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if the user's .db file has all the tables from the database model.
        /// </summary>
        /// <returns></returns>
        public static bool HasAllTables()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (HasTable("reminder", db) && HasTable("settings", db) 
                    && HasTable("songs", db) && HasTable("popupdimensions", db) 
                    && HasTable("listviewcolumnsizes", db) && HasTable("hotkeys", db)
                    && HasTable("AdvancedReminderProperties", db) && HasTable("AdvancedReminderFilesFolders", db)
                    && HasTable("ReadMessages", db) && HasTable("ButtonSpaces", db) && HasTable("Themes", db)
                    && HasTable("HttpRequests", db) && HasTable("HttpRequestCondition", db))
                    return true;
                else
                    return false;                
            }
            
        }

        /// <summary>
        /// Inserts all missing tables into the user's .db file 
        /// </summary>
        public static void InsertMissingTables()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "data source = " + DB_FILE;
                conn.Open();

                SQLiteCommand tableReminder = new SQLiteCommand();
                SQLiteCommand tableSettings = new SQLiteCommand();
                SQLiteCommand tableSongs = new SQLiteCommand();
                SQLiteCommand tablePopupDimensions = new SQLiteCommand();
                SQLiteCommand tableListviewColumnSizes = new SQLiteCommand();
                SQLiteCommand tableHotkeys = new SQLiteCommand();
                SQLiteCommand tableAvrProperties = new SQLiteCommand();
                SQLiteCommand tableAvrFilesFolders = new SQLiteCommand();
                SQLiteCommand tableReadMessages = new SQLiteCommand();
                SQLiteCommand tableButtonSpaces = new SQLiteCommand();
                SQLiteCommand tableThemes = new SQLiteCommand();
                SQLiteCommand tableHttp = new SQLiteCommand();
                SQLiteCommand tableHttpCon = new SQLiteCommand();
                //SQLiteCommand tableRemindMeColorSchemes = new SQLiteCommand();


                tableReminder.CommandText = TABLE_REMINDER;
                tableSettings.CommandText = TABLE_SETTINGS;
                tableSongs.CommandText = TABLE_SONGS;
                tablePopupDimensions.CommandText = TABLE_POPUP_DIMENSIONS;
                tableListviewColumnSizes.CommandText = TABLE_LISTVIEW_COLUMN_SIZES;
                tableHotkeys.CommandText = TABLE_HOTKEYS;
                tableAvrProperties.CommandText = TABLE_AVR_PROPERTIES;
                tableAvrFilesFolders.CommandText = TABLE_AVR_FILES_FOLDERS;
                tableReadMessages.CommandText = TABLE_READ_MESSAGES;
                tableButtonSpaces.CommandText = TABLE_BUTTONSPACES;
                tableThemes.CommandText = TABLE_THEMES;
                tableHttp.CommandText = TABLE_HTTP;
                tableHttpCon.CommandText = TABLE_HTTP_CONDITION;
                //tableRemindMeColorSchemes.CommandText = TABLE_REMINDME_COLOR_SCHEMES;

                tableReminder.Connection = conn;
                tableSettings.Connection = conn;
                tableSongs.Connection = conn;
                tablePopupDimensions.Connection = conn;
                tableListviewColumnSizes.Connection = conn;
                tableHotkeys.Connection = conn;
                tableAvrProperties.Connection = conn;
                tableAvrFilesFolders.Connection = conn;
                tableReadMessages.Connection = conn;
                tableButtonSpaces.Connection = conn;
                tableThemes.Connection = conn;
                tableHttp.Connection = conn;
                tableHttpCon.Connection = conn;
                //tableRemindMeColorSchemes.Connection = conn;


                if (!HasTable("Reminder", db))
                    tableReminder.ExecuteNonQuery();

                if (!HasTable("Settings", db))
                    tableSettings.ExecuteNonQuery();

                if (!HasTable("Songs", db))
                    tableSongs.ExecuteNonQuery();

                if (!HasTable("Popupdimensions", db))
                    tablePopupDimensions.ExecuteNonQuery();

                if (!HasTable("ListviewColumnSizes", db))
                    tableListviewColumnSizes.ExecuteNonQuery();

                if (!HasTable("Hotkeys", db))
                    tableHotkeys.ExecuteNonQuery();

                if (!HasTable("AdvancedReminderProperties", db))
                    tableAvrProperties.ExecuteNonQuery();

                if (!HasTable("AdvancedReminderFilesFolders", db))
                    tableAvrFilesFolders.ExecuteNonQuery();

                if (!HasTable("ReadMessages", db))
                    tableReadMessages.ExecuteNonQuery();

                if (!HasTable("ButtonSpaces", db))
                    tableButtonSpaces.ExecuteNonQuery();

                if (!HasTable("Themes", db))
                    tableThemes.ExecuteNonQuery();

                if (!HasTable("HttpRequests", db))
                    tableHttp.ExecuteNonQuery();

                if (!HasTable("HttpRequestCondition", db))
                    tableHttpCon.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                db.Dispose();
            }
        }

        /// <summary>
        /// This method will insert every missing column for each table into the database. Will only be called if HasallColumns() returns false. This means the user has an outdated .db file
        /// </summary>
        public static void InsertNewColumns()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                //every column that SHOULD exist
                var reminderNames = typeof(Reminder).GetProperties().Select(property => property.Name).ToArray();
                var settingNames = typeof(Settings).GetProperties().Select(property => property.Name).ToArray();
                var songNames = typeof(Songs).GetProperties().Select(property => property.Name).ToArray();
                var popupDimensionsNames = typeof(PopupDimensions).GetProperties().Select(property => property.Name).ToArray();
                var lvColumnSizes = typeof(ListviewColumnSizes).GetProperties().Select(property => property.Name).ToArray();
                var hotkeys = typeof(Hotkeys).GetProperties().Select(property => property.Name).ToArray();
                var avrProperties = typeof(AdvancedReminderProperties).GetProperties().Select(property => property.Name).ToArray();
                var avrFilesFolders = typeof(AdvancedReminderFilesFolders).GetProperties().Select(property => property.Name).ToArray();
                var readMessages = typeof(ReadMessages).GetProperties().Select(property => property.Name).ToArray();
                var buttonSpaces = typeof(ButtonSpaces).GetProperties().Select(property => property.Name).ToArray();
                var themes = typeof(Themes).GetProperties().Select(property => property.Name).ToArray();
                var http = typeof(HttpRequests).GetProperties().Select(property => property.Name).ToArray();
                var httpCon = typeof(HttpRequestCondition).GetProperties().Select(property => property.Name).ToArray();
                //var remindMeColorSchemes = typeof(RemindMeColorScheme).GetProperties().Select(property => property.Name).ToArray();

                foreach (string column in reminderNames)
                {
                    if (!HasColumn(column, "reminder"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE REMINDER ADD COLUMN " + column + " " + GetReminderColumnSqlType(column));
                }

                foreach (string column in settingNames)
                {
                    if (!HasColumn(column, "settings"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE SETTINGS ADD COLUMN " + column + " " + GetSettingColumnSqlType(column));
                }

                foreach (string column in songNames)
                {
                    if (!HasColumn(column, "songs"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE SONGS ADD COLUMN " + column + " " + GetSongColumnSqlType(column));
                }

                foreach (string column in popupDimensionsNames)
                {
                    if (!HasColumn(column, "PopupDimensions"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE POPUPDIMENSIONS ADD COLUMN " + column + " " + GetPopupDimensionsColumnSqlType(column));
                }

                foreach (string column in lvColumnSizes)
                {
                    if (!HasColumn(column, "ListviewColumnSizes"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE ListviewColumnSizes ADD COLUMN " + column + " " + GetLvColumnSizesColumnSqlType(column));
                }

                foreach (string column in hotkeys)
                {
                    if (!HasColumn(column, "Hotkeys"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE Hotkeys ADD COLUMN " + column + " " + GetHotkeysColumnSqlType(column));
                }

                foreach (string column in avrProperties)
                {
                    if (!HasColumn(column, "AdvancedReminderProperties"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE AdvancedReminderProperties ADD COLUMN " + column + " " + GetAvrPropertiesColumnSqlType(column));
                }

                foreach (string column in avrFilesFolders)
                {
                    if (!HasColumn(column, "AdvancedReminderFilesFolders"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE AdvancedReminderFilesFolders ADD COLUMN " + column + " " + GetAvrFilesFoldersColumnSqlType(column));
                }

                foreach (string column in readMessages)
                {
                    if (!HasColumn(column, "ReadMessages"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE ReadMessages ADD COLUMN " + column + " " + GetReadMessagesColumnSqlType(column));
                }

                foreach (string column in buttonSpaces)
                {
                    if (!HasColumn(column, "ButtonSpaces"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE ButtonSpaces ADD COLUMN " + column + " " + GetButtonSpacesColumnSqlType(column));
                }

                foreach (string column in themes)
                {
                    try
                    {
                        if (!HasColumn("["+column+"]", "Themes"))
                            db.Database.ExecuteSqlCommand("ALTER TABLE Themes ADD COLUMN [" + column + "] " + GetThemesColumnSqlType(column));
                    }
                    catch(Exception ex)
                    {
                        if (ex.Message == "SQL logic error\r\nnear \"Primary\": syntax error") {} //not important. Not sure why this error is thrown, but everything works.
                        else throw ex;
                    }
                }

                foreach (string column in http)
                {
                    if (!HasColumn(column, "HttpRequests"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE HttpRequests ADD COLUMN " + column + " " + GetHttpColumnSqlType(column));
                }

                foreach (string column in httpCon)
                {
                    if (!HasColumn(column, "HttpRequestCondition"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE HttpRequestCondition ADD COLUMN " + column + " " + GetHttpConditionColumnSqlType(column));
                }

                db.SaveChanges();                
                db.Dispose();
            }
        }

        /// <summary>
        /// Gets the SQLite data types of the reminder columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetReminderColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "Deleted": return "bigint DEFAULT 0 NOT NULL";
                case "Name": return "text NOT NULL DEFAULT ''";
                case "Date": return "text NOT NULL DEFAULT '1-1-1990'";
                case "RepeatType": return "text NOT NULL DEFAULT 'none'";
                case "Note": return "text NULL ";
                case "Enabled": return "bigint NOT NULL DEFAULT '1'";
                case "DayOfWeek": return "bigint NULL";
                case "EveryXCustom": return "bigint NULL";
                case "RepeatDays": return "text NULL";
                case "SoundFilePath": return "text NULL";
                case "PostponeDate": return "text NULL";
                case "Hide": return "bigint DEFAULT 0  NULL";
                case "Corrupted": return "bigint DEFAULT 0  NULL";
                case "EnableAdvancedReminder": return "bigint DEFAULT 1  NOT NULL";
                case "UpdateTime": return "bigint DEFAULT(0) NOT NULL";
                default: return "text NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data types of the settings columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetSettingColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {
                case "PopupType": return "text NOT NULL DEFAULT('AlwaysOnTop')";
                case "StickyForm": return "INTEGER DEFAULT 0 NOT NULL";
                case "EnablePopupMessage": return "INTEGER DEFAULT 1 NOT NULL";
                case "EnableHourBeforeReminder": return "INTEGER DEFAULT 1 NOT NULL";
                case "HideReminderConfirmation": return "bigint DEFAULT 0  NULL";
                case "EnableQuickTimer": return "bigint DEFAULT 1  NOT NULL";
                case "LastVersion": return "text NULL";
                case "DefaultTimerSound": return "text NULL";
                case "EnableAdvancedReminders": return "bigint DEFAULT 0 NULL";
                case "UniqueString": return "text NULL";
                case "RemindMeTheme": return "text DEFAULT('Default') NOT NULL";
                case "DrawerUseColors": return "bigint DEFAULT 0 NULL";
                case "DrawerHighlight": return "bigint DEFAULT 1 NULL";
                case "DrawerBackground": return "bigint DEFAULT 0 NULL";
                case "CurrentTheme": return   "bigint DEFAULT -1 NULL";
                case "MaterialDesign": return "bigint DEFAULT 1 NULL";
                case "IsDefault": return "bigint DEFAULT 0 NOT NULL";
                case "AutoUpdate": return "bigint DEFAULT 1 NOT NULL";
                case "TimerVolume": return "bigint DEFAULT 100 NOT NULL";
                default: return "text NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data types of the songs columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetSongColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "SongFileName": return "text NOT NULL";
                case "SongFilePath": return "text NOT NULL";
                default: return "text NULL";
            }
        }


        /// <summary>
        /// Gets the SQLite data types of the songs columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetPopupDimensionsColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "FormWidth": return "bigint NOT NULL";
                case "FormHeight": return "bigint NOT NULL";
                case "FontTitleSize": return "bigint NOT NULL";
                case "FontNoteSize ": return "bigint NOT NULL";

                default: return "text NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data type of a column in the LvColumnSizes table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetLvColumnSizesColumnSqlType(string columnName)
        {
            switch (columnName)
            {                
                case "Id": return "INTEGER NOT NULL";
                case "Title": return "bigint NOT NULL";
                case "Date": return "bigint NOT NULL";
                case "Repeating": return "bigint NOT NULL";
                case "Enabled ": return "bigint NOT NULL";

                default: return "bigint NOT NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data type of a column in the Hotkeys table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetHotkeysColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "Name": return "text NOT NULL";
                case "Key": return "text NOT NULL";
                case "Modifiers": return "text NOT NULL";                
                default: return "text NOT NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data type of a column in the AvrProperties table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetAvrPropertiesColumnSqlType(string columnName)
        {
            switch (columnName)
            {                
                case "Id": return "INTEGER NOT NULL";
                case "Remid": return "bigint NOT NULL";
                case "BatchScript": return "text NULL";
                case "ShowReminder": return "bigint DEFAULT 1  NULL";
                default: return "text NOT NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data type of a column in the AvrFilesFolders table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetAvrFilesFoldersColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "Remid": return "bigint NOT NULL";
                case "Path": return "text NOT NULL";
                case "Action": return "text NOT NULL";
                default: return "text NOT NULL";
            }
        }

        /// <summary>
        /// Gets the SQLite data type of a column in the ReadMessages table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetReadMessagesColumnSqlType(string columnName)
        {            
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "ReadMessageId": return "INTEGER NOT NULL";
                case "ReadDate": return "TEXT NOT NULL";
                case "MessageText": return "text NULL";
                default: return "text NOT NULL";
            }
        }

        private static string GetButtonSpacesColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Reminders": return "bigint DEFAULT(5) NOT NULL";
                case "Timer": return "bigint DEFAULT(5) NOT NULL";
                case "BackupImport": return "bigint DEFAULT(5) NOT NULL";
                case "Settings": return "bigint DEFAULT(5) NOT NULL";
                case "SoundEffects": return "bigint DEFAULT(5) NOT NULL";
                case "ResizePopup": return "bigint DEFAULT(5) NOT NULL";
                case "MessageCenter": return "bigint DEFAULT(5) NOT NULL";
                case "DebugMode": return "bigint DEFAULT(5) NOT NULL";
                default: return "text NOT NULL";
            }
        }

        private static string GetThemesColumnSqlType(string columnName)
        {
            switch (columnName)
            {                
                case "Primary": return "bigint DEFAULT(0) NOT NULL";
                case "DarkPrimary": return "bigint DEFAULT(0) NOT NULL";
                case "LightPrimary": return "bigint DEFAULT(0) NOT NULL";
                case "Accent": return "bigint DEFAULT(0) NOT NULL";
                case "TextShade": return "bigint DEFAULT(0) NOT NULL";
                case "Mode": return "bigint DEFAULT(0) NOT NULL";
                case "ThemeName": return "text NULL";
                default: return "text NOT NULL";
            }
        }

        private static string GetHttpColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "reminderId": return "bigint NOT NULL";
                case "URL": return "text NOT NULL";
                case "Type": return "text NOT NULL";
                case "AcceptHeader": return "text NOT NULL";
                case "ContentTypeHeader": return "text NOT NULL";
                case "OtherHeaders": return "text NOT NULL";
                case "Body": return "text NOT NULL";
                case "Interval": return " bigint NOT NULL";
                case "AfterPopup": return "text DEFAULT('Stop') NOT NULL";
                default: return "text NOT NULL";
            }
        }

        private static string GetHttpConditionColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Id": return "INTEGER NOT NULL";
                case "RequestId": return "bigint NOT NULL";                
                case "Condition": return "text NOT NULL";
                case "DataType": return "text NOT NULL";
                case "Property": return "text NOT NULL";
                case "Operator": return "text NOT NULL";
                case "Value": return "text NOT NULL";                             
                default: return "text NOT NULL";
            }
        }

        /*This was testing a custom color scheme
        /// <summary>
        /// Gets the SQLite data type of a column in the RemindMeColorThemes table, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetRemindMeColorSchemesColumnSqlType(string columnName)
        {
            switch (columnName)
            {
                case "Id": return "INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL";
                case "ThemeName": return "TEXT NOT NULL";
                case "PrimaryBottomLeft": return "TEXT NOT NULL";
                case "PrimaryBottomRight": return "TEXT NOT NULL";
                case "PrimaryTopLeft": return "TEXT NOT NULL";
                case "PrimaryTopRight": return "TEXT NOT NULL";
                case "SecondaryBottomLeft": return "TEXT NOT NULL";
                case "SecondaryBottomRight": return "TEXT NOT NULL";
                case "SecondaryTopLeft": return "TEXT NOT NULL";
                case "SecondaryTopRight": return "TEXT NOT NULL";
                default: return "text NOT NULL";
            }
        }*/

    }
}
