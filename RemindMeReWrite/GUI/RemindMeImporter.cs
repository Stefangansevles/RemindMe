using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RemindMe
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

        /// <summary>
        /// The form that allows 
        /// </summary>
        /// <param name="reminderFile"></param>
        public RemindMeImporter(string reminderFile)
        {
            InitializeComponent();
            this.reminderFile = reminderFile;
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
            AppDomain.CurrentDomain.SetData("DataDirectory", Variables.IOVariables.databaseFile);
        }

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
                
                         
        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Reminder rem in BLIO.ReadRemindersFromFile(reminderFile))
                    BLReminder.PushReminderToDatabase(rem);

                //Let remindme know that the listview should be refreshed
                PostMessage((IntPtr)HWND_BROADCAST, WM_RELOAD_REMINDERS, new IntPtr(0xCDCD), new IntPtr(0xEFEF));
                
                this.Close();
                
            }
            catch(Exception ex)
            {
                ErrorPopup pop = new ErrorPopup("Error inserting reminders", ex);
                pop.Show();
                BLIO.WriteError(ex, "Error inserting reminders");
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemindMeImporter_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;

            List<Reminder> reminders = BLIO.ReadRemindersFromFile(reminderFile);
            if (reminders != null)
            {
                BLFormLogic.AddRemindersToListview(lvImportedReminders, reminders);
                lblStatus.Text = "Succesfully loaded reminders.";
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            }
            else
            {
                lblStatus.Text = "Failed to load reminders.";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
                btnYes.Enabled = false;
            }
        }      
    }
}

