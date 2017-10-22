using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using Database.Entity;
using Business_Logic_Layer;
using System.Runtime.InteropServices;
using System.Globalization;

namespace RemindMe
{
    /// <summary>
    /// This is the main form. Control events will be handled here
    /// </summary>
    public partial class Form1 : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);

        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        //The stop playing preview sound icon
        Image imgStop;

        //The start playing preview sound icon
        Image imgPlayResume;

        
        
        //This list will contain reminders that need removing    
        List<Reminder> toRemoveReminders;

        bool allowRefreshListview = false;

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        int dayOfStartRemindMe;

        UCWindows ucWindows;
        UCMusic ucMusic;
        UCImportExport ucImportExport;
        UCCustomizePopup ucCustomizePopup;
        UCSendMailInfo ucSendMail;

        //Determines if the user is editing an reminder. If this reminder is null, the user is not currently editing one.
        Reminder editableReminder;

        //Reminders that will pop up the next hour.
        List<Reminder> remindersToHappenInAnHour;        

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        RemindMeMessageForm popupForm;
        public Form1()
        {
            
            InitializeComponent();

            

            AppDomain.CurrentDomain.SetData("DataDirectory", Variables.IOVariables.databaseFile);
            BLIO.CreateSettings();
            BLIO.CreateDatabaseIfNotExist();            

            ucWindows = new UCWindows();
            ucMusic = new UCMusic();
            ucImportExport = new UCImportExport();
            ucCustomizePopup = new UCCustomizePopup();
            ucSendMail = new UCSendMailInfo();

            dayOfStartRemindMe = DateTime.Now.Day;

            imgStop = Properties.Resources.stopBlack;
            imgPlayResume = Properties.Resources.resume;

            toRemoveReminders = new List<Reminder>();
            remindersToHappenInAnHour = new List<Reminder>();

            //Subscribe all day checkboxes to our custom checked changed event, so that whenever any of these checkboxes change, the cbDaysCheckedChangeEvent will fire
            cbMonday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbTuesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbWednesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbThursday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbFriday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSaturday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSunday.CheckedChanged += cbDaysCheckedChangeEvent;    
            
            //Set the Renderer of the menustrip to our custom renderer, which sets the highlight and border collor to DimGray, which is the same
            //As the menu's themselves, which means you will not see any highlighting color or border. This renderer also makes the text of the selected
            //toolstrip items white.
            RemindMeTrayIconMenuStrip.Renderer = new MyToolStripMenuRenderer();       
            ReminderMenuStrip.Renderer = new MyToolStripMenuRenderer();
        }


        //prevent flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }



        protected override void WndProc(ref Message m)
        {
            //Make RemindMe draggable from the top
             base.WndProc(ref m);
            
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);

            //This message will be sent when the RemindMeImporter imports reminders.
            if (m.Msg == WM_RELOAD_REMINDERS)
            {
                int currentReminderCount = BLReminder.GetReminders().Count;
                BLReminder.NotifyChange();
                RefreshListview(lvReminders);

                if (!this.Visible) //don't make this message if RemindMe is visible, the user will see the changes if it is visible.
                    MakeMessagePopup(BLReminder.GetReminders().Count - currentReminderCount + " Reminder(s) succesfully imported!",3);

            }
        }


        /// <summary>
        /// makes the popup that shows howmany reminders are set for today
        /// </summary>
        private void MakeTodaysRemindersPopup()
        {
            int reminderCount = BLReminder.GetTodaysReminders().Count;
            if(BLSettings.IsReminderCountPopupEnabled())
            {
                if (reminderCount > 0)
                    MakeMessagePopup("You have " + reminderCount + " Reminder(s) set for today.", 3);
                else
                    MakeMessagePopup("You have no reminders set for today.", 3);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //place all panels on top of eachother, they won't all be visible, though
            pnlMain.Location = new Point(0, 22);
            pnlNewReminder.Location = new Point(0, 22);
            pnlSettings.Location = new Point(0, 22);
            ShowPanel(pnlMain);
            ResetReminderForm();

            //throw new FileNotFoundException("test","test");
            MakeTodaysRemindersPopup();

            //hide the form on startup
            BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                }));



            //Add all reminders to the listview
            AddRemindersToListview(lvReminders, BLReminder.GetReminders());

            this.BackgroundImage = Properties.Resources.gray;
            pictureBox4.BringToFront();

            //Start checking for reminders
            tmrCheckReminder.Start();

            //Resizes the form to it's original size.            
            this.Size = new Size(463, 475);
            this.MaximumSize = this.Size;

            //Make the buttons borderless-------------------
            BLFormLogic.RemovebuttonBorders(btnAddReminder);
            BLFormLogic.RemovebuttonBorders(btnBack);
            BLFormLogic.RemovebuttonBorders(btnRemoveReminder);
            BLFormLogic.RemovebuttonBorders(btnEditReminder);
            BLFormLogic.RemovebuttonBorders(btnConfirm);
            BLFormLogic.RemovebuttonBorders(btnDisableEnable);
            BLFormLogic.RemovebuttonBorders(btnClear);
            BLFormLogic.RemovebuttonBorders(btnBackFromSettings);
            BLFormLogic.RemovebuttonBorders(btnAddMonthlyDay);
            BLFormLogic.RemovebuttonBorders(btnRemoveMonthlyDay);
            BLFormLogic.RemovebuttonBorders(btnAddDate);
            BLFormLogic.RemovebuttonBorders(btnRemoveDate);
            //----------------------------------------------   




            //Set the custom format for the time datetime picker (HH:mm) instead of HH:mm:ss
            dtpTime.Format = DateTimePickerFormat.Custom;

            btnPlaySound.BackgroundImage = imgPlayResume;
            
            //Create an shortcut in the windows startup folder if it doesn't already exist
            if (!File.Exists(Variables.IOVariables.startupFolderPath + "\\RemindMe" + ".lnk"))
                FSManager.Shortcuts.CreateShortcut(Variables.IOVariables.startupFolderPath, "RemindMe", Application.StartupPath + "\\" + "RemindMe.exe", "Shortcut of RemindMe");

            FillSoundComboboxFromDatabase(cbSound);


            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);            
            lblVersion.Text = "RemindMe - Version " + fvi.FileVersion;
        }

        /// <summary>
        /// Resets all the controls to their original state.
        /// </summary>
        private void ResetControlValues(Panel pnl)
        {
            RadioButton rb;
            foreach (Control c in pnl.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                    c.BackColor = Color.DimGray;
                }

                if (c is RadioButton)
                {
                    rb = (RadioButton)c;

                    
                    if (rb.Name == "rbNoRepeat")
                        rb.Checked = true; //The default radio button should be rbNoRepeat
                    else
                        rb.Checked = false;
                }
                if (c is CheckBox)
                {
                    if (c.Name != "cbStickyForm")//we dont want to reset the sticky form checkbox
                    {
                        CheckBox check = (CheckBox)c;
                        check.Checked = false;
                    }
                }
                if (c is DateTimePicker)
                {
                    DateTimePicker pick = (DateTimePicker)c;
                    pick.Enabled = true;
                    pick.Value = DateTime.Now.AddMinutes(1);
                }
                if (c is ComboBox)
                {
                    if (c.Name != "cbEveryXCustom")
                    {
                        ComboBox cb = (ComboBox)c;
                        cb.Items.Clear();
                        cb.Text = "";
                    }
                }
                if (c is PictureBox && c.Name != "pbEdit")
                    c.Visible = false;
            }
        }
        /// <summary>
        /// Adds an reminder to the listview, showing the details of that reminder.
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The reminder</param>
        private void AddReminderToListview(ListView lv, Reminder rem)
        {

            ListViewItem itm = new ListViewItem(rem.Name);
            itm.Tag = rem.Id; //Add the id as a tag(invisible)

            if (rem.PostponeDate == null)
            {
                if (Convert.ToDateTime(DateTime.Today.ToShortDateString()) >= Convert.ToDateTime(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortDateString()))
                    itm.SubItems.Add(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortTimeString());
                else
                    itm.SubItems.Add(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortDateString());
            }
            else
            {
                if (Convert.ToDateTime(DateTime.Today.ToShortDateString()) >= Convert.ToDateTime(Convert.ToDateTime(rem.PostponeDate).ToShortDateString()))
                    itm.SubItems.Add(Convert.ToDateTime(rem.PostponeDate).ToShortTimeString() + " (p)");
                else
                    itm.SubItems.Add(Convert.ToDateTime(rem.PostponeDate).ToShortDateString() + " (p)");
            }

            if (rem.EveryXCustom == null)
            {

                if (rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                {
                    string cutOffString = "";
                    foreach (string day in rem.RepeatDays.Split(','))
                        cutOffString += day.Substring(0, 3) + ",";

                    cutOffString = cutOffString.Remove(cutOffString.Length - 1, 1); //remove the final ','
                    itm.SubItems.Add(cutOffString); //Add all the repeating days to the listview column. example: mon,tue,sat
                }
                else if (rem.RepeatType == ReminderRepeatType.MONTHLY.ToString())
                {
                    string multipleDays = "";
                    foreach (string date in rem.Date.Split(','))
                        multipleDays += Convert.ToDateTime(date).Day.ToString() + ",";

                    multipleDays = multipleDays.Remove(multipleDays.Length - 1, 1);
                    itm.SubItems.Add(multipleDays);
                }
                else
                    itm.SubItems.Add(rem.RepeatType.ToString().ToLower());
            }
            else
                itm.SubItems.Add("every " + rem.EveryXCustom + " " + rem.RepeatType);

            if (rem.Enabled == 1)
                itm.SubItems.Add("True");
            else
                itm.SubItems.Add("False");

            lv.Items.Add(itm);
        }
        /// <summary>
        /// Adds multiple reminders to the listview
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The list of reminders</param>
        private void AddRemindersToListview(ListView lv, List<Reminder> reminderList)
        {
            List<Reminder> list = reminderList.OrderBy(t => Convert.ToDateTime(t.Date.Split(',')[0])).ToList();
            foreach (Reminder rem in list)
                AddReminderToListview(lv, rem);
        }

        private void RefreshListview(ListView lv)
        {
            lv.Items.Clear();            
            AddRemindersToListview(lv, BLReminder.GetReminders());
        }

        /// <summary>
        /// Gets all the sounds from the database and fills the combobox with them.
        /// </summary>
        /// <param name="cbSound"></param>
        private void FillSoundComboboxFromDatabase(ComboBox cbSound)
        {
            //Fill the list with all the sounds from the settings.ini file
            List<Songs> sounds = BLSongs.GetSongs();

            cbSound.Items.Clear();
            ComboBoxItemManager.ClearComboboxItems();

            if (sounds != null)
                foreach (Songs item in sounds)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));


            cbSound.Items.Remove(" Add files...");
            cbSound.Items.Add(" Add files...");
            cbSound.Sorted = true;
        }

        /// <summary>
        /// Creates a new instance of popup
        /// </summary>
        private void MakeReminderPopup(Reminder rem)
        {
            Popup p = new Popup(rem);
            p.Show();                                   
        }

        /// <summary>
        /// Creates a new instance of popup
        /// </summary>
        private void MakeMessagePopup(string message, int popDelay)
        {
            if (popupForm != null && popupForm.Visible)//We are about to create a new popup, but there's already one visible! Let's dispose it
            {
                popupForm.Dispose();

                tmrMessageFormScrollDown.Stop(); //stop the timers
                tmrMessageFormScrollUp.Stop();
            }

            popupForm = new RemindMeMessageForm(message, popDelay);
            popupForm.Show();
            tmrMessageFormScrollUp.Start();
        }

        /// <summary>
        /// Adds the DayCheckBoxes panel between the layout and adjusts the location of the note textbox, and the buttons below it.
        /// </summary>
        private void PlaceDayCheckBoxesPanel()
        {
            //place it just under the panel under the radio buttons
            pnlDayCheckBoxes.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
            pnlDayCheckBoxes.Visible = true;
            //place the textbox under this panel                        
        }

        /// <summary>
        /// Adds the monthly combobox between the layout and adjusts the location of the note textbox, and the buttons below it.
        /// </summary>
        private void PlaceComboboxMonthlyWeekly()
        {
            lblEvery.Visible = true;
            //cbEvery.Visible = true; ?
            pnlDayCheckBoxes.Visible = false;

            
            

            if (rbEveryXCustom.Checked)
            {
                numEveryXDays.Visible = true;
                cbEveryXCustom.Visible = true;
            }
            else
            {
                numEveryXDays.Visible = false;
                cbEveryXCustom.Visible = false;
            }

            if ((rbMonthly.Checked) && !rbEveryXCustom.Checked)
                cbEvery.Visible = true;
            else
                cbEvery.Visible = false;

            
        }


        /// <summary>
        /// Hides the week/monthly combobox between the layout and resets the location of the textbox and the buttons below it
        /// </summary>
        private void RemoveComboboxMonthlyWeekly()
        {
            pnlDayCheckBoxes.Visible = false;
            cbEvery.Visible = false;
            lblEvery.Visible = false;
            numEveryXDays.Visible = false;
            cbEveryXCustom.Visible = false;
                                                
        }

        private List<Reminder> GetSelectedRemindersFromListview()
        {
            List<Reminder> selectedReminders = new List<Reminder>();

            foreach(ListViewItem item in lvReminders.SelectedItems)            
                selectedReminders.Add(BLReminder.GetReminderById((long)item.Tag));
            
            return selectedReminders;
            
        }

        /// <summary>
        /// Fills the controls of creating a new reminder with the data from the reminder
        /// </summary>
        public void FillControlsForEdit(Reminder rem)
        {//public for unit testing, yeah i know it sucks
            if (lvReminders.SelectedItems.Count < 2)
            {
                
                pnlDayCheckBoxes.Visible = false;
                ShowPanel(pnlNewReminder);
                pbEdit.BackgroundImage = Properties.Resources.Edit;
                if (rem != null)
                {
                    FillSoundComboboxFromDatabase(cbSound);
                    tbNote.Text = rem.Note.Replace("\\n", Environment.NewLine);
                    tbReminderName.Text = rem.Name;

                    if (rem.SoundFilePath != null)
                    {
                        string song = Path.GetFileNameWithoutExtension(rem.SoundFilePath);
                        ComboBoxItem reminderItem = ComboBoxItemManager.GetComboBoxItem(song, BLSongs.GetSongByFullPath(rem.SoundFilePath));

                        if (reminderItem != null)
                            cbSound.SelectedItem = reminderItem;
                    }




                    switch (rem.RepeatType)
                    {
                        case "NONE":
                            rbNoRepeat.Checked = true;
                            cbMultipleDates.Items.Clear();
                            foreach (string date in rem.Date.Split(','))
                                cbMultipleDates.Items.Add(Convert.ToDateTime(date));

                            if (cbMultipleDates.Items.Count > 0)
                                cbMultipleDates.SelectedItem = cbMultipleDates.Items[0];


                            break;
                        case "DAILY":
                            rbDaily.Checked = true;
                            break;
                        case "MONTHLY":
                            rbMonthly.Checked = true;
                            List<int> days = new List<int>();

                            //Remove the items, then go through the date string, and get all the dates from each date. 25-7-2017 00:00:00,31-7-2017 00:00:00 will return 25,31
                            cbMonthlyDays.Items.Clear();
                            foreach (string date in rem.Date.Split(','))
                                cbMonthlyDays.Items.Add(Convert.ToDateTime(date).Day);

                            if (cbMonthlyDays.Items.Count > 0)
                                cbMonthlyDays.SelectedItem = cbMonthlyDays.Items[0];

                            break;
                        case "WORKDAYS":
                            rbWorkDays.Checked = true;
                            break;
                        case "MULTIPLE_DAYS":
                            PlaceDayCheckBoxesPanel();
                            rbMultipleDays.Checked = true;
                            //get the RepeatDays string (monday,friday,saturday) and split them.
                            List<string> repeatDays = rem.RepeatDays.Split(',').ToList();
                            //check all the checkboxes from the split string. did it contain monday? check the checkbox "cbMonday", etc
                            CheckDayCheckBoxes(repeatDays);
                            break;
                    }
                    if (rem.EveryXCustom != null)
                    {
                        rbEveryXCustom.Checked = true;
                        numEveryXDays.Value = (decimal)rem.EveryXCustom;

                        //The repeating type will now be different, because the user selected a custom reminder. repeating types will now be minutes,hours,days,weeks or months
                        switch (rem.RepeatType.ToLower())
                        {
                            case "minutes":
                                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[0];
                                break;
                            case "hours":
                                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[1];
                                break;
                            case "days":
                                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2];
                                break;
                            case "weeks":
                                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[3];
                                break;
                            case "months":
                                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[4];
                                break;
                        }
                    }                    
                    dtpTime.Value = Convert.ToDateTime(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortTimeString());
                    dtpDate.Value = Convert.ToDateTime(rem.Date.Split(',')[0]);
                    //reposition the textbox under the groupbox. null,null because we're not doing anything with the parameters
                    pnlDayCheckBoxes_VisibleChanged(null, null);

                    
                }
                else
                {
                    BLIO.WriteError(new ArgumentNullException(), "Error loading reminder");
                    ErrorPopup pop = new ErrorPopup("Error loading reminder. Reminder is null", new ArgumentNullException());
                    pop.Show();
                }
            }
            else                                
                RemindMeBox.Show("Please select one reminder to edit at a time", RemindMeBoxIcon.INFORMATION);
        }

        private void CheckDayCheckBoxes(List<string> days)
        {
            if (days.Contains("monday"))
                cbMonday.Checked = true;
            else
                cbMonday.Checked = false;

            if (days.Contains("tuesday"))
                cbTuesday.Checked = true;
            else
                cbTuesday.Checked = false;

            if (days.Contains("wednesday"))
                cbWednesday.Checked = true;
            else
                cbWednesday.Checked = false;

            if (days.Contains("thursday"))
                cbThursday.Checked = true;
            else
                cbThursday.Checked = false;

            if (days.Contains("friday"))
                cbFriday.Checked = true;
            else
                cbFriday.Checked = false;

            if (days.Contains("saturday"))
                cbSaturday.Checked = true;
            else
                cbSaturday.Checked = false;

            if (days.Contains("sunday"))
                cbSunday.Checked = true;
            else
                cbSunday.Checked = false;
        }

        /// <summary>
        /// Determines wether the exlamation sign should be visible or not, with an tooltip saying the entered date is invalid
        /// </summary>
        private void ShowOrHideExclamation() 
        {
            
            if (Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) < DateTime.Now)
            {//User selected a date in the past
                pbExclamationDate.Visible = true;
                toolTip1.SetToolTip(pbExclamationDate, "Entered date is invalid.\r\nCan't select a date from the past");
            }
            else
                pbExclamationDate.Visible = false;


            if (rbWorkDays.Checked)
            {
                //Is the selected day a workday?                
                if (dtpDate.Value.DayOfWeek != DayOfWeek.Saturday && dtpDate.Value.DayOfWeek != DayOfWeek.Sunday )
                    pbExclamationWorkday.Visible = false;
                else
                {
                    pbExclamationWorkday.Visible = true;
                    toolTip1.SetToolTip(pbExclamationWorkday, "The day you selected is not a work day.");
                }
            }
        }

        
        /// <summary>
        /// Closes RemindMe to the system tray. RemindMe can be terminated through it's icon in the tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void ResetReminderForm()
        {
            cbSound.SelectedItem = null;
            pnlDayCheckBoxes.Visible = false;
            //Reset the controls to their default values, empty text boxes etc
            ResetControlValues(pnlNewReminder);
            ResetControlValues(pnlDayCheckBoxes);

            rbNoRepeat.Checked = true;
            cbMultipleDates.Visible = true;
            cbEvery_VisibleChanged(null,null);

            //There's no selected item, so it should not appear that way either
            cbSound.Text = "";
            cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2]; //days

            dtpTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")).AddMinutes(1); //Add 1 minute so the exclamination won't show
            

            FillSoundComboboxFromDatabase(cbSound);
        }

        private void cbDaysCheckedChangeEvent(object sender, EventArgs e)
        {
            DateTime? selectedDateFromCheckboxes = BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString()) ?? DateTime.Now;

            dtpDate.Value = selectedDateFromCheckboxes ?? DateTime.Now;

            
            if (IsDayCheckboxChecked(DateTime.Now.DayOfWeek))
            {//Check if the checkbox of today's dayofweek is checked
                //Then, if the selected time is in the FUTURE, we want to set the date to today.
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) > DateTime.Now)
                {
                    dtpDate.Value = DateTime.Now;
                }
            }                        
            
        }
        /// <summary>
        /// Checks if a day checkbox for the given day is checked
        /// </summary>
        /// <param name="day">The day you want to check for selection</param>
        /// <returns>True if the given day is selected, false if not</returns>
        private bool IsDayCheckboxChecked(DayOfWeek day)
        {
            switch(day)
            {
                case DayOfWeek.Sunday:
                    if (cbSunday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Monday:
                    if (cbMonday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Tuesday:
                    if (cbTuesday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Wednesday:
                    if (cbWednesday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Thursday:
                    if (cbThursday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Friday:
                    if (cbFriday.Checked)
                        return true;
                    else
                        return false;

                case DayOfWeek.Saturday:
                    if (cbSaturday.Checked)
                        return true;
                    else
                        return false;
                    
                default: return false;
            }
            
        }
        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            editableReminder = null;
            if (!BLSettings.IsStickyForm())
            {                
                ResetReminderForm();
                cbStickyForm.Checked = false;
            }
            else
                cbStickyForm.Checked = true;

            pbExclamationDate.Visible = false;

            FillSoundComboboxFromDatabase(cbSound);
            pbEdit.BackgroundImage = Properties.Resources.Create_new;
            ShowPanel(pnlNewReminder);
        }

        private void ShowPanel(Panel thePanel)
        {
            //Show the panel and hide the others

            switch(thePanel.Name)
            {
                case "pnlMain":
                    pnlNewReminder.Visible = false;
                    pnlSettings.Visible = false;
                    pnlMain.Visible = true;                    
                    break;

                case "pnlNewReminder":
                    pnlMain.Visible = false;                    
                    pnlSettings.Visible = false;
                    pnlNewReminder.Visible = true;
                    break;

                case "pnlSettings":
                    pnlMain.Visible = false;
                    pnlNewReminder.Visible = false;
                    pnlSettings.Visible = true;
                    break;
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
                BLReminder.DeleteReminders(toRemoveReminders);                
            }                        
        }

        private void tmrCheckReminder_Tick(object sender, EventArgs e)
        {
            //If a day has passed since the start of RemindMe, we may want to refresh the listview. 
            //There might be reminders happening on this day, if so, we show the time of the reminder, instead of the day
            if (dayOfStartRemindMe < DateTime.Now.Day)
            {
                allowRefreshListview = true;
                dayOfStartRemindMe = DateTime.Now.Day;
                MakeTodaysRemindersPopup();
            }
                

            //We will check for reminders here every 30 seconds.
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
                            theDateToCheckOn = Convert.ToDateTime(rem.Date);


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
                RefreshListview(lvReminders);
                
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
                message = message.Remove(message.Length-2, 2);            
            if (remindersToHappenInAnHour.Count > 0)
                MakeMessagePopup(message, 5);

            remindersToHappenInAnHour.Clear();
        }

        

       

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSound.SelectedItem != null)
            {                
                if (cbSound.SelectedItem.ToString() == " Add files...")
                {
                    //Fill selectedFiles with the selected files AND the current files, 
                    //and check if it is not already in the list

                    List<string> selectedFiles = FSManager.Files.GetSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();

                    if (selectedFiles.Count == 1 && selectedFiles[0] == "")
                        return;                  

                    List<Songs> toInsertSongs = new List<Songs>();
                    foreach (string sound in selectedFiles)
                    {
                        if (sound != "")
                        {
                            Songs song = new Songs();
                            song.SongFilePath = sound;
                            song.SongFileName = Path.GetFileName(sound);
                            toInsertSongs.Add(song);
                        }
                    }
                    BLSongs.InsertSongs(toInsertSongs);

                    foreach (Songs item in toInsertSongs) //already inserted, but iterating through them to add to the combobox
                        if (item.SongFileName != "")
                            cbSound.Items.Add(new ComboBoxItem(Path.GetFileNameWithoutExtension(item.SongFileName), BLSongs.GetSongByFullPath(item.SongFilePath)));



                    /*foreach (Songs item in BLSongs.GetSongs())
                        if (item.SongFileName != "")
                            cbSound.Items.Add(new ComboBoxItem(item.SongFileName, BLSongs.GetSongByFullPath(item.SongFilePath)));*/

                    //Make sure that Add files... is in the combobox
                    cbSound.Items.Remove(" Add files...");
                    cbSound.Items.Add(" Add files...");
                }
            }
        }

        private void rbNoRepeat_CheckedChanged(object sender, EventArgs e)
        {
            RemoveComboboxMonthlyWeekly();
            if (rbNoRepeat.Checked && editableReminder == null)
            {
                dtpDate.ResetText();
                dtpTime.ResetText();                
            }

            if(rbNoRepeat.Checked)
            {
                pnlDayCheckBoxes_VisibleChanged(sender, e);
                cbMultipleDates.Visible = true;
            }
            else
            {
                cbMultipleDates.Visible = false;
            }
            
        }

        

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonthly.Checked)
            {
                cbEvery.Visible = true;
                lblEvery.Visible = true;
                           
                //clear the combobox of previous data
                cbEvery.Items.Clear();

                for (int i = 1; i <= 31; i++)
                    cbEvery.Items.Add(i.ToString()); //Add 1-31 string to it 

                //Select the first item
                cbEvery.SelectedItem = cbEvery.Items[0];
                lblEvery.Text = "Day(s):";

                if (!cbEvery.Visible)
                    PlaceComboboxMonthlyWeekly();

                dtpDate.Enabled = false;
            }
            else
            {
                cbEvery.Visible = false;
                dtpDate.Enabled = true;
            }
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlMain);

            //If there is an scrolling popup, hide it.
            HideScrollingPopupMessage();

        }

        public void btnConfirm_Click(object sender, EventArgs e)
        {
            //set it to null at first, the user may not have this option selected            
            string commaSeperatedDays = "";

            //Will be different based on what repeating method the user has selected
            if (!string.IsNullOrWhiteSpace(tbReminderName.Text) && (Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) > DateTime.Now || rbNoRepeat.Checked)) //for the radiobuton rbnorepeat it doesn't matter if the datetime pickers have dates from the past, because it checks the added dates in the cbMultipleDates ComboBox
            {
                ReminderRepeatType repeat = new ReminderRepeatType();
                if (rbMonthly.Checked)
                    repeat = ReminderRepeatType.MONTHLY;

                if (rbWorkDays.Checked)
                    repeat = ReminderRepeatType.WORKDAYS;

                if (rbDaily.Checked)
                    repeat = ReminderRepeatType.DAILY;

                if (rbNoRepeat.Checked)
                    repeat = ReminderRepeatType.NONE;

                if (rbEveryXCustom.Checked)
                    repeat = ReminderRepeatType.CUSTOM;

                if (rbMultipleDays.Checked)
                    repeat = ReminderRepeatType.MULTIPLE_DAYS;

                string soundPath = "";

                if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                    commaSeperatedDays = GetCommaSeperatedDayCheckboxesString();

                if (cbSound.SelectedItem != null && cbSound.SelectedItem.ToString() != " Add files...")
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
                    Songs selectedSong = (Songs)selectedItem.Value;
                    soundPath = selectedSong.SongFilePath;
                }

                tbReminderName.BackColor = Color.DimGray;
                pbExclamationTitle.Visible = false;
                pbExclamationDate.Visible = true;

                if (editableReminder == null) //If the user isn't editing an existing reminder, he's creating one
                {
                    if (repeat == ReminderRepeatType.MONTHLY)
                    {
                        if (cbMonthlyDays.Items.Count > 0)
                            BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMonthlyDaysComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            MakeScrollingPopupMessage("Can not create an reminder with monthly day(s) if there are no days selected!");
                            pbExclamationDate.Visible = false;

                            return;
                        }
                    }

                    else if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        if (IsAtLeastOneWeeklyCheckboxSelected())
                            BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, commaSeperatedDays, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            MakeScrollingPopupMessage("You do not have any day(s) selected!");
                            return;
                        }
                    else if (repeat == ReminderRepeatType.CUSTOM)
                        BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), cbEveryXCustom.SelectedItem.ToString(), Convert.ToInt32(numEveryXDays.Value), null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                    else if (repeat == ReminderRepeatType.NONE)
                    {
                        if (cbMultipleDates.Items.Count > 0)
                            BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMultipleDatesComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            MakeScrollingPopupMessage("You have not added any dates!\r\nIf you have selected a date and want only that one, press the \"+\" button");
                            return;
                        }
                    }
                    else
                        BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);


                }
                else
                {//The user is editing an existing reminder                                        
                    editableReminder.Name = tbReminderName.Text;

                    if (rbEveryXCustom.Checked)
                    {
                        editableReminder.RepeatType = cbEveryXCustom.SelectedItem.ToString();
                        editableReminder.EveryXCustom = Convert.ToInt32(numEveryXDays.Value);
                    }
                    else
                        editableReminder.RepeatType = repeat.ToString();

                    switch (repeat.ToString())
                    {
                        case "DAILY":
                            editableReminder.Date = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString();
                            break;
                        case "MULTIPLE_DAYS":
                            if (IsAtLeastOneWeeklyCheckboxSelected())
                                editableReminder.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString())).ToShortDateString() + " " + dtpTime.Value.ToShortTimeString();
                            else
                            {
                                MakeScrollingPopupMessage("You do not have any day(s) selected!");
                                return;
                            }
                            break;
                        case "NONE":
                            if (cbMultipleDates.Items.Count > 0)
                                editableReminder.Date = GetDatesStringFromMultipleDatesComboBox();
                            else
                            {
                                MakeScrollingPopupMessage("You have not added any dates!\r\nIf you have selected a date and want only that one, press the \"+\" button");
                                return;
                            }
                            break;
                        case "MONTHLY":
                            if (cbMonthlyDays.Items.Count > 0)
                                editableReminder.Date = GetDatesStringFromMonthlyDaysComboBox();
                            else
                            {
                                MakeScrollingPopupMessage("Can not create an reminder with monthly day(s) if there are no days selected!");
                                pbExclamationDate.Visible = false;

                                return;
                            }
                            break;
                        case "WORKDAYS":
                            editableReminder.Date = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString();
                            break;
                        default:
                            editableReminder.Date = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString();
                            break;
                    }
                    
                    editableReminder.SoundFilePath = soundPath;
                    editableReminder.Note = tbNote.Text.Replace(Environment.NewLine, "\\n");


                    if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        editableReminder.RepeatDays = commaSeperatedDays;

                    if (editableReminder.EveryXCustom != null)
                        editableReminder.EveryXCustom = Convert.ToInt32(numEveryXDays.Value);


                    RemoveUnusedPropertiesFromReminders(editableReminder);
                    BLReminder.EditReminder(editableReminder);
                }

                //clear the entire listview an re-fill it so that the listview is ordered by date again
                lvReminders.Items.Clear();
                AddRemindersToListview(lvReminders, BLReminder.GetReminders());
                ShowPanel(pnlMain);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbReminderName.Text))
                {//User didnt fill in a title
                    tbReminderName.BackColor = Color.Red;
                    pbExclamationTitle.Visible = true;
                    toolTip1.SetToolTip(pbExclamationTitle, "Please enter a title.");
                }
                else
                {//if(!cbmonthly.selected) TODO
                    tbReminderName.BackColor = Color.DimGray;
                    pbExclamationTitle.Visible = false;
                }


                ShowOrHideExclamation();

                MakeScrollingPopupMessage("Some fields are not valid. Please see the exclaminations");

            }


            //If there is an scrolling popup, hide it.
            HideScrollingPopupMessage();
        }

        /// <summary>
        /// Removes properties from a reminder that the reminder shouldn't have. 
        /// Example: The reminder is a monthly reminder, but before editing it was a weekdays reminder. If that reminder is now monthly and it still has weekdays, it will be removed here
        /// </summary>
        /// <param name="rem"></param>
        private void RemoveUnusedPropertiesFromReminders(Reminder rem)
        {
            if (rem.RepeatType != ReminderRepeatType.MULTIPLE_DAYS.ToString())
                rem.RepeatDays = null;

            if(rem.RepeatType != "Minutes" && rem.RepeatType != "Hours" && rem.RepeatType != "Days" && rem.RepeatType != "Weeks" && rem.RepeatType != "Months")
                rem.EveryXCustom = null;            
        }
        private bool IsAtLeastOneWeeklyCheckboxSelected()
        {
            foreach(Control c in pnlDayCheckBoxes.Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox theCheckbox = (CheckBox)c;
                    if (theCheckbox.Checked)
                        return true;
                }
            }
            return false;
        }
        private void pbSettings_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlSettings);  
             
            //no controls in this panel yet. this means that the settings button has been pressed for the first time, so we load ucWindows in by default.         
            if(pnlUserControls.Controls.Count == 0)
                pnlUserControls.Controls.Add(ucWindows);
            else
            {
                if (pnlUserControls.Controls[0].Name == "UCMusic")
                {//re-load the ucmusic user control so the load function will be called again. there might have been changes made to the database.
                    pnlUserControls.Controls.Clear();
                    ucMusic = new UCMusic();
                    pnlUserControls.Controls.Add(ucMusic);
                }
            }
        }

        /// <summary>
        /// gets all the checked day comboboxes and puts them into a string. example: monday,tuesday,friday
        /// </summary>
        /// <returns></returns>
        private string GetCommaSeperatedDayCheckboxesString()
        {
            string commaSeperatedDays = "";
            //loop through the selected checkboxes
            foreach (CheckBox cb in pnlDayCheckBoxes.Controls)
            {
                if (cb.Checked)
                    commaSeperatedDays += cb.Text.ToLower() + ",";
            }
            if(commaSeperatedDays.Length > 0)
                commaSeperatedDays = commaSeperatedDays.Remove(commaSeperatedDays.Length - 1, 1); //remove the last ','

            return commaSeperatedDays;
        }

        public void btnEditReminder_Click(object sender, EventArgs e)
        {           
            //Fill the form with the data from the single reminder selected from the listview.
            if (lvReminders.SelectedItems.Count > 0)
            {
                //clear the form, then fill it with the selected reminder
                ResetReminderForm();
                ListViewItem item = lvReminders.SelectedItems[0];                
                int id = Convert.ToInt32(item.Tag);
                editableReminder = BLReminder.GetReminderById(id);                            
                cbSound.Text = "";                
                FillControlsForEdit(editableReminder);
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

                    Reminder rem = BLReminder.GetReminderById(Convert.ToInt32(itm.Tag));
                    
                    if (bool.Parse(itm.SubItems[3].Text))
                        rem.Enabled = 1;
                    else
                        rem.Enabled = 0;

                    BLReminder.EditReminder(rem);

                }                
            }
        }
                   
        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void showRemindMeReWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            RemoveComboboxMonthlyWeekly();
        }

        private void rbWorkDays_CheckedChanged(object sender, EventArgs e)
        {
            RemoveComboboxMonthlyWeekly();

            if (!rbWorkDays.Checked)
                pbExclamationWorkday.Visible = false;
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {

            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem != null && selectedItem.Text != "Add files...")
            {
                Songs selectedSong = (Songs)selectedItem.Value;

                if (btnPlaySound.BackgroundImage == imgPlayResume)
                {

                    if (selectedItem != null)
                    {
                        if (System.IO.File.Exists(selectedSong.SongFilePath))
                        {
                            btnPlaySound.BackgroundImage = imgStop;

                            myPlayer.URL = selectedSong.SongFilePath;
                            mediaInfo = myPlayer.newMedia(myPlayer.URL);

                            //Start the timer. the timer ticks when the song ends. The timer will then reset the picture of the play button                        
                            if (mediaInfo.duration > 0)
                                tmrMusic.Interval = (int)(mediaInfo.duration * 1000);
                            else
                                tmrMusic.Interval = 1000;
                            tmrMusic.Start();


                            myPlayer.controls.play();
                        }
                        else
                        {
                            //Get the song object from the combobox value
                            Songs song = (Songs)selectedItem.Value;
                            if (song != null)
                            {
                                //Remove the song from the SQLite Database
                                BLSongs.RemoveSong(BLSongs.GetSongByFullPath(song.SongFilePath));

                                //Remove the song from the combobox
                                cbSound.Items.Remove(ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(song.SongFileName), song));

                                //Remove the song from the combobox list in the manager
                                ComboBoxItemManager.RemoveComboboxItem(ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(song.SongFileName), song));
                                
                                //Show the user the message that the file is no longer at the specified path.
                                RemindMeBox.Show("Could not play " + song.SongFileName + " located at \"" + song.SongFilePath + "\" \r\nDid you move,rename or delete the file ?", RemindMeBoxIcon.INFORMATION);
                            }
                        }
                    }
                }
                else
                {
                    btnPlaySound.BackgroundImage = imgPlayResume;
                    myPlayer.controls.stop();
                    tmrMusic.Stop();
                }
            }



        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPlaySound.BackgroundImage = imgPlayResume;
            tmrMusic.Stop();
        }

        private void RemindMeReWriteIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void cbEvery_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Sets the value to the DateTimePicker "dtpDate" after the user adds days to the monthly reminder
        /// </summary>
        private void SetDateTimePickerMonthlyValue()
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (var cbItem in cbMonthlyDays.Items)
            {
                if (BLDateTime.GetDateForNextDayOfMonth(Convert.ToInt32(cbItem)).Day == DateTime.Now.Day)
                    dates.Add(DateTime.Now);
                else
                    dates.Add(BLDateTime.GetDateForNextDayOfMonth(Convert.ToInt32(cbItem)));
            }


            if (dates.Count > 0)
                dtpDate.Value = dates.Min();
            else
                dtpDate.Value = DateTime.Now;
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            ShowOrHideExclamation();
            cbEvery_SelectedIndexChanged(sender, e);
                  
            if(rbDaily.Checked && Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) < DateTime.Now)            
                dtpDate.Value = DateTime.Now.AddDays(1);            
        }
        
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {        
            ShowOrHideExclamation();
        }

        private void RemindMeIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();    
        }

        private void showRemindMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Show();            
        }

        private void lvReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnRemoveReminder_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                foreach (ListViewItem item in lvReminders.Items)
                    item.Selected = true;
            }
        }

        private void lvReminders_DoubleClick(object sender, EventArgs e)
        {
            btnEditReminder_Click(sender, e);
        }

      

        private void rbEveryXDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEveryXCustom.Checked)            
                lblEvery.Text = "Every:";

            PlaceComboboxMonthlyWeekly();
        }

        private void numEveryXDays_ValueChanged(object sender, EventArgs e)
        {
            if (numEveryXDays.Value <= 0) //You can't make a reminder that repeats every 0 days
                numEveryXDays.Value = 1;
        }

        private void cbStickyForm_CheckedChanged(object sender, EventArgs e)
        {
            //Get the settings from the database and put it in an object
            Settings set = BLSettings.GetSettings();


            //Give a new value to the Stickyform property
            if (cbStickyForm.Checked)
                set.StickyForm = 1;
            else
                set.StickyForm = 0;

            //Push it to the database
            BLSettings.UpdateSettings(set);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetReminderForm();
        }

        private void rbMultipleDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMultipleDays.Checked)                            
                PlaceDayCheckBoxesPanel();            
            else            
                pnlDayCheckBoxes.Visible = false;            
        }

        private void tbNote_LocationChanged(object sender, EventArgs e)
        {
            //Whenever, however the textbox changes location, these buttons need to be placed below it again
            btnConfirm.Location = new Point(btnConfirm.Location.X, (tbNote.Location.Y + tbNote.Height + 3));
            btnBack.Location = new Point(btnConfirm.Location.X + btnConfirm.Width, btnConfirm.Location.Y);
            btnClear.Location = new Point(btnBack.Location.X + (btnBack.Width), btnBack.Location.Y);
            lblNote.Location = new Point(lblNote.Location.X, tbNote.Location.Y);
        }

        private void pnlDayCheckBoxes_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below the panel if its visible
            if(pnlDayCheckBoxes.Visible)
                tbNote.Location = new Point(pnlDayCheckBoxes.Location.X, (pnlDayCheckBoxes.Location.Y + pnlDayCheckBoxes.Size.Height) + 3);
            else if(cbEvery.Visible || numEveryXDays.Visible) //if those are visible, place the textbox below them
                tbNote.Location = new Point(cbEvery.Location.X, (cbEvery.Location.Y + cbEvery.Size.Height) + 3);
            else // if they're not, AND the pnlDaycheckBoxes isnt visible EITHER, place them below the groupbox of radio buttons
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }

        private void cbEvery_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below the combobox if its visible
            if (cbEvery.Visible)
            {
                tbNote.Location = new Point(cbEvery.Location.X, (cbEvery.Location.Y + cbEvery.Size.Height) + 3);
                lblEvery.Location = new Point(lblEvery.Location.X, cbEvery.Location.Y);

                btnAddMonthlyDay.Visible = true;
                btnRemoveMonthlyDay.Visible = true;
                cbMonthlyDays.Visible = true;
            }
            else if (!pnlDayCheckBoxes.Visible && (!cbEvery.Visible && !numEveryXDays.Visible))
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);

            if (!cbEvery.Visible)
            {
                btnAddMonthlyDay.Visible = false;
                btnRemoveMonthlyDay.Visible = false;
                cbMonthlyDays.Visible = false;
            }
        }

        private void numEveryXDays_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below this control if its visible
            if (numEveryXDays.Visible)
            {
                tbNote.Location = new Point(numEveryXDays.Location.X, (numEveryXDays.Location.Y + numEveryXDays.Size.Height) + 3);
                lblEvery.Location = new Point(lblEvery.Location.X, numEveryXDays.Location.Y);
            }
            else if (!pnlDayCheckBoxes.Visible)
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }

        private void enableDisableReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDisableEnable_Click(sender, e);
        }

        private void editReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditReminder_Click(sender, e);
        }

        private void removeReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemoveReminder_Click(sender, e);
        }

        private void lvReminders_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && lvReminders.SelectedItems.Count > 0)
            {
                ReminderMenuStrip.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Goes through all dates in the ComboBox cbMultipleDates and seperates them by a comma. Used for reminders with the repeat type None
        /// </summary>
        private string GetDatesStringFromMultipleDatesComboBox()
        {
            List<DateTime> selectedDates = new List<DateTime>();
            foreach (DateTime date in cbMultipleDates.Items)
                selectedDates.Add(date);

            selectedDates.Sort(); //important! make sure the earliest date is in front

            string datesSeperatedByCommas = "";
            foreach (DateTime date in selectedDates)
                datesSeperatedByCommas += date.ToString() + ",";

            return datesSeperatedByCommas.Remove(datesSeperatedByCommas.Length - 1, 1);
        }
        /// <summary>
        /// Goes through all the integer days in the combobox(1,3,25),makes dates from them and puts them into a string. Used for reminders with the repeat type monthly
        /// </summary>
        /// <returns></returns>
        private string GetDatesStringFromMonthlyDaysComboBox()
        {
            //First, get all the selected integer days
            List<int> selectedMonthlyDays = new List<int>();
            foreach (var item in cbMonthlyDays.Items)
                selectedMonthlyDays.Add(Convert.ToInt32(item.ToString()));

            List<DateTime> selectedMonthlyDaysDateTime = new List<DateTime>();
            //Now we need to create datetime's of those integer values
            foreach (int day in selectedMonthlyDays)
            {
                DateTime date = BLDateTime.GetDateForNextDayOfMonth(day,dtpTime.Value);
                selectedMonthlyDaysDateTime.Add(date);

            }

            //sort it so that the earliest date is the first
            selectedMonthlyDaysDateTime.Sort();
            string multipleDatesString = "";

            foreach (DateTime date in selectedMonthlyDaysDateTime)
                multipleDatesString += date.ToString() + ",";

            if (multipleDatesString.Length > 0)
                return multipleDatesString.Remove(multipleDatesString.Length - 1, 1); //remove the last ","
            else
                return "";
        }
        private void PreviewReminder(Reminder rem)
        {
            Reminder previewRem = rem;
            previewRem.Id = -1; //give the >temporary< reminder an invalid id, so that the real reminder won't be altered
            MakeReminderPopup(previewRem);
        }

        private void previewThisReminderNowToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            foreach (Reminder rem in GetSelectedRemindersFromListview())
                PreviewReminder(rem);
        }       

        private async void previewThisReminderIn5SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {             
            await Task.Delay(5000);

            foreach(Reminder rem in GetSelectedRemindersFromListview())            
                PreviewReminder(rem);            
            
        }

        private async void previewThisReminderIn10SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            await Task.Delay(10000);

            foreach (Reminder rem in GetSelectedRemindersFromListview())
                PreviewReminder(rem);
        }

        private void pbWindows_Click(object sender, EventArgs e)
        {
            AddUserControl(pnlUserControls, ucWindows);            
        }

        private void pbMusic_Click(object sender, EventArgs e)
        {
            AddUserControl(pnlUserControls,ucMusic);            
        }
        private void pbImportExport_Click(object sender, EventArgs e)
        {
            AddUserControl(pnlUserControls, ucImportExport);
        }
        private void AddUserControl(Panel pnl,UserControl uc)
        {
            pnl.Controls.Clear();
            pnl.Controls.Add(uc);
        }

        private void btnBackFromSettings_Click(object sender, EventArgs e)
        {
            RefreshListview(lvReminders);
            ShowPanel(pnlMain);
        }             

        public void btnAddMonthlyDay_Click(object sender, EventArgs e)
        {
            int newValue = 1;
            try
            {
                newValue = Convert.ToInt32(cbEvery.Text);
                if (newValue > 0 && newValue < 32)
                {
                    cbEvery.SelectedItem = cbEvery.Items[newValue - 1];

                    if (!cbMonthlyDays.Items.Contains(cbEvery.SelectedItem.ToString()))
                        cbMonthlyDays.Items.Add(cbEvery.SelectedItem);
                    else
                        MakeScrollingPopupMessage("The number " + newValue + " is already added.");

                    SetDateTimePickerMonthlyValue();
                }
                else
                    throw new FormatException();
            }
            catch (FormatException)
            {
                MakeScrollingPopupMessage("Invalid number entered.\r\nPlease enter a number 1-31");
                if (cbEvery.Items.Count > 0)
                    cbEvery.SelectedItem = cbEvery.Items[0];
            }
            catch(Exception)
            {

            }
            
        }

        public void btnRemoveMonthlyDay_Click(object sender, EventArgs e)
        {
            cbMonthlyDays.Items.Remove(cbMonthlyDays.SelectedItem);
            SetDateTimePickerMonthlyValue();
        }

        
        /// <summary>
        /// Creates an popup message from the bottom right corner that slowly moves up.
        /// </summary>
        /// <param name="message">The message the popup should contain</param>
        private void MakeScrollingPopupMessage(string message)
        {
            UCPopupMessage mes = new UCPopupMessage(message);
            if(pnlPopup.Size == mes.Size && pnlPopup.Location.X == (this.Width - pnlPopup.Width) && pnlPopup.Location.Y < this.Height)
            {//The popup is already visible / onscreen
                mes.Dispose();
                return;
            }
            pnlPopup.Controls.Clear();
            pnlPopup.Controls.Add(mes);
            pnlPopup.Size = mes.Size;


            //Place it just out of sight of the bottom-right corner
            pnlPopup.Location = new Point(this.Width - pnlPopup.Width, this.Height);

            if (tmrAnimationScrollUp.Enabled)
                tmrAnimationScrollUp.Stop();

            if (tmrAnimationScrollDown.Enabled)
                tmrAnimationScrollDown.Stop();

            //animation time!
            tmrAnimationScrollUp.Start();
        }

        

        private async void tmrAnimationScrollUp_Tick(object sender, EventArgs e)
        {
            if (tmrAnimationScrollDown.Enabled)
                tmrAnimationScrollDown.Stop(); //Dont want to run the scroll down timer at the same time as the scroll up timer

            pnlPopup.Location = new Point(pnlPopup.Location.X, pnlPopup.Location.Y - 1);
            pnlPopup.Visible = true;

            if (pnlPopup.Location.Y <= this.Height - pnlPopup.Height)
            {
                tmrAnimationScrollUp.Stop();

                //make the message go down again after a while
                await Task.Delay(5000);


                //when dealing with delays, the timer that is set to stop() above can be set to start() again within that 5 second time-frame
                if (!tmrAnimationScrollUp.Enabled)
                    tmrAnimationScrollDown.Start();
            }
        }

        private void tmrAnimationScrollDown_Tick(object sender, EventArgs e)
        {
            if (tmrAnimationScrollUp.Enabled)
                tmrAnimationScrollUp.Stop(); //Dont want to run the scroll down timer at the same time as the scroll up timer

            //if the user pressed the red X, we don't need to do all this
            if (!pnlPopup.Visible)
                tmrAnimationScrollDown.Stop();

            pnlPopup.Location = new Point(pnlPopup.Location.X, pnlPopup.Location.Y + 1);            

            if (pnlPopup.Location.Y >= this.Height)
            {
                tmrAnimationScrollDown.Stop();
                pnlPopup.Visible = false;
                pnlPopup.Controls.Clear();
            }
           
        }

        private void cbEvery_KeyUp(object sender, KeyEventArgs e)
        {            
            if(e.KeyCode == Keys.Enter)
                btnAddMonthlyDay_Click(sender, e);            
        }

        private void cbEveryXCustom_TextChanged(object sender, EventArgs e)
        {
            if (cbEveryXCustom.SelectedItem == null)
                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[0]; //make sure the user cant type some random text into the combobox
        }

        private void cbMultipleDates_VisibleChanged(object sender, EventArgs e)
        {
            if (cbMultipleDates.Visible)
            {
                groupRepeatRadiobuttons.Location = new Point(cbMultipleDates.Location.X, cbMultipleDates.Location.Y + cbMultipleDates.Height + 5);
                dtpTime.Size = new Size(190, 20);
                btnAddDate.Visible = true;
                btnRemoveDate.Visible = true;
                lblAddedDates.Visible = true;                
            }
            else
            {
                dtpTime.Size = new Size(234,20);
                groupRepeatRadiobuttons.Location = new Point(dtpTime.Location.X, dtpTime.Location.Y + dtpTime.Height);
                btnAddDate.Visible = false;
                btnRemoveDate.Visible = false;
                lblAddedDates.Visible = false;
            }
        }

        public void btnAddDate_Click(object sender, EventArgs e)
        {
            if(pnlPopup.Visible)
            {//For this way of adding reminders, we DO want the scrolling popup to dissapear and re-appear again even if it is already visible
                HideScrollingPopupMessage();
            }
            DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
            if (selectedDate > DateTime.Now)
            {
                if (!cbMultipleDates.Items.Contains(selectedDate))
                {
                    cbMultipleDates.Items.Add(selectedDate);
                    MakeScrollingPopupMessage(selectedDate.ToString() + " Added to this reminder.");
                }
                else
                    HideScrollingPopupMessage();
            }
            else            
                MakeScrollingPopupMessage("The date you selected is in the past! Cannot add this date.");            
        }

        /// <summary>
        /// Removes the scrolling popup message from view and reset's its location
        /// </summary>
        private void HideScrollingPopupMessage()
        {
            pnlPopup.Visible = false;
            pnlPopup.Controls.Clear();
            pnlPopup.Location = new Point(pnlPopup.Location.X, this.Height);

            if (tmrAnimationScrollUp.Enabled)
                tmrAnimationScrollUp.Stop();

            if (tmrAnimationScrollDown.Enabled)
                tmrAnimationScrollDown.Stop();
        }
        

        private void groupRepeatRadiobuttons_LocationChanged(object sender, EventArgs e)
        {
            if(rbMultipleDays.Checked) //we should put the panel with monday-sunday under this groupbox            
                pnlDayCheckBoxes.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);           

            if(rbDaily.Checked || rbWorkDays.Checked) //same logic for both radiobuttons            
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);            

            if(rbMonthly.Checked)
            {
                cbEvery.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);
                tbNote.Location = new Point(cbEvery.Location.X, cbEvery.Location.Y + cbEvery.Height + 3);
            }

            if(rbNoRepeat.Checked)            
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);

            lblRepeat.Location = new Point(lblRepeat.Location.X, groupRepeatRadiobuttons.Location.Y + 3);
        }

        public void btnRemoveDate_Click(object sender, EventArgs e)
        {
            if (cbMultipleDates.SelectedItem != null)
            {
                MakeScrollingPopupMessage(cbMultipleDates.SelectedItem.ToString() + "\r\nRemoved from this reminder" );
                cbMultipleDates.Items.Remove(cbMultipleDates.SelectedItem);

                //Make it so that it doesn't have a selected item and remove the text.
                cbMultipleDates.SelectedItem = null;
                cbMultipleDates.Text = "";
            }
        }

        private void exportSelectedRemindersToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            string selectedPath = FSManager.Folders.GetSelectedFolderPath();
            BLReminder.ExportReminders(GetSelectedRemindersFromListview(), selectedPath);            
        }

        private void pnlPopup_VisibleChanged(object sender, EventArgs e)
        {
            if(!pnlPopup.Visible)
            {
                //Stop the timer(s)
                tmrAnimationScrollDown.Stop();
                tmrAnimationScrollUp.Stop();
                //reset location
                pnlPopup.Location = new Point(this.Width - pnlPopup.Width, this.Height);
            }
        }

        private async void tmrMessageFormScrollUp_Tick(object sender, EventArgs e)
        {
            popupForm.Location = new Point(popupForm.Location.X, popupForm.Location.Y - 2);

            if (popupForm.Location.Y <= Screen.GetWorkingArea(this).Height - popupForm.Height)
            {
                tmrMessageFormScrollUp.Stop();

                //stop scrolling up, wait 3 seconds, scroll down
                await Task.Delay(popupForm.PopDelay * 1000);
                tmrMessageFormScrollDown.Start();               
            }
        }

        private void tmrMessageFormScrollDown_Tick(object sender, EventArgs e)
        {
            popupForm.Location = new Point(popupForm.Location.X, popupForm.Location.Y + 2);

            if (popupForm.Location.Y >= Screen.GetWorkingArea(this).Height)
            {
                tmrMessageFormScrollDown.Stop();
                popupForm.TopMost = false;                
                popupForm.TopLevel = false;                
                popupForm.Dispose();                
            }
                  
        }

        private void pbCustomizePopup_Click(object sender, EventArgs e)
        {
            AddUserControl(pnlUserControls, ucCustomizePopup);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AddUserControl(pnlUserControls,ucSendMail);
        }


        /// <summary>
        /// Starts the mail timer. whenever the mail timer is ticking, the user is not allowed to send a new e-mail. 
        /// He can of course bypass this by closing remindme and restarting it for each e-mail, but that's fine.
        /// </summary>
        public void StartMailTimer()
        {
            tmrAllowMail.Start();            
        }
        public bool IsMailTimerTicking()
        {
            return tmrAllowMail.Enabled;
        }
        private void tmrAllowMail_Tick(object sender, EventArgs e)
        {
            tmrAllowMail.Stop();
        }

        private void tbNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                tbNote.SelectAll(); //Select all text in the textbox when you ctrl + a5
                tbNote.Focus();
            }
        }
    }
}


