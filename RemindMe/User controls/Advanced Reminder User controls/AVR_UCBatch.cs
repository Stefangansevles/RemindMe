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
    public partial class AVR_UCBatch : UserControl
    {
        public AVR_UCBatch()
        {
            InitializeComponent();
        }
        public string BatchScript
        {
            get { return tbBatch.Text; }
            set { tbBatch.Text = value; }
        }

        private void tbBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all
                tbBatch.SelectAll();
                tbBatch.Focus();
            }
        }
    }
}
