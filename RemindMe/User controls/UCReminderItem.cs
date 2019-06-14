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
using Bunifu.Framework.UI;

namespace RemindMe
{
    public partial class UCReminderItem : UserControl
    {
        //Fill this user control with the details of this reminder
        private Reminder rem;
        //Determine if this control is "Selected"
        private bool selected = false;
        
        public UCReminderItem(Reminder rem)
        {
            InitializeComponent();
            this.rem = rem;

            //Make it so that it doesn't matter where on the item you click, the click event gets fired
           

            btnDelete.MouseHover += btn_MouseHover;
            btnDelete.MouseLeave += btn_MouseLeave;

            btnEdit.MouseHover += btn_MouseHover;
            btnEdit.MouseLeave += btn_MouseLeave;

            btnDisable.MouseHover += btn_MouseHover;
            btnDisable.MouseLeave += btn_MouseLeave;

            btnSettings.MouseHover += btn_MouseHover;
            btnSettings.MouseLeave += btn_MouseLeave;

            ReminderMenuStrip.Renderer = new MyToolStripMenuRenderer();

            

            tpInformation.SetToolTip(btnSettings, "Click for more options");
            tpInformation.SetToolTip(btnDisable, "Enable/Disable the reminder");
            tpInformation.SetToolTip(btnDelete, "Delete a reminder");
            tpInformation.SetToolTip(btnEdit, "Edit a reminder");
        }


       
        public void UpdateReminder(Reminder rem)
        {
            this.rem = rem;          
            LoadReminderData();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

      

        private void UCReminderItem_Load(object sender, EventArgs e)
        {
            //Prevent flickering
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            
            LoadReminderData();
        }

        //Loads reminder data into the controls
        private void LoadReminderData()
        {
            if(rem == null)
            {
                lblDate.Text = "x";
                lblReminderName.Text = "None";
                lblRepeat.Text = "x";
                btnDisable.Image = Properties.Resources.turnedOffTwo;
                this.Visible = false;
                return;
            }

            pbRepeat.Location = new Point(168, 26);
            lblRepeat.Location = new Point(195, 30);

            DateTime date = Convert.ToDateTime(rem.Date.Split(',')[0]);
            lblDate.Text = date.ToShortDateString() + " " + date.ToShortTimeString();

            //Postpone logic
            if(rem.PostponeDate != null)
            {                
                pbDate.BackgroundImage = Properties.Resources.RemindMeZzz;
                Font font = new Font(lblRepeat.Font, FontStyle.Bold | FontStyle.Italic);
                lblDate.Font = font;

                lblDate.Text = Convert.ToDateTime(rem.PostponeDate) + " (Postponed)";
            }
            else
            {
                pbDate.BackgroundImage = Properties.Resources.RemindMe;
                Font font = new Font(lblRepeat.Font, FontStyle.Bold);
                lblDate.Font = font;
            }

            //If some country has a longer date string, move the repeat icon/text more to the right so it doesnt overlap
            while (lblDate.Bounds.IntersectsWith(pbRepeat.Bounds))
            {
                pbRepeat.Location = new Point(pbRepeat.Location.X + 5, pbRepeat.Location.Y);
                lblRepeat.Location = new Point(lblRepeat.Location.X + 5, lblRepeat.Location.Y);
            }

            lblReminderName.Text = rem.Name;
            lblRepeat.Text = BLReminder.GetRepeatTypeText(rem);

            if (rem.Enabled == 1)
                btnDisable.Image = Properties.Resources.turnedOn;
            else
                btnDisable.Image = Properties.Resources.turnedOffTwo;
        }
        

        private void UCReminderItem_MouseEnter(object sender, EventArgs e)
        {
            if(!selected)
                this.BackColor = Color.FromArgb(150, 150, 150);
        }

        //2 collective events that both do the same "animation" by changing the zoom, for 2 different buttons
        private void btn_MouseHover(object sender, EventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            btn.Zoom = -15;
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            btn.Zoom = -15;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (rem.Enabled == 1)
            {
                btnDisable.Image = Properties.Resources.turnedOffTwo;
                rem.Enabled = 0;
            }
            else
            {
                btnDisable.Image = Properties.Resources.turnedOn;
                rem.Enabled = 1;
            }

            BLReminder.EditReminder(rem);
            UCReminders.GetInstance().UpdateCurrentPage();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HideOrShowRemovePostponeMenuItem(rem);
            HideOrShowSkipForwardMenuItem(rem);
            ReminderMenuStrip.Show(Cursor.Position);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UCReminders.GetInstance().EditReminder(rem);            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BLReminder.DeleteReminder(rem);            
            UCReminders.GetInstance().UpdateCurrentPage();
        }

        private void previewThisReminderNowToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            PreviewReminder();
        }
        private void PreviewReminder()
        {
            BLIO.Log("Previewing reminder with id " + rem.Id);
            Reminder previewRem = rem;
            previewRem.Id = -1; //give the >temporary< reminder an invalid id, so that the real reminder won't be altered
            Popup p = new Popup(previewRem);
            p.Show();
        }

        private async void previewThisReminderIn5SecondsToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            PreviewReminder();
        }

