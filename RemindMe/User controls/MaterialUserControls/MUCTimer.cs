using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.IO;
using RemindMe.Other_classes;
using Bunifu.Framework.UI;
using System.Threading;
using MaterialSkin.Controls;

namespace RemindMe
{
    public partial class MUCTimer : UserControl
    {
        private static List<TimerItem> timers = new List<TimerItem>();
        public decimal timerDuration = 0;
        public string timerNote = "";

        //Contains the TimerItem the user is currently viewing/editing. This should change if the user clicks one of the timer buttons(if there are multiple timers)
        private TimerItem currentTimerItem;

        private int timerIdCounter = 1;
        public MUCTimer()
        {
            InitializeComponent();

            btnPauseResumeTimer.Icon = Properties.Resources.pause_2x1;

            //Link events to the global event
            btnPlusHours.Click += numericUpDown_ValueChange;
            btnPlusMinutes.Click += numericUpDown_ValueChange;
            btnPlusSeconds.Click += numericUpDown_ValueChange;

            btnMinHours.Click += numericUpDown_ValueChange;
            btnMinMinutes.Click += numericUpDown_ValueChange;
            btnMinSeconds.Click += numericUpDown_ValueChange;

            //The user can change the time of an timer with these numeric up-downs. When the user attempts to do that, link the event to the global numericUpDown_ValueChange
            numSeconds.KeyUp += numericUpDown_ValueChange;
            numMinutes.KeyUp += numericUpDown_ValueChange;
            numHours.KeyUp += numericUpDown_ValueChange;
            


            //Don't allow typing characters in the numeric textbox
            numHours.KeyPress += num_KeyPress;
            numHours.KeyDown += num_KeyDown;

            numMinutes.KeyPress += num_KeyPress;
            numMinutes.KeyDown += num_KeyDown;

            numSeconds.KeyPress += num_KeyPress;
            numSeconds.KeyDown += num_KeyDown;
        }

        private void SubtractSecond(MaterialTextBox tb)
        {
            if (pnlRunningTimers.Controls.Count > 1 && tb.Text != "0")
            {
                int value = Convert.ToInt32(tb.Text);
                value--;
                tb.Text = "" + value;
            }
        }


        private void btnMinHours_Click(object sender, EventArgs e)
        {
            SubtractSecond(numHours);
        }

        private void btnMinMinutes_Click(object sender, EventArgs e)
        {
            SubtractSecond(numMinutes);
        }

        private void btnMinSeconds_Click(object sender, EventArgs e)
        {
            SubtractSecond(numSeconds);
        }

        /// <summary>
        /// Subtracts a second from the numeric updown every second, a minute if seconds = 0, an hour if minutes = 0
        /// </summary>
        private void TickDownTime()
        {
            try
            {
                if (Convert.ToInt32(numSeconds.Text) > 0)
                    numSeconds.Text = "" + (Convert.ToInt32(numSeconds.Text) - 1);
                else
                {
                    if (Convert.ToInt32(numMinutes.Text) > 0)
                    {
                        numMinutes.Text = "" + (Convert.ToInt32(numMinutes.Text) - 1);
                        numSeconds.Text = "59";
                    }
                    else
                    {
                        if (Convert.ToInt32(numHours.Text) > 0)
                        {
                            numHours.Text = "" + (Convert.ToInt32(numHours.Text) - 1);
                            numMinutes.Text = "59";
                            numSeconds.Text = "59";
                        }//Else probably no time left.

                    }
                }


                if (currentTimerItem == null || (currentTimerItem.PopupDate - DateTime.Now).TotalSeconds <= 0)
                    tmrCountdown.Stop();
            }
            catch(Exception ex)
            {
                BLIO.Log("TickDownTime FAILED. -> " + ex);
                BLIO.WriteError(ex, "Failed to tick down time on this timer");
            }
        }


