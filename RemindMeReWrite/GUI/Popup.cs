using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class Popup : Form
    {
        private Reminder rem;
        public Popup(Reminder rem)
        {
            InitializeComponent();
            this.rem = rem;            
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void pbClosePopup_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            if (DLSettings.IsAlwaysOnTop())
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            else
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;             
            }

            //Show the reminder note            
            tbText.Text = rem.Note.Replace("\\n", Environment.NewLine);

            //Show what date this reminder was set for
            if(rem.PostponeDate == null)
                lblDate.Text = "This reminder was set for " + rem.Date;
            else
                lblDate.Text = "This reminder was set for " + rem.PostponeDate;

            tbTitle.Text = rem.Name;            

            //Make the button look better
            btnOk.TabStop = false;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;

            cbPostponeType.SelectedItem = cbPostponeType.Items[0];

            lblDate.Focus();            
        }

        private void pbMinimizePopup_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
         

            if (cbPostpone.Checked)
            {
                DateTime newReminderTime = new DateTime();
                if (cbPostponeType.SelectedItem == cbPostponeType.Items[0])
                {//postpone option is x minutes
                    newReminderTime = DateTime.Now.AddMinutes((double)cbPostponeTime.Value);
                }
                else
                {//postpone option is x hours
                    newReminderTime = DateTime.Now.AddHours((double)cbPostponeTime.Value);
                }
                rem.PostponeDate = newReminderTime.ToString();
                rem.Enabled = 1;
                DLReminders.EditReminder(rem);
            }
            else
            {
                rem.PostponeDate = null;
                DLReminders.UpdateReminder(rem);
            }
            RefreshMainFormListView();

            this.Dispose();
            this.Close();
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            rem.PostponeDate = null;
            DLReminders.UpdateReminder(rem);
            RefreshMainFormListView();
            this.Close();
            this.Dispose();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;            
        }

        private void cbPostpone_CheckedChanged(object sender, EventArgs e)
        {            
            if (cbPostpone.Checked)
                btnOk.Text = "Postpone";
            else
                btnOk.Text = "Ok";
        }

        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Try to update the reminder before the form unexpectedly closes
            rem.PostponeDate = null;
            DLReminders.UpdateReminder(rem);
            RefreshMainFormListView();
        }

        private void RefreshMainFormListView()
        {
            Form mainForm = Application.OpenForms["Form1"];
            ListView lvReminders = (ListView)mainForm.Controls["pnlMain"].Controls["lvReminders"];
            BLFormLogic.RefreshListview(lvReminders);
        }

        private void cbPostponeTime_ValueChanged(object sender, EventArgs e)
        {
            cbPostpone.Checked = true;
        }

        private void cbPostponeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPostponeType.SelectedItem.ToString() == "Hours")
                cbPostponeTime.Maximum = 23;
            else
                cbPostponeTime.Maximum = 1400;
        }
    }
}
