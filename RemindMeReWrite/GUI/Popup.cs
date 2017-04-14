using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class Popup : Form
    {
        private Reminder rem;
        public Popup(Reminder rem)
        {
            InitializeComponent();
            this.rem = rem;
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

        private void pbClosePopup_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            if (BLIO.ReadAlwaysOnTop())
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            else
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;             
            }

            //Show the reminder note
            tbText.Text = rem.Note.Replace("\\n", Environment.NewLine);

            //Show what date this reminder was set for
            lblDate.Text = "This reminder was set for " + rem.CompleteDate.ToString();


            #region add line breaks when the title becomes too long
            int myLimit = 30;
            string[] words = rem.Name.Split(new char[] { ' ' });
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
           


            lblTitle.Text = "";
            foreach (string x in sentenceParts)
                lblTitle.Text += x + "\r\n";

            #endregion


            //Make the button look better
            btnOk.TabStop = false;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;

            btnOk.Focus();
        }

        private void pbMinimizePopup_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;            
        }
    }
}
