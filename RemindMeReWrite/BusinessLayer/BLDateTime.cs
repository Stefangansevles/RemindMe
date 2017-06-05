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
        /// <param name="day">The day , 1 being monday</param>
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

            return DayOfWeek.Monday;
        }

        
    }
}
