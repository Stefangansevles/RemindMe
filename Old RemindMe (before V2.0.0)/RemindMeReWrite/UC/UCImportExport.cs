using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrendanGrant.Helpers.FileAssociation;
using System.Security.Permissions;
using Business_Logic_Layer;
using Database.Entity;
using System.Threading;
using System.Globalization;

namespace RemindMe
{
    public partial class UCImportExport : UserControl
    {
        List<object> toImportReminders;
        public UCImportExport()
        {
            InitializeComponent();            
            toImportReminders = null;
        }

        private void UCImportExport_Load(object sender, EventArgs e)
        {
            pnlIntro.Visible = true;
        }

        

        private void pbClearPanel_Click(object sender, EventArgs e)
        {
            pnlImportedReminders.Controls.Clear();            
        }

        private void pnlImportedReminders_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (pnlImportedReminders.Controls.Count == 0)//controls cleared
            {
                pbClearPanel.Visible = false;
                pnlIntro.Visible = true;
            }
        }

        private void pbExport_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            pbStatus.Visible = false;

            pnlImportedReminders.Controls.Clear();
            pnlImportedReminders.Controls.Add(new UCImportedReminders(BLReminder.GetReminders().Cast<object>().ToList(), ReminderTransferType.EXPORT));
            pbClearPanel.Visible = true;
            pnlIntro.Visible = false;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pbExport_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pbImport_Click(sender, e);
        }

        private void pbImport_Click(object sender, EventArgs e)
        {            
            string remindmeFile = FSManager.Files.GetSelectedFileWithPath("RemindMe backup file", "*.remindme");

            if (remindmeFile == null || remindmeFile == "")
            {//user pressed cancel
                pnlIntro.Visible = true;
                return;
            }

            List<object> test = BLReminder.DeserializeRemindersFromFile(remindmeFile).Cast<object>().ToList();

            toImportReminders = BLReminder.DeserializeRemindersFromFile(remindmeFile);
            if (toImportReminders != null)
            {
                pnlImportedReminders.Controls.Clear();
                pnlImportedReminders.Controls.Add(new UCImportedReminders(toImportReminders, ReminderTransferType.IMPORT));

                pbClearPanel.Visible = true;

                pbStatus.BackgroundImage = null;
                lblStatus.Text = "";
            }
            else
            {
                lblStatus.Text = "Loading reminders failed.";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);

                pnlImportedReminders.Controls.Clear();
            }
            pnlIntro.Visible = false;
        }

        private void pbRecover_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            pbStatus.Visible = false;

            pnlImportedReminders.Controls.Clear();            
            pnlImportedReminders.Controls.Add(new UCImportedReminders(BLReminder.GetDeletedReminders().Cast<object>().ToList(), ReminderTransferType.RECOVER));
            pbClearPanel.Visible = true;
            pnlIntro.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            pbRecover_Click(sender, e);
        }
    }
}
