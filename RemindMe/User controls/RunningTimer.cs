using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemindMe.Other_classes;

namespace RemindMe
{
    public partial class RunningTimer : UserControl
    {
        //The usercontrol TimerItem
        TimerItem tmr;
        //The time of the running TimerItem
        int seconds, minutes, hours;
        //The time we will display, seperated with : and numbers below 10 will become 2 digits, example: 00:04:33
        string secondText, minuteText, hourText;

        private void btnAddMinute_Click(object sender, EventArgs e)
        {
            tmrTickDownTime.Stop();

            tmr.SecondsRemaining += 60;
            SetTimeRemainingTextLabel();

            tmrTickDownTime.Start();
        }
        private void btnSubtractMinute_Click(object sender, EventArgs e)
        {
            tmrTickDownTime.Stop();

            if (tmr.SecondsRemaining >= 60)
                tmr.SecondsRemaining -= 60;
            else
                tmr.SecondsRemaining = 0;

            SetTimeRemainingTextLabel();

            tmrTickDownTime.Start();
        }
        private void SetTimeRemainingTextLabel()
        {
            TimeSpan time = TimeSpan.FromSeconds((double)tmr.SecondsRemaining);
            seconds = time.Seconds;
            minutes = time.Minutes;
            hours = time.Hours;

            secondText = "" + seconds;
            minuteText = "" + minutes;
            hourText = "" + hours;

            lblTimerTime.Text = TimerText;
        }

        

        /// <summary>
        /// Creates a new RunningTimer usercontrol displaying a currently running timer
        /// </summary>
        /// <param name="tmr">The Timer that will be displayed</param>
        public RunningTimer(TimerItem tmr)
        {
            InitializeComponent();
            this.tmr = tmr;
            lblTimerName.MaximumSize = new Size(162, lblTimerName.Height);
        }

        private void RunningTimer_Load(object sender, EventArgs e)
        {
            lblTimerName.Text = tmr.TimerText;
            if (string.IsNullOrEmpty(lblTimerName.Text))
                lblTimerName.Text = "( No name set )";

            TimeSpan time = TimeSpan.FromSeconds((double)tmr.SecondsRemaining);            

            seconds = time.Seconds;
            minutes = time.Minutes;
            hours = time.Hours;            

            //Text that will show, example: 00:04:33
            secondText = "" + seconds;
            minuteText = "" + minutes;
            hourText = "" + hours;

            lblTimerTime.Text = TimerText;
            tmrTickDownTime.Start();
        }

        private void tmrTickDownTime_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
                seconds--;
            else
            {
                if (minutes > 0)
                {
                    minutes--;
                    minutes = 59;
                }
                else
                {
                    if (hours > 0)
                    {
                        hours--;
                        hours = 59;
                        hours = 59;
                    }//Else probably no time left.

                }
            }
         
            lblTimerTime.Text = TimerText;


            if (seconds == 0 && minutes == 0 && hours == 0)
            {
                tmrTickDownTime.Stop();
                TimerCheck.Instance.PlaceTimers(); //Re-position
            }
        }

        private string TimerText
        {
            get
            {
                if (seconds < 10)
                    secondText = "0" + seconds;
                else
                    secondText = "" + seconds;

                if (minutes < 10)
                    minuteText = "0" + minutes;
                else
                    minuteText = "" + minutes;

                if (hours < 10)
                    hourText = "0" + hours;
                else
                    hourText = "" + hours;


                return hourText + ":" + minuteText + ":" + secondText; ;
            }
        }
    }
}
