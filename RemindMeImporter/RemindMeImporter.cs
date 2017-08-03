using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMeImporter
{
    public partial class RemindMeImporter : Form
    {
        #region Dll Imports
        private const int HWND_BROADCAST = 0xFFFF;

        //tell remindme to reload reminders
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports
        

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        private string reminderFile;
        public RemindMeImporter(string reminderFile)
        {
            InitializeComponent();
            this.reminderFile = reminderFile;
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
            AppDomain.CurrentDomain.SetData("DataDirectory",  Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RemindMe\\RemindMeDatabase.db");
        }

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            //minimize to tray
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void RemindMeImporter_Load(object sender, EventArgs e)
        {
            List<Reminder> reminders = BLIO.ReadRemindersFromFile(reminderFile);
            BLFormLogic.AddRemindersToListview(lvImportedReminders, reminders);
            lblStatus.Text = "Succesfully loaded reminders.";
            pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Reminder rem in BLIO.ReadRemindersFromFile(reminderFile))
                    BLReminder.PushReminderToDatabase(rem);

                PostMessage((IntPtr)HWND_BROADCAST,WM_RELOAD_REMINDERS,new IntPtr(0xCDCD),new IntPtr(0xEFEF));

                this.Close();
                this.Dispose();
            }
            catch
            {

            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
