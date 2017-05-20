using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSManager;
using System.IO;
using IWshRuntimeLibrary;
using System.Windows.Forms;

namespace RemindMe
{
    public abstract class BLIO
    {
        static IWshShortcut Shortcut;
        static WshShell shell = new WshShell();
        /// <summary>
        /// Creates the folders and files needed by RemindMe. This should only occur once, during first use.
        /// </summary>
        public static void CreateSettings()
        {
            FSManager.Folders.CreateHiddenFolder(Variables.IOVariables.rootFolder);
            FSManager.Folders.CreateHiddenFolder(Variables.IOVariables.remindersFolder);
        }
        /// <summary>
        /// Adds all the selected sounds to the settings.ini of RemindMe
        /// </summary>
        /// <returns>The list of selected files with the path to them</returns>
        public static List<string> AddSoundsToFile()
        {
            List<string> selectedFiles = FSManager.Files.getSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();
            WriteSettings(selectedFiles,false,ReadAlwaysOnTop());
           
            return selectedFiles;
        }
        /// <summary>
        /// Reads the sound files in the settings.ini of RemindMe
        /// </summary>
        /// <returns>an string list of user imported sounds and their paths</returns>
        public static List<string> ReadSoundFiles()
        {
            List<string> currentSoundFiles = null;

            if (System.IO.File.Exists(Variables.IOVariables.settingsIni))
            {
                using (StreamReader read = new StreamReader(Variables.IOVariables.settingsIni))
                {
                    while (!read.EndOfStream)
                    {
                        string line = read.ReadLine();
                        if (line.Contains("Sound files = <"))
                            currentSoundFiles = BLUtilities.stripString(line, "<", ">").Split(';').ToList();

                    }
                }
                if (currentSoundFiles != null && currentSoundFiles[0] == "")
                    currentSoundFiles.RemoveAt(0);
            }
            else
                WriteError(new FileNotFoundException(), "Could not find settings.ini", false);

            return currentSoundFiles;
        }


        /// <summary>
        /// Reads popup type in the settings.ini of RemindMe
        /// </summary>
        /// <returns>true if the user selected the popup to be always on top, false if not</returns>
        public static bool ReadAlwaysOnTop()
        {
            if (System.IO.File.Exists(Variables.IOVariables.settingsIni))
            {
                using (StreamReader read = new StreamReader(Variables.IOVariables.settingsIni))
                {
                    while (!read.EndOfStream)
                    {
                        string line = read.ReadLine();

                        if (line.Contains("Always on top = <"))
                            return Boolean.Parse(BLUtilities.stripString(line, "<", ">"));

                    }
                }

            }
            else
                WriteError(new FileNotFoundException(), "Could not find settings.ini",false);
            return true;


        }


