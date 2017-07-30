using Data_Access_Layer;
using Database;
using RemindMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Logic_Layer
{
    public abstract class BLReminder
    {
        public static List<Reminder> GetReminders()
        {
            //currently no business logic
            return DLReminders.GetReminders();
        }

        /// <summary>
        /// Gets an reminder with the matching unique id.
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns>Reminder that matches the given id. null if no reminder was found</returns>
        public static Reminder GetReminderById(long id)
        {
            if (id != -1)
                return DLReminders.GetReminderById(id);
            else
                return null;
        }

        /// <summary>
        /// Gives a new value to a reminder based on it's repeating type, and inserts it into the database
        /// </summary>
        /// <param name="rem"></param>
        public static void UpdateReminder(Reminder rem)
        {
            if (rem != null)
            {
                //Enable the reminder again
                rem.Enabled = 1;

                if (rem.RepeatType == ReminderRepeatType.NONE.ToString())
                    DLReminders.DeleteReminder(rem);

                if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString()) //Add days to the reminder so that the next date will be a new workday      
                    rem.Date = BLDateTime.GetNextReminderWorkDay(rem).ToString();

                if (rem.RepeatType == ReminderRepeatType.DAILY.ToString())    //Add a day to the reminder                                   
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1).ToString();


                if (rem.RepeatType == ReminderRepeatType.MONTHLY.ToString())
                {
                    if (rem.Date.Split(',').Length > 1)
                    {
                        List<DateTime> reminderDates = new List<DateTime>();

                        foreach (string date in rem.Date.Split(',')) //go through each date. with monthly reminders, it can have multiple dates, seperated by comma's
                        {

                            if (Convert.ToDateTime(date) < DateTime.Now)//get the next day of the monthly day of the date. example: 10-6-2017 -> 10-7-2017 BUT 31-1-2017 -> 31-3-2017, since february doesnt have 31 days                            
                                reminderDates.Add(Convert.ToDateTime(BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(date).Day).ToShortDateString() + " " + Convert.ToDateTime(date).ToShortTimeString()));
                            else
                                reminderDates.Add(Convert.ToDateTime(date)); //Date in the future? good! do nothing with it.   



                        }
                        //have to make sure the first date is in front.
                        reminderDates.Sort();

                        //Now, we're going to put the (sorted) dates in a string
                        string newDateString = "";
                        foreach (DateTime date in reminderDates)
                            newDateString += date.ToString() + ",";
                        
                        rem.Date = newDateString.Remove(newDateString.Length - 1, 1);
                    }
                    else
                    {//There's only one date in this string.                        
                        rem.Date = BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(rem.Date).Day).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString() + ",";
                    }
                }

                if (rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                    rem.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(rem.RepeatDays)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();

                if (rem.EveryXCustom != null)
                {
                    while (Convert.ToDateTime(rem.Date) < DateTime.Now)
                    {
                        //The user has a custom reminder, every x minutes,hours,days,weeks, or months
                        switch (rem.RepeatType.ToLower())
                        {
                            case "minutes":
                                rem.Date = Convert.ToDateTime(rem.Date).AddMinutes((double)rem.EveryXCustom).ToString();
                                break;
                            case "hours":
                                rem.Date = Convert.ToDateTime(rem.Date).AddHours((double)rem.EveryXCustom).ToString();
                                break;
                            case "days":
                                rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom).ToString();
                                break;
                            case "weeks":
                                rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom * 7).ToString();
                                break;
                            case "months":
                                rem.Date = Convert.ToDateTime(rem.Date).AddMonths((int)rem.EveryXCustom).ToString();
                                break;
                        }
                    }

                }

                //finally, Write the changes to the database  
                if (rem.RepeatType != ReminderRepeatType.NONE.ToString())
                    DLReminders.EditReminder(rem);
            }
            else
                throw new ArgumentNullException("parameter rem in UpdateReminder is null.");
        }

        /// <summary>
        /// Inserts a new reminder into the database
        /// </summary>
        /// <param name="name">The name of the reminder</param>
        /// <param name="date">The date the reminder should pop up</param>
        /// <param name="repeatingType"></param>        
        /// <param name="dayOfWeek">The day of the week this reminder should pop up at each week. Use null if the reminder isn't weekly</param>
        /// <param name="everyXDays">The amount of x. example: every 5 days</param>
        /// <param name="commaSeperatedDays">a string with days seperated by a comma. example: monday,friday,sunday</param>
        /// <param name="note">The optional note of this reminder</param>
        /// <param name="enabled">Wether this reminder is enabled or not. 1 = enabled   0 = not enabled</param>
        /// <param name="soundPath">The path to the sound effect that should play when this reminder pops up</param>
        /// <returns>Returns the ID of the newly inserted reminder</returns>
        public static long InsertReminder(string name, string date, string repeatingType, long? everyXDays, string commaSeperatedDays, string note, bool enabled, string soundPath)
        {
            Reminder rem = new Reminder();
            rem.Name = name;
            rem.Date = date;


            rem.RepeatType = repeatingType.ToString();

            //below are nullable parameters. a reminder can have a dayofmonth, if it does, it won't have a everyXDays.            
            if (everyXDays.HasValue)
                rem.EveryXCustom = everyXDays;

            //will containall selected days. example: "monday,thursday,saturday"          
            if (commaSeperatedDays != null && commaSeperatedDays != "")
                rem.RepeatDays = commaSeperatedDays;

            rem.Note = note;
            rem.SoundFilePath = soundPath;
            if (enabled)
                rem.Enabled = 1;
            else
                rem.Enabled = 0;

            return DLReminders.PushReminderToDatabase(rem);            
        }








       

       



        /// <summary>
        /// Update an existing reminder.
        /// </summary>
        /// <param name="rem">The altered reminder</param>
        public static void EditReminder(Reminder rem)
        {
            if (rem != null && DLReminders.GetReminderById(rem.Id) != null) //Check if the reminder exists            
                DLReminders.EditReminder(rem);            
            else
                throw new ReminderException("Could not edit that reminder, it doesn't exist.");
        }

        /// <summary>
        /// Deletes a single reminder from the database
        /// </summary>
        /// <param name="rem">The reminder you wish to remove</param>
        public static void DeleteReminder(Reminder rem)
        {
            if (rem != null)
                DLReminders.DeleteReminder(rem);
        }

        /// <summary>
        /// Deletes a single reminder from the database
        /// </summary>
        /// <param name="reminderId">The id of the reminder you wish to remove</param>
        public static void DeleteReminder(int reminderId)
        {
            if (reminderId != -1)
                DLReminders.DeleteReminder(reminderId);
        }

        /// <summary>
        /// Deletes multiple reminders from the database. 
        /// </summary>
        /// <param name="rems"></param>
        public static void DeleteReminders(List<Reminder> rems)
        {
            if (rems != null)
                DLReminders.DeleteReminders(rems);
        }
    }
}
