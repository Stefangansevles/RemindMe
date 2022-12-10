using Data_Access_Layer;
using Database.Entity;
//using RemindMe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Business_Logic_Layer
{
    public class BLReminder
    {
        private BLReminder() { }

        /// <summary>
        /// Gets all "existing" reminders from the database (Not the deleted/archived ones)
        /// </summary>
        /// <param name="includeConditionalReminders">Wether to include conditional (HTTP) reminders or not. These do not have a date</param>
        /// <returns></returns>
        public static List<Reminder> GetReminders(bool includeConditionalReminders = false)
        {            
            List<Reminder> reminders = DLReminders.GetReminders(includeConditionalReminders);
            GC.Collect();
            return reminders;
        }

        /// <summary>
        /// Orders reminders, ready to be served to the reminder list
        /// </summary>
        /// <returns>A list of ordered reminders, normal reminders first, then HTTP conditional reminders, then disabled reminders. Normal reminders are ordered by date</returns>
        public static List<Reminder> GetOrderedReminders()
        {
            List<Reminder> reminders = new List<Reminder>();

            //Add active reminders
            reminders.AddRange(GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).ToList());
            //Add conditional (HTTP) reminders
            reminders.AddRange(GetReminders(true).OrderBy(r => r.HttpId).Where(r => r.Enabled == 1).Where(r => r.Hide == 0).Where(r => r.HttpId != null).ToList());
            //Add disabled reminders
            reminders.AddRange(GetReminders().OrderBy(r => Convert.ToDateTime(r.Date.Split(',')[0])).Where(r => r.Enabled == 0).Where(r => r.Hide == 0).ToList());
            //Add disabled conditional reminders
            reminders.AddRange(GetReminders(true).OrderBy(r => r.HttpId).Where(r => r.Enabled == 0).Where(r => r.Hide == 0).Where(r => r.HttpId != null).ToList());

            return reminders;
        }

        /// <summary>
        /// Gets every reminder from the database
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetAllReminders()
        {                      
            List<Reminder> reminders = DLReminders.GetAllReminders();
            GC.Collect();
            return reminders;
        }
        /// <summary>
        /// Gets all (enabled) reminders which are happening today.
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetTodaysReminders()
        {
            List<Reminder> returnList = new List<Reminder>();

            foreach (Reminder rem in DLReminders.GetReminders())
            {
                //No postpone date? Is at least the first date's day <= today?
                if (rem.PostponeDate == null && Convert.ToDateTime(rem.Date.Split(',')[0]).DayOfYear <= DateTime.Now.DayOfYear && Convert.ToDateTime(rem.Date.Split(',')[0]).Year <= DateTime.Now.Year && rem.Enabled == 1)
                    returnList.Add(rem);
                //Postpone date, is at least the first postpone date's day <= today?
                else if (rem.PostponeDate != null && Convert.ToDateTime(rem.PostponeDate.Split(',')[0]).DayOfYear <= DateTime.Now.DayOfYear && Convert.ToDateTime(rem.Date.Split(',')[0]).Year <= DateTime.Now.Year && rem.Enabled == 1)
                    returnList.Add(rem);
            }

            return returnList;
        }

        /// <summary>
        /// Export a list of reminders to a .remindme file
        /// </summary>
        /// <param name="reminders"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Exception ExportReminders(List<Reminder> reminders, string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                    SerializeRemindersToFile(reminders, path + "\\Backup reminders " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".remindme");

                return null;
            }
            catch (UnauthorizedAccessException ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                return ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Get all reminders that are marked as deleted
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetDeletedReminders()
        {
            List<Reminder> reminders = DLReminders.GetDeletedReminders();
            GC.Collect();
            return reminders;            
        }

        /// <summary>
        /// Get all reminders that are marked as deleted
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetArchivedReminders()
        {
            List<Reminder> reminders = DLReminders.GetArchivedReminders();
            GC.Collect();
            return reminders;            
        }


        /// <summary>
        /// Permanentely deletes a single reminder from the database
        /// </summary>
        /// <param name="rem">The reminder you wish to remove</param>
        public static void PermanentelyDeleteReminder(Reminder rem)
        {
            if (rem != null && GetReminderById(rem.Id) != null) //Check if the reminder exists and isnt null
                DLReminders.PermanentelyDeleteReminder(rem);

            GC.Collect();
        }

        /// <summary>
        /// Marks a single reminder as archived
        /// </summary>
        /// <param name="rem">The reminder you wish to archive</param>
        public static void ArchiveReminder(Reminder rem)
        {
            DLReminders.ArchiveReminder(rem);
            GC.Collect();
        }


        /// <summary>
        /// forces the database to refresh the list
        /// </summary>
        public static void NotifyChange()
        {
            BLIO.Log("BLReminder.NotifyChange()");
            DLReminders.NotifyChange();            
            GC.Collect();            
        }
        /// <summary>
        /// Gets an reminder with the matching unique id.
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns>Reminder that matches the given id. null if no reminder was found</returns>
        public static Reminder GetReminderById(long id)
        {
            BLIO.Log("BLReminder.GetReminderById(" + id + ")");
            if (id != -1)
            {
                Reminder reminder = DLReminders.GetReminderById(id);
                GC.Collect();
                return reminder;               
            }
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rem"></param>
        public static void SkipToNextReminderDate(Reminder rem)
        {
            if (!IsRepeatableReminder(rem))
                return; //If the parameter is a reminder that doesn't have 2 or more dates, we can't continue.        

            switch (rem.RepeatType)
            {
                case "NONE": UpdateReminderDateWithoutRepeatType(rem);
                    break;
                case "DAILY": SkipDailyReminder(rem);
                    break;
                case "MONTHLY": SkipMonthlyReminder(rem);
                    break;
                case "WORKDAYS": SkipWorkdaysReminder(rem);
                    break;
                case "MULTIPLE_DAYS": UpdateReminderDateMultipleDays(rem);
                    break;
                default: if (rem.EveryXCustom != null) { UpdateReminderDateByRepeatType(rem); }
                    break;
            }
             GC.Collect();
        }

        private static void SkipWorkdaysReminder(Reminder rem)
        {
            DateTime nextWorkDay = Convert.ToDateTime(rem.Date);

            //If it's an old reminder, skip it to today. If there is an reminder from 2 months ago, you dont want it to keep popping up
            if (nextWorkDay < DateTime.Now)
                while (nextWorkDay < DateTime.Now.AddDays(-1))
                    nextWorkDay = nextWorkDay.AddDays(1);

            switch (nextWorkDay.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    nextWorkDay = nextWorkDay.AddDays(3);
                    break;
                case DayOfWeek.Saturday:
                    nextWorkDay = nextWorkDay.AddDays(2);
                    break;
                default:
                    nextWorkDay = nextWorkDay.AddDays(1);
                    break;
            }

            rem.Date = nextWorkDay.ToString();

        }

        /// <summary>
        /// Skips the date of a daily reminder to the next day
        /// </summary>
        /// <param name="rem"></param>
        private static void SkipDailyReminder(Reminder rem)
        {
            DateTime date = Convert.ToDateTime(rem.Date);
            date = date.AddDays(1);

            //If the user skips a daily reminder that is let's say 10 days in the past, let's not let the user press skip 10 times
            while (date < DateTime.Now)
            {
                date = date.AddDays(1);
            }

            rem.Date = date.ToString();
        }



        /// <summary>
        /// Update an reminder's date based on it's repeat type, ( every x: minutes,hours,days,weeks,months )
        /// </summary>
        /// <param name="rem"></param>
        private static void UpdateReminderDateByRepeatType(Reminder rem)
        {
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

        /// <summary>
        /// Update an reminder's date without a repeat type by picking the next date in sequence (This reminder's date consists of commma seperated dates: date1,date2 etc)
        /// </summary>
        /// <param name="rem"></param>
        private static void UpdateReminderDateWithoutRepeatType(Reminder rem)
        {
            //Remove the first element [0] from the string, and assign the new value to the reminder                        
            List<string> dates = rem.Date.Split(',').ToList();
            string newDateString = "";
            dates.RemoveAt(0);

            foreach (string dat in dates)
                newDateString += dat + ",";

            newDateString = newDateString.Remove(newDateString.Length - 1, 1);
            rem.Date = newDateString;
        }

        /// <summary>
        /// Update an reminder's date with a daily repeat type.
        /// </summary>
        /// <param name="rem"></param>
        /// <param name="allowUpdateTime">Determines if this method is allowed to update the TIME part of the datetime object</param>
        private static void UpdateReminderDateDaily(Reminder rem, bool allowUpdateTime = false)
        {
            if (rem.UpdateTime == 0 || !allowUpdateTime) //Dont update the time? just add 1 day
            {
                //If the reminder pops up a few days late, but the time of the reminder is still in the future, do not add one day to the current day, but set it to the current day instead
                if (Convert.ToDateTime("2010-10-10 " + Convert.ToDateTime(rem.Date).ToShortTimeString()) > Convert.ToDateTime("2010-10-10 " + DateTime.Now.ToShortTimeString()))
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString();
                else
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1).ToString();
            }
            else //change the TIME part of the datetime to now 
            {
                if (Convert.ToDateTime("2010-10-10 " + Convert.ToDateTime(rem.Date).ToShortTimeString()) > Convert.ToDateTime("2010-10-10 " + DateTime.Now.ToShortTimeString()))
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).ToString();
                else
                    rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).AddDays(1).ToString();
            }
        }

        /// <summary>
        /// skips an reminder's date with a monthly repeat type to the next date in line
        /// </summary>
        /// <param name="rem"></param>
        /// <param name="allowUpdateTime">Determines if this method is allowed to update the TIME part of the datetime object</param>
        private static void SkipMonthlyReminder(Reminder rem)
        {
            //Amount of months to add to the date. If the day of month is 31, you might need to add multiple months to get a month that has 31 days
            int monthsToAdd = 1;
            if (!string.IsNullOrWhiteSpace(rem.Date))
            {
                List<DateTime> reminderDates = new List<DateTime>();

                foreach (string date in rem.Date.Split(',')) //go through each date. with monthly reminders, it can have multiple dates, seperated by comma's                
                {
                    DateTime dateObj = Convert.ToDateTime(date);
                    //if next month has the amount of days as the dateObj, add 1 month. else add possible more months
                    if (DateTime.DaysInMonth(dateObj.AddMonths(1).Year, dateObj.AddMonths(1).Month) >= DateTime.DaysInMonth(dateObj.Year, dateObj.Month))
                    {
                        reminderDates.Add(dateObj.AddMonths(1));
                    }
                    else
                    {
                        while (DateTime.DaysInMonth(dateObj.AddMonths(monthsToAdd).Year, dateObj.AddMonths(monthsToAdd).Month) < dateObj.Day)
                            monthsToAdd++;

                        reminderDates.Add(dateObj.AddMonths(monthsToAdd));
                    }

                    //todo reminderDates.Add(Convert.ToDateTime(BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(date))));
                }

                //have to make sure the first date is in front.
                reminderDates.Sort();

                //Now, we're going to put the (sorted) dates in a string
                string newDateString = "";

                foreach (DateTime date in reminderDates)
                    newDateString += date.ToString() + ",";

                rem.Date = newDateString.Remove(newDateString.Length - 1, 1);
            }
        }

        /// <summary>
        /// Update an reminder's date with multiple days as repeat type
        /// </summary>
        /// <param name="rem"></param>
        /// <param name="allowUpdateTime">Determines if this method is allowed to update the TIME part of the datetime object</param>
        private static void UpdateReminderDateMultipleDays(Reminder rem, bool allowUpdateTime = false)
        {
            DayOfWeek dayOfWeekOfThisReminder = Convert.ToDateTime(rem.Date).DayOfWeek;
            List<string> days = BLDateTime.SortDayOfWeekStringList(rem.RepeatDays.Split(',').ToList()); //These are the days this reminder has. Example: monday,thursday,sunday

            int indexOfDay = 0;
            foreach (string day in days)
            {
                if (day.ToLower() != dayOfWeekOfThisReminder.ToString().ToLower())
                    indexOfDay++;
                else
                    break;
            }
            DayOfWeek nextDay;

            if (indexOfDay + 1 >= days.Count)
            {
                indexOfDay = 0;
                nextDay = BLDateTime.GetDayOfWeekFromString(days[indexOfDay]);
            }
            else
                nextDay = BLDateTime.GetDayOfWeekFromString(days[indexOfDay + 1]);


            int toAddDays = BLDateTime.GetAmountOfDaysBetween(dayOfWeekOfThisReminder, nextDay);
            if (toAddDays == 0)
                toAddDays = 7;
            //Days between monday and monday is 0, but in our case that means 1 week, so 7 days.
            if (rem.UpdateTime == 0 || !allowUpdateTime)
                rem.Date = Convert.ToDateTime(rem.Date).AddDays(toAddDays).ToString();
            else //Update time aswell
                rem.Date = Convert.ToDateTime(rem.Date).AddDays(toAddDays).ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

        }

        /// <summary>
        /// Checks if a reminder has 2 or more dates
        /// </summary>
        /// <param name="rem"></param>
        /// <returns></returns>
        public static bool IsRepeatableReminder(Reminder rem)
        {
            if (rem.RepeatType == ReminderRepeatType.NONE.ToString())
            {
                //Okay! the selected item has a reapeating type of NONE. The item can still contain 2 or more dates though! Let's see if it does.
                if (rem.Date.Split(',').Length <= 1)
                    return false;//If there's a single reminder in the selected reminders that does not have a next date, hide the option
            }

            return true;
        }
        /// <summary>
        /// Goes through a list of reminders and checks if there is a reminder that is not repeatable
        /// </summary>
        /// <param name="reminders"></param>
        /// <returns></returns>
        public static bool ContainsRepeatableReminder(List<Reminder> reminders)
        {
            //Check if the repeat type is NONE, and check if the amount of dates after split by comma is smaller or equal than 1.
            //If this is the case, we have a reminder that doesn't have a next day, and therefore is not repeatable
            //Then simply return if the count is equal to 0. No reminders that aren't repeatable? return true;
            return reminders.Where(r => r.RepeatType == ReminderRepeatType.NONE.ToString() && r.Date.Split(',').Length <= 1).ToList().Count == 0;
        }

        /// <summary>
        /// Goes through a list of reminders and checks if there is a reminder that is not postponed
        /// </summary>
        /// <param name="reminders"></param>
        /// <returns></returns>
        public static bool ContainsPostponedReminder(List<Reminder> reminders)
        {
            bool contains = false;
            foreach (Reminder rem in reminders)
            {
                if (rem.PostponeDate != null && rem.PostponeDate != "")
                {
                    try
                    {
                        DateTime tryConv = Convert.ToDateTime(rem.PostponeDate);
                        contains = true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else //no postpone date? don't show.
                    return false;
            }
            return contains;
        }
        /// <summary>
        /// Gives a new value to a reminder based on it's repeating type, and inserts it into the database
        /// </summary>
        /// <param name="rem"></param>
        public static void UpdateReminder(Reminder rem)
        {
            if (rem != null)
            {
                BLIO.Log("Updating reminder with id " + rem.Id);
                //Enable the reminder again
                rem.Enabled = 1;

                if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString()) //Add days to the reminder so that the next date will be a new workday      
                    rem.Date = BLDateTime.GetNextReminderWorkDay(rem, true).ToString();

                if (rem.RepeatType == ReminderRepeatType.DAILY.ToString())    //Add a day to the reminder                                     
                    UpdateReminderDateDaily(rem, true);


                if (rem.RepeatType == ReminderRepeatType.MONTHLY.ToString())
                {
                    if (rem.Date.Split(',').Length > 1)
                    {
                        List<DateTime> reminderDates = new List<DateTime>();

                        foreach (string date in rem.Date.Split(',')) //go through each date. with monthly reminders, it can have multiple dates, seperated by comma's
                        {

                            if (Convert.ToDateTime(date) < DateTime.Now)//get the next day of the monthly day of the date. example: 10-6-2017 -> 10-7-2017 BUT 31-1-2017 -> 31-3-2017, since february doesnt have 31 days                            
                                reminderDates.Add(Convert.ToDateTime(BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(date)).ToShortDateString() + " " + Convert.ToDateTime(date).ToShortTimeString()));
                            else
                                reminderDates.Add(Convert.ToDateTime(date)); //Date in the future? good! do nothing with it.   

                        }
                        //have to make sure the first date is in front.
                        reminderDates.Sort();

                        //Now, we're going to put the (sorted) dates in a string
                        string newDateString = "";
                        foreach (DateTime date in reminderDates)
                        {
                            if (rem.UpdateTime == 0)
                                newDateString += date.ToString() + ",";
                            else
                                newDateString += date.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ",";
                        }


                        rem.Date = newDateString.Remove(newDateString.Length - 1, 1);
                    }
                    else
                    {//There's only one date in this string.  
                        if (rem.UpdateTime == 0)
                            rem.Date = BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(rem.Date)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();
                        else
                            rem.Date = BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(rem.Date)).ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    }
                }

                if (rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                {
                    if (rem.UpdateTime == 0)
                        rem.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(rem.RepeatDays)).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();
                    else
                        rem.Date = Convert.ToDateTime(BLDateTime.GetEarliestDateFromListOfStringDays(rem.RepeatDays)).ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                }

                if (rem.EveryXCustom != null)
                {
                    while (Convert.ToDateTime(rem.Date) < DateTime.Now)
                    {
                        //The user has a custom reminder, every x minutes,hours,days,weeks, or months
                        switch (rem.RepeatType.ToLower())
                        {
                            case "minutes":
                                if (rem.UpdateTime == 1)
                                    rem.Date = DateTime.Now.AddMinutes((double)rem.EveryXCustom).ToString();
                                else
                                    rem.Date = Convert.ToDateTime(rem.Date).AddMinutes((double)rem.EveryXCustom).ToString();
                                break;
                            case "hours":
                                if (rem.UpdateTime == 1)
                                    rem.Date =DateTime.Now.AddHours((double)rem.EveryXCustom).ToString();
                                else
                                    rem.Date = Convert.ToDateTime(rem.Date).AddHours((double)rem.EveryXCustom).ToString();
                                break;
                            case "days":
                                rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom).ToString();
                                if (rem.UpdateTime == 1)
                                    rem.Date = Convert.ToDateTime(rem.Date).ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                                break;
                            case "weeks":
                                rem.Date = Convert.ToDateTime(rem.Date).AddDays((double)rem.EveryXCustom * 7).ToString();
                                if (rem.UpdateTime == 1)
                                    rem.Date = Convert.ToDateTime(rem.Date).ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                                break;
                            case "months":
                                rem.Date = Convert.ToDateTime(rem.Date).AddMonths((int)rem.EveryXCustom).ToString();
                                if (rem.UpdateTime == 1)
                                    rem.Date = Convert.ToDateTime(rem.Date).ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                                break;
                        }
                    }

                }
                if (rem.RepeatType == ReminderRepeatType.NONE.ToString())
                {
                    if (rem.Date.Split(',').Length > 1) //multiple dates seperated by comma's
                    {
                        string newDateString = "";//The new date1,date2,date3 string that we will assign to the reminder

                        string[] dateArray = rem.Date.Split(',');

                        dateArray = dateArray.Where(s => Convert.ToDateTime(s) > DateTime.Now).ToArray(); //remove all elements from the array that already happened

                        if (dateArray.Length == 0)
                        {
                            DLReminders.ArchiveReminder(rem);
                            return;
                        }

                        foreach (string date in dateArray)
                            newDateString += date + ",";

                        newDateString = newDateString.Remove(newDateString.Length - 1, 1); //remove the last ','

                        rem.Date = newDateString;
                    }
                    else//it had one date, and that date caused this popup. Let's delete the reminder.
                    {
                        DLReminders.ArchiveReminder(rem);
                        return;
                    }
                }
                //finally, Write the changes to the database                  
                DLReminders.EditReminder(rem);
                BLIO.Log("Reminder updated");
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
        public static long InsertReminder(string name, string date, string repeatingType, long? everyXDays, string commaSeperatedDays, string note, bool enabled, string soundPath, int updateTime = 0)
        {
            Reminder rem = new Reminder();
            rem.Name = name;

            DateTime test;
            //If split by comma [1] (second value) is not a datetime, it means the date is a single date WITH a comma in it. we gotta fix that
            if (date.Split(',').Length > 1 && !DateTime.TryParse(date.Split(',')[1], out test))
            {
                //The date contains a ',' , no good! Try and convert it to en-us
                date = DateTime.Parse(date.ToString(), CultureInfo.CurrentCulture).ToString();

                if (date.Contains(","))//Still contains a comma? Let's just convert it to en-us then..
                    date = DateTime.Parse(date.ToString(), new CultureInfo("en-US")).ToString();

            }

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

            rem.UpdateTime = updateTime;

            return DLReminders.PushReminderToDatabase(rem);
        }

        /// <summary>
        /// Checks if there is anything wrong with the reminder that might cause an exception
        /// </summary>
        /// <param name="rem">The reminder you want to check on</param>
        /// <returns>True if this reminder could cause an exception, false if not</returns>
        public static Exception IsValidReminder(Reminder rem)
        {
            try
            {
                DateTime date;

                if (rem.HttpId == null)
                {
                    //Check all possible dates
                    foreach (string stringDate in rem.Date.Split(','))
                        date = Convert.ToDateTime(stringDate);

                    if (rem.PostponeDate != null)
                        date = Convert.ToDateTime(rem.PostponeDate.Split(',')[0]);
                }


                if (rem.Enabled > 1 || rem.Enabled < 0)
                    throw new Exception("Enabled is not 0 or 1");

                if (rem.Deleted > 2 || rem.Deleted < 0)
                    throw new Exception("Deleted is not between 0 and 2");

                if (rem.Hide > 1 || rem.Hide < 0)
                    throw new Exception("Hide is not 0 or 1");

                if (rem.Corrupted > 1 || rem.Corrupted < 0)
                    throw new Exception("Corrupted is not 0 or 1");

                if (rem.EnableAdvancedReminder > 1 || rem.EnableAdvancedReminder < 0)
                    throw new Exception("EnableAdvancedReminder is not 0 or 1");

                if (rem.UpdateTime > 1 || rem.UpdateTime < 0)
                    throw new Exception("UpdateTime is not 0 or 1");

                //If the reminder is weekdays, check if there are more than 0 days 
                if (rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                {
                    string[] days = rem.RepeatDays.Split(',');

                    if (days.Length <= 0)
                        throw new Exception("RepeatType is MULTIPLE_DAYS and there are are no RepeatDays");
                }

                if (rem.RepeatType == ReminderRepeatType.CUSTOM.ToString())
                    if (rem.EveryXCustom <= 0)
                        throw new Exception("RepeatType is CUSTOM and EveryXCustom is not set");


                string test = GetRepeatTypeText(rem);

                AdvancedReminderProperties avrProps = DLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
                List<AdvancedReminderFilesFolders> avrFF = DLLocalDatabase.AVRProperty.GetAVRFilesFolders(rem.Id);

                if (rem.HttpId != null)
                {
                    HttpRequests req = DLLocalDatabase.HttpRequest.GetHttpRequest(rem.Id);
                }

            }
            catch (Exception ex)
            {                
                return ex;
            }

            return null;
        }

        /// <summary>
        /// Serializes the provided list of reminder objects to a file located at the given path
        /// </summary>
        /// <param name="reminders">The list of reminders you want serialized</param>
        /// <param name="pathToRemindMeFile">The path to the file that will contain the serialized reminder objects</param>
        /// <returns>True if succesfull, false if not</returns>
        public static bool SerializeRemindersToFile(List<Reminder> reminders, string pathToRemindMeFile)
        {
            BLIO.Log("Beginning reminder serialization...");
            // Create a hashtable of values that will eventually be serialized.
            Hashtable hashReminders = new Hashtable();
            foreach (Reminder rem in reminders)
            {
                rem.Hide = 0; //Un-hide the reminder when putting it into a .remindme file
                hashReminders.Add(rem.Id, rem);
            }
            BLIO.Log(reminders.Count + " reminders hashed");


            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream(pathToRemindMeFile, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();

            //Finally, add the language tag of the current machine running RemindMe to it
            hashReminders.Add("LANGUAGE_CODE", CultureInfo.CurrentCulture.IetfLanguageTag);
            try
            {
                BLIO.Log("Serializing reminders...");
                formatter.Serialize(fs, hashReminders);
                BLIO.Log("Reminders succesfully serialized");
            }
            catch (SerializationException)
            {
                BLIO.Log("Could not serialize reminder(s)");
                return false;
            }
            finally
            {
                fs.Close();
            }

            //Force the list in DLReminders to sync again. In this method some reminders could have their Hide property set from 1 to 0.
            //Since the reference is passed, changing the reminder here will also change the reminder in the list of DLReminders, hence the change.
            NotifyChange();
            return true;
        }



        /// <summary>
        /// De-Serializes the provided .remindme file located at the given path into a List of Reminder objects
        /// </summary>
        /// <param name="pathToRemindMeFile">The path to the file that contains the serialized reminder objects</param>
        /// <returns>A list of reminder objects from the given .remindme file</returns>
        public static List<object> DeserializeRemindersFromFile(string pathToRemindMeFile)
        {
            List<object> toReturnList = new List<object>();

            // Declare the hashtable reference.
            Hashtable hashReminders = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(pathToRemindMeFile, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                hashReminders = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException)
            {
                return null;
            }
            finally
            {
                fs.Close();
            }

            foreach (DictionaryEntry de in hashReminders)
                toReturnList.Add(de.Value);


            return toReturnList;
        }


        /// <summary>
        /// Inserts the reminder into the database.
        /// </summary>
        /// <param name="rem">The reminder you want added into the database</param>
        public static long PushReminderToDatabase(Reminder rem)
        {
            if (rem != null)
                return DLReminders.PushReminderToDatabase(rem);
            else
                return -1;
        }


        /// <summary>
        /// Prints an reminder in string format
        /// </summary>
        /// <param name="rem">The reminder</param>
        /// <returns>Details of the reminder in string format</returns>
        public static string ToString(Reminder rem)
        {
            string mess = "Reminder with ID " + rem.Id + ":\r\n";              
           
            mess += "Deleted:    "      + rem.Deleted + "\r\n";
            mess += "Date:    "         + rem.Date + "\r\n";
            mess += "RepeatType:    "   + rem.RepeatType + "\r\n";
            mess += "Enabled:    "      + rem.Enabled + "\r\n";
            mess += "DayOfMonth:    "   + rem.DayOfMonth + "\r\n";
            mess += "EveryXCustom:    " + rem.EveryXCustom + "\r\n";
            mess += "RepeatDays:    "   + rem.RepeatDays + "\r\n";
            mess += "SoundFilePath:    "+ rem.SoundFilePath + "\r\n";
            mess += "PostponeDate:    " + rem.PostponeDate + "\r\n";
            mess += "Hide:    "         + rem.Hide + "\r\n";
            mess += "Corrupted:    "    + rem.Corrupted + "\r\n";
            mess += "UpdateTime:    "   + rem.UpdateTime + "\r\n";
            mess += "EnableAdvancedReminder:" + rem.EnableAdvancedReminder + "\r\n\r\n";            

            mess += "=== Displaying date culture info of the user's PC, so you might be able to re-create the reminder ===\r\n";
            mess += "Current culture DisplayName: " + CultureInfo.CurrentCulture.DisplayName + "\r\n";
            mess += "Current culture ShortTimePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern + "\r\n";
            mess += "Current culture ShortDatePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + "\r\n";
            mess += "Current culture ToString(): " + CultureInfo.CurrentCulture.ToString() + "\r\n";

            return mess;

        }

        /// <summary>
        /// Checks if all reminders are functioning and not causing problems
        /// </summary>
        /// <returns>A list of corrupt reminders. null if none are found</returns>
        public static List<Reminder> CheckForCorruptedReminders()
        {
            BLIO.Log("Checking for corrupted reminders...");

            List<Reminder> corruptReminders = new List<Reminder>();

            foreach (Reminder rem in GetReminders())
            {
                Exception ex = IsValidReminder(rem);

                if (ex != null)
                {
                    BLIO.Log("Reminder with ID " + rem.Id + " Caused an exception: " + ex.Message + ". \r\nMarking this reminder as corrupted.");
                    rem.Corrupted = 1;

                    BLIO.Log("Pushing corrupted reminder to the db.");
                    EditReminder(rem);

                    corruptReminders.Add(rem);
                }
            }

            BLIO.Log("Checking for corrupted reminders complete.");

            if (corruptReminders.Count > 0)
                return corruptReminders;
            else
                return null;            
        }

        /// <summary>
        /// Update an existing reminder.
        /// </summary>
        /// <param name="rem">The altered reminder</param>
        public static void EditReminder(Reminder rem)
        {
            if (rem != null && DLReminders.GetReminderById(rem.Id) != null) //Check if the reminder exists            
                DLReminders.EditReminder(rem);
            // else
            ///throw new ReminderException("Could not edit that reminder, it doesn't exist.");
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


        public static string GetRepeatTypeText(Reminder rem)
        {
            if (rem.RepeatType == null)
                return "";

            if (rem.Date.Split(',').Count() > 1)
                return "Multiple dates";

            if(rem.EveryXCustom.HasValue)            
                return "Every " + rem.EveryXCustom + " " + rem.RepeatType.ToString().ToLower();            

            switch (rem.RepeatType.ToString())
            {
                case "DAILY": return "Daily";
                case "MONTHLY": return "Monthly";
                case "WORKDAYS": return "Work days";
                case "NONE": return "No repeat";
                case "CONDITIONAL":
                    HttpRequests req = BLLocalDatabase.HttpRequest.GetHttpRequestById(rem.Id);                    
                    if (req == null || req.AfterPopup == "Stop")
                        return "No repeat";
                    else if (req.AfterPopup == "Repeat")
                        return "Interval";
                    else
                        return req.AfterPopup;
                case "MULTIPLE_DAYS":
                    string dayString = "";
                    foreach (string day in rem.RepeatDays.Split(','))
                    {
                        dayString += day.Substring(0, 3) + ", ";
                    }
                    return dayString.Substring(0, dayString.Length - 2); //-2 because of , and space

                case "CUSTOM": return "Daily";
                case "Months": return "Daily";
                default: return string.Empty;
            }
        }
    }
}
