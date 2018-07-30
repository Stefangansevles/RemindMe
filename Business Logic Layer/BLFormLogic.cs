using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Data_Access_Layer;
using WMPLib;
using System.Drawing;


namespace Business_Logic_Layer
{
    public class BLFormLogic
    {
        private BLFormLogic() { }
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
        /// Adds an reminder to the listview, showing the details of that reminder.
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The reminder</param>
        public static void AddReminderToListview(ListView lv, Reminder rem)
        {
            if (!BLReminder.IsValidReminder(rem))
            {
                //This reminder isn't valid! Set the "Corrupted" tag to 1 and throw exception
                rem.Corrupted = 1;
                BLReminder.EditReminder(rem);
                throw new ReminderException("Corrupted/damaged reminder: " + rem.Name + " \r\nIt has been removed from your list of reminders", rem);
            }

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
            {
                itm.SubItems.Add("True");
                itm.ForeColor = Color.White;
            }
            else
            {
                itm.SubItems.Add("False");
                itm.ForeColor = Color.FromArgb(64, 64, 64);
            }

            lv.Items.Add(itm);
        }
       
        /// <summary>
        /// Adds multiple reminders to the listview
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The list of reminders</param>
        public static void AddRemindersToListview(ListView lv, List<Reminder> reminderList)
        {
            List<Reminder> disabledReminders = new List<Reminder>(); //We're going to add the disabled reminders after all the enabled ones.  
            
            //First, lets check if this list is correct
            foreach(Reminder checkRem in reminderList)
            {
                if (!BLReminder.IsValidReminder(checkRem))
                {
                    //This reminder isn't valid! Set the "Corrupted" tag to 1 and throw exception
                    checkRem.Corrupted = 1;
                    BLReminder.EditReminder(checkRem);
                    throw new ReminderException("Corrupted/damaged reminder: " + checkRem.Name + " \r\nIt has been removed from your list of reminders", checkRem);
                }
            }
                      
            List<Reminder> list = reminderList.OrderBy(t => Convert.ToDateTime(t.Date.Split(',')[0])).ToList();
            foreach (Reminder rem in list)
            {                
                if (rem.Enabled == 1) //not disabled? add to listview
                    AddReminderToListview(lv, rem);
                else
                    disabledReminders.Add(rem);
            }

            //Add disabled reminders to the bottom of the list
            foreach (Reminder rem in disabledReminders)
                AddReminderToListview(lv, rem);
        }

        public static void RefreshListview(ListView lv)
        {            
            lv.Items.Clear();
            AddRemindersToListview(lv, DLReminders.GetReminders().Where(rem => rem.Hide == 0).ToList());
        }

       

        

        

        
    }
}
