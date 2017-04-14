using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Contains the startup folder path. 
        /// </summary>
        public static readonly string startupFolderPath = userProfile + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\";

        /// <summary>
        /// Contains the path to the root folder of RemindMe
        /// </summary>
        public static readonly string rootFolder = userProfile + @"\RemindMe Data\";

        /// <summary>
        /// Contains the path to the folder with every reminder.ini
        /// </summary>
        public static readonly string remindersFolder = userProfile + @"\RemindMe Data\Reminders\";        

        /// <summary>
        /// Contains the path to the reminders.ini file of RemindMe
        /// </summary>
        public static readonly string settingsIni = userProfile + @"\RemindMe Data\Settings.ini";

        /// <summary>
        /// Contains the path to the error log file of RemindMe. This contains exceptions and when they occured.
        /// </summary>
        public static readonly string errorLog = userProfile + @"\RemindMe Data\ErrorLog.txt";

        
    }
}
