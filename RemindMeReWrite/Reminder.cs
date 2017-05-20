using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RemindMe
{
    /// <summary>
    /// This is a class that stores reminders
    /// </summary>
    public class Reminder
    {
        private static List<Reminder> reminders = new List<Reminder>();
        private string name;
        private DateTime date;
        private ReminderRepeatType repeatingType;
        private string note;
        private bool enabled;        
        private int dayOfWeek;
        private int dayOfMonth;
        private int everyXDays;
        private string soundFilePath;
        private decimal value;


        /// <summary>
        /// Sets the data of an reminder
        /// </summary>
        /// <param name="name">The name of the reminder</param>
        /// <param name="date">The complete date of the reminder (xx:xx:xxxx xx:xx:xx)</param>
        /// <param name="repeatingType">How often the reminder should repeat (None,Daily,Workdays,Weekly,Monthly)</param>
        /// <param name="note">The note that you want to add to the reminder</param>
        /// <param name="enabled">Enable if you want this reminder to pop up if it's time to pop up</param>
        public Reminder(string name, DateTime date, ReminderRepeatType repeatingType, string note, bool enabled) 
        {
            this.name = name;
            this.date = date;
            this.repeatingType = repeatingType;
            this.note = note;
            this.enabled = enabled;

            //Automatically add it to the manager's list when a new object is created
            ReminderManager.GetReminders().Add(this);            
        }
        public Reminder(string name, DateTime date, ReminderRepeatType repeatingType, int dayOfMonth, string note, bool enabled) : this(name,date,repeatingType,note,enabled)
        {                        
            this.dayOfMonth = dayOfMonth;            
        }

        public Reminder(string name, DateTime date, ReminderRepeatType repeatingType,  string note, int dayOfWeek, bool enabled) : this(name, date, repeatingType, note, enabled)
        {           
            this.dayOfWeek = dayOfWeek;
        }

        public Reminder(string name, DateTime date, ReminderRepeatType repeatingType, string note,  bool enabled,int everyXDays) : this(name, date, repeatingType, note, enabled)
        {
            this.everyXDays = everyXDays;
        }

        







        /// <summary>
        /// The name and title of the reminder
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// The repeating type of the reminder, example: Daily,Weekly,Monthly, Workdays
        /// </summary>
        public ReminderRepeatType RepeatingType
        {
            get { return repeatingType; }
            set { repeatingType = value; }
        }

        /// <summary>
        /// An optional note/description of the reminder
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        /// <summary>
        /// Determines wether the reminder is enabled
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// The complete date of the reminder. Date(xx-xx-xxxx) + time(xx:xx:xx)
        /// </summary>
        public DateTime CompleteDate
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// The date of the reminder. (xx-xx-xxxx)
        /// </summary>
        public string Date
        {
            get { return date.ToShortDateString(); }            
        }

        /// <summary>
        /// The time of the reminder. (xx-xx-xx)
        /// </summary>
        public string Time
        {
            get { return date.ToShortTimeString(); }
        }

        /// <summary>
        /// The day of the week, Monday - Sunday. Can be unassigned
        /// </summary>
        public int DayOfWeek
        {
            get { return dayOfWeek; }
            set { dayOfWeek = value; }
        }
        /// <summary>
        /// The day of the month, 1-31. Can be unassigned
        /// </summary>
        public int DayOfMonth
        {
            get { return dayOfMonth; }
            set { dayOfMonth = value; }
        }

        /// <summary>
        /// The amount of days added to the next date of this reminder. i.e reminder should pop up every 3 days
        /// </summary> 
        public int EveryXDays
        {
            get { return everyXDays; }
            set { everyXDays = value; }
        }


        /// <summary>
        /// The path to the popup sound set by the user. Can be unassigned.
        /// </summary>
        public string SoundFilePath
        {
            get { return soundFilePath; }
            set { soundFilePath = value; }
        }


        

        
    }
}
