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

namespace RemindMe
{
    public partial class UCImportExport : UserControl
    {
        List<Reminder> toImportReminders;
        public UCImportExport()
        {
            InitializeComponent();
            BLFormLogic.RemovebuttonBorders(btnExport);
            BLFormLogic.RemovebuttonBorders(btnImport);            
            toImportReminders = null;
        }

        private void UCImportExport_Load(object sender, EventArgs e)
        {

        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            string remindmeFile = FSManager.Files.GetSelectedFileWithPath("RemindMe backup file", "*.remindme");

            if (remindmeFile == null || remindmeFile == "")
                return;

            toImportReminders = BLReminder.DeserializeRemindersFromFile(remindmeFile);
            if (toImportReminders != null)
            {                
                pnlImportedReminders.Controls.Clear();
                pnlImportedReminders.Controls.Add(new UCImportedReminders(toImportReminders, true));

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

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            pnlImportedReminders.Controls.Clear();
            pnlImportedReminders.Controls.Add(new UCImportedReminders(BLReminder.GetReminders(), false));
            pbClearPanel.Visible = true;
        }

        private void pbClearPanel_Click(object sender, EventArgs e)
        {
            pnlImportedReminders.Controls.Clear();            
        }

        private void pnlImportedReminders_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (pnlImportedReminders.Controls.Count == 0)//controls cleared
                pbClearPanel.Visible = false;
        }
    }
}
