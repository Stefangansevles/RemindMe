using Business_Logic_Layer;
using Database.Entity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe.Other_classes
{
    public class TimerItem : IDisposable
    {
        // Flag: Has Dispose already been called?
        private bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        
        //The timer
        private Timer timer;
        //The text that should display when the timer pops up
        private string timerText;

        //TimerItem may only edit the running clock if the user selected this button.
        //Without this, all running timers would constantly alter the clock and it would be a mess
        public bool updateAllowed;

        //The timer instance of UCTimer
        UCTimer ucTimer = Form1.Instance.ucTimer;

        //Unique id to identify timers
        private int id;

        //The date this timer is set for
        private DateTime popupDate;

        //If the timer is being paused, record the time. Then, when the timer is being started again, add the difference to popupDate
        private TimeSpan pauseDate;

        private int pauseSeconds, pauseMinutes, pauseHours;

        /// <summary>
        /// Create a new TimerItem to create multiple running timers.
        /// </summary>
        public TimerItem(DateTime popupDate,string text, int id)
        {
            this.popupDate = popupDate;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            this.timerText = text;
            this.id = id;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {            
            if(popupDate <= DateTime.Now)//Let's make the popup
            {
                BLIO.Log("Creating timer popup...");

                timer.Stop();

                Reminder rem = new Reminder();
                rem.Date = popupDate.ToShortDateString() + " " + popupDate.ToShortTimeString();
                rem.RepeatType = ReminderRepeatType.NONE.ToString();
                rem.Id = -1; //Set it to our "Invalid id" number. It is not a real reminder after all.
                rem.Name = "Timer";
                rem.Note = timerText;

                Settings set = BLLocalDatabase.Setting.Settings;
                rem.SoundFilePath = set.DefaultTimerSound;

                Popup pop = new Popup(rem);
                pop.Show();

                //Let's remove this timer. It's served its purpose
                ucTimer.RemoveTimer(this);
                
                this.Dispose();
            }
        }
        //Read-only ID
        public int ID
        {
            get { BLIO.Log("GET TimerItem.ID ("+id+")");  return id; }
        }
        //Read-only seconds left
        public int SecondsRemaining
        {
            get
            {
                if (pauseDate.Seconds == 0)
                    return ((popupDate - DateTime.Now).Hours * 60 * 60) + (popupDate - DateTime.Now).Minutes * 60 + (popupDate - DateTime.Now).Seconds;
                else                                  
                    return (pauseHours * 60 * 60) + (pauseMinutes * 60) + pauseSeconds;
            }
            set { popupDate = DateTime.Now.AddSeconds(value); }
        }      
        /// <summary>
        /// Determines if the timer is currently running
        /// </summary>
        /// <returns></returns>
        public bool Running
        {
            get { BLIO.Log("GET TimerItem.Running ("+timer.Enabled+")"); return timer.Enabled; }
            
        }
        /// <summary>
        /// Start the timer
        /// </summary>
        public void StartTimer()
        {
            timer.Start();

            //If the pausedate is set, add time to the popupdate.
            if(pauseDate.Seconds > 1)
                popupDate = popupDate.Add(DateTime.Now.TimeOfDay - pauseDate);

            pauseDate = new TimeSpan();
            pauseSeconds = 0;
            pauseMinutes = 0;
            pauseHours = 0;
            

            if (updateAllowed)
            {
                ucTimer.timerDuration = (popupDate-DateTime.Now).Seconds;
                if (!ucTimer.tmrCountdown.Enabled)
                    ucTimer.tmrCountdown.Start();
            }
        }
        /// <summary>
        /// Stop the timer
        /// </summary>
        public void StopTimer(int seconds, int minutes, int hours)
        {
            timer.Stop();

            pauseDate = DateTime.Now.TimeOfDay;

            pauseSeconds = seconds;
            pauseMinutes = minutes;
            pauseHours = hours;

            if (updateAllowed)
            {
                ucTimer.timerDuration = (popupDate - DateTime.Now).Seconds;
                if (ucTimer.tmrCountdown.Enabled)
                    ucTimer.tmrCountdown.Stop();
            }
        }

        /// <summary>
        /// Gets or sets the timer text
        /// </summary>
        public string TimerText
        {
            get { return timerText; }
            set { timerText = value; }
        }

        public DateTime PopupDate
        {
            get { return popupDate; }
        }


        //== Custom dispose code below == 

        /// <summary>
        /// Determines wether this TimerItem is disposed. Readonly
        /// </summary>
        public bool Disposed
        {            
            get { return disposed; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                timer.Dispose();
                ucTimer = null;
            }

            disposed = true;
        }
    }
}
