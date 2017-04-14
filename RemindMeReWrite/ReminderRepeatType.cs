namespace RemindMe
{
    /// <summary>
    /// Contains the repeat types of an reminder.
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
        /// The reminder will show up every week
        /// </summary>
        WEEKLY,
        /// <summary>
        /// The reminder will show up every month
        /// </summary>
        MONTHLY
    }
}
