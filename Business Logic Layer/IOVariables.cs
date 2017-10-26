using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Business_Logic_Layer
{
    /// <summary>
    /// This class contains IO related variables, that you don't want to declare in each class.
    /// </summary>
    public class IOVariables
    {
        private IOVariables() { }

        /// <summary>
        /// Contains the path to the SQLite Database of RemindMe
        /// </summary>
        public static readonly string databaseFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db";
        
        
        /// <summary>
        /// Contains the path to the root folder of RemindMe
        /// </summary>
        public static readonly string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemindMe\";              

        /// <summary>
        /// Contains the path to the error log file of RemindMe. This contains exceptions and when they occured.
        /// </summary>
        public static readonly string errorLog = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemindMe\ErrorLog.txt";

        
    }
}
