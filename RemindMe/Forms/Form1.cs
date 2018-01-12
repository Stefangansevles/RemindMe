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

namespace RemindMe
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        //User controls that will be loaded into the "main" panel
        UCReminders ucReminders;
        UCImportExport ucImportExport;
        UCSound ucSound;
        UCWindowOverlay ucOverlay;
        UCResizePopup ucResizePopup;
        UCSupport ucSupport;
        public static UCNewReminder ucNewReminder; //Can be null

        public Form1()
        {

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

            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();
            
            
        }

        //prevent flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        protected override void WndProc(ref Message m)
        {                        
            //This message will be sent when the RemindMeImporter imports reminders.
            if (m.Msg == WM_RELOAD_REMINDERS)
            {
                int currentReminderCount = BLReminder.GetReminders().Count;
                BLReminder.NotifyChange();
                UCReminders.NotifyChange();

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                    MessageFormManager.MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!", 3);

            }

            base.WndProc(ref m);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Default view should be reminders
            pnlMain.Controls.Add(ucReminders);

            MessageFormManager.MakeTodaysRemindersPopup();
           
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
            this.Show();
            this.WindowState = FormWindowState.Normal;
            tmrFadeIn.Start();
        }

        private void RemindMeIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            tmrFadeIn.Start();
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

        
    }
}
