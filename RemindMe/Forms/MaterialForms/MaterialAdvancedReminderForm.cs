using Business_Logic_Layer;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MaterialAdvancedReminderForm : MaterialForm
    {
        public MaterialAdvancedReminderForm()
        {
            this.Opacity = 0;
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(this);
            InitializeComponent();                                
            BLIO.Log("Advanced reminder form created!");            
        }

        private void MaterialAdvancedReminderForm_Load(object sender, EventArgs e)
        {
            BLIO.Log("Advanced Reminder Form loaded");
            MaterialForm1 remindme = (MaterialForm1)Application.OpenForms["MaterialForm1"];
            if (remindme != null)
            {
                //Place the message box in the middle of remindme
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            tmrFadeIn.Start();
        }

        public string BatchScript
        {
            get { return tbBatch.Text; }
            set { tbBatch.Text = value; }
        }
        public bool HideReminder
        {
            get { return cbHideReminder.Checked; }
            set { cbHideReminder.Checked = value; }
        }

        private void tbBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all
                tbBatch.SelectAll();
                tbBatch.Focus();
            }
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(tbBatch.Text.Length > 0 || cbHideReminder.Checked)
                MaterialMessageFormManager.MakeMessagePopup("Advanced settings applied/updated", 5);

            Hide();
        }        

        private void MaterialAdvancedReminderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialSkin.MaterialSkinManager.Instance.RemoveFormToManage(this);
        }
    }
}
