using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    /// <summary>
    /// The Exception that is thrown when something is bad with an Reminder.
    /// </summary>
    public class ReminderException : Exception
    {
        /// <summary>
        /// An exception that is caused by a faulty reminder
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="rem">The reminder that caused an exception</param>       
        public ReminderException(string message, Reminder rem) : base(message)
        {
            Reminder = rem;
        }
        /// <summary>
        /// The Reminder object of this Exception
        /// </summary>
        public Reminder Reminder { get; private set; }
    }
}
