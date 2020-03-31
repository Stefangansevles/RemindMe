using Business_Logic_Layer;
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
    public partial class ExceptionPopup : Form
    {        
        private Exception exception;
        private bool customFeedback;
        private static int activePopups = 0;
        public ExceptionPopup(Exception ex, string message = null)
        {
            activePopups++;
            if (activePopups < 3)
            {
                BLIO.Log("Constructing ExceptionPopup ( " + ex.GetType().ToString() + " )");
                InitializeComponent();

                this.exception = ex;

                //Set the location within the remindme window. 
                //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
                Form1 remindme = (Form1)Application.OpenForms["Form1"];
                if (remindme != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
                }

                if (!string.IsNullOrWhiteSpace(message))
                    lblMessage.Text = "Problem description: " + message;

                tbDummy.Focus();
                this.Click += FocusDummy;
                pnlMainGradient.Click += FocusDummy;
                pnlFooterButtons.Click += FocusDummy;
                lblText.Click += FocusDummy;
                lblMessage.Click += FocusDummy;
                lblTitle.Click += FocusDummy;
                
                BLIO.Log("Constructing ExceptionPopup complete");
            }
            else
            {
                //There are 2 active popups already. Do not show another one! 
                
                this.Opacity = 0;
                this.ShowInTaskbar = false;

                InitializeComponent(); //so we can call the timer that disposes this form. Closing/disposing from the constructor is not possible

                BLIO.Log("IGNORE Popup(" + ex.GetType().ToString() + "). " + activePopups + " Popups active!");                                
            }
        }

        private void SetUpdateText()
        {
            if (RemindMeUpdater.GetGithubVersion() > new Version(IOVariables.RemindMeVersion))
            {
                //The user is not up-to-date.
                lblLatestVersion.Text += "\r\nYou are not running the latest version of RemindMe ( " + RemindMeUpdater.GetGithubVersion().ToString() + " )";
            }
            else
                lblLatestVersion.Text += "\r\nYou are already running the latest version of RemindMe.";
            
            pictureBox1.Location = new Point(16, 30);

            lblLatestVersion.Location = new Point(lblLatestVersion.Location.X, lblLatestVersion.Location.Y -10);
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y -10);
        }

        private void ExceptionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string logTxtPath = IOVariables.systemLog;
                BLIO.Log("Closing ExceptionPopup...");
                if (!customFeedback) //If the user didn't leave instructions of how this problem happened, just log the exception / stacktrace and logfile
                    BLOnlineDatabase.AddException(exception, DateTime.UtcNow, logTxtPath);
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("btnOk pressed on ExceptionPopup. textbox text = " + tbFeedback.Text);
                string logTxtPath = IOVariables.systemLog;
                string textBoxText = tbFeedback.Text; //Cant access tbNote in a thread. save the text in a variable instead

                if (string.IsNullOrWhiteSpace(textBoxText) || tbFeedback.ForeColor == Color.Gray)
                    textBoxText = null;
                
                BLOnlineDatabase.AddException(exception, DateTime.UtcNow, logTxtPath, textBoxText);

                if(textBoxText != null && tbFeedback.ForeColor != Color.Gray)
                    RemindMeMessageFormManager.MakeMessagePopup("Feedback sent.\r\nThank you for taking the time!", 5);

                //Set this boolean to true so that when this popup closes, we won't try to add another db entry
                customFeedback = true;
                btnOk.Enabled = false;

                this.Close();
                this.Dispose();
            }
            catch { }                        
        }

        /// <summary>
        /// Give focus to a control off-screen so the textbox won't be in input mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusDummy(object sender, EventArgs e)
        {
            tbDummy.Focus();
        }
        private void tbFeedback_Leave(object sender, EventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(tbFeedback.Text))
            {
                tbFeedback.Text = "If you can, please describe how this happened here...";
                tbFeedback.ForeColor = Color.Gray;
            }
        }

        private void tbFeedback_Enter(object sender, EventArgs e)
        {            
            if (tbFeedback.ForeColor == Color.Gray & tbFeedback.Text == "If you can, please describe how this happened here...")
            {
                tbFeedback.Text = "";
                tbFeedback.ForeColor = Color.White;
            }
        }

        private void ExceptionPopup_Load(object sender, EventArgs e)
        {
            tmrCheckForVersion.Start();

            if(activePopups > 2)
            {
                BLIO.Log("[ExceptionPopup " + activePopups + "] ExceptionPopup_Load   closing form...");
                this.Close();
            }

            tbDummy.Focus();
        }

        private void tbFeedback_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                tbDummy.Focus();
        }

        private void ExceptionPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            activePopups--;
        }

        private void tmrDispose_Tick(object sender, EventArgs e)
        {
            
        }

        private void tmrCheckForVersion_Tick(object sender, EventArgs e)
        {
            SetUpdateText();
            tmrCheckForVersion.Stop();
        }
    }
}
