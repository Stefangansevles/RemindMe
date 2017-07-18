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
        }
        [TestMethod]
        public void TestGetReminders()
        {
            Assert.IsNotNull(DLReminders.GetReminders());                        
        }
        [TestMethod]
        public void TestInsertUpdateDeleteReminder()
        {
            int databaseReminderCount = DLReminders.GetReminders().Count;

            long idReminderOnce = DLReminders.InsertReminder("Some Reminder", Convert.ToDateTime("2011-11-11 00:00:00"), ReminderRepeatType.NONE.ToString(), null,  null, "", "Some Note", true, "invalidPath");            
            long idReminderEvery5Days = DLReminders.InsertReminder("Some Reminder", Convert.ToDateTime("2011-11-11 00:00:00"), ReminderRepeatType.CUSTOM.ToString(), null, 5, "", "Some Note", true, "invalidPath");
            long idReminderMonthly = DLReminders.InsertReminder("Some Reminder", Convert.ToDateTime("2011-11-11 00:00:00"), ReminderRepeatType.MONTHLY.ToString(), 15, null, "", "Some Note", true, "invalidPath");

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
            Assert.AreEqual(reminderOnce.DayOfMonth, null);
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
            Assert.AreEqual(reminder5Days.DayOfMonth, null);
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
            Assert.AreEqual(reminderMonthly.DayOfMonth, 15);
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
            //lets just insert values into repeatdays,everyxcustom and dayofmonth aswell. a normal reminder wouldn't have all of these 3 values, but for testing purposes...       
            reminderOnce.DayOfMonth = 13;
            reminderOnce.EveryXCustom = 37;
            reminderOnce.RepeatDays = "monday,friday,sunday";            
            DLReminders.EditReminder(reminderOnce);

            //Now, let's check on those updates. did they really happen the way they should have?
            Assert.AreEqual(reminderOnce.Name, "testUpdate");
            Assert.AreEqual(reminderOnce.Date, Convert.ToDateTime("2010-10-10 00:00:00").ToString());
            Assert.AreEqual(reminderOnce.PostponeDate, Convert.ToDateTime("2027-10-10 00:00:00").ToString());
            Assert.AreEqual(reminderOnce.RepeatType, ReminderRepeatType.WORKDAYS.ToString());
            Assert.AreEqual(reminderOnce.DayOfMonth, 13);
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
