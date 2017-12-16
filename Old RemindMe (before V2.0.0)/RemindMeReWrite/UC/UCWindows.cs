using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;

namespace RemindMe
{
    public partial class UCWindows : UserControl
    {
        int alwaysOnTop = 1;
        public UCWindows()
        {
            InitializeComponent();
        }

        private void cbPopupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cbPopupType.SelectedItem.ToString() == "Always on top (Recommended)")
                alwaysOnTop = 1;            
            else
                alwaysOnTop = 0;

            Settings set = BLSettings.GetSettings();
            set.AlwaysOnTop = alwaysOnTop;

            BLSettings.UpdateSettings(set);            
        }

        private void UCWindows_Load(object sender, EventArgs e)
        {           
            if(BLSettings.GetSettings() == null)
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

        private void cbEnableRemindMeMessages_CheckedChanged(object sender, EventArgs e)
        {
            Settings set = BLSettings.GetSettings();

            if (cbEnableRemindMeMessages.Checked)
                set.EnableReminderCountPopup = 1;
            else
                set.EnableReminderCountPopup = 0;

            BLSettings.UpdateSettings(set);
        }

        private void cbEnableOneHourBeforeNotification_CheckedChanged(object sender, EventArgs e)
        {
            Settings set = BLSettings.GetSettings();

            if (cbEnableOneHourBeforeNotification.Checked)
                set.EnableHourBeforeReminder = 1;
            else
                set.EnableHourBeforeReminder = 0;

            BLSettings.UpdateSettings(set);
        }
    }
}
