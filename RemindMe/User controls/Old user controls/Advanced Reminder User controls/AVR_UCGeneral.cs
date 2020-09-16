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
    public partial class AVR_UCGeneral : UserControl
    {
        public AVR_UCGeneral()
        {
            InitializeComponent();
        }
        public bool ShowReminder
        {
            get { return cbShowReminder.Checked; }
            set { cbShowReminder.Checked = value; }
        }      

        private void lblShowReminder_Click(object sender, EventArgs e)
        {
            cbShowReminder.Checked = !cbShowReminder.Checked;            
        }
    }
}
