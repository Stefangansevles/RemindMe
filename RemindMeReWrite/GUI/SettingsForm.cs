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
    public partial class SettingsForm : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            //Make RemindMe draggable from the top
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        UCMusic music;
        UCWindows windows;
        public SettingsForm()
        {
            
            InitializeComponent();
            music = new UCMusic();
            windows = new UCWindows();
            this.ShowIcon = true;            
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            pbLogo.BringToFront();

            //When the user loads the settings, the music tab will load by default
            pnlParent.Controls.Clear();
            pnlParent.Controls.Add(music);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pbMusic_Click(object sender, EventArgs e)
        {
            pnlParent.Controls.Clear();
            pnlParent.Controls.Add(music);
        }

        private void pbWindows_Click(object sender, EventArgs e)
        {
            pnlParent.Controls.Clear();
            pnlParent.Controls.Add(windows);
        }
    }
}
