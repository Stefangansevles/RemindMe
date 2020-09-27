using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Database.Entity;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Gma.System.MouseKeyHook;
using System.Threading;
using System.Net;
using System.Security.Permissions;
using System.Management;
using Microsoft.Win32;
using Ionic.Zip;
using IWshRuntimeLibrary;
using JCS;
using System.Globalization;
using MaterialSkin.Controls;
using MaterialSkin;

namespace RemindMe
{
    public partial class MaterialForm1 : MaterialForm
    {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        private IKeyboardMouseEvents m_GlobalHook;

        //The hotkey key-combination(customizable) to make a quick-timer popup
        Hotkeys timerHotkey;
        Hotkeys timerCheckHotKey;

        RemindMeUpdater updater = new RemindMeUpdater();

        private bool allowshowdisplay = false;

        public MUCReminders reminders;
        public MUCSettings mucSettings;
        private MUCTheme theme;
        public  MUCTimer timer;
        private MUCImportExport importExport;
        private MUCSound sound;
        private MUCResizePopup popup;
        private MUCSupport support;
        private MUCDebugMode debug;
        private MUCNewReminder newReminder;
        private MUCInfo info;

        //If the user presses the end key quickly 3 times, enable debug mode
        private int endKeyPressed = 0;

        private static MaterialForm1 instance = null;
        private static MaterialSkinManager materialSkinManager;

        //[Workaround] If the user presses the X button, RemindMe shouldn't close. This boolean is a workaround for the MaterialSkin "x" button
        public bool shouldClose = false;

        public MaterialForm1()
        {
            BLIO.Log("===  Initializing RemindMe Version " + IOVariables.RemindMeVersion + "  ===");
            BLIO.CreateSettings();
            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);

            int tries = 0;
            bool done = false;
            while (!done || !BLLocalDatabase.HasAllTables())
            {               
                try
                {
                    tries++;
                    if (tries >= 4 || BLLocalDatabase.HasAllTables())
                    {
                        done = true;
                        if (tries >= 4)
                            BLIO.Log("something went terribly wrong... 4 tries and it still doesnt work..");
                    }

                   
                    BLIO.Log("DB does not have all tables. Entered while loop to create.");
                    BLIO.CreateDatabaseIfNotExist();
                    Thread.Sleep(500);
                }
                catch(Exception ex)
                {

                }
            }
            
            LogWindowsInfo(); //Windows version info etc
            LogCultureInfo(); //Datetime info in their country
            Cleanup();
            
            

            this.Opacity = 0;
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ThemeChanged += UpdateTheme;
            materialSkinManager.AddFormToManage(this);

            instance = this;

            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalKeyPressDown;
            m_GlobalHook.KeyUp += GlobalKeyPressUp;

            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();


            UpdateInformation.Initialize();

            //dont show debug
            
            

            formLoad();

            SystemEvents.PowerModeChanged += OnPowerChange;

            RemindMeIcon.Visible = true;

            //Update LastOnline every 5 minutes
            tmrPingActivity.Start();

            tmrDumpLogTxtContents.Start();

            tmrEnableDatabaseAccess.Start();


            //workaround
            tmrRemoveDebug.Start();

            BLIO.Log("===  Initializing RemindMe Complete  ===");
        }
        /// <summary>
        /// Logs windows version info
        /// </summary>
        private void LogWindowsInfo()
        {
            BLIO.Log("Windows information:");
            BLIO.Log("- Version: " + OSVersionInfo.Name);
            BLIO.Log("- Edition:  " + OSVersionInfo.Edition);
            BLIO.Log("- Service pack:  " + OSVersionInfo.ServicePack);
            BLIO.Log("- Specific version:  " + OSVersionInfo.VersionString);
        }

