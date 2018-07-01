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

namespace RemindMe
{
    public partial class UCWindowOverlay : UserControl
    {
        private int alwaysOnTop = 1;
        public UCWindowOverlay()
        {
            InitializeComponent();
        }

        private void cbEnableRemindMeMessages_OnChange(object sender, EventArgs e)
        {
            Settings set = BLSettings.GetSettings();

            if (cbEnableRemindMeMessages.Checked)
                set.EnableReminderCountPopup = 1;
            else
                set.EnableReminderCountPopup = 0;

            
            BLSettings.UpdateSettings(set);
            BLIO.Log("Today's reminder popup setting changed to: " + cbEnableRemindMeMessages.Checked.ToString());
        }

        private void cbEnableOneHourBeforeNotification_OnChange(object sender, EventArgs e)
        {
            Settings set = BLSettings.GetSettings();

            if (cbEnableOneHourBeforeNotification.Checked)
                set.EnableHourBeforeReminder = 1;
            else
                set.EnableHourBeforeReminder = 0;

            BLSettings.UpdateSettings(set);
            BLIO.Log("1 hour before reminder setting changed to: " + cbEnableOneHourBeforeNotification.Checked.ToString());
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
                BLSettings.UpdateSettings(set);
            }

            //Since we're not going to change the contents of this combobox anyway, we're just going to do it like this
            if (BLSettings.IsAlwaysOnTop())
                cbPopupType.SelectedItem = cbPopupType.Items[0];
            else
                cbPopupType.SelectedItem = cbPopupType.Items[1];

            cbEnableRemindMeMessages.Checked = BLSettings.IsReminderCountPopupEnabled();
            cbEnableOneHourBeforeNotification.Checked = BLSettings.IsHourBeforeNotificationEnabled();
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
            cbEnableRemindMeMessages.Checked = !cbEnableRemindMeMessages.Checked;
            cbEnableRemindMeMessages_OnChange(sender,e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            cbEnableOneHourBeforeNotification.Checked = !cbEnableOneHourBeforeNotification.Checked;
            cbEnableOneHourBeforeNotification_OnChange(sender, e);
        }
    }
}
