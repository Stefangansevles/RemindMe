using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLHotkeys
    {        
        private DLHotkeys() { }


        /// <summary>
        /// Reads the settings from the database and checks if reminders should be set to always on top.
        /// </summary>
        /// <returns>True if reminders are set to be always on top, false if not</returns>
        public static Hotkeys TimerPopup
        {
            get
            {
                Hotkeys hotKey = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    var count = db.Hotkeys.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {

                        hotKey = (from g in db.Hotkeys select g).Where(i => i.Name == "Timer").SingleOrDefault();
                        db.Dispose();                                                                        
                    }                    
                }
                return hotKey;
            }
            set
            {
                UpdateHotkey(value);
            }      
        }

        public static void InsertHotkey(Hotkeys hotkey)
        {            
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.Hotkeys.Count() > 0)
                    hotkey.Id = db.Reminder.Max(i => i.Id) + 1;

                db.Hotkeys.Add(hotkey);
                db.SaveChanges();                
                db.Dispose();
            }            
        }
        private static void UpdateHotkey(Hotkeys hotkey)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                var count = db.Hotkeys.Where(o => o.Id >= hotkey.Id).Count();
                if (count == 1)
                {
                    db.Hotkeys.Attach(hotkey);
                    var entry = db.Entry(hotkey);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    db.SaveChanges();                                      //push to database
                    db.Dispose();
                }
                else
                {//The settings table is still empty
                    db.Hotkeys.Add(hotkey);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }          
    }
}
