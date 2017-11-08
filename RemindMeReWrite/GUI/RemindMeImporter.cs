using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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


        private string remindmeFile;
        private List<Reminder> remindersFromRemindMeFile = new List<Reminder>();      

        private static TimeZone time = TimeZone.CurrentTimeZone;
        private static string languageCode = "";
        /// <summary>
        /// The form that allows 
        /// </summary>
        /// <param name="reminderFile"></param>
        public RemindMeImporter(string reminderFile)
        {
            InitializeComponent();
            this.remindmeFile = reminderFile;
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
            AppDomain.CurrentDomain.SetData("DataDirectory", Variables.IOVariables.databaseFile);
        }

      

        private static bool HasFileAccess(string filePath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                {
                    return true;                    
                }
                
            }
            catch (UnauthorizedAccessException ex)
            {                
                return false;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            BLFormLogic.customBackgroundPainter(e, this, linethickness: 3, linecolor: Color.White, offsetborder: 0);
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
                if (lvImportedReminders.CheckedItems.Count > 0)
                {
                    foreach (Reminder rem in GetSelectedRemindersFromListview())
                    {
                        if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                            rem.SoundFilePath = "";

                        BLReminder.PushReminderToDatabase(rem);
                    }

                    //Let remindme know that the listview should be refreshed
                    PostMessage((IntPtr)HWND_BROADCAST, WM_RELOAD_REMINDERS, new IntPtr(0xCDCD), new IntPtr(0xEFEF));

                    this.Close();
                }
                else
                {
                    lblStatus.Text = "Please select at least one reminder.";
                    pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);                    
                }
                
            }
            catch(Exception ex)
            {
                ErrorPopup pop = new ErrorPopup("Error inserting reminders", ex);
                pop.Show();
                BLIO.WriteError(ex, "Error inserting reminders");
            }
        }

        private List<Reminder> GetSelectedRemindersFromListview()
        {            
            List<long> selectedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach(ListViewItem item in lvImportedReminders.CheckedItems)            
                selectedIds.Add((long)item.Tag);


            return remindersFromRemindMeFile.Where(r => selectedIds.Contains(r.Id)).ToList();
            
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void RemindMeImporter_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;


            if (!HasFileAccess(this.remindmeFile)) //Do not attempt to launch the importer form if we can't open the file
            {
                RemindMeBox.Show("Can not open this .remindme file from " + Path.GetDirectoryName(this.remindmeFile) + ". Insufficient rights.", RemindMeBoxIcon.EXCLAMATION, MessageBoxButtons.OK);
                this.Close();
            }
            else
            {

                try
                {
                    foreach (object rem in BLReminder.DeserializeRemindersFromFile(remindmeFile))
                    {
                        if (rem.GetType() == typeof(Reminder))
                            remindersFromRemindMeFile.Add((Reminder)rem);
                        else
                            languageCode = rem.ToString(); //The language code stored in the .remindme file, "en-Us" for example
                    }

                    if (languageCode != "") //Don't need to do this when exporting.
                    {
                        foreach (object rem in remindersFromRemindMeFile)
                        {
                            if (rem.GetType() == typeof(Reminder))
                            {
                                Reminder remm = (Reminder)rem;
                                //Fix the date if the .remindme file has a different time format than the current system
                                remm.Date = BLDateTime.ConvertDateTimeStringToCurrentCulture(remm.Date, languageCode);
                            }
                        }
                    }

                    if (remindersFromRemindMeFile != null)
                    {
                        BLFormLogic.AddRemindersToListview(lvImportedReminders, remindersFromRemindMeFile);
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
                catch(Exception ex)
                {
                    RemindMeBox.Show("Something has gone wrong loading reminders from this .remindme file.\r\nThe file might be corrupt",RemindMeBoxIcon.EXCLAMATION, MessageBoxButtons.OK);
                    BLIO.WriteError(ex, "Error loading reminders from .remindme file");
                    Application.Exit();
                }
            }
        }

        

        private void lvImportedReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                foreach (ListViewItem item in lvImportedReminders.Items)
                    item.Selected = true;
            }
        }
    }
}

