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

namespace RemindMe
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        //User controls that will be loaded into the "main" panel
        private UCReminders ucReminders;
        private UCImportExport ucImportExport;
        private UCSound ucSound;
        private UCWindowOverlay ucOverlay;
        private UCResizePopup ucResizePopup;
        private UCSupport ucSupport;
        private UCDebugMode ucDebug;
        public static UCNewReminder ucNewReminder; //Can be null
        //If the user presses the end key quickly 3 times, enable debug mode
        private int endKeyPressed = 0;

        public Form1()
        {

            BLIO.Log("Construct Form");
            InitializeComponent();            

            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            BLIO.CreateSettings();
            BLIO.CreateDatabaseIfNotExist();

            //User controls that will be loaded into the "main" panel
            ucReminders = new UCReminders();
            ucImportExport = new UCImportExport();
            ucSound = new UCSound();
            ucOverlay = new UCWindowOverlay();
            ucResizePopup = new UCResizePopup();
            ucSupport = new UCSupport();
            ucDebug = new UCDebugMode();

            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();
            BLIO.Log("Form constructed");
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

            if (File.Exists(oldSystemLog)) File.Delete(oldSystemLog);
            if (File.Exists(oldTempReminders)) File.Delete(oldTempReminders);
        }

        protected override void WndProc(ref Message m)
        {
            //This message will be sent when the RemindMeImporter imports reminders.
            if (m.Msg == WM_RELOAD_REMINDERS)
            {
                BLIO.Log("Received message WM_RELOAD_REMINDERS");
                int currentReminderCount = BLReminder.GetReminders().Count;
               
                BLReminder.NotifyChange();
                UCReminders.NotifyChange();

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                {                    
                    MessageFormManager.MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!", 3);
                    BLIO.Log("Created reminders succesfully imported message popup (WndProc)");
                }

            }

            base.WndProc(ref m);
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {            
            BLIO.Log("RemindMe_Load");
            //Default view should be reminders
            pnlMain.Controls.Add(ucReminders);

            MessageFormManager.MakeTodaysRemindersPopup();
            BLIO.Log("Today's reminders popup created");

            //hide the form on startup
            BeginInvoke(new MethodInvoker(delegate
            {
                this.Opacity = 0;
                Hide();
            }));

            //Create an shortcut in the windows startup folder if it doesn't already exist
            if (!File.Exists(IOVariables.startupFolderPath + "\\RemindMe" + ".lnk"))
                FSManager.Shortcuts.CreateShortcut(IOVariables.startupFolderPath, "RemindMe", Application.StartupPath + "\\" + "RemindMe.exe", "Shortcut of RemindMe");

            

            lblVersion.Text = "Version " + IOVariables.RemindMeVersion;


            if (System.Diagnostics.Debugger.IsAttached)
            {//Debugging ? show extra option
                btnDebugMode.Visible = true;
            }
            BLIO.Log("RemindMe loaded");
            Cleanup();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
        }




        private void showRemindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;

            //Instead of calling .Show() on a form with 100% opacity making it visible instantly, we call .Show() on the form with 0% opacity.
            //The form will be drawn invisibly, and then increase the opacity until it reaches 100%. This way RemindMe's form:
            //1. Has a fade-in like animation when showing
            //2. No longer shows flickery that occurs when drawing the form(windows-forms issue)
            this.Show();
            this.WindowState = FormWindowState.Normal;
            tmrFadeIn.Start();
            BLIO.Log("Show remindme toolstrip menu item clicked. Showing remindme");
        }

        private void RemindMeIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                return;

            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            tmrFadeIn.Start();
            BLIO.Log("Remindme icon double clicked");
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReminders_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            if (ucNewReminder != null)
                pnlMain.Controls.Add(ucNewReminder);
            else
            {
                UCReminders.NotifyChange();
                pnlMain.Controls.Add(ucReminders);
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
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucImportExport);
        }

        private void btnSoundEffects_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucSound);
        }

        private void btnWindowOverlay_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucOverlay);
        }

        private void btnResizePopup_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucResizePopup);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucSupport);
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

        private void pnlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            BLIO.Log("Control removed from pnlMain (" + e.Control.GetType() + ")");
            //If the removed control is UCNewReminder, dispose it. Memory usage goes up and doesnt get cleaned
            //When you edit multiple reminders without disposing them.
            if (e.Control is UCNewReminder )
            {
                if (ucNewReminder != null && ucNewReminder.shouldDispose)
                {
                    e.Control.Dispose();
                    BLIO.Log("ucNewReminder disposed");
                    ucNewReminder = null;
                }
            }
        }

        private void btnDebugMode_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ucDebug);

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
        
    }
}
