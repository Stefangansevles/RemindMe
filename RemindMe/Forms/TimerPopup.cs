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
        //The amount of minutes the timer is going to be set for    
        private int timerMinutes = 0;


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
                timerMinutes = 0;
                lblErrorText.Visible = false;

               

                try
                {
                    //the "m" part of the input is unnecesary. If the input is 2h15m, 
                    //then 2h15 would produce the same output. 15m would also be the same as 15, since there is no 'h' present.
                    tbTime.Text = tbTime.Text.ToLower().Replace("m", "");

                    if (tbTime.Text.ToLower().Contains('h'))
                    {
                        BLIO.Log("timer popup contains 'h'. Checking what's before it");
                        
                        //Get the index number of the 'h' in the text
                        int index = tbTime.Text.ToLower().IndexOf('h');

                        //Now get all the text before it(should be a numer) and multiply by 60 because the user input hours
                        BLIO.Log("Parsing hours....");
                        timerMinutes += Convert.ToInt32(tbTime.Text.Substring(0, index)) * 60;

                        //Now get the number after the 'h' , which should be minutes, and add it to timerMinutes
                        //But, first check if there is actually something after the 'h'

                        if (tbTime.Text.Length > index+1)//+1 because .Length starts from 1, index starts from 0
                        {
                            BLIO.Log("Parsing minutes....");
                            timerMinutes += Convert.ToInt32(tbTime.Text.Substring(index + 1, tbTime.Text.Length - (index + 1)));
                        }
                    }
                    else                    
                        timerMinutes = Convert.ToInt32(tbTime.Text);

                    if (timerMinutes <= 0)
                    {
                        lblErrorText.Visible = true;
                        lblErrorText.Text = "Invalid input time";
                        return;
                    }
                }
                catch
                {
                    lblErrorText.Visible = true;
                    lblErrorText.Text = "Invalid input";
                    return;
                }

                                
                
                BLIO.Log("Success. (" + timerMinutes + "minutes ) Creating timespan.");
                
                TimeSpan time = TimeSpan.FromMinutes(timerMinutes);

                UCTimer ucTimer = Form1.Instance.ucTimer;

                BLIO.Log("Setting values of (UCTimer) numericupdowns");

                ucTimer.numSeconds.Value = Math.Ceiling((decimal)time.Seconds / 60);                
                ucTimer.numMinutes.Value = Math.Ceiling((decimal)time.Minutes % 60);
                ucTimer.numHours.Value = Math.Ceiling((decimal)time.Hours);
                ucTimer.timerNote = tbNote.Text;

                BLIO.Log("Values set");
                
                ucTimer.AddTimer(timerMinutes*60, tbNote.Text);

                //ucTimer.ToggleTimer();
                
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
            }
            this.BringToFront();                        
            this.Activate();
        }

        private void TimerPopup_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            this.TopLevel = true;
            this.BringToFront();
            this.ActiveControl = tbTime;
            tbTime.Focus();
            this.Activate();            
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
