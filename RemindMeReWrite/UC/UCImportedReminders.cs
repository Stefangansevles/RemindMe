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
        private string reminderFileLanguagecode = "";
        private ReminderTransferType transferType;
        /// <summary>
        /// Shows reminders and gives the option to import/export them 
        /// </summary>
        /// <param name="reminders">The list of reminders you want to add to the listview. The user can then make a slection of these reminders to import/export</param>
        /// <param name="import">True if you want to import reminders. False if you want to export them.</param>
        public UCImportedReminders(List<object> reminders, ReminderTransferType transferType)
        {            
            InitializeComponent();
            ReminderMenuStrip.Renderer = new MyToolStripMenuRenderer();

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
            


            this.transferType = transferType;
            BLFormLogic.AddRemindersToListview(lvImportedReminders, remindersFromRemindMeFile);
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);            

            if (lvImportedReminders.Items.Count  == remindersFromRemindMeFile.Count) // -1 because the list contains one item which is the language tag, for example"en-US"
            {
                lblStatus.Text = "Succesfully loaded reminders.";
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            }
            else
            {
                lblStatus.Text = "Not all reminders loaded. (" + lvImportedReminders.Items.Count + "/" + remindersFromRemindMeFile.Count + ")"; 
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }

            if(lvImportedReminders.Items.Count == 0)
                lblStatus.Text = "No reminders to load.";

            FixText();
        }

     
        private void btnYes_Click(object sender, EventArgs e)
        {
            if(lvImportedReminders.CheckedItems.Count > 0)
            {
                if (this.transferType == ReminderTransferType.IMPORT)
                    ImportReminders();
                else if (this.transferType == ReminderTransferType.EXPORT)
                    Exportreminders();
                else if (this.transferType == ReminderTransferType.RECOVER)
                    RecoverReminders();
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
            if (this.transferType == ReminderTransferType.IMPORT)
            {
                label1.Text = "Select the reminders you want to import";
                btnYes.Text = "Import";
            }
            else if (this.transferType == ReminderTransferType.EXPORT)
            {
                label1.Text = "Select the reminders you want to export";
                btnYes.Text = "Export";
            }
            else if (this.transferType == ReminderTransferType.RECOVER)
            {
                label1.Text = "Select the reminders you want to recover";
                btnYes.Text = "Recover";
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

                    Exception possibleException = BLReminder.ExportReminders(GetSelectedRemindersFromListview(), selectedPath);
                    if (possibleException == null)
                    {
                        lblStatus.Text = "Backup completed.";
                        pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
                    }
                    else if (possibleException is UnauthorizedAccessException)
                    {
                        if (RemindMeBox.Show("Could not save reminders to \"" + selectedPath + "\"\r\nDo you wish to place them on your desktop instead?", RemindMeBoxIcon.EXCLAMATION, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            possibleException = BLReminder.ExportReminders(GetSelectedRemindersFromListview(), Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                            if (possibleException != null)
                            {//Did saving to desktop go wrong, too?? just show a message
                                RemindMeBox.Show("Something went wrong. Could not save the reminders to your desktop.", RemindMeBoxIcon.EXCLAMATION, MessageBoxButtons.OK);
                            }
                            else
                            {//Saving to desktop did not throw an exception                        
                                lblStatus.Text = "Backup completed.";
                                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
                            }
                        }
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
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
            if (remindersFromRemindMeFile != null)
            {
                foreach (Reminder rem in selectedReminders)
                {
                    if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                        rem.SoundFilePath = "";
                    
                    BLReminder.PushReminderToDatabase(rem);                
                    remindersInserted++;                    
                }
            }
            SetStatusTexts(remindersInserted, selectedReminders.Count);
        }
        private void RecoverReminders()
        {
            int remindersRecovered = 0;
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
            if (remindersFromRemindMeFile != null)
            {
                foreach (Reminder rem in selectedReminders)
                {
                    if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                        rem.SoundFilePath = "";

                    if (rem.Deleted == 1) //The user wants to recover reminders, instead of importing new ones
                    {
                        rem.Deleted = 0;
                        BLReminder.EditReminder(rem);
                    }                    
                    remindersRecovered++;                    
                }
                SetStatusTexts(remindersRecovered, selectedReminders.Count);
            }            
        }



        private void SetStatusTexts(int completedReminders,int totalReminders)
        {
            string transferType = this.transferType.ToString().ToLower() + "ed"; //export+ed = exported, imported, recovered , etc
            if (completedReminders == totalReminders)
            {
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
                lblStatus.Text = completedReminders + " / " + totalReminders + " Reminders " + transferType + ".";
            }
            else
            {
                lblStatus.Text = this.transferType.ToString().ToLower() + " failed.";

                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }

            remindersFromRemindMeFile = null;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            foreach (ListViewItem item in lvImportedReminders.CheckedItems)
                lvImportedReminders.Items.Remove(item);            
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

        private void lvImportedReminders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvImportedReminders.SelectedItems.Count > 0 && this.transferType == ReminderTransferType.RECOVER)
            {
                ReminderMenuStrip.Show(Cursor.Position);
            }
        }

        private void permanentelyRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();

            if (selectedReminders.Count > 0)
            {
                if (RemindMeBox.Show("Are you really sure you wish to permanentely delete " + selectedReminders.Count + " reminders?", RemindMeBoxIcon.EXCLAMATION, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLReminder.PermanentelyDeleteReminders(selectedReminders);
                }

                foreach (ListViewItem item in lvImportedReminders.CheckedItems)
                    lvImportedReminders.Items.Remove(item);
            }
        }
    }

    /// <summary>
    /// Determines what the user wants to do with reminders. import,export or recover
    /// </summary>
    public enum ReminderTransferType
    {
        /// <summary>
        /// The user wants to import new reminders
        /// </summary>
        IMPORT,
        /// <summary>
        /// The user wants to export his reminders
        /// </summary>
        EXPORT,
        /// <summary>
        /// The user wants to recover his previously deleted reminders
        /// </summary>
        RECOVER
    }
}
