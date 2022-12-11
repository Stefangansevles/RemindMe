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

namespace RemindMe
{
    public partial class MUCSettings : UserControl
    {
        private string popupType = "AlwaysOnTop";        

        //The stop playing preview sound icon
        Image imgStop;
        //The start playing preview sound icon
        Image imgPlayResume;

        public MUCSettings()
        {
            InitializeComponent();            
            imgStop = Properties.Resources.Stop;
            imgPlayResume = Properties.Resources.Play;
        }
        

        private void cbEnableRemindMeMessages_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("cbEnableRemindMeMessages_OnChange");
            Settings set = BLLocalDatabase.Setting.Settings;

            if (cbRemindMeMessages.Checked)
                set.EnableReminderCountPopup = 1;
            else
                set.EnableReminderCountPopup = 0;


            BLLocalDatabase.Setting.UpdateSettings(set);
            BLIO.Log("Today's reminder popup setting changed to: " + cbRemindMeMessages.Checked.ToString());
        }

        private void cbEnableOneHourBeforeNotification_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("cbEnableOneHourBeforeNotification_OnChange");
            Settings set = BLLocalDatabase.Setting.Settings;

            if (cbOneHourBeforeNotification.Checked)
                set.EnableHourBeforeReminder = 1;
            else
                set.EnableHourBeforeReminder = 0;

