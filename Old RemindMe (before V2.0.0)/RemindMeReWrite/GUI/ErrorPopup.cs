using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class ErrorPopup : Form
    {
        private string message;
        private string description;
        private Exception ex;        
        private bool sentCustomEmail;
        private int allowEmail = -1;        
        public ErrorPopup(string message, Exception ex)
        {
            InitializeComponent();
            this.message = message;
            this.ex = ex;
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


        public ErrorPopup(string message,Exception ex,string description) 
        {
            InitializeComponent();
            this.message = message;
            this.ex = ex;
            this.description = description;
        }
        public ErrorPopup(string message, Exception ex, string description,int allowEmail)
        {
            InitializeComponent();
            this.message = message;
            this.ex = ex;
            this.description = description;
            this.allowEmail = allowEmail;
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

       

      

        private void ErrorPopup_Load(object sender, EventArgs e)
        {
            tbError.Text = message + "\r\n\r\nException type: " + ex.GetType() + "\r\n" + description;
            tbError.Location = lblCouldYouShare.Location;
            tbError.Visible = false;

            pbErrorIcon.BringToFront();

            //Make the button look better
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
            BLFormLogic.RemovebuttonBorders(btnClose);
            BLFormLogic.RemovebuttonBorders(btnSubmit);
        }


        /// <summary>
        /// Enlarges the textbox if the text exceeds the textbox.
        /// </summary>
        private void EnlargeTextbox()
        {
            Font tempFont = tbError.Font;
            int textLength = tbError.Text.Length;
            int textLines = tbError.GetLineFromCharIndex(textLength) + 1;
            int Margin = tbError.Bounds.Height - tbError.ClientSize.Height;
            tbError.Height = (TextRenderer.MeasureText(" ", tempFont).Height * textLines) + Margin + 2;

            while ((tbError.Location.Y + tbError.Height) > (this.Height - btnClose.Height - 10))
            {
                this.Height = this.Height + 10;
            }
            //if (tbError.Height + 62 > this.Height) //let's only enlarge the form, not shrink it.


        }


        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            btnClose_Click_1(sender, e);            
        }

       

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ErrorPopup_SizeChanged(object sender, EventArgs e)
        {
            btnNo.Location = new Point(this.Width - btnNo.Width - 2, this.Height - btnNo.Height - 2);
            btnYes.Location = new Point((btnNo.Location.X - btnYes.Width) - 2, this.Height - btnYes.Height - 2);

            pbShowDetails.Location = new Point(6,this.Height - pbShowDetails.Height - 2);
            lblShowDetails.Location = new Point((pbShowDetails.Location.X + pbShowDetails.Width) + 6, this.Height - lblShowDetails.Height - 2);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            btnNo_Click(sender, e);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            

            pnlSendErrorMessage.Location = lblCouldYouShare.Location;
            pnlSendErrorMessage.Visible = true;

            lblCouldYouShare.Visible = false;

            this.Height = pnlSendErrorMessage.Location.Y + pnlSendErrorMessage.Height + 5;

            btnYes.Visible = false;
            btnNo.Visible = false;
        }

        private void pnlSendErrorMessage_SizeChanged(object sender, EventArgs e)
        {
            /*The panel resized. Lets resize the textbox and re-align the buttons
            btnSubmit.Location = new Point(btnSubmit.Location.X,pnlSendErrorMessage.Height - 37);
            btnClose.Location = new Point( (btnSubmit.Location.X - btnClose.Width) - 1,btnSubmit.Location.Y);

            tbNote.Size = new Size(tbNote.Width,btnClose.Location.Y - tbNote.Location.Y);*/
        }

        private void pbShowDetails_Click(object sender, EventArgs e)
        {
            if (lblShowDetails.Text == "Hide Details")
            {
                lblShowDetails.Text = "Show Details";
                tbError.Visible = false;

                if (!pnlSendErrorMessage.Visible)
                {
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    lblCouldYouShare.Visible = true;

                    this.Height = 180;                    
                }
                else
                {
                    btnYes.Visible = false;
                    btnNo.Visible = false;
                    lblCouldYouShare.Visible = false;
                    this.Height = pnlSendErrorMessage.Location.Y + pnlSendErrorMessage.Height + 5;
                }
                pbShowDetails.BackgroundImage = Properties.Resources._2arrows;
            }
            else
            {
                
                tbError.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;

                if (pnlSendErrorMessage.Visible)
                {//Place the textbox under the panel if the panel to leave a message is  visible
                    tbError.Location = new Point(tbError.Location.X, (pnlSendErrorMessage.Location.Y + pnlSendErrorMessage.Height) + 5);                                        
                }
                else
                {                    
                    tbError.Location = lblCouldYouShare.Location;
                }

                lblCouldYouShare.Visible = false;
                EnlargeTextbox();
                
                lblShowDetails.Text = "Hide Details";
                pbShowDetails.BackgroundImage = Properties.Resources._2ArrowsUp;
            }

                                             
        }

        private void tbError_Enter(object sender, EventArgs e)
        {
            pbShowDetails.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string textBoxText = tbNote.Text; //Cant access tbNote in a thread. save the text in a variable instead
                Thread sendMailThread = new Thread(() => BLEmail.SendEmail("[CUSTOM] | Error Report: " + ex.GetType().ToString(), "[CUSTOM USER INPUT]\r\n" + textBoxText + "\r\n\r\n---------------Default below--------------------\r\nOops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString()));
                sendMailThread.Start();
            }
            catch { }


            //Set this boolean to true so that when this popup closes, we won't try to send another e-mail
            sentCustomEmail = true;
            btnClose_Click_1(sender, e);
        }

        private void ErrorPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //!sendCustomEmail = If the user has not given a description of the exception and sent it.
            //allowEmail determines if we are allowed to send an e-mail(it's only allowed once every 30 seconds to prevent spam)
            if (!sentCustomEmail && allowEmail == 1)
            {
                try
                {
                    
                    Thread sendMailThread = new Thread(() => BLEmail.SendEmail("Error Report: " + ex.GetType().ToString(), "Oops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString()));
                    sendMailThread.Start();
                }
                catch{ }
            }
        }
    }
}
