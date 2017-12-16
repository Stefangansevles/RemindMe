using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Database.Entity;

namespace Business_Logic_Layer
{
    public class BLListviewColumnSizes
    {
        private BLListviewColumnSizes() { }
        public static ListviewColumnSizes GetcolumnSizes()
        {
            return DLListviewColumnSizes.GetColumnSizes();
        }

        public static void UpdateListviewSizes(ListviewColumnSizes dimensions)
        {
            if (dimensions != null)
                DLListviewColumnSizes.UpdateListviewSizes(dimensions);
        }

        public static void ResetToDefaults()
        {
            DLListviewColumnSizes.ResetToDefaults();
        }
    }
}
