using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class ErrorPopup : Form
    {
        string message;
        public ErrorPopup(string message)
        {
            InitializeComponent();
            this.message = message;            
           
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void ErrorPopup_Load(object sender, EventArgs e)
        {
            int myLimit = 60;            
            string[] words = message.Split(new char[] { ' ' });
            IList<string> sentenceParts = new List<string>();
            sentenceParts.Add(string.Empty);

            int partCounter = 0;

            foreach (string word in words)
            {
                if ((sentenceParts[partCounter] + word).Length > myLimit)
                {
                    partCounter++;
                    sentenceParts.Add(string.Empty);
                }

                sentenceParts[partCounter] += word + " ";
            }

            foreach (string x in sentenceParts)
                lblErrorMessage.Text += x + "\r\n";

            pbErrorIcon.BringToFront();
            //Make the button look better
            BLFormLogic.removeButtonBorders(btnClose);
            BLFormLogic.removeButtonBorders(btnOpenErrorLog);


            btnClose.Focus();
        }

        

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void btnOpenErrorLog_Click(object sender, EventArgs e)
        {
            Process.Start(Variables.IOVariables.errorLog);
        }
    }
}
