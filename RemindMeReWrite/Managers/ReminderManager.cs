using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// Contains methods that handle reminders
    /// </summary>
    public abstract class ReminderManager
    {                               
        /// <summary>
        /// Adds a day to the reminder so that the next date will be a weekly day. If the day is friday, the next popup date of the reminder will be monday
        /// </summary>
        /// <param name="rem"></param>
        public static void SetNextReminderWorkDay(Reminder rem)
        {//This method is placed in ReminderManager because it directly alters an reminder. BLDateTime just has usefull date methods

            if (rem.RepeatType == ReminderRepeatType.WORKDAYS.ToString())
            {
                if (DateTime.Now.DayOfWeek != DayOfWeek.Friday && DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                    rem.Date = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString(); //You can safely add just one day
                else
                {
                    switch (DateTime.Now.DayOfWeek)
                    {//Add days to the datetime picker so that the value will be monday depending on the day after thursday
                        case DayOfWeek.Friday: rem.Date = Convert.ToDateTime(DateTime.Now.AddDays(3).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString();
                            break;
                        case DayOfWeek.Saturday: rem.Date = Convert.ToDateTime(DateTime.Now.AddDays(2).ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).ToString();
                            break;
                    }
                }
            }                            
        }

    }
}
