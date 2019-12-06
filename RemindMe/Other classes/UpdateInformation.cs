using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
    //Contains information about what's new in the new version
    public class UpdateInformation
    {
        private static Dictionary<string, string> releaseNotes = new Dictionary<string, string>();

        public static void Initialize()
        {
            releaseNotes.Add("2.4.15", "The RemindMe Timer popup(for quick timers) now accepts xxhxxm syntax, for example 5h30m will now be accepted.\r\nPreviously you had to enter 530(minutes) to reach the same goal.");
            releaseNotes.Add("2.4.16", "Big change to the Timer system.You can now create as many timers as you want!they will all run simultaneously.\r\n"
            +"The Timer screen has been altered to fit this change. Once you start to add timers you will be able to select the timers by clicking the button(s).\r\n"
            +"You can then pause them or alter the time in which they will pop up. You can also delete the timers by right - clicking the button.\r\n"
            +"Attempted to make the TimerPopup have more priority over other things running on your computer, so that you can always instantly type the time / timer note, instead of having to click on the popup to gain focus");

            releaseNotes.Add("2.4.17", "tiny fix to the timer system.Timer's are now being disposed when they run out");
            releaseNotes.Add("2.4.18", "Fixed a small issue where a test date was still hardcoded in, which made it impossible to make a new reminder with a custom date, Oops!");
            releaseNotes.Add("2.5.0", "Overhauled the list of reminders. Instead of just being text, it is now a fancy item. \r\nThe list contains 7 reminders and the user can press next/previous page to see the other reminders\r\n Fixed an issue where RemindMe would throw an error when loading the settings tab if the default timer sound was not set.");
            releaseNotes.Add("2.5.1", "RemindMe now has update support! \r\nIf there's a new version available, you will get a notification and the left panel of RemindMe will contain a green button to update!");
            releaseNotes.Add("2.5.2", "Fixed an issue where the timer popup would cause an error.");    
            releaseNotes.Add("2.5.3", "Finally fixed the issue where RemindMe looks really weird(mostly windows 10) where you can't see certain parts of RemindMe until you hover over it");
            releaseNotes.Add("2.5.4", "Redesigned the RemindMe popup form that shows whenever a reminder pops up\r\nRemindMe will no longer crash when you try to send an e-mail without having an internet connection\r\nReworked the timer system.Running timers will now still have the correct date after the computer has been put to sleep for an x amount of time.");
            releaseNotes.Add("2.5.5", "Fixed a problem with the timers where it would pop up two messages when a timer pops up");
            releaseNotes.Add("2.5.6", "Reminder Popup now doesnt show the postpone textbox by default, only when selecting the postpone option\r\nIncreased the performance speed of loading the screen to edit or create a new reminder\r\nFixed an issue where the list of reminders would not be refreshed after being on a page where there's not 7 reminders\r\nFixed an issue where downloading a new version of RemindMe would crash the application if the form hasn't become visible yet");
            releaseNotes.Add("2.5.7", "Fixed a bug where RemindMe wouldn't show after double clicking it's icon\r\nRemindMe's tray icon now has an update function that's clickable if theres a new update available");
            releaseNotes.Add("2.5.8", "Fixed a issue where reminders weren't being checked on RemindMe startup.");
            releaseNotes.Add("2.5.90", "Fixed an issue where using the \"Exit Remindme\" option on the icon didn't fully shut down RemindMe\r\nImproved the performance of loading the data of a reminder when editing a reminder a little bit.\r\nFixed a tiny bug where pressing the reminder tab would switch to the creating a new reminder window when navigating from another tab");
            releaseNotes.Add("2.5.91", "Fixed a small bug where an error prompt would show up when navigating to the timer tab under certain conditions\r\nFixed a bug where you couldn't select a sound effect when creating a new reminder");
            releaseNotes.Add("2.5.92", "The date of reminders in the list of reminders will now show as \"Today < time > \" instead of \" < date > < time > \" if the reminder is for today.\r\nFixed an issue where deleting reminders when you have less than 7 reminders would sometimes create an error\r\nFixed an interface issue where editing some reminders would cause some items to overlap\r\nAdded a image to the screen where you see the list of reminders if you have no reminders.The image displays that you have no reminders yet.");
            releaseNotes.Add("2.5.93", "RemindMe should now be able to send e - mails again for error reporting. This helps with fixing bugs");
            releaseNotes.Add("2.5.94", "Removed a test error");
            releaseNotes.Add("2.5.95", "Fixed a problem where sending an e-mail would crash RemindMe\r\nAdded additional failsafes for when there is a problem in RemindMe");
            releaseNotes.Add("2.5.96", "Added debug information to detect a problem");
            releaseNotes.Add("2.6.0", "RemindMe now uses an online database for various loggings. This database can also be used for other purposes in the future");
            releaseNotes.Add("2.6.101", "Added more logging to the database");
        }

        public static Dictionary<string,string> ReleaseNotes
        {
            get { return releaseNotes; }
        }
    }
}
