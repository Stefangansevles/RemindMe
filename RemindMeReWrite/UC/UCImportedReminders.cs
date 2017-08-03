using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;


namespace RemindMe
{
    public partial class UCImportedReminders : UserControl
    {
        List<Reminder> importedReminders;
        public UCImportedReminders(List<Reminder> importedReminders)
        {
            InitializeComponent();
            this.importedReminders = importedReminders;
            BLFormLogic.AddRemindersToListview(lvImportedReminders, importedReminders);
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);

            lblStatus.Text = "Succesfully loaded reminders.";
            pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {            
            int remindersInserted = 0;
            if (importedReminders != null)
            {
                foreach (Reminder rem in importedReminders)
                {
                    BLReminder.PushReminderToDatabase(rem);
                    remindersInserted++;
                    lblStatus.Text = remindersInserted + " / " + importedReminders.Count + " Reminders added.";
                }
            }

            if (remindersInserted == importedReminders.Count)
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            else
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);

            importedReminders = null;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            lvImportedReminders.Items.Clear();        
        }

       

        

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Clear();
        }
    }
}
