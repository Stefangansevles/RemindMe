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

        /// <summary>
        /// Gets the column sizes of the Listview in the SQLite database 
        /// </summary>
        /// <returns></returns>
        public static ListviewColumnSizes GetcolumnSizes()
        {
            return DLListviewColumnSizes.GetColumnSizes();
        }
    }
}
