using MaterialSkin;
using MaterialSkin.Controls;
using RemindMe.Other_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MaterialTimerCheck : MaterialForm
    {
        //Only allow one TimerCheck to be open        
        private static MaterialTimerCheck instance = null;
        /// <summary>
        /// Creates a new TimerCheck form displaying all currently running timers
        /// </summary>        
        public MaterialTimerCheck()
        {
            this.StatusBarHeight = 0;
            InitializeComponent();
            this.MaximumSize = new Size(315, 375);
            instance = this;
        }

        private void TimerCheck_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //Will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the it.
            this.TopLevel = true;

            PlaceTimers();

            this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, Screen.GetWorkingArea(this).Height - this.Height - 5);
        }

        public void PlaceTimers()
        {
            pnlTimers.Controls.Clear();

            int counter = 0;
            MaterialRunningTimer rTmr;
            foreach (TimerItem itm in MUCTimer.RunningTimers)
            {
                rTmr = new MaterialRunningTimer(itm);
                rTmr.Location = new Point(4, counter * rTmr.Height + 3);
                pnlTimers.Controls.Add(rTmr);

                counter++;

                if ((counter * rTmr.Height + 3) > pnlTimers.Height)
                {
                    pnlTimers.Height += rTmr.Height + 3;
                    this.Height += rTmr.Height + 3;
                }
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            MaterialSkinManager.Instance.RemoveFormToManage(this);
            instance = null;
        }
        public static MaterialTimerCheck Instance
        {
            get { return instance; }
        }
    }
}
