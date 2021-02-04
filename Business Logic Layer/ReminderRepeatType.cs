namespace Business_Logic_Layer
{
    /// <summary>
    /// Contains the different repeat types of an reminder.
    /// </summary>
    public enum ReminderRepeatType
    {
        /// <summary>
        /// The reminder will only show up once
        /// </summary>
        NONE,
        /// <summary>
        /// The reminder will show up every day
        /// </summary>
        DAILY,
        /// <summary>
        /// The reminder will show up every work day
        /// </summary>
        WORKDAYS,
        /// <summary>
        /// The reminder will show up every month
        /// </summary>
        MONTHLY,
        /// <summary>
        /// The reminder will show up at multiple days. example: Every monday, wednesday and sunday.
        /// </summary>
        MULTIPLE_DAYS,
        /// <summary>
        /// The reminder will show up every x amount of x, custom. Can be every 5 months, every 3 minutes, etc
        /// </summary>
        CUSTOM,
        /// <summary>
        /// The reminder will show up when a condition is met on the response data of a HTTP request
        /// </summary>
        CONDITIONAL

    }
}
