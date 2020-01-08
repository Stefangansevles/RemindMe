using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class ErrorPopup : Form
    {
        private string message;        
        private Exception ex;
        private bool customFeedback;        
        public ErrorPopup(string message,Exception ex)
        {
            BLIO.Log("Constructing ErrorPopup (" + ex.GetType().ToString() + ")");
            InitializeComponent();
            

            lblText.MaximumSize = new Size((pnlMainGradient.Width - lblText.Location.X) - 10, 0);
            lblTitle.MaximumSize = new Size((pnlMainGradient.Width - lblTitle.Location.X) - 10, 0);

            //Set the location within the remindme window. 
            //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }

            this.ex = ex;
            this.message = message;
            lblText.Text = message + "\r\nCould you report how this happened?";            

            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;

            BLIO.Log("Constructing ErrorPopup complete");
        }
        

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if(File.Exists(IOVariables.errorLog))
                Process.Start(IOVariables.errorLog);
        }




        private void ErrorPopup_FormClosing(object sender, FormClosingEventArgs e)
        {            
            try
            {                
                if(!customFeedback)
                    BLOnlineDatabase.AddException(ex, DateTime.UtcNow, BLIO.GetLogTxtPath());
            }
            catch { }

        }

      

        private void btnYes_Click(object sender, EventArgs e)
        {
            pnlFooterButtons.Controls.Clear();
            pnlSubmitFeedback.Visible = true;
            pnlFooterButtons.Controls.Add(pnlSubmitFeedback);
            pnlSubmitFeedback.Dock = DockStyle.Fill;
            pnlFooterButtons.Size = pnlSubmitFeedback.Size;
            /*pnlSubmitFeedback.Visible = true;
            pnlSubmitFeedback.Dock = DockStyle.Bottom;*/
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string textBoxText = tbNote.Text; //Cant access tbNote in a thread. save the text in a variable instead

                if (string.IsNullOrWhiteSpace(textBoxText))
                    textBoxText = null;

                RemindMeMessageFormManager.MakeMessagePopup("Feedback sent.\r\nThank you for taking the time!", 5);
                BLOnlineDatabase.AddException(ex, DateTime.UtcNow, BLIO.GetLogTxtPath(), textBoxText);
                this.Dispose();
            }
            catch { }


            //Set this boolean to true so that when this popup closes, we won't try to send another e-mail
            customFeedback = true;
        }
    }
}

