using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.IO;

namespace RemindMe
{
    public partial class UCImportedReminders : UserControl
    {
        private List<Reminder> reminders;
        private bool import;
        /// <summary>
        /// Shows reminders and gives the option to import/export them 
        /// </summary>
        /// <param name="reminders">The list of reminders you want to add to the listview. The user can then make a slection of these reminders to import/export</param>
        /// <param name="import">True if you want to import reminders. False if you want to export them.</param>
        public UCImportedReminders(List<Reminder> reminders,bool import)
        {
            InitializeComponent();
            this.reminders = reminders;
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
            //Imported reminders are just values. They don't have ID's. Exported reminders however, are reminders that are currently inside RemindMe.
            //These reminders do have an id in the listview's tag. 

            List<Reminder> toReturnList = new List<Reminder>();
            foreach(ListViewItem item in lvImportedReminders.SelectedItems)
            {
                Reminder rem = BLReminder.GetReminderById((long)item.Tag);
                if (rem != null)
                    toReturnList.Add(rem);
            }
            return toReturnList;
        }
        private void Exportreminders()
        {
            if (GetSelectedRemindersFromListview().Count > 0)
            {
                string selectedPath = FSManager.Folders.GetSelectedFolderPath();
                if (selectedPath != null)
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
            if (reminders != null)
            {
                foreach (Reminder rem in reminders)
                {
                    if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                        rem.SoundFilePath = "";

                    BLReminder.PushReminderToDatabase(rem);
                    remindersInserted++;
                    lblStatus.Text = remindersInserted + " / " + reminders.Count + " Reminders added.";
                }
            }

            if (remindersInserted == reminders.Count)
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            else
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);

            reminders = null;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            lvImportedReminders.Items.Clear();
        }
    }
}
