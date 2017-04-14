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
        private static List<Reminder> reminders = new List<Reminder>();

        /// <summary>
        /// Gets the list of all reminders
        /// </summary>
        /// <returns>The list containing all reminders</returns>
        public static List<Reminder> GetReminders()
        {
            return reminders;
        }

        /// <summary>
        /// Finds an reminder in the list which matches the given name
        /// </summary>
        /// <param name="name">The name of the reminder</param>
        /// <returns>A reminder with the given name. Null if it wasn't found</returns>
        public static Reminder GetReminderByName(string name)
        {
            foreach (Reminder rem in reminders)
                if (rem.Name == name)
                    return rem;
            return null;
        }        


        /// <summary>
        /// Adds a day to the reminder so that the next date will be a weekly day. If the day is friday, the next popup date of the reminder will be monday
        /// </summary>
        /// <param name="rem"></param>
        public static void SetNextReminderWorkDay(Reminder rem)
        {//This method is placed in ReminderManager because it directly alters an reminder. BLDateTime just has usefull date methods

            if (rem.RepeatingType == ReminderRepeatType.WORKDAYS)
            {
                if (DateTime.Now.DayOfWeek != DayOfWeek.Friday && DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                    rem.CompleteDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " " + rem.Time); //You can safely add just one day
                else
                {
                    switch (DateTime.Now.DayOfWeek)
                    {//Add days to the datetime picker so that the value will be monday depending on the day after thursday
                        case DayOfWeek.Friday: rem.CompleteDate = Convert.ToDateTime(DateTime.Now.AddDays(3).ToShortDateString() + " " + rem.Time);
                            break;
                        case DayOfWeek.Saturday: rem.CompleteDate = Convert.ToDateTime(DateTime.Now.AddDays(2).ToShortDateString() + " " + rem.Time);
                            break;
                    }
                }
            }                            
        }

    }
}
