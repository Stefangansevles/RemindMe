using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Database.Entity;

namespace Business_Logic_Layer
{
    public abstract class BLSettings
    {
        /// <summary>
        /// Reads the settings from the database and checks if reminders should be set to always on top.
        /// </summary>
        /// <returns>True if reminders are set to be always on top, false if not</returns>
        public static bool IsAlwaysOnTop()
        {
            //no business logic (yet)
            return DLSettings.IsAlwaysOnTop();
        }


        /// <summary>
        /// Reads the settings from the database and checks if the controls should be cleared after making a new reminder.
        /// </summary>
        /// <returns>True to use sticky form, false if not</returns>
        public static bool IsStickyForm()
        {
            return DLSettings.IsStickyForm();
        }

        public static Settings GetSettings()
        {
            return DLSettings.GetSettings();
        }
        
        public static void UpdateSettings(Settings set)
        {
            if (set != null)
                DLSettings.UpdateSettings(set);
        }

    }
}
