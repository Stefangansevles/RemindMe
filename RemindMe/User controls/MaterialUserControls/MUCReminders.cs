using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Business_Logic_Layer;
using Database.Entity;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace RemindMe
{
    public partial class MUCReminders : UserControl
    {
        private static MUCReminders instance;

        //Reminders that will pop up the next hour.
        private static List<Reminder> remindersToHappenInAnHour = new List<Reminder>();

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        private static int dayOfStartRemindMe = DateTime.Now.Day;

        private List<string> popupMessages = new List<string>();
        private Dictionary<Reminder, System.Windows.Forms.Timer> httpTimers = new Dictionary<Reminder, System.Windows.Forms.Timer>();

        //The "page" we're on. If the user has 10 reminders and presses "next page", he should see 3 reminders (7 reminders max on 1 page, second page shows the last 3). 
        //The page number will be 2 in that case
        int pageNumber = 1;

        //The instance of the user control that lets an user alter a reminder.
        private MUCNewReminder newReminderUc;
        public bool showUpdateMessage = true;
        public MUCReminders()
        {
            InitializeComponent();
            instance = this;
        }


        /// <summary>
        /// Gets the timer object from the KeyValuePair<Reminder, Timer>
        /// </summary>        
        /// <returns></returns>
        private System.Windows.Forms.Timer GetTimer(Reminder rem)
        {
            var kvp = httpTimers.Where(r => r.Key.Id == rem.Id).FirstOrDefault();
            return kvp.Value;
        }
        private void RemoveTimer(Reminder rem)
        {
            Reminder del = httpTimers.Where(r => r.Key.Id == rem.Id).FirstOrDefault().Key;
            System.Windows.Forms.Timer timer = httpTimers.Where(r => r.Key.Id == rem.Id).FirstOrDefault().Value;

            if (del != null)
                httpTimers.Remove(del);

            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
        public static MUCReminders Instance
        {
            get
            {
                return instance;
            }

        }
        private async void ExecuteHttpRequest(object sender, EventArgs e, HttpRequests http, Reminder rem)
        {
            try
            {               
                if (!BLIO.HasInternetAccess())                    
                {
                    BLIO.Log("Cancelling ExecuteHttpRequest(). No internet access");
                    return;
                }

                BLIO.Log("ExecuteHttpRequest timer tick! [ " + http.URL + " ]");
                if (httpTimers.Where(t => t.Key.Id == rem.Id) == null)
                {
                    BLIO.Log("Attempted to ExecuteHttpRequest() from a timer that no longer exists. Cancelling.");
                    return;
                }
                
                JObject response = await BLIO.HttpRequest(http.Type, http.URL, http.OtherHeaders, http.AcceptHeader, http.ContentTypeHeader, http.Body);                


                

                List<HttpCondition> conditions = new List<HttpCondition>();                
                foreach(HttpRequestCondition cond in BLLocalDatabase.HttpRequestConditions.GetConditions(http.Id))                
                    conditions.Add(new HttpCondition(cond, response));                

                bool conditionMet = conditions.Count > 0;
                foreach (HttpCondition con in conditions) //Check for ALL conditions and see if all of them return true
                {
                    if (!con.Evaluate())
                        conditionMet = false;
                }

                if (conditionMet)
                {
                    //All conditions returned true!

                    MakeReminderPopup(rem);

                    if (http.AfterPopup == "Stop")
                    {
                        var timer = GetTimer(rem);
                        if (timer != null)
                        {
                            timer.Stop();

                            //remove from dictionary
                            httpTimers.Remove(rem);
                        }
                    }
                }
                else BLIO.Log("ExecuteHttpRequest returned FALSE");
            }
            catch(Exception ex)
            {
                BLIO.Log("ExecuteHttpRequest() Failed. " + ex.GetType().ToString());
            }
        }
        
        public void Initialize()
        {
            try
            {                
                MaterialSkin.MaterialSkinManager.Themes theme = MaterialSkin.MaterialSkinManager.Instance.Theme;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                List<Reminder> corruptedReminders = BLReminder.CheckForCorruptedReminders();

                if (corruptedReminders != null)
                {
                    string message = "RemindMe has detected";
                    if (corruptedReminders.Count > 1)
                    {
                        message += " problems with the following reminders: \r\n";

                        foreach (Reminder rem in corruptedReminders)
                            message += "- " + rem.Name + "\r\n";

                        message += "\r\nThey have been removed from your list of reminders.";
                    }
                    else
                    {
                        message += " a problem with the reminder:\r\n\"" + corruptedReminders[0].Name + "\". \r\nIt has been removed from your list of reminders.";
                    }

                    MaterialMessageFormManager.MakeMessagePopup(message, 0);
                }

                BLIO.Log("Loading reminders from database");
                //Give initial value to newReminderUc 
                newReminderUc = new MUCNewReminder(this);
                newReminderUc.Visible = false;
                newReminderUc.saveState = false;
                this.Parent.Controls.Add(newReminderUc);


                //MaterialForm1.Instance.ucNewReminder = newReminderUc;
                //BLFormLogic.AddRemindersToListview(lvReminders, BLReminder.GetReminders().Where(r => r.Hide == 0).ToList()); //Get all "active" reminders);   

                BLIO.Log("Starting the reminder timer");
                tmrCheckReminder.Start();

                pnlReminders.Visible = true;

                pnlReminders.DragDrop += MUCReminders_DragDrop;
                pnlReminders.DragEnter += MUCReminders_DragEnter;


                int counter = 0;
                //List<Reminder> reminders = BLReminder.GetOrderedReminders();
                List<Reminder> conditionalReminders = BLReminder.GetReminders(true).Where(r => r.HttpId != null).Where(r => r.Hide == 0).Where(r => r.Enabled == 1).ToList();
                List<Reminder> activeReminders = BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).ToList();
                List<Reminder> disabledReminders = BLReminder.GetReminders().Where(r => r.Hide == 0).OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).ToList();

                //we've got postponed reminders, now do this
                if (BLReminder.GetReminders().Where(r => !string.IsNullOrWhiteSpace(r.PostponeDate)).ToList().Count > 0)
                    activeReminders = OrderPostponedReminders();
                
                foreach (Reminder rem in activeReminders)
                {
                    if (pnlReminders.Controls.Count >= 7) break; //Only 7 reminders on 1 page

                    pnlReminders.Controls.Add(new MUCReminderItem(rem));

                    if (counter > 0)
                        pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                    counter++;
                }
                foreach (Reminder rem in conditionalReminders)
                {
                    if (pnlReminders.Controls.Count >= 7) break; //Only 7 reminders on 1 page

                    pnlReminders.Controls.Add(new MUCReminderItem(rem));

                    if (counter > 0)
                        pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                    counter++;
                }
                foreach (Reminder rem in disabledReminders)
                {
                    if (pnlReminders.Controls.Count >= 7) break;

                    pnlReminders.Controls.Add(new MUCReminderItem(rem));

                    if (counter > 0)
                        pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                    counter++;
                }

                if (activeReminders.Count + disabledReminders.Count < 7) //Less than 7 reminders, let's fit in some empty MUCReminderItem 's
                {
                    for (int i = (activeReminders.Count + disabledReminders.Count); i < 7; i++)
                    {
                        pnlReminders.Controls.Add(new MUCReminderItem(null));
                        
                        if (counter > 0)
                            pnlReminders.Controls[counter].Location = new Point(0, pnlReminders.Controls[counter - 1].Location.Y + pnlReminders.Controls[counter - 1].Size.Height);

                        counter++;
                    }
                }

                if (BLReminder.GetReminders().Where(r => r.Hide == 0).ToList().Count <= 7)
                    MaterialForm1.Instance.UpdatePageNumber(-1); //Tell MaterialForm1 that there are not more than 1 pages
                else
                {
                    if(theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                        btnNextPage.Icon = Properties.Resources.NextWhite;
                    else
                        btnNextPage.Icon = Properties.Resources.nextDark;

                    MaterialForm1.Instance.UpdatePageNumber(pageNumber);
                }

                //Just design, no logic here. Drags the color panel a bit down and shrink it so it doesnt overlap over the shadow
                MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[0];
                itm.pnlSideColor.Size = new Size(itm.pnlSideColor.Width, itm.pnlSideColor.Height - 4);
                itm.pnlSideColor.Location = new Point(itm.pnlSideColor.Location.X, itm.pnlSideColor.Location.Y + 4);


                //Http requests
                foreach (Reminder rem in conditionalReminders)
                {
                    HttpRequests httpObj = BLLocalDatabase.HttpRequest.GetHttpRequestById((long)rem.Id);

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();                    
                    timer.Interval = Convert.ToInt32(httpObj.Interval * 60000);
                    timer.Tick += (object s, EventArgs a) => ExecuteHttpRequest(s, a, httpObj, rem);

                    httpTimers.Add(rem, timer);
                    timer.Start();
                }

                stopwatch.Stop();
                BLIO.Log("MUCReminders Initialize took " + stopwatch.ElapsedMilliseconds + " ms");
            }
            catch (Exception ex)
            {
                BLIO.Log("MUCReminders.Initialize() FAILED. Type -> " + ex.GetType().ToString());
                BLIO.Log("Message -> " + ex.Message);
            }
        }

      

        /// <summary>
        /// Change this user controls's icons based on the theme
        /// </summary>
        /// <param name="theme"></param>
        public void UpdateTheme(MaterialSkin.MaterialSkinManager.Themes theme)
        {

            if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
            {
                btnAddReminder.Icon = Properties.Resources.Plus_white;
                btnPreviousPage.Icon = Properties.Resources.PreviousWhite;
                btnNextPage.Icon = Properties.Resources.NextWhite;
                btnUnhideReminders.Icon = Properties.Resources.eyeWhite;
            }
            else
            {//Light
                btnAddReminder.Icon = Properties.Resources.plusDark;
                btnPreviousPage.Icon = Properties.Resources.previousDark;
                btnNextPage.Icon = Properties.Resources.nextDark;
                btnUnhideReminders.Icon = Properties.Resources.eyeDark;
            }

            //also update each uc in pnlreminders
            foreach (Control c in pnlReminders.Controls)
            {
                if (c is MUCReminderItem)
                {
                    MUCReminderItem m = (MUCReminderItem)c;
                    m.UpdateTheme(null);
                }
            }

            SetPageButtonIcons(BLReminder.GetReminders());
        }

        /// <summary>
        /// Creates a new instance of popup
        /// </summary>
        private void MakeReminderPopup(Reminder rem)
        {
            MaterialPopup p = new MaterialPopup(rem);
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(p);
            p.Show();

        }
        public void btnAddReminder_Click(object sender, EventArgs e)
        {            
            BLIO.Log("btnAddReminder_Click");
            this.Visible = false;
            newReminderUc.Reminder = null;

            if (newReminderUc.AVRForm != null && !newReminderUc.AVRForm.IsDisposed)
            {
                newReminderUc.AVRForm.Dispose();
                newReminderUc.AVRForm = null;
            }

            newReminderUc.Visible = true;                       
            GC.Collect();
        }

        public void EditReminder(Reminder rem)
        {
            if (rem != null)
            {
                BLIO.Log("Edit button clicked on reminder item (" + rem.Id + ")");
                newReminderUc.Reminder = BLReminder.GetReminderById(rem.Id);
                BLIO.Log("Filling form with details of reminder with id " + rem.Id + " to edit");
                //MaterialForm1.Instance.mucReminders = newReminderUc;
                this.Visible = false;
                newReminderUc.Visible = true;
            }
        }



        private void tmrCheckReminder_Tick(object sender, EventArgs e)
        {
            try
            {
                bool isHourBeforeNotificationEnabled = BLLocalDatabase.Setting.IsHourBeforeNotificationEnabled();
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
                    MaterialMessageFormManager.MakeTodaysRemindersPopup();
                    //Update lastOnline. If you keep RemindMe running and put your pc to sleep instead of turning it off, it would never get updated without this                
                    BLOnlineDatabase.InsertOrUpdateUser(BLLocalDatabase.Setting.Settings.UniqueString);
                }


                //We will check for reminders here every 5 seconds.
                foreach (Reminder rem in BLReminder.GetReminders().Where(r => r.Enabled == 1).ToList())
                {
                    //Create the popup. Do the other stuff afterwards.
                    if ((rem.PostponeDate != null && Convert.ToDateTime(rem.PostponeDate) <= DateTime.Now) || (Convert.ToDateTime(rem.Date.Split(',')[0]) <= DateTime.Now && rem.PostponeDate == null && rem.Enabled == 1))
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
                        if (isHourBeforeNotificationEnabled)
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
                    //Don't show "reminderName in 60 minutes!" if the reminder doesn't "Show" when popped up, silent reminders.
                    if (BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id) != null && BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id).ShowReminder != 1)
                        continue;

                    if (remindersToHappenInAnHour.Count > 1)
                        message += count + ") " + rem.Name + Environment.NewLine;
                    else
                        message = rem.Name + " in 60 minutes!";

                    count++;
                }

                if (remindersToHappenInAnHour.Count > 1 && count > 1) //cut off the last \n
                {
                    message = message.Remove(message.Length - 2, 2);

                    if (!popupMessages.Contains(message)) //Don't create this popup if we have already created it once before
                        MaterialMessageFormManager.MakeMessagePopup(message, 6);

                    popupMessages.Add(message);
                }
                else if (remindersToHappenInAnHour.Count > 0 && count > 1)
                {
                    if (!popupMessages.Contains(message)) //Don't create this popup if we have already created it once before
                        MaterialMessageFormManager.MakeMessagePopup(message, 6, remindersToHappenInAnHour[0]);

                    popupMessages.Add(message);
                }

                remindersToHappenInAnHour.Clear();
            }
            catch (Exception ex)
            {
                BLIO.Log("CheckReminder FAILED!!! " + ex.GetType().ToString());
                BLIO.WriteError(ex, "!!! Error in tmrCheckReminder_Tick");
            }
        }

        private void tmrClearMessageCache_Tick(object sender, EventArgs e)
        {
            //Clear the list of messages that have appeared every 2 minutes
            popupMessages.Clear();
        }


        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnPreviousPage_Click");
            

            if (pageNumber <= 1) //Can't go to the previous page if we're on the first one
                return;

            List<Reminder> reminders = BLReminder.GetOrderedReminders();

            int reminderItemCounter = 0;
            for (int i = (pageNumber - 2) * 7; i < ((pageNumber - 2) * 7) + 7; i++)
            {
                if (reminders.Count - 1 >= i) //Safely within index numbers
                {
                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    itm.Visible = true;
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.Reminder = reminders[i];

                }

                reminderItemCounter++;

                if (reminderItemCounter == 7)
                    break;
            }

            pageNumber--;            

            SetPageButtonIcons(reminders);
            foreach (MUCReminderItem itm in pnlReminders.Controls)
                itm.RefreshLabelFont();

            GC.Collect();
        }

        public void SetPageButtonIcons(List<Reminder> reminders)
        {
            MaterialSkin.MaterialSkinManager.Themes theme = MaterialSkin.MaterialSkinManager.Instance.Theme;

            //Previous/next icons
            if ((pageNumber * 7) + 1 > reminders.Count)
            {
                btnNextPage.Icon = Properties.Resources.nextDisabledDark;
            }
            else
            {
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnNextPage.Icon = Properties.Resources.NextWhite;
                else
                    btnNextPage.Icon = Properties.Resources.nextDark;
            }

            if (pageNumber <= 1) //Can't go to the previous page if we're on the first one            
                btnPreviousPage.Icon = Properties.Resources.previousDisabledDark;
            else
            {
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnPreviousPage.Icon = Properties.Resources.PreviousWhite;
                else
                    btnPreviousPage.Icon = Properties.Resources.previousDark;
            }
        }

        /// <summary>
        /// Display changes on the current page. (For example a deleted or enabled/disabled reminder)
        /// </summary>
        /// <param name="editedReminder">If a reminder has been edited, this object will contain that reminder</param>
        public void UpdateCurrentPage(Reminder editedReminder = null)
        {            
            MaterialSkin.MaterialSkinManager.Themes theme = MaterialSkin.MaterialSkinManager.Instance.Theme;

            BLIO.Log("Starting UpdateCurrentPage()...");

            //Reminder list containing normal reminders and conditional reminders, enabled and disabled
            List<Reminder> reminders = BLReminder.GetOrderedReminders();

            //^ All reminders in one list with the disabled ones at the end of the list
            BLIO.Log(reminders.Count + " reminders loaded");

            startMethod:
            if ((pageNumber * 7) + 1 > reminders.Count)
            {                
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnNextPage.Icon = Properties.Resources.nextDisabledDark;
                else
                    btnNextPage.Icon = Properties.Resources.nextDisabledDark;
            }
            else
            {
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnNextPage.Icon = Properties.Resources.NextWhite;
                else
                    btnNextPage.Icon = Properties.Resources.nextDark;
            }

            int reminderItemCounter = 0;
            for (int i = (pageNumber - 1) * 7; i < ((pageNumber) * 7); i++)
            {
                if (reminders.Count - 1 >= i) //Safely within index numbers
                {
                    if (reminderItemCounter >= pnlReminders.Controls.Count)
                        return;

                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.Reminder = reminders[i];
                    itm.RefreshLabelFont();
                }
                else
                {
                    //User deleted a reminder, which was the last one out of the list from that page. Navigate to the previous page.
                    if (i % 7 == 0 && pageNumber > 1)
                    {
                        BLIO.Log("navigating to the previous page after deletion of an reminder...");
                        pageNumber--;
                        goto startMethod;
                    }

                    for (int ii = i; ii < 7; ii++)
                    {
                        if (ii >= pnlReminders.Controls.Count)
                            break;

                        MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[ii];
                        itm.Reminder = null;
                    }

                    //This happens when an reminder has been deleted, and there are less than 7 reminders on that page. Empty out the remaining reminder items. 
                    while (reminderItemCounter <= 6)
                    {
                        BLIO.Log("Detected the deletion of an reminder on the current page.");
                        //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                        try
                        {
                            MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[reminderItemCounter];

                            if (itm.Reminder != null)
                                BLIO.Log("Emptying ReminderItem with ID " + itm.Reminder.Id);
                            //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                            itm.Reminder = null;

                            reminderItemCounter++;
                        }   
                        catch(Exception ex)
                        {
                            BLIO.Log("Setting new Reminder value failed. -> " + ex.GetType().ToString());
                        }                                                
                    }

                    break;
                }

                reminderItemCounter++;

                if (reminderItemCounter == 7)
                    break;
            }



            if (reminders.Count <= 7)
                MaterialForm1.Instance.UpdatePageNumber(-1);
            else
                MaterialForm1.Instance.UpdatePageNumber(pageNumber);

            if (Instance != null)
                Instance.tmrCheckReminder.Start();


            if (editedReminder != null && editedReminder.HttpId != null)
            {
                //This object has been altered. Deleted, Perma-deleted, edited OR disabled
                if (BLReminder.GetReminderById(editedReminder.Id) == null || editedReminder.Deleted > 0 || editedReminder.Enabled == 0)
                {
                    //perma-deleted, soft-deleted or turned off
                    if(GetTimer(editedReminder) != null)
                        GetTimer(editedReminder).Stop();
                    RemoveTimer(editedReminder);                    
                }
                else //Reminder is still active, so it probably has been edited
                {
                    HttpRequests httpObj = BLLocalDatabase.HttpRequest.GetHttpRequestById((long)editedReminder.Id);                    
                    var kvp = httpTimers.Where(r => r.Key.Id == editedReminder.Id).FirstOrDefault();
                    if (kvp.Key != null)
                    {
                        //Already exist, stop timer, change & restart
                        RemoveTimer(editedReminder);                        
                        var timer = new System.Windows.Forms.Timer();
                        timer.Interval = Convert.ToInt32(httpObj.Interval * 60000);
                        timer.Tick += (object s, EventArgs a) => ExecuteHttpRequest(s, a, httpObj, editedReminder);
                        timer.Start();
                        httpTimers.Add(editedReminder, timer);
                    }
                    else if(editedReminder.Enabled == 1) //Reminder has been re-enabled
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        httpTimers.Add(editedReminder, timer);
                        timer.Interval = Convert.ToInt32(httpObj.Interval * 60000);
                        timer.Tick += (object s, EventArgs a) => ExecuteHttpRequest(s, a, httpObj, editedReminder);
                        timer.Start();
                    }                    
                }
            }
            else
            {
                //Http requests
                foreach (Reminder rem in BLReminder.GetReminders(true).Where(r => r.HttpId != null).Where(r => r.Enabled == 1))
                {
                    HttpRequests httpObj = BLLocalDatabase.HttpRequest.GetHttpRequestById((long)rem.Id);

                    if (GetTimer(rem) == null)
                    {
                        //Don't add duplicates                                        
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        httpTimers.Add(rem, timer);
                        timer.Interval = Convert.ToInt32(httpObj.Interval * 60000);
                        timer.Tick += (object s, EventArgs a) => ExecuteHttpRequest(s, a, httpObj, rem);
                        timer.Start();
                    }
                }
            }



            BLIO.Log("UpdateCurrentPage() completed.");
        }

        private List<Reminder> OrderPostponedReminders()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Reminder> reminders = BLReminder.GetReminders().Where(r => r.Enabled == 1).Where(r => r.Hide == 0).Where(r => string.IsNullOrWhiteSpace(r.PostponeDate)).ToList();
            List<Reminder> postPonedReminders = BLReminder.GetReminders().Where(r => r.Enabled == 1).Where(r => r.Hide == 0).Where(r => !string.IsNullOrWhiteSpace(r.PostponeDate)).ToList();

            Dictionary<long, DateTime> orderedReminders = new Dictionary<long, DateTime>();

            foreach (Reminder rem in reminders)
                orderedReminders.Add(rem.Id, Convert.ToDateTime(rem.Date.Split(',')[0]));

            foreach (Reminder rem in postPonedReminders)
                orderedReminders.Add(rem.Id, Convert.ToDateTime(rem.PostponeDate));


            //now we have both normal dates and postpone dates


            List<Reminder> returnValue = new List<Reminder>();
            foreach (KeyValuePair<long, DateTime> entry in orderedReminders.OrderBy(x => x.Value))
                returnValue.Add(BLReminder.GetReminderById(entry.Key));

            stopwatch.Stop();
            BLIO.Log("OrderPostponedReminders() took " + stopwatch.ElapsedMilliseconds + " ms");

            return returnValue;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnNextPage_Click");


            List<Reminder> reminders = BLReminder.GetOrderedReminders();


            if ((pageNumber * 7) + 1 > reminders.Count)
                return; //No reminders left


            int reminderItemCounter = 0;
            for (int i = pageNumber * 7; i < (pageNumber * 7) + 7; i++)
            {
                if (reminders.Count - 1 >= i) //Safely within index numbers
                {
                    //Get the user control item from the panel. There's 7 user controls in the panel, so we have another counter for those
                    MUCReminderItem itm = (MUCReminderItem)pnlReminders.Controls[reminderItemCounter];
                    itm.Visible = true;
                    //Update the reminder object inside the user control, that's waay faster than removing and re-drawing a new control.
                    itm.Reminder = reminders[i];

                }
                else //Fill all remaining controls that can't be filled with reminders with "empty", since there are no reminders left
                {
                    for (int ii = reminderItemCounter; ii < 7; ii++)
                        ((MUCReminderItem)pnlReminders.Controls[ii]).Reminder = null;
                }
                reminderItemCounter++;
            }

            MaterialSkin.MaterialSkinManager.Themes theme = MaterialSkin.MaterialSkinManager.Instance.Theme;

            pageNumber++;
            if ((pageNumber * 7) + 1 > reminders.Count)
            {
                btnNextPage.Icon = Properties.Resources.nextDisabledDark;
            }
            else
            {
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnNextPage.Icon = Properties.Resources.NextWhite;
                else
                    btnNextPage.Icon = Properties.Resources.nextDark;
            }

            if (pageNumber > 1)
            {
                if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                    btnPreviousPage.Icon = Properties.Resources.PreviousWhite;
                else
                    btnPreviousPage.Icon = Properties.Resources.previousDark;
            }

            MaterialForm1.Instance.UpdatePageNumber(pageNumber);
            foreach (MUCReminderItem itm in pnlReminders.Controls)
                itm.RefreshLabelFont();

            GC.Collect();
        }

        public void RefreshPage()
        {
            if (pageNumber > 1)
            {
                btnPreviousPage_Click(null, null);
                btnNextPage_Click(null, null);
            }
        }




        private void MUCReminders_DragEnter(object sender, DragEventArgs e)
        {
            BLIO.Log("Detected file dragging into RemindMe!");
            e.Effect = DragDropEffects.All;
        }

        private void MUCReminders_DragDrop(object sender, DragEventArgs e)
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
                try
                {
                    BLOnlineDatabase.ImportCount++;
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.ImportCount++ MUCReminders.cs . -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
            }).Start();

            //finally, refresh the listview
            UpdateCurrentPage();
        }

        private void btnUnhideReminders_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnUnhideReminders_Click");
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

        private void MUCReminders_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                BLIO.Log("Control MUCReminders now visible");
        }

        private void MUCReminders_Load(object sender, EventArgs e)
        {            
            tmrCheckForUpdates.Start();
            SetPageButtonIcons(BLReminder.GetReminders());
        }

        private void tmrCheckForUpdates_Tick(object sender, EventArgs e)
        {
            try
            {
                if (showUpdateMessage && Directory.Exists(IOVariables.applicationFilesFolder + "\\old") && Directory.GetFiles(IOVariables.applicationFilesFolder + "\\old").Count() > 0)
                {
                    MaterialMessageFormManager.MakeMessagePopup("RemindMe has updated!\r\nRestart RemindMe to load these changes directly.", 0);
                    tmrCheckForUpdates.Stop();
                }                
            }
            catch (Exception ex)
            {
                BLIO.Log("CheckForUpdates FAILED. " + ex.GetType().ToString());
                BLIO.WriteError(ex, "Error in tmrCheckForUpdates_Tick");
            }
        }
    }
}
