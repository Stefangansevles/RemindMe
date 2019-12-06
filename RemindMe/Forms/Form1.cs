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
using HtmlAgilityPack;
using System.Security.Permissions;
using System.Management;

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

        //Update variables
        private RemindMeUpdater updater;
        
        private int r = 14, g = 130, b = 22;
        private bool increaseR = true;
        private bool increaseG = true;
        private bool increaseB = true;
        private bool allowshowdisplay = false;

        public Form1()
        {

            BLIO.Log("Construct Form");            
            InitializeComponent();
            instance = this;

            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            BLIO.CreateSettings();
            BLIO.CreateDatabaseIfNotExist();


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
            m_GlobalHook.KeyUp += GlobalKeyPress;

            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();

            
            UpdateInformation.Initialize();
            
            formLoadAsync();
            Thread.Sleep(2000);
            RemindMeIcon.Visible = true;                 
            BLIO.Log("Form constructed");            
        }

        public static Form1 Instance
        {
            get { return instance; }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
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
            //RemindMe loaded, if an old system log/temp reminders still exists, delete it
            string oldSystemLog = System.IO.Path.GetTempPath() + "SystemLog.txt";
            string oldTempReminders = System.IO.Path.GetTempPath() + "Exported Reminders.remindme";

            try
            {
                if (File.Exists(oldSystemLog)) File.Delete(oldSystemLog);
                if (File.Exists(oldTempReminders)) File.Delete(oldTempReminders);
            }
            catch (IOException ex) { BLIO.WriteError(ex, "Error in Cleanup()"); }
        }

        protected override void WndProc(ref Message m)
        {
            //This message will be sent when the RemindMeImporter imports reminders.
            if (m.Msg == WM_RELOAD_REMINDERS)
            {
                BLIO.Log("Received message WM_RELOAD_REMINDERS");
                int currentReminderCount = BLReminder.GetReminders().Count;

                BLReminder.NotifyChange();
                UCReminders.GetInstance().UpdateCurrentPage();

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                {
                    MessageFormManager.MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!", 3);
                    BLIO.Log("Created reminders succesfully imported message popup (WndProc)");
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
            if (BLSettings.GetSettings().EnableQuickTimer != 1) //Not enabled? don't do anything
                return;

            if (!e.Shift && !e.Control && !e.Alt) //None of the key key's (get it?) pressed? return.
                return;

            //Good! now let's check if the KeyCode is not alt shift or ctr
            if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
                return;

            timerHotkey = BLHotkeys.TimerPopup;

            if (e.Modifiers.ToString().Replace(" ", string.Empty) == timerHotkey.Modifiers && e.KeyCode.ToString() == timerHotkey.Key)
            {
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
            BLIO.Log("RemindMe_Load");

            BLIO.WriteUpdateBatch(Application.StartupPath);

            lblVersion.Text = "Version " + IOVariables.RemindMeVersion;                    

            Settings set = BLSettings.GetSettings();

            if (set.LastVersion != null && (new Version(set.LastVersion) < new Version(IOVariables.RemindMeVersion)))
            {
                //User has a new RemindMe version!                
                string releaseNotesString = "";

                foreach (KeyValuePair<string, string> entry in UpdateInformation.ReleaseNotes)
                {
                    if (new Version(entry.Key) > new Version(set.LastVersion))
                    {
                        releaseNotesString += "Version " + entry.Key + "\r\n" + entry.Value + "\r\n\r\n\r\n";
                    }
                }
                WhatsNew wn = new WhatsNew(set.LastVersion, releaseNotesString);
                wn.Show();

                //Before updating the lastVersion, log the update in the db
                BLOnlineDatabase.AddNewUpdate(DateTime.Now, set.LastVersion, IOVariables.RemindMeVersion);
                //Update lastVersion            
                set.LastVersion = IOVariables.RemindMeVersion;
                BLSettings.UpdateSettings(set);


            }

            //Default view should be reminders
            pnlMain.Controls.Add(ucReminders);

            MessageFormManager.MakeTodaysRemindersPopup();
            BLIO.Log("Today's reminders popup created");            

            //Create an shortcut in the windows startup folder if it doesn't already exist
            if (!File.Exists(IOVariables.startupFolderPath + "\\RemindMe" + ".lnk"))
                FSManager.Shortcuts.CreateShortcut(IOVariables.startupFolderPath, "RemindMe", System.Windows.Forms.Application.StartupPath + "\\" + "RemindMe.exe", "Shortcut of RemindMe");


            if (Debugger.IsAttached)
            {//Debugging ? show extra option
                btnDebugMode.Visible = true;
            }


            BLSongs.InsertWindowsSystemSounds();

            BLIO.Log("RemindMe loaded");
            Cleanup();

            tmrUpdateRemindMe.Start();

            //If the setup still exists, delete it
            File.Delete(IOVariables.rootFolder + "SetupRemindMe.msi");

            //Call the timer once
            Thread tr = new Thread(() =>
            {
                //wait a bit, then call the update timer once. It then runs every 5 minutes
                Thread.Sleep(5000);
                tmrUpdateRemindMe_Tick(null, null);
            });
            tr.Start();


            this.Opacity = 0;               
            this.ShowInTaskbar = true;
            this.Show();            
            tmrInitialHide.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
        }



        private void showRemindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("showRemindMeToolStripMenuItem_Click");
            if (this.Visible)
            {
                BLIO.Log("Remindme was already visible though..");
                return;
            }            

            //Instead of calling .Show() on a form with 100% opacity making it visible instantly, we call .Show() on the form with 0% opacity.
            //The form will be drawn invisibly, and then increase the opacity until it reaches 100%. This way RemindMe's form:
            //1. Has a fade-in like animation when showing
            //2. No longer shows flickery that occurs when drawing the form(windows-forms issue)
            allowshowdisplay = true;
            this.ShowInTaskbar = true;
            this.Show();
            tmrFadeIn.Start(); ;
            BLIO.Log("Show remindme toolstrip menu item clicked(not double-click). Showing remindme");
        }

        private void RemindMeIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BLIO.Log("Remindme icon double clicked");
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

        private void tsExit_Click(object sender, EventArgs e)
        {
            BLIO.Log("Closing RemindMe(through RemindMeIcon)");
            this.Close();
            Application.Exit();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReminders_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            if (ucNewReminder != null && ucNewReminder.saveState)
                ucNewReminder.Visible = true;            
            else
            {
                ucReminders.Visible = true;
                UCReminders.GetInstance().UpdateCurrentPage();                
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
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucImportExport.Visible = true;
        }

        private void btnSoundEffects_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucSound.Visible = true;
        }

        private void btnWindowOverlay_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucOverlay.Visible = true;
        }

        private void btnResizePopup_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucResizePopup.Visible = true;
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
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


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

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

        private void pnlMain_ControlAdded(object sender, ControlEventArgs e)
        {
            BLIO.Log("Control added to pnlMain (" + e.Control.GetType() + ")");
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);

            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            ucTimer.Visible = true;
        }

        private void tmrUpdateRemindMe_Tick(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        public void CheckForUpdates()
        {
            Version localVersion = new Version(IOVariables.RemindMeVersion);
            Version newVersion = BLIO.GetGithubVersion();

            BLIO.Log("localVersion: " + localVersion + " gitVersion: " + newVersion);

            if (newVersion > localVersion) //New version!
            {
                BLIO.Log("New version detected!");
                //SetupRemindMe exists? is the version of the msi the same as the github version? That means it is the one you downloaded. Let's not download it again!
                if (File.Exists(IOVariables.rootFolder + "SetupRemindMe.msi")
                    && new Version(BLIO.GetMsiVersion(IOVariables.rootFolder + "SetupRemindMe.msi")) == newVersion)
                    return;

                DownloadMsi();
            }
            else
                BLIO.Log("No new version.");
        }
        private void DownloadMsi()
        {            
            new Thread(() =>
            {
                try
                {                    
                    this.BeginInvoke((MethodInvoker)async delegate
                    {
                        try
                        {
                            BLIO.Log("New version on github! starting download...");
                            updater = new RemindMeUpdater();
                            updater.startDownload();

                            while (!updater.Completed)
                                await Task.Delay(500);

                            MessageFormManager.MakeMessagePopup("RemindMe has a new version available to update!\r\nClick the update button on RemindMe on the left panel!", 10);

                            btnNewUpdate.Visible = true;
                            BLIO.Log("Completed downloading the new .msi from github!");
                        }
                        catch
                        {
                            BLIO.Log("Downloading new version of RemindMe failed! :(");
                        }
                    });
                }
                catch(Exception ex)
                {
                    BLIO.Log("Failed downloading MSI. " + ex.ToString());
                }
            }).Start();
        }


        private void btnNewUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("Installing the new version from github!");

                if (!File.Exists(IOVariables.rootFolder + "SetupRemindMe.msi"))
                {
                    RemindMeBox.Show("Could not update RemindMe. Please try again later");
                    BLIO.Log("SetupRemindMe.msi was not found on the hard drive.. hmmmmm... suspicious.... ;)");
                    return;
                }
                

                ProcessStartInfo info = new ProcessStartInfo(IOVariables.rootFolder + "install.bat");
                info.Verb = "runas";

                Process process = new Process();
                process.StartInfo = info;
                process.Start();
                                              
                Application.Exit();                
            }
            catch (Exception ex)
            {
                MessageFormManager.MakeMessagePopup("Cancelled installation.", 2);
                BLIO.Log("Cancelled installation.");
            }
        }

        private void btnNewUpdate_VisibleChanged(object sender, EventArgs e)
        {
            if (btnNewUpdate.Visible)
            {
                tmrAnimateUpdateButton.Start();
                updateRemindMeToolStripMenuItem.Visible = true;
            }
            else
                tmrAnimateUpdateButton.Stop();                            

        }

        private void tmrInitialHide_Tick(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
            tmrInitialHide.Stop();
        }

        private void updateRemindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewUpdate_Click(sender, e);
        }

        private void pnlUpdateButton_VisibleChanged(object sender, EventArgs e)
        {
            if (btnNewUpdate.Visible)
                lblVersion.Location = new Point(3, 107);
            else
                lblVersion.Location = new Point(3, 542);
        }

        private void tmrAnimateUpdateButton_Tick(object sender, EventArgs e)
        {
            btnNewUpdate.BackColor = Color.FromArgb(r, g, b);
            btnNewUpdate.OnHovercolor = btnNewUpdate.BackColor;
            btnNewUpdate.Normalcolor = btnNewUpdate.BackColor;
            btnNewUpdate.Activecolor = btnNewUpdate.BackColor;

            if (increaseR)
                r += 1;
            else
                r -= 1;

            if (increaseG)            
                g += 3;            
            else            
                g -= 3;           

            if (increaseB)                         
                b += 1;            
            else                           
                b -= 1;            



            if (r >= 40)
                increaseR = false;
            if (r <= 11)
                increaseR = true;

            if (g >= 170)
                increaseG = false;
            if (g <= 130)
                increaseG = true;

            if (b >= 50)
                increaseB = false;
            if (b <= 20)
                increaseB = true;

        }
    }
}
