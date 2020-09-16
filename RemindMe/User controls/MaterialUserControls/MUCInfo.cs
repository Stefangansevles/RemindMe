using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MUCInfo : UserControl
    {
        public MUCInfo()
        {
            InitializeComponent();

            lblVersion.Text += IOVariables.RemindMeVersion;
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.buymeacoffee.com/RemindMe");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Stefangansevles/RemindMe");
        }
    }
}
