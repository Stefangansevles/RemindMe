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


        //The duration of this timer in seconds
        private int secondsTillPop = 0;
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

        /// <summary>
        /// Create a new TimerItem to create multiple running timers.
        /// </summary>
        public TimerItem(int seconds,string text, int id)
        {
            this.secondsTillPop = seconds;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            this.timerText = text;
            this.id = id;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsTillPop--;

            if(secondsTillPop <= 0)//Let's make the popup
            {
                timer.Stop();

                Reminder rem = new Reminder();
                rem.Id = -1; //Set it to our "Invalid id" number. It is not a real reminder after all.
                rem.Name = "Timer";
                rem.Note = timerText;

                Settings set = BLSettings.GetSettings();
                rem.SoundFilePath = set.DefaultTimerSound;

                Popup pop = new Popup(rem);
                pop.Show();

                //Let's remove this timer. It's served its purpose
                ucTimer.RemoveTimer(this);
            }
        }
        //Read-only ID
        public int ID
        {
            get { return id; }
        }
        //Read-only seconds left
        public int SecondsRemaining
        {
            get { return secondsTillPop; }
            set { secondsTillPop = value; }
        }      
        /// <summary>
        /// Determines if the timer is currently running
        /// </summary>
        /// <returns></returns>
        public bool IsRunning()
        {
            return timer.Enabled;
        }
        /// <summary>
        /// Start the timer
        /// </summary>
        public void StartTimer()
        {
            timer.Start();

            if (updateAllowed)
            {
                ucTimer.timerDuration = secondsTillPop;
                if (!ucTimer.tmrCountdown.Enabled)
                    ucTimer.tmrCountdown.Start();
            }
        }
        /// <summary>
        /// Stop the timer
        /// </summary>
        public void StopTimer()
        {
            timer.Stop();


            if (updateAllowed)
            {
                ucTimer.timerDuration = secondsTillPop;
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

        /// <summary>
        /// Deletes this object by removing all the data from in
        /// </summary>
        public void Delete()
        {
            timer.Stop();
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
