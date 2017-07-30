using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RemindMe;
using Database;
using Business_Logic_Layer;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestBLSettings
    {
      
        public TestBLSettings()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", RemindMe.Variables.IOVariables.databaseFile);
            BLIO.CreateDatabaseIfNotExist();
        }
        [TestMethod]
        public void TestGetSettings()
        {
            Assert.IsNotNull(BLSettings.GetSettings());            
        }
        [TestMethod]
        public void TestUpdateSettings()
        {            
            Settings set = new Settings();
            set.AlwaysOnTop = 0;
            set.StickyForm = 0;
            BLSettings.UpdateSettings(set);

            Assert.IsFalse(BLSettings.IsAlwaysOnTop());
            Assert.IsFalse(BLSettings.IsStickyForm());

            set.AlwaysOnTop = 1;
            set.StickyForm = 1;
            BLSettings.UpdateSettings(set);

            Assert.IsTrue(BLSettings.IsAlwaysOnTop());
            Assert.IsTrue(BLSettings.IsStickyForm());
        }
    }
}
