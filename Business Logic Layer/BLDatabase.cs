using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLDatabase
    {
        private BLDatabase() { }
        private static readonly string DB_FILE = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db";

        /// <summary>
        /// Creates the database with associated tables
        /// </summary>
        public static void CreateDatabase()
        {
            DLDatabase.CreateDatabase();
        }

        /// <summary>
        /// Checks wether the table x has column x
        /// </summary>
        /// <param name="columnName">The column you want to check on</param>
        /// <param name="table">The table you want to check on</param>
        /// <returns></returns>
        public static bool HasColumn(string columnName, string table)
        {
            return DLDatabase.HasColumn(columnName, table);
        }

        /// <summary>
        /// Checks if the user's .db file has all the columns from the database model.
        /// </summary>
        /// <returns></returns>
        public static bool HasAllColumns()
        {
            return DLDatabase.HasAllColumns();            
        }

        /// <summary>
        /// This method will insert missing columns into the table reminder. Will only be called if HasallColumns() returns false. This means the user has an outdated .db file
        /// </summary>
        public static void InsertNewColumns()
        {
            DLDatabase.InsertNewColumns(); 
        }  
    }
}
