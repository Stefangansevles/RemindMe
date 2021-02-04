using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Data_Access_Layer;
using WMPLib;
using System.Drawing;
using MaterialSkin.Controls;
using System.Drawing.Imaging;

namespace Business_Logic_Layer
{
    public class BLFormLogic
    {
        private BLFormLogic() { }
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        

        /// <summary>
        /// Adds an reminder to the listview, showing the details of that reminder.
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The reminder</param>
        public static void AddReminderToListview(object lv, Reminder rem, bool material)
        {
            if (BLReminder.IsValidReminder(rem) != null)
            {
                //This reminder isn't valid! Set the "Corrupted" tag to 1 and throw exception
                rem.Corrupted = 1;
                BLReminder.EditReminder(rem);
                throw new ReminderException("Corrupted/damaged reminder: " + rem.Name + " \r\nIt has been removed from your list of reminders", rem);
            }

            ListViewItem itm = new ListViewItem(rem.Name);
            itm.Tag = rem.Id; //Add the id as a tag(invisible)

            if (rem.HttpId == null)
            {
                if (rem.PostponeDate == null)
                    itm.SubItems.Add(Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortDateString() + " " + Convert.ToDateTime(rem.Date.Split(',')[0]).ToShortTimeString());
                else
                    itm.SubItems.Add(Convert.ToDateTime(rem.PostponeDate).ToShortDateString() + " " + Convert.ToDateTime(rem.PostponeDate).ToShortTimeString() + " (p)");
            }
            else
                itm.SubItems.Add("Conditional");


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

            if (!material)
            {

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
            }
            
            if(material)
                ((MaterialListView)lv).Items.Add(itm);
            else
                ((ListView)lv).Items.Add(itm);
        }
       
        /// <summary>
        /// Adds multiple reminders to the listview
        /// </summary>
        /// <param name="lv">The listview</param>
        /// <param name="rem">The list of reminders</param>
        public static void AddRemindersToListview(object lv, List<Reminder> reminderList, bool material)
        {
            List<Reminder> disabledReminders = new List<Reminder>(); //We're going to add the disabled reminders after all the enabled ones.  
            
            //First, lets check if this list is correct
            foreach(Reminder checkRem in reminderList)
            {
                if (BLReminder.IsValidReminder(checkRem) != null)
                {
                    //This reminder isn't valid! Set the "Corrupted" tag to 1 and throw exception
                    checkRem.Corrupted = 1;
                    BLReminder.EditReminder(checkRem);
                    throw new ReminderException("Corrupted/damaged reminder: " + checkRem.Name + " \r\nIt has been removed from your list of reminders", checkRem);
                }
            }
                      
            List<Reminder> list = reminderList.Where(r => r.HttpId == null).OrderBy(t => Convert.ToDateTime(t.Date.Split(',')[0])).ToList();
            list.AddRange(reminderList.Where(r => r.HttpId != null));

            foreach (Reminder rem in list)
            {                
                if (rem.Enabled == 1) //not disabled? add to listview
                    AddReminderToListview(lv, rem, material);
                else
                    disabledReminders.Add(rem);
            }

            //Add disabled reminders to the bottom of the list
            foreach (Reminder rem in disabledReminders)
                AddReminderToListview(lv, rem, material);
        }

        public static void SetImageAlpha(PictureBox pb, int alpha)
        {
            if (pb.Image == null)
                return;

            var original = (Bitmap)pb.Image.Clone();
            pb.BackColor = Color.Transparent;
            pb.Image = SetAlpha((Bitmap)original, alpha);
        }
        private static Bitmap SetAlpha(Image bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
        new float[] {1, 0, 0, 0, 0},
        new float[] {0, 1, 0, 0, 0},
        new float[] {0, 0, 1, 0, 0},
        new float[] {0, 0, 0, a, 0},
        new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        public static void CenterFormToParent(Form c, Form parent)
        {            
            c.StartPosition = FormStartPosition.Manual;
            c.Location = new Point(parent.Location.X + ((parent.Width / 2) - c.Width / 2), parent.Location.Y + ((parent.Height / 2) - (c.Height / 2)));
        }
        /// <summary>
        /// Gets the amount of minutes from a bunifu textbox string. Includes formats like h, for example 1h30 returns 90
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static int GetTextboxMinutes(Control tb)
        {
            try
            {                
                int timerMinutes = 0;

                //Text without the 'm'. We know the number after 'h' is in minutes, no need to keep it in the string
                string tbText = tb.Text.ToLower().Replace("m", "");
                if (tbText.Contains('h'))
                {
                    BLIO.Log("Reminder popup contains 'h'. Checking what's before it");

                    //Get the tbPrompt number of the 'h' in the text
                    int index = tbText.IndexOf('h');

                    //Now get all the text before it(should be a numer) and multiply by 60 because the user input hours
                    BLIO.Log("Parsing hours....");
                    timerMinutes += Convert.ToInt32(tbText.Substring(0, index)) * 60;

                    //Now get the number after the 'h' , which should be minutes, and add it to timerMinutes
                    //But, first check if there is actually something after the 'h'

                    if (tbText.Length > index + 1)//+1 because .Length starts from 1, index starts from 0
                    {
                        BLIO.Log("Parsing minutes....");
                        timerMinutes += Convert.ToInt32(tbText.Substring(index + 1, tbText.Length - (index + 1)));
                    }
                }
                else
                    timerMinutes = Convert.ToInt32(tbText);

                return timerMinutes;
            }
            catch
            {
                return -1;
            }
        }
    }
}
