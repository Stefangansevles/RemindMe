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
using System.IO;

namespace RemindMe
{
    public partial class UCSupport : UserControl
    {                
        public UCSupport()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //Don't do anything without internet
                if (!BLIO.HasInternetAccess())
                {
                    MessageFormManager.MakeMessagePopup("You do not currently have an active internet connection", 3);
                    return;
                }

                string email = tbEmail.Text;
                string subject = tbSubject.Text;
                string note = tbNote.Text;

                BLOnlineDatabase.InsertEmailAttempt(File.ReadAllText(IOVariables.uniqueString), note, subject, email);
            }
            catch (Exception ex)
            {
                MessageFormManager.MakeMessagePopup("Something went wrong. Could not send the e-mail",3);
            }
        }      
    }
}
