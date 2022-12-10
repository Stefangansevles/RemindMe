﻿using System;
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
using Database.Entity;

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
            BLIO.Log("(UCSupport)btnSend_Click");
            try
            {
                BLIO.Log("Attempting to send a message to the RemindMe developer..");

                //Don't do anything if there's no text
                if (string.IsNullOrWhiteSpace(tbNote.Text) || tbNote.Text == "Type your message here...")
                    return;

                //Don't do anything without internet
                if (!BLIO.HasInternetAccess())
                {
                    RemindMeMessageFormManager.MakeMessagePopup("You do not currently have an active internet connection", 3);
                    return;
                }

                string email = tbEmail.Text;
                string subject = tbSubject.Text;
                string note = tbNote.Text;
                
                RemindMeMessageFormManager.MakeMessagePopup("online_database_removed", 5);
                tbEmail.Text = "";
                tbSubject.Text = "";
                tbNote.Text = "";
                label3.Focus();
                BLIO.Log("Message sent!");
            }
            catch (Exception ex)
            {
                BLIO.Log("Error in UCSUpport.btnSend_Click. Could not send the message! Exception type: " + ex.GetType().ToString() + "   Stacktrace:\r\n" + ex.StackTrace);
                RemindMeMessageFormManager.MakeMessagePopup("Something went wrong. Could not send the e-mail",3);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCSupport)btnBack_Click");
            pnlMessageOverview.Location = new Point(0, 0);
            pnlSendMessages.Location = new Point(667, 0);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCSupport)bunifuFlatButton2_Click [btnSendMessage]");
            pnlSendMessages.Location = new Point(0, 0);
            pnlMessageOverview.Location = new Point(667, 0);
        }

        private void UCSupport_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                BLIO.Log("Control UCSupport now visible");

                lvMessages.Items.Clear();

                ListViewItem itm;
                foreach (ReadMessages mes in BLLocalDatabase.ReadMessage.Messages) //Thread? maybe?
                {
                    itm = new ListViewItem(mes.MessageText);
                    itm.Tag = mes.ReadMessageId;
                    lvMessages.Items.Add(itm);
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCSupport)bunifuFlatButton1_Click [btnView]");
        }

        private void tbSubject_Enter(object sender, EventArgs e)
        {
            tbSubject.LineIdleColor = Color.Silver;
            tbSubject.HintForeColor = Color.White;
        }

        private void tbSubject_Leave(object sender, EventArgs e)
        {
            tbSubject.HintForeColor = Color.DarkGray;
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            tbEmail.LineIdleColor = Color.Silver;
            tbEmail.HintForeColor = Color.White;
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            tbEmail.HintForeColor = Color.DarkGray;
        }

        private void tbNote_Enter(object sender, EventArgs e)
        {
            tbNote.ForeColor = Color.White;

            if (tbNote.Text == "Type your message here...")
                tbNote.Text = "";
        }

        private void tbNote_Leave(object sender, EventArgs e)
        {
            if (tbNote.Text == "")
            {
                tbNote.ForeColor = Color.Silver;
                tbNote.Text = "Type your message here...";
            }
        }
    }
}
