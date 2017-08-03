using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemindMe.Variables
{
    /// <summary>
    /// This class contains IO related variables, that you don't want to declare in each class.
    /// </summary>
    public abstract class IOVariables
    {
        /// <summary>
        /// Contains the userprofile of the user (C:\Users\[username]\)
        /// </summary>
        public static readonly string userProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");

        /// <summary>
        /// Contains the path to the SQLite Database of RemindMe
        /// </summary>
        public static readonly string databaseFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db";

        /// <summary>
        /// Contains the startup folder path. 
        /// </summary>
        public static readonly string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);


        /// <summary>
        /// Contains the path to the error log file of RemindMe. This contains exceptions and when they occured.
        /// </summary>
        public static readonly string errorLog = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemindMe\ErrorLog.txt";

        
    }
}
