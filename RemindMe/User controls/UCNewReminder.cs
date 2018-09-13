using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Database.Entity;
using System.Runtime.InteropServices;
using WMPLib;
using System.IO;
using System.Reflection;

namespace RemindMe
{
    public partial class UCNewReminder : UserControl
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        //The stop playing preview sound icon
        Image imgStop;

        //The start playing preview sound icon
        Image imgPlayResume;

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        private Reminder editableReminder = null;

        public bool shouldDispose = false;

        UserControl callback;

        AdvancedReminderForm AVRForm;

        /// <summary>
        /// Create a new usercontrol to manage reminders
        /// </summary>
        /// <param name="callback">The usercontrol you should go back to when pressing the back button from UCNewReminder</param>
        public UCNewReminder(UserControl callback)
        {
            InitializeComponent();
            AVRForm = new AdvancedReminderForm();
            this.callback = callback;
            FillSoundComboboxFromDatabase(cbSound);
            SetComboBoxHeight(cbSound.Handle, 24);

            imgStop = Properties.Resources.Stop;
            imgPlayResume = Properties.Resources.Play;

            btnPlaySound.Image = imgPlayResume;

            //Subscribe all day checkboxes to our custom checked changed event, so that whenever any of these checkboxes change, the cbDaysCheckedChangeEvent will fire
            cbMonday.OnChange += cbDaysCheckedChangeEvent;
            cbTuesday.OnChange += cbDaysCheckedChangeEvent;
            cbWednesday.OnChange += cbDaysCheckedChangeEvent;
            cbThursday.OnChange += cbDaysCheckedChangeEvent;
            cbFriday.OnChange += cbDaysCheckedChangeEvent;
            cbSaturday.OnChange += cbDaysCheckedChangeEvent;
            cbSunday.OnChange += cbDaysCheckedChangeEvent;

            rbDaily.CheckedChanged += rbCheckedChangeEvent;
            rbMonthly.CheckedChanged += rbCheckedChangeEvent;
            rbMultipleDays.CheckedChanged += rbCheckedChangeEvent;
            rbNoRepeat.CheckedChanged += rbCheckedChangeEvent;
            rbEveryXCustom.CheckedChanged += rbCheckedChangeEvent;
            rbWorkDays.CheckedChanged += rbCheckedChangeEvent;


            AddDaysMenuStrip.Renderer = new MyToolStripMenuRenderer();
        }

        private void rbCheckedChangeEvent(object sender, EventArgs e)
        {
            if (rbMultipleDays.Checked) //we should put the panel with monday-sunday under this groupbox            
                pnlDayCheckBoxes.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);

