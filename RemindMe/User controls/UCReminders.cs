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
using System.Runtime.InteropServices;

namespace RemindMe
{
    public partial class UCReminders : UserControl
    {
        //The sizes of the listview column headers. The user can change these and they will be saved.
        private ListviewColumnSizes sizes;
        private static ListView lvRems = null;        
        private static UCReminders instance;

        //Reminders that will pop up the next hour.
        private static List<Reminder> remindersToHappenInAnHour = new List<Reminder>();

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        private static int dayOfStartRemindMe = DateTime.Now.Day;

        private List<string> popupMessages = new List<string>();

        //The "page" we're on. If the user has 10 reminders and presses "next page", he should see 3 reminders (7 reminders max on 1 page, second page shows the last 3). 
        //The page number will be 2 in that case
        int pageNumber = 1;

        //The instance of the user control that lets an user alter a reminder.
        private static UCNewReminder newReminderUc;


        public UCReminders()
        {
            InitializeComponent();
            sizes = BLListviewColumnSizes.GetcolumnSizes();            
            ReminderMenuStrip.Renderer = new MyToolStripMenuRenderer();
                                           
            instance = this;

            if (BLReminder.GetReminders().Count == 0)
                pnlReminders.BackgroundImage = Properties.Resources.NoReminders2;            
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

              

        public void Initialize()
        {
            BLIO.Log("Loading reminders from database");
            //Give initial value to newReminderUc 
            newReminderUc = new UCNewReminder(this);
            newReminderUc.Visible = false;
            newReminderUc.saveState = false;
            this.Parent.Controls.Add(newReminderUc);


            Form1.Instance.ucNewReminder = newReminderUc;
            //BLFormLogic.AddRemindersToListview(lvReminders, BLReminder.GetReminders().Where(r => r.Hide == 0).ToList()); //Get all "active" reminders);   

            BLIO.Log("Starting the reminder timer");
            tmrCheckReminder.Start();

            pnlReminders.Visible = true;

            pnlReminders.DragDrop += UCReminders_DragDrop;
            pnlReminders.DragEnter += UCReminders_DragEnter;


            int counter = 0;
            foreach (Reminder rem in BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0))
            {
                if (pnlReminders.Controls.Count >= 7) break; //Only 7 reminders on 1 page

                pnlReminders.Controls.Add(new UCReminderItem(rem));

                if (counter > 0)
                    pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                counter++;
            }

            foreach (Reminder rem in BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0))
            {
                if (pnlReminders.Controls.Count >= 7) break;

                pnlReminders.Controls.Add(new UCReminderItem(rem));

                if (counter > 0)
                    pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                counter++;
            }