            BLLocalDatabase.Setting.UpdateSettings(set);
            BLIO.Log("1 hour before reminder setting changed to: " + cbOneHourBeforeNotification.Checked.ToString());
        }

        private void UCWindowOverlay_Load(object sender, EventArgs e)
        {
            if (BLLocalDatabase.Setting.Settings == null)
            {
                Settings set = new Settings();
                set.PopupType = popupType;
                set.StickyForm = 0;
                set.EnableHourBeforeReminder = 1;
                set.EnableReminderCountPopup = 1;
                set.EnableQuickTimer = 1;
                set.CurrentTheme = -1;                
                set.AutoUpdate = 1;
                set.TimerVolume = 100;
                BLLocalDatabase.Setting.UpdateSettings(set);
            }
            
            if (BLLocalDatabase.Setting.Settings.PopupType == "AlwaysOnTop")
                cbPopupType.SelectedItem = cbPopupType.Items[0];
            else if (BLLocalDatabase.Setting.Settings.PopupType == "Minimized")
                cbPopupType.SelectedItem = cbPopupType.Items[1];
            else if(BLLocalDatabase.Setting.Settings.PopupType == "SoundOnly") 
                cbPopupType.SelectedItem = cbPopupType.Items[2];            

            cbRemindMeMessages.Checked = BLLocalDatabase.Setting.IsReminderCountPopupEnabled();
            cbOneHourBeforeNotification.Checked = BLLocalDatabase.Setting.IsHourBeforeNotificationEnabled();
            cbQuicktimer.Checked = BLLocalDatabase.Setting.Settings.EnableQuickTimer == 1;
            cbAdvancedReminders.Checked = BLLocalDatabase.Setting.Settings.EnableAdvancedReminders == 1;
            cbAutoUpdate.Checked = BLLocalDatabase.Setting.Settings.AutoUpdate == 1;

            Hotkeys timerKey = BLLocalDatabase.Hotkey.TimerPopup;
            Hotkeys timerCheck = BLLocalDatabase.Hotkey.TimerCheck;
            foreach (string m in timerKey.Modifiers.Split(','))
                tbTimerHotkey.Text += m + " + ";
            tbTimerHotkey.Text += timerKey.Key;

            foreach (string m in timerCheck.Modifiers.Split(','))
                tbCheckTimerHotKey.Text += m + " + ";
            tbCheckTimerHotKey.Text += timerCheck.Key;

            //Fill the combobox to select a timer popup sound with data
            FillSoundCombobox();
            //Set the item the user selected as text           
            string def = BLLocalDatabase.Setting.Settings.DefaultTimerSound;
            if (def == null) //User has no default sound combobox
            {
                foreach (ComboBoxItem itm in cbSound.Items)
                {
                    if (itm.Text.ToLower().Contains("unlock")) //Set the default timer sound to windows unlock 
                    {
                        Songs sng = (Songs)itm.Value;
                        Settings set = BLLocalDatabase.Setting.Settings;
                        set.DefaultTimerSound = sng.SongFilePath;
                        BLLocalDatabase.Setting.UpdateSettings(set);
                    }
                }
            }
            if (BLLocalDatabase.Setting.Settings.DefaultTimerSound == null)//Still null? well damn.
                return;

            cbSound.Items.Add(new ComboBoxItem(Path.GetFileNameWithoutExtension(BLLocalDatabase.Setting.Settings.DefaultTimerSound), BLLocalDatabase.Song.GetSongByFullPath(BLLocalDatabase.Setting.Settings.DefaultTimerSound)));
            cbSound.Text = Path.GetFileNameWithoutExtension(BLLocalDatabase.Setting.Settings.DefaultTimerSound);


            trbVolume.Refresh();
            trbVolume.Value = (int)BLLocalDatabase.Setting.Settings.TimerVolume;
            //Because for some reason it doesn't trigger it onload due to FileNotFound exception ?? #JustBunifuThings..
            trbVolume_ValueChanged(sender,e);
            refreshTrackbars();
        }

        /// <summary>
        /// Bunifu trackbar looks good but is a bit buggy, invalidating it kinda fixes it
        /// </summary>
        private void refreshTrackbars()
        {
            trbVolume.IndicatorColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor;            

            trbVolume.BackgroudColor = Color.DarkGray;            

            trbVolume.Invalidate();            
        }

        private void cbPopupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbPopupType.SelectedItem.ToString())
            {
                case "Always on top (Recommended)":
                    popupType = "AlwaysOnTop";
                    break;
                case "Minimized":
                    popupType = "Minimized";
                    break;
                case "Sound Only":
                    popupType = "SoundOnly";
                    break;
            }

            Settings set = BLLocalDatabase.Setting.Settings;
            set.PopupType = popupType;

            BLLocalDatabase.Setting.UpdateSettings(set);
            BLIO.Log("Updated popup type.");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            cbRemindMeMessages.Checked = !cbRemindMeMessages.Checked;
            cbEnableRemindMeMessages_OnChange(sender, e);
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

            BLIO.Log("tbTimerHotKey legal key combination pressed.");


            tbTimerHotkey.Text = "";

            foreach (string m in e.Modifiers.ToString().Split(','))
            {
                tbTimerHotkey.Text += m + " + ";
            }
            tbTimerHotkey.Text += e.KeyCode.ToString();

            BLIO.Log("tbTimerHotKey key combination: " + tbTimerHotkey.Text);
            //Get the current key combination for the Timer popup
            Hotkeys timerKey = BLLocalDatabase.Hotkey.TimerPopup;
            timerKey.Key = e.KeyCode.ToString();                                   //Set the new key
            timerKey.Modifiers = e.Modifiers.ToString().Replace(" ", string.Empty); //Set the new modifier(remove whitespace)
            BLLocalDatabase.Hotkey.TimerPopup = timerKey;                                       //Assign the value
            BLIO.Log("timerKey.Key=" + timerKey.Key + "   timerKey.Modifiers=" + timerKey.Modifiers);
        }

        public void FillSoundCombobox()
        {
            //Fill the list with all the sounds from the Database(non default windows ones)
            List<Songs> sounds = BLLocalDatabase.Song.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

            cbSound.Items.Clear();
            ComboBoxItemManager.ClearComboboxItems();

            if (sounds != null)
                foreach (Songs item in sounds)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));

            //Let's make sure the default windows System sounds are placed at the bottom
            List<Songs> windowsDefaultSongs = BLLocalDatabase.Song.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() == "c:\\windows\\media").OrderBy(s => s.SongFileName).ToList();

            if (windowsDefaultSongs != null)
                foreach (Songs item in windowsDefaultSongs)
                    if (item.SongFileName != "")
                        cbSound.Items.Add(new ComboBoxItem(System.IO.Path.GetFileNameWithoutExtension(item.SongFileName), item));
        }

        private void cbEnableQuicktimer_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("cbEnableQuicktimer_OnChange");
            Settings set = BLLocalDatabase.Setting.Settings;

            set.EnableQuickTimer = cbQuicktimer.Checked ? 1 : 0;

            BLLocalDatabase.Setting.UpdateSettings(set);
            BLIO.Log("Quick timer setting changed to: " + cbQuicktimer.Checked.ToString());
        }

        private void label10_Click(object sender, EventArgs e)
        {
            cbQuicktimer.Checked = !cbQuicktimer.Checked;
            cbEnableQuicktimer_OnChange(sender, e);
        }

        private void cbAdvancedReminders_OnChange(object sender, EventArgs e)
        {
            BLIO.Log("cbAdvancedReminders_OnChange");
            Settings set = BLLocalDatabase.Setting.Settings;

            set.EnableAdvancedReminders = cbAdvancedReminders.Checked ? 1 : 0;

            BLLocalDatabase.Setting.UpdateSettings(set);
            BLIO.Log("Advanced Reminder setting changed to: " + cbAdvancedReminders.Checked.ToString());

            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            cbAdvancedReminders.Checked = !cbAdvancedReminders.Checked;
            cbAdvancedReminders_OnChange(sender, e);
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCSetings)btnRemoveSong_Click");
            cbSound.SelectedItem = null;
            cbSound.Text = "";
            Settings set = BLLocalDatabase.Setting.Settings;
            set.DefaultTimerSound = "";
            BLLocalDatabase.Setting.UpdateSettings(set);
        }

        private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem != null)
            {
                Songs selectedSong = (Songs)selectedItem.Value;
                if (selectedSong != null)
                {
                    Settings set = BLLocalDatabase.Setting.Settings;
                    set.DefaultTimerSound = selectedSong.SongFilePath;
                    BLLocalDatabase.Setting.UpdateSettings(set);
                }
            }
        }

        private void btnPreviewSong_Click(object sender, EventArgs e)
        {
            BLIO.Log("(UCSetings)btnPreviewSong_Click");
            ComboBoxItem selectedItem = (ComboBoxItem)cbSound.SelectedItem;
            if (selectedItem == null)
                return;

            Songs selectedSong = (Songs)selectedItem.Value;
            if (selectedSong == null)
                return;

            //Stop the song
            if (btnPreviewSong.Icon == imgStop)
            {
                btnPreviewSong.Icon = imgPlayResume;
                BLIO.StopSound();
                tmrMusic.Stop();
                return;
            }

            //Does the file we're trying to play REALLY exist?
            if (File.Exists(selectedSong.SongFilePath))
            {
                BLIO.Log("selected sound file exists on hard drive (MUCSettings)");
                //Set the image to "Stop", since we're going to play a song. Give the user the option to stop it                

                int duration = BLIO.PlaySound(selectedSong.SongFilePath, trbVolume.Value);
                if (duration == -1)
                {
                    MaterialMessageFormManager.MakeMessagePopup($"Could not preview the selected song. This type of file({Path.GetExtension(selectedSong.SongFilePath)}) is not supported.", 4);
                    return;
                }

                btnPreviewSong.Icon = imgStop;
                tmrMusic.Interval = duration;
                tmrMusic.Start();                
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPreviewSong.Icon = imgPlayResume;
            tmrMusic.Stop();
        }

        private void MUCSettings_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                BLIO.Log("Control MUCSettings now visible");

            refreshTrackbars();
        }

        private void tbCheckTimerHotKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt) //None of the key key's (get it?) pressed? return.
                return;

            //Good! now let's check if the KeyCode is not alt shift or ctr
            if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
                return;

            BLIO.Log("tbCheckTimerHotKey legal key combination pressed.");


            tbCheckTimerHotKey.Text = "";

            foreach (string m in e.Modifiers.ToString().Split(','))
            {
                tbCheckTimerHotKey.Text += m + " + ";
            }
            tbCheckTimerHotKey.Text += e.KeyCode.ToString();

            BLIO.Log("tbCheckTimerHotKey key combination: " + tbCheckTimerHotKey.Text);

            //Get the current key combination for the Timer popup
            Hotkeys timerCheckKey = BLLocalDatabase.Hotkey.TimerCheck;
            timerCheckKey.Key = e.KeyCode.ToString();                                   //Set the new key
            timerCheckKey.Modifiers = e.Modifiers.ToString().Replace(" ", string.Empty); //Set the new modifier(remove whitespace)
            BLLocalDatabase.Hotkey.TimerCheck = timerCheckKey;                                       //Assign the value
            BLIO.Log("TimerCheck.Key=" + timerCheckKey.Key + "   TimerCheck.Modifiers=" + timerCheckKey.Modifiers);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            foreach (Control b in Form1.Instance.pnlSide.Controls)
                if (b is Bunifu.Framework.UI.BunifuFlatButton && b.Text[0] == ' ')
                    b.Text = b.Text.Substring(1, b.Text.Length - 1);


            ButtonSpaces btn = new ButtonSpaces();
            btn.Id = 0;
            btn.Reminders = SpacesInFront(Form1.Instance.btnReminders);

            BLLocalDatabase.ButtonSpacing.UpdateButtonSpacing(btn);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            foreach (Control b in Form1.Instance.pnlSide.Controls)
                if (b is Bunifu.Framework.UI.BunifuFlatButton && SpacesInFront((Bunifu.Framework.UI.BunifuFlatButton)b) < 15)
                    b.Text = " " + b.Text;

            ButtonSpaces btn = new ButtonSpaces();
            btn.Id = 0;
            btn.Reminders = SpacesInFront(Form1.Instance.btnReminders);

            BLLocalDatabase.ButtonSpacing.UpdateButtonSpacing(btn);
        }

        //Get the amount of spaces in front of the text of the button used in btnPlus_click
        private int SpacesInFront(Bunifu.Framework.UI.BunifuFlatButton b)
        {
            for (int i = 0; i < b.Text.Length - 1; i++)
            {
                if (b.Text[i] != ' ')
                    return i;
            }
            return -1;
        }

        private void cbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Settings set = BLLocalDatabase.Setting.Settings;

            if (!cbAutoUpdate.Checked)
            {
                if (MaterialRemindMeBox.Show("Attention!", "Are you sure you want to disable auto-update? Newer versions of RemindMe will contain new features and/or fixes to problems in previous versions\r\n\r\nIt is recommended to keep this feature on!", RemindMeBoxReason.YesNo) == DialogResult.Yes)
                {
                    //ask for confirmation
                    set.AutoUpdate = 0;
                    MaterialForm1.Instance.tmrUpdateRemindMe.Stop();
                }
                else
                {
                    cbAutoUpdate.Checked = true;
                }
            }
            else
            {
                set.AutoUpdate = cbAutoUpdate.Checked ? 1 : 0;
                MaterialForm1.Instance.tmrUpdateRemindMe.Start();
            }

            BLLocalDatabase.Setting.UpdateSettings(set);
        }

        private void cbAdvancedReminders_Click(object sender, EventArgs e)
        {
            if (cbAdvancedReminders.Checked)
                MaterialRemindMeBox.Show("You now have access to advanced reminders.\r\nA new button has appeared at the top-right corner when creating/editing reminders.");
        }

        private void trbVolume_ValueChanged(object sender, EventArgs e)
        {
            tmrSaveTimerVolume.Stop();

            lblVolume.Text = "Timer volume: " + trbVolume.Value + "%";
            trbVolume.Invalidate();

            tmrSaveTimerVolume.Start();
        }

        private void tmrSaveTimerVolume_Tick(object sender, EventArgs e)
        {
            Settings set = BLLocalDatabase.Setting.Settings;
            set.TimerVolume = trbVolume.Value;
            BLLocalDatabase.Setting.UpdateSettings(set);

            tmrSaveTimerVolume.Stop();            
        }
    }
}
