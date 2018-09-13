using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLAVRProperties
    {
        private BLAVRProperties() { }

        /// <summary>
        /// Get the advanced Reminder properties for a reminder
        /// </summary>
        /// <param name="remId">The id of the reminder</param>
        /// <returns></returns>
        public static AdvancedReminderProperties GetAVRProperties(long remId)
        {
            //First check if the reminder exists
            if (DLReminders.GetReminderById(remId) == null)
                return null;

            return DLAVRProperties.GetAVRProperties(remId);
        }
        /// <summary>
        /// Get the advanced Reminder files/folders
        /// </summary>
        /// <param name="remId">The id of the reminder</param>
        /// <returns></returns>
        public static List<AdvancedReminderFilesFolders> GetAVRFilesFolders(long remId)
        {
            //First check if the reminder exists
            if (DLReminders.GetReminderById(remId) == null)
                return null;
            
            return DLAVRProperties.GetAVRFilesFolders(remId);
        }



        /// <summary>
        /// Inserts Advanced reminder properties into the database, with a link to the reminder by it's ID
        /// </summary>
        /// <param name="avr"></param>
        /// <returns>The id of the newly inserted row. -1 if something went wrong</returns>
        public static long InsertAVRProperties(AdvancedReminderProperties avr)
        {
            //First check if the reminder exists
            if (DLReminders.GetReminderById(avr.Remid) == null)
                return -1;

            return DLAVRProperties.InsertAVRProperties(avr);
        }

        /// <summary>
        /// Inserts file/folder actions into the database, with a link to the reminder by it's ID
        /// </summary>
        /// <param name="avr"></param>
        /// <returns>The id of the newly inserted row. -1 if something went wrong</returns>
        public static long InsertAVRFilesFolders(AdvancedReminderFilesFolders avr)
        {
            //First check if the reminder exists
            if (DLReminders.GetReminderById(avr.Remid) == null)
                return -1;

            return DLAVRProperties.InsertAVRFilesFolders(avr);
        }


        public static void DeleteAvrFilesFoldersById(long id)
        {            
            DLAVRProperties.DeleteAvrFilesFoldersById(id);
        }
    }
}