            if (rbDaily.Checked || rbWorkDays.Checked) //same logic for both radiobuttons            
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);

            if (rbMonthly.Checked)
            {
                cbEvery.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);
                tbNote.Location = new Point(cbEvery.Location.X, cbEvery.Location.Y + cbEvery.Height + 3);
            }

            if (rbNoRepeat.Checked)
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height + 3);

            lblRepeat.Location = new Point(lblRepeat.Location.X, groupRepeatRadiobuttons.Location.Y + 3);
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
        /// Create a new usercontrol to manage reminders
        /// </summary>
        /// <param name="callback">The usercontrol you should go back to when pressing the back button from UCNewReminder</param>
        /// <param name="editableReminder">The reminder you wish to fill the controls with</param>
        public UCNewReminder(UserControl callback, Reminder editableReminder) : this(callback)
        {
            this.editableReminder = editableReminder;
            FillControlsForEdit(editableReminder);
        }


        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        /// <summary>
        /// Fills the controls of creating a new reminder with the data from the reminder
        /// </summary>
        private void FillControlsForEdit(Reminder rem)
        {
            pnlDayCheckBoxes.Visible = false;
            if (rem != null)
            {
                dtpTime.Value = Convert.ToDateTime(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortTimeString());
                DateTime remDate = Convert.ToDateTime(rem.Date.Split(',')[0]);

                //Due to some really weird bug in winforms, the .checked has to be set to true(even though it already is true) to fix a problem where the
                //datetimepicker does not show the text matching it's value
                dtpDate.Checked = true;
                dtpDate.Value = remDate;


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


                //reposition the textbox under the groupbox. null,null because we're not doing anything with the parameters
                pnlDayCheckBoxes_VisibleChanged(null, null);

                //Now, let's see if this reminder has any advanced properties
                AdvancedReminderProperties avrProps = BLAVRProperties.GetAVRProperties(rem.Id);
                List<AdvancedReminderFilesFolders> avrFF = BLAVRProperties.GetAVRFilesFolders(rem.Id);
                if (avrProps != null)
                {
                    if(avrProps.ShowReminder.HasValue)
                        AVRForm.ShowReminder = (long)avrProps.ShowReminder;

                    AVRForm.BatchScript = avrProps.BatchScript;
                    if (BLSettings.GetSettings().EnableAdvancedReminders == 1)
                    {
                        cbAdvancedReminder.Visible = true;
                        lblAdvancedReminders.Visible = true;
                    }
                    cbAdvancedReminder.Checked = rem.EnableAdvancedReminder == 1;

                    if (!cbAdvancedReminder.Checked)
                        lblAdvancedReminders.Text = "Disabled.";
                    else
                        lblAdvancedReminders.Text = "Enabled!";
                }
                if (avrFF != null)
                {
                    Dictionary<string, string> filesFolders = new Dictionary<string, string>();
                    foreach (AdvancedReminderFilesFolders dic in avrFF)
                    {
                        if(!filesFolders.ContainsKey(dic.Path))
                            filesFolders.Add(dic.Path, dic.Action);
                    }
                    AVRForm.FilesFolders = filesFolders;                    
                }                
            }
            else
            {
                BLIO.WriteError(new ArgumentNullException(), "Error loading reminder");
                ErrorPopup pop = new ErrorPopup("Error loading reminder. Reminder is null", new ArgumentNullException());
                pop.Show();
            }

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
        /// Gets all the sounds from the database and fills the combobox with them.
        /// </summary>
        /// <param name="cbSound"></param>
        private void FillSoundComboboxFromDatabase(ComboBox cbSound)
        {
            //Fill the list with all the sounds from the Database(non default windows ones)
            List<Songs> sounds = BLSongs.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();            

            cbSound.Items.Clear();
            ComboBoxItemManager.ClearComboboxItems();

            if (sounds != null)
                foreach (Songs item in sounds)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));            

            //Let's make sure the default windows System sounds are placed at the bottom
            List<Songs> windowsDefaultSongs = BLSongs.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() == "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();            

            if (windowsDefaultSongs != null)
                foreach (Songs item in windowsDefaultSongs)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));

            cbSound.Items.Remove(" Add files...");
            cbSound.Items.Add(" Add files...");
            
        }


        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            BLIO.Log("Attempting to play a sound...");
            if (cbSound.SelectedItem == null || cbSound.SelectedItem.ToString() == " Add files..." ||  String.IsNullOrWhiteSpace(cbSound.SelectedItem.ToString()))
                return;

            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem != null)
            {
                
                Songs selectedSong = (Songs)selectedItem.Value;
                BLIO.Log("selected sound file is valid (UCNewReminder)");

                if (btnPlaySound.Image == imgPlayResume)
                {

                    if (selectedItem != null)
                    {
                        if (System.IO.File.Exists(selectedSong.SongFilePath))
                        {
                            BLIO.Log("selected sound file exists on hard drive (UCNewReminder)");
                            btnPlaySound.Image = imgStop;

                            myPlayer.URL = selectedSong.SongFilePath;
                            mediaInfo = myPlayer.newMedia(myPlayer.URL);

                            //Start the timer. the timer ticks when the song ends. The timer will then reset the picture of the play button                        
                            if (mediaInfo.duration > 0)
                                tmrMusic.Interval = (int)(mediaInfo.duration * 1000);
                            else
                                tmrMusic.Interval = 1000;
                            tmrMusic.Start();

                            BLIO.Log("Playing sound... (UCNewReminder)");
                            myPlayer.controls.play();
                        }
                        else
                        {
                            BLIO.Log("selected sound file does not exist on hard drive anymore (UCNewReminder)");
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

                                BLIO.Log("selected sound file removed from RemindMe as it no longer exists on the hard drive (UCNewReminder)");

                                //Show the user the message that the file is no longer at the specified path.
                                RemindMeBox.Show("Could not play " + song.SongFileName + " located at \"" + song.SongFilePath + "\" \r\nDid you move,rename or delete the file ?", RemindMeBoxReason.OK, false);
                            }
                            
                        }
                    }
                }
                else
                {
                    btnPlaySound.Image = imgPlayResume;
                    myPlayer.controls.stop();
                    tmrMusic.Stop();
                }
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPlaySound.Image = imgPlayResume;
            tmrMusic.Stop();
        }

        private void cbDaysCheckedChangeEvent(object sender, EventArgs e)
        {
            DateTime? selectedDateFromCheckboxes = BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString()) ?? DateTime.Now;

            dtpDate.Value = selectedDateFromCheckboxes ?? DateTime.Now;
            dtpDate.Value = selectedDateFromCheckboxes ?? DateTime.Now;


            if (IsDayCheckboxChecked(DateTime.Now.DayOfWeek))
            {//Check if the checkbox of today's dayofweek is checked
                //Then, if the selected time is in the FUTURE, we want to set the date to today.
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) > DateTime.Now)
                {
                    dtpDate.Value = DateTime.Now;
                    dtpDate.Value = DateTime.Now;
                }
            }

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
        /// gets all the checked day comboboxes and puts them into a string. example: monday,tuesday,friday
        /// </summary>
        /// <returns></returns>
        private string GetCommaSeperatedDayCheckboxesString()
        {
            Bunifu.Framework.UI.BunifuCheckbox check;
            string commaSeperatedDays = "";
            //loop through the selected checkboxes
            foreach (Control cb in pnlDayCheckBoxes.Controls)
            {
                if (cb is Bunifu.Framework.UI.BunifuCheckbox)
                {
                    check = (Bunifu.Framework.UI.BunifuCheckbox)cb;
                    if (check.Checked)
                        commaSeperatedDays += cb.Name.Substring(2, cb.Name.Length - 2).ToLower() + ",";
                }
            }
            if (commaSeperatedDays.Length > 0)
                commaSeperatedDays = commaSeperatedDays.Remove(commaSeperatedDays.Length - 1, 1); //remove the last ','

            return commaSeperatedDays;
        }

        /// <summary>
        /// Checks if a day checkbox for the given day is checked
        /// </summary>
        /// <param name="day">The day you want to check for selection</param>
        /// <returns>True if the given day is selected, false if not</returns>
        private bool IsDayCheckboxChecked(DayOfWeek day)
        {
            switch (day)
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

        private void rbMultipleDays_CheckedChanged(object sender, EventArgs e)
        {
            BLIO.Log("Reminder type set to week days");
            if (rbMultipleDays.Checked)
                PlaceDayCheckBoxesPanel();
            else
                pnlDayCheckBoxes.Visible = false;
        }

        private void pnlDayCheckBoxes_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below the panel if its visible
            if (pnlDayCheckBoxes.Visible)
                tbNote.Location = new Point(pnlDayCheckBoxes.Location.X, (pnlDayCheckBoxes.Location.Y + pnlDayCheckBoxes.Size.Height) + 3);
            else if (cbEvery.Visible || numEveryXDays.Visible) //if those are visible, place the textbox below them
                tbNote.Location = new Point(cbEvery.Location.X, (cbEvery.Location.Y + cbEvery.Size.Height) + 3);
            else // if they're not, AND the pnlDaycheckBoxes isnt visible EITHER, place them below the groupbox of radio buttons
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }

        private void cbEvery_VisibleChanged(object sender, EventArgs e)
        {
            //The note textbox has to be placed below the combobox if its visible
            if (cbEvery.Visible)
            {
                if (rbMonthly.Checked)
                {
                    btnAddMonthlyDay.Location = new Point(cbEvery.Location.X + cbEvery.Width + 2, cbEvery.Location.Y);
                    btnRemoveMonthlyDay.Location = new Point(btnAddMonthlyDay.Location.X + btnAddMonthlyDay.Width + 2, btnAddMonthlyDay.Location.Y);
                    cbMonthlyDays.Location = new Point(btnRemoveMonthlyDay.Location.X + btnRemoveMonthlyDay.Width + 2, btnRemoveMonthlyDay.Location.Y);
                }
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
                numEveryXDays.Location = new Point(numEveryXDays.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Height) + 2);
                lblEvery.Location = new Point(lblEvery.Location.X, numEveryXDays.Location.Y);
                tbNote.Location = new Point(numEveryXDays.Location.X, (numEveryXDays.Location.Y + numEveryXDays.Size.Height) + 3);
                cbEveryXCustom.Location = new Point((numEveryXDays.Location.X + numEveryXDays.Width) + 2, numEveryXDays.Location.Y);

            }
            else if (!pnlDayCheckBoxes.Visible)
                tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
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
        private void rbNoRepeat_CheckedChanged(object sender, EventArgs e)
        {
            BLIO.Log("Reminder type set to set date(s)");
            RemoveComboboxMonthlyWeekly();
            if (rbNoRepeat.Checked && editableReminder == null)
            {
                dtpDate.ResetText();
                dtpTime.ResetText();
            }

            if (rbNoRepeat.Checked)
            {
                pnlDayCheckBoxes_VisibleChanged(sender, e);
                cbMultipleDates.Visible = true;
            }
            else
            {
                cbMultipleDates.Visible = false;
            }
        }

        private void rbEveryXCustom_CheckedChanged(object sender, EventArgs e)
        {
            BLIO.Log("Reminder type set to custom");
            if (rbEveryXCustom.Checked)
            {
                lblEvery.Text = "Every:";
                if (editableReminder == null || (editableReminder != null && editableReminder.EveryXCustom == null))
                    cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2]; //days
                else if (editableReminder.EveryXCustom != null)
                {

                }
            }

            PlaceComboboxMonthlyWeekly();
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {

            BLIO.Log("Reminder type set to monthly");
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
                cbMonthlyDays.Items.Clear();


            }
            else
            {
                cbEvery.Visible = false;
                dtpDate.Enabled = true;
            }
        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            BLIO.Log("Reminder type set to daily");
            RemoveComboboxMonthlyWeekly();
        }

        private void rbWorkDays_CheckedChanged(object sender, EventArgs e)
        {
            BLIO.Log("Reminder type set to work days");
            RemoveComboboxMonthlyWeekly();

            if (!rbWorkDays.Checked)
                pbExclamationWorkday.Visible = false;
        }

        private void cbMultipleDates_VisibleChanged(object sender, EventArgs e)
        {
            if (cbMultipleDates.Visible)
            {
                groupRepeatRadiobuttons.Location = new Point(cbMultipleDates.Location.X, (cbMultipleDates.Location.Y + cbMultipleDates.Height + 2));
                dtpTime.Size = new Size(329, 25);
                btnAddDate.Visible = true;
                btnRemoveDate.Visible = true;
                lblAddedDates.Visible = true;
            }
            else
            {
                //not visible? place the repeat radio button groupbox on this place
                groupRepeatRadiobuttons.Location = cbMultipleDates.Location;

                dtpTime.Size = new Size(366, 20);
                groupRepeatRadiobuttons.Location = new Point(dtpTime.Location.X, dtpTime.Location.Y + dtpTime.Height);
                btnAddDate.Visible = false;
                btnRemoveDate.Visible = false;
                lblAddedDates.Visible = false;
            }
        }

        private void tbNote_LocationChanged(object sender, EventArgs e)
        {
            lblNote.Location = new Point(lblNote.Location.X, tbNote.Location.Y);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            cbSunday.Checked = !cbSunday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            cbThursday.Checked = !cbThursday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            cbFriday.Checked = !cbFriday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            cbSaturday.Checked = !cbSaturday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            cbWednesday.Checked = !cbWednesday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            cbTuesday.Checked = !cbTuesday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }



        private void label7_Click_1(object sender, EventArgs e)
        {
            cbMonday.Checked = !cbMonday.Checked;
            cbDaysCheckedChangeEvent(sender, e);
        }

        

        private void cbEveryXCustom_TextChanged(object sender, EventArgs e)
        {
            if (cbEveryXCustom.SelectedItem == null)
                cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[0]; //make sure the user cant type some random text into the combobox
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
        private void btnAddMonthlyDay_Click(object sender, EventArgs e)
        {
            int newValue = 1;
            try
            {
                BLIO.Log("attempting to add a monthly day to this reminder");
                newValue = Convert.ToInt32(cbEvery.Text);
                if (newValue > 0 && newValue < 32)
                {
                    
                    cbEvery.SelectedItem = cbEvery.Items[newValue - 1];
                    

                    if (!cbMonthlyDays.Items.Contains(cbEvery.SelectedItem.ToString()))
                    {
                        cbMonthlyDays.Items.Add(cbEvery.SelectedItem);
                        BLIO.Log("value between 1 and 31! setted the selected item (" + cbEvery.SelectedItem.ToString() + ") and added it to cbMonthlyDays");
                    }
                    // else
                    //MakeScrollingPopupMessage("The number " + newValue + " is already added.");

                    SetDateTimePickerMonthlyValue();
                }
                else
                    throw new FormatException();
            }
            catch (FormatException)
            {
                //MakeScrollingPopupMessage("Invalid number entered.\r\nPlease enter a number 1-31");
                if (cbEvery.Items.Count > 0)
                    cbEvery.SelectedItem = cbEvery.Items[0];
            }
            catch (Exception)
            {

            }
        }

        private void btnRemoveMonthlyDay_Click(object sender, EventArgs e)
        {
            BLIO.Log("removing monthly day from cbMonthlyDays (" + cbMonthlyDays.SelectedItem.ToString() + ")");
            cbMonthlyDays.Items.Remove(cbMonthlyDays.SelectedItem);
            SetDateTimePickerMonthlyValue();
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            BLIO.Log("Attempting to add date to reminder...");
            DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
            if (selectedDate > DateTime.Now)
            {
                BLIO.Log("selectedDate > DateTime.now !");
                if (!cbMultipleDates.Items.Contains(selectedDate))
                {
                    BLIO.Log("reminder doesnt have this date yet!");
                    cbMultipleDates.Items.Add(selectedDate);
                    BLIO.Log("Added date to cbMultipleDates combobox");
                    MessageFormManager.MakeMessagePopup(selectedDate.ToString() + " Added to this reminder.", 1);
                }
                else
                    MessageFormManager.MakeMessagePopup("You have already added that date.", 1);
            }
            else
                MessageFormManager.MakeMessagePopup("The date you selected is in the past! Cannot add this date.", 3);
        }

        private void btnRemoveDate_Click(object sender, EventArgs e)
        {
            if (cbMultipleDates.SelectedItem != null)
            {
                BLIO.Log("attempting to remove date from reminder");
                //MakeScrollingPopupMessage(cbMultipleDates.SelectedItem.ToString() + "\r\nRemoved from this reminder");
                cbMultipleDates.Items.Remove(cbMultipleDates.SelectedItem);
                BLIO.Log("date removed");

                //Make it so that it doesn't have a selected item and remove the text.
                cbMultipleDates.SelectedItem = null;
                cbMultipleDates.Text = "";
            }
        }
        private bool IsAtLeastOneWeeklyCheckboxSelected()
        {
            foreach (Control c in pnlDayCheckBoxes.Controls)
            {
                if (c is Bunifu.Framework.UI.BunifuCheckbox)
                {
                    Bunifu.Framework.UI.BunifuCheckbox theCheckbox = (Bunifu.Framework.UI.BunifuCheckbox)c;
                    if (theCheckbox.Checked)
                        return true;
                }
            }
            return false;
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

            if (rem.RepeatType != "Minutes" && rem.RepeatType != "Hours" && rem.RepeatType != "Days" && rem.RepeatType != "Weeks" && rem.RepeatType != "Months")
                rem.EveryXCustom = null;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            BLIO.Log("User pressed confirm at reminder user control. Attempting to create/edit a reminder (UCNewReminder)");
            //set it to empty at first, the user may not have this option selected            
            string commaSeperatedDays = "";
            long remId = -1;

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
                            remId = BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMonthlyDaysComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            //MakeScrollingPopupMessage("Can not create an reminder with monthly day(s) if there are no days selected!");
                            pbExclamationDate.Visible = false;

                            return;
                        }
                    }

                    else if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        if (IsAtLeastOneWeeklyCheckboxSelected())
                            remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, commaSeperatedDays, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            //MakeScrollingPopupMessage("You do not have any day(s) selected!");
                            return;
                        }
                    else if (repeat == ReminderRepeatType.CUSTOM)
                        remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), cbEveryXCustom.SelectedItem.ToString(), Convert.ToInt32(numEveryXDays.Value), null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                    else if (repeat == ReminderRepeatType.NONE)
                    {
                        DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
                        if (!cbMultipleDates.Items.Contains(selectedDate) && selectedDate > DateTime.Now)
                            cbMultipleDates.Items.Add(selectedDate);//If the user pressed confirm, but didnt "+" the date yet, we'll do it for him.                                              

                        if (cbMultipleDates.Items.Count > 0)
                            remId = BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMultipleDatesComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            //MakeScrollingPopupMessage("You have not added any dates!\r\nIf you have selected a date and want only that one, press the \"+\" button");
                            return;
                        }
                    }
                    else
                        remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);

                    BLIO.Log("New reminder succesfully created! (UCNewReminder)");
                }
                else
                {//The user is editing an existing reminder                                        
                    editableReminder.Name = tbReminderName.Text;
                    remId = editableReminder.Id;
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
                                editableReminder.Date = editableReminder.Date = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString();//Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString())).ToShortDateString() + " " + dtpTime.Value.ToShortTimeString();
                            else
                            {
                                //MakeScrollingPopupMessage("You do not have any day(s) selected!");
                                return;
                            }
                            break;
                        case "NONE":

                            DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
                            if (!cbMultipleDates.Items.Contains(selectedDate) && selectedDate > DateTime.Now)
                                cbMultipleDates.Items.Add(selectedDate);//If the user pressed confirm, but didnt "+" the date yet, we'll do it for him.  
                            else
                            {
                                if (selectedDate < DateTime.Now)
                                    MessageFormManager.MakeMessagePopup("The selected date is in the past!", 4);
                            }

                            if (cbMultipleDates.Items.Count > 0)
                                editableReminder.Date = GetDatesStringFromMultipleDatesComboBox();
                            else
                            {
                                //MakeScrollingPopupMessage("You have not added any dates!\r\nIf you have selected a date and want only that one, press the \"+\" button");
                                return;
                            }
                            break;
                        case "MONTHLY":
                            if (cbMonthlyDays.Items.Count > 0)
                                editableReminder.Date = GetDatesStringFromMonthlyDaysComboBox();
                            else
                            {
                                //MakeScrollingPopupMessage("Can not create an reminder with monthly day(s) if there are no days selected!");
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
                    BLIO.Log("Reminder with id " + editableReminder.Id + " edited! (UCNewReminder)");
                }


                //Assign AVR properties to this reminder                                
                CreateAdvancedReminderProperties(remId);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbReminderName.Text))
                {//User didnt fill in a title
                    tbReminderName.LineIdleColor = Color.Red;
                    pbExclamationTitle.Visible = true;
                    toolTip1.SetToolTip(pbExclamationTitle, "Please enter a title.");
                }
                else
                {//if(!cbmonthly.selected) TODO
                    tbReminderName.BackColor = Color.DimGray;
                    pbExclamationTitle.Visible = false;
                }


                ShowOrHideExclamation();

                //MakeScrollingPopupMessage("Some fields are not valid. Please see the exclaminations");
                BLIO.Log("Could not create a reminder. some fields are not valid (UCNewReminder)");
                return;
            }


            //If there is an scrolling popup, hide it.
            //HideScrollingPopupMessage();            
            btnBack_Click(sender, e);

        }

        private void CreateAdvancedReminderProperties(long remId)
        {
            Reminder rem = BLReminder.GetReminderById(remId);
            rem.EnableAdvancedReminder = cbAdvancedReminder.Checked ? 1 : 0;
            BLReminder.EditReminder(rem);

            //Create AVR properties and insert them into the database
            AdvancedReminderProperties avr = BLAVRProperties.GetAVRProperties(remId);
            if (avr == null) { avr = new AdvancedReminderProperties(); }

            avr.ShowReminder = AVRForm.ShowReminder;
            avr.BatchScript = AVRForm.BatchScript;
            avr.Remid = remId; //Link this reminder to it
            BLAVRProperties.InsertAVRProperties(avr);

            //Create AVR properties for file/folder actions and insert them into the database
            AdvancedReminderFilesFolders avrFF = new AdvancedReminderFilesFolders();

            //Delete all the files/folders with this id. Then insert the ones we have now in case the user deleted some
            BLAVRProperties.DeleteAvrFilesFoldersById(remId);

            foreach (KeyValuePair<string, string> entry in AVRForm.FilesFolders)
            {
                avrFF.Path = entry.Key;
                avrFF.Id = -1;
                avrFF.Action = entry.Value;
                avrFF.Remid = remId; //Link this reminder to it
                BLAVRProperties.InsertAVRFilesFolders(avrFF);
            }
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
                DateTime date = BLDateTime.GetDateForNextDayOfMonth(day, dtpTime.Value);
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
        /// Resets all the controls to their original state.
        /// </summary>
        private void ResetControlValues()
        {
            RadioButton rb;
            foreach (Control c in this.Controls)
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
                    CheckBox check = (CheckBox)c;
                    check.Checked = false;
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

        public void ResetReminderForm()
        {
            cbSound.SelectedItem = null;
            pnlDayCheckBoxes.Visible = false;
            //Reset the controls to their default values, empty text boxes etc            
            ResetControlValues();

            rbNoRepeat.Checked = true;
            cbMultipleDates.Visible = true;
            cbEvery_VisibleChanged(null, null);

            //There's no selected item, so it should not appear that way either
            cbSound.Text = "";
            cbEveryXCustom.SelectedItem = cbEveryXCustom.Items[2]; //days

            dtpTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")).AddMinutes(1); //Add 1 minute so the exclamination won't show


            FillSoundComboboxFromDatabase(cbSound);
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
                if (dtpDate.Value.DayOfWeek != DayOfWeek.Saturday && dtpDate.Value.DayOfWeek != DayOfWeek.Sunday)
                    pbExclamationWorkday.Visible = false;
                else
                {
                    pbExclamationWorkday.Visible = true;
                    toolTip1.SetToolTip(pbExclamationWorkday, "The day you selected is not a work day.");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BLIO.Log("User pressed back (UCNewReminder)");
            shouldDispose = true;
            btnPlaySound.Image = imgPlayResume;
                                    
            if(myPlayer.controls.currentPosition != 0)
                BLIO.Log("stopping music");

            myPlayer.controls.stop();
            tmrMusic.Stop();

            //Refresh listview with the newly made reminder            
            UCReminders.NotifyChange();


            this.Parent.Controls.Add(callback);            
            this.Parent.Controls.Remove(this);                                           
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ShowOrHideExclamation();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            ShowOrHideExclamation();

            if (rbDaily.Checked && Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()) < DateTime.Now)
                dtpDate.Value = DateTime.Now.AddDays(1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            BLIO.Log("Clearing reminder form (UCNewReminder)");
            ResetReminderForm();
        }

        private void UCNewReminder_Load(object sender, EventArgs e)
        {
            cbEvery.LocationChanged += cbEvery_VisibleChanged;
            dtpTime.Format = DateTimePickerFormat.Custom;
            btnAdvancedReminder.Visible = BLSettings.GetSettings().EnableAdvancedReminders == 1;

            if (editableReminder == null)
                ResetReminderForm();                        
        }

        private void cbEvery_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddMonthlyDay_Click(sender, e);
        }

        private void btnAddDays_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDate.Enabled)
                {
                    AddDaysMenuStrip.Show(Cursor.Position);
                    BLIO.Log("bringing up the menu when the user clicks ... (UCNewReminder)");
                }
                    
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large."); }

        }

        private void addMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddMinutes = RemindMePrompt.ShowNumber("Add minutes to the current time");
                dtpDate.Value = DateTime.Now.AddMinutes(toAddMinutes);
                dtpTime.Value = DateTime.Now.AddMinutes(toAddMinutes);
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large."); }

        }

        private void addDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddDays = RemindMePrompt.ShowNumber("Add days to the selected date");
                dtpDate.Value = dtpDate.Value.AddDays(toAddDays);
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large.", false); }

        }

        private void addMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddMonths = RemindMePrompt.ShowNumber("Add months to the selected date");
                dtpDate.Value = dtpDate.Value.AddMonths(toAddMonths);
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large.", false); }

        }

        private void subtractDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toSubtractDays = RemindMePrompt.ShowNumber("Subtract days to the selected date");
                dtpDate.Value = dtpDate.Value.AddDays(-toSubtractDays);
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large.", false); }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int toSubtractMonths = RemindMePrompt.ShowNumber("Subtract months to the selected date");
                dtpDate.Value = dtpDate.Value.AddMonths(-toSubtractMonths);
            }
            catch (ArgumentOutOfRangeException ex) { RemindMeBox.Show("Entered number is too large.", false); }

        }

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSound.SelectedItem != null)
            {
                if (cbSound.SelectedItem.ToString() == " Add files...")
                {
                    BLIO.Log("combobox sound selected index changed. selecteditem != null && item string == add files...");
                    //Fill selectedFiles with the selected files AND the current files, 
                    //and check if it is not already in the list

                    List<string> selectedFiles = FSManager.Files.GetSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();

                    if (selectedFiles.Count == 1 && selectedFiles[0] == "")
                        return;

                    List<Songs> toInsertSongs = new List<Songs>();

                    foreach (string sound in selectedFiles.Where(song => !BLSongs.SongExistsInDatabase(song) && song != "").ToList())
                    {
                        Songs song = new Songs();
                        song.SongFilePath = sound;
                        song.SongFileName = Path.GetFileName(sound);
                        toInsertSongs.Add(song);
                    }

                    BLSongs.InsertSongs(toInsertSongs);

                    //already inserted, but iterating through them to add to the combobox
                    foreach (Songs item in toInsertSongs.Where(itm => itm.SongFileName != "").ToList()) 
                            cbSound.Items.Add(new ComboBoxItem(Path.GetFileNameWithoutExtension(item.SongFileName), BLSongs.GetSongByFullPath(item.SongFilePath)));

                    
                    //Make sure that Add files... is in the combobox
                    cbSound.Items.Remove(" Add files...");
                    cbSound.Items.Add(" Add files...");
                }
            }
        }

        private void resetTimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtpTime.Value = Convert.ToDateTime(DateTime.Now.ToString("HH:mm")).AddMinutes(1); //Add 1 minute so the exclamination won't show
            dtpDate.Value = DateTime.Now;

        }

        private void tbNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                tbNote.SelectAll();
                tbNote.Focus();
            }
        }

        private void tbReminderName_Enter(object sender, EventArgs e)
        {
            tbReminderName.LineIdleColor = Color.Silver;            
            tbReminderName.HintForeColor = Color.White;
        }

        private void btnAdvancedReminder_Click(object sender, EventArgs e)
        {                        
            AVRForm.ShowDialog();
            if(AVRForm.FilesFolders.Count > 0 || !string.IsNullOrWhiteSpace(AVRForm.BatchScript))
            {
                cbAdvancedReminder.Visible = true;                
                lblAdvancedReminders.Visible = true;
            }
            else
            {
                cbAdvancedReminder.Visible = false;                
                lblAdvancedReminders.Visible = false;
            }
        }

        private void UCNewReminder_VisibleChanged(object sender, EventArgs e)
        {
            btnAdvancedReminder.Visible = BLSettings.GetSettings().EnableAdvancedReminders == 1;
        }

        private void tbReminderName_Leave(object sender, EventArgs e)
        {
            tbReminderName.HintForeColor = Color.DarkGray;
        }

        private void lblAdvancedReminders_Click(object sender, EventArgs e)
        {
            cbAdvancedReminder.Checked = !cbAdvancedReminder.Checked;            
        }

        private void cbAdvancedReminder_OnChange(object sender, EventArgs e)
        {            
            if(!cbAdvancedReminder.Checked)            
                lblAdvancedReminders.Text = "Disabled.";            
            else            
                lblAdvancedReminders.Text = "Enabled!";           
        }
    }
}
