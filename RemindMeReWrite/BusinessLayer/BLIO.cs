using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSManager;
using System.IO;
using IWshRuntimeLibrary;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RemindMe
{
    public abstract class BLIO
    {
        static IWshShortcut Shortcut;
        static WshShell shell = new WshShell();
        /// <summary>
        /// Creates the folders and files needed by RemindMe. This should only occur once, during first use.
        /// </summary>
        public static void CreateSettings()
        {            
            Directory.CreateDirectory(Variables.IOVariables.rootFolder);            
        }
        
        /// <summary>
        /// If the user deleted the .db file, or if the user is using RemindMe for the first time, this method created the neccesary database + tables.
        /// </summary>
        public static void CreateDatabaseIfNotExist()
        {
            if (!System.IO.File.Exists(Variables.IOVariables.databaseFile))
            {
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "data source = " + Variables.IOVariables.databaseFile;
                conn.Open();

                SQLiteCommand tableReminder = new SQLiteCommand();
                SQLiteCommand tableSettings = new SQLiteCommand();
                SQLiteCommand tableSongs = new SQLiteCommand();
                tableReminder.CommandText = "CREATE TABLE [Reminder] ([Id] INTEGER NOT NULL, [Name]text NOT NULL, [Date]text NOT NULL, [RepeatType]text NOT NULL, [Note]text NOT NULL, [Enabled]bigint NOT NULL, [DayOfWeek]bigint NULL, [DayOfMonth] bigint NULL, [EveryXCustom] bigint NULL, [SoundFilePath] text NULL, [PostponeDate] text NULL, CONSTRAINT[sqlite_master_PK_Reminder] PRIMARY KEY([Id]));";
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
        }



        /// <summary>
        /// Creates an shortcut of RemindMe in the windows startup folder so that RemindMe will start automatically when windows starts.
        /// </summary>
        public static void CreateShortcut()
        {
            try
            {
                //Where do you want to create the shortcut + what is the name of the shortcut?
                Shortcut = (IWshShortcut)shell.CreateShortcut(Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk");

                //What is the shortcut's target?
                Shortcut.TargetPath = Application.StartupPath + "\\" + "RemindMe.exe";

                //Tooltip
                Shortcut.Description = "Shortcut of RemindMe";


                Shortcut.Save();
            }
            catch (Exception ex)
            {
                WriteError(ex, "Error while creating a shortcut",false);                

            }
        }

        
        

        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message, bool showErrorPopup)
        {
            using (FileStream fs = new FileStream(Variables.IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }
            if (showErrorPopup)
            {
                ErrorPopup popup = new ErrorPopup(message, ex);
                popup.Show();
            }
        }

        /// <summary>
        /// Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="description">A custom description of the error</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message, string description, bool showErrorPopup)
        {
            using (FileStream fs = new FileStream(Variables.IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }
            if (showErrorPopup)
            {
                ErrorPopup popup = new ErrorPopup(message, ex, description);
                popup.Show();
            }
        }
    }
}
