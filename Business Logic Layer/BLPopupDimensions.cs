using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public abstract class BLPopupDimensions
    {        
        public static PopupDimensions GetPopupDimensions()
        {
            return DLPopupDimensions.GetPopupDimensions();            
        }

        

        public static void UpdatePopupDimensions(PopupDimensions dimensions)
        {
            if (dimensions != null)                        
                DLPopupDimensions.UpdatePopupDimensions(dimensions);            
        }

        public static void ResetToDefaults()
        {
            DLPopupDimensions.ResetToDefaults();
        }
    }
}