        private void btnPlusHours_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlRunningTimers.Controls.Count > 1)
                    numHours.Text = "" + (Convert.ToInt32(numHours.Text) + 1);
            }
            catch (Exception ex)
            {
                BLIO.Log("btnPlusHours FAILED. -> " + ex);
                BLIO.WriteError(ex, "Failed to add another hour to this timer");
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
                e.Handled = true;
        }
        private void num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }

        private void btnPlusMinutes_Click(object sender, EventArgs e) 
        {
            if (pnlRunningTimers.Controls.Count > 1 && Convert.ToInt32(numMinutes.Text) <= 59)
                numMinutes.Text = "" + (Convert.ToInt32(numMinutes.Text) + 1);
        }

        private void btnPlusSeconds_Click(object sender, EventArgs e)
        {
            if (pnlRunningTimers.Controls.Count > 1 &&  Convert.ToInt32(numSeconds.Text) <= 59)
                numSeconds.Text = "" + (Convert.ToInt32(numSeconds.Text) + 1);
        }

        private void numSeconds_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numSeconds.Text))
                numSeconds.Text = "0";
            else if (Convert.ToInt32(numSeconds.Text) > 60)
                numSeconds.Text = "60";
        }

        private void numMinutes_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(numMinutes.Text))
                numMinutes.Text = "0";
            else if (Convert.ToInt32(numMinutes.Text) > 60)
                numMinutes.Text = "60";
        }

        public static List<TimerItem> RunningTimers
        {
            get { return timers; }
        }

        public void ToggleTimer()
        {
            if (tmrCountdown.Enabled)
            {
                tmrCountdown.Stop();
                return;
            }

            if (timerDuration > 0)
            {
                tmrCountdown.Start();
                //                label2.Focus(); //Dont leave focus on the numeric up down, showing the Ibeam cursor isnt very good looking                
            }
        }
        public void AddTimer(int seconds, string text)
        {
            BLIO.Log("Attempting to add a timer for " + seconds + " seconds.");
            TimerItem tmrItem = new TimerItem(DateTime.Now.AddSeconds(seconds), text, timerIdCounter, "material");
            tmrItem.updateAllowed = true;
            tmrItem.StartTimer();
            timers.Add(tmrItem);

            //Generate a new MaterialButton, but with the template markup
            MaterialButton timerButton = CloneButton();


            timerButton.Text = "[" + timerIdCounter + "] " + tmrItem.TimerText;

            //Shorten text
            if (timerButton.Text.Length > 11)
                timerButton.Text = timerButton.Text.Remove(10, timerButton.Text.Length - 10);

            //Link every new button click to this event.            
            timerButton.Click += TimerButton_Click;
            BLIO.Log("Button cloned & event listener linked");

            //Add the new button to top panel
            pnlRunningTimers.Controls.Add(timerButton);

            currentTimerItem = tmrItem;

            //Up the Id so that the next timer has a higher id
            timerIdCounter++;

            EnableButton(timerButton);

            new Thread(() =>
            {
                //Log an entry to the database, for data!                
                try
                {
                    BLOnlineDatabase.TimersCreated++;
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.TimersCreated++ . -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
            }).Start();
            BLIO.Log("Timer added!");
            TimerButton_Click(timerButton, null);
        }

        /// <summary>
        /// Gives all buttons the non-selected color, except the parameter
        /// </summary>
        /// <param name="button">The button that is going to be "selected"</param>
        private void EnableButton(MaterialButton btn)
        {
            //De-select all buttons 
            MaterialButton button = null;
            foreach (Control c in pnlRunningTimers.Controls)
            {
                if (c is MaterialButton)
                {
                    button = (MaterialButton)c;
                    button.Type = MaterialButton.MaterialButtonType.Outlined;
                }
            }
            //Select the clicked button
            btn.Type = MaterialButton.MaterialButtonType.Contained;
        }



        public void RemoveTimer(TimerItem tmrItem)
        {
            BLIO.Log("Attempting to remove timer with ID " + tmrItem.ID);
            TimerItem itemToRemove = null;
            MaterialButton toRemovebutton = null;

            foreach (TimerItem itm in timers)
                if (itm.ID == tmrItem.ID)
                    itemToRemove = itm;

            if (itemToRemove != null)
            {
                timers.Remove(itemToRemove);

                foreach (Control c in pnlRunningTimers.Controls)
                {
                    if (c is MaterialButton)
                    {
                        if (c.Text.StartsWith("[" + itemToRemove.ID + "] ")) //Remove this button
                            toRemovebutton = (MaterialButton)c;
                    }
                }
            }

            if (toRemovebutton != null)
            {
                pnlRunningTimers.Controls.Remove(toRemovebutton);
                toRemovebutton.Dispose();
            }
        }


        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            TickDownTime();
        }

        private void numericUpDown_ValueChange(object sender, EventArgs e)
        {
            if (currentTimerItem == null)
                return;
            try
            {
                int secondsRemaining = Convert.ToInt32((Convert.ToInt32(numHours.Text) * 60 * 60) + (Convert.ToInt32(numMinutes.Text) * 60) + Convert.ToInt32(numSeconds.Text));
                if(secondsRemaining < -5)
                {
                    BLIO.Log("Woah there.. Let's not assign this new time to this timer ;)");
                    numHours.Text = numHours.Text.Substring(0, numHours.Text.Length - 2);
                    return;
                }
                currentTimerItem.SecondsRemaining = secondsRemaining;
            }
            catch (OverflowException ex)
            {
                BLIO.Log("That number is a bit too large for this timer ;)");
                numHours.Text = numHours.Text.Substring(0, numHours.Text.Length - 2);
                numericUpDown_ValueChange(null, null);                
            }
            catch (Exception ex)
            {
                BLIO.Log("numericUpDown_valuechange collection FAILED. -> " + ex);
                BLIO.WriteError(ex, "Failed to add time to this timer");
            }
        }

        private void UCTimer_Load(object sender, EventArgs e)
        {
            SetKeyCombinationLabel();
        }
        private void SetKeyCombinationLabel()
        {
            lblKeyCombination.Text = "protip: You can create a quick timer by pressing the key combination: ";
            foreach (string m in BLLocalDatabase.Hotkey.TimerPopup.Modifiers.ToString().Split(','))
            {
                lblKeyCombination.Text += m + " + ";
            }
            lblKeyCombination.Text += BLLocalDatabase.Hotkey.TimerPopup.Key.ToString();
        }



        /// <summary>
        /// Copy the appearance of a template button into a new button. Basically cloning an object, but only these fields
        /// </summary>
        /// <returns></returns>
        private MaterialButton CloneButton()
        {
            MaterialButton btn = new MaterialButton();
            btn.Text = btnTimerTemplate.Text;
            btn.AutoSize = true;
            btn.Cursor = btnTimerTemplate.Cursor;
            btn.Icon = btnTimerTemplate.Icon;
            btn.Dock = DockStyle.Left;
            btn.Type = btnTimerTemplate.Type;
            btn.Cursor = btnTimerTemplate.Cursor;
            return btn;
        }



        private void btnNewTimer_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnNewTimer clicked!");
            MaterialTimerPopup quickTimer = new MaterialTimerPopup();
            quickTimer.Show();
        }

        public int GetTimerButtonId(MaterialButton button)
        {
            int indexFirst = button.Text.IndexOf("[");
            int indexLast = button.Text.IndexOf("]");
            return Convert.ToInt32(button.Text.Substring(indexFirst, indexLast).Remove(0, 1));
        }
        private void TimerButton_Click(object sender, EventArgs e)
        {          

            //Get selected TimerItem
            MaterialButton clickedButton = (MaterialButton)sender;

            BLIO.Log("TimerButton " + clickedButton.Text + " clicked!");
            //Remove all the text apart from the id and store it


            int id = GetTimerButtonId(clickedButton);


            foreach (TimerItem itm in timers)
            {
                if (itm.ID == id)
                {                    

                    currentTimerItem = itm;                    


                    if (currentTimerItem.Running)
                        tmrCountdown.Start();
                    else
                        tmrCountdown.Stop();


                    BLIO.Log("Setting values of (UCTimer) numericupdowns");
                    TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                    numSeconds.Text = "" + time.Seconds;
                    numMinutes.Text = "" + time.Minutes;
                    numHours.Text = "" + time.Hours;

                }
            }

            //Show play or pause depending on if the selected timer is running or not
            if (currentTimerItem.Running)
                btnPauseResumeTimer.Icon = Properties.Resources.pause_2x1;
            else
                btnPauseResumeTimer.Icon = Properties.Resources.Play;

            EnableButton(clickedButton);
        }

        private void pnlRunningTimers_ControlAdded(object sender, ControlEventArgs e)
        {
            lblNoTimers.Visible = pnlRunningTimers.Controls.Count == 1;
            btnDeleteTimer.DrawShadows = pnlRunningTimers.Controls.Count > 1;
            btnDeleteTimer.Visible = pnlRunningTimers.Controls.Count > 1;

            if (pnlRunningTimers.HorizontalScroll.Visible && pnlRunningTimers.Size.Height == 33)
                pnlRunningTimers.Size = new Size(pnlRunningTimers.Size.Width, pnlRunningTimers.Height + 20);
        }

        private void pnlRunningTimers_ControlRemoved(object sender, ControlEventArgs e)
        {
            //Will always contain one control, the (in)visible label
            lblNoTimers.Visible = pnlRunningTimers.Controls.Count == 1;
            btnDeleteTimer.DrawShadows = pnlRunningTimers.Controls.Count > 1;
            btnDeleteTimer.Visible = pnlRunningTimers.Controls.Count > 1;

            if (!pnlRunningTimers.HorizontalScroll.Visible && pnlRunningTimers.Size.Height > 33)
                pnlRunningTimers.Size = new Size(pnlRunningTimers.Size.Width, pnlRunningTimers.Height - 20);

            //Reset the time indication if there are no running timers left
            if (!lblNoTimers.Visible)
            {
                numHours.Text = "0";
                numMinutes.Text = "0";
                numSeconds.Text = "0";
            }
        }

        private void btnPauseResumeTimer_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCTimer)btnPauseResumeTimer_Click");
            if (currentTimerItem == null || currentTimerItem.Disposed)
                return;

            if (currentTimerItem.Running)
            {
                btnPauseResumeTimer.Icon = Properties.Resources.Play;
                currentTimerItem.StopTimer(Convert.ToInt32(numSeconds.Text), Convert.ToInt32(numMinutes.Text), Convert.ToInt32(numHours.Text));
            }
            else
            {
                btnPauseResumeTimer.Icon = Properties.Resources.pause_2x1;
                currentTimerItem.StartTimer();
            }
        }



        private void UCTimer_VisibleChanged(object sender, EventArgs e)
        {
            if (currentTimerItem != null && this.Visible)
            {
                BLIO.Log("Control UCImportExport now visible");
                BLIO.Log("Setting values of (UCTimer) numericupdowns on UCTimer_VisibleChanged (" + this.Visible + ")");

                if (currentTimerItem.SecondsRemaining <= 0)
                    return;

                TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                numSeconds.Text = "" + time.Seconds;
                numMinutes.Text = "" + time.Minutes;
                numHours.Text = "" + time.Hours;
                tmrCountdown.Start();
            }
        }

        private void btnDeleteTimer_Click(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("Attempting to delete timer...");
                //First, see what button is pressed
                MaterialButton button = null;
                foreach (Control c in pnlRunningTimers.Controls)
                {
                    if (c is MaterialButton)
                    {
                        button = (MaterialButton)c;

                        if (button.Type == MaterialButton.MaterialButtonType.Contained)
                            break;
                    }
                }

                //Now that we have the selected button stored in the "button" variable, let's work with it
                //Get the id
                BLIO.Log("Getting the ID of the button..");
                int id = GetTimerButtonId(button);
                BLIO.Log("Done! -> " + id + ". Getting the associated TimerItem...");
                //Use the id to get the correct TimerItem from the "timers" collection, and delete it
                TimerItem toRemoveItem = timers.Where(t => t.ID == id).ToList()[0];
                BLIO.Log("Deleting TimerItem with popup date " + toRemoveItem.PopupDate + " ..."); 
                RemoveTimer(toRemoveItem);
                toRemoveItem.Dispose();
                BLIO.Log("Successfully removed & disposed the TimerItem");
                //Set the current timer to the first one in the list
                if (timers.Count > 0)
                {
                    currentTimerItem = timers[0];

                    BLIO.Log("Setting values of (UCTimer) numericupdowns");
                    TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                    numSeconds.Text = "" + time.Seconds;
                    numMinutes.Text = "" + time.Minutes;
                    numHours.Text = "" + time.Hours;
                }
                else  //Nothing left
                {
                    numSeconds.Text = "0";
                    numMinutes.Text = "0";
                    numHours.Text = "0";
                    btnPauseResumeTimer.Icon = Properties.Resources.pause_2x1;
                    currentTimerItem = null;
                }

                //Set the pause/resume icon image depending on the current timer
                if (currentTimerItem == null || currentTimerItem.Disposed)
                    return;

                tmrCountdown.Enabled = currentTimerItem.Running;

                if (currentTimerItem.Running)
                    btnPauseResumeTimer.Icon = Properties.Resources.pause_2x1;
                else
                    btnPauseResumeTimer.Icon = Properties.Resources.Play;

                //Now make the current TimerItem button selected
                foreach (Control c in pnlRunningTimers.Controls)
                {
                    if (c is MaterialButton)
                    {
                        button = (MaterialButton)c;

                        if (GetTimerButtonId(button) == currentTimerItem.ID)
                            button.Type = MaterialButton.MaterialButtonType.Contained; //This is our button                    
                    }
                }
            }
            catch(Exception ex)
            {
                BLIO.Log("Deleting timer FAILED. -> " + ex);
                BLIO.WriteError(ex, "Failed to delete this timer");
            }
        }

        private void numHours_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numHours.Text))
                numHours.Text = "0";
        }
    }
}
