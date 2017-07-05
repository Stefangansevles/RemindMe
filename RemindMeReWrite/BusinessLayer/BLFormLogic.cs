using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace RemindMe
{
    public abstract class BLFormLogic
    {
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        /// <summary>
        /// Removes borders from buttons to make them look better with a background
        /// </summary>
        /// <param name="b"></param>
        public static void RemovebuttonBorders(Button b)
        {
            b.TabStop = false;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Switches the panels and gives the user the option to make a new reminder
        /// </summary>
        /// <param name="homeLoc">The panel which contains the controls to make a new reminder</param>
        /// <param name="sideLoc">Main panel which shows all reminders</param>
        public static void SwitchPanels(Panel homeLoc, Panel sideLoc)
        {
            //Switch the panels around

            homeLoc.Location = new Point(0, 22);
            homeLoc.Visible = true;

            sideLoc.Visible = false;
            sideLoc.Location = new Point(405, 22);
        }

        /// <summary>
        /// Resets all the controls to their original state.
        /// </summary>
        public static void ResetControlValues(Panel pnl)
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
                if(c is CheckBox)
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
                    pick.Value = DateTime.Today.AddMinutes(1);
                }
                if (c is ComboBox)
                {
                    if (c.Name != "cbEveryXCustom")
                    {
                        ComboBox cb = (ComboBox)c;
                        cb.Items.Clear();
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
        public static void AddReminderToListview(ListView lv, Reminder rem)
        {
            
            ListViewItem itm = new ListViewItem(rem.Name);
            itm.Tag = rem.Id; //Add the id as a tag(invisible)

            if (rem.PostponeDate == null)
            {
                if (Convert.ToDateTime(DateTime.Today.ToShortDateString()) >= Convert.ToDateTime(Convert.ToDateTime(rem.Date).ToShortDateString()))
                    itm.SubItems.Add(Convert.ToDateTime(rem.Date).ToShortTimeString());
                else
                    itm.SubItems.Add(Convert.ToDateTime(rem.Date).ToShortDateString());
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
                
                if(rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                {
                    string cutOffString = "";
                    foreach(string day in rem.RepeatDays.Split(','))                   
                        cutOffString += day.Substring(0, 3) + ",";

                    cutOffString = cutOffString.Remove(cutOffString.Length - 1, 1); //remove the final ','
                    itm.SubItems.Add(cutOffString); //Add all the repeating days to the listview column. example: mon,tue,sat
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
        public static void AddRemindersToListview(ListView lv, List<Reminder> reminderList)
        {
            List<Reminder> list = reminderList.OrderBy(t => Convert.ToDateTime(t.Date)).ToList();
            foreach (Reminder rem in list)            
                AddReminderToListview(lv, rem);            
        }

        public static void RefreshListview(ListView lv)
        {
            lv.Items.Clear();
            AddRemindersToListview(lv, DLReminders.GetReminders());
        }

        /// <summary>
        /// Gets all the sounds from the database and fills the combobox with them.
        /// </summary>
        /// <param name="cbSound"></param>
        public static void FillSoundComboboxFromDatabase(ComboBox cbSound)
        {
            //Fill the list with all the sounds from the settings.ini file
            List<Songs> sounds = DLSongs.GetSongs();

            cbSound.Items.Clear();
            ComboBoxItemManager.GetComboboxItems().Clear();

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
        public static void MakePopup(Reminder rem)
        {
            Popup p = new Popup(rem);
            p.Show();

            //BLIO.readSettings();
            if (rem.SoundFilePath != null && rem.SoundFilePath != "")
            {
                if (System.IO.File.Exists(rem.SoundFilePath))
                {
                    myPlayer.URL = rem.SoundFilePath;
                    myPlayer.controls.play();
                }
                else
                    throw new FileNotFoundException("", rem.SoundFilePath);                             
            }
        }

        

        
    }
}