        /// <summary>
        /// Writes settings to the RemindMe settings.ini
        /// </summary>
        /// <param name="soundFiles"></param>
        /// <param name="overWriteCurrentSoundFiles">true to overwrite the current sound files in the settings.ini file, or false to add them to the current existing ones</param>
        /// <param name="popupAlwaysOnTop">Wether this popup should show always on top or not.</param>
        public static void WriteSettings(List<string> soundFiles,bool overWriteCurrentSoundFiles, bool popupAlwaysOnTop/*, Param others*/)
        {
            List<string> currentSoundFiles = ReadSoundFiles();

            if (currentSoundFiles == null)
                currentSoundFiles = new List<string>();

            if(overWriteCurrentSoundFiles)
            {
                if (System.IO.File.Exists(Variables.IOVariables.settingsIni))
                    System.IO.File.WriteAllText(Variables.IOVariables.settingsIni,""); // clear the file before writing  
            }

            using (FileStream fs = new FileStream(Variables.IOVariables.settingsIni, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                #region Sound Writing
                sw.Write("Sound files = <");
                string allSoundFilePaths = "";

                if (!overWriteCurrentSoundFiles)
                {
                    if (currentSoundFiles != null && currentSoundFiles.Count > 0) //There already are sound files
                    {
                        foreach (string soundPath in currentSoundFiles)
                        {
                            allSoundFilePaths += soundPath + ";";
                            //sw.Write(soundPath + ";");
                        }
                        //soundFileWritePaths = soundFileWritePaths.Remove(soundFileWritePaths.Length - 1);
                    }
                }

                if (soundFiles != null)
                {
                    foreach (string soundPath in soundFiles)
                    {
                        if (!overWriteCurrentSoundFiles)
                        {
                            if (!currentSoundFiles.Contains(soundPath))
                                allSoundFilePaths += soundPath + ";";
                        }
                        else
                            allSoundFilePaths += soundPath + ";";

                        //sw.Write(soundPath + ";");
                    }
                }
                if(allSoundFilePaths.Length > 0)
                    allSoundFilePaths = allSoundFilePaths.Remove(allSoundFilePaths.Length - 1);
                sw.Write(allSoundFilePaths);
                sw.WriteLine(">");
                #endregion

                if (popupAlwaysOnTop)
                    sw.WriteLine("Always on top = <True>");
                else
                    sw.WriteLine("Always on top = <False>");
                
            }
        }

       
        /// <summary>
        /// Reads through all reminder files.
        /// </summary>
        /// <returns>A list with the read reminders from the RemindMe folder</returns>
        public static List<Reminder> ReadAllReminders()
        {                        
            //Get all the .ini files in the folder
            List<string> reminderNames = FSManager.Files.getFilesWithPathInFolder(Variables.IOVariables.remindersFolder,false, "*.ini;").ToList();

            //Go through all the .ini files
            foreach (string rem in reminderNames)
            {
                Reminder remin = null;
                
                DateTime completeDate = new DateTime();
                ReminderRepeatType repeatingType = new ReminderRepeatType();
                int dayOfMonth = -1;
                int dayOfWeek = -1;
                bool enabled = true;
                string note = "";
                int everyXDays = -1;
                string soundPath = "";

                                
                using (StreamReader read = new StreamReader(rem))
                {
                    while (!read.EndOfStream)//go through all the lines
                    {
                        string line = read.ReadLine();
                        
                        if (line.Contains("Date = <"))
                            completeDate = Convert.ToDateTime(BLUtilities.stripString(line,"<",">"));

                        if (line.Contains("RepeatingType = <"))
                            repeatingType = (ReminderRepeatType)Enum.Parse(typeof(ReminderRepeatType), BLUtilities.stripString(line, "<", ">").ToUpper());

                        if (line.Contains("DayOfMonth = <"))
                            dayOfMonth = Convert.ToInt16(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("DayOfWeek = <"))
                            dayOfWeek = Convert.ToInt16(BLUtilities.stripString(line, "<", ">"));

                        if(line.Contains("EveryXDays = <"))
                            everyXDays = Convert.ToInt16(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("Enabled = <"))
                            enabled = Boolean.Parse(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("Note = <"))
                        {
                            if (!line.Contains(">")) //multiple lines!
                            {
                                note = line;
                                
                                while (!read.EndOfStream)
                                {
                                    string linee = read.ReadLine();

                                    if(linee == "")
                                        note += "\\n";
                                    else if(!linee.Contains(">"))
                                        note += linee;
                                    if (linee.Contains(">"))
                                    {
                                        note += linee;
                                        break;
                                    }


                                }
                            }
                            else
                                note = BLUtilities.stripString(line, "<", ">");
                            
                        }

                        if (line.Contains("Sound = <"))
                            soundPath = BLUtilities.stripString(line, "<", ">");
                    }
                }

                
                if (dayOfMonth != -1)
                    remin = new Reminder(Path.GetFileNameWithoutExtension(rem), completeDate, repeatingType, dayOfMonth, note, enabled);
                else if (dayOfWeek != -1)
                    remin = new Reminder(Path.GetFileNameWithoutExtension(rem), completeDate, repeatingType, note, dayOfWeek, enabled);
                else if(everyXDays != -1)
                    remin = new Reminder(Path.GetFileNameWithoutExtension(rem), completeDate, repeatingType, note, enabled,everyXDays);
                else
                    remin = new Reminder(Path.GetFileNameWithoutExtension(rem), completeDate, repeatingType, note, enabled);

                remin.SoundFilePath = soundPath;
            }

            return ReminderManager.GetReminders();
        }

        /// <summary>
        /// Reads a single reminder
        /// </summary>
        /// <param name="reminderName">The name of the reminder</param>
        /// <returns></returns>
        public static Reminder ReadSingleReminder(string reminderName)
        {
            Reminder remin = null;

            DateTime completeDate = new DateTime();
            ReminderRepeatType repeatingType = new ReminderRepeatType();
            int dayOfMonth = -1;
            int dayOfWeek = -1;
            bool enabled = true;
            string note = "";
            string soundPath = "";
            if (System.IO.File.Exists(Variables.IOVariables.remindersFolder + reminderName + ".ini"))
            {
                using (StreamReader read = new StreamReader(Variables.IOVariables.remindersFolder + reminderName + ".ini"))
                {
                    while (!read.EndOfStream)//go through all the lines
                    {
                        string line = read.ReadLine();


                        if (line.Contains("Date = <"))
                            completeDate = Convert.ToDateTime(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("RepeatingType = <"))
                            repeatingType = (ReminderRepeatType)Enum.Parse(typeof(ReminderRepeatType), BLUtilities.stripString(line, "<", ">").ToUpper());

                        if (line.Contains("DayOfMonth = <"))
                            dayOfMonth = Convert.ToInt16(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("DayOfWeek = <"))
                            dayOfWeek = Convert.ToInt16(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("Enabled = <"))
                            enabled = Boolean.Parse(BLUtilities.stripString(line, "<", ">"));

                        if (line.Contains("Note = <"))
                        {
                            if (!line.Contains(">")) //multiple lines!
                            {
                                note = line;

                                while (!read.EndOfStream)
                                {
                                    string linee = read.ReadLine();
                                    if (linee == "")
                                        note += "\\n";
                                    else if (!linee.Contains(">"))
                                        note += linee;
                                    if (linee.Contains(">"))
                                    {
                                        note += linee;
                                        note = BLUtilities.stripString(note, "<", ">");
                                        break;
                                    }


                                }
                            }
                            else
                                note = BLUtilities.stripString(line, "<", ">");

                        }

                        if (line.Contains("Sound = <"))
                            soundPath = BLUtilities.stripString(line, "<", ">");
                    }
                }

                if (dayOfMonth != -1)
                    remin = new Reminder(reminderName, completeDate, repeatingType, dayOfMonth, note, enabled);
                else if (dayOfWeek != -1)
                    remin = new Reminder(reminderName, completeDate, repeatingType, note, dayOfWeek, enabled);
                else
                    remin = new Reminder(reminderName, completeDate, repeatingType, note, enabled);

                remin.SoundFilePath = soundPath;

                return remin;
            }
            else                            
                return null;            
        }


        /// <summary>
        /// Writes an reminder to the reminder folder. Will overwrite if the file already exists.
        /// </summary>
        /// <param name="rem"></param>
        public static void WriteReminderToFile(Reminder rem)
        {
            using (FileStream fs = new FileStream(Variables.IOVariables.remindersFolder + rem.Name + ".ini", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                
                sw.WriteLine("Date = <" + rem.CompleteDate + ">");
                sw.WriteLine("RepeatingType = <" + rem.RepeatingType.ToString().ToUpper() + ">");
                if (rem.DayOfMonth != 0)
                    sw.WriteLine("DayOfMonth = <" + rem.DayOfMonth + ">");
                if (rem.DayOfWeek  > 0) 
                    sw.WriteLine("DayOfWeek = <" + rem.DayOfWeek + ">");

                if(rem.EveryXDays > 0)
                    sw.WriteLine("EveryXDays = <" + rem.EveryXDays + ">");

                sw.WriteLine("Enabled = <" + rem.Enabled.ToString() + ">");
                sw.WriteLine("Note = <" + rem.Note + ">");

                if (rem.SoundFilePath != null && rem.SoundFilePath != "")
                    sw.WriteLine("Sound = <" + rem.SoundFilePath + ">");
                
            }
                
        }

        /// <summary>
        /// Creates an shortcut of RemindMe in the windows startup folder so that RemindMe will start automatically when windows starts.
        /// </summary>
        public static void CreateShortcut()
        {
            try
            {
                //Where do you want to create the shortcut + what is the name of the shortcut?
                Shortcut = (IWshShortcut)shell.CreateShortcut(Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk");

                //What is the shortcut's target?
                Shortcut.TargetPath = Application.StartupPath + "\\" + "RemindMe.exe";

                //Tooltip
                Shortcut.Description = "Shortcut of RemindMe";


                Shortcut.Save();
            }
            catch (Exception ex)
            {
                WriteError(ex, "Error while creating a shortcut",false);                

            }
        }

        public static void WriteChangedReminderToFile(Reminder rem)
        {
            //This is how it is before we change it.
            //Reminder oldReminder = ReadSingleReminder(rem.Name);
            
           

            using (FileStream fs = new FileStream(Variables.IOVariables.remindersFolder + rem.Name + ".ini", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {

                sw.WriteLine("Date = <" + rem.CompleteDate + ">");
                sw.WriteLine("RepeatingType = <" + rem.RepeatingType.ToString().ToUpper() + ">");
                if (rem.DayOfMonth > 0)
                    sw.WriteLine("DayOfMonth = <" + rem.DayOfMonth + ">");
                if (rem.DayOfWeek > 0)
                    sw.WriteLine("DayOfWeek = <" + rem.DayOfWeek + ">");

                if (rem.EveryXDays > 0)
                    sw.WriteLine("EveryXDays = <" + rem.EveryXDays + ">");

                sw.WriteLine("Enabled = <" + rem.Enabled.ToString() + ">");
                sw.WriteLine("Note = <" + rem.Note + ">");

                if (rem.SoundFilePath != null && rem.SoundFilePath != "")
                    sw.WriteLine("Sound = <" + rem.SoundFilePath + ">");

            }

        }

        /// <summary>
        /// Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="description">A custom description of the error</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex,string description,bool showErrorPopup)
        {
            using (FileStream fs = new FileStream(Variables.IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + description + "\r\n" + ex.ToString() + "\r\n\r\n");
            }
            if(showErrorPopup)
            {
                ErrorPopup popup = new ErrorPopup(description);
                popup.Show();
            }
        }
    }
}
