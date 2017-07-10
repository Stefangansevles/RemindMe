using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// This class handles the dates and times of reminders.
    /// </summary>
    public abstract class BLDateTime
    {  

        /// <summary>
        /// Gets the date of the next day of the week. The time will be 00:00:00
        /// </summary>
        /// <param name="day">The day you want to know the date of</param>
        /// <returns>Date of the next day of the week</returns>
        public static DateTime GetDateOfNextDay(DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)DateTime.Now.DayOfWeek + 7) % 7;

            if (day != DateTime.Now.DayOfWeek)
                return Convert.ToDateTime(DateTime.Now.AddDays(daysToAdd).ToShortDateString() + " 00:00:00");
            else                            
                return Convert.ToDateTime(DateTime.Now.AddDays(7).ToShortDateString() + " 00:00:00");            
        }

        /// <summary>
        /// Gets the day of the week in DayOfWeek
        /// </summary>
        /// <param name="day">The day , 1 being monday. Note: sunday is 0, not 7.</param>
        /// <returns>The day in DayOfWeek format</returns>
        public static DayOfWeek GetDayOfWeekFromInt(int day)
        {
            if (day != -1 && day <= 7)
            {
                switch (day)
                {
                    case 0: return DayOfWeek.Sunday;
                    case 1: return DayOfWeek.Monday;
                    case 2: return DayOfWeek.Tuesday;
                    case 3: return DayOfWeek.Wednesday;
                    case 4: return DayOfWeek.Thursday;
                    case 5: return DayOfWeek.Friday;
                    case 6: return DayOfWeek.Saturday;                    
                }
            }

            return DateTime.Now.DayOfWeek;
        }

        /// <summary>
        /// Gets the day of the week in DayOfWeek in integer format
        /// </summary>
        /// <param name="day">The day , 1 being monday</param>
        /// <returns>The day in DayOfWeek format</returns>
        public static int GetIntFromDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday: return 0;
                case DayOfWeek.Monday: return 1;
                case DayOfWeek.Tuesday: return 2;
                case DayOfWeek.Wednesday: return 3;
                case DayOfWeek.Thursday: return 4;
                case DayOfWeek.Friday: return 5;
                case DayOfWeek.Saturday: return 6;
                default: return -1;
            }                        
        }

        /// <summary>
        /// Gets the integer value of a day in a week. returns -1 if an invalid string was given
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int GetIntWeekdayFromString(string day)
        {
            switch (day.ToLower())
            {
                case "sunday": return 0;
                case "monday": return 1;
                case "tuesday": return 2;
                case "wednesday": return 3;
                case "thursday": return 4;
                case "friday": return 5;
                case "saturday": return 6;
                default: return -1;                
            }
        }

        /// <summary>
        /// Gets the next date of the earliest coming day in a list of days. example: monday,wednesday,thursday,saturday. If it is friday, it will get the next day of saturday. 
        /// If it is tuesday, it will get the next date of the next upcoming wednesday.
        /// </summary>
        /// <param name="dayList">The string with comma seperated days. Example format: monday,tuesday,saturday,sunday</param>
        /// <returns>The next date of the earliest day from the string. null if it didn't succeed.
        /// Note: will not have a time. Complete example may be: 5-5-2017 00:00:00</returns>
        public static DateTime? GetEarliestDateFromListOfStringDays(string dayList)
        {
            //what day is it today?                    
            int today = GetIntFromDayOfWeek(DateTime.Now.DayOfWeek);
            //monday,tuesday,friday etc as ints                
            List<int> repeatDaysAsInteger = new List<int>();
            List<DateTime> datesFromInt = new List<DateTime>();

            

            //fill the int list with selected days. sunday = 0, monday = 1, etc
            if (dayList != "")
            {
                foreach (string repeatDay in dayList.ToLower().Split(',').ToList())
                    repeatDaysAsInteger.Add(GetIntWeekdayFromString(repeatDay));
            }

            //make sure the first day is at the beginning
            repeatDaysAsInteger.Sort();

            foreach (int day in repeatDaysAsInteger)                           
                datesFromInt.Add(Convert.ToDateTime(GetDateOfNextDay(GetDayOfWeekFromInt(day)).ToShortDateString()));            

            if (datesFromInt.Count > 0)
                return datesFromInt.Min();

            return null;
        }


        /// <summary>
        /// Adds day(s) to the reminder so that the next date will be a weekly day. If the day is friday, the next popup date of the reminder will be monday
        /// </summary>
        /// <param name="rem"></param>
        public static DateTime? GetNextReminderWorkDay(Reminder rem)
        {//This method is placed in ReminderManager because it directly alters an reminder. BLDateTime just has usefull date methods

            if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString())
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        return Convert.ToDateTime(DateTime.Now.AddDays(3).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString());

                    case DayOfWeek.Saturday:
                        return Convert.ToDateTime(DateTime.Now.AddDays(2).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString());

                    default:
                        return Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString());

                }

            }
            else
                return null;
        }


    }
}
