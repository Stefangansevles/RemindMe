using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
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
        /// Contains the path to the root folder of RemindMe
        /// </summary>
        public static readonly string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemindMe\";

        /// <summary>
        /// Contains the startup folder path. 
        /// </summary>
        public static readonly string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);


        /// <summary>
        /// Contains the path to the error log file of RemindMe. This contains exceptions and when they occured.
        /// </summary>
        public static readonly string errorLog = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemindMe\ErrorLog.txt";

        /// <summary>
        /// Contains the path to the batch file for advanced reminders. Batch scripts will be written to this and executed
        /// </summary>
        public static readonly string uniqueString = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\string.txt";

        /// <summary>
        /// Returns the version of RemindMe. Read from the assembly
        /// </summary>
        public static string RemindMeVersion
        {
            get
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);                    
                    return fvi.FileVersion;
                }
                catch(FileNotFoundException) //For some reason this can throw a FileNotFoundException on RemindMe.exe , let's try the code below
                {
                    try
                    {
                        Assembly asm = Assembly.GetExecutingAssembly();
                        AssemblyName asmName = asm.GetName();
                        string versionString = asmName.Version.ToString();
                        
                        if (versionString[versionString.Length-2] == '.' && versionString[versionString.Length - 1] == '0')                        
                            versionString = versionString.Substring(0, versionString.Length - 2);                        

                        return versionString;
                    }
                    catch { return "1.0"; } //Failed AGAIN ? Welp
                }
                catch { return "1.0"; }
            }
        }

    }
}
