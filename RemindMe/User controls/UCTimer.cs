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

namespace RemindMe
{
    public partial class UCTimer : UserControl
    {
        public decimal timerDuration = 0;
        public List<TimerItem> timers = new List<TimerItem>();
        public string timerNote = "";

        //Contains the TimerItem the user is currently viewing/editing. This should change if the user clicks one of the timer buttons(if there are multiple timers)
        private TimerItem currentTimerItem;

        private int timerIdCounter = 1;
        
        public UCTimer()
        {
            InitializeComponent();
            TimerMenuStrip.Renderer = new MyToolStripMenuRenderer();
            btnPauseResumeTimer.Iconimage = Properties.Resources.pause_2x1;

            //Link events to the global event
            numSeconds.Click += numericUpDown_ValueChange;
            numMinutes.Click += numericUpDown_ValueChange;
            numHours.Click += numericUpDown_ValueChange;

            numSeconds.KeyUp += numericUpDown_ValueChange;
            numMinutes.KeyUp += numericUpDown_ValueChange;
            numHours.KeyUp += numericUpDown_ValueChange;
            //The user can change the time of an timer with these numeric up-downs. When the user attempts to do that, link the event to the global numericUpDown_ValueChange
        }

        /// <summary>
        /// Subtracts a second from the numeric updown every second, a minute if seconds = 0, an hour if minutes = 0
        /// </summary>
        private void TickDownTime()
        {           
            if(numSeconds.Value > 0)
                numSeconds.Value--;
            else
            {
                if (numMinutes.Value > 0)
                {
                    numMinutes.Value--;
                    numSeconds.Value = 59;
                }
                else
                {
                    if (numHours.Value > 0)
                    {
                        numHours.Value--;
                        numMinutes.Value = 59;
                        numSeconds.Value = 59;
                    }//Else probably no time left.
                    
                }                
            }
            

            if ( (currentTimerItem.PopupDate-DateTime.Now).Seconds <= 0)                            
                tmrCountdown.Stop();                                            
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
                label2.Focus(); //Dont leave focus on the numeric up down, showing the Ibeam cursor isnt very good looking                
            }
        }
        public void AddTimer(int seconds, string text)
        {
            BLIO.Log("Attempting to add a timer for " + seconds + " seconds.");
            TimerItem tmrItem = new TimerItem(DateTime.Now.AddSeconds(seconds), text, timerIdCounter);
            tmrItem.updateAllowed = true;            
            tmrItem.StartTimer();            
            timers.Add(tmrItem);

            //Generate a new BunifuFlatbutton, but with the template markup
            BunifuFlatButton timerButton = CloneButton();
            

            timerButton.Text = " Timer " + timerIdCounter;

            //Link every new button click to this event.            
            timerButton.Click += TimerButton_Click;
            BLIO.Log("Button cloned & event listener linked");

            //Add the new button to top panel
            pnlRunningTimers.Controls.Add(timerButton);

            currentTimerItem = tmrItem;

            //Up the Id so that the next timer has a higher id
            timerIdCounter++;

            EnableButton(timerButton);
            BLIO.Log("Timer added!");            
        }

        /// <summary>
        /// Gives all buttons the non-selected color, except the parameter
        /// </summary>
        /// <param name="button">The button that is going to be "selected"</param>
        private void EnableButton(BunifuFlatButton btn)
        {
            //De-select all buttons 
            BunifuFlatButton button = null;
            foreach (Control c in pnlRunningTimers.Controls)
            {
                if (c is BunifuFlatButton)
                {
                    button = (BunifuFlatButton)c;
                    button.Normalcolor = Color.FromArgb(64, 64, 64);
                }
            }
            //Select the clicked button
            btn.Normalcolor = Color.Gray;
        }

       