        private async void previewThisReminderIn10SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Delay(10000);
            PreviewReminder();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Setting up the duplicating process...");
            BLIO.Log("duplicating reminder with id " + rem.Id);
            BLReminder.PushReminderToDatabase(rem);
            BLIO.Log("reminder duplicated.");
            UCReminders.GetInstance().UpdateCurrentPage();            
        }
        /// <summary>
        /// When right-clicking reminder(s), this method will hide the skip to next date option if one of the reminder(s) does not have a next date.
        /// </summary>
        private void HideOrShowSkipForwardMenuItem(Reminder reminder)
        {
            //Check if the repeat type is NONE, and check if the amount of dates after split by comma is smaller or equal than 1.
            //If this is the case, we have a reminder that doesn't have a next day, and therefore is not repeatable
            //Then simply return if the count is equal to 0. No reminders that aren't repeatable? return true;
            bool hideMenuItem = reminder.RepeatType == ReminderRepeatType.NONE.ToString() && rem.Date.Split(',').Length <= 1;
           

            //The option
            ToolStripItem skipToNextDateItem = ReminderMenuStrip.Items.Find("skipToNextDateToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Skip to next date" option based on the boolean hideMenuItem
            skipToNextDateItem.Visible = !hideMenuItem;
            BLIO.Log("Showing skip to next date option from right click menu: " + hideMenuItem);

        }

        /// <summary>
        /// When right-clicking a reminder, this method will hide the remove postpone option if the reminder does not have a postpone date.
        /// </summary>
        private void HideOrShowRemovePostponeMenuItem(Reminder reminder)
        {
            //Check if there is even a single reminder that is not postponed from the selected reminders. We only want to show this option if every
            //selected reminder is postponed
            bool hideMenuItem = rem.PostponeDate != null && rem.PostponeDate != "";

            //The option
            ToolStripItem removePostponeItem = ReminderMenuStrip.Items.Find("removePostponeToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Remove postpone" option based on the boolean hideMenuItem

            removePostponeItem.Visible = hideMenuItem;
            BLIO.Log("Showing remove postpone option from right click menu: " + hideMenuItem);

        }

        private void hideReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message = "You can hide reminders with this option. The reminder will not be deleted, you just won't be able to see it"
                 + " in the list of reminders. This creates a sense of surprise.\r\n\r\nDo you wish to hide this reminder?";                        

            BLIO.Log("Attempting to hide reminder(s)");
            if (BLSettings.HideReminderOptionEnabled || RemindMeBox.Show(message, RemindMeBoxReason.YesNo, true) == DialogResult.Yes)
            {
                //Enable the hide flag here                                
                rem.Hide = 1;
                BLIO.Log("Marked reminder with id " + rem.Id + " as hidden");
                BLReminder.EditReminder(rem);
                UCReminders.GetInstance().UpdateCurrentPage();
            }
            else
                BLIO.Log("Attempting to hide reminder(s) failed.");
        }

        private void enableWarningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Attempting to re-enable the hide warning on reminders....");

            //Get the current settings from the database
            Settings currentSettings = BLSettings.GetSettings();

            //Set the hiding of the confirmation on hiding a reminder to false
            currentSettings.HideReminderConfirmation = 0;

            //Make the right-click menu option invisible
            enableWarningToolStripMenuItem.Visible = false;

            //Push the updated settings to the database
            BLSettings.UpdateSettings(currentSettings);

            BLIO.Log("Re-enabled the hide warning on reminders!");
        }

        private void postponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minutes = RemindMePrompt.ShowMinutes("Select your postpone time", "(in minutes or in xhxxm format (1h20m) )");
           
            if (rem.PostponeDate == null)//No postpone yet, create it
                rem.PostponeDate = Convert.ToDateTime(rem.Date.Split(',')[0]).AddMinutes(minutes).ToString();
            else//Already a postponedate, add the time to that date                
                rem.PostponeDate = Convert.ToDateTime(rem.PostponeDate).AddMinutes(minutes).ToString();

            BLReminder.EditReminder(rem);//Push changes

            UCReminders.GetInstance().UpdateCurrentPage();
        }

        private void removePostponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Removing postpone from reminder with id " + rem.Id);
            rem.PostponeDate = null;
            BLReminder.EditReminder(rem);

            pbRepeat.Location = new Point(168, 26);
            lblRepeat.Location = new Point(195, 30);
            LoadReminderData();
            UCReminders.GetInstance().UpdateCurrentPage();
        }

        private void skipToNextDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Skipping reminder with id " + rem.Id + " to its next date");
            //The reminder object has now been altered. The first date has been removed and has been "skipped" to it's next date
            BLReminder.SkipToNextReminderDate(rem);
            //push the altered reminder to the database 
            BLReminder.EditReminder(rem);

            //Refresh to show changes
            UCReminders.GetInstance().UpdateCurrentPage();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            if (RemindMeBox.Show("Are you really sure you wish to permanentely delete \"" + rem.Name + "\" ?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
            {
                BLIO.Log("Permanentely deleting reminder with id " + rem.Id + " ...");
                BLReminder.PermanentelyDeleteReminder(rem);                
                BLIO.Log("Reminder permanentely deleted.");
                UCReminders.GetInstance().UpdateCurrentPage();
            }
        }
    }
}
