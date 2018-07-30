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
using System.Threading.Tasks;


namespace Business_Logic_Layer
{
    public class BLReminder
    {
        private BLReminder() { }

        /// <summary>
        /// Gets all non-deleted/archived reminders from the database
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetReminders()
        {
            //currently no business logic
            return DLReminders.GetReminders();
        }

        /// <summary>
        /// Gets every reminder from the database
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetAllReminders()
        {
            //currently no business logic
            return DLReminders.GetAllReminders();
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
        public static Exception ExportReminders(List<Reminder> reminders,string path)
        {            
            try
            {
                if (!string.IsNullOrEmpty(path))
                    SerializeRemindersToFile(reminders, path + "\\Backup reminders "  + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".remindme");

                return null;
            }
            catch (UnauthorizedAccessException ex)
            {                
                return ex;                
            }    
            catch(Exception ex)
            {
                return ex;
            }
        }
        /// <summary>
        /// Get all reminders that are marked as deleted
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetDeletedReminders()
        {
            return DLReminders.GetDeletedReminders();
        }

        /// <summary>
        /// Gets all "Corrupted" reminders. Corrupted reminders are reminders that are marked as corrupted, because they caused an exception. They can't be processed
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetCorruptedReminders()
        {
            return DLReminders.GetCorruptedReminders();
        }

        /// <summary>
        /// Get all reminders that are marked as deleted
        /// </summary>
        /// <returns></returns>
        public static List<Reminder> GetArchivedReminders()
        {
            return DLReminders.GetArchivedReminders();
        }


        /// <summary>
        /// Permanentely deletes a single reminder from the database
        /// </summary>
        /// <param name="rem">The reminder you wish to remove</param>
        public static void PermanentelyDeleteReminder(Reminder rem)
        {
            if(rem != null && GetReminderById(rem.Id) != null) //Check if the reminder exists and isnt null
                DLReminders.PermanentelyDeleteReminder(rem);
        }

        /// <summary>
        /// Permanentely deletes a single reminder from the database
        /// </summary>
        /// <param name="rem">The reminder you wish to remove</param>
        public static void PermanentelyDeleteReminder(int reminderId)
        {
            if(GetReminderById(reminderId) != null)
                DLReminders.PermanentelyDeleteReminder(reminderId);
        }


        /// <summary>
        /// Deletes multiple reminders from the database. 
        /// </summary>
        /// <param name="rems"></param>
        public static void PermanentelyDeleteReminders(List<Reminder> rems)
        {
            DLReminders.PermanentelyDeleteReminders(rems);
        }

        /// <summary>
        /// Marks a single reminder as archived
        /// </summary>
        /// <param name="rem">The reminder you wish to archive</param>
        public static void ArchiveReminder(Reminder rem)
        {
            ArchiveReminder(rem);
        }
        /// <summary>
        /// Marks a single reminder as deleted
        /// </summary>
        /// <param name="reminderId">The id of the reminder you wish to remove</param>
        public static void ArchiveReminder(int reminderId)
        {
            DLReminders.ArchiveReminder(reminderId);
        }

        /// <summary>
        /// Deletes multiple reminders from the database. 
        /// </summary>
        /// <param name="rems"></param>
        public static void ArchiveReminders(List<Reminder> rems)
        {
            if(rems != null)
                DLReminders.ArchiveReminders(rems);
        }

        /// <summary>
        /// forces the database to refresh the list
        /// </summary>
        public static void NotifyChange()
        {
            BLIO.Log("BLReminder.NotifyChange()");
            DLReminders.NotifyChange();
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
        /// 
        /// </summary>
        /// <param name="rem"></param>
        public static void SkipToNextReminderDate(Reminder rem)
        {
            if (!IsRepeatableReminder(rem))
                return; //If the parameter is a reminder that doesn't have 2 or more dates, we can't continue.

            
            switch (rem.RepeatType)
            {
                case "NONE": //Remove the first element [0] from the string, and assign the new value to the reminder                        
                    List<string> dates = rem.Date.Split(',').ToList();
                    string newDateString = "";
                    dates.RemoveAt(0);

                    foreach (string dat in dates)
                        newDateString += dat + ",";

                    newDateString = newDateString.Remove(newDateString.Length - 1, 1);
                    rem.Date = newDateString;

                    break;
                case "DAILY":
                    rem.Date = Convert.ToDateTime(rem.Date).AddDays(1).ToString();
                    break;
                case "MONTHLY":
                    //Add 1 month to the first date of the month string, [0] and add it to the end
                    List<string> monthDates = rem.Date.Split(',').ToList();
                    string newMonthString = "";
                    int monthDay = Convert.ToDateTime(monthDates[0]).Day;
                    int monthsInAdvance = 1;
                    string updatedDate = "";

                    //If you add 1 month, and the day is not equal, then that means the next month doesnt have enough days. Keep adding months until we find the good month
                    //Example: Day of month: 31. Add 1 month to january, thats february. It doesnt have 31 days, so it should go to the next month, etc etc
                    if (Convert.ToDateTime(monthDates[0]).AddMonths(1).Day != monthDay)
                    {
                        while (Convert.ToDateTime(monthDates[0]).AddMonths(monthsInAdvance).Day != monthDay)
                        {
                            monthsInAdvance++;
                        }
                        updatedDate = Convert.ToDateTime(monthDates[0]).AddMonths(monthsInAdvance).ToString();
                    }
                    else
                        updatedDate = Convert.ToDateTime(monthDates[0]).AddMonths(1).ToString(); //Just add 1 month


                    //Remove the old date at index 0, and add the new date at the end.
                    monthDates.RemoveAt(0);
                    monthDates.Add(updatedDate);

                    foreach (string monthDate in monthDates)
                        newMonthString += monthDate + ",";

                    newDateString = newMonthString.Remove(newMonthString.Length - 1, 1);
                    rem.Date = newDateString;
                    break;
                case "WORKDAYS":
                    if (Convert.ToDateTime(rem.Date).DayOfWeek == DayOfWeek.Friday)
                        rem.Date = Convert.ToDateTime(rem.Date).AddDays(3).ToString(); //Add 3 days, friday -> saturday -> sunday -> monday
                    else if (Convert.ToDateTime(rem.Date).DayOfWeek == DayOfWeek.Saturday)
                        rem.Date = Convert.ToDateTime(rem.Date).AddDays(2).ToString(); //Add 2 days,  saturday -> sunday -> monday                        
                    else
                        rem.Date = Convert.ToDateTime(rem.Date).AddDays(1).ToString();
                    break;
                case "MULTIPLE_DAYS":
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
                    rem.Date = Convert.ToDateTime(rem.Date).AddDays(toAddDays).ToString();
                    break;
                default:
                    if (rem.EveryXCustom != null)
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
                    break;
            }
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
                    catch (Exception ex)
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
                    rem.Date = BLDateTime.GetNextReminderWorkDay(rem).ToString();

                if (rem.RepeatType == ReminderRepeatType.DAILY.ToString())    //Add a day to the reminder 
                {
                    //If the reminder pops up a few days late, but the time of the reminder is still in the future, do not add one day to the current day, but set it to the current day instead
                    if(Convert.ToDateTime("2010-10-10 " + Convert.ToDateTime(rem.Date).ToShortTimeString()) > Convert.ToDateTime("2010-10-10 " + DateTime.Now.ToShortTimeString()))
                        rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString();
                    else
                        rem.Date = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1).ToString();
                }


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
                        rem.Date = BLDateTime.GetDateForNextDayOfMonth(Convert.ToDateTime(rem.Date).Day).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString();
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
                if(rem.RepeatType == ReminderRepeatType.NONE.ToString())
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
        /// Checks if there is anything wrong with the reminder that might cause an exception
        /// </summary>
        /// <param name="rem">The reminder you want to check on</param>
        /// <returns>True if this reminder could cause an exception, false if not</returns>
        public static bool IsValidReminder(Reminder rem)
        {
            try
            {
                DateTime date;
                //Check all possible dates
                foreach (string stringDate in rem.Date.Split(','))
                {
                    date = Convert.ToDateTime(stringDate);
                }
                

                if(rem.PostponeDate != null)
                    date = Convert.ToDateTime(rem.PostponeDate.Split(',')[0]);

                //If the reminder is weekdays, check if there are more than 0 days 
                if(rem.RepeatType == ReminderRepeatType.MULTIPLE_DAYS.ToString())
                {
                    string[] days = rem.RepeatDays.Split(',');

                    if (days.Length <= 0)
                        return false;
                }
                if (rem.RepeatType == ReminderRepeatType.CUSTOM.ToString())
                {
                    if (rem.EveryXCustom <= 0)
                        return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Serializes the provided list of reminder objects to a file located at the given path
        /// </summary>
        /// <param name="reminders">The list of reminders you want serialized</param>
        /// <param name="pathToRemindMeFile">The path to the file that will contain the serialized reminder objects</param>
        /// <returns>True if succesfull, false if not</returns>
        public static bool SerializeRemindersToFile(List<Reminder> reminders,string pathToRemindMeFile)
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
            catch (SerializationException e)
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
