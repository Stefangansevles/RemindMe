using Business_Logic_Layer;
using Database.Entity;
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
    public partial class RemindMeImporter : Form
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

        private string remindmeFile;
        private List<Reminder> remindersFromRemindMeFile = new List<Reminder>();

        private static TimeZone time = TimeZone.CurrentTimeZone;
        private static string languageCode = "";
        /// <summary>
        /// The form that allows 
        /// </summary>
        /// <param name="reminderFile"></param>
        public RemindMeImporter(string reminderFile)
        {
            BLIO.Log("Constructing RemindMeImporter");
            InitializeComponent();
            this.Opacity = 0;
            this.remindmeFile = reminderFile;
            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            tmrFadeIn.Start();
            BLIO.Log("RemindMeImporter constructed");
        }

        private List<Reminder> GetSelectedRemindersFromListview()
        {
            List<long> selectedIds = new List<long>(); //get all selected id's from the listview reminders
            foreach (ListViewItem item in lvReminders.CheckedItems)
                selectedIds.Add((long)item.Tag);


            return remindersFromRemindMeFile.Where(r => selectedIds.Contains(r.Id)).ToList();

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
            catch (UnauthorizedAccessException ex)
            {
                BLIO.Log("HasfileAccess from RemindMeImporter returned with false");
                return false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {                
                if (lvReminders.CheckedItems.Count > 0)
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
                    MessageFormManager.MakeMessagePopup("Please select at least one reminder.", 3);
                }

            }
            catch (Exception ex)
            {
                ErrorPopup pop = new ErrorPopup("Error inserting reminders", ex);
                pop.Show();
                BLIO.WriteError(ex, "Error inserting reminders");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void RemindMeImporter_Load(object sender, EventArgs e)
        {
            BLIO.Log("RemindmeImporter_load");
            this.MaximumSize = this.Size;


            if (!HasFileAccess(this.remindmeFile)) //Do not attempt to launch the importer form if we can't open the file
            {
                BLIO.Log("Error opening .remindme file, no rights");
                RemindMeBox.Show("Can not open this .remindme file from " + Path.GetDirectoryName(this.remindmeFile) + ". Insufficient rights.", RemindMeBoxReason.OK);
                this.Close();
            }
            else
            {
                try
                {
                    BLIO.Log("Deserializing reminders.....");
                    List<object> deSerializedReminders = BLReminder.DeserializeRemindersFromFile(remindmeFile);
                    BLIO.Log(deSerializedReminders.Count-1 + " reminders deserialized!");
                    lblAmountOfReminders.Text = deSerializedReminders.Count - 1 + " Reminders"; //-1 because of country code
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
                        BLFormLogic.AddRemindersToListview(lvReminders, remindersFromRemindMeFile);
                        BLIO.Log("Done!");
                    }
                    else
                    {
                        BLIO.Log("Failed to load reminders.");
                        lblTitle.Text = "Failed to load reminders.";
                    }
                }
                catch (Exception ex)
                {
                    RemindMeBox.Show("Something has gone wrong loading reminders from this .remindme file.\r\nThe file might be corrupt", RemindMeBoxReason.OK);
                    BLIO.Log("Error loading reminders from .remindme file written to error log");
                    BLIO.WriteError(ex, "Error loading reminders from .remindme file");
                    Application.Exit();
                }
            }
            BLIO.Log("RemindmeImporter loaded !");
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
    }
}
