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
        UCSendMailInfo ucSendMailInfo;
        Thread sendMailThread = null;
        int timeout = 5;
        int secondsPassed = 0;
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
                    sendMailThread = new Thread(() => BLEmail.SendEmail(tbSubject.Text, tbMessage.Text));
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
                    lblCouldNotSendMail.Text = "Could not send e-mail from your connection.";
                    tmrSendMail.Stop();
                    secondsPassed = 0;
                }
            }
            else
            {
                tmrSendMail.Stop();

                lblCouldNotSendMail.Visible = false;
                //Take the user back to the info panel
                ucSendMailInfo = new UCSendMailInfo();
                Panel parentPanel = (Panel)this.Parent;
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(ucSendMailInfo);

                Form1 mainForm = (Form1)Application.OpenForms["Form1"];
                mainForm.StartMailTimer();

            }
            
            secondsPassed++;
        }
    }
}
