using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RemindMe;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestDLSettings
    {
      
        public TestDLSettings()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", RemindMe.Variables.IOVariables.databaseFile);
            BLIO.CreateDatabaseIfNotExist();
        }
        [TestMethod]
        public void TestGetSettings()
        {
            Assert.IsNotNull(DLSettings.GetSettings());            
        }
        [TestMethod]
        public void TestUpdateSettings()
        {            
            Settings set = new Settings();
            set.AlwaysOnTop = 0;
            set.StickyForm = 0;
            DLSettings.UpdateSettings(set);

            Assert.IsFalse(DLSettings.IsAlwaysOnTop());
            Assert.IsFalse(DLSettings.IsStickyForm());

            set.AlwaysOnTop = 1;
            set.StickyForm = 1;
            DLSettings.UpdateSettings(set);

            Assert.IsTrue(DLSettings.IsAlwaysOnTop());
            Assert.IsTrue(DLSettings.IsStickyForm());
        }
    }
}
