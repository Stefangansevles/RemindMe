using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using System.Threading;

namespace RemindMe
{
    public partial class UCSendMail : UserControl
    {
        private UCSendMailInfo ucSendMailInfo;
        private Thread sendMailThread = null;
        private Exception sendMailException; //Will be null if the mail was succesfull
        private int timeout = 20;
        private int secondsPassed = 0;
        public UCSendMail()
        {
            InitializeComponent();
            BLFormLogic.RemovebuttonBorders(btnConfirm);
        }
       

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbConfirm.Checked && tbSubject.Text != "" && tbMessage.Text != "")
                {
                    lblCouldNotSendMail.Text = "Sending mail...";
                    lblCouldNotSendMail.Visible = true;
                    btnConfirm.Enabled = false;




                    // TimeSpan timeout = TimeSpan.FromSeconds(5);
                    sendMailThread = new Thread(() => sendMailException = BLEmail.SendEmail(tbSubject.Text, tbMessage.Text));
                    sendMailThread.Start();
                    tmrSendMail.Start();
                }
            }
            catch(Exception ex)
            {
                lblCouldNotSendMail.Text = "Something went wrong";
            }
        }

        private void tmrSendMail_Tick(object sender, EventArgs e)
        {            
            if (sendMailThread.IsAlive)
            {
                if (secondsPassed >= timeout)
                {
                    sendMailThread.Abort();
                    btnConfirm.Enabled = true;
                    lblCouldNotSendMail.Text = "Could not send the e-mail from your connection.";
                    tmrSendMail.Stop();
                    secondsPassed = 0;
                }
            }
            else
            {
                tmrSendMail.Stop();
                if (sendMailException == null)
                {
                    Panel parentPanel = (Panel)this.Parent;
                    if (parentPanel != null) //parentPanel can be null if the user switches panels while the sendmail thread is alive.
                    {
                        lblCouldNotSendMail.Visible = false;
                        //Take the user back to the info panel
                        ucSendMailInfo = new UCSendMailInfo();
                        
                        parentPanel.Controls.Clear();
                        parentPanel.Controls.Add(ucSendMailInfo);
                    }

                    Form1 mainForm = (Form1)Application.OpenForms["Form1"];
                    mainForm.StartMailTimer();
                }
                else
                {                                                         
                    lblCouldNotSendMail.Text = "Could not send the e-mail :(";     //No clue what happened                                

                    secondsPassed = 0;
                    btnConfirm.Enabled = true;
                }

            }
            
            secondsPassed++;
        }
    }
}
