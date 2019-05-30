using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Database.Entity;
using System.IO;
using WMPLib;

namespace RemindMe
{
    public partial class UCSettings : UserControl
    {
        private int alwaysOnTop = 1;

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        //The stop playing preview sound icon
        Image imgStop;    
        //The start playing preview sound icon
        Image imgPlayResume;

        public UCSettings()
        {
            InitializeComponent();

            imgStop = Properties.Resources.Stop;
            imgPlayResume = Properties.Resources.Play;
        }

        private void cbEnableRemindMeMessages_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("Checkbox change (todays reminder popup)");
            Settings set = BLSettings.GetSettings();

            if (cbRemindMeMessages.Checked)
                set.EnableReminderCountPopup = 1;
            else
                set.EnableReminderCountPopup = 0;

            
            BLSettings.UpdateSettings(set);
            BLIO.Log("Today's reminder popup setting changed to: " + cbRemindMeMessages.Checked.ToString());
        }

        private void cbEnableOneHourBeforeNotification_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("Checkbox change (Enable 1h before)");
            Settings set = BLSettings.GetSettings();

            if (cbOneHourBeforeNotification.Checked)
                set.EnableHourBeforeReminder = 1;
            else
                set.EnableHourBeforeReminder = 0;

            BLSettings.UpdateSettings(set);
            BLIO.Log("1 hour before reminder setting changed to: " + cbOneHourBeforeNotification.Checked.ToString());
        }

        private void UCWindowOverlay_Load(object sender, EventArgs e)
        {
            if (BLSettings.GetSettings() == null)
            {
                Settings set = new Settings();
                set.AlwaysOnTop = alwaysOnTop;
                set.StickyForm = 0;
                set.EnableHourBeforeReminder = 1;
                set.EnableReminderCountPopup = 1;
                set.EnableQuickTimer = 1;
                BLSettings.UpdateSettings(set);
            }

            //Since we're not going to change the contents of this combobox anyway, we're just going to do it like this
            if (BLSettings.IsAlwaysOnTop())
                cbPopupType.SelectedItem = cbPopupType.Items[0];
            else
                cbPopupType.SelectedItem = cbPopupType.Items[1];

            cbRemindMeMessages.Checked = BLSettings.IsReminderCountPopupEnabled();
            cbOneHourBeforeNotification.Checked = BLSettings.IsHourBeforeNotificationEnabled();
            cbQuicktimer.Checked = BLSettings.GetSettings().EnableQuickTimer == 1;
            cbAdvancedReminders.Checked = BLSettings.GetSettings().EnableAdvancedReminders == 1;

            Hotkeys timerKey = BLHotkeys.TimerPopup;
            foreach(string m in timerKey.Modifiers.Split(','))
            {
                tbTimerHotkey.Text += m + " + ";
            }
            tbTimerHotkey.Text += timerKey.Key;

            //Fill the combobox to select a timer popup sound with data
            FillSoundCombobox();
            //Set the item the user selected as text           
            
            cbSound.Items.Add(new ComboBoxItem(Path.GetFileNameWithoutExtension(BLSettings.GetSettings().DefaultTimerSound), BLSongs.GetSongByFullPath(BLSettings.GetSettings().DefaultTimerSound)));
            cbSound.Text = Path.GetFileNameWithoutExtension(BLSettings.GetSettings().DefaultTimerSound);
        }

        private void cbPopupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbPopupType.SelectedItem.ToString() == "Always on top (Recommended)")
            {
                alwaysOnTop = 1;
                BLIO.Log("Popup type selected index changed to always on top.");
            }
            else
            {
                alwaysOnTop = 0;
                BLIO.Log("Popup type selected index changed to minimized.");
            }

            Settings set = BLSettings.GetSettings();
            set.AlwaysOnTop = alwaysOnTop;

            BLSettings.UpdateSettings(set);
            BLIO.Log("Updated popup type.");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            cbRemindMeMessages.Checked = !cbRemindMeMessages.Checked;
            cbEnableRemindMeMessages_OnChange(sender,e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            cbOneHourBeforeNotification.Checked = !cbOneHourBeforeNotification.Checked;
            cbEnableOneHourBeforeNotification_OnChange(sender, e);
        }

        private void tbTimerHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt) //None of the key key's (get it?) pressed? return.
                return;

            //Good! now let's check if the KeyCode is not alt shift or ctr
            if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
                return;


            tbTimerHotkey.Text = "";            

            foreach(string m in e.Modifiers.ToString().Split(','))
            {
                tbTimerHotkey.Text += m + " + ";
            }
            tbTimerHotkey.Text += e.KeyCode.ToString();

                                                                                   //Get the current key combination for the Timer popup
            Hotkeys timerKey = BLHotkeys.TimerPopup;            
            timerKey.Key = e.KeyCode.ToString();                                   //Set the new key
            timerKey.Modifiers = e.Modifiers.ToString().Replace(" ", string.Empty); //Set the new modifier(remove whitespace)
            BLHotkeys.TimerPopup = timerKey;                                       //Assign the value

        }

        private void FillSoundCombobox()
        {
            //Fill the list with all the sounds from the Database(non default windows ones)
            List<Songs> sounds = BLSongs.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

            cbSound.Items.Clear();
            ComboBoxItemManager.ClearComboboxItems();

            if (sounds != null)
                foreach (Songs item in sounds)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));

            //Let's make sure the default windows System sounds are placed at the bottom
            List<Songs> windowsDefaultSongs = BLSongs.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() == "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

            if (windowsDefaultSongs != null)
                foreach (Songs item in windowsDefaultSongs)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));
        }

        private void cbEnableQuicktimer_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("Checkbox change (Quick timer)");
            Settings set = BLSettings.GetSettings();

            set.EnableQuickTimer = cbQuicktimer.Checked ? 1 : 0;

            BLSettings.UpdateSettings(set);
            BLIO.Log("Quick timer setting changed to: " + cbQuicktimer.Checked.ToString());
        }

        private void label10_Click(object sender, EventArgs e)
        {
            cbQuicktimer.Checked = !cbQuicktimer.Checked;
            cbEnableQuicktimer_OnChange(sender, e);
        }

        private void cbAdvancedReminders_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("Checkbox change (Advanced Reminder)");
            Settings set = BLSettings.GetSettings();

            set.EnableAdvancedReminders = cbAdvancedReminders.Checked ? 1 : 0;

            BLSettings.UpdateSettings(set);
            BLIO.Log("Advanced Reminder setting changed to: " + cbAdvancedReminders.Checked.ToString());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            cbAdvancedReminders.Checked = !cbAdvancedReminders.Checked;
            cbAdvancedReminders_OnChange(sender, e);
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            cbSound.SelectedItem = null;
            cbSound.Text = "";
            Settings set = BLSettings.GetSettings();
            set.DefaultTimerSound = "";
            BLSettings.UpdateSettings(set);
        }

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem != null)
            {
                Songs selectedSong = (Songs)selectedItem.Value;
                Settings set = BLSettings.GetSettings();
                set.DefaultTimerSound = selectedSong.SongFilePath;
                BLSettings.UpdateSettings(set);
            }
        }

        private void btnPreviewSong_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem == null)
                return;

            Songs selectedSong = (Songs)selectedItem.Value;
            if (selectedSong == null)
                return;

            //Stop the song
            if(btnPreviewSong.Image == imgStop)
            {
                btnPreviewSong.Image = imgPlayResume;
                myPlayer.controls.stop();
                tmrMusic.Stop();
                return;
            }

            //Does the file we're trying to play REALLY exist?
            if (File.Exists(selectedSong.SongFilePath))
            {
                BLIO.Log("selected sound file exists on hard drive (UCsettings)");
                //Set the image to "Stop", since we're going to play a song. Give the user the option to stop it
                btnPreviewSong.Image = imgStop;

                //Give the player the path to the file
                myPlayer.URL = selectedSong.SongFilePath;
                //Get media info so we know when the song ends
                mediaInfo = myPlayer.newMedia(myPlayer.URL);

                //Start the timer. the timer ticks when the song ends. The timer will then reset the picture of the play button                        
                if (mediaInfo.duration > 0)
                    tmrMusic.Interval = (int)(mediaInfo.duration * 1000);
                else
                    tmrMusic.Interval = 1000;
                tmrMusic.Start();

                BLIO.Log("Playing sound... (UCsettings)");
                myPlayer.controls.play();
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPreviewSong.Image = imgPlayResume;
            tmrMusic.Stop();
        }
    }
}
