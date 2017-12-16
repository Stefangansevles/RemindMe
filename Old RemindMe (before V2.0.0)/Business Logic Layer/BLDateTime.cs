using Database.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Business_Logic_Layer
{
    /// <summary>
    /// This class has usefull methods regarding dates and times.
    /// </summary>
    public class BLDateTime
    {
        private BLDateTime() { }
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
        /// Converts a string of date of any date-time-format into a string of time of the current machine's date-time-format        
        /// </summary>
        /// <param name="Date">The string containing a date in a valid format</param>
        /// <returns></returns>
        public static string ConvertDateTimeStringToCurrentCulture(string date,string languageCode)
        {
            //Same language code? just return the same date. No converting needed
            if (CultureInfo.CurrentCulture.IetfLanguageTag == languageCode)
                return date;

            //The date format of the exported reminders in the .remindme file(for example, "nl-NL")
            DateTimeFormatInfo remindMeFileFormat = new CultureInfo(languageCode, false).DateTimeFormat;
            //the date format of the system running RemindMe(for example, "en-US")
            DateTimeFormatInfo currentSystemFormat = new CultureInfo(CultureInfo.CurrentCulture.IetfLanguageTag, false).DateTimeFormat;


            //Parse it into the correct format,
            //Convert.ToDateTime(The date, the date format of that date).ToString(the date format of the system running RemindMe)
            return Convert.ToDateTime(date, remindMeFileFormat).ToString(currentSystemFormat.ShortDatePattern + " " + currentSystemFormat.ShortTimePattern);                      
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

        public static DayOfWeek GetDayOfWeekFromString(string day)
        {

            switch (day.ToLower())
            {
                case "sunday": return DayOfWeek.Sunday;
                case "monday": return DayOfWeek.Monday;
                case "tuesday": return DayOfWeek.Tuesday;
                case "wednesday": return DayOfWeek.Wednesday;
                case "thursday": return DayOfWeek.Thursday;
                case "friday": return DayOfWeek.Friday;
                case "saturday": return DayOfWeek.Saturday;
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

        public static int GetAmountOfDaysBetween(DayOfWeek day1, DayOfWeek day2)
        {
           return (7 + (day2 - day1)) % 7;
        }

        /// <summary>
        /// Sorts a list containing unique week days, for example wednesday,monday,sunday into monday,wednesday,sunday.
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        public static List<string> SortDayOfWeekStringList(List<string> List)
        {
            List<string> returnList = new List<string>();
            List = List.ConvertAll(d => d.ToLower());

            if (List.Contains("monday"))
                returnList.Add("monday");

            if (List.Contains("tuesday"))
                returnList.Add("tuesday");

            if (List.Contains("wednesday"))
                returnList.Add("wednesday");

            if (List.Contains("thursday"))
                returnList.Add("thursday");

            if (List.Contains("friday"))
                returnList.Add("friday");

            if (List.Contains("saturday"))
                returnList.Add("saturday");

            if (List.Contains("sunday"))
                returnList.Add("sunday");

            
            return returnList;
        }

        public static DateTime GetDateForNextDayOfMonth(int day, DateTime givenTime)
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
                    
                    if (day > DateTime.Now.Day)
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day, givenTime.Hour, givenTime.Minute, givenTime.Second);

                    //If the day is the same, check for the time. If the time is in the future, do not add one month to the date!
                    else if (day == DateTime.Now.Day && Convert.ToDateTime("10-10-2010 " + givenTime.ToShortTimeString()) > Convert.ToDateTime("10-10-2010 " + DateTime.Now.ToShortTimeString()))
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day, givenTime.Hour, givenTime.Minute, givenTime.Second);
                    else
                        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day, givenTime.Hour, givenTime.Minute, givenTime.Second).AddMonths(1);
                }

            }
            else
                return new DateTime();
        }


    }
}
