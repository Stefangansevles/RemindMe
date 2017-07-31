using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RemindMe;
using Database.Entity;
using Business_Logic_Layer;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestBLDateTime
    {
        public TestBLDateTime()
        {
        }
        [TestMethod]
        public void TestGetNextWorkDay()
        {                        
            Reminder rem = new Reminder();
            rem.Date = BLDateTime.GetDateOfNextDay(DayOfWeek.Friday).ToShortDateString() + " 00:00:00"; //a friday
            rem.Name = "weekdayTest";
            rem.Enabled = 1;
            rem.Note = "some note";
            rem.SoundFilePath = "";
            rem.RepeatType = ReminderRepeatType.WORKDAYS.ToString();

            DateTime? monday = Convert.ToDateTime(rem.Date).AddDays(3); // a monday
            Assert.IsNotNull(monday); 
            Assert.AreEqual(monday, Convert.ToDateTime(rem.Date).AddDays(3)); //rem's date is friday, so next workday should be monday. 

            rem.Date = BLDateTime.GetDateOfNextDay(DayOfWeek.Monday).ToShortDateString() + " 00:00:00"; //a monday
            DateTime? tuesday = Convert.ToDateTime(rem.Date).AddDays(1);
            Assert.IsNotNull(tuesday);
            Assert.AreEqual(tuesday, Convert.ToDateTime(rem.Date).AddDays(1)); //rem's date is monday, so next workday should be tuesday.
        }
        [TestMethod]
        public void TestGetNextDay()
        {                        
            //BLDateTime.GetDateOfNextDay() works with DateTime.Now, so it's not easily tested.          
            switch (DateTime.Now.Day)
            {
                case 0: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Monday).ToShortDateString(),DateTime.Now.AddDays(1).ToShortDateString());
                    break; //sunday
                case 1: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Tuesday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break; //monday
                case 2: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break;
                case 3: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Thursday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break;
                case 4: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Friday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break;
                case 5: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Saturday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break;
                case 6: Assert.AreEqual(BLDateTime.GetDateOfNextDay(DayOfWeek.Sunday).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                    break;                
            }
        }
    }
}
