using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business_Logic_Layer
{
    /// <summary>
    /// This class has usefull methods regarding datetime.
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
        {                        
            DateTime nextWorkDay = Convert.ToDateTime(rem.Date);
            if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString())
            {
                while (nextWorkDay < DateTime.Now)
                {//Keep looping through this until the date is larger than today. If there is an reminder from 2 months ago, you dont want it to keep popping up
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
                }
                return nextWorkDay;

            }
            else
                return null;
        }

        /// <summary>
        /// Creates an datetime from a day number(1-31). It can return multiple months in the future if the current month does not have the number of days provided(example: 31).
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateForNextDayOfMonth(int day)
        {
            if (day > 0 && day <= 31)
            {
                int month = DateTime.Now.Month;

                int amountOfDaysThisMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
                if (day > amountOfDaysThisMonth)
                {
                    while (day > amountOfDaysThisMonth) //continue until we have found a month that has the appropriate amount of days
                    {
                        month++;
                        amountOfDaysThisMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
                    }

                    if (month >= 1 && month <= 12)
                        return new DateTime(DateTime.Now.Year, month, day);
                    else
                        return new DateTime();

                }
                else
                {
                    if(day > DateTime.Now.Day)
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                    else
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day).AddMonths(1);
                }

            }
            else
                return new DateTime();
        }


    }
}
