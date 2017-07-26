using System;
using RemindMe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestFormLogic
    {
        Form1 mainForm;
        Reminder testReminder;
        Songs testSong;        
        public TestFormLogic()
        {
            mainForm = new Form1();
            DLSongs.GetSongs();            

            //Create a sound
            testSong = new Songs();
            testSong.SongFilePath = "c:\\testSong.mp3";
            testSong.SongFileName = "testSong.mp3";
            DLSongs.InsertSong(testSong);                                  
        }
        [TestMethod]
        public void TestAddSongToCombobox()
        {
            Assert.AreEqual(mainForm.cbSound.Items.Count, 1); //there's always 1 item, the item "Add files..."
            ComboBoxItem item = new ComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath));
            mainForm.cbSound.Items.Add(item);
            Assert.AreEqual(mainForm.cbSound.Items.Count, 2);
        }
      
       
        [TestMethod]
        public void TestAddAndRemoveReminderFromListview()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.WORKDAYS.ToString();
            testReminder.RepeatDays = "";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            Assert.AreEqual(mainForm.lvReminders.Items.Count, 0);
            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, 1);

            ListViewItem item = mainForm.lvReminders.Items[0];
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Tag, testReminder.Id);
            Assert.AreEqual(item.Text, testReminder.Name);

            mainForm.lvReminders.Items.Remove(item);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, 0);

            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }
        [TestMethod]
        public void TestFillReminderFormForEditWorkdays()
        {        
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.WORKDAYS.ToString();
            testReminder.RepeatDays = "";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);
            
            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);
            
            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));           
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbWorkDays.Checked);

            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }

        [TestMethod]
        public void TestFillReminderFormForEditOnce()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.NONE.ToString();
            testReminder.RepeatDays = "";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);

            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbNoRepeat.Checked);

            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }
        [TestMethod]
        public void TestFillReminderFormForEditDaily()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.DAILY.ToString();
            testReminder.RepeatDays = "";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);

            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbDaily.Checked);

            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }
        [TestMethod]
        public void TestCheckBoxChangesDateTimePickerDate()
        {
            foreach (CheckBox cb in mainForm.pnlDayCheckBoxes.Controls)
                cb.Checked = false;

            mainForm.cbMonday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
            mainForm.cbMonday.Checked = false;
            mainForm.cbTuesday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Tuesday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Tuesday));
            mainForm.cbTuesday.Checked = false;
            mainForm.cbWednesday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
            mainForm.cbWednesday.Checked = false;
            mainForm.cbThursday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Thursday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Thursday));
            mainForm.cbThursday.Checked = false;
            mainForm.cbFriday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Friday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Friday));
            mainForm.cbFriday.Checked = false;
            mainForm.cbSaturday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Saturday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Saturday));
            mainForm.cbSaturday.Checked = false; 
            mainForm.cbSunday.Checked = true;
            Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Sunday);
            Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Sunday));
            mainForm.cbSunday.Checked = false;


            //now some combination tests
            switch(DateTime.Now.DayOfWeek)
            {
                
                case DayOfWeek.Monday:
                    //next date should be wednesday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
                    //now, we remove wednesday.
                    mainForm.cbWednesday.Checked = false;
                    //next day should be friday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Friday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Friday));
                    break;

                case DayOfWeek.Tuesday:
                    //next date should be wednesday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
                    //now, we remove wednesday.
                    mainForm.cbWednesday.Checked = false;
                    //next day should be friday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Friday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Friday));
                    break;

                case DayOfWeek.Wednesday:
                    //next date should be friday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Friday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Friday));
                    //now, we remove friday.
                    mainForm.cbFriday.Checked = false;
                    //next day should be monday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
                    break;

                case DayOfWeek.Thursday:
                    //next date should be sunday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbSunday.Checked = true;                    
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Sunday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Sunday));
                    //now, we remove Sunday.
                    mainForm.cbSunday.Checked = false;
                    //next day should be monday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
                    break;

                case DayOfWeek.Friday:
                    //next date should be monday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
                    //now, we remove Monday.
                    mainForm.cbMonday.Checked = false;
                    //next day should be wednesday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
                    break;

                case DayOfWeek.Saturday:
                    //next date should be monday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
                    //now, we remove monday.
                    mainForm.cbMonday.Checked = false;
                    //next day should be wednesday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
                    break;


                case DayOfWeek.Sunday:
                    //next date should be monday
                    mainForm.cbMonday.Checked = true;
                    mainForm.cbWednesday.Checked = true;
                    mainForm.cbFriday.Checked = true;
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Monday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Monday));
                    //now, we remove monday.
                    mainForm.cbMonday.Checked = false;
                    //next day should be wednesday
                    Assert.AreEqual(mainForm.dtpDate.Value.DayOfWeek, DayOfWeek.Wednesday);
                    Assert.AreEqual(mainForm.dtpDate.Value, BLDateTime.GetDateOfNextDay(DayOfWeek.Wednesday));
                    break;
            }
        }
        [TestMethod]
        public void TestFillReminderFormForEditMonthly()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.MONTHLY.ToString();
            testReminder.RepeatDays = "";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);

            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbMonthly.Checked);
            Assert.AreEqual(mainForm.lblEvery.Text, "Day(s):");
            
            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }
        [TestMethod]
        public void TestFillReminderFormForEditCustom()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = "Days";
            testReminder.EveryXCustom = 5; //every 5 days
            testReminder.RepeatDays = "";            
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);

            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbEveryXCustom.Checked);
            Assert.AreEqual(mainForm.cbEveryXCustom.SelectedItem.ToString(), "Days");
            Assert.AreEqual(mainForm.numEveryXDays.Value.ToString(), "5");
            Assert.AreEqual(mainForm.lblEvery.Text, "Every:");


           
            
            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }
        [TestMethod]
        public void TestFillReminderFormForEditMultipleDays()
        {
            //Creating a test reminder to test some form logic with.
            testReminder = new Reminder();
            testReminder.Note = "some note";
            testReminder.Name = "testReminder";
            testReminder.RepeatType = ReminderRepeatType.MULTIPLE_DAYS.ToString();
            testReminder.RepeatDays = "monday,tuesday,wednesday";
            testReminder.SoundFilePath = testSong.SongFilePath;
            testReminder.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testReminder.Enabled = 1;
            testReminder.Id = DLReminders.InsertReminder(testReminder.Name,  testReminder.Date, testReminder.RepeatType,  null, testReminder.RepeatDays, testReminder.Note, true, testReminder.SoundFilePath);

            //Add it to the listview
            BLFormLogic.AddReminderToListview(mainForm.lvReminders, testReminder);

            //So, now the reminder is in the listview. Let's attempt to fill the controls with it's details!
            mainForm.FillControlsForEdit(testReminder);
            Assert.AreEqual(mainForm.tbNote.Text, testReminder.Note.Replace("\\n", Environment.NewLine));
            Assert.AreEqual(mainForm.tbReminderName.Text, testReminder.Name);
            Assert.AreEqual(mainForm.cbSound.SelectedItem, ComboBoxItemManager.GetComboBoxItem(Path.GetFileNameWithoutExtension(testSong.SongFileName), DLSongs.GetSongByFullPath(testSong.SongFilePath)));
            Assert.AreEqual(mainForm.dtpDate.Value, Convert.ToDateTime(testReminder.Date));
            Assert.AreEqual(mainForm.dtpTime.Value, Convert.ToDateTime(Convert.ToDateTime(testReminder.Date).ToShortTimeString()));
            Assert.IsTrue(mainForm.rbMultipleDays.Checked);

            //Day checkboxes
            Assert.IsTrue(mainForm.cbMonday.Checked);
            Assert.IsTrue(mainForm.cbTuesday.Checked);
            Assert.IsTrue(mainForm.cbWednesday.Checked);

            //change the day string, fill controls and check again
            testReminder.RepeatDays = "thursday,friday,saturday,sunday";
            mainForm.FillControlsForEdit(testReminder);

            Assert.IsTrue(mainForm.cbThursday.Checked);
            Assert.IsTrue(mainForm.cbFriday.Checked);
            Assert.IsTrue(mainForm.cbSaturday.Checked);
            Assert.IsTrue(mainForm.cbSunday.Checked);

            
            //delete it so it wont stay in the database
            DLReminders.DeleteReminder(testReminder);
        }

        [TestMethod]
        public void TestResetReminderForm()
        {
            mainForm.ResetReminderForm();
            Assert.IsNull(mainForm.cbSound.SelectedItem);
            Assert.AreEqual(mainForm.tbReminderName.Text, "");
            Assert.IsTrue(mainForm.rbNoRepeat.Checked);
            Assert.AreEqual(mainForm.cbSound.Text, "");
            Assert.AreEqual(mainForm.cbEveryXCustom.SelectedItem, mainForm.cbEveryXCustom.Items[2]);
        }

        //from here on, we are going to test the form logic with the controls itself. we're going to insert data into the controls and raising the click events of buttons
        //NOTE: Yes. making the _click event on a button public is bad. BUT, in these unit tests, all the controls are not visible. therefore PerformClick() will do nothing, because the button is invisible            
        [TestMethod]
        public void TestMakeReminderMonthlyWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbMonthly.Checked = true;

            mainForm.cbEvery.SelectedItem = mainForm.cbEvery.Items[0]; //"1"
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 0);
            mainForm.btnAddMonthlyDay_Click(null, null);
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 1);
            Assert.IsNotNull(mainForm.cbMonthlyDays.Items[0]); //the combobox item should not be null
            Assert.AreEqual(mainForm.cbMonthlyDays.Items[0].ToString(), "1"); //we added "1" to the combobox, so lets test this
                        
            mainForm.cbEvery.SelectedItem = mainForm.cbEvery.Items[4]; //"5"
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 1);
            mainForm.btnAddMonthlyDay_Click(null, null);
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 2);
            Assert.IsNotNull(mainForm.cbMonthlyDays.Items[1]); //the combobox item should not be null
            Assert.AreEqual(mainForm.cbMonthlyDays.Items[1].ToString(), "5"); //we added "1" to the combobox, so lets test this

            mainForm.cbEvery.SelectedItem = mainForm.cbEvery.Items[14]; //"15"
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 2);
            mainForm.btnAddMonthlyDay_Click(null, null);
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 3);
            Assert.IsNotNull(mainForm.cbMonthlyDays.Items[2]); //the combobox item should not be null
            Assert.AreEqual(mainForm.cbMonthlyDays.Items[2].ToString(), "15"); //we added "1" to the combobox, so lets test this

            //actually, lets remove 15. 
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 3);
            mainForm.cbMonthlyDays.SelectedItem = mainForm.cbMonthlyDays.Items[2];
            mainForm.btnRemoveMonthlyDay_Click(null, null);
            Assert.AreEqual(mainForm.cbMonthlyDays.Items.Count, 2);


            

            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    
                    Assert.AreEqual(item.Note, "some note");
                    Assert.AreEqual(item.RepeatDays, null);
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, null);

                    DLReminders.DeleteReminder(item);
                }
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }

        [TestMethod]
        public void TestMakeReminderCustomWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpDate.Value = DateTime.Now.AddDays(1);
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbEveryXCustom.Checked = true;
            
            mainForm.cbEveryXCustom.SelectedItem = mainForm.cbEveryXCustom.Items[2]; //"Days"
            mainForm.numEveryXDays.Value = 10;
            //Every 10 days            




            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    Assert.AreEqual(item.Date, DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                    Assert.AreEqual(item.Note, "some note");
                    Assert.AreEqual(item.RepeatType, "Days");
                    Assert.AreEqual(item.RepeatDays, null);
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, 10);

                    DLReminders.DeleteReminder(item);
                }
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }

        [TestMethod]
        public void TestMakeReminderOnceWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpDate.Value = DateTime.Now.AddDays(1);
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbNoRepeat.Checked = true;

          

            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    Assert.AreEqual(item.RepeatType, ReminderRepeatType.NONE.ToString());
                    Assert.AreEqual(item.Date, DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                    Assert.AreEqual(item.Note, "some note");
                    Assert.AreEqual(item.RepeatDays, null);
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, null);

                    DLReminders.DeleteReminder(item);
                }
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }

        [TestMethod]
        public void TestMakeReminderWeekdaysWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpDate.Value = DateTime.Now.AddDays(1);
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbMultipleDays.Checked = true;
            mainForm.cbMonday.Checked = true;
            mainForm.cbWednesday.Checked = true;
            mainForm.cbFriday.Checked = true;
            mainForm.cbSunday.Checked = true;




            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    Assert.AreEqual(item.RepeatDays, "sunday,friday,wednesday,monday");
                    Assert.AreEqual(item.RepeatType, ReminderRepeatType.MULTIPLE_DAYS.ToString());

                    Assert.AreEqual(item.Note, "some note");                    
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, null);

                    DLReminders.DeleteReminder(item);
                }
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }

        [TestMethod]
        public void TestMakeReminderWorkdaysWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpDate.Value = DateTime.Now.AddDays(1);
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbWorkDays.Checked = true;





            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    Assert.AreEqual(item.RepeatType, ReminderRepeatType.WORKDAYS.ToString());
                    Assert.AreEqual(item.Date, DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                    Assert.AreEqual(item.Note, "some note");
                    Assert.AreEqual(item.RepeatDays, null);
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, null);

                    DLReminders.DeleteReminder(item);
                }
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }


        [TestMethod]
        public void TestMakeReminderDailyWithFormControls()
        {
            mainForm.cbMonthlyDays.Items.Clear();

            mainForm.tbReminderName.Text = "some reminder";
            mainForm.dtpDate.Value = DateTime.Now.AddDays(1);
            mainForm.dtpTime.Value = Convert.ToDateTime("10-10-2010 12:00:00"); //we just want the time
            mainForm.rbDaily.Checked = true;





            mainForm.tbNote.Text = "some note";
            int currentReminderCount = DLReminders.GetReminders().Count;

            //Okay, everything is done!
            mainForm.btnConfirm_Click(null, null);
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount + 1);
            Assert.AreEqual(mainForm.lvReminders.Items.Count, DLReminders.GetReminders().Count);


            //now let's remove it from the database so it doesnt get added each time the test runs. because of the way we inserted the reminder, we don't have its id.
            foreach (Reminder item in DLReminders.GetReminders())
            {
                if (item.Name == "some reminder" && item.Note == "some note")
                {
                    Assert.AreEqual(item.RepeatType, ReminderRepeatType.DAILY.ToString());
                    Assert.AreEqual(item.Date, DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");
                    Assert.AreEqual(item.Note, "some note");
                    Assert.AreEqual(item.RepeatDays, null);
                    Assert.AreEqual(item.SoundFilePath, "");
                    Assert.AreEqual(item.PostponeDate, null);
                    Assert.AreEqual(item.Enabled, 1);
                    Assert.AreEqual(item.EveryXCustom, null);

                    DLReminders.DeleteReminder(item);
                }
                    
            }
            Assert.AreEqual(DLReminders.GetReminders().Count, currentReminderCount);

        }

        [TestMethod]
        public void RemoveTests()
        {            
            DLSongs.RemoveSong(DLSongs.GetSongByFullPath(testSong.SongFilePath));
        }        
    }
}

