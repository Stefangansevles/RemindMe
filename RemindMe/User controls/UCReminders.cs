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
using System.Threading;

namespace RemindMe
{
    public partial class UCReminders : UserControl
    {                
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
                                           
            instance = this;

            if (BLReminder.GetReminders().Count == 0)
                pnlReminders.BackgroundImage = Properties.Resources.NoReminders2;            
        }

        public static UCReminders Instance
        {
            get
            {
                return instance;
            }
            
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
            List<Reminder> activeReminders = BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).ToList();
            List<Reminder> disabledReminders = BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).ToList();

            foreach (Reminder rem in activeReminders)
            {                                
                if (pnlReminders.Controls.Count >= 7) break; //Only 7 reminders on 1 page

                pnlReminders.Controls.Add(new UCReminderItem(rem));

                if (counter > 0)
                    pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                counter++;
            }

            foreach (Reminder rem in disabledReminders)
            {
                if (pnlReminders.Controls.Count >= 7) break;

                pnlReminders.Controls.Add(new UCReminderItem(rem));

                if (counter > 0)
                    pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                counter++;
            }

            if (activeReminders.Count + disabledReminders.Count < 7) //Less than 7 reminders, let's fit in some empty UCReminderItem 's
            {
                for (int i = (activeReminders.Count + disabledReminders.Count); i < 7; i++)
                {
                    pnlReminders.Controls.Add(new UCReminderItem(null));

                    if (counter > 0)
                        pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                    counter++;
                }
            }
            
            if (BLReminder.GetReminders().Where(r => r.Hide == 0).ToList().Count <= 7)
                Form1.Instance.UpdatePageNumber(-1); //Tell form1 that there are not more than 1 pages
            else
            {
                btnNextPage.Iconimage = Properties.Resources.NextWhite;
                Form1.Instance.UpdatePageNumber(pageNumber);
            }
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
      
        public void EditReminder(Reminder rem)
        {
            if (rem != null)
            {
                newReminderUc.Reminder = BLReminder.GetReminderById(rem.Id);
                BLIO.Log("Filling form with details of reminder with id " + rem.Id + " to edit");
                Form1.Instance.ucNewReminder = newReminderUc;
                this.Visible = false;
                newReminderUc.Visible = true;
            }
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
                RemindMeMessageFormManager.MakeTodaysRemindersPopup();
                //Update lastOnline. If you keep RemindMe running and put your pc to sleep instead of turning it off, it would never get updated without this                
                BLOnlineDatabase.InsertOrUpdateUser(BLSettings.Settings.UniqueString);
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
                    RemindMeMessageFormManager.MakeMessagePopup(message, 6);

                popupMessages.Add(message);
            }
            else if (remindersToHappenInAnHour.Count > 0)
            {
                if (!popupMessages.Contains(message)) //Don't create this popup if we have already created it once before
                    RemindMeMessageFormManager.MakeMessagePopup(message, 6, remindersToHappenInAnHour[0]);

                popupMessages.Add(message);
            }

            remindersToHappenInAnHour.Clear();
        }

        private void tmrClearMessageCache_Tick(object sender, EventArgs e)
        {
            //Clear the list of messages that have appeared every 2 minutes
            popupMessages.Clear();
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
                    itm.Reminder = reminders[i];

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
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.Reminder = reminders[i];
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
                        itm.Reminder = null;
                    }                    

                    //This happens when an reminder has been deleted, and there are less than 7 reminders on that page. Empty out the remaining reminder items. 
                    while (reminderItemCounter <= 6)
                    {
                        //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                        UCReminderItem itm = (UCReminderItem)pnlReminders.Controls[reminderItemCounter];
                        //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                        itm.Reminder = null;

                        reminderItemCounter++;
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

            if (Instance != null)
                Instance.tmrCheckReminder.Start();            
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
                    itm.Reminder = reminders[i];
                    
                }
                else //hide all remaining controls that can't be filled with reminders, since there are no reminders left
                {
                    for(int ii = reminderItemCounter; ii < 7; ii++)
                        ((UCReminderItem)pnlReminders.Controls[ii]).Reminder = null;
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            BLIO.Log(files.Length + " File(s) dropped into RemindMe!");
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

            new Thread(() =>
            {
                //Log an entry to the database, for data!
                BLOnlineDatabase.ImportCount++;
            }).Start();

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

        private void UCReminders_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                BLIO.Log("Control UCReminders now visible");
        }

        private void UCReminders_Load(object sender, EventArgs e)
        {
            /*This was testing a custom color scheme
            btnAddReminder.BackgroundImage = Form1.Instance.pnlSideBackgroundImage;
            btnPreviousPage.BackgroundImage = Form1.Instance.pnlSideBackgroundImage;
            btnNextPage.BackgroundImage = Form1.Instance.pnlSideBackgroundImage;
            btnUnhideReminders.BackgroundImage = Form1.Instance.pnlSideBackgroundImage;*/
        }
    }
}