        public void RemoveTimer(TimerItem tmrItem)
        {
            BLIO.Log("Attempting to remove timer with ID " + tmrItem.ID);
            TimerItem itemToRemove = null;
            BunifuFlatButton toRemovebutton = null;

            foreach (TimerItem itm in timers)
                if (itm.ID == tmrItem.ID)
                    itemToRemove = itm;

            if (itemToRemove != null)
            {
                timers.Remove(itemToRemove);

                foreach (Control c in pnlRunningTimers.Controls)
                {
                    if (c is BunifuFlatButton)
                    {
                        if (c.Text == " Timer " + itemToRemove.ID) //Remove this button
                            toRemovebutton = (BunifuFlatButton)c;
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

            currentTimerItem.SecondsRemaining = Convert.ToInt32((numHours.Value * 60 * 60) + (numMinutes.Value * 60) + numSeconds.Value);
        }

        private void UCTimer_Load(object sender, EventArgs e)
        {            
            SetKeyCombinationLabel();            
        }
        private void SetKeyCombinationLabel()
        {
            lblKeyCombination.Text = "protip: You can create a quick timer by pressing the key combination: ";
            foreach (string m in BLHotkeys.TimerPopup.Modifiers.ToString().Split(','))
            {
                lblKeyCombination.Text += m + " + ";
            }
            lblKeyCombination.Text += BLHotkeys.TimerPopup.Key.ToString();            
        }

    

        /// <summary>
        /// Copy the appearance of a template button into a new button. Basically cloning an object, but only these fields
        /// </summary>
        /// <returns></returns>
        private BunifuFlatButton CloneButton()
        {
            BunifuFlatButton btn = new BunifuFlatButton();
            btn.Activecolor = btnTimerTemplate.Activecolor;
            btn.BackColor = btnTimerTemplate.BackColor;                       
            btn.BackgroundImageLayout = btnTimerTemplate.BackgroundImageLayout;
            btn.BorderRadius = btnTimerTemplate.BorderRadius;
            btn.Text = btnTimerTemplate.Text;
            btn.DisabledColor = btnTimerTemplate.DisabledColor;
            btn.Font = btnTimerTemplate.Font;
            btn.Cursor = btnTimerTemplate.Cursor;
            btn.Iconimage = btnTimerTemplate.Iconimage;
            btn.IconZoom = btnTimerTemplate.IconZoom;
            btn.Normalcolor = btnTimerTemplate.Normalcolor;
            btn.OnHovercolor = btnTimerTemplate.OnHovercolor;
            btn.OnHoverTextColor = btnTimerTemplate.OnHoverTextColor;
            btn.selected = false;
            btn.TextAlign = btnTimerTemplate.TextAlign;
            btn.Textcolor = btnTimerTemplate.Textcolor;
            btn.TextFont = btnTimerTemplate.TextFont;
            btn.Size = btnTimerTemplate.Size;
            btn.Dock = DockStyle.Left;
            

            return btn;
        }

     

        private void btnNewTimer_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnNewTimer clicked!");
            TimerPopup quickTimer = new TimerPopup();
            quickTimer.Show();
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {            
            //Right click delete
            if (e.GetType().Equals(typeof(MouseEventArgs)))
            {
                MouseEventArgs mouse = (MouseEventArgs)e;                
                if (mouse.Button == MouseButtons.Right)
                {
                    TimerMenuStrip.Show(Cursor.Position);
                }
            }

            BLIO.Log("TimerButton clicked!");
            //Get selected TimerItem
            BunifuFlatButton clickedButton = (BunifuFlatButton)sender;
            BLIO.Log("^^^^ (" + clickedButton.Text + ")");
            //Remove all the text apart from the id and store it
            int id = Convert.ToInt32(clickedButton.Text.Replace("Timer","").Replace(" ","")); 

            foreach (TimerItem itm in timers)
            {
                if (itm.ID == id)
                {
                    currentTimerItem = itm;  

                    if(currentTimerItem.IsRunning())
                        tmrCountdown.Start();
                    else
                        tmrCountdown.Stop();


                    BLIO.Log("Setting values of (UCTimer) numericupdowns");
                    TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                    numSeconds.Value = time.Seconds;
                    numMinutes.Value = time.Minutes;
                    numHours.Value = time.Hours;
                }
            }            

            //Show play or pause depending on if the selected timer is running or not
            if (currentTimerItem.IsRunning())            
                btnPauseResumeTimer.Iconimage = Properties.Resources.pause_2x1;                            
            else            
                btnPauseResumeTimer.Iconimage = Properties.Resources.Play;

            EnableButton(clickedButton);
        }

        private void pnlRunningTimers_ControlAdded(object sender, ControlEventArgs e)
        {
            lblNoTimers.Visible = pnlRunningTimers.Controls.Count == 1;

            if (pnlRunningTimers.HorizontalScroll.Visible && pnlRunningTimers.Size.Height == 33)
                pnlRunningTimers.Size = new Size(pnlRunningTimers.Size.Width, pnlRunningTimers.Height+20);
        }

        private void pnlRunningTimers_ControlRemoved(object sender, ControlEventArgs e)
        {
            lblNoTimers.Visible = pnlRunningTimers.Controls.Count == 1;

            if (!pnlRunningTimers.HorizontalScroll.Visible && pnlRunningTimers.Size.Height > 33)
                pnlRunningTimers.Size = new Size(pnlRunningTimers.Size.Width, pnlRunningTimers.Height - 20);
        }

        private void btnPauseResumeTimer_Click(object sender, EventArgs e)
        {            
            if (currentTimerItem == null || currentTimerItem.Disposed)
                return;

            if (currentTimerItem.IsRunning())
            {
                btnPauseResumeTimer.Iconimage = Properties.Resources.Play;
                currentTimerItem.StopTimer();
            }
            else
            {
                btnPauseResumeTimer.Iconimage = Properties.Resources.pause_2x1;
                currentTimerItem.StartTimer();
            }            
        }

        private void ucTimerDeleteToolstrip_Click(object sender, EventArgs e)
        {
            //First, see what button is pressed
            BunifuFlatButton button = null;
            foreach (Control c in pnlRunningTimers.Controls)
            {
                if (c is BunifuFlatButton)
                {
                    button = (BunifuFlatButton)c;

                    if (button.Normalcolor == Color.Gray)
                        break;
                }
            }

            //Now that we have the selected button stored in the "button" variable, let's work with it
            //Get the id
            int id = Convert.ToInt32(button.Text.Replace("Timer", "").Replace(" ", ""));
            //Use the id to get the correct TimerItem from the "timers" collection, and delete it
            TimerItem toRemoveItem = timers.Where(t => t.ID == id).ToList()[0];
            RemoveTimer(toRemoveItem);
            toRemoveItem.Dispose();

            //Set the current timer to the first one in the list
            if (timers.Count > 0)
            {
                currentTimerItem = timers[0];
                

                BLIO.Log("Setting values of (UCTimer) numericupdowns");
                TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                numSeconds.Value = time.Seconds;
                numMinutes.Value = time.Minutes;
                numHours.Value = time.Hours;
            }
            else  //Nothing left
            {
                numSeconds.Value = 0;
                numMinutes.Value = 0;
                numHours.Value = 0;
                btnPauseResumeTimer.Iconimage = Properties.Resources.pause_2x1;
            }

            //Set the pause/resume icon image depending on the current timer
            if (currentTimerItem.Disposed || currentTimerItem == null)
                return;

            tmrCountdown.Enabled = currentTimerItem.IsRunning();

            if (currentTimerItem.IsRunning())
                btnPauseResumeTimer.Iconimage = Properties.Resources.pause_2x1;
            else
                btnPauseResumeTimer.Iconimage = Properties.Resources.Play;

            //Now make the current TimerItem button selected
            foreach (Control c in pnlRunningTimers.Controls)
            {
                if (c is BunifuFlatButton)
                {
                    button = (BunifuFlatButton)c;

                    if (Convert.ToInt32(button.Text.Replace("Timer", "").Replace(" ", "")) == currentTimerItem.ID)
                        button.Normalcolor = Color.Gray; //This is our button                    
                }
            }
        }

        private void UCTimer_VisibleChanged(object sender, EventArgs e)
        {
            if(currentTimerItem != null && this.Visible)
            {
                BLIO.Log("Setting values of (UCTimer) numericupdowns on UCTimer_VisibleChanged ("+this.Visible+")");

                if (currentTimerItem.SecondsRemaining <= 0)
                    return;

                TimeSpan time = TimeSpan.FromSeconds((double)currentTimerItem.SecondsRemaining);
                numSeconds.Value = time.Seconds;
                numMinutes.Value = time.Minutes;
                numHours.Value = time.Hours;
                tmrCountdown.Start();
            }
        }
    }
}
