using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLAVRProperties
    {
        private DLAVRProperties() {}

        /// <summary>
        /// Get the advanced Reminder properties for a reminder
        /// </summary>
        /// <param name="remId">The id of the reminder</param>
        /// <returns></returns>
        public static AdvancedReminderProperties GetAVRProperties(long remId)
        {
            AdvancedReminderProperties avr = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                avr = (from g in db.AdvancedReminderProperties select g).Where(r => r.Remid == remId).SingleOrDefault();
                db.Dispose();
            }
            return avr;
        }
        /// <summary>
        /// Get the advanced Reminder files/folders
        /// </summary>
        /// <param name="remId">The id of the reminder</param>
        /// <returns></returns>
        public static List<AdvancedReminderFilesFolders> GetAVRFilesFolders(long remId)
        {
            List<AdvancedReminderFilesFolders> avr = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                avr = (from g in db.AdvancedReminderFilesFolders select g).Where(r => r.Remid == remId).ToList();
                db.Dispose();
            }            
            return avr;
        }

        public static long InsertAVRProperties(AdvancedReminderProperties avr)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.AdvancedReminderProperties.Where(r => r.Remid == avr.Remid).Count() > 0)
                {                    
                    //Exists already. update.                    
                    db.AdvancedReminderProperties.Attach(avr);
                    var entry = db.Entry(avr);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                                                            
                    db.SaveChanges();
                    db.Dispose();
                }
                else
                {
                    if (db.AdvancedReminderProperties.Count() > 0)
                        avr.Id = db.AdvancedReminderProperties.Max(i => i.Id) + 1;

                    db.AdvancedReminderProperties.Add(avr);
                    db.SaveChanges();
                    db.Dispose();
                }
                
            }
            return avr.Id;
        }

        public static long InsertAVRFilesFolders(AdvancedReminderFilesFolders avr)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.AdvancedReminderFilesFolders.Where(r => r.Id == avr.Id).Count() > 0)
                {                    
                    //Exists already. update.
                    db.AdvancedReminderFilesFolders.Attach(avr);
                    var entry = db.Entry(avr);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                }
                else
                {
                    if (db.AdvancedReminderFilesFolders.Count() > 0)
                        avr.Id = db.AdvancedReminderFilesFolders.Max(i => i.Id) + 1;
                    else
                        avr.Id = 0;        
                                
                    db.AdvancedReminderFilesFolders.Add(avr);
                }
                db.SaveChanges();
                db.Dispose();
            }
            return avr.Id;
        }
        
        public static void DeleteAvrFilesFoldersById(long id)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                foreach(AdvancedReminderFilesFolders avr in db.AdvancedReminderFilesFolders.Where(r => r.Remid == id).ToList())
                {
                    db.AdvancedReminderFilesFolders.Attach(avr);
                    db.AdvancedReminderFilesFolders.Remove(avr);
                }

                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void DeleteAvrProperties(long id)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                AdvancedReminderProperties prop = GetAVRProperties(id);
                db.AdvancedReminderProperties.Attach(prop);
                db.AdvancedReminderProperties.Remove(prop);

                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void DeleteAvrProperties(AdvancedReminderProperties prop)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {                
                db.AdvancedReminderProperties.Attach(prop);
                db.AdvancedReminderProperties.Remove(prop);

                db.SaveChanges();
                db.Dispose();
            }
        }


    }
}
