using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        Settings set;
        //This list will contain reminders that need removing    
        List<Reminder> toRemoveReminders;

        bool allowRefreshListview = false;

        //contains the datetime of when remindme started. Used to refresh the listview if one day has passed,
        //to potentionally show a time instead of a date in the listview for reminders that are set for the new day
        int dayOfStartRemindMe;

        //Determines if the user entered characters that can't be used
        bool illegalCharacters = false;

        //Determines if the user is editing an reminder. If this reminder is null, the user is not currently editing one.
        Reminder editableReminder;        
        public Form1()
        {
            InitializeComponent();
            BLIO.CreateSettings();

            dayOfStartRemindMe = DateTime.Now.Day;

            imgStop = Properties.Resources.stopBlack;
            imgPlayResume = Properties.Resources.resume;

            toRemoveReminders = new List<Reminder>();


            //Read through all the reminders
            BLIO.ReadAllReminders();

            
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
            //BLIO.WriteError(new FieldAccessException(), "Exception in main.", true);

            //hide the form on startup
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
            }));

            //Add all reminders to the listview
            BLFormLogic.AddRemindersToListview(lvReminders, ReminderManager.GetReminders());

            this.BackgroundImage = Properties.Resources.gray;
            pictureBox4.BringToFront();
            
            //Start checking for reminders
            tmrCheckReminder.Start();

            //Resizes the form to it's original size.            
            this.Size = new Size(463, 430);

            //Make the buttons borderless-------------------
            BLFormLogic.RemovebuttonBorders(btnAddReminder);
            BLFormLogic.RemovebuttonBorders(btnBack);
            BLFormLogic.RemovebuttonBorders(btnRemoveReminder);
            BLFormLogic.RemovebuttonBorders(btnEditReminder);
            BLFormLogic.RemovebuttonBorders(btnConfirm);
            BLFormLogic.RemovebuttonBorders(btnDisableEnable);
            //----------------------------------------------   




            //Set the custom format for the time datetime picker (HH:mm) instead of HH:mm:ss
            dtpTime.Format = DateTimePickerFormat.Custom;

            btnPlaySound.BackgroundImage = imgPlayResume;

            //Create an shortcut in the windows startup folder if it doesn't already exist
            if(!File.Exists(Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk"))            
                BLIO.CreateShortcut();
        }

        
        /// <summary>
        /// Adds the week/monthly combobox between the layout and adjusts the location of the note textbox, and the two buttons below it.
        /// </summary>
        private void AddComboboxMonthlyWeekly()
        {
            lblEvery.Visible = true;
            cbEvery.Visible = true;

            tbNote.Location = new Point(tbNote.Location.X, cbEvery.Location.Y + (cbEvery.Height + 3));
            btnConfirm.Location = new Point(btnConfirm.Location.X, (tbNote.Location.Y + tbNote.Height + 3));
            btnBack.Location = new Point(btnBack.Location.X, btnConfirm.Location.Y);
            lblNote.Location = new Point(lblNote.Location.X, tbNote.Location.Y);

            if (rbEveryXDays.Checked)
            {
                numEveryXDays.Visible = true;
                lblEveryXDays.Visible = true;
            }
            else
            {
                numEveryXDays.Visible = false;
                lblEveryXDays.Visible = false;
            }

            if (rbMonthly.Checked || rbWeekly.Checked)
                cbEvery.Visible = true;
            else
                cbEvery.Visible = false;

            
        }


        /// <summary>
        /// Hides the week/monthly combobox between the layout and resets the location of the textbox and the buttons below it
        /// </summary>
        private void RemoveComboboxMonthlyWeekly()
        {
            cbEvery.Visible = false;
            lblEvery.Visible = false;
            numEveryXDays.Visible = false;
            lblEveryXDays.Visible = false;

            tbNote.Location = new Point(cbEvery.Location.X, cbEvery.Location.Y);
            lblNote.Location = new Point(lblEvery.Location.X, lblEvery.Location.Y);
            btnConfirm.Location = new Point(btnConfirm.Location.X, (tbNote.Location.Y + tbNote.Height + 3));
            btnBack.Location = new Point(btnBack.Location.X, btnConfirm.Location.Y);
        }

        /// <summary>
        /// Fills the controls of creating a new reminder with the data from the reminder
        /// </summary>
        private void FillControlsForEdit(Reminder rem)
        {
            if (lvReminders.SelectedItems.Count == 1)
            {
                if (rem != null)
                {
                    FillSoundComboBoxFromFile();
                    tbNote.Text = rem.Note.Replace("\\n", Environment.NewLine);
                    tbReminderName.Text = rem.Name;

                    if (rem.SoundFilePath != null)
                    {
                        string song = Path.GetFileNameWithoutExtension(rem.SoundFilePath);
                        ComboBoxItem reminderItem = ComboBoxItemManager.GetComboBoxItem(song, rem.SoundFilePath);

                        if (reminderItem != null)
                            cbSound.SelectedItem = reminderItem;
                    }
                    BLFormLogic.SwitchPanels(pnlNewReminder, pnlMain);

                    dtpDate.Value = Convert.ToDateTime(rem.Date);
                    dtpTime.Value = Convert.ToDateTime(rem.Time);

                    switch (rem.RepeatingType)
                    {
                        case ReminderRepeatType.NONE:
                            rbNoRepeat.Checked = true;
                            break;
                        case ReminderRepeatType.DAILY:
                            rbDaily.Checked = true;
                            break;
                        case ReminderRepeatType.MONTHLY:
                            rbMonthly.Checked = true;
                            cbEvery.SelectedItem = rem.DayOfMonth.ToString();
                            break;
                        case ReminderRepeatType.WORKDAYS:
                            rbWorkDays.Checked = true;
                            break;
                        case ReminderRepeatType.WEEKLY:
                            rbWeekly.Checked = true;

                            //Load combobox with monday-sunday
                            if (rem.DayOfWeek == 0) //0 = sunday. combobox starts with monday. sunday being 6
                                cbEvery.SelectedItem = cbEvery.Items[6];
                            else
                                cbEvery.SelectedItem = cbEvery.Items[rem.DayOfWeek - 1];

                            break;
                        case ReminderRepeatType.EVERY_X_DAYS:
                            rbEveryXDays.Checked = true;
                            numEveryXDays.Value = rem.EveryXDays;
                            break;
                    }
                }
                else
                    BLIO.WriteError(new ArgumentNullException(), "Error loading reminder", true);
            }
            else                                
                RemindMeBox.Show("Please select one reminder to edit at a time", RemindMeBoxIcon.INFORMATION);
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

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            editableReminder = null;

            //Switch the 2 panels giving the user the option to create or edit an reminder
            BLFormLogic.SwitchPanels(pnlNewReminder, pnlMain);
            //Reset the controls to their default values, empty text boxes etc
            BLFormLogic.ResetControlValues(pnlNewReminder);
            rbNoRepeat.Checked = true;

            dtpTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));
            pbExclamationDate.Visible = false;

            FillSoundComboBoxFromFile();

            //There's no selected item, so it should not appear that way either
            cbSound.Text = "";
        }

        private void btnRemoveReminder_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvReminders.SelectedItems)
            {
                if (File.Exists(Variables.IOVariables.remindersFolder + item.Text + ".ini"))                
                    File.Delete(Variables.IOVariables.remindersFolder + item.Text + ".ini");         
                                          
                lvReminders.Items.Remove(item);
            }


            ReminderManager.GetReminders().Clear();
            BLIO.ReadAllReminders();

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
            foreach (Reminder rem in ReminderManager.GetReminders())
            {
                //Create the popup. Do the other stuff afterwards.
                if (rem.CompleteDate <= DateTime.Now && rem.Enabled) //Check if it is enabled, and if it is ready to popup (Date of the reminder is smaller than date now)
                {                    
                    allowRefreshListview = true;

                    if (rem.RepeatingType == ReminderRepeatType.NONE)
                        toRemoveReminders.Add(rem);

                    BLFormLogic.MakePopup(rem);


                    if (rem.RepeatingType == ReminderRepeatType.WORKDAYS)
                    {
                        //Add days to the reminder so that the next date will be a new workday
                        ReminderManager.SetNextReminderWorkDay(rem);

                        //Write the changes to the file
                        BLIO.WriteChangedReminderToFile(rem);                        
                    }

                    if (rem.RepeatingType == ReminderRepeatType.DAILY)
                    {
                        //Add a day to the reminder
                        rem.CompleteDate = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + rem.Time).AddDays(1);

                        //Write the changes to the file
                        BLIO.WriteChangedReminderToFile(rem);
                    }
                                        
                    if (rem.RepeatingType == ReminderRepeatType.WEEKLY)
                    {
                        //Add a week to the reminder
                        //No matter what date the time was set to, the new date will be the date of the next x. x being the day of the week of the reminder.
                        //Like this, you won't get multiple popups if RemindMe hasnt been launched in a while, one popup for every week. 
                        rem.CompleteDate = Convert.ToDateTime(BLDateTime.GetDateOfNextDay(BLDateTime.GetDayOfWeekFromInt(rem.DayOfWeek)).ToShortDateString() + " " + rem.Time);

                        //Write the changes to the file
                        BLIO.WriteChangedReminderToFile(rem);
                    }

                    if (rem.RepeatingType == ReminderRepeatType.MONTHLY)
                    {
                        //Add a month. Change this while into: date = Datetime.Today.THISMONTH + addMonth(1);  ? maybe.
                        while(rem.CompleteDate < DateTime.Now)
                            rem.CompleteDate = rem.CompleteDate.AddMonths(1);
                        
                        //Write the changes to the file
                        BLIO.WriteChangedReminderToFile(rem);
                    }

                    if (rem.RepeatingType == ReminderRepeatType.EVERY_X_DAYS)
                    {
                        //Add a day to the reminder
                        rem.CompleteDate = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + rem.Time).AddDays(rem.EveryXDays);

                        //Write the changes to the file
                        BLIO.WriteChangedReminderToFile(rem);
                    }

                }                                             
            }

             foreach (Reminder rem in toRemoveReminders)
                ReminderManager.GetReminders().Remove(rem);


            //Refresh the listview. Using the boolean refreshListview, we dont refresh the listview every tick of the timer, that would be very unnecessary
            if (allowRefreshListview)
            {
                lvReminders.Items.Clear();
                BLFormLogic.AddRemindersToListview(lvReminders, ReminderManager.GetReminders());

                //set it to false again, otherwise it will continue to refresh every tick
                allowRefreshListview = false;
            }
        }

       

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSound.SelectedItem.ToString() == "Add files...")
            {
                cbSound.Items.Clear();
                ComboBoxItemManager.GetComboboxItems().Clear();

                //Fill selectedFiles with the selected files AND the current files, 
                //and check if it is not already in the list
                List<string> selectedFiles = BLIO.AddSoundsToFile();
                foreach (string sound in BLIO.ReadSoundFiles())
                    if (!selectedFiles.Contains(sound))
                        selectedFiles.Add(sound);
                

                foreach (string item in selectedFiles)  
                    if(item != "")                              
                         cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileName(item), item));                


                //Make sure that Add files... is on the bottom of the combobox
                
                cbSound.Items.Add("Add files...");
            }
        }

        private void rbNoRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoRepeat.Checked && editableReminder == null)
            {
                dtpDate.ResetText();
                dtpTime.ResetText();
            }

            if (cbEvery.Visible || numEveryXDays.Visible)
                RemoveComboboxMonthlyWeekly();
        }

        private void FillSoundComboBoxFromFile()
        {
            //Fill the list with all the sounds from the settings.ini file
            List<string> sounds = BLIO.ReadSoundFiles();

            cbSound.Items.Clear();
            ComboBoxItemManager.GetComboboxItems().Clear();

            if (sounds != null)
                foreach (string item in sounds)
                    if(item != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item), item));

           
            cbSound.Items.Remove("Add files...");
            cbSound.Items.Add("Add files...");
            cbSound.Sorted = true;
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
                    AddComboboxMonthlyWeekly();
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
                    AddComboboxMonthlyWeekly(); 
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
            //Will be different based on what repeating method the user has selected
            if (tbReminderName.Text != "" && (Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) > DateTime.Now) && !illegalCharacters)
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

                if (rbEveryXDays.Checked)
                    repeat = ReminderRepeatType.EVERY_X_DAYS;


                if (editableReminder == null) //If the user isn't editing an existing reminder, he's creating one
                {
                    Reminder rem = null;
                    tbReminderName.BackColor = Color.DimGray;
                    pbExclamationTitle.Visible = false;
                    pbExclamationDate.Visible = true;
                    
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





                    if (cbSound.SelectedItem != null && cbSound.SelectedItem.ToString() != "Add files...")
                    {
                        ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
                        soundPath = selectedItem.Value.ToString();
                    }

                    if (repeat == ReminderRepeatType.MONTHLY)
                        rem = new Reminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat, dayOfMonth, tbNote.Text.Replace(Environment.NewLine, "\\n"), true);
                    else if (repeat == ReminderRepeatType.WEEKLY)
                        rem = new Reminder(tbReminderName.Text, Convert.ToDateTime(BLDateTime.GetDateOfNextDay((DayOfWeek)(cbEvery.SelectedItem as ComboBoxItem).Value).ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat, tbNote.Text.Replace(Environment.NewLine, "\\n"), dayOfWeek, true);
                    else if (repeat == ReminderRepeatType.EVERY_X_DAYS)
                        rem = new Reminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, Convert.ToInt32(numEveryXDays.Value));
                    else
                        rem = new Reminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()), repeat, tbNote.Text.Replace(Environment.NewLine, "\\n"), true);


                    rem.SoundFilePath = soundPath;

                    if (rem != null)
                        BLIO.WriteReminderToFile(rem);
                }
                else
                {//The user is editing an existing reminder

                    string oldReminderName = editableReminder.Name; //The name before the change
                    editableReminder.Name = tbReminderName.Text;
                    editableReminder.CompleteDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
                    editableReminder.RepeatingType = repeat;
                    editableReminder.Note = tbNote.Text.Replace(Environment.NewLine, "\\n");
                    BLIO.WriteExistingReminderToFile(editableReminder, oldReminderName);
                }

                //clear the entire listview an re-fill it so that the listview is ordered by date again
                lvReminders.Items.Clear();
                BLFormLogic.AddRemindersToListview(lvReminders, ReminderManager.GetReminders());
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

                if(illegalCharacters)
                {
                    pbExclamationTitle.Visible = true;                    
                    toolTip1.SetToolTip(pbExclamationTitle, "The title contains characters that you can't use.\r\nCharacters: \\ / : * ? \" < > | [ ]");
                }
                ShowOrHideExclamation();


                
            }
        }

     

        private void pbSettings_Click(object sender, EventArgs e)
        {
            set = new Settings();
            set.Show();
        }

        private void btnEditReminder_Click(object sender, EventArgs e)
        {
            //Fill the form with the data from the single reminder selected from the listview.
            if (lvReminders.SelectedItems.Count > 0)
            {
                editableReminder = ReminderManager.GetReminderByName(lvReminders.SelectedItems[0].Text);
                cbSound.Text = "";
                FillControlsForEdit(editableReminder);
            }
        }

        private void btnDisableEnable_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in lvReminders.SelectedItems)
            {
                if (itm.SubItems[3].Text == "True")
                    itm.SubItems[3].Text = "False";
                else
                    itm.SubItems[3].Text = "True";

                Reminder rem = ReminderManager.GetReminderByName(itm.Text);
                rem.Enabled = Boolean.Parse(itm.SubItems[3].Text);

                BLIO.WriteChangedReminderToFile(rem);
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

            if(cbEvery.Visible || numEveryXDays.Visible)
                RemoveComboboxMonthlyWeekly();
        }

        private void rbWorkDays_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEvery.Visible || numEveryXDays.Visible)
                RemoveComboboxMonthlyWeekly();

            if (!rbWorkDays.Checked)
                pbExclamationWorkday.Visible = false;
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;

                if (btnPlaySound.BackgroundImage == imgPlayResume)
                {
                   
                    if (selectedItem != null)
                    {
                        if (System.IO.File.Exists(selectedItem.Value.ToString()))
                        {
                            btnPlaySound.BackgroundImage = imgStop;

                            myPlayer.URL = selectedItem.Value.ToString();
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
                            BLIO.WriteError(new System.IO.FileNotFoundException(), "Song doesn't exist in the specified folder anymore \r\n(" + selectedItem.Value.ToString() + ")", "\r\nHave you deleted or moved " + Path.GetFileName(selectedItem.Value.ToString()) + "? Please re-add it to RemindMe to use it again" , true);
                    }
                }
                else
                {
                    btnPlaySound.BackgroundImage = imgPlayResume;
                    myPlayer.controls.stop();
                    tmrMusic.Stop();
                }
            }
            catch(Exception ex)
            {
                BLIO.WriteError(ex, "Error while playing song " + myPlayer.URL + ".",true);
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

            if (rbWeekly.Checked)
            {
                //Set the date to today, instead of the next week IF the time is greater than now
                ComboBoxItem selectedItem = (ComboBoxItem)cbEvery.SelectedItem; //Error als maand geselecteer is
                if (dtpTime.Value > DateTime.Now.ToLocalTime() && selectedItem.Value.Equals(DateTime.Today.DayOfWeek))                
                    dtpDate.Value = DateTime.Today;                
            }
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

        private void tbReminderName_KeyUp(object sender, KeyEventArgs e)
        {
            List<string> blackList = new List<string> { "\\", "/", ":", "*", "?", "\"", "<", ">", "|", "[", "]" };


            for (int i = 0; i < blackList.Count; i++)
            {
                if (tbReminderName.Text.Contains(blackList[i]) || tbReminderName.Text.Count() >= 240)
                {
                    pbExclamationTitle.Visible = true;
                    illegalCharacters = true;
                    toolTip1.SetToolTip(pbExclamationTitle, "The title contains characters that you can't use.\r\nCharacters: \\ / : * ? \" < > | [ ]");
                    break;
                }
                else
                {
                    pbExclamationTitle.Visible = false;
                    illegalCharacters = false;
                }
            }
        }

        private void rbEveryXDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEveryXDays.Checked)
            {
                lblEvery.Text = "Every:";                                                

                AddComboboxMonthlyWeekly();
            }
                       
        }

        private void numEveryXDays_ValueChanged(object sender, EventArgs e)
        {
            if (numEveryXDays.Value <= 0) //You can't make a reminder that repeats every 0 days
                numEveryXDays.Value = 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