            if (BLReminder.GetReminders().Count < 7) //Less than 7 reminders, let's fit in some invisible UCReminderItem 's
            {
                for (int i = BLReminder.GetReminders().Count; i < 7; i++)
                {
                    pnlReminders.Controls.Add(new UCReminderItem(null));

                    if (counter > 0)
                        pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                    counter++;
                }
            }
            int test = pnlReminders.Controls.Count;
            if (BLReminder.GetReminders().Where(r => r.Hide == 0).ToList().Count <= 7)
                Form1.Instance.UpdatePageNumber(-1); //Tell form1 that there are not more than 1 pages
            else
            {
                btnNextPage.Iconimage = Properties.Resources.NextWhite;
                Form1.Instance.UpdatePageNumber(pageNumber);
            }
        }
        
        
        private void AddRemindersToPanel()
        {
            Point loc = new Point(10,10);
            UCReminderItem itm = null;
            foreach (Reminder rem in BLReminder.GetReminders())
            {
                if (itm != null)
                    loc = new Point(loc.X, (itm.Location.Y + itm.Height) + 10);
                
                itm = new UCReminderItem(rem);                
                itm.Location = loc;
                pnlReminders.Controls.Add(itm);
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
            newReminderUc.Visible = true;
            newReminderUc.Reminder = null;            
            this.Visible = false;
        }

        private void lvReminders_DoubleClick(object sender, EventArgs e)
        {
            btnEditReminder_Click(sender, e);
        }

        private void btnEditReminder_Click(object sender, EventArgs e)
        {
            
        }
        public void EditReminder(Reminder rem)
        {            
            newReminderUc.Reminder = BLReminder.GetReminderById(rem.Id);
            BLIO.Log("Filling form with details of reminder with id " + rem.Id + " to edit");
            Form1.Instance.ucNewReminder = newReminderUc;
            this.Visible = false;
            newReminderUc.Visible = true;
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
                UpdateCurrentPage();
                dayOfStartRemindMe = DateTime.Now.Day;
                MessageFormManager.MakeTodaysRemindersPopup();
            }


            //We will check for reminders here every 5 seconds.
            foreach (Reminder rem in BLReminder.GetReminders())
            {
                //Create the popup. Do the other stuff afterwards.
                if ((rem.PostponeDate != null && Convert.ToDateTime(rem.PostponeDate) <= DateTime.Now && rem.Enabled == 1) || (Convert.ToDateTime(rem.Date.Split(',')[0]) <= DateTime.Now && rem.PostponeDate == null && rem.Enabled == 1))
                {                    
                    //temporarily disable it. When the user postpones the reminder, it will be re-enabled.
                    rem.Enabled = 0;
                    BLReminder.EditReminder(rem);
                    MakeReminderPopup(rem);
                    UpdateCurrentPage();
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

       
        private void pnlReminders_ControlAdded(object sender, ControlEventArgs e)
        {
            //Check if the scrollbar is visible
            if (pnlReminders.VerticalScroll.Visible)
            {
                //Reduce the length of the items
                foreach (UCReminderItem itm in pnlReminders.Controls)
                    itm.Size = new Size(650, itm.Size.Height);
            }
            else
            {
                if(pnlReminders.Controls.Count >= 6)
                {
                    //Reduce the length of the items
                    foreach (UCReminderItem itm in pnlReminders.Controls)
                        itm.Size = new Size(itm.Size.Width - 20, itm.Size.Height);
                }
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (pageNumber <= 1) //Can't go to the previous page if we're on the first one
                return;

            List<Reminder> reminders = BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).ToList();
            reminders.AddRange(BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0));
            //^ All reminders in one list with the disabled ones at the end of the list

            int reminderItemCounter = 0;
            for (int i = (pageNumber-2) * 7; i < ((pageNumber-2) * 7) + 7; i++)
            {
                if (reminders.Count - 1 >= i) //Safely within index numbers
                {
                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    UCReminderItem itm = (UCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    itm.Visible = true;
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.UpdateReminder(reminders[i]);

                }
                
                reminderItemCounter++;

                if (reminderItemCounter == 7)
                    break;
            }

            pageNumber--;
            Form1.Instance.UpdatePageNumber(pageNumber);

            SetPageButtonIcons(reminders);

        }

        public void SetPageButtonIcons(List<Reminder> reminders)
        {
            //Previous/next icons
            if ((pageNumber * 7) + 1 > reminders.Count)
                btnNextPage.Iconimage = Properties.Resources.NextGray1;
            else
                btnNextPage.Iconimage = Properties.Resources.NextWhite;

            if (pageNumber <= 1) //Can't go to the previous page if we're on the first one            
                btnPreviousPage.Iconimage = Properties.Resources.PreviousGray1;
            else
                btnPreviousPage.Iconimage = Properties.Resources.PreviousWhite;
        }
        //Display changes on the current page. (For example a deleted or enabled/disabled reminder)
        public void UpdateCurrentPage()
        {            
            List<Reminder> reminders = BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).ToList();
            reminders.AddRange(BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0));
            //^ All reminders in one list with the disabled ones at the end of the list

            startMethod:
            if ((pageNumber * 7) + 1 > reminders.Count)           
                btnNextPage.Iconimage = Properties.Resources.NextGray1;            
            else
                btnNextPage.Iconimage = Properties.Resources.NextWhite;


            int reminderItemCounter = 0;
            for (int i = (pageNumber - 1) * 7; i < ((pageNumber) * 7); i++)
            {
                if (reminders.Count - 1 >= i) //Safely within index numbers
                {
                    if (reminderItemCounter >= pnlReminders.Controls.Count)
                        return;

                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    UCReminderItem itm = (UCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    itm.Visible = true;
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.UpdateReminder(reminders[i]);
                }
                else
                {
                    //User deleted a reminder, which was the last one out of the list from that page. Navigate to the previous page.
                    if (i % 7 == 0 && pageNumber > 1)
                    {
                        pageNumber--;
                        goto startMethod;
                    }

                    for (int ii = i; ii < 7; ii++)
                    {
                        if (ii >= pnlReminders.Controls.Count)
                            break;

                        UCReminderItem itm = (UCReminderItem)pnlReminders.Controls[ii];
                        itm.Visible = false;
                    }
                    break;

                }

                reminderItemCounter++;

                if (reminderItemCounter == 7)
                    break;
            }
            if (reminders.Count <= 7)
                Form1.Instance.UpdatePageNumber(-1);
            else
                Form1.Instance.UpdatePageNumber(pageNumber);

            if (GetInstance() != null)
                GetInstance().tmrCheckReminder.Start();


            //Change background if there are no reminders left                                        
            if (BLReminder.GetReminders().Where(r => r.Hide == 0).ToList().Count == 0)
                pnlReminders.BackgroundImage = Properties.Resources.NoReminders2;
            else
                pnlReminders.BackgroundImage = Properties.Resources.RemindMeGradient;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            List<Reminder> reminders = BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).ToList();
            reminders.AddRange(BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0));
            //^ All reminders in one list with the disabled ones at the end of the list
            

            if (  (pageNumber * 7) +1 > reminders.Count)                           
                return; //No reminders left
            

            int reminderItemCounter = 0;
            for(int i = pageNumber*7; i < (pageNumber * 7)+7; i++)
            {
                if(reminders.Count-1 >= i) //Safely within index numbers
                {
                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    UCReminderItem itm = (UCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    itm.Visible = true;
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.UpdateReminder(reminders[i]);
                    
                }
                else //hide all remaining controls that can't be filled with reminders, since there are no reminders left
                {
                    for(int ii = reminderItemCounter; ii < 7; ii++)                                           
                        pnlReminders.Controls[ii].Visible = false;                    
                }
                reminderItemCounter++;
            }

            pageNumber++;
            if ((pageNumber * 7) + 1 > reminders.Count)
                btnNextPage.Iconimage = Properties.Resources.NextGray1;
            else
                btnNextPage.Iconimage = Properties.Resources.NextWhite;

            if (pageNumber > 1) 
                btnPreviousPage.Iconimage = Properties.Resources.PreviousWhite;

            Form1.Instance.UpdatePageNumber(pageNumber);
        }

        public void RefreshPage()
        {
            if (pageNumber > 1)
            {
                btnPreviousPage_Click(null, null);
                btnNextPage_Click(null, null);
            }
        }
       

  
   
        private void UCReminders_DragEnter(object sender, DragEventArgs e)
        {
            BLIO.Log("Detected file dragging into RemindMe!");
            e.Effect = DragDropEffects.All;
        }

        private void UCReminders_DragDrop(object sender, DragEventArgs e)
        {

            object source = e.Data.GetData("DragSource");
            if (source != null && source.ToString() == "lvReminders")
            {
                if (RemindMeBox.Show("Do you want to copy the selected reminders?\n\nYou just dragged reminders and dropped them in RemindMe again.", RemindMeBoxReason.YesNo) == DialogResult.No)
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
            UpdateCurrentPage();
        }

        private void btnUnhideReminders_Click(object sender, EventArgs e)
        {
            int remindersUnhidden = 0;
            foreach (Reminder rem in BLReminder.GetReminders())
            {
                if (rem.Hide == 1)
                {
                    rem.Hide = 0;
                    remindersUnhidden++;
                }

                BLReminder.EditReminder(rem);
            }
            BLIO.Log(remindersUnhidden + " reminders not hidden anymore");
            UpdateCurrentPage();
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            List<Reminder> reminders = BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).ToList();
            reminders.AddRange(BLReminder.GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0));

            if (this.Visible)
                SetPageButtonIcons(reminders);
        }

       
        
    }
}
