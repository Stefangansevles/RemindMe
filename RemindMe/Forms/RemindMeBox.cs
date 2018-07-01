using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// An option dialogue giving the user the option to choose yes or no, or just ok.
    /// </summary>
    public partial class RemindMeBox : Form
    {
        private string description;
        private static DialogResult result;
        private static RemindMeBox newMessageBox;
        private static bool showDontRemind;
        private RemindMeBox(string description, RemindMeBoxReason buttons, bool showDontRemindOption)
        {
            BLIO.Log("Constructing RemindMeBox(" + description + "");
            //We will use the default "Attention" title text
            InitializeComponent();

            showDontRemind = showDontRemindOption;

            if (buttons == RemindMeBoxReason.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            else
                btnOk.Visible = true;

            if (showDontRemind)
                pnlRemind.Visible = true;

            this.description = description;

            this.Opacity = 0;
            tmrFadeIn.Start();
            lblText.MaximumSize = new Size((pnlMainGradient.Width - lblText.Location.X) - 10, 0);
            lblTitle.MaximumSize = new Size((pnlMainGradient.Width - lblTitle.Location.X) - 10, 0);

            
            lblText.Text = description;


        

            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;

            
            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null)
            {
                //Place the message box in the middle of remindme
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            BLIO.Log("RemindMeBox constructed");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private RemindMeBox(string title,string description,  RemindMeBoxReason buttons, bool showDontRemindOption) : this(description,buttons, showDontRemindOption)
        {
            lblTitle.Text = title;

            //Reposition the text label so that the title label wont overlap
            while (lblTitle.Location.Y + lblTitle.Height >= lblText.Location.Y)
                lblText.Location = new Point(lblText.Location.X, lblText.Location.Y + 20);

            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;

        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            newMessageBox.Close();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            if(cbDontRemind.Checked)
            {
                Settings settingsObject = BLSettings.GetSettings();
                settingsObject.HideReminderConfirmation = 1;
                BLSettings.UpdateSettings(settingsObject);                
            }
            newMessageBox.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            newMessageBox.Close();
        }

        public static DialogResult Show(string text, bool showDontRemindOption = false)
        {
            newMessageBox = new RemindMeBox(text, RemindMeBoxReason.OK,showDontRemindOption);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);
            return result;
        }
        public static DialogResult Show(string text, RemindMeBoxReason buttons, bool showDontRemindOption = false)
        {
            newMessageBox = new RemindMeBox(text, buttons,showDontRemindOption);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);
            return result;
        }
        public static DialogResult Show(string text,string title, RemindMeBoxReason buttons, bool showDontRemindOption = false)
        {
            newMessageBox = new RemindMeBox(text, title,buttons,showDontRemindOption);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);            
            return result;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            cbDontRemind.Checked = !cbDontRemind.Checked;
        }
    }

    public enum RemindMeBoxReason
    {
        /// <summary>
        /// The message box contains a yes and a no button
        /// </summary>
        YesNo,
        /// <summary>
        /// The message box contains a cancel button
        /// </summary>
        OK
    }
   
}
