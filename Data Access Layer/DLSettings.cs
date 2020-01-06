using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Entity;

namespace Data_Access_Layer
{
    /// <summary>
    /// This class handles(creates/updates) settings in the database
    /// </summary>
    public class DLSettings
    {

        private DLSettings() { }


        private static Settings settings;

       
        /// <summary>
        /// Reads the settings from the database and checks if reminders should be set to always on top.
        /// </summary>
        /// <returns>True if reminders are set to be always on top, false if not</returns>
        public static bool IsAlwaysOnTop()
        {
            int alwaysOnTop = 1;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    
                    alwaysOnTop = Convert.ToInt32((from g in db.Settings select g.AlwaysOnTop).SingleOrDefault());
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return alwaysOnTop == 1;                                            
        }

        /// <summary>
        /// Reads the settings from the database and checks if reminders should be set to always on top.
        /// </summary>
        /// <returns>True if reminders are set to be always on top, false if not</returns>
        public static bool IsReminderCountPopupEnabled()
        {
            int enablePopupMessage = 1;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    enablePopupMessage = Convert.ToInt32((from g in db.Settings select g.EnableReminderCountPopup).SingleOrDefault());
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return enablePopupMessage == 1;
        }


        /// <summary>
        /// Reads the settings from the database and checks if the user wants to see the popup explaining the hide reminder feature.
        /// </summary>
        /// <returns>True if the user hasn't pressed the don't remind again option yet, false if not</returns>
        public static bool HideReminderOptionEnabled()
        {
            int hideReminderOption = 0;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    hideReminderOption = Convert.ToInt32((from g in db.Settings select g.HideReminderConfirmation).SingleOrDefault());
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return hideReminderOption == 1;
        }

        /// <summary>
        /// Reads the settings from the database and checks if there should be a notification 1 hour before the reminder that there is a reminder
        /// </summary>
        /// <returns>True if the notification is enabled, false if not</returns>
        public static bool IsHourBeforeNotificationEnabled()
        {
            int notificationEnabled = 1;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    notificationEnabled = Convert.ToInt32((from g in db.Settings select g.EnableHourBeforeReminder).SingleOrDefault());
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return notificationEnabled == 1;
        }

        public static Settings Settings
        {
            get
            {
                if (settings == null)
                    RefreshSettings();

                return settings;
            }
            
        }
        /*This was testing a custom color scheme

        public static RemindMeColorScheme GetColorTheme(string themeName)
        {
            RemindMeColorScheme theme;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                theme = (from t in db.RemindMeColorScheme select t).Where(t => t.ThemeName == themeName).ToList().FirstOrDefault();
                db.Dispose();
            }
            return theme;
        }*/
        private static void RefreshSettings()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                int count = db.Settings.Where(o => o.Id >= 0).Count();
                if(count == 0)
                {
                    settings = new Settings();
                    settings.AlwaysOnTop = 1;
                    settings.StickyForm = 0;
                    settings.EnableReminderCountPopup = 1;
                    settings.EnableHourBeforeReminder = 1;
                    settings.HideReminderConfirmation = 0;
                    settings.EnableQuickTimer = 1;                    
                    UpdateSettings(settings);                   
                }
                else
                    settings = (from s in db.Settings select s).ToList().FirstOrDefault();
                db.Dispose();
            }            
        }
        public static void UpdateSettings(Settings set)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    db.Settings.Attach(set);
                    var entry = db.Entry(set);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    db.SaveChanges();                                      //push to database
                    db.Dispose();
                }
                else
                {//The settings table is still empty
                    db.Settings.Add(set);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }

        
       



    }
}
