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
using System.Reflection;

namespace RemindMe
{
    public partial class UCReminders : UserControl
    {
        //The sizes of the listview column headers. The user can change these and they will be saved.
        private ListviewColumnSizes sizes;
        private static ListView lvRems = null;
        private static bool allowRefreshListview = false;
        private static UCReminders instance;

        //Reminders that will pop up the next hour.
        private static List<Reminder> remindersToHappenInAnHour = new List<Reminder>();

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        private static int dayOfStartRemindMe = DateTime.Now.Day;

        private List<string> popupMessages = new List<string>();
        public UCReminders()
        {
            InitializeComponent();
            sizes = BLListviewColumnSizes.GetcolumnSizes();
            SetColumnHeaderWidth();
            ReminderMenuStrip.Renderer = new MyToolStripMenuRenderer();
                               
            lvRems = lvReminders;
            instance = this;            
        }

        public static UCReminders GetInstance()
        {
            return instance;
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

        /// <summary>
        /// Alert UCReminders to refresh the reminder listview from outside sources
        /// </summary>
        public static void NotifyChange()
        {
            BLIO.Log("UCReminders.NotifyChange()");            
            if (lvRems != null)
                BLFormLogic.RefreshListview(lvRems);

            if (GetInstance() != null)
                GetInstance().tmrCheckReminder.Start();            
        }
        private void UCReminders_Load(object sender, EventArgs e)
        {
            BLIO.Log("Loading reminders from database");
            BLFormLogic.AddRemindersToListview(lvReminders, BLReminder.GetReminders().Where(r => r.Hide == 0).ToList()); //Get all "active" reminders);                                
            BLIO.Log("Starting the reminder timer");
            tmrCheckReminder.Start();
        }        

        /// <summary>
        /// Set the column widths to the widths from the database. Whenever the user changes the width of them, they will save.
        /// </summary>
        private void SetColumnHeaderWidth()
        {
            foreach (ColumnHeader ch in lvReminders.Columns)
            {
                switch (ch.Text)
                {
                    case "Title":
                        ch.Width = (int)sizes.Title;
                        break;
                    case "Date":
                        ch.Width = (int)sizes.Date;
                        break;
                    case "Repeating":
                        ch.Width = (int)sizes.Repeating;
                        break;
                    case "Enabled":
                        ch.Width = (int)sizes.Enabled;
                        break;
                }
            }
            BLIO.Log("Column header width set.");
        }


        private void UpdateColumnHeaderWidth()
        {
            foreach (ColumnHeader ch in lvReminders.Columns)
            {
                switch (ch.Text)
                {
                    case "Title":
                        sizes.Title = ch.Width;
                        break;
                    case "Date":
                        sizes.Date = ch.Width;
                        break;
                    case "Repeating":
                        sizes.Repeating = ch.Width;
                        break;
                    case "Enabled":
                        sizes.Enabled = ch.Width;
                        break;
                }
            }
            BLListviewColumnSizes.UpdateListviewSizes(sizes);
            BLIO.Log("Column header width updated.");
        }

        private void lvReminders_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            UpdateColumnHeaderWidth();
        }

