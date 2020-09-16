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
using System.Globalization;
using System.Threading;
using MaterialSkin.Controls;

namespace RemindMe
{
    public partial class MUCNewReminder : UserControl
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);        

        //The stop playing preview sound icon
        Image imgStop;

        //The start playing preview sound icon
        Image imgPlayResume;

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        private Reminder editableReminder = null;

        UserControl callback;

        MaterialAdvancedReminderForm AVRForm;

        //If the user was editing an reminder, and selecter another screen from the left panel, we need to save this state
        public bool saveState = false;

        /// <summary>
        /// Create a new usercontrol to manage reminders
        /// </summary>
        /// <param name="callback">The usercontrol you should go back to when pressing the back button from MUCNewReminder</param>
        public MUCNewReminder(UserControl callback)
        {
            InitializeComponent();

            AVRForm = new MaterialAdvancedReminderForm();
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(AVRForm);
            
            this.callback = callback;

            FillSoundComboboxFromDatabase(cbSound);


            MaterialSkin.MaterialSkinManager.Instance.ThemeChanged += Instance_ThemeChanged;

            imgStop = Properties.Resources.Stop;
            imgPlayResume = Properties.Resources.Play;

            btnPlaySound.Icon = imgPlayResume;

            //Subscribe all day checkboxes to our custom checked changed event, so that whenever any of these checkboxes change, the cbDaysCheckedChangeEvent will fire
            cbMonday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbTuesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbWednesday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbThursday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbFriday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSaturday.CheckedChanged += cbDaysCheckedChangeEvent;
            cbSunday.CheckedChanged += cbDaysCheckedChangeEvent;

            rbDaily.CheckedChanged += rbCheckedChangeEvent;
            rbMonthly.CheckedChanged += rbCheckedChangeEvent;
            rbMultipleDays.CheckedChanged += rbCheckedChangeEvent;
            rbNoRepeat.CheckedChanged += rbCheckedChangeEvent;
            rbEveryXCustom.CheckedChanged += rbCheckedChangeEvent;
            rbWorkDays.CheckedChanged += rbCheckedChangeEvent;


            numEveryXDays.KeyDown += numericOnly_KeyDown;
            numEveryXDays.KeyPress += numericOnly_KeyPress;
            

            AddDaysMenuStrip.Renderer = new MyToolStripMenuRenderer();

        }

        private void Instance_ThemeChanged(object sender)
        {
            //remove old one
            MaterialSkin.MaterialSkinManager.Instance.RemoveFormToManage(AVRForm);
            string batch = AVRForm.BatchScript;
            bool check = AVRForm.HideReminder;
            
            AVRForm = new MaterialAdvancedReminderForm();
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(AVRForm);

            AVRForm.BatchScript = batch;
            AVRForm.HideReminder = check;
        }

        private void numericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void numericOnly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
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
            
        }



        public Reminder Reminder
        {
            get { return editableReminder; }
            set
            {
                editableReminder = value;
                ResetReminderForm();
                FillControlsForEdit(editableReminder);

               
            }
        }

        /// <summary>
        /// Fills the controls of creating a new reminder with the data from the reminder
        /// </summary>
        private void FillControlsForEdit(Reminder rem)
        {
            if (rem == null)
            {
                ResetControlValues();
                return;
            }

            pnlDayCheckBoxes.Visible = false;
            //reposition the textbox under the groupbox. null,null because we're not doing anything with the parameters
            pnlDayCheckBoxes_VisibleChanged(null, null);

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
                Songs songObj = BLLocalDatabase.Song.GetSongByFullPath(rem.SoundFilePath);
                if (songObj != null)
                {
                    if (songObj.SongFilePath.Contains("C:\\Windows\\Media") && !song.Contains("Windows"))
                        song = "(Windows) " + song;
                    else if (song.Contains("Windows"))
                        song = song.Replace("Windows", "(Windows)");

                    ComboBoxItem reminderItem = ComboBoxItemManager.GetComboBoxItem(song, songObj);

                    if (reminderItem != null)
                        cbSound.SelectedItem = reminderItem;
                }



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
                numEveryXDays.Text = ""+(decimal)rem.EveryXCustom;

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


            //Now, let's see if this reminder has any advanced properties
            AdvancedReminderProperties avrProps = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
            List<AdvancedReminderFilesFolders> avrFF = BLLocalDatabase.AVRProperty.GetAVRFilesFolders(rem.Id);
            if (avrProps != null)
            {
                if (avrProps.ShowReminder.HasValue)
                    AVRForm.HideReminder = !Convert.ToBoolean(avrProps.ShowReminder);

                AVRForm.BatchScript = avrProps.BatchScript;                                             
            }
            if (avrFF != null)
            {
                Dictionary<string, string> filesFolders = new Dictionary<string, string>();
                foreach (AdvancedReminderFilesFolders dic in avrFF)
                {
                    if (!filesFolders.ContainsKey(dic.Path))
                        filesFolders.Add(dic.Path, dic.Action);
                }                
            }

            //Only allow the setting of UpdateTime if the repeat type is NOT multiple dates(which is "NONE")
            if (rbNoRepeat.Checked || rbEveryXCustom.Checked && cbEveryXCustom.SelectedItem.ToString() == "Minutes" && cbEveryXCustom.SelectedItem.ToString() == "Hours")
                pnlUpdateTime.Visible = false;
            else
                pnlUpdateTime.Visible = true;

            swUpdateTime.Checked = Convert.ToBoolean(rem.UpdateTime);
            pnlUpdateTime.Visible = !(rbEveryXCustom.Checked && cbEveryXCustom.SelectedItem.ToString() == "Minutes" || cbEveryXCustom.SelectedItem.ToString() == "Hours");
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
            List<Songs> sounds = BLLocalDatabase.Song.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

            cbSound.Items.Clear();
            ComboBoxItemManager.ClearComboboxItems();

            if (sounds != null)
                foreach (Songs item in sounds)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));

            //Let's make sure the default windows System sounds are placed at the bottom
            List<Songs> windowsDefaultSongs = BLLocalDatabase.Song.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() == "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

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
            if (cbSound.SelectedItem == null || cbSound.SelectedItem.ToString() == " Add files..." || String.IsNullOrWhiteSpace(cbSound.SelectedItem.ToString()))
                return;

            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem != null)
            {

                Songs selectedSong = (Songs)selectedItem.Value;
                BLIO.Log("selected sound file is valid (MUCNewReminder)");

                if (btnPlaySound.Icon == imgPlayResume)
                {

                    if (selectedItem != null)
                    {
                        if (System.IO.File.Exists(selectedSong.SongFilePath))
                        {
                            BLIO.Log("selected sound file exists on hard drive (MUCNewReminder)");
                            btnPlaySound.Icon = imgStop;

                            myPlayer.URL = selectedSong.SongFilePath;
                            mediaInfo = myPlayer.newMedia(myPlayer.URL);

                            //Start the timer. the timer ticks when the song ends. The timer will then reset the picture of the play button                        
                            if (mediaInfo.duration > 0)
                                tmrMusic.Interval = (int)(mediaInfo.duration * 1000);
                            else
                                tmrMusic.Interval = 1000;
                            tmrMusic.Start();

                            BLIO.Log("Playing sound... (MUCNewReminder)");
                            myPlayer.controls.play();
                        }
                        else
                        {
                            BLIO.Log("selected sound file does not exist on hard drive anymore (MUCNewReminder)");
                            //Get the song object from the combobox value
                            Songs song = (Songs)selectedItem.Value;
                            if (song != null)
                            {
                                //Remove the song from the SQLite Database
                                BLLocalDatabase.Song.RemoveSong(BLLocalDatabase.Song.GetSongByFullPath(song.SongFilePath));

                                //Remove the song from the combobox
                                cbSound.Items.Remove(ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(song.SongFileName), song));

                                //Remove the song from the combobox list in the manager
                                ComboBoxItemManager.RemoveComboboxItem(ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(song.SongFileName), song));

                                BLIO.Log("selected sound file removed from RemindMe as it no longer exists on the hard drive (MUCNewReminder)");

                                //Show the user the message that the file is no longer at the specified path.
                                MaterialRemindMeBox.Show("Could not play " + song.SongFileName + " located at \"" + song.SongFilePath + "\" \r\nDid you move,rename or delete the file ?", RemindMeBoxReason.OK, false);
                            }

                        }
                    }
                }
                else
                {
                    btnPlaySound.Icon = imgPlayResume;
                    myPlayer.controls.stop();
                    tmrMusic.Stop();
                }
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPlaySound.Icon = imgPlayResume;
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
            MaterialSkin.Controls.MaterialCheckbox check;
            string commaSeperatedDays = "";
            //loop through the selected checkboxes
            foreach (Control cb in pnlDayCheckBoxes.Controls)
            {
                if (cb is MaterialSkin.Controls.MaterialCheckbox)
                {
                    check = (MaterialSkin.Controls.MaterialCheckbox)cb;
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

            cbEvery.Visible = true; 
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
            if (rbMonthly.Checked)
            {
                BLIO.Log("Reminder type set to monthly");
                cbEvery.Visible = true;                

                //clear the combobox of previous data
                cbEvery.Items.Clear();

                for (int i = 1; i <= 31; i++)
                    cbEvery.Items.Add(i.ToString()); //Add 1-31 string to it 

                //Select the first item
                cbEvery.SelectedItem = cbEvery.Items[0];
       

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

         
        }

        private void cbMultipleDates_VisibleChanged(object sender, EventArgs e)
        {
            if (cbMultipleDates.Visible)
            {
                groupRepeatRadiobuttons.Location = new Point(cbMultipleDates.Location.X, (cbMultipleDates.Location.Y + cbMultipleDates.Height + 2));

                btnRemoveDate.DrawShadows = true;
                btnAddDate.DrawShadows = true;

                btnAddDate.Visible = true;
                btnRemoveDate.Visible = true;                
            }
            else
            {
                //not visible? place the repeat radio button groupbox on this place
                groupRepeatRadiobuttons.Location = cbMultipleDates.Location;
                
                groupRepeatRadiobuttons.Location = new Point(dtpDate.Location.X, dtpDate.Location.Y + dtpDate.Height);

                btnRemoveDate.DrawShadows = false;
                btnAddDate.DrawShadows = false;

                btnAddDate.Visible = false;                
                btnRemoveDate.Visible = false;                
            }
        }

        private void tbNote_LocationChanged(object sender, EventArgs e)
        {            
            pnlUpdateTime.Location = new Point(pnlUpdateTime.Location.X, (tbNote.Location.Y + tbNote.Height));

            //Only allow the setting of UpdateTime if the repeat type is NOT multiple dates(which is "NONE")
            if (rbNoRepeat.Checked || rbEveryXCustom.Checked && cbEveryXCustom.SelectedItem.ToString() == "Minutes" && cbEveryXCustom.SelectedItem.ToString() == "Hours")
                pnlUpdateTime.Visible = false;
            else
                pnlUpdateTime.Visible = true;

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
                //System.ArgumentOutOfRangeException;

                DateTime? date = null;
                int addMonths = 0;
                while (date == null)
                {
                    try
                    {
                        date = new DateTime(DateTime.Now.Year, (DateTime.Now.Month+ addMonths), Convert.ToInt32(cbItem));
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        //If for example day 31 doesnt exist, add a month
                        addMonths++;
                    }
                }
                if (BLDateTime.GetDateForNextDayOfMonth(date.Value).Day == DateTime.Now.Day)
                    dates.Add(DateTime.Now);
                else
                    dates.Add(BLDateTime.GetDateForNextDayOfMonth(date.Value));
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
                        BLIO.Log("value between 1 and 31! set the selected item (" + cbEvery.SelectedItem.ToString() + ") and added it to cbMonthlyDays");
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
            catch (Exception ex)
            {
                string t = ex.Message;
            }
        }

        private void btnRemoveMonthlyDay_Click(object sender, EventArgs e)
        {
            if (cbMonthlyDays.SelectedItem == null)
                return;

            BLIO.Log("removing monthly day from cbMonthlyDays (" + cbMonthlyDays.SelectedItem.ToString() + ")");
            cbMonthlyDays.Items.Remove(cbMonthlyDays.SelectedItem);
            SetDateTimePickerMonthlyValue();
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            BLIO.Log("Attempting to add date to reminder...");
            DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());

            if (selectedDate.ToString().Contains(","))
            {
                //The date contains a ',' , no good! Try and convert it to en-us
                selectedDate = DateTime.Parse(selectedDate.ToString(), CultureInfo.CurrentCulture);

                if (selectedDate.ToShortDateString().Contains(","))//Still contains a comma? Let's just convert it to en-us then..
                    selectedDate = DateTime.Parse(selectedDate.ToString(), new CultureInfo("en-US"));
            }

            if (selectedDate > DateTime.Now)
            {
                BLIO.Log("selectedDate > DateTime.now !");
                if (!cbMultipleDates.Items.Contains(selectedDate))
                {
                    BLIO.Log("reminder doesnt have this date yet!");
                    cbMultipleDates.Items.Add(selectedDate);
                    BLIO.Log("Added date to cbMultipleDates combobox");
                    MaterialMessageFormManager.MakeMessagePopup(selectedDate.ToString() + " Added to this reminder.", 1);
                }
                else
                    MaterialMessageFormManager.MakeMessagePopup("You have already added that date.", 1);
            }
            else
                MaterialMessageFormManager.MakeMessagePopup("The date you selected is in the past! Cannot add this date.", 3);
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
                if (c is MaterialSkin.Controls.MaterialCheckbox)
                {
                    MaterialSkin.Controls.MaterialCheckbox theCheckbox = (MaterialSkin.Controls.MaterialCheckbox)c;
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


        private void btnConfirm_Click(object sender, EventArgs e) //Update: oof, messy method :(
        {
            BLIO.Log("User pressed confirm at reminder user control. Attempting to create/edit a reminder (MUCNewReminder)");
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
               

                if (editableReminder == null) //If the user isn't editing an existing reminder, he's creating one
                {
                    if (repeat == ReminderRepeatType.MONTHLY)
                    {
                        //If the user pressed confirm, but didnt "+" the monthly day yet, we'll do it for him/her(yes, there are 2 genders).                                              
                        if (cbEvery.SelectedItem.ToString() != "1" && cbMonthlyDays.Items.Count == 0)
                            cbMonthlyDays.Items.Add(cbEvery.SelectedItem);

                        if (cbMonthlyDays.Items.Count > 0)
                            remId = BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMonthlyDaysComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath, Convert.ToInt32(swUpdateTime.Checked));
                        else
                        {
                            //MakeScrollingPopupMessage("Can not create an reminder with monthly day(s) if there are no days selected!");
                           

                            return;
                        }
                    }

                    else if (repeat == ReminderRepeatType.MULTIPLE_DAYS)
                        if (IsAtLeastOneWeeklyCheckboxSelected())
                            remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, commaSeperatedDays, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath, Convert.ToInt32(swUpdateTime.Checked));
                        else
                        {
                            //MakeScrollingPopupMessage("You do not have any day(s) selected!");
                            return;
                        }
                    else if (repeat == ReminderRepeatType.CUSTOM)
                    {
                        int updateTime = 0;
                        if (pnlUpdateTime.Visible)
                            updateTime = Convert.ToInt32(swUpdateTime.Checked);

                        remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), cbEveryXCustom.SelectedItem.ToString(), Convert.ToInt32(numEveryXDays.Text), null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath, updateTime);
                    }
                    else if (repeat == ReminderRepeatType.NONE)
                    {
                        BLIO.Log("Attempting to read the selected date for the new reminder...");
                        DateTime selectedDate = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString());
                        BLIO.Log("Success! Date -> " + selectedDate.ToString());
                        if (!cbMultipleDates.Items.Contains(selectedDate) && selectedDate > DateTime.Now)
                            cbMultipleDates.Items.Add(selectedDate);//If the user pressed confirm, but didnt "+" the date yet, we'll do it for him/her(yes, there are 2 genders).                                              

                        if (cbMultipleDates.Items.Count > 0)
                            remId = BLReminder.InsertReminder(tbReminderName.Text, GetDatesStringFromMultipleDatesComboBox(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath);
                        else
                        {
                            //MakeScrollingPopupMessage("You have not added any dates!\r\nIf you have selected a date and want only that one, press the \"+\" button");
                            return;
                        }
                    }
                    else
                        remId = BLReminder.InsertReminder(tbReminderName.Text, Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString(), repeat.ToString(), null, null, tbNote.Text.Replace(Environment.NewLine, "\\n"), true, soundPath, Convert.ToInt32(swUpdateTime.Checked));


                    new Thread(() =>
                    {
                        //Log an entry to the database, for data!
                        try
                        {
                            BLOnlineDatabase.RemindersCreated++;
                        }
                        catch (ArgumentException ex)
                        {
                            BLIO.Log("Exception at BLOnlineDatabase.RemindersCreated++. -> " + ex.Message);
                            BLIO.WriteError(ex, ex.Message, true);
                        }
                    }).Start();
                    BLIO.Log("New reminder succesfully created! (MUCNewReminder)");
                }
                else
                {//The user is editing an existing reminder                                        
                    editableReminder.Name = tbReminderName.Text;
                    remId = editableReminder.Id;
                    if (rbEveryXCustom.Checked)
                    {
                        editableReminder.RepeatType = cbEveryXCustom.SelectedItem.ToString();
                        editableReminder.EveryXCustom = Convert.ToInt32(numEveryXDays.Text);
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
                                editableReminder.Date = Convert.ToDateTime(dtpDate.Value.ToShortDateString() + " " + dtpTime.Value.ToShortTimeString()).ToString();//Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(GetCommaSeperatedDayCheckboxesString())).ToShortDateString() + " " + dtpTime.Value.ToShortTimeString();
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
                                    MaterialMessageFormManager.MakeMessagePopup("The selected date is in the past!", 4);
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
                        editableReminder.EveryXCustom = Convert.ToInt32(numEveryXDays.Text);

                    //Only allow the setting of UpdateTime if the repeat type is NOT multiple dates(which is "NONE")
                    if (repeat != ReminderRepeatType.NONE)
                    {
                        //Don't update the TIME if the repeat type is every x minutes/hours, that might mess it up
                        if (repeat == ReminderRepeatType.CUSTOM && cbEveryXCustom.SelectedItem.ToString() == "Minutes" && cbEveryXCustom.SelectedItem.ToString() == "Hours") { }
                        else
                            editableReminder.UpdateTime = Convert.ToInt32(swUpdateTime.Checked);

                    }
                    RemoveUnusedPropertiesFromReminders(editableReminder);

                    BLReminder.EditReminder(editableReminder);
                    BLIO.Log("Reminder with id " + editableReminder.Id + " edited! (MUCNewReminder)");
                }


                //Assign AVR properties to this reminder                                
                CreateAdvancedReminderProperties(remId);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbReminderName.Text))
                {//User didnt fill in a title
                    //tbReminderName.LineIdleColor = Color.Red;                    
                    //toolTip1.SetToolTip(pbExclamationTitle, "Please enter a title.");
                }
                else
                {//if(!cbmonthly.selected) TODO
                    tbReminderName.BackColor = Color.DimGray;                    
                }


                ShowOrHideExclamation();

                //MakeScrollingPopupMessage("Some fields are not valid. Please see the exclaminations");
                BLIO.Log("Could not create a reminder. some fields are not valid (MUCNewReminder)");
                return;
            }

            BLReminder.NotifyChange();
            btnBack_Click(sender, e);
        }

        private void CreateAdvancedReminderProperties(long remId)
        {
            Reminder rem = BLReminder.GetReminderById(remId);            
            BLReminder.EditReminder(rem);

            //Create AVR properties and insert them into the database
            AdvancedReminderProperties avr = BLLocalDatabase.AVRProperty.GetAVRProperties(remId);
            if (avr == null) { avr = new AdvancedReminderProperties(); }

            avr.ShowReminder = AVRForm.HideReminder ? 0 : 1;
            avr.BatchScript = AVRForm.BatchScript;
            avr.Remid = remId; //Link this reminder to it
            BLLocalDatabase.AVRProperty.InsertAVRProperties(avr);            
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
            MaterialRadioButton rb;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is MaterialTextBox || c is MaterialMultiLineTextBox)
                {
                    c.Text = "";                    
                }

                if (c is MaterialRadioButton)
                {
                    rb = (MaterialRadioButton)c;


                    if (rb.Name == "rbNoRepeat")
                        rb.Checked = true; //The default radio button should be rbNoRepeat
                    else
                        rb.Checked = false;
                }
                if (c is MaterialCheckbox )
                {
                    MaterialCheckbox check = (MaterialCheckbox)c;
                    check.Checked = false;
                }
                if (c is DateTimePicker)
                {
                    DateTimePicker pick = (DateTimePicker)c;
                    pick.Enabled = true;
                    pick.Value = DateTime.Now.AddMinutes(1);
                }
                if (c is MaterialComboBox)
                {
                    if (c.Name != "cbEveryXCustom" && c.Name != "cbSound")
                    {
                        MaterialComboBox cb = (MaterialComboBox)c;
                        cb.Items.Clear();
                        cb.Text = "";
                    }
                }
                if (c is PictureBox && c.Name != "pbEdit" && c.Name != "pbUpdateTimeInformation")
                    c.Visible = false;
            }

            tbReminderName.ResetText();
            rbNoRepeat.Checked = true;
            rbCheckedChangeEvent(null, null);
            AVRForm = new MaterialAdvancedReminderForm();            
            swUpdateTime.Checked = false;            
        }

        public void ResetReminderForm()
        {
            cbSound.SelectedItem = null;
            pnlDayCheckBoxes.Visible = false;

            cbMultipleDates.Visible = true;
            cbEvery_VisibleChanged(null, null);

            //Reset the controls to their default values, empty text boxes etc            
            ResetControlValues();



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
               
                
            }
           


            if (rbWorkDays.Checked)
            {
                /*Is the selected day a workday?                
                if (dtpDate.Value.DayOfWeek != DayOfWeek.Saturday && dtpDate.Value.DayOfWeek != DayOfWeek.Sunday)
                    pbExclamationWorkday.Visible = false;
                else
                {
                   
                    toolTip1.SetToolTip(pbExclamationWorkday, "The day you selected is not a work day.");
                }*/
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BLIO.Log("User pressed back (MUCNewReminder)");
            btnPlaySound.Icon = imgPlayResume;

            if (myPlayer.controls.currentPosition != 0)
                BLIO.Log("stopping music");

            myPlayer.controls.stop();
            tmrMusic.Stop();

            //Refresh listview with the newly made reminder                        
            MUCReminders.Instance.UpdateCurrentPage();

            callback.Visible = true;
            this.Visible = false;
            saveState = false;
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
            BLIO.Log("Clearing reminder form (MUCNewReminder)");
            ResetReminderForm();
        }

        private void MUCNewReminder_Load(object sender, EventArgs e)
        {
            cbEvery.LocationChanged += cbEvery_VisibleChanged;
            dtpTime.Format = DateTimePickerFormat.Custom;
            btnAdvancedReminder.Visible = BLLocalDatabase.Setting.Settings.EnableAdvancedReminders == 1;

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
                    BLIO.Log("bringing up the menu when the user clicks ... (MUCNewReminder)");
                }

            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large."); }

        }

        private void addMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddMinutes = MaterialRemindMePrompt.ShowNumber("Add minutes to the current time");
                dtpDate.Value = DateTime.Now.AddMinutes(toAddMinutes);
                dtpTime.Value = DateTime.Now.AddMinutes(toAddMinutes);
            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large."); }

        }

        private void addDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddDays = MaterialRemindMePrompt.ShowNumber("Add days to the selected date");
                dtpDate.Value = dtpDate.Value.AddDays(toAddDays);
            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large.", false); }

        }

        private void addMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toAddMonths = MaterialRemindMePrompt.ShowNumber("Add months to the selected date");
                dtpDate.Value = dtpDate.Value.AddMonths(toAddMonths);
            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large.", false); }

        }

        private void subtractDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toSubtractDays = MaterialRemindMePrompt.ShowNumber("Subtract days to the selected date");
                dtpDate.Value = dtpDate.Value.AddDays(-toSubtractDays);
            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large.", false); }

        }

        private void subtractMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int toSubtractMonths = MaterialRemindMePrompt.ShowNumber("Subtract months to the selected date");
                dtpDate.Value = dtpDate.Value.AddMonths(-toSubtractMonths);
            }
            catch (ArgumentOutOfRangeException) { MaterialRemindMeBox.Show("Entered number is too large.", false); }

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

                    List<string> selectedFiles = FSManager.Files.GetSelectedFilesWithPath("Sound files", "*.mp3; *.wav; *.ogg; *.3gp; *.aac; *.flac; *.webm; *.aiff; *.wma; *.alac;").ToList();

                    if (selectedFiles.Count == 1 && selectedFiles[0] == "")
                        return;

                    List<Songs> toInsertSongs = new List<Songs>();

                    foreach (string sound in selectedFiles.Where(song => !BLLocalDatabase.Song.SongExistsInDatabase(song) && song != "").ToList())
                    {
                        Songs song = new Songs();
                        song.SongFilePath = sound;
                        song.SongFileName = Path.GetFileName(sound);
                        toInsertSongs.Add(song);
                    }

                    BLLocalDatabase.Song.InsertSongs(toInsertSongs);

                    //already inserted, but iterating through them to add to the combobox
                    foreach (Songs item in toInsertSongs.Where(itm => itm.SongFileName != "").ToList())
                        cbSound.Items.Add(new ComboBoxItem(Path.GetFileNameWithoutExtension(item.SongFileName), BLLocalDatabase.Song.GetSongByFullPath(item.SongFilePath)));


                    //Make sure that Add files... is in the combobox
                    cbSound.Items.Remove(" Add files...");
                    cbSound.Items.Add(" Add files...");

                    MaterialForm1.Instance.mucSettings.FillSoundCombobox();
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
            
        }

        private void btnAdvancedReminder_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCNewReminder)btnAdvancedReminder_Click");            
            AVRForm.ShowDialog();            
        }

        private void MUCNewReminder_VisibleChanged(object sender, EventArgs e)
        {
            btnAdvancedReminder.Visible = BLLocalDatabase.Setting.Settings.EnableAdvancedReminders == 1;

            if (callback != null && !callback.Visible && !this.Visible)
                saveState = true;

            if (this.Visible)
                BLIO.Log("Control MUCNewReminder now visible");
        }

     


        private void groupRepeatRadiobuttons_LocationChanged(object sender, EventArgs e)
        {            
            tbNote.Location = new Point(groupRepeatRadiobuttons.Location.X, (groupRepeatRadiobuttons.Location.Y + groupRepeatRadiobuttons.Size.Height) + 3);
        }
        private void cbEveryXCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateTime.Visible = !(rbEveryXCustom.Checked && cbEveryXCustom.SelectedItem.ToString() == "Minutes" || cbEveryXCustom.SelectedItem.ToString() == "Hours");
        }

        private void pnlUpdateTime_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlUpdateTime.Visible)
                pnlUpdateTime.Visible = !(rbEveryXCustom.Checked && cbEveryXCustom.SelectedItem.ToString() == "Minutes" || cbEveryXCustom.SelectedItem.ToString() == "Hours");
        }

        private void btnAddDate_VisibleChanged(object sender, EventArgs e)
        {
            if (!btnAddDate.Visible)
            {                
                btnAddDays.Size = new Size(45, 26);
                btnAddDays.Location = new Point(645, 88);
            }
            else
            {                
                btnAddDays.Size = new Size(22, 26);
                btnAddDays.Location = new Point(668, 88);
            }
        }

        private void btnAdvancedReminder_Click_1(object sender, EventArgs e)
        {
            AVRForm.ShowDialog();
            //AVRForm.ShowReminder == rem
        }

        private void tmrMusic_Tick_1(object sender, EventArgs e)
        {
            btnPlaySound.Icon = imgPlayResume;
            tmrMusic.Stop();
        }
    }
}