        /// <summary>
        /// Logs information about the user's datetime information in their country
        /// </summary>
        private void LogCultureInfo()
        {
            BLIO.Log("CultureInfo information:");
            BLIO.Log("- Culture NativeName: " + CultureInfo.CurrentCulture.NativeName);
            BLIO.Log("- Culture ShortDatePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + "  [" + DateTime.Now.ToShortDateString() + "]");
            BLIO.Log("- Culture LongDatePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern + "  [" + DateTime.Now.ToLongDateString() + "]");
            BLIO.Log("- Culture FullDateTimePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern + "  [" + DateTime.Now.ToString() + "]");
            BLIO.Log("- Culture ShortTimePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern + "  [" + DateTime.Now.ToShortTimeString() + "]");
            BLIO.Log("- Culture LongTimePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern + "  [" + DateTime.Now.ToLongTimeString() + "]");
            BLIO.Log("- Culture DateSeparator: " + CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);
            BLIO.Log("- Culture TimeSeparator: " + CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator);
            BLIO.Log("- Culture ToString(): " + CultureInfo.CurrentCulture.ToString());
        }

        private void OnPowerChange(object sender, PowerModeChangedEventArgs e)
        {
            BLIO.Log("=== OnPowerChange() ===");

            switch (e.Mode)
            {
                //PC wakes up from sleep. If you're someone that always puts your pc to sleep instead of turning it off, RemindMe won't get "launched" again
                //but instead, resumes.
                case PowerModes.Resume:
                    BLIO.Log("=== PC Woke up from sleep! ===");
                    Thread t = new Thread(() =>
                    {
                        Thread.Sleep(5000);
                        BLIO.Log("Trying to update user after PC Sleep...");
                        BLOnlineDatabase.InsertOrUpdateUser(BLLocalDatabase.Setting.Settings.UniqueString);
                        BLIO.Log("User updated.");
                    });
                    t.Start();
                    break;
                case PowerModes.Suspend:
                    BLIO.Log("=== PC Is going to sleep. ZzZzzzZzz... ===");
                    break;
            }
        }

        public static MaterialForm1 Instance
        {
            get { return instance; }
        }

        public static MaterialSkinManager MaterialSkinManager
        {
            get { return materialSkinManager; }
        }


        private void MaterialForm1_Load(object sender, EventArgs e)
        {
            #region User controls
            reminders = new MUCReminders();
            mucSettings = new MUCSettings();
            theme = new MUCTheme();
            timer = new MUCTimer();
            importExport = new MUCImportExport();
            sound = new MUCSound();
            popup = new MUCResizePopup();
            support = new MUCSupport();
            debug = new MUCDebugMode();
            newReminder = new MUCNewReminder(reminders);
            info = new MUCInfo();

            newReminder.Visible = false;


            tabReminders.Controls.Add(reminders);
            tabReminders.Controls.Add(newReminder);
            tabSettings.Controls.Add(mucSettings);
            tabTheme.Controls.Add(theme);
            tabTimer.Controls.Add(timer);
            tabBackupImport.Controls.Add(importExport);
            tabSoundEffects.Controls.Add(sound);
            tabResizePopup.Controls.Add(popup);
            tabMessageCenter.Controls.Add(support);
            tabDebug.Controls.Add(debug);
            tabInfo.Controls.Add(info);




            reminders.Initialize();

            long? id = BLLocalDatabase.Setting.Settings.CurrentTheme;
            if (id.HasValue && id != -1)
            {
                Themes selectedTheme = BLLocalDatabase.Theme.GetThemeById(id.Value);
                if(selectedTheme == null)
                {
                    //Selected theme has been deleted
                    BLIO.Log("Attempted to load a Theme that has been deleted. Theme with ID " + id.Value + " does not exist anymore");
                }
                else
                {                    
                    //Load theme from selectedTheme (local Db)       
                    materialSkinManager.Theme = (MaterialSkinManager.Themes)(int)selectedTheme.Mode;
                    materialSkinManager.ColorScheme = new ColorScheme((Primary)(int)selectedTheme.Primary, (Primary)(int)selectedTheme.DarkPrimary, (Primary)(int)selectedTheme.LightPrimary, (Accent)(int)selectedTheme.Accent, (TextShade)(int)selectedTheme.TextShade);
                }
                
            }
            

            #endregion
        }

        public void UpdateTheme(object sender)
        {
            reminders.UpdateTheme(materialSkinManager.Theme);
        }
        private void Cleanup()
        {
            try
            {
                BLIO.Log("Starting Cleanup...");
                //RemindMe loaded, if an old system log/temp reminders still exists, delete it
                string oldSystemLog = IOVariables.systemLog;
                string oldTempReminders = System.IO.Path.GetTempPath() + "Exported Reminders.remindme";
                string oldUpdateFilesZip = IOVariables.rootFolder + "UpdateFiles.zip";

                if (System.IO.File.Exists(oldSystemLog))
                {
                    System.IO.File.Delete(oldSystemLog);
                    BLIO.Log("- Deleted   " + Path.GetFileName(oldSystemLog));
                }
                if (System.IO.File.Exists(oldTempReminders))
                {
                    System.IO.File.Delete(oldTempReminders);
                    BLIO.Log("- Deleted   " + Path.GetFileName(oldTempReminders));
                }
                if (System.IO.File.Exists(oldUpdateFilesZip))
                {
                    System.IO.File.Delete(oldUpdateFilesZip);
                    BLIO.Log("- Deleted   " + Path.GetFileName(oldUpdateFilesZip));
                }
                if (Directory.Exists(IOVariables.applicationFilesFolder + "\\old"))
                {
                    Directory.Delete(IOVariables.applicationFilesFolder + "\\old", true);
                    BLIO.Log("- Deleted   \\old Folder");
                }

                //If the errorlog is >= 5mb , clear it. That's a bit big..                                
                if (System.IO.File.Exists(IOVariables.errorLog) && new FileInfo(IOVariables.errorLog).Length / 1024 >= 5000)
                {
                    BLIO.Log("Clearing error log that is too large... [" + new FileInfo(IOVariables.errorLog).Length / 1024 + ".mb ]");

                    if (System.IO.File.Exists(IOVariables.errorLog))
                        System.IO.File.WriteAllText(IOVariables.errorLog, "");
                }

                BLIO.Log("Cleanup complete.");
            }
            catch (UnauthorizedAccessException ex)
            {
                BLIO.Log("Cleanup() FAILED. Unauthorized");
                //BLIO.WriteError(ex, "Error in Cleanup()"); //don't write this one to the db
            }
            catch (IOException ex)
            {
                BLIO.Log("Cleanup() FAILED. IOException");
                BLIO.WriteError(ex, "Error in Cleanup()");
            }
            catch (Exception ex)
            {
                BLIO.Log("Cleanup() FAILED. Global exception");
                BLIO.WriteError(ex, "Error in Cleanup()");
            }
        }

        /*This was testing a custom color scheme
        private void SetColorScheme()
        {
            
            string t = BLLocalDatabase.Setting.Settings.RemindMeTheme;
            RemindMeColorScheme colorTheme = BLLocalDatabase.Setting.GetColorTheme(BLLocalDatabase.Setting.Settings.RemindMeTheme);
            BLIO.Log("Setting RemindMe Color scheme \"" + BLLocalDatabase.Setting.Settings.RemindMeTheme + "\"");
            pnlSide.GradientBottomLeft = Color.FromArgb(Convert.ToInt16(colorTheme.PrimaryBottomLeft.Split(',')[0]), Convert.ToInt16(colorTheme.PrimaryBottomLeft.Split(',')[1]), Convert.ToInt16(colorTheme.PrimaryBottomLeft.Split(',')[2]));
            pnlSide.GradientBottomRight = Color.FromArgb(Convert.ToInt16(colorTheme.PrimaryBottomRight.Split(',')[0]), Convert.ToInt16(colorTheme.PrimaryBottomRight.Split(',')[1]), Convert.ToInt16(colorTheme.PrimaryBottomRight.Split(',')[2]));
            pnlSide.GradientTopLeft = Color.FromArgb(Convert.ToInt16(colorTheme.PrimaryTopLeft.Split(',')[0]), Convert.ToInt16(colorTheme.PrimaryTopLeft.Split(',')[1]), Convert.ToInt16(colorTheme.PrimaryTopLeft.Split(',')[2]));
            pnlSide.GradientTopRight = Color.FromArgb(Convert.ToInt16(colorTheme.PrimaryTopRight.Split(',')[0]), Convert.ToInt16(colorTheme.PrimaryTopRight.Split(',')[1]), Convert.ToInt16(colorTheme.PrimaryTopRight.Split(',')[2]));


            pnlMain.GradientBottomLeft = Color.FromArgb(Convert.ToInt16(colorTheme.SecondaryBottomLeft.Split(',')[0]), Convert.ToInt16(colorTheme.SecondaryBottomLeft.Split(',')[1]), Convert.ToInt16(colorTheme.SecondaryBottomLeft.Split(',')[2]));
            pnlMain.GradientBottomRight = Color.FromArgb(Convert.ToInt16(colorTheme.SecondaryBottomRight.Split(',')[0]), Convert.ToInt16(colorTheme.SecondaryBottomRight.Split(',')[1]), Convert.ToInt16(colorTheme.SecondaryBottomRight.Split(',')[2]));
            pnlMain.GradientTopLeft = Color.FromArgb(Convert.ToInt16(colorTheme.SecondaryTopLeft.Split(',')[0]), Convert.ToInt16(colorTheme.SecondaryTopLeft.Split(',')[1]), Convert.ToInt16(colorTheme.SecondaryTopLeft.Split(',')[2]));
            pnlMain.GradientTopRight = Color.FromArgb(Convert.ToInt16(colorTheme.SecondaryTopRight.Split(',')[0]), Convert.ToInt16(colorTheme.SecondaryTopRight.Split(',')[1]), Convert.ToInt16(colorTheme.SecondaryTopRight.Split(',')[2]));
        }*/

        protected override void WndProc(ref Message m)
        {
            //This message will be sent when the RemindMeImporter imports reminders.
            if (m.Msg == WM_RELOAD_REMINDERS)
            {
                BLIO.Log("Reloading reminders after import from .remindme file");
                int currentReminderCount = BLReminder.GetReminders().Count;

                BLReminder.NotifyChange();

                if (MUCReminders.Instance != null)
                    MUCReminders.Instance.UpdateCurrentPage();

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                {
                    MaterialMessageFormManager.MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!", 3);
                    BLIO.Log("Created reminders succesfully imported message popup (WndProc)");
                }

                if ((BLReminder.GetReminders().Count - currentReminderCount) > 0)
                {
                    new Thread(() =>
                    {
                        //Log an entry to the database, for data!                                                
                        try
                        {
                            BLOnlineDatabase.ImportCount++;
                        }
                        catch (ArgumentException ex)
                        {
                            BLIO.Log("Exception at BLOnlineDatabase.ImportCount++ Form1.cs . -> " + ex.Message);
                            BLIO.WriteError(ex, ex.Message, true);
                        }
                    }).Start();
                }

            }

            base.WndProc(ref m);
        }

        public void UpdatePageNumber(int number)
        {
            //if (number == -1)
                //lblPageNumber.Text = "";
           // else
                //lblPageNumber.Text = "Page " + number;
        }




        /// <summary>
        /// Looks for key combinations to launch the timer form (to set a timer quickly)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The keyeventargs which contains the pressed keys</param>
        private void GlobalKeyPressDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt) //None of the key key's (get it?) pressed? return.
                return;

            if (BLLocalDatabase.Setting.Settings.EnableQuickTimer != 1) //Not enabled? don't do anything
                return;

            //Good! now let's check if the KeyCode is not alt shift or ctrl
            if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
                return;

            timerHotkey = BLLocalDatabase.Hotkey.TimerPopup;
            timerCheckHotKey = BLLocalDatabase.Hotkey.TimerCheck;

            if (MaterialTimerPopup.Instance == null && e.Modifiers.ToString().Replace(" ", string.Empty) == timerHotkey.Modifiers && e.KeyCode.ToString() == timerHotkey.Key)
            {
                //Don't allow other applications to also fire this key combination, ctrl+shift+r would for example reload the page at the same time
                e.Handled = true;

                BLIO.Log("Timer hotkey combination pressed!");
                MaterialTimerPopup quickTimer = new MaterialTimerPopup();
                quickTimer.Show();
            }
            if (MaterialTimerCheck.Instance == null && MUCTimer.RunningTimers.Count > 0 && e.Modifiers.ToString().Replace(" ", string.Empty) == timerCheckHotKey.Modifiers && e.KeyCode.ToString() == timerCheckHotKey.Key)
            {
                //Don't allow other applications to also fire this key combination, ctrl+shift+r would for example reload the page at the same time
                e.Handled = true;

                BLIO.Log("Timer check hotkey combination pressed!");
                MaterialTimerCheck check = new MaterialTimerCheck();
                materialSkinManager.AddFormToManage(check);
                check.Show();
            }
        }


        private void GlobalKeyPressUp(object sender, KeyEventArgs e)
        {
            if (BLLocalDatabase.Setting.Settings.EnableQuickTimer != 1) //Not enabled? don't do anything
                return;

            timerCheckHotKey = BLLocalDatabase.Hotkey.TimerCheck;

            if (MaterialTimerCheck.Instance != null && (e.Modifiers.ToString().Replace(" ", string.Empty) == timerCheckHotKey.Modifiers || e.KeyCode.ToString() == timerCheckHotKey.Key))
            {
                MaterialTimerCheck.Instance.Close();
            }



        }


        /// <summary>
        /// Alternative Form_load method since form_load doesnt get called until you first double-click the RemindMe icon due to override SetVisibleCore
        /// </summary>
        private void formLoad()
        {
            try
            {
                BLIO.Log("RemindMe_Load");                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();


                RemindMeIcon.Text = "RemindMe " + IOVariables.RemindMeVersion;

                

                //set unique user string            
                BLIO.WriteUniqueString();
                

                MaterialMessageFormManager.MakeTodaysRemindersPopup();
                BLIO.Log("Today's reminders popup created");

                //Create an shortcut in the windows startup folder if it doesn't already exist
                if (!System.IO.File.Exists(IOVariables.startupFolderPath + "\\RemindMe" + ".lnk"))
                    FSManager.Shortcuts.CreateShortcut(IOVariables.startupFolderPath, "RemindMe", System.Windows.Forms.Application.StartupPath + "\\" + "RemindMe.exe", "Shortcut of RemindMe");
                else
                {

                    WshShell shell = new WshShell(); //Create a new WshShell Interface
                    IWshShortcut link = (IWshShortcut)shell.CreateShortcut(IOVariables.startupFolderPath + "\\RemindMe.lnk"); //Link the interface to our shortcut

                    //shortcut does exist, let's see if the target of that shortcut isn't the old RemindMe in the programs files
                    if (link.TargetPath.ToString().Contains("StefanGansevlesPrograms") || link.TargetPath.ToString().Contains("Program Files"))
                    {
                        BLIO.Log("Deleting old .lnk shortcut of RemindMe");
                        System.IO.File.Delete(IOVariables.startupFolderPath + "\\RemindMe.lnk");
                        FSManager.Shortcuts.CreateShortcut(IOVariables.startupFolderPath, "RemindMe", IOVariables.applicationFilesFolder + "RemindMe.exe", "Shortcut of RemindMe");
                    }
                }


                //if (Debugger.IsAttached) //Debugging ? show extra option            
                    //btnDebugMode.Visible = true;


                BLLocalDatabase.Song.InsertWindowsSystemSounds();

                if(BLLocalDatabase.Setting.Settings.AutoUpdate == 1) //I guess some users don't want it? :(
                    tmrUpdateRemindMe.Start();

                //If the setup still exists, delete it
                System.IO.File.Delete(IOVariables.rootFolder + "SetupRemindMe.msi");

                Settings set = BLLocalDatabase.Setting.Settings;
                //Call the timer once
                Thread tr = new Thread(() =>
                {
                    //wait a bit, then call the update timer once. It then runs every 5 minutes
                    Thread.Sleep(5000);
                    tmrUpdateRemindMe_Tick(null, null);
                    BLOnlineDatabase.InsertOrUpdateUser(set.UniqueString);

                    if (set.LastVersion == null)
                        set.LastVersion = IOVariables.RemindMeVersion;

                    BLLocalDatabase.Setting.UpdateSettings(set);
                });
                tr.Start();


                
                this.ShowInTaskbar = true;
                this.Show();
                tmrInitialHide.Start();

                Random r = new Random();
                tmrCheckRemindMeMessages.Interval = (r.Next(60, 300)) * 1000; //Random interval between 1 and 5 minutes
                tmrCheckRemindMeMessages.Start();
                BLIO.Log("tmrCheckRemindMeMessages.Interval = " + tmrCheckRemindMeMessages.Interval / 1000 + " seconds.");


                stopwatch.Stop();
                BLIO.Log("formLoad() took " + stopwatch.ElapsedMilliseconds + " ms");

                BLIO.Log("RemindMe loaded");
            }
            catch (Exception ex)
            {
                BLIO.Log("Exception in formLoadAsync() -> " + ex.GetType().ToString());
                BLOnlineDatabase.AddException(ex, DateTime.Now, IOVariables.systemLog);
            }


        }
     


        private void showRemindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("showRemindMeToolStripMenuItem_Click");
            ShowWhatsNew();
            if (this.Visible)
            {                
                BLIO.Log("Remindme was already visible though..");
                return;
            }

            //Instead of calling .Show() on a form with 100% opacity making it visible instantly, we call .Show() on the form with 0% opacity.
            //The form will be drawn invisibly, and then increase the opacity until it reaches 100%. This way RemindMe's form:
            //1. Has a fade-in like animation when showing
            //2. No longer shows flickery that occurs when drawing the form(windows-forms drawing issue)
            allowshowdisplay = true;
            this.ShowInTaskbar = true;
            this.Show();
            tmrFadeIn.Start(); ;
            BLIO.Log("Show remindme toolstrip menu item clicked(not double-click). Showing remindme");
        }

        private void RemindMeIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BLIO.Log("Remindme icon double clicked");
            ShowWhatsNew();
            if (this.Visible)
            {
                BLIO.Log("Remindme was already visible though..");
                return;
            }
            allowshowdisplay = true;
            this.ShowInTaskbar = true;            

            this.TopMost = true;
            this.Show();
            
            tmrFadeIn.Start();
            BLIO.Log("Showing RemindMe");
                      
        }

        //launch a form showing the user what is new since the last version(s)
        private void ShowWhatsNew()
        {
            Settings set = BLLocalDatabase.Setting.Settings;
            if (set.LastVersion != null && (new Version(set.LastVersion) < new Version(IOVariables.RemindMeVersion)))
            {
                BLIO.Log("[VERSION CHECK] New version! last version: " + set.LastVersion + "  New version: " + IOVariables.RemindMeVersion);
                //User has a new RemindMe version!                
                string releaseNotesString = "";

                foreach (KeyValuePair<string, string> entry in UpdateInformation.ReleaseNotes)
                {
                    if (new Version(entry.Key) > new Version(set.LastVersion))
                    {
                        releaseNotesString += "Version " + entry.Key + "\r\n" + entry.Value + "\r\n\r\n\r\n";
                    }
                }
                if (releaseNotesString.Length > 0)
                {
                    MaterialWhatsNew wn = new MaterialWhatsNew(set.LastVersion, releaseNotesString);
                    materialSkinManager.AddFormToManage(wn);
                    wn.Location = this.Location;
                    wn.Show();
                }

                //Update the lastVersion
                set.LastVersion = IOVariables.RemindMeVersion;
                BLLocalDatabase.Setting.UpdateSettings(set);
            }
            else
            {
                BLIO.Log("[VERSION CHECK] No new version! lastVersion: " + set.LastVersion + "  New version: " + IOVariables.RemindMeVersion);
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            shouldClose = true;
            this.Close(); //Calls form_closing.
        }



        private void tmrOpacity_Tick(object sender, EventArgs e)
        {                        
            this.Opacity += 0.15;
            if (this.Opacity >= 1)
            {
                Invalidate();
                this.TopMost = false;
                tmrFadeIn.Stop();
            }
        }

        private void MaterialForm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End && !mainTabControl.Controls.Contains(tabDebug))
            {
                tmrDebugMode.Stop();
                tmrDebugMode.Start();
                endKeyPressed++;
                if (endKeyPressed >= 3)
                {
                    tmrDebugMode.Stop();
                    endKeyPressed = 0;
                    BLIO.Log("end key pressed 3 times. Show dialog for debug mode");
                    if (MaterialRemindMeBox.Show("Enable debug mode?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                    {
                        BLIO.Log("Debug mode enabled");
                        
                        mainTabControl.Controls.Add(tabDebug);
                        
                        
                    }
                }
            }
        }

        private void tmrDebugMode_Tick(object sender, EventArgs e)
        {
            endKeyPressed = 0;
        }


        private void tmrUpdateRemindMe_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    updater.UpdateRemindMe();
                }
                catch (Exception ex)
                {
                    BLIO.Log("UpdateRemindMe FAILED. " + ex.GetType().ToString());
                    BLIO.WriteError(ex, "Error in tmrUpdateRemindMe_Tick");
                }
            }).Start();

        }

        private void tmrInitialHide_Tick(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
            tmrInitialHide.Stop();
        }

        private void MaterialForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldClose)
            {
                BLIO.Log("lblExit_Click (X) (kinda)");
                this.Opacity = 0;
                this.Hide();

                e.Cancel = true;
                return;
            }

            BLIO.Log("MaterialForm1_FormClosing   [" + e.CloseReason + "]");
            BLIO.DumpLogTxt();

            if (MUCTimer.RunningTimers.Count > 0)
            {
                if (MaterialRemindMeBox.Show("You have (" + MUCTimer.RunningTimers.Count + ") active timers running.\r\n\r\nAre you sure you wish to close RemindMe? These timers will not be saved", RemindMeBoxReason.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    shouldClose = false;
                }
            }
        }

        private void tmrCheckRemindMeMessages_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    //Check for messages sent by me every minute
                    foreach (RemindMeMessages message in BLOnlineDatabase.RemindMeMessages)
                    {
                        //first, check if this user has already read this message.
                        if (BLLocalDatabase.ReadMessage.Messages.Where(m => m.ReadMessageId == message.Id).Count() == 0)
                        {
                            this.BeginInvoke(new MethodInvoker(delegate //This is required to show windows forms (the messages) on a new thread
                            {
                                BLIO.Log("RemindMe detected an unread message!");
                                //User hasn't read it yet. great! Mark the message as read
                                BLLocalDatabase.ReadMessage.MarkMessageRead(message);
                                BLIO.Log("Message marked as read.");

                                if (!string.IsNullOrWhiteSpace(message.MeantForSpecificPerson))
                                {
                                    BLIO.Log("This message is specifically for me!");
                                    //This message is meant for a specific user.

                                    if (BLLocalDatabase.Setting.Settings.UniqueString == message.MeantForSpecificPerson)
                                        PopupRemindMeMessage(message);

                                }
                                else if (!string.IsNullOrWhiteSpace(message.MeantForSpecificVersion))
                                {
                                    BLIO.Log("This message is specifically for the currently running RemindMe version (" + message.MeantForSpecificVersion + ")");
                                    //This message is meant for a specific RemindMe version. Only show this message if the user: Hasn't read this message AND: has this RemindMe version
                                    if (IOVariables.RemindMeVersion == message.MeantForSpecificVersion)
                                    {
                                        //Show the message
                                        PopupRemindMeMessage(message);
                                    }
                                }
                                else
                                {
                                    BLIO.Log("This is a global message. creating popup...");
                                    //A global message, not meant for a specific RemindMe version nor user
                                    PopupRemindMeMessage(message);
                                    BLIO.Log("popup created");
                                }

                            }));
                        }

                    }
                }
                catch (Exception ex)
                {
                    BLIO.Log("CheckRemindMeMessages FAILED. " + ex.GetType().ToString());
                    BLIO.WriteError(ex, "Error in tmrCheckRemindMeMessages_Tick");
                }
            }).Start();

        }

        private void PopupRemindMeMessage(RemindMeMessages mess)
        {
            //Update the counter on the message
            BLIO.Log("Attempting to update an message with id " + mess.Id);
            BLOnlineDatabase.UpdateRemindMeMessageCount(mess.Id);

            switch (mess.NotificationType)
            {
                case "MaterialRemindMeBox":
                    MaterialRemindMeBox.Show("RemindMe Developer", "This is a message from the developer of RemindMe.\r\n\r\n" + mess.Message.Replace("¤", Environment.NewLine), RemindMeBoxReason.OK);
                    break;
                case "REMINDMEMESSAGEFORM":
                    MaterialMessageFormManager.MakeMessagePopup(mess.Message.Replace("¤", Environment.NewLine), mess.NotificationDuration.Value, "RemindMe Developer");
                    break;
            }
        }

        private void tmrPingActivity_Tick(object sender, EventArgs e)
        {
            try
            {
                if (BLIO.LastLogMessage != null && !BLIO.LastLogMessage.Contains("Updating user"))
                    BLIO.Log("Pinging online status");

                //Update LastOnline
                BLOnlineDatabase.InsertOrUpdateUser(BLLocalDatabase.Setting.Settings.UniqueString);
            }
            catch (Exception ex)
            {
                BLIO.Log("PingActivity FAILED. " + ex.GetType().ToString());
                BLIO.WriteError(ex, "Error in tmrPingActivity_Tick");
            }
        }

        int currentLogCount = 0;
        private void tmrDumpLogTxtContents_Tick(object sender, EventArgs e)
        {
            try
            {
                if (BLIO.systemLog.Count != currentLogCount)
                    currentLogCount = BLIO.DumpLogTxt();

            }
            catch (Exception ex)
            {
                BLIO.Log("DumpLogTxT FAILED. " + ex.GetType().ToString());
                BLIO.WriteError(ex, "Error in tmrDumpLogTxtContents_Tick");
            }
        }

        private void tmrEnableDatabaseAccess_Tick(object sender, EventArgs e)
        {
            try
            {
                //If we could not connect to the database, the Data Access Layer will no longer try to connect to the database again. 
                //This timer will re-enable this every 10 minutes, just in case the database is no longer available. Then, if it is available again, continue as usual.
                BLOnlineDatabase.ReAllowDatabaseAccess();
            }
            catch (Exception ex)
            {
                BLIO.Log("EnableDatabaseAccess FAILED. " + ex.GetType().ToString());
                BLIO.WriteError(ex, "Error in tmrEnableDatabaseAccess_Tick");
            }
        }        

        private void restartRemindMeUpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tmrRemoveDebug_Tick(object sender, EventArgs e)
        {
            mainTabControl.Controls.Remove(tabDebug);
            tmrRemoveDebug.Stop();
        }
    }
}
