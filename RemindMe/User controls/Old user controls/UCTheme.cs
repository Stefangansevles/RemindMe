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
            Settings set = BLLocalDatabase.Setting.Settings;
            set.MaterialDesign = 1;
            BLLocalDatabase.Setting.UpdateSettings(set);
            Application.Restart();
        }
    }
}
