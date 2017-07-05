using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

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

        //The stop playing preview sound icon
        Image imgStop;

        //The start playing preview sound icon
        Image imgPlayResume;

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        SettingsForm set;
        //This list will contain reminders that need removing    
        List<Reminder> toRemoveReminders;

        bool allowRefreshListview = false;

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        int dayOfStartRemindMe;



        //Determines if the user is editing an reminder. If this reminder is null, the user is not currently editing one.
        Reminder editableReminder;
        
        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.SetData("DataDirectory", Variables.IOVariables.databaseFile);
            BLIO.CreateSettings();

            //No database? create
            BLIO.CreateDatabaseIfNotExist();


            dayOfStartRemindMe = DateTime.Now.Day;

            imgStop = Properties.Resources.stopBlack;
            imgPlayResume = Properties.Resources.resume;

            toRemoveReminders = new List<Reminder>();            

            //We just call this method once, because if the settings table does not yet have a column AlwaysOnTop, it will default it to 1(true)
            DLSettings.IsAlwaysOnTop();
        }


        
        protected override void WndProc(ref Message m)
        {
            //Make RemindMe draggable from the top
             base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);        
        }

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //For testing purposes. create a test-reminder on startup------------------------
            /*Reminder rem = new Reminder();
            rem.Date = "2016-6-2 13:00:00";
            rem.Name = "testReminder";
            rem.Note = "This is a note for a test reminder\nwith\n\nsome spaces";
            rem.RepeatType = ReminderRepeatType.CUSTOM.ToString();
            rem.EveryXCustom = 5;
            rem.SoundFilePath = @"D:\users\rs\Music\sound effects\onee toch niet.wav";
            BLFormLogic.MakePopup(rem);*/
            //-------------------------------------------------------------------------------   


            //Subscribe all day checkboxes to our custom checked changed event, so that whenever any of these checkboxes change, the cbDaysCheckedChangeEvent will be fired
            cbMonday.CheckedChanged += cbDaysCheckedChangeEvent;            
            cbTuesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbWednesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbThursday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbFriday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSaturday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSunday.CheckedChanged += cbDaysCheckedChangeEvent;
            ResetReminderForm();                     

            //hide the form on startup
            BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                }));


            //Add all reminders to the listview
            BLFormLogic.AddRemindersToListview(lvReminders, DLReminders.GetReminders());

            this.BackgroundImage = Properties.Resources.gray;
            pictureBox4.BringToFront();
            
            //Start checking for reminders
            tmrCheckReminder.Start();

            //Resizes the form to it's original size.            
            this.Size = new Size(463, 475);

            //Make the buttons borderless-------------------
            BLFormLogic.RemovebuttonBorders(btnAddReminder);
            BLFormLogic.RemovebuttonBorders(btnBack);
            BLFormLogic.RemovebuttonBorders(btnRemoveReminder);
            BLFormLogic.RemovebuttonBorders(btnEditReminder);
            BLFormLogic.RemovebuttonBorders(btnConfirm);
            BLFormLogic.RemovebuttonBorders(btnDisableEnable);
            BLFormLogic.RemovebuttonBorders(btnClear);
            //----------------------------------------------   




            //Set the custom format for the time datetime picker (HH:mm) instead of HH:mm:ss
            dtpTime.Format = DateTimePickerFormat.Custom;

            btnPlaySound.BackgroundImage = imgPlayResume;

            //Create an shortcut in the windows startup folder if it doesn't already exist
            if(!File.Exists(Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk"))            
                BLIO.CreateShortcut();

            BLFormLogic.FillSoundComboboxFromDatabase(cbSound);
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
        /// Adds the week/monthly combobox between the layout and adjusts the location of the note textbox, and the buttons below it.
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

            if ((rbMonthly.Checked || rbWeekly.Checked) && !rbEveryXCustom.Checked)
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

        /// <summary>
        /// Fills the controls of creating a new reminder with the data from the reminder
        /// </summary>
        private void FillControlsForEdit(Reminder rem)
        {
            if (lvReminders.SelectedItems.Count == 1)
            {
                pnlDayCheckBoxes.Visible = false;

                if (rem != null)
                {                    
                    BLFormLogic.FillSoundComboboxFromDatabase(cbSound);
                    tbNote.Text = rem.Note.Replace("\\n", Environment.NewLine);
                    tbReminderName.Text = rem.Name;

                    if (rem.SoundFilePath != null)
                    {
                        string song = Path.GetFileNameWithoutExtension(rem.SoundFilePath);
                        ComboBoxItem reminderItem = ComboBoxItemManager.GetComboBoxItem(song, DLSongs.GetSongByFullPath(rem.SoundFilePath));

                        if (reminderItem != null)
                            cbSound.SelectedItem = reminderItem;
                    }
                    BLFormLogic.SwitchPanels(pnlNewReminder, pnlMain);

                    dtpDate.Value = Convert.ToDateTime(rem.Date);
                    dtpTime.Value = Convert.ToDateTime(Convert.ToDateTime(rem.Date).ToShortTimeString());

                    
                    switch (rem.RepeatType)
                    {
                        case "NONE":
                            rbNoRepeat.Checked = true;
                            break;
                        case "DAILY":
                            rbDaily.Checked = true;
                            break;
                        case "MONTHLY":
                            rbMonthly.Checked = true;
                            cbEvery.SelectedItem = rem.DayOfMonth.ToString();
                            break;
                        case "WORKDAYS":
                            rbWorkDays.Checked = true;
                            break;
                        case "WEEKLY":
                            rbWeekly.Checked = true;

                            //Load combobox with monday-sunday
                            if (rem.DayOfWeek == 0) //0 = sunday. combobox starts with monday. sunday being 6
                                cbEvery.SelectedItem = cbEvery.Items[6];
                            else
                                cbEvery.SelectedItem = cbEvery.Items[(int)rem.DayOfWeek - 1];
                            break;
                        case "MULTIPLE_DAYS": PlaceDayCheckBoxesPanel();
                            List<string> repeatDays = rem.RepeatDays.Split(',').ToList();
                            CheckDayCheckBoxes(repeatDays);
                            break;                   
                    }
                    if(rem.EveryXCustom != null)
                    {
                        rbEveryXCustom.Checked = true;
                        numEveryXDays.Value = (decimal)rem.EveryXCustom;

                        //The repeating type will now be different, because the user selected a custom reminder. repeating types will now be minutes,hours,days,weeks or months
                        switch (rem.RepeatType.ToLower())
                        {
                            case "minutes": cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[0];
                                break;
                            case "hours": cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[1];
                                break; 
                            case "days": cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2];
                                break;
                            case "weeks": cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[3];
                                break;
                            case "months": cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[4];
                                break;
                        }
                    }
                }
                else
                    BLIO.WriteError(new ArgumentNullException(), "Error loading reminder", true);
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

        private void ResetReminderForm()
        {
            cbSound.SelectedItem = null;
            pnlDayCheckBoxes.Visible = false;
            //Reset the controls to their default values, empty text boxes etc
            BLFormLogic.ResetControlValues(pnlNewReminder);
            BLFormLogic.ResetControlValues(pnlDayCheckBoxes);

            rbNoRepeat.Checked = true;


            //There's no selected item, so it should not appear that way either
            cbSound.Text = "";
            cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2]; //days

            dtpTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")).AddMinutes(1); //Add 1 minute so the exclamination won't show
            

            BLFormLogic.FillSoundComboboxFromDatabase(cbSound);
        }

        private void cbDaysCheckedChangeEvent(object sender, EventArgs e)
        {
            dtpDate.Value = BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString())?? DateTime.Now; 
            
        }

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            editableReminder = null;
            bool test = pnlDayCheckBoxes.Visible;
            if (!DLSettings.IsStickyForm())
            {
                ResetReminderForm();
                cbStickyForm.Checked = false;                
            }
            else
                cbStickyForm.Checked = true;

            pbExclamationDate.Visible = false;

            //Switch the 2 panels giving the user the option to create or edit an reminder
            BLFormLogic.SwitchPanels(pnlNewReminder, pnlMain);                                              
        }

        private void btnRemoveReminder_Click(object sender, EventArgs e)
        {
            if (lvReminders.SelectedItems.Count > 0)
            {
                List<Reminder> toRemoveReminders = new List<Reminder>();
                foreach (ListViewItem item in lvReminders.SelectedItems)
                {
                    toRemoveReminders.Add(DLReminders.GetReminderById(Convert.ToInt32(item.Tag)));
                    lvReminders.Items.Remove(item);                                                     //Remove it from the listview                    
                }
                
                //If the user selected multiple reminders, you don't open the database, remove the reminder, and close the database for every selected reminder this way
                DLReminders.DeleteReminders(toRemoveReminders);                
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
            }
                

            //We will check for reminders here every 30 seconds.
            foreach (Reminder rem in DLReminders.GetReminders())
            {
                //Create the popup. Do the other stuff afterwards.
                if(rem.PostponeDate != null && Convert.ToDateTime(rem.PostponeDate) <= DateTime.Now && rem.Enabled == 1)
                {
                    allowRefreshListview = true;

                    //temporarily disable it. When the user postpones the reminder, it will be re-enabled.
                    rem.Enabled = 0;
                    DLReminders.EditReminder(rem);

                    BLFormLogic.MakePopup(rem);
                }
                else if(Convert.ToDateTime(rem.Date) <= DateTime.Now && rem.PostponeDate == null && rem.Enabled == 1)
                {
                    allowRefreshListview = true;

                    //temporarily disable it. When the user postpones the reminder, it will be re-enabled.
                    rem.Enabled = 0;
                    DLReminders.EditReminder(rem);

                    BLFormLogic.MakePopup(rem);
                }
                                                                    
            }             
            //Refresh the listview. Using the boolean refreshListview, we dont refresh the listview every tick of the timer, that would be very unnecessary
            if (allowRefreshListview)
            {                
                BLFormLogic.RefreshListview(lvReminders);

                //set it to false again, otherwise it will continue to refresh every tick
                allowRefreshListview = false;                
            }
        }

        

       

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSound.SelectedItem != null)
            {
                if (cbSound.SelectedItem.ToString() == " Add files...")
                {
                    //Fill selectedFiles with the selected files AND the current files, 
                    //and check if it is not already in the list

                    List<string> selectedFiles = FSManager.Files.getSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();

                    if (selectedFiles.Count >= 1 && selectedFiles[0] != "") //[0] == "" if the user pressed cancel
                    {
                        cbSound.Items.Clear();
                        ComboBoxItemManager.GetComboboxItems().Clear();



                    }

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
                    DLSongs.InsertSongs(toInsertSongs);




                    foreach (Songs item in DLSongs.GetSongs())
                        if (item.SongFileName != "")
                            cbSound.Items.Add(new ComboBoxItem(item.SongFileName, DLSongs.GetSongByFullPath(item.SongFilePath)));

                    //Make sure that Add files... is in the combobox
                    cbSound.Items.Add(" Add files...");
                }
            }
        }

        private void rbNoRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoRepeat.Checked && editableReminder == null)
            {
                dtpDate.ResetText();
                dtpTime.ResetText();
                pnlDayCheckBoxes_VisibleChanged(sender, e);
            }

            RemoveComboboxMonthlyWeekly();
        }

        

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonthly.Checked)
            {
                //clear the combobox of previous data
                cbEvery.Items.Clear();

                for (int i = 1; i < 31; i++)
                    cbEvery.Items.Add(i.ToString()); //Add 1-31 string to it TODO: check if month x has x days. method GetDaysInMonth(int month) case 2: return 30, etc

                //Select the first item
                cbEvery.SelectedItem = cbEvery.Items[0];
                lblEvery.Text = "Day:";

                if (!cbEvery.Visible)
                    PlaceComboboxMonthlyWeekly();
                dtpDate.Enabled = false;
            }
            else            
                dtpDate.Enabled = true;                            
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWeekly.Checked)
            {
            

                //clear the combobox of previous data
                cbEvery.Items.Clear();

                

                ComboBoxItem[] days = { new ComboBoxItem("Monday", DayOfWeek.Monday), new ComboBoxItem("Tuesday", DayOfWeek.Tuesday) ,
                    new ComboBoxItem("Wednesday", DayOfWeek.Wednesday) , new ComboBoxItem("Thursday", DayOfWeek.Thursday) , new ComboBoxItem("Friday", DayOfWeek.Friday),
                    new ComboBoxItem("Saturday", DayOfWeek.Saturday) , new ComboBoxItem("Sunday", DayOfWeek.Sunday) };
                
                dtpDate.Enabled = false;

                cbEvery.Items.AddRange(days);

                cbEvery.SelectedItem = cbEvery.Items[0];
                lblEvery.Text = "Every:";

                if(!cbEvery.Visible)
                    PlaceComboboxMonthlyWeekly(); 
            }
            else           
                dtpDate.Enabled = true;                          
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Switch the 2 panels giving the user the option to create or edit an reminder
            BLFormLogic.SwitchPanels(pnlMain, pnlNewReminder);                        
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //set it to null at first, the user may not have this option selected            
            string commaSeperatedDays = "";

            //Will be different based on what repeating method the user has selected
            if (tbReminderName.Text != "" && (Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) > DateTime.Now))
            {
                ReminderRepeatType repeat = new ReminderRepeatType();
                if (rbMonthly.Checked)                                    
                    repeat = ReminderRepeatType.MONTHLY;                

                if (rbWeekly.Checked)                                    
                    repeat = ReminderRepeatType.WEEKLY;                

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

                int dayOfMonth = -1;
                int dayOfWeek = -1;
                string soundPath = "";  

                if (repeat == ReminderRepeatType.MONTHLY)
                {
                    if (cbEvery.SelectedItem != null)
                        dayOfMonth = Convert.ToInt16(cbEvery.SelectedItem.ToString());
                }

                if (repeat == ReminderRepeatType.WEEKLY)
                {
                    if (cbEvery.SelectedItem != null)
                        dayOfWeek = (int)(cbEvery.SelectedItem as ComboBoxItem).Value;
                }

                if(repeat == ReminderRepeatType.MULTIPLE_DAYS)                
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
                        DLReminders.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat.ToString(), dayOfMonth,null,null,null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                    else if (repeat == ReminderRepeatType.WEEKLY)
                    {
                        DateTime date = Convert.ToDateTime(BLDateTime.GetDateOfNextDay((DayOfWeek)(cbEvery.SelectedItem as ComboBoxItem).Value).ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());

                        if (Convert.ToDateTime(dtpTime.Value.ToShortTimeString()) > Convert.ToDateTime(DateTime.Now.ToShortTimeString()) && DateTime.Now.Day == date.Day)
                            date = date.AddDays(-7);

                        DLReminders.InsertReminder(tbReminderName.Text, date, repeat.ToString(), null,dayOfWeek,null,null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);

                    }
                    else if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        DLReminders.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat.ToString(), null, null, null, commaSeperatedDays, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                    else if (repeat == ReminderRepeatType.CUSTOM)
                        DLReminders.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), cbEveryXCustom.SelectedItem.ToString(), null, null, Convert.ToInt32(numEveryXDays.Value),null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true,  soundPath);                    
                    else
                        DLReminders.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat.ToString(),null,null,null,null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                                        
                    
                }
                else
                {//The user is editing an existing reminder                                        
                    editableReminder.Name = tbReminderName.Text;
                    editableReminder.Date = dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString();

                    if (editableReminder.EveryXCustom == null)
                        editableReminder.RepeatType = repeat.ToString();
                    else
                        editableReminder.RepeatType = cbEveryXCustom.SelectedItem.ToString();

                    editableReminder.SoundFilePath = soundPath;
                    editableReminder.Note = tbNote.Text.Replace(Environment.NewLine, "\\n");

                    if (repeat == ReminderRepeatType.WEEKLY)
                        editableReminder.DayOfWeek = dayOfWeek;
                    
                    if (repeat == ReminderRepeatType.MONTHLY)
                        editableReminder.DayOfMonth = dayOfMonth;

                    if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        editableReminder.RepeatDays = commaSeperatedDays;

                    if (editableReminder.EveryXCustom != null)
                        editableReminder.EveryXCustom = Convert.ToInt32(numEveryXDays.Value);


                    DLReminders.EditReminder(editableReminder);                    
                }

                //clear the entire listview an re-fill it so that the listview is ordered by date again
                lvReminders.Items.Clear();                
                BLFormLogic.AddRemindersToListview(lvReminders, DLReminders.GetReminders());
                BLFormLogic.SwitchPanels(pnlMain, pnlNewReminder);
                
            }
            else
            {
                if (tbReminderName.Text == "")
                {//User didnt fill in a title
                    tbReminderName.BackColor = Color.Red;
                   pbExclamationTitle.Visible = true;
                   toolTip1.SetToolTip(pbExclamationTitle, "Please enter a title.");
                }
                else
                {
                    tbReminderName.BackColor = Color.DimGray;
                    pbExclamationTitle.Visible = false;
                }


                ShowOrHideExclamation();


                
            }
        }

     

        private void pbSettings_Click(object sender, EventArgs e)
        {            
            set = new SettingsForm();
            set.Show();
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

        private void btnEditReminder_Click(object sender, EventArgs e)
        {           
            //Fill the form with the data from the single reminder selected from the listview.
            if (lvReminders.SelectedItems.Count > 0)
            {
                ListViewItem item = lvReminders.SelectedItems[0];                
                int id = Convert.ToInt32(item.Tag);
                editableReminder = DLReminders.GetReminderById(id);                            
                cbSound.Text = "";
                //cbSound.SelectedItem = ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(editableReminder.SoundFilePath), DLSongs.GetSongByFullPath(editableReminder.SoundFilePath));
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

                    Reminder rem = DLReminders.GetReminderById(Convert.ToInt32(itm.Tag));

                    if (Boolean.Parse(itm.SubItems[3].Text))
                        rem.Enabled = 1;
                    else
                        rem.Enabled = 0;

                    DLReminders.EditReminder(rem);

                }                
            }
        }


        private void tsSettings_Click(object sender, EventArgs e)
        {
            pbSettings_Click(sender, e);
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
            if (selectedItem != null)
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
                                DLSongs.RemoveSong(DLSongs.GetSongByFullPath(song.SongFilePath));

                                //We're throwing a new exception here. We're going to pass the song file path to the constructor of the exception, which will be read from program.cs
                                //All exceptions will be caught in Program.cs
                                throw new FileNotFoundException("", song.SongFilePath);
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
            if(rbWeekly.Checked)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cbEvery.SelectedItem;                
                                
                //Set the date of the weekly reminder to today, instead of next week. 
                //If the user wants a weekly reminder every wednesday, and it's wednesday today, we don't want to select next week's wednesday as the starting date of the reminder.
                if (dtpTime.Value > DateTime.Now.ToLocalTime() && selectedItem.Value.Equals(DateTime.Today.DayOfWeek))                
                    dtpDate.Value = DateTime.Today;                
                else
                    dtpDate.Value = BLDateTime.GetDateOfNextDay((DayOfWeek)selectedItem.Value);
            }
            if(rbMonthly.Checked)
            {
                dtpDate.ResetText();

                //Adjust the date of the datetimepicker to the day of the selected month
                int selectedDayOfMonth = Convert.ToInt16(cbEvery.SelectedItem.ToString());
                if (DateTime.Now.Day > selectedDayOfMonth)                
                    dtpDate.Value = dtpDate.Value.AddDays((selectedDayOfMonth - dtpDate.Value.Day)).AddMonths(1);                                                        
                else
                    dtpDate.Value = dtpDate.Value.AddDays((selectedDayOfMonth - dtpDate.Value.Day));
            }
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            ShowOrHideExclamation();
            cbEvery_SelectedIndexChanged(sender, e);            
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
        }

        private void lvReminders_DoubleClick(object sender, EventArgs e)
        {
            btnEditReminder_Click(sender, e);
        }

      

        private void rbEveryXDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEveryXCustom.Checked)
            {
                lblEvery.Text = "Every:";                                                
                PlaceComboboxMonthlyWeekly();
            }
                       
        }

        private void numEveryXDays_ValueChanged(object sender, EventArgs e)
        {
            if (numEveryXDays.Value <= 0) //You can't make a reminder that repeats every 0 days
                numEveryXDays.Value = 1;
        }

        private void cbStickyForm_CheckedChanged(object sender, EventArgs e)
        {
            //Get the settings from the database and put it in an object
            Settings set = DLSettings.GetSettings();


            //Give a new value to the Stickyform property
            if (cbStickyForm.Checked)
                set.StickyForm = 1;
            else
                set.StickyForm = 0;

            //Push it to the database
            DLSettings.UpdateSettings(set);
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
            //Whenever the textbox changes location somehow, these buttons need to be placed below it again
            btnConfirm.Location = new Point(btnConfirm.Location.X, (tbNote.Location.Y + tbNote.Height + 3));
            btnBack.Location = new Point(btnBack.Location.X, btnConfirm.Location.Y);
            btnClear.Location = new Point(btnBack.Location.X + (btnBack.Width + 3), btnBack.Location.Y);
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
                tbNote.Location = new Point(cbEvery.Location.X, (cbEvery.Location.Y + cbEvery.Size.Height) + 3);
            else if(!pnlDayCheckBoxes.Visible && (!cbEvery.Visible && !numEveryXDays.Visible))
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }

        private void numEveryXDays_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below this control if its visible
            if (numEveryXDays.Visible)
                tbNote.Location = new Point(numEveryXDays.Location.X, (numEveryXDays.Location.Y + numEveryXDays.Size.Height) + 3);
            else if (!pnlDayCheckBoxes.Visible)
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }

        
    }
}
