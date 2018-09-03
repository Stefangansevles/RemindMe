using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class TimerPopup : Form
    {       
        public TimerPopup()
        {            
            InitializeComponent();            
            this.Opacity = 0;            
            tmrFadeIn.Start();

            tbTime.KeyUp += TimerPopup_KeyUp;
            tbNote.KeyUp += TimerPopup_KeyUp;
            this.KeyUp += TimerPopup_KeyUp;
            BLIO.Log("TimerPopup created");
        }

        
        private void TimerPopup_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BLIO.Log("TimerPopup enter pressed");
                UCTimer ucTimer = Form1.Instance.ucTimer;

                BLIO.Log("Parsing number....");
                int tryparse;
                try { tryparse = Convert.ToInt32(tbTime.Text); }
                catch (Exception ex) { return; }
                if (tryparse <= 0)
                    return;
                BLIO.Log("Success. (" + tryparse + ") Creating timespan.");

                TimeSpan time = TimeSpan.FromSeconds(Convert.ToInt32(tbTime.Text) * 60);

                BLIO.Log("Setting values of (UCTimer) numericupdowns");
                ucTimer.numSeconds.Value = Math.Ceiling((decimal)time.Seconds / 60);
                
                ucTimer.numMinutes.Value = Math.Ceiling((decimal)time.Minutes % 60);

                ucTimer.numHours.Value = Math.Ceiling((decimal)time.Hours);

                ucTimer.timerNote = tbNote.Text;

                BLIO.Log("Values set");

                ucTimer.ToggleTimer();

                if(!ucTimer.tmrCountdown.Enabled)
                    ucTimer.ToggleTimer();

                BLIO.Log("Timer started");

                this.Dispose();
            }
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity >= 1)
            {
                tmrFadeIn.Stop();
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
                this.TopLevel = true;
                this.ActiveControl = tbTime;
                this.Activate();
                
            }
        }

        private void TimerPopup_Load(object sender, EventArgs e)
        {           
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.DarkRed;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Transparent;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Dispose();            
        }
    }
}
