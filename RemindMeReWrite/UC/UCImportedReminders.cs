using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace RemindMe
{
    public partial class UCImportedReminders : UserControl
    {        
        private List<Reminder> remindersFromRemindMeFile;
        private bool import;
        private string reminderFileLanguagecode = "";
       
        /// <summary>
        /// Shows reminders and gives the option to import/export them 
        /// </summary>
        /// <param name="reminders">The list of reminders you want to add to the listview. The user can then make a slection of these reminders to import/export</param>
        /// <param name="import">True if you want to import reminders. False if you want to export them.</param>
        public UCImportedReminders(List<object> reminders,bool import)
        {            
            InitializeComponent();
            remindersFromRemindMeFile = new List<Reminder>();
            foreach (object rem in reminders)
            {
                if (rem.GetType() == typeof(Reminder))                
                    remindersFromRemindMeFile.Add((Reminder)rem);                
                else
                    reminderFileLanguagecode = rem.ToString(); //The language code stored in the .remindme file                                
            }

            if (reminderFileLanguagecode != "") //Don't need to do this when exporting.
            {
                foreach (object rem in reminders) 
                {
                    if (rem.GetType() == typeof(Reminder))
                    {
                        Reminder remm = (Reminder)rem;
                        //Fix the date if the .remindme file has a different time format than the current system
                        remm.Date = BLDateTime.ConvertDateTimeStringToCurrentCulture(remm.Date, reminderFileLanguagecode);
                    }
                }
            }
            


            this.import = import;
            BLFormLogic.AddRemindersToListview(lvImportedReminders, remindersFromRemindMeFile);
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);            

            if (lvImportedReminders.Items.Count  == reminders.Count) // -1 because the list contains one item which is the language tag, for example"en-US"
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
            if(lvImportedReminders.CheckedItems.Count > 0)
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
            List<long> checkedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvImportedReminders.CheckedItems)
                checkedIds.Add((long)item.Tag);

            return remindersFromRemindMeFile.Where(r => checkedIds.Contains(r.Id)).ToList();
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
                        if (BLReminder.ExportReminders(GetSelectedRemindersFromListview(), selectedPath))
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

        private void lvImportedReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                foreach (ListViewItem item in lvImportedReminders.Items)
                    item.Selected = true;
            }
        }

       

       

        
    }
}
