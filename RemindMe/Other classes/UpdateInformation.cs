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
            ReleaseNotes.Add("2.5.6", "Reminder Popup now doesnt show the postpone textbox by default, only when selecting the postpone option\r\nIncreased the performance speed of loading the screen to edit or create a new reminder\r\nFixed an issue where the list of reminders would not be refreshed after being on a page where there's not 7 reminders\r\nFixed an issue where downloading a new version of RemindMe would crash the application if the form hasn't become visible yet");
            ReleaseNotes.Add("2.5.7", "Fixed a bug where RemindMe wouldn't show after double clicking it's icon");
        }

        public static Dictionary<string,string> ReleaseNotes
        {
            get { return releaseNotes; }
        }
    }
}