        private void lvReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Delete)
                permanentelyRemoveToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.Delete)
                btnRemoveReminder_Click(sender, e); 
            else if (e.KeyCode == Keys.Space)
                btnDisableEnable_Click(sender, e);


            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                BLIO.Log("selecting all reminders (Ctrl + a ).");
                foreach (ListViewItem item in lvReminders.Items)
                    item.Selected = true;
            }
        }

        private void btnRemoveReminder_Click(object sender, EventArgs e)
        {
            if (lvReminders.SelectedItems.Count > 0)
            {
                List<Reminder> toRemoveReminders = new List<Reminder>();
                foreach (ListViewItem item in lvReminders.SelectedItems)
                {
                    toRemoveReminders.Add(BLReminder.GetReminderById(Convert.ToInt32(item.Tag)));
                    lvReminders.Items.Remove(item);//Remove it from the listview                    
                }

                //If the user selected multiple reminders, you don't open the database, remove the reminder, and close the database for every selected reminder this way
                BLIO.Log("Deleting " + toRemoveReminders.Count + " reminders");
                BLReminder.DeleteReminders(toRemoveReminders);
            }
        }

        private void btnDisableEnable_Click(object sender, EventArgs e)
        {
            if (lvReminders.SelectedItems.Count > 0)
            {
                foreach (ListViewItem itm in lvReminders.SelectedItems)
                {
                    if (itm.SubItems[3].Text == "True")
                        itm.SubItems[3].Text = "False";
                    else
                        itm.SubItems[3].Text = "True";

                    //The reminder selected from the listview
                    Reminder rem = BLReminder.GetReminderById(Convert.ToInt32(itm.Tag));

                    if (bool.Parse(itm.SubItems[3].Text))
                    {
                        rem.Enabled = 1;
                        BLIO.Log("Reminder with id " + rem.Id + " enabled");
                    }
                    else
                    {
                        rem.Enabled = 0;
                        BLIO.Log("Reminder with id " + rem.Id + " disabled");
                    }

                    BLReminder.EditReminder(rem);

                }
            }            
            NotifyChange();
        }

        private List<Reminder> GetSelectedRemindersFromListview()
        {
            BLIO.Log("Getting the selected reminders from the listview...");
            List<Reminder> selectedReminders = new List<Reminder>();

            foreach (ListViewItem item in lvReminders.SelectedItems)
                selectedReminders.Add(BLReminder.GetReminderById((long)item.Tag));


            BLIO.Log("result: " + selectedReminders.Count + " reminders.");
            return selectedReminders;
        }

        private void lvReminders_MouseClick(object sender, MouseEventArgs e)
        {
            ReminderMenuStrip.Items.Insert(4,unHideReminderToolStripMenuItem);            
            
            if (e.Button == MouseButtons.Right && lvReminders.SelectedItems.Count > 0)
            {
                List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
                HideOrShowRemovePostponeMenuItem(selectedReminders);
                HideOrShowSkipForwardMenuItem(selectedReminders);
                HideOrShowUnhideReminders();
                HideOrShowEnableHideWarning();
                ReminderMenuStrip.Show(Cursor.Position);
            }
           
        }

        private void lvReminders_MouseUp(object sender, MouseEventArgs e)
        {            
            if (lvReminders.SelectedItems.Count > 0)
                return;

            if (e.Button == MouseButtons.Right && lvReminders.SelectedItems.Count <= 0)
            {
                if (BLReminder.GetReminders().Where(r => r.Hide == 1).ToList().Count > 0)
                {
                    ContextMenuStrip strip = new ContextMenuStrip();
                    strip.Renderer = new MyToolStripMenuRenderer();
                    unHideReminderToolStripMenuItem.Visible = true;
                    unHideReminderToolStripMenuItem.Font = hideReminderToolStripMenuItem.Font;                     
                    strip.Items.Add(unHideReminderToolStripMenuItem);
                    strip.Show(Cursor.Position);
                }
            }
        }
        /// <summary>
        /// When right-clicking reminder(s), this method will hide the skip to next date option if one of the reminder(s) does not have a next date.
        /// </summary>
        private void HideOrShowRemovePostponeMenuItem(List<Reminder> reminders)
        {
            //Check if there is even a single reminder that is not postponed from the selected reminders. We only want to show this option if every
            //selected reminder is postponed
            bool hideMenuItem = BLReminder.ContainsPostponedReminder(reminders);

            //The option
            ToolStripItem removePostponeItem = ReminderMenuStrip.Items.Find("removePostponeToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Remove postpone" option based on the boolean hideMenuItem
            
            removePostponeItem.Visible = hideMenuItem;
            BLIO.Log("Showing remove postpone option from right click menu: " + hideMenuItem );

        }
        /// <summary>
        /// When right-clicking reminder(s), this method will hide the skip to next date option if one of the reminder(s) does not have a next date.
        /// </summary>
        private void HideOrShowUnhideReminders()
        {
            //Check if there is even a single reminder that is hidden            
            bool showMenuItem = false;

            if(BLReminder.GetReminders().Where(r => r.Hide == 1).ToList().Count > 0)
                showMenuItem = true; //If there's just 1 reminder that is hidden, show the option to un-hide all reminders
           

            //The option
            ToolStripItem unHideToolStripItem = ReminderMenuStrip.Items.Find("unHideReminderToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Remove postpone" option based on the boolean hideMenuItem
            unHideToolStripItem.Visible = showMenuItem;
            BLIO.Log("Showing unhide reminders option from right click menu: " + showMenuItem);

        }
        private void HideOrShowEnableHideWarning()
        {
            //The option
            enableWarningToolStripMenuItem.Visible = BLSettings.GetSettings().HideReminderConfirmation == 1;
                        
            BLIO.Log("Showing enable hide warning option from right click menu: " + (BLSettings.GetSettings().HideReminderConfirmation == 1) );
        }
        /// <summary>
        /// When right-clicking reminder(s), this method will hide the skip to next date option if one of the reminder(s) does not have a next date.
        /// </summary>
        private void HideOrShowSkipForwardMenuItem(List<Reminder> reminders)
        {
            //Check if there is even a single reminder that can't be repeated from the selected reminders. We only want to show this option if every
            //selected reminder is repeatable
            bool hideMenuItem = BLReminder.ContainsRepeatableReminder(reminders);


            //The option
            ToolStripItem skipToNextDateItem = ReminderMenuStrip.Items.Find("skipToNextDateToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Skip to next date" option based on the boolean hideMenuItem
            skipToNextDateItem.Visible = hideMenuItem;
            BLIO.Log("Showing skip to next date option from right click menu: " + hideMenuItem);

        }

        private void permanentelyRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Reminder> selectedReminders = GetSelectedRemindersFromListview();
            if (RemindMeBox.Show("Are you really sure you wish to permanentely delete " + selectedReminders.Count + " reminders?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
            {
                BLIO.Log("Permanentely deleting " + selectedReminders.Count + " reminders...");
                BLReminder.PermanentelyDeleteReminders(selectedReminders);


                foreach (ListViewItem item in lvReminders.SelectedItems)
                    lvReminders.Items.Remove(item);

                BLIO.Log(selectedReminders.Count + " Reminders permanentely deleted.");
            }

        }

        private void skipToNextDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Reminder rem in GetSelectedRemindersFromListview())
            {
                BLIO.Log("Skipping reminder with id " + rem.Id + " to its next date");
                //The reminder object has now been altered. The first date has been removed and has been "skipped" to it's next date
                BLReminder.SkipToNextReminderDate(rem);
                //push the altered reminder to the database 
                BLReminder.EditReminder(rem);          
            }                                            

            //Refresh to show changes
            BLFormLogic.RefreshListview(lvReminders);
        }

        private void removePostponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Reminder rem in GetSelectedRemindersFromListview())
            {
                BLIO.Log("Removing postpone from reminder with id " + rem.Id);
                rem.PostponeDate = null;
                BLReminder.EditReminder(rem);
            }
            BLFormLogic.RefreshListview(lvReminders);
        }

        private void postponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int returnValue = RemindMePrompt.ShowNumber("Select your postpone time", "(in minutes)");

            if (returnValue <= 0)
                return;

            foreach (Reminder rem in GetSelectedRemindersFromListview())
            {
                if (rem.PostponeDate == null)//No postpone yet, create it
                    rem.PostponeDate = Convert.ToDateTime(rem.Date.Split(',')[0]).AddMinutes(returnValue).ToString();
                else//Already a postponedate, add the time to that date                
                    rem.PostponeDate = Convert.ToDateTime(rem.PostponeDate).AddMinutes(returnValue).ToString();

                BLReminder.EditReminder(rem);//Push changes
            }
            BLFormLogic.RefreshListview(lvReminders);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Setting up the duplicating process...");
            foreach (Reminder rem in GetSelectedRemindersFromListview())
            {
                BLIO.Log("duplicating reminder with id " + rem.Id);
                BLReminder.PushReminderToDatabase(rem);
                BLIO.Log("reminder duplicated.");
                BLFormLogic.RefreshListview(lvReminders);
            }
            BLIO.Log(GetSelectedRemindersFromListview().Count + " reminders duplicated!");
        }

        private void exportSelectedRemindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedPath = FSManager.Folders.GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(selectedPath))
            {
                BLIO.Log("User selected a valid path");
                Exception possibleException = BLReminder.ExportReminders(GetSelectedRemindersFromListview(), selectedPath);
                if (possibleException is UnauthorizedAccessException)
                {//Did ExportReminders return an UnauthorizedException? Give the user the option to save to the desktop instead.
                    BLIO.Log("Problem encountered: Unauthorized");
                    if (RemindMeBox.Show("Could not save reminders to \"" + selectedPath + "\"\r\nDo you wish to place them on your desktop instead?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                    {
                        BLIO.Log("Trying to save to desktop instead...");
                        possibleException = BLReminder.ExportReminders(GetSelectedRemindersFromListview(), Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                        if (possibleException != null)
                        {//Did saving to desktop go wrong, too?? just show a message
                            BLIO.Log("Trying to save to desktop didnt work either");
                            RemindMeBox.Show("Something went wrong. Could not save the reminders to your desktop.", RemindMeBoxReason.OK);
                        }
                        else
                        {//Saving to desktop did not throw an exception    
                            BLIO.Log("Saved to desktop");
                            MessageFormManager.MakeMessagePopup("Succesfully exported " + GetSelectedRemindersFromListview().Count + " reminders to: Desktop", 3);
                        }
                    }
                }
                else if (possibleException is Exception)
                {//ExportReminders returned the global Exception. We don't know what went wrong
                    RemindMeBox.Show("Something went wrong. Could not save the reminders.", RemindMeBoxReason.OK);
                }
                else if (possibleException == null) //Success
                {
                    BLIO.Log("No problems encountered (exception null)");
                    MessageFormManager.MakeMessagePopup("Succesfully exported " + GetSelectedRemindersFromListview().Count + " reminders to \\" + new DirectoryInfo(selectedPath).Name, 3);
                }
            }
        }

        private void previewThisReminderNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Reminder rem in GetSelectedRemindersFromListview())
                PreviewReminder(rem);
        }

        private async void previewThisReminderIn5SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Delay(5000);

            foreach (Reminder rem in GetSelectedRemindersFromListview())
                PreviewReminder(rem);
        }

        private async void previewThisReminderIn10SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Delay(10000);

            foreach (Reminder rem in GetSelectedRemindersFromListview())
                PreviewReminder(rem);
        }
        private void PreviewReminder(Reminder rem)
        {
            BLIO.Log("Previewing reminder with id " + rem.Id);
            Reminder previewRem = rem;
            previewRem.Id = -1; //give the >temporary< reminder an invalid id, so that the real reminder won't be altered
            MakeReminderPopup(previewRem);
        }

        /// <summary>
        /// Creates a new instance of popup
        /// </summary>
        private void MakeReminderPopup(Reminder rem)
        {
            Popup p = new Popup(rem);
            p.Show();

        }
        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            UCNewReminder uc = new UCNewReminder(this);
            Form1.ucNewReminder = uc;
            this.Parent.Controls.Add(uc);
            this.Parent.Controls.Remove(this);
        }

        private void lvReminders_DoubleClick(object sender, EventArgs e)
        {
            btnEditReminder_Click(sender, e);
        }

        private void btnEditReminder_Click(object sender, EventArgs e)
        {
            //Fill the form with the data from the single reminder selected from the listview.
            if (lvReminders.SelectedItems.Count == 1)
            {
                //Get the selected listview item
                ListViewItem item = lvReminders.SelectedItems[0];
                //Extract the reminderId from the selected item
                int id = Convert.ToInt32(item.Tag);
                //Create a new UCNewReminder and pass the reminder
                UCNewReminder newRem = new UCNewReminder(this, BLReminder.GetReminderById(id));
                BLIO.Log("Filling form with details of reminder with id " + id + " to edit");
                Form1.ucNewReminder = newRem;
                this.Parent.Controls.Add(newRem);
                this.Parent.Controls.Remove(this);
            }
        }

        private void lvReminders_DragDrop(object sender, DragEventArgs e)
        {
            object source = e.Data.GetData("DragSource");
            if(source != null && source.ToString() == "lvReminders")
            {
                if (RemindMeBox.Show("Do you want to copy the selected reminders?\n\nYou just dragged reminders and dropped them in RemindMe again.",RemindMeBoxReason.YesNo) == DialogResult.No)
                    return;
                //If the user said no, return; else just continue
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            BLIO.Log("File(s) dropped into RemindMe! ( " + files.Length + " file(s) )");
            BLIO.Log(".remindme files: " + files.Where(file => Path.GetExtension(file) == ".remindme").ToList().Count);
            //Loop through each file that is dragged into RemindMe
            foreach (string file in files.Where(file => Path.GetExtension(file) == ".remindme").ToList()) 
            {
                List<object> remindersFromFile = BLReminder.DeserializeRemindersFromFile(file); //Objects from the .remindme file

                foreach (object rem in remindersFromFile.Where(rem => rem.GetType() == typeof(Reminder)).ToList())
                {                    
                    BLReminder.PushReminderToDatabase((Reminder)rem);
                    BLIO.Log("Deserialized reminder and inserted it into RemindMe");
                }
            }
            //finally, refresh the listview
            NotifyChange();
        }

        private void lvReminders_DragEnter(object sender, DragEventArgs e)
        {
            BLIO.Log("Detected file dragging into RemindMe!");
            e.Effect = DragDropEffects.All;
        }

        private void tmrCheckReminder_Tick(object sender, EventArgs e)
        {            
            if (BLReminder.GetReminders().Where(r => r.Enabled == 1).ToList().Count <= 0)
            {
                tmrCheckReminder.Stop(); //No existing reminders? no enabled reminders? stop timer.
                BLIO.Log("Stopping the reminder checking timer, because there are no more (enabled) reminders");
                return;
            }            

            //If a day has passed since the start of RemindMe, we may want to refresh the listview. 
            //There might be reminders happening on this day, if so, we show the time of the reminder, instead of the day
            if (dayOfStartRemindMe < DateTime.Now.Day)
            {
                BLIO.Log("Dawn of a new day -24 hours remaining- ");
                allowRefreshListview = true;
                dayOfStartRemindMe = DateTime.Now.Day;
                MessageFormManager.MakeTodaysRemindersPopup();
            }


            //We will check for reminders here every 5 seconds.
            foreach (Reminder rem in BLReminder.GetReminders())
            {
                //Create the popup. Do the other stuff afterwards.
                if ((rem.PostponeDate != null && Convert.ToDateTime(rem.PostponeDate) <= DateTime.Now && rem.Enabled == 1) || (Convert.ToDateTime(rem.Date.Split(',')[0]) <= DateTime.Now && rem.PostponeDate == null && rem.Enabled == 1))
                {
                    allowRefreshListview = true;
                    //temporarily disable it. When the user postpones the reminder, it will be re-enabled.
                    rem.Enabled = 0;
                    BLReminder.EditReminder(rem);
                    MakeReminderPopup(rem);
                }
                else
                {
                    // -- In this part we will create popups at the users right bottom corner of the screen saying x reminder is happening in 1 hour or x minutes -- \\
                    if (BLSettings.IsHourBeforeNotificationEnabled() && rem.Enabled == 1)
                    {
                        DateTime theDateToCheckOn; //Like this we dont need an if ánd an else with the same code
                        if (rem.PostponeDate != null)
                            theDateToCheckOn = Convert.ToDateTime(rem.PostponeDate);
                        else
                            theDateToCheckOn = Convert.ToDateTime(rem.Date.Split(',')[0]);


                        //The timespan between the date and now.
                        TimeSpan timeSpan = Convert.ToDateTime(theDateToCheckOn) - DateTime.Now;
                        if (timeSpan.TotalMinutes >= 59.50 && timeSpan.TotalMinutes <= 60)
                            remindersToHappenInAnHour.Add(rem);
                    }
                }




            }
            //Refresh the listview. Using the boolean refreshListview, we dont refresh the listview every tick of the timer, that would be very unnecessary
            if (allowRefreshListview)
            {
                BLFormLogic.RefreshListview(lvReminders);

                //set it to false again, otherwise it will continue to refresh every tick
                allowRefreshListview = false;
            }


            string message = "You have " + remindersToHappenInAnHour.Count + " reminders set in 60 minutes:\r\n";
            int count = 1;
            foreach (Reminder rem in remindersToHappenInAnHour)
            {

                if (remindersToHappenInAnHour.Count > 1)
                    message += count + ") " + rem.Name + Environment.NewLine;
                else
                    message = rem.Name + " in 60 minutes!";

                count++;
            }

            if (remindersToHappenInAnHour.Count > 1) //cut off the last \n
            {
                message = message.Remove(message.Length - 2, 2);

                if (!popupMessages.Contains(message)) //Don't create this popup if we have already created it once before
                    MessageFormManager.MakeMessagePopup(message, 8);

                popupMessages.Add(message);
            }
            else if (remindersToHappenInAnHour.Count > 0)
            {
                if (!popupMessages.Contains(message)) //Don't create this popup if we have already created it once before
                    MessageFormManager.MakeMessagePopup(message, 8, remindersToHappenInAnHour[0]);

                popupMessages.Add(message);
            }

            remindersToHappenInAnHour.Clear();
        }

        private void tmrClearMessageCache_Tick(object sender, EventArgs e)
        {
            //Clear the list of messages that have appeared every 2 minutes
            popupMessages.Clear();
        }

        private void hideReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string message = "You can hide reminders with this option. The reminder will not be deleted, you just won't be able to see it"
                 + " in the list of reminders. This creates a sense of surprise.\r\n\r\nDo you wish to hide this reminder?";

            int selectedReminders = GetSelectedRemindersFromListview().Count;
            //Change the message if theres multiple reminders
            if (selectedReminders > 1)
                message = "You can hide reminders with this option. The reminder will not be deleted, you just won't be able to see it"
                 + " in the list of reminders. This creates a sense of surprise.\r\n\r\nDo you wish to hide these reminders?";

            BLIO.Log("Attempting to hide reminder(s)");
            if (BLSettings.HideReminderOptionEnabled || RemindMeBox.Show(message, RemindMeBoxReason.YesNo, true) == DialogResult.Yes)
            {
                //Enable the hide flag here
                foreach (Reminder rem in GetSelectedRemindersFromListview())
                {                    
                    rem.Hide = 1;
                    BLIO.Log("Marked reminder with id " + rem.Id + " as hidden");
                    BLReminder.EditReminder(rem);                   
                }
                foreach (ListViewItem rem in lvReminders.SelectedItems)
                    lvReminders.Items.Remove(rem);

                BLIO.Log(selectedReminders + " reminder(s) hidden");

            }
            else
                BLIO.Log("Attempting to hide reminder(s) failed.");
        }

        private void unHideReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int remindersUnhidden = 0;
            foreach(Reminder rem in BLReminder.GetReminders())
            {
                if (rem.Hide == 1)
                {
                    rem.Hide = 0;
                    remindersUnhidden++;
                }

                BLReminder.EditReminder(rem);
            }
            BLIO.Log(remindersUnhidden + " reminders not hidden anymore");
            BLFormLogic.RefreshListview(lvReminders);
            
        }

        private void lvReminders_ItemDrag(object sender, ItemDragEventArgs e)
        {        
            BLIO.Log("User selected reminder(s) and dragged! (UCReminders)");
            string[] path = { System.IO.Path.GetTempPath() +"\\Exported Reminders.remindme" };
            BLReminder.SerializeRemindersToFile(GetSelectedRemindersFromListview(), path[0] );

            BLIO.Log("doing drag drop!");
            DataObject dataObj = new DataObject(DataFormats.FileDrop, path);
            dataObj.SetData("DragSource", "lvReminders");            
            this.lvReminders.DoDragDrop(dataObj, DragDropEffects.Move);            
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
    }
}
