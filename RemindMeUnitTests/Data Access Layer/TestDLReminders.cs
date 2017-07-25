using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RemindMe;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestDLReminders
    {
        public TestDLReminders()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", RemindMe.Variables.IOVariables.databaseFile);            
            BLIO.CreateDatabaseIfNotExist();
        }

        [TestMethod]
        public void TestGetReminderById()
        {            
            if (DLReminders.GetReminders().Count > 0)
                Assert.IsNotNull(DLReminders.GetReminderById(DLReminders.GetReminders()[0].Id));

            Assert.IsNull(DLReminders.GetReminderById(-1));
        }
        [TestMethod]
        public void TestGetReminders()
        {
            Assert.IsNotNull(DLReminders.GetReminders());                        
        }
        [TestMethod]
        public void TestReminderEveryXMinutes()
        {
            //We're going to make a every 5 days reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every35minutes";
            rem.Date = DateTime.Now.AddDays(-10).ToString();
            rem.EveryXCustom = 35;
            rem.RepeatType = "minutes";
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";
            rem.Note = "A reminder for every 35 minutes";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);


            DateTime oldReminderDateBeforeUpdate = Convert.ToDateTime(rem.Date);
            DateTime expectedDate = Convert.ToDateTime(rem.Date);

            while (expectedDate < DateTime.Now)
                expectedDate = expectedDate.AddMinutes((double)rem.EveryXCustom);

            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderEveryXHours()
        {
            //We're going to make a every 5 hours reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every10hours";
            rem.Date = DateTime.Now.AddDays(-10).ToString();
            rem.EveryXCustom = 10;
            rem.RepeatType = "hours";
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";
            rem.Note = "A reminder for every 10 hours";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);


            DateTime oldReminderDateBeforeUpdate = Convert.ToDateTime(rem.Date);
            DateTime expectedDate = Convert.ToDateTime(rem.Date);

            while (expectedDate < DateTime.Now)
                expectedDate = expectedDate.AddHours((double)rem.EveryXCustom);

            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderEveryXDays()
        {
            //We're going to make a every 5 days reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every5days";
            rem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            rem.EveryXCustom = 5;
            rem.RepeatType = "days";
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";            
            rem.Note = "A reminder for every 5 d ays";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString().ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);
            

            DateTime oldReminderDateBeforeUpdate = Convert.ToDateTime(rem.Date);
            DateTime expectedDate = Convert.ToDateTime(rem.Date);

            while (expectedDate < DateTime.Now)
                expectedDate = expectedDate.AddDays(5);

            DLReminders.UpdateReminder(rem);
            
            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));            

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderEveryXWeeks()
        {
            //We're going to make a every 5 weeks reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every5weeks";
            rem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            rem.EveryXCustom = 5;
            rem.RepeatType = "weeks";
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";
            rem.Note = "A reminder for every 5 weeks";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  rem.Date, rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);


            DateTime oldReminderDateBeforeUpdate = Convert.ToDateTime(rem.Date);
            DateTime expectedDate = Convert.ToDateTime(rem.Date);

            while (expectedDate < DateTime.Now)
                expectedDate = expectedDate.AddDays((double)rem.EveryXCustom * 7);

            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderEveryXMonths()
        {
            //We're going to make a every 2 months reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every5months";
            rem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            rem.EveryXCustom = 2;
            rem.RepeatType = "months";
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";
            rem.Note = "A reminder for every 2 months";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);


            DateTime oldReminderDateBeforeUpdate = Convert.ToDateTime(rem.Date);
            DateTime expectedDate = Convert.ToDateTime(rem.Date);

            while (expectedDate < DateTime.Now)
                expectedDate = expectedDate.AddMonths((int)rem.EveryXCustom);

            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderDaily()
        {
            //We're going to make a every day reminder here.
            Reminder rem = new Reminder();
            rem.Name = "every day";
            rem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            rem.EveryXCustom = 0;
            rem.RepeatType = ReminderRepeatType.DAILY.ToString();
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "";
            rem.Note = "A reminder for every day";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);


            
            DateTime expectedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + Convert.ToDateTime(rem.Date).ToShortTimeString()).AddDays(1); 
                                        
            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(expectedDate, Convert.ToDateTime(rem.Date));

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestReminderWeekdays()
        {
            //We're going to make a every friday reminder here.
            Reminder rem = new Reminder();
            rem.Name = "reminder for monday,thursday and sunday";
            rem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            rem.EveryXCustom = 0;
            rem.RepeatType = ReminderRepeatType.MULTIPLE_DAYS.ToString();
            rem.Enabled = 1;
            rem.SoundFilePath = "";
            rem.RepeatDays = "friday";
            rem.Note = "A reminder for every friday";
            rem.PostponeDate = "";
            rem.Id = DLReminders.InsertReminder(rem.Name,  Convert.ToDateTime(rem.Date).ToString(), rem.RepeatType,  rem.EveryXCustom, "", rem.Note, true, rem.SoundFilePath);

                                   
            DLReminders.UpdateReminder(rem);

            Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Friday).ToShortDateString(), Convert.ToDateTime(rem.Date).ToShortDateString());

            //finally remove the testing-purpose reminder
            DLReminders.DeleteReminder(rem);
        }
        [TestMethod]
        public void TestInsertUpdateDeleteReminder()
        {
            int databaseReminderCount = DLReminders.GetReminders().Count;

            long idReminderOnce = DLReminders.InsertReminder("Some Reminder",  Convert.ToDateTime("2011-11-11 00:00:00").ToString(), ReminderRepeatType.NONE.ToString(),   null, "", "Some Note", true, "invalidPath");            
            long idReminderEvery5Days = DLReminders.InsertReminder("Some Reminder",  Convert.ToDateTime("2011-11-11 00:00:00").ToString(), ReminderRepeatType.CUSTOM.ToString(),  5, "", "Some Note", true, "invalidPath");
            long idReminderMonthly = DLReminders.InsertReminder("Some Reminder",  Convert.ToDateTime("2011-11-11 00:00:00").ToString(), ReminderRepeatType.MONTHLY.ToString(), 15,  "", "Some Note", true, "invalidPath");

            //The count of the database should be equal to the count before the insert + amount of inserted remindesr
            Assert.AreEqual(databaseReminderCount + 3, DLReminders.GetReminders().Count);


            //Get the inserted reminder as object. Then, we will check if all values are as they should be
            Reminder reminderOnce = DLReminders.GetReminderById(idReminderOnce);
            Reminder reminder5Days = DLReminders.GetReminderById(idReminderEvery5Days);
            Reminder reminderMonthly = DLReminders.GetReminderById(idReminderMonthly);
            
            //reminderOnce
            Assert.AreEqual(reminderOnce.Name, "Some Reminder");
            Assert.AreEqual(reminderOnce.Date, Convert.ToDateTime("2011-11-11 00:00:00").ToString()); //we convert it to datetime, and then back to string to avoid american/europe date difference issues
            Assert.AreEqual(reminderOnce.Id, idReminderOnce);
            Assert.AreEqual(reminderOnce.RepeatType, ReminderRepeatType.NONE.ToString());
            Assert.AreEqual(reminderOnce.EveryXCustom, null);
            Assert.AreEqual(reminderOnce.RepeatDays, null);            
            Assert.AreEqual(reminderOnce.Note, "Some Note");
            Assert.AreEqual(reminderOnce.Enabled, 1);
            Assert.AreEqual(reminderOnce.SoundFilePath, "invalidPath");


            //reminder5Days
            Assert.AreEqual(reminder5Days.Name, "Some Reminder");
            Assert.AreEqual(reminder5Days.Date, Convert.ToDateTime("2011-11-11 00:00:00").ToString()); //we convert it to datetime, and then back to string to avoid american/europe date difference issues
            Assert.AreEqual(reminder5Days.Id, idReminderEvery5Days);
            Assert.AreEqual(reminder5Days.RepeatType, ReminderRepeatType.CUSTOM.ToString());
            Assert.AreEqual(reminder5Days.EveryXCustom, 5);
            Assert.AreEqual(reminder5Days.RepeatDays, null);
            Assert.AreEqual(reminder5Days.Note, "Some Note");
            Assert.AreEqual(reminder5Days.Enabled, 1);
            Assert.AreEqual(reminder5Days.SoundFilePath, "invalidPath");


            //reminderMonthly
            Assert.AreEqual(reminderMonthly.Name, "Some Reminder");
            Assert.AreEqual(reminderMonthly.Date, Convert.ToDateTime("2011-11-11 00:00:00").ToString()); //we convert it to datetime, and then back to string to avoid american/europe date difference issues
            Assert.AreEqual(reminderMonthly.Id, idReminderMonthly);
            Assert.AreEqual(reminderMonthly.RepeatType, ReminderRepeatType.MONTHLY.ToString());
            Assert.AreEqual(reminderMonthly.EveryXCustom, null);
            Assert.AreEqual(reminderMonthly.RepeatDays, null);
            Assert.AreEqual(reminderMonthly.Note, "Some Note");
            Assert.AreEqual(reminderMonthly.Enabled, 1);
            Assert.AreEqual(reminderMonthly.SoundFilePath, "invalidPath");

            //Now, lets update them
            reminderOnce.Name = "testUpdate";
            reminderOnce.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            reminderOnce.PostponeDate = Convert.ToDateTime("2027-10-10 00:00:00").ToString();
            reminderOnce.Note = "updatedNote";
            reminderOnce.SoundFilePath = "updatedPath";
            reminderOnce.RepeatType = ReminderRepeatType.WORKDAYS.ToString();
            reminderOnce.Enabled = 0;            
            reminderOnce.EveryXCustom = 37;
            reminderOnce.RepeatDays = "monday,friday,sunday";            
            DLReminders.EditReminder(reminderOnce);

            //Now, let's check on those updates. did they really happen the way they should have?
            Assert.AreEqual(reminderOnce.Name, "testUpdate");
            Assert.AreEqual(reminderOnce.Date, Convert.ToDateTime("2010-10-10 00:00:00").ToString());
            Assert.AreEqual(reminderOnce.PostponeDate, Convert.ToDateTime("2027-10-10 00:00:00").ToString());
            Assert.AreEqual(reminderOnce.RepeatType, ReminderRepeatType.WORKDAYS.ToString());
            Assert.AreEqual(reminderOnce.EveryXCustom, 37);
            Assert.AreEqual(reminderOnce.RepeatDays, "monday,friday,sunday");
            Assert.AreEqual(reminderOnce.Note, "updatedNote");
            Assert.AreEqual(reminderOnce.Enabled, 0);
            Assert.AreEqual(reminderOnce.SoundFilePath, "updatedPath");

            
            //Now, lets delete them again
            DLReminders.DeleteReminder(reminderOnce);
            DLReminders.DeleteReminder(reminder5Days);
            DLReminders.DeleteReminder(reminderMonthly);            
            Assert.AreEqual(databaseReminderCount, DLReminders.GetReminders().Count);

            Assert.IsNull(DLReminders.GetReminderById(reminderOnce.Id));
            Assert.IsNull(DLReminders.GetReminderById(reminder5Days.Id));
            Assert.IsNull(DLReminders.GetReminderById(reminderMonthly.Id));
        }
    }
}
