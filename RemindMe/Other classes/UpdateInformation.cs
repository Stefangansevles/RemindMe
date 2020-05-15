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
            releaseNotes.Add("2.6.102", "RemindMe no longer crashes without internet access");
            releaseNotes.Add("2.6.103", "Added RemindMe version to the database logging");
            releaseNotes.Add("2.6.104", "Performance improvement when checking for internet connectivity");
            releaseNotes.Add("2.6.200", "Fixed some things, RemindMe would crash upon launch the first time after installing an new update");
            releaseNotes.Add("2.6.202", "Added more logging");
            releaseNotes.Add("2.6.300", "- Fixed the RemindMe popup \"-\" and \"x\" (minimize and close) buttons. They weren't functioning\r\n- Fixed the resizing of the popup.The reminder text size did not increase in the preview\r\n- Fixed a problem where you kept getting the \"whats new since the previous version\" popup");
            releaseNotes.Add("2.6.301", "Removed the limit on timers where the maximum time was 24 hours\r\nChanged logging timestampts to UTC time\r\nFixed an issue with timer buttons not clearing in the timer interface");
            releaseNotes.Add("2.6.400", "- Added a new customizable feature to reminders!\r\nYou can now make it so that the time of the next day of a reminder will be equal to the time you dismiss the reminder.\r\nExample: A reminder that repeats Daily at 15:00.You turn on your computer at 16:05, remindme launches and the reminders pops up.\r\nWhen you dismiss the reminder by pressing \"OK\", the next date will be tomorrow, like usual, but at 16:05 instead of 15:00.\r\nThis feature is disabled by default and can be enabled when editing a reminder\r\n- You can now see the text you set on a timer when you press the button in the timer interface.");
            releaseNotes.Add("2.6.401", "Fixed a bug where editing an existing reminder wouldn't allow you to set the new feature \"Update time\" in certain situations");
            releaseNotes.Add("2.6.402", "- The reminder list interface now always contains 7 reminder items. Each item starts out empty initially. If you have reminders already, these items will be loaded with your reminder. This way you don't see a few reminders, and a different color under the reminders\r\n- Dragging a.remindme file into RemindMe will now import reminders again\r\n- Right clicking a reminder now does the same as clicking the settings button(hint: double clicking does the same as editing)");
            releaseNotes.Add("2.6.410", "Made a lot of fixes all around.\r\n- The \"Skip to next date\" functionality now works properly again\r\n- When you attempt to close RemindMe with active timers running, you will get a prompt asking if you really want to close RemindMe\r\n- Fixed a bug where deleting a reminder on a page with less than 7 reminders would look like a reminder was being duplicated");
            releaseNotes.Add("2.6.411", "RemindMe now proplerly reloads the reminders after importing reminders from a.remindme file");
            releaseNotes.Add("2.6.412", "Fixed a small issue where RemindMe would crash when launching RemindMe when you never used RemindMe before");
            releaseNotes.Add("2.6.413", "Fixed another small issue where RemindMe would throw an error at midnight");
            releaseNotes.Add("2.6.415", "Fixed an issue where you could not download a new version of RemindMe if you haven't opened it before (Previous fix did not work)");
            releaseNotes.Add("2.6.416", "Fixed importing reminders from a .remindme file");
            releaseNotes.Add("2.6.417", "- Fixed an issue where you might not have been able to see RemindMe properly visually until you hover over RemindMe. This was fixed previously, but re - introduced when trying to fix something else. Regardless, it is now functioning correctly again. \r\n-RemindMe users can now receive messages from the RemindMe developer through RemindMe.This can be usefull if for example some functionality like the update remindme button stops working.You can then get notified about this instead of wondering why it has stopped working.This functionality can also be used for different purposes in the future. You can watch these messages again by going into the message center in the left panel of RemindMe\r\n- The right click on a reminder menu item icons now have a white color instead of black to match the overall design of RemindMe");
            releaseNotes.Add("2.6.418", "Small update\r\n- Improved the appearance of the RemindMe messages on the bottom right corner of your monitor to look more fancy\r\n- Removed the(postponed) text after the date of a reminder that indicates that it is postponed.The italic text and the ZzZ icon should be clear enough.\r\n- Fixed a small error that would occur when you resized the RemindMe popup to a size that is smaller than the minimum size");
            releaseNotes.Add("2.6.419", "- Fixed a small issue where RemindMe would throw an error when loading RemindMe without reminders");
            releaseNotes.Add("2.6.420", "- The text on the RemindMe message form(bottom right corner) is now always centered\r\n- Fixed an issue where users could get a test RemindMe message not meant for them.");
            releaseNotes.Add("2.6.421", "The support feature(Sending an message to the RemindMe developer) now works again.Whoops!");
            releaseNotes.Add("2.6.422", "Attempted to fix a issue where RemindMe would create an error on startup when trying to read the current RemindMe version");
            releaseNotes.Add("2.6.430", "Redesigned RemindMe's error popup form. Whenever RemindMe crashes, you will see this screen. It is now better looking and easier to give input.");
            releaseNotes.Add("2.6.431", "Added some more logging to detect future bugs more easily");
            releaseNotes.Add("2.6.432", "Fixed some issues when using RemindMe without an active internet connection");
            releaseNotes.Add("2.6.433", "Fixed some issues when using RemindMe without an active internet connection (again, sorry!)");
            releaseNotes.Add("2.6.440", "- If you get an reminder notification of an reminder that is happening in 1 hour, you can now choose to postpone that reminder from that message in the bottom right corner of your monitor.\r\n- Double clicking an empty reminder no longer gives an error.");
            releaseNotes.Add("2.6.500", "- RemindMe now stays up-to-date automatically\r\n- Attempted to fix some logging errors");
            releaseNotes.Add("2.6.501", "- Fixed an issue where RemindMe wouldn't start on windows startup anymore since 2.6.500");
            releaseNotes.Add("2.6.510", "- When RemindMe can't connect to the database, it no longer lags or hangs\r\n- When you use the RemindMe Timer shortcut key, it no longer also activates shortcuts from other applications.\r\nFor example, creating a new timer with ctrl + shift + R  will no longer refresh your browser webpage if it is focused.");
            releaseNotes.Add("2.6.514", "Postponing an reminder from the message form on the bottom right corner of your screen(which shows up 1 hour before the reminder shows) will now work again. It caused an error when you did not put in an value before the message screen dissapeared");
            releaseNotes.Add("2.6.515", "- Reminders in your list of reminders will now have grayed out text if the reminder is disabled.\r\n- When you close RemindMe when you have timer's active, you no longer get the same popup twice\r\n- typing 'm' in the timer popup will now work when you haven't typed a 'h'. For example: 15m instead of just '15'. 1h15m has always worked where as 1h15 also did.\r\n- You can now launch the RemindMe Importer(double clicking a.remindme file) seperately from RemindMe.Previously, double clicking a.remindme file wouldfirst launch RemindMe.Then, if RemindMe was active, you could open the RemindMe importer by double clicking the file");
            releaseNotes.Add("2.6.516", "- Pausing running timers will now work correctly again.\r\n- Redesigned the custom message form a little bit\r\n- RemindMe will attempt to remove / hide reminders that can not be loaded(corrupt reminders)");
        }

        public static Dictionary<string,string> ReleaseNotes
        {
            get { return releaseNotes; }
        }
    }
}

