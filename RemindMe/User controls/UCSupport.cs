using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Business_Logic_Layer;
using System.Net.Mail;

namespace RemindMe
{
    public partial class UCSupport : UserControl
    {        
        private Thread sendMailThread = null;
        private Exception sendMailException; //Will be null if the mail was succesfull
        private int timeout = 20;
        private int secondsPassed = 0;
        public UCSupport()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string subject = tbSubject.Text;
                string note = tbNote.Text;

                if (tmrAllowMail.Enabled)
                {
                    RemindMeBox.Show("You have recently sent an e-mail. Wait a bit before you do it again!");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(subject) && !string.IsNullOrWhiteSpace(note))
                {
                   
                    lblSending.Visible = true;
                    pbSending.Visible = true;                
                    btnSend.Enabled = false;




                    // TimeSpan timeout = TimeSpan.FromSeconds(5);
                    if (string.IsNullOrWhiteSpace(email))
                        sendMailThread = new Thread(() => sendMailException = BLEmail.SendEmail(subject, note,false));
                    else
                    {
                        try
                        {
                            MailMessage mes = new MailMessage(email, "remindmehelp@gmail.com", subject, note);
                            sendMailThread = new Thread(() => sendMailException = BLEmail.SendEmail(subject, note, email,false));                            
                        }
                        catch (FormatException ex)
                        {                            
                            btnSend.Enabled = true;
                            lblSending.Visible = false;
                            pbSending.Visible = false;
                            RemindMeBox.Show("Please enter a valid e-mail address, or leave it empty");
                        }
                        
                    }

                    if (sendMailThread != null)
                    {
                        sendMailThread.Start();
                        tmrSendMail.Start();
                        tbEmail.ResetText();
                        tbNote.ResetText();
                        tbSubject.ResetText();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageFormManager.MakeMessagePopup("Something went wrong. Could not send the e-mail",3);
            }
        }

        private void tmrSendMail_Tick(object sender, EventArgs e)
        {
            if (sendMailThread.IsAlive)
            {
                if (secondsPassed >= timeout)
                {
                    sendMailThread.Abort();
                    btnSend.Enabled = true;
                    pbSending.Visible = false;
                    lblSending.Visible = false;
                    MessageFormManager.MakeMessagePopup("Could not send the e-mail from your connection.", 5);                    
                    tmrSendMail.Stop();
                    secondsPassed = 0;
                }
            }
            else
            {
                lblSending.Visible = false;
                pbSending.Visible = false;
                tmrSendMail.Stop();
                if (sendMailException == null)
                {                   
                    tmrAllowMail.Start();
                    sendMailThread = null;
                    MessageFormManager.MakeMessagePopup("E-mail Sent. Thank you!", 5);
                }
                else
                {
                    if (sendMailException is FormatException)
                        RemindMeBox.Show("Please enter a valid e-mail address, or leave it empty");
                    else
                        MessageFormManager.MakeMessagePopup("Could not send the e-mail :(", 3);     //No clue what happened                                

                    secondsPassed = 0;
                    btnSend.Enabled = true;
                }
            }
            secondsPassed++;
        }

        private void tmrAllowMail_Tick(object sender, EventArgs e)
        {
            tmrAllowMail.Stop();
            btnSend.Enabled = true;
        }
    }
}
