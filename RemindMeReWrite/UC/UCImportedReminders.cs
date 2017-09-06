using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.IO;
using System.Linq;

namespace RemindMe
{
    public partial class UCImportedReminders : UserControl
    {
        private List<Reminder> remindersFromRemindMeFile;
        private bool import;
        /// <summary>
        /// Shows reminders and gives the option to import/export them 
        /// </summary>
        /// <param name="reminders">The list of reminders you want to add to the listview. The user can then make a slection of these reminders to import/export</param>
        /// <param name="import">True if you want to import reminders. False if you want to export them.</param>
        public UCImportedReminders(List<Reminder> reminders,bool import)
        {
            InitializeComponent();
            this.remindersFromRemindMeFile = reminders;
            this.import = import;
            BLFormLogic.AddRemindersToListview(lvImportedReminders, reminders);
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
            BLFormLogic.RemovebuttonBorders(btnSelectAll);

            if (lvImportedReminders.Items.Count == reminders.Count)
            {
                lblStatus.Text = "Succesfully loaded reminders.";
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            }
            else
            {
                lblStatus.Text = "Not all reminders loaded. (" + lvImportedReminders.Items.Count + "/" + reminders.Count + ")"; 
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }
            

            FixText();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if(lvImportedReminders.SelectedItems.Count > 0)
            {
                if (import)
                    ImportReminders();
                else
                    Exportreminders();
            }
            else
            {
                lblStatus.Text = "Select 1 or more reminders.";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }
        }

       

        

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Clear();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvImportedReminders.Items)           
                item.Selected = true;                            

            lvImportedReminders.Select();
        }

        /// <summary>
        /// Sets the button/label text to import-related text if the user chose import, and export if the user chose export.
        /// </summary>
        private void FixText()
        {
            if (import)
            {
                label1.Text = "Select the reminders you want to import";
                btnYes.Text = "Import";
            }
            else
            {
                label1.Text = "Select the reminders you want to export";
                btnYes.Text = "Export";
            }
        }
        private List<Reminder> GetSelectedRemindersFromListview()
        {                       
            List<long> selectedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvImportedReminders.SelectedItems)
                selectedIds.Add((long)item.Tag);

            return remindersFromRemindMeFile.Where(r => selectedIds.Contains(r.Id)).ToList();
        }
        private void Exportreminders()
        {
            if (GetSelectedRemindersFromListview().Count > 0)
            {
                string selectedPath = FSManager.Folders.GetSelectedFolderPath();
                if (selectedPath != null)
                {
                    try
                    {
                        if (BLReminder.SerializeRemindersToFile(GetSelectedRemindersFromListview(), selectedPath + "\\Backup reminders " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".remindme"))
                        {
                            lblStatus.Text = "Backup completed.";
                            pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
                        }
                        else
                        {
                            lblStatus.Text = "Backup failed";
                            pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
                            return;
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        RemindMeBox.Show("Can not export reminders to\r\n\"" + selectedPath + "\"!\r\nAccess is denied.\r\n\r\nIf you wish to save to that path, run RemindMe in administrator mode.", RemindMeBoxIcon.EXCLAMATION);
                    }
                }
                else
                {
                    lblStatus.Text = "Backup failed. Backup cancelled";
                    pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
                    return;
                }
                
            }
            else
            {
                lblStatus.Text = "Please select one or more reminders";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }

        }
        private void ImportReminders()
        {
            int remindersInserted = 0;
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
            if (remindersFromRemindMeFile != null)
            {
                foreach (Reminder rem in selectedReminders)
                {
                    if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                        rem.SoundFilePath = "";

                    BLReminder.PushReminderToDatabase(rem);
                    remindersInserted++;
                    lblStatus.Text = remindersInserted + " / " + selectedReminders.Count + " Reminders added.";
                }
            }

            if (remindersInserted == selectedReminders.Count)
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            else
            {
                lblStatus.Text = "Import failed.";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }

            remindersFromRemindMeFile = null;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            lvImportedReminders.Items.Clear();
        }
    }
}
