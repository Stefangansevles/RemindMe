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
        public static void removeButtonBorders(Button b)
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
                    rb.Checked = false;
                }

                if (c is DateTimePicker)
                {
                    DateTimePicker pick = (DateTimePicker)c;
                    pick.Enabled = true;
                    pick.Value = DateTime.Today;
                }
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.Items.Clear();
                }
                if (c is PictureBox && c.Name != "pbEdit")                
                    c.Visible = false;                
            }
        }
        /// <summary>
        /// Adds an reminder to the listview
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The reminder</param>
        public static void AddReminderToListview(ListView lv, Reminder rem)
        {
            ListViewItem itm = new ListViewItem(rem.Name);
            if (DateTime.Today.ToShortDateString() == rem.Date)
                itm.SubItems.Add(rem.Time);
            else
                itm.SubItems.Add(rem.Date);

            itm.SubItems.Add(rem.RepeatingType.ToString().ToLower());
            itm.SubItems.Add(rem.Enabled.ToString());

            lv.Items.Add(itm);
        }
        /// <summary>
        /// Adds multiple reminders to the listview
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The list of reminders</param>
        public static void AddRemindersToListview(ListView lv, List<Reminder> reminderList)
        {
            var list = reminderList.OrderBy(t => t.CompleteDate).ToList();
            foreach (Reminder rem in list)
            {
                ListViewItem itm = new ListViewItem(rem.Name);
                if (DateTime.Today.ToShortDateString() == rem.Date)
                    itm.SubItems.Add(rem.Time);
                else
                    itm.SubItems.Add(rem.Date);

                if(rem.RepeatingType != ReminderRepeatType.EVERY_X_DAYS)
                    itm.SubItems.Add(rem.RepeatingType.ToString().ToLower());
                else
                    itm.SubItems.Add("every " + rem.EveryXDays + "d");
                itm.SubItems.Add(rem.Enabled.ToString());

                lv.Items.Add(itm);
            }
        }
        /// <summary>
        /// Creates a new instance of popup
        /// </summary>
        public static void makePopup(Reminder rem)
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
                {
                    BLIO.WriteError(new System.IO.FileNotFoundException(), "Song doesn't exist in the specified folder anymore (" + rem.SoundFilePath + ")", true);                                    
                }
            }

            if(rem.RepeatingType == ReminderRepeatType.NONE)
            {//Lets remove it
                File.Delete(Variables.IOVariables.remindersFolder + rem.Name + ".ini");
            }
        }
    }
}
