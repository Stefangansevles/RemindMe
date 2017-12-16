using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
    /// <summary>
    /// The Exception that is thrown when something is bad with an Reminder.
    /// </summary>
    public class ReminderException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message</param>
        public ReminderException(string message) : base(message)
        {
            
        }
    }
}
