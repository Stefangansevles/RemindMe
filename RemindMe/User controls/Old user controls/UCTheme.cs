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
    public partial class UCTheme : UserControl
    {
        public UCTheme()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool doRestart = true;

            if(UCTimer.RunningTimers.Count > 0)            
                if (RemindMeBox.Show("You have (" + UCTimer.RunningTimers.Count + ") active timers running.\r\n\r\nAre you sure you wish to close RemindMe? These timers will not be saved", RemindMeBoxReason.YesNo) == DialogResult.No)                
                    doRestart = false;

            if (doRestart)
            {
                Settings set = BLLocalDatabase.Setting.Settings;
                set.MaterialDesign = 1;
                BLLocalDatabase.Setting.UpdateSettings(set);


                UCTimer.RunningTimers.Clear();
                Application.Restart();
            }
        }
    }
}
