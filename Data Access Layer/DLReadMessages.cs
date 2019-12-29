using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLReadMessages
    {
        private DLReadMessages() { }        

  
        /// <summary>
        /// Save and close the database connection
        /// </summary>
        /// <param name="db"></param>
        private static void SaveAndCloseDataBase(RemindMeDbEntities db)
        {
            db.SaveChanges();
            db.Dispose();            
        } 
        
        public static List<ReadMessages> Messages
        {
            get
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.ReadMessages.Where(o => o.Id >= 0).Count();

                    if (count > 0)                    
                        return db.ReadMessages.ToList();                                            
                    else                    
                        return new List<ReadMessages>();                    
                }
            }
            
        }
    }
}
