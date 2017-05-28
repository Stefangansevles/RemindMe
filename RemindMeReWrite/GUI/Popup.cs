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
            if (DLSettings.IsAlwaysOnTop())
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            else
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;             
            }

            //Show the reminder note
            tbText.Text = rem.Note.Replace("\\n", Environment.NewLine);

            //Show what date this reminder was set for
            lblDate.Text = "This reminder was set for " + rem.Date;

            lblTitle.Text = rem.Name;


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
