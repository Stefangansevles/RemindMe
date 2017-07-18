using System;
using System.Collections.Generic;
using RemindMe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestBLIO
    {
        public TestBLIO()
        {
            
        }
        [TestMethod]
        public void TestCreateShortcut()
        {            
            if(File.Exists(RemindMe.Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk"))            
                File.Delete(RemindMe.Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk");
            
            Assert.IsFalse(File.Exists(RemindMe.Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk"));
            BLIO.CreateShortcut();
            Assert.IsTrue(File.Exists(RemindMe.Variables.IOVariables.startupFolderPath + "RemindMe" + ".lnk"));
        }
    }
}
