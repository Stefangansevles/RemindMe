using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemindMe;
using Business_Logic_Layer;

namespace Import
{
    public partial class Form1 : Form
    {
        private string reminderFile;
        public Form1(string reminderFile)
        {
            InitializeComponent();
            this.reminderFile = reminderFile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlImportedReminders.Controls.Clear();
            pnlImportedReminders.Controls.Add(new UCImportedReminders(BLIO.ReadRemindersFromFile(reminderFile)));
        }
    }
}
