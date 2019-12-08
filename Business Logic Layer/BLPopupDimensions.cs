using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLPopupDimensions
    {
        private BLPopupDimensions() { }

        /// <summary>
        /// Gets the popup dimensions from the SQLite database. This determines how big the RemindMe popup should be in length and height
        /// </summary>
        /// <returns></returns>
        public static PopupDimensions GetPopupDimensions()
        {
            return DLPopupDimensions.GetPopupDimensions();            
        }


        /// <summary>
        /// Updates the popup dimensions in the SQLite database. This determines how big the RemindMe popup should be in length and height
        /// </summary>        
        /// <param name="dimensions"></param>
        public static void UpdatePopupDimensions(PopupDimensions dimensions)
        {
            if (dimensions != null)                        
                DLPopupDimensions.UpdatePopupDimensions(dimensions);            
        }

        /// <summary>
        /// Resets the popup dimensions to their default sizes
        /// </summary>
        public static void ResetToDefaults()
        {
            DLPopupDimensions.ResetToDefaults();
        }
    }
}
