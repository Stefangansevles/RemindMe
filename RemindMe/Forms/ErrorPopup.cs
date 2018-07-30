using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private bool sentCustomEmail;
        private bool allowEmail = false;
        public ErrorPopup(string message,Exception ex, bool allowEmail = true)
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
            this.allowEmail = allowEmail;

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
            //!sendCustomEmail = If the user has not given a description of the exception and sent it.
            //allowEmail determines if we are allowed to send an e-mail(it's only allowed once every 30 seconds to prevent spam)
            if (!sentCustomEmail && allowEmail)
            {
                try
                {
                    string mess = "Oops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString();

                    if(ex is ReminderException)
                    {
                        ReminderException theException = (ReminderException)ex;
                        theException.Reminder.Note = "Removed for privacy reasons";
                        theException.Reminder.Name = "Removed for privacy reasons";

                        mess += "\r\n\r\nThis exception is an ReminderException! Let's see if we can figure out what's wrong with it....\r\n";
                        mess += "ID:    " + theException.Reminder.Id + "\r\n";
                        mess += "Deleted:    " + theException.Reminder.Deleted + "\r\n";
                        mess += "Date:  " + theException.Reminder.Date + "\r\n";
                        mess += "RepeatType:    " + theException.Reminder.RepeatType + "\r\n";
                        mess += "Enabled:   " + theException.Reminder.Enabled + "\r\n";
                        mess += "DayOfMonth:    " + theException.Reminder.DayOfMonth + "\r\n";
                        mess += "EveryXCustom:  " + theException.Reminder.EveryXCustom + "\r\n";
                        mess += "RepeatDays:    " + theException.Reminder.RepeatDays + "\r\n";
                        mess += "SoundFilePath: " + theException.Reminder.SoundFilePath + "\r\n";
                        mess += "PostponeDate:  " + theException.Reminder.PostponeDate + "\r\n";
                        mess += "Hide:  " + theException.Reminder.Hide + "\r\n";

                    }

                    Thread sendMailThread = new Thread(() => BLEmail.SendEmail("Error Report: " + ex.GetType().ToString(), mess));
                    sendMailThread.Start();
                }
                catch { }
            }
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
                string customMess = "[CUSTOM USER INPUT]\r\n" + textBoxText + "\r\n\r\n---------------Default below--------------------\r\nOops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString();

                if (ex is ReminderException)
                {
                    ReminderException theException = (ReminderException)ex;
                    theException.Reminder.Note = "Removed for privacy reasons";
                    theException.Reminder.Name = "Removed for privacy reasons";

                    customMess += "\r\n\r\nThis exception is an ReminderException! Let's see if we can figure out what's wrong with it....\r\n";
                    customMess += "ID:    " + theException.Reminder.Id + "\r\n";
                    customMess += "Deleted:    " + theException.Reminder.Deleted + "\r\n";
                    customMess += "Date:  " + theException.Reminder.Date + "\r\n";
                    customMess += "RepeatType:    " + theException.Reminder.RepeatType + "\r\n";
                    customMess += "Enabled:   " + theException.Reminder.Enabled + "\r\n";
                    customMess += "DayOfMonth:    " + theException.Reminder.DayOfMonth + "\r\n";
                    customMess += "EveryXCustom:  " + theException.Reminder.EveryXCustom + "\r\n";
                    customMess += "RepeatDays:    " + theException.Reminder.RepeatDays + "\r\n";
                    customMess += "SoundFilePath: " + theException.Reminder.SoundFilePath + "\r\n";
                    customMess += "PostponeDate:  " + theException.Reminder.PostponeDate + "\r\n";
                    customMess += "Hide:  " + theException.Reminder.Hide + "\r\n";

                }

                Thread sendMailThread = new Thread(() => BLEmail.SendEmail("[CUSTOM] | Error Report: " + ex.GetType().ToString(), customMess));
                sendMailThread.Start();
                MessageFormManager.MakeMessagePopup("Feedback sent.\r\nThank you for taking the time!", 5);
                this.Dispose();
            }
            catch { }


            //Set this boolean to true so that when this popup closes, we won't try to send another e-mail
            sentCustomEmail = true;
        }
    }
}

