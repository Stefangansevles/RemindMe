using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// This class handles(creates/updates) settings in the database
    /// </summary>
    public abstract class DLSettings
    {
        static Settings settings;

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
                    Settings set = new Settings();
                    set.AlwaysOnTop = alwaysOnTop;
                    UpdateSettings(set);
                }
            }
            return alwaysOnTop == 1;                                            
        }


        /// <summary>
        /// Reads the settings from the database and checks if the controls should be cleared after making a new reminder.
        /// </summary>
        /// <returns>True to use sticky form, false if not</returns>
        public static bool IsStickyForm()
        {
            int stickyForm = 1;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                var count = db.Settings.Where(o => o.StickyForm >= 0).Count();
                if (count > 0)
                {
                    stickyForm = Convert.ToInt32((from g in db.Settings select g.StickyForm).SingleOrDefault());
                    db.Dispose();
                }
                else
                {
                    Settings set = new Settings();
                    set.StickyForm = stickyForm;
                    UpdateSettings(set);
                }
            }
            return stickyForm == 1;
        }

        public static Settings GetSettings()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                settings = (from s in db.Settings select s).ToList().FirstOrDefault();
                db.Dispose();
            }
            return settings;
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
