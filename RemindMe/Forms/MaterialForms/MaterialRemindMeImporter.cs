﻿using Business_Logic_Layer;
using Database.Entity;
using Ical.Net.CalendarComponents;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MaterialRemindMeImporter : MaterialForm
    {
        //todo: maybe remove the BLIO.Log() methods since it doesnt work because a new instance of the importer is tricky that way        

        #region Dll Imports
        private const int HWND_BROADCAST = 0xFFFF;

        //tell remindme to reload reminders
        private static readonly int WM_RELOAD_REMINDERS = RegisterWindowMessage("WM_RELOAD_REMINDERS");

        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports

        private string importFile;
        private List<Reminder> remindersFromRemindMeFile = new List<Reminder>();

        private static TimeZone time = TimeZone.CurrentTimeZone;
        private static string languageCode = "";
        /// <summary>
        /// The form that allows 
        /// </summary>
        /// <param name="reminderFile"></param>
        public MaterialRemindMeImporter(string reminderFile)
        {
            BLIO.Log("Constructing RemindMeImporter");
            BLIO.Log("Form1 null: " + (Form1.Instance == null).ToString());
            BLIO.Log("Form1: " + Form1.Instance);

            
            // Initialize MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            Themes theme = BLLocalDatabase.Theme.GetThemeById(BLLocalDatabase.Setting.Settings.CurrentTheme.Value);
            if (theme != null)
            {
                Primary p = (Primary)Enum.Parse(typeof(Primary), theme.Primary.ToString());
                Primary dp = (Primary)Enum.Parse(typeof(Primary), theme.DarkPrimary.ToString());
                Primary lp = (Primary)Enum.Parse(typeof(Primary), theme.LightPrimary.ToString());
                Accent acc = (Accent)Enum.Parse(typeof(Accent), theme.Accent.ToString());
                TextShade ts = (TextShade)Enum.Parse(typeof(TextShade), theme.TextShade.ToString());


                materialSkinManager.Theme = (MaterialSkinManager.Themes)theme.Mode;
                materialSkinManager.ColorScheme = new ColorScheme(p, dp, lp, acc, ts);
            }


            //This is the only other form that you need to set this for again(after form1) because it is ran differently, namely from program.cs
            //As Application.Run() instead of loading it from the current application

            InitializeComponent();
            this.Opacity = 0;
            this.importFile = reminderFile;
            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            tmrFadeIn.Start();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            BLIO.Log("RemindMeImporter constructed");
        }

        private List<Reminder> GetSelectedRemindersFromListview()
        {
            List<long> selectedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvReminders.SelectedItems)
                selectedIds.Add((long)item.Tag);


            return remindersFromRemindMeFile.Where(r => selectedIds.Contains(r.Id)).ToList();

        }

        private List<CalendarEvent> GetSelectedCalendarEventsFromListview()
        {
            List<CalendarEvent> selectedEvents = new List<CalendarEvent>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvCalendarItems.SelectedItems)
                selectedEvents.Add((CalendarEvent)item.Tag);


            return selectedEvents;

        }

        private static bool HasFileAccess(string filePath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                {
                    BLIO.Log("HasfileAccess from RemindMeImporter returned with true");
                    return true;
                }

            }
            catch (UnauthorizedAccessException)
            {
                BLIO.Log("HasfileAccess from RemindMeImporter returned with false");
                return false;
            }
        }

 
        private void ImportReminders()
        {
            try
            {
                if (lvReminders.SelectedItems.Count > 0)
                {
                    foreach (Reminder rem in GetSelectedRemindersFromListview())
                    {
                        if (!File.Exists(rem.SoundFilePath)) //when you import reminders on another device, the path to the file might not exist. remove it.
                            rem.SoundFilePath = "";

                        BLIO.Log("Pushing reminder with id " + rem.Id + " To the database");
                        BLReminder.PushReminderToDatabase(rem);
                    }

                    //Let remindme know that the listview should be refreshed                                        
                    BLIO.Log("Sending message WM_RELOAD_REMINDERS ....");
                    PostMessage((IntPtr)HWND_BROADCAST, WM_RELOAD_REMINDERS, new IntPtr(0xCDCD), new IntPtr(0xEFEF));
                    this.Close();
                }
                else
                {
                    MaterialMessageFormManager.MakeMessagePopup("Please select at least one reminder.", 3);
                }

            }
            catch (Exception ex)
            {
                MaterialExceptionPopup pop = new MaterialExceptionPopup(ex, "Error inserting reminders");
                pop.Show();
                BLIO.WriteError(ex, "Error inserting reminders");
            }
        }

        private void ImportCalendarItems()
        {
            try
            {
                if (lvCalendarItems.SelectedItems.Count > 0)
                {
                    foreach (CalendarEvent cal in GetSelectedCalendarEventsFromListview())
                    {
                        DateTime date = new DateTime(cal.DtStart.Year, cal.DtStart.Month, cal.DtStart.Day, cal.DtStart.Hour, cal.DtStart.Minute, cal.DtStart.Second);
                        long id = BLReminder.InsertReminder(cal.Summary, date.ToString(), ReminderRepeatType.NONE.ToString(), null, "", cal.Description, true, "");                                                
                        BLIO.Log("Pushing reminder with id " + id + " To the database");
                    }

                    //Let remindme know that the listview should be refreshed                                        
                    BLIO.Log("Sending message WM_RELOAD_REMINDERS ....");
                    PostMessage((IntPtr)HWND_BROADCAST, WM_RELOAD_REMINDERS, new IntPtr(0xCDCD), new IntPtr(0xEFEF));
                    this.Close();
                }
                else
                {
                    MaterialMessageFormManager.MakeMessagePopup("Please select at least one event.", 3);
                }

            }
            catch (Exception ex)
            {
                MaterialExceptionPopup pop = new MaterialExceptionPopup(ex, "Error inserting calendar events " + ex.ToString());
                pop.Show();
                BLIO.WriteError(ex, "Error inserting calendar events");
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {            
            if(pnlCalendarEvent.Visible)
            {
                ImportCalendarItems();
                return;
            }                          
            ImportReminders();          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void RemindMeImporter_Load(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("RemindmeImporter_load");
                this.MaximumSize = this.Size;


                if (!HasFileAccess(this.importFile)) //Do not attempt to launch the importer form if we can't open the file
                {
                    BLIO.Log("Error opening .remindme file, no rights");
                    MaterialRemindMeBox.Show($"Can not open this {Path.GetExtension(this.importFile)} file from " + Path.GetDirectoryName(this.importFile) + ". Insufficient rights.", RemindMeBoxReason.OK);
                    this.Close();
                }
                else
                {
                    try
                    {
                        if (Path.GetExtension(this.importFile) == ".ics")
                        {
                            this.Text = "Import calendar event";
                            lvReminders.Visible = false;
                            pnlCalendarEvent.Visible = true;

                            string contents = System.IO.File.ReadAllText(this.importFile);
                            Ical.Net.Calendar calendar = Ical.Net.Calendar.Load(contents);
                            for (int i = 0; i < calendar.Events.Count; i++)
                            {
                                ListViewItem lvi;
                                lvi = calendar.Events[i].Summary.Length > 30 ? new ListViewItem(calendar.Events[i].Summary.Substring(0, 30) + "...")
                                    : lvi = new ListViewItem(calendar.Events[i].Summary);

                                DateTime date = new DateTime(calendar.Events[i].DtStart.Year, calendar.Events[i].DtStart.Month, calendar.Events[i].DtStart.Day, calendar.Events[i].DtStart.Hour, calendar.Events[i].DtStart.Minute, calendar.Events[i].DtStart.Second);
                                lvi.SubItems.Add(date.ToString());
                                lvi.Tag = calendar.Events[i];
                                lvCalendarItems.Items.Add(lvi);
                            }
                            lvCalendarItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                        else
                        {
                            BLIO.Log("Deserializing reminders.....");
                            List<object> deSerializedReminders = BLReminder.DeserializeRemindersFromFile(importFile);
                            BLIO.Log(deSerializedReminders.Count - 1 + " reminders deserialized!");
                            this.Text += " (" + (deSerializedReminders.Count - 1) + " Reminders)"; //-1 because of country code
                            foreach (object rem in deSerializedReminders)
                            {
                                if (rem.GetType() == typeof(Reminder))
                                {
                                    Reminder reminder = (Reminder)rem;
                                    BLIO.Log(reminder.Name + " Loaded into RemindMeImporter from the .remindme file.");
                                    remindersFromRemindMeFile.Add((Reminder)rem);
                                }
                                else
                                {
                                    BLIO.Log("Language code" + languageCode + " read from the .remindme file!");
                                    languageCode = rem.ToString(); //The language code stored in the .remindme file, "en-Us" for example
                                }
                            }

                            if (languageCode != "") //Don't need to do this when exporting.
                            {
                                BLIO.Log("Going through the reminder list once more....");
                                foreach (object rem in remindersFromRemindMeFile)
                                {
                                    if (rem.GetType() == typeof(Reminder))
                                    {
                                        Reminder remm = (Reminder)rem;
                                        //Fix the date if the .remindme file has a different time format than the current system
                                        BLIO.Log("(" + remm.Name + ") Fixing the date to match the language code " + languageCode);
                                        remm.Date = BLDateTime.ConvertDateTimeStringToCurrentCulture(remm.Date, languageCode);
                                    }
                                }
                            }

                            if (remindersFromRemindMeFile != null)
                            {
                                BLIO.Log("Adding the reminders from the .remindme file to the listview....");
                                BLFormLogic.AddRemindersToListview(lvReminders, remindersFromRemindMeFile, true);
                                BLIO.Log("Done!");
                            }
                            else
                            {
                                BLIO.Log("Failed to load reminders.");
                                this.Text = "Failed to load reminders.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MaterialRemindMeBox.Show("Something has gone wrong loading reminders from this .remindme file.\r\nThe file might be corrupt", RemindMeBoxReason.OK);
                        BLIO.Log("Error loading reminders from .remindme file written to error log");
                        BLIO.WriteError(ex, "Error loading reminders from .remindme file");
                        Application.Exit();
                    }
                }
                BLIO.Log("RemindmeImporter loaded !");
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "RemindMeImporter_Load failed!");
            }
        }

        private void lvReminders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                foreach (ListViewItem item in lvReminders.Items)
                    item.Selected = true;
            }
        }


        private void tmrFadeIn_Tick_1(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        private void MaterialRemindMeImporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialSkinManager.Instance.RemoveFormToManage(this);
        }

        private void lvCalendarItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblItemsSelected.Text = $"{lvCalendarItems.SelectedItems.Count} Items selected";
            lblItemsSelected.Visible = lvCalendarItems.SelectedItems.Count > 0;
        }

        private void lvReminders_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblItemsSelected.Text = $"{lvReminders.SelectedItems.Count} Reminders selected";
            lblItemsSelected.Visible = lvReminders.SelectedItems.Count > 0;            
        }
    }
}
