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
        List<Reminder> reminders;
        public UCImportExport()
        {
            InitializeComponent();
            BLFormLogic.RemovebuttonBorders(btnExport);
            BLFormLogic.RemovebuttonBorders(btnImport);            
            reminders = null;
        }

        private void UCImportExport_Load(object sender, EventArgs e)
        {

        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            string remindmeFile = FSManager.Files.GetSelectedFileWithPath("RemindMe backup", "*.remindme");

            if (remindmeFile == null || remindmeFile == "")
                return;

            reminders = BLIO.ReadRemindersFromFile(remindmeFile);
            if (reminders != null)
            {
                

                pnlImportedReminders.Controls.Clear();
                pnlImportedReminders.Controls.Add(new UCImportedReminders(reminders));

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
            lblStatus.Text = "";
            Exception ex = null;

            string selectedPath = FSManager.Folders.GetSelectedFolderPath();
            if (selectedPath != null)
                ex = BLIO.ExportRemindersToFile(selectedPath + "\\Backup reminders " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".remindme");
            else
            {
                lblStatus.Text = "Backup failed. Backup cancelled";
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
                return;
            }

            if (ex == null)
            {
                lblStatus.Text = "Backup completed.";
                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            }
            else
            {
                lblStatus.Text = "Backup failed. " + ex.Message;
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }

            lblStatus.Focus();

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
