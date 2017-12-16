using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Database.Entity;
using System.IO;

namespace RemindMe
{
    public partial class UCImportExport : UserControl
    {        
        private ReminderTransferType transferType;
        private List<Reminder> remindersFromRemindMeFile = new List<Reminder>();
        public UCImportExport()
        {
            InitializeComponent();
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
        private void btnImport_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            lvReminders.Items.Clear();

            string remindmeFile = FSManager.Files.GetSelectedFileWithPath("RemindMe backup file", "*.remindme");

            if (remindmeFile == null || remindmeFile == "")
            {//user pressed cancel                  
                btnImport.selected = false;       
                return;
            }

            try
            {
                


                List<object> toImportReminders = BLReminder.DeserializeRemindersFromFile(remindmeFile).Cast<object>().ToList();

                if (toImportReminders != null)
                {
                    transferType = ReminderTransferType.IMPORT;
                    
                    foreach (object rem in toImportReminders)
                    {
                        if (rem.GetType() == typeof(Reminder))
                        {
                            BLFormLogic.AddReminderToListview(lvReminders, (Reminder)rem);
                            remindersFromRemindMeFile.Add((Reminder)rem);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageFormManager.MakeMessagePopup("Error loading reminder(s)", 6);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);
            lvReminders.Items.Clear();

            if (BLReminder.GetReminders().Count > 0)
            {
                transferType = ReminderTransferType.EXPORT;
                

                foreach (Reminder rem in BLReminder.GetReminders())
                {
                    BLFormLogic.AddReminderToListview(lvReminders, rem);
                }

            }
        }

        private void ToggleButton(object sender)
        {
            btnImport.selected = false;
            btnExport.selected = false;
            btnRecover.selected = false;

            if(sender != null)
                ((Bunifu.Framework.UI.BunifuFlatButton)sender).selected = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {                        
            ToggleButton(null);
            lvReminders.Items.Clear();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ToggleButton(sender);            
            lvReminders.Items.Clear();

            List<Reminder> toRecoverReminders = BLReminder.GetDeletedReminders();
            if (toRecoverReminders.Count > 0)
            {
                transferType = ReminderTransferType.RECOVER;
                foreach (Reminder rem in toRecoverReminders)
                {
                    BLFormLogic.AddReminderToListview(lvReminders, rem);
                }
                
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            switch(transferType)
            {
                case ReminderTransferType.IMPORT: ImportReminders();
                    break;
                case ReminderTransferType.EXPORT: Exportreminders();
                    break;
                case ReminderTransferType.RECOVER: RecoverReminders();
                    break;
            }
            
            foreach (ListViewItem item in lvReminders.CheckedItems)
                lvReminders.Items.Remove(item);

            

            ToggleButton(null);            
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
                        SetStatusTexts(GetSelectedRemindersFromListview().Count, BLReminder.GetReminders().Count);
                    }
                    else if (possibleException is UnauthorizedAccessException)
                    {
                        if (RemindMeBox.Show("Could not save reminders to \"" + selectedPath + "\"\r\nDo you wish to place them on your desktop instead?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                        {
                            possibleException = BLReminder.ExportReminders(GetSelectedRemindersFromListview(), Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                            if (possibleException != null)
                            {//Did saving to desktop go wrong, too?? just show a message
                                RemindMeBox.Show("Something went wrong. Could not save the reminders to your desktop.", RemindMeBoxReason.OK);
                            }
                            else
                            {//Saving to desktop did not throw an exception                        
                                SetStatusTexts(GetSelectedRemindersFromListview().Count, BLReminder.GetReminders().Count);
                            }
                        }
                    }
                    else
                    {
                        MessageFormManager.MakeMessagePopup("Backup failed.", 6);
                        return;
                    }
                }
                else
                {                    
                    return;
                }

            }
            else
            {                
                MessageFormManager.MakeMessagePopup("Please select one or more reminder(s)", 6);
            }

        }
        private bool ImportReminders()
        {
            int remindersInserted = 0;
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();

            if (selectedReminders.Count == 0)
                return false;

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
            return true;
        }
        private void RecoverReminders()
        {
            int remindersRecovered = 0;
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
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


        private List<Reminder> GetSelectedRemindersFromListview()
        {
            List<long> checkedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvReminders.CheckedItems)
                checkedIds.Add((long)item.Tag);

            if(transferType == ReminderTransferType.IMPORT) //Look through the reminders from the .remindme file instead of the database if import.
                return remindersFromRemindMeFile.Where(r => checkedIds.Contains(r.Id)).ToList();
            else
                return BLReminder.GetAllReminders().Where(r => checkedIds.Contains(r.Id)).ToList();
        }

        private void SetStatusTexts(int completedReminders, int totalReminders)
       {                                    
            foreach (ListViewItem item in lvReminders.CheckedItems)
                lvReminders.Items.Remove(item);

            if(completedReminders > 0)
                MessageFormManager.MakeMessagePopup("Succesfully " + this.transferType.ToString().ToLower() + "ed " + completedReminders + " reminders.", 4);
        }


        private void lvReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                foreach (ListViewItem item in lvReminders.Items)
                    item.Selected = true;
            }
        }

        /// <summary>
        /// Determines what the user wants to do with reminders. import,export or recover
        /// </summary>
        private enum ReminderTransferType
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

    
}

