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

namespace RemindMe
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        private IKeyboardMouseEvents m_GlobalHook;

        //The hotkey key-combination(customizable) to make a quick-timer popup
        Hotkeys timerHotkey;

        RemindMeUpdater updater = new RemindMeUpdater();

        #region User Controls
        //User controls that will be loaded into the "main" panel
        private UCReminders ucReminders;
        private UCImportExport ucImportExport;
        private UCSound ucSound;
        private UCSettings ucOverlay;
        private UCResizePopup ucResizePopup;
        private UCSupport ucSupport;
        private UCDebugMode ucDebug;
        public UCTimer ucTimer;
        public UCNewReminder ucNewReminder; //Can be null
        //If the user presses the end key quickly 3 times, enable debug mode
        private int endKeyPressed = 0;
        private static Form1 instance;
        #endregion
        
        private bool allowshowdisplay = false;

        public Form1()
        {            
            BLIO.Log("===  Initializing RemindMe Version " + IOVariables.RemindMeVersion + "  ===");
            Cleanup();
            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            BLIO.CreateSettings();
            BLIO.CreateDatabaseIfNotExist();
            InitializeComponent();
            //--

            instance = this;            

            //User controls that will be loaded into the "main" panel
            ucReminders = new UCReminders();
            ucImportExport = new UCImportExport();
            ucSound = new UCSound();
            ucOverlay = new UCSettings();
            ucResizePopup = new UCResizePopup();
            ucSupport = new UCSupport();
            ucDebug = new UCDebugMode();
            ucTimer = new UCTimer();

            //Turn them invisible            
            ucImportExport.Visible = false;
            ucSound.Visible = false;
            ucOverlay.Visible = false;
            ucResizePopup.Visible = false;
            ucSupport.Visible = false;
            ucDebug.Visible = false;
            ucTimer.Visible = false;

            //Add all of them(invisible) to the panel            
            pnlMain.Controls.Add(ucImportExport);
            pnlMain.Controls.Add(ucSound);
            pnlMain.Controls.Add(ucOverlay);
            pnlMain.Controls.Add(ucResizePopup);
            pnlMain.Controls.Add(ucSupport);
            pnlMain.Controls.Add(ucDebug);
            pnlMain.Controls.Add(ucTimer);

            pnlMain.Controls.Add(ucReminders);
            ucReminders.Visible = true;
            ucReminders.Initialize();

            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalKeyPress;

            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();


            UpdateInformation.Initialize();

            formLoadAsync();

            SystemEvents.PowerModeChanged += OnPowerChange;

            RemindMeIcon.Visible = true;

            //Update LastOnline every 5 minutes
            tmrPingActivity.Start();

            tmrDumpLogTxtContents.Start();

            tmrEnableDatabaseAccess.Start();            

            BLIO.Log("===  Initializing RemindMe Complete  ===");            
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
                        BLOnlineDatabase.InsertOrUpdateUser(BLSettings.Settings.UniqueString);
                        BLIO.Log("User updated.");
                    });
                    t.Start();                    
                    break;
                case PowerModes.Suspend: BLIO.Log("=== PC Is going to sleep. ZzZzzzZzz... ===");
                    break;
            }
        }

        public static Form1 Instance
        {
            get { return instance; }
        }
       

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }            
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
                if (new System.IO.FileInfo(IOVariables.errorLog).Length / 1024 >= 5000)
                {
                    BLIO.Log("Clearing error log that is too large... ["+ new System.IO.FileInfo(IOVariables.errorLog).Length/1024+".mb ]");
                    System.IO.File.WriteAllText(IOVariables.errorLog, "");
                }

                BLIO.Log("Cleanup complete.");
            }
            catch(UnauthorizedAccessException ex)
            {
                BLIO.Log("Cleanup() FAILED. Unauthorized");
                BLIO.WriteError(ex, "Error in Cleanup()");
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
            
            string t = BLSettings.Settings.RemindMeTheme;
            RemindMeColorScheme colorTheme = BLSettings.GetColorTheme(BLSettings.Settings.RemindMeTheme);
            BLIO.Log("Setting RemindMe Color scheme \"" + BLSettings.Settings.RemindMeTheme + "\"");
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

                if (UCReminders.Instance != null)
                    UCReminders.Instance.UpdateCurrentPage();

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                {
                    RemindMeMessageFormManager.MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!", 3);
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
            if (number == -1)
                lblPageNumber.Text = "";
            else
                lblPageNumber.Text = "Page " + number;
        }




        /// <summary>
        /// Looks for key combinations to launch the timer form (to set a timer quickly)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The keyeventargs which contains the pressed keys</param>
        private void GlobalKeyPress(object sender, KeyEventArgs e)
        {            
            if (!e.Shift && !e.Control && !e.Alt) //None of the key key's (get it?) pressed? return.
                return;

            if (BLSettings.Settings.EnableQuickTimer != 1) //Not enabled? don't do anything
                return;

            //Good! now let's check if the KeyCode is not alt shift or ctrl
            if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
                return;

            timerHotkey = BLHotkeys.TimerPopup;

            if (e.Modifiers.ToString().Replace(" ", string.Empty) == timerHotkey.Modifiers && e.KeyCode.ToString() == timerHotkey.Key)
            {
                //Don't allow other applications to also fire this key combination, ctrl+shift+r would for example reload the page at the same time
                e.Handled = true;

                BLIO.Log("Timer hotkey combination pressed!");
                TimerPopup quickTimer = new TimerPopup();
                quickTimer.Show();
            }
        }

        /// <summary>
        /// Alternative Form_load method since form_load doesnt get called until you first double-click the RemindMe icon due to override SetVisibleCore
        /// </summary>
        private async Task formLoadAsync()
        {
           
            try
            {
                BLIO.Log("RemindMe_Load");                

                lblVersion.Text = "Version " + IOVariables.RemindMeVersion;

                //set unique user string            
                BLIO.WriteUniqueString();

                //Default view should be reminders
                pnlMain.Controls.Add(ucReminders);

                RemindMeMessageFormManager.MakeTodaysRemindersPopup();
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


                if (Debugger.IsAttached) //Debugging ? show extra option            
                    btnDebugMode.Visible = true;


                BLSongs.InsertWindowsSystemSounds();

                tmrUpdateRemindMe.Start();

                //If the setup still exists, delete it
                System.IO.File.Delete(IOVariables.rootFolder + "SetupRemindMe.msi");

                Settings set = BLSettings.Settings;
                //Call the timer once
                Thread tr = new Thread(() =>
                {
                //wait a bit, then call the update timer once. It then runs every 5 minutes
                Thread.Sleep(5000);
                    tmrUpdateRemindMe_Tick(null, null);                    
                    BLOnlineDatabase.InsertOrUpdateUser(set.UniqueString);

                    if (set.LastVersion == null)
                        set.LastVersion = IOVariables.RemindMeVersion;

                    BLSettings.UpdateSettings(set);
                });
                tr.Start();


                this.Opacity = 0;
                this.ShowInTaskbar = true;
                this.Show();
                tmrInitialHide.Start();

                //Insert the errorlog.txt into the DB if it is not empty
                if (new FileInfo(IOVariables.errorLog).Length > 0 && new System.IO.FileInfo(IOVariables.errorLog).Length / 1024 < 5000)
                {
                    string logContents = System.IO.File.ReadAllText(IOVariables.errorLog);
                    int lineCount = System.IO.File.ReadLines(IOVariables.errorLog).Count();

                    BLIO.Log("Inserting local error log with " + lineCount + " lines");
                    BLOnlineDatabase.InsertLocalErrorLog(set.UniqueString, logContents, lineCount);
                    System.IO.File.WriteAllText(IOVariables.errorLog, "");
                }

                Random r = new Random();
                tmrCheckRemindMeMessages.Interval = (r.Next(60, 300)) * 1000; //Random interval between 1 and 5 minutes
                tmrCheckRemindMeMessages.Start();
                BLIO.Log("tmrCheckRemindMeMessages.Interval = " + tmrCheckRemindMeMessages.Interval / 1000 + " seconds.");
                BLIO.Log("RemindMe loaded");                
            }
            catch (Exception ex)
            {
                BLIO.Log("Exception in formLoadAsync() -> " + ex.GetType().ToString());
                BLOnlineDatabase.AddException(ex, DateTime.Now, IOVariables.systemLog);
            }

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            BLIO.Log("lblExit_Click (X)");
            this.Opacity = 0;
            this.Hide();
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
            this.Show();
            tmrFadeIn.Start();
            BLIO.Log("Showing RemindMe");
        }

        //launch a form showing the user what is new since the last version(s)
        private void ShowWhatsNew()
        {
            Settings set = BLSettings.Settings;
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
                    WhatsNew wn = new WhatsNew(set.LastVersion, releaseNotesString);
                    wn.Location = this.Location;
                    wn.Show();
                }                

                //Update the lastVersion
                set.LastVersion = IOVariables.RemindMeVersion;
            }
            else
            {
                BLIO.Log("[VERSION CHECK] No new version! lastVersion: " + set.LastVersion + "  New version: " + IOVariables.RemindMeVersion);
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            if (UCTimer.RunningTimers.Count > 0 && !this.Visible)
            {
                if (RemindMeBox.Show("You have (" + UCTimer.RunningTimers.Count + ") active timers running.\r\n\r\nAre you sure you wish to close RemindMe? These timers will not be saved", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                {
                    BLIO.Log("User had running timers and closed RemindMe(through RemindMeIcon)");
                    this.Close();
                    Application.Exit();
                }
            }
            else
            {
                BLIO.Log("Closing RemindMe(through RemindMeIcon)");
                this.Close();
                Application.Exit();
            }


        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            BLIO.Log("lblMinimize_Click (-)");
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReminders_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnReminders_Click");
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            if (ucNewReminder != null && ucNewReminder.saveState)
                ucNewReminder.Visible = true;
            else
            {
                ucReminders.Visible = true;
                UCReminders.Instance.UpdateCurrentPage();
            }
            ToggleButton(sender);
        }
        /// <summary>
        /// Toggles a button to become selected.
        /// </summary>
        private void ToggleButton(object sender)
        {
            btnBackupImport.selected = false;
            btnReminders.selected = false;
            btnResizePopup.selected = false;
            btnSoundEffects.selected = false;
            btnSupport.selected = false;
            btnWindowOverlay.selected = false;

            ((Bunifu.Framework.UI.BunifuFlatButton)sender).selected = true;
        }

        private void btnBackupImport_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnBackupImport_Click");
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucImportExport.Visible = true;
        }

        private void btnSoundEffects_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnSoundEffects_Click");
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucSound.Visible = true;
        }

        private void btnWindowOverlay_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnWindowOverlay_Click");
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucOverlay.Visible = true;
        }

        private void btnResizePopup_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnResizePopup_Click");
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucResizePopup.Visible = true;
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnSupport_Click");
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucSupport.Visible = true;
        }

        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.CornflowerBlue;
        }

        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Transparent;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Transparent;

        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.DarkRed;
        }

        private void tmrOpacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.15;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }



        private void btnDebugMode_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);

            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucDebug.Visible = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End && !btnDebugMode.Visible)
            {
                tmrDebugMode.Stop();
                tmrDebugMode.Start();
                endKeyPressed++;
                if (endKeyPressed >= 3)
                {
                    tmrDebugMode.Stop();
                    endKeyPressed = 0;
                    BLIO.Log("end key pressed 3 times. Show dialog for debug mode");
                    if (RemindMeBox.Show("Enable debug mode?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                    {
                        BLIO.Log("Debug mode enabled");
                        btnDebugMode.Visible = true;
                    }
                }
            }
        }

        private void tmrDebugMode_Tick(object sender, EventArgs e)
        {
            endKeyPressed = 0;
        }        

        private void btnTimer_Click(object sender, EventArgs e)
        {            
            BLIO.Log("btnTimer_Click");
            ToggleButton(sender);            
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucTimer.Visible = true;
        }

        private void tmrUpdateRemindMe_Tick(object sender, EventArgs e)
        {    
            new Thread(() =>
            {                                
                updater.UpdateRemindMe();
            }).Start();
            
        }             

        private void tmrInitialHide_Tick(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
            tmrInitialHide.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLIO.Log("Form1_FormClosing   ["+e.CloseReason+"]");
            BLIO.DumpLogTxt();

            if (UCTimer.RunningTimers.Count > 0)            
                if (RemindMeBox.Show("You have (" + UCTimer.RunningTimers.Count + ") active timers running.\r\n\r\nAre you sure you wish to close RemindMe? These timers will not be saved", RemindMeBoxReason.YesNo) == DialogResult.No)                
                    e.Cancel = true;            
        }
        
        private void tmrCheckRemindMeMessages_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {                
                //Check for messages sent by me every minute
                foreach (RemindMeMessages message in BLOnlineDatabase.RemindMeMessages)
                {                    
                    //first, check if this user has already read this message.
                    if (BLReadMessages.Messages.Where(m => m.ReadMessageId == message.Id).Count() == 0)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate //This is required to show windows forms (the messages) on a new thread
                        {
                            BLIO.Log("RemindMe detected an unread message!");
                            //User hasn't read it yet. great! Mark the message as read
                            BLReadMessages.MarkMessageRead(message);
                            BLIO.Log("Message marked as read.");

                            if (!string.IsNullOrWhiteSpace(message.MeantForSpecificPerson))
                            {
                                BLIO.Log("This message is specifically for me!");
                                //This message is meant for a specific user.

                                if (BLSettings.Settings.UniqueString == message.MeantForSpecificPerson)
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
            }).Start();
            
        }

        private void PopupRemindMeMessage(RemindMeMessages mess)
        {
            //Update the counter on the message
            BLIO.Log("Attempting to update an message with id " + mess.Id);
            BLOnlineDatabase.UpdateRemindMeMessageCount(mess.Id);

            switch (mess.NotificationType)
            {
                case "REMINDMEBOX":
                    RemindMeBox.Show("RemindMe Developer", "This is a message from the developer of RemindMe.\r\n\r\n" + mess.Message.Replace("¤", Environment.NewLine), RemindMeBoxReason.OK);
                    break;
                case "REMINDMEMESSAGEFORM":
                    RemindMeMessageFormManager.MakeMessagePopup(mess.Message.Replace("¤", Environment.NewLine), mess.NotificationDuration.Value, "RemindMe Developer");
                    break;
            }
        }

        private void tmrPingActivity_Tick(object sender, EventArgs e)
        {
            if (BLIO.LastLogMessage != null && !BLIO.LastLogMessage.Contains("Updating user"))
                BLIO.Log("Pinging online status");

            //Update LastOnline
            BLOnlineDatabase.InsertOrUpdateUser(BLSettings.Settings.UniqueString);
        }     

        int currentLogCount = 0;
        private void tmrDumpLogTxtContents_Tick(object sender, EventArgs e)
        {
            if(BLIO.systemLog.Count != currentLogCount)
                currentLogCount = BLIO.DumpLogTxt();
        }

        private void tmrEnableDatabaseAccess_Tick(object sender, EventArgs e)
        {
            //If we could not connect to the database, the Data Access Layer will no longer try to connect to the database again. 
            //This timer will re-enable this every 10 minutes, just in case the database is no longer available. Then, if it is available again, continue as usual.
            BLOnlineDatabase.ReAllowDatabaseAccess();
        }     
    }
}
