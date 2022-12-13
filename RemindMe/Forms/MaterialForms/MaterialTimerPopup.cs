using Business_Logic_Layer;
using MaterialSkin.Controls;
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
    public partial class MaterialTimerPopup : MaterialForm
    {
        //The amount of minutes the timer is going to be set for    
        private int timerMinutes = 0;

        //Only allow one TimerCheck to be open            
        private static MaterialTimerPopup instance = null;

        public MaterialTimerPopup()
        {
            try
            {
                MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(this);

                InitializeComponent();

                instance = this;
                this.Opacity = 0;

                //Set the location within the remindme window. 
                //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
                MaterialForm1 remindme = (MaterialForm1)Application.OpenForms["MaterialForm1"];
                if (remindme != null && remindme.Visible)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
                }
                else
                    this.StartPosition = FormStartPosition.CenterScreen;

                tmrFadeIn.Start();
                tbTime.KeyUp += TimerPopup_KeyUp;
                tbNote.KeyUp += TimerPopup_KeyUp;
                this.KeyUp += TimerPopup_KeyUp;

                tbTime.KeyDown += numericOnly_KeyDown;
                tbTime.KeyPress += numericOnly_KeyPress;

                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;

                this.TopMost = true;
                this.BringToFront();
                this.Focus();
                this.ActiveControl = tbTime;

                if (!this.Focused)
                    this.Activate();

                BLIO.Log("TimerPopup created");
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "Initialization of MaterialTimerPopup failed!");
            }
        }

        private void numericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar.ToString().ToLower() != "h") && (e.KeyChar.ToString().ToLower() != "m"))
                e.Handled = true;
        }
        private void numericOnly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }

        private void TimerPopup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

                        if (tbTime.Text.Length > index + 1)//+1 because .Length starts from 1, index starts from 0
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

                MUCTimer ucTimer = MaterialForm1.Instance.timer;

                BLIO.Log("Setting values of (UCTimer) numericupdowns");

                ucTimer.numSeconds.Text = "" + Math.Ceiling((decimal)time.Seconds / 60);
                ucTimer.numMinutes.Text = "" + Math.Ceiling((decimal)time.Minutes % 60);
                ucTimer.numHours.Text = "" + Math.Ceiling((decimal)time.Hours);
                ucTimer.timerNote = tbNote.Text;

                BLIO.Log("Values set");

                ucTimer.AddTimer(timerMinutes * 60, tbNote.Text);

                //ucTimer.ToggleTimer();

                BLIO.Log("Timer started");


                this.Close();
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
            try
            {
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
                this.TopLevel = true;
                this.BringToFront();
                this.ActiveControl = tbTime;
                tbTime.Focus();
                this.Activate();
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "TimerPopup_Load failed!");
            }
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static MaterialTimerPopup Instance
        {
            get { return instance; }
        }

        private void TimerPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}
