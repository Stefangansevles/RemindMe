using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class RemindMePrompt : Form
    {
        static int intResult;
        static string stringResult;
        static RemindMePrompt newPrompt;

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }





        /// <summary>
        /// Shows a prompt where the user can enter a string
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <returns></returns>
        public static string Show(string title)
        {
            newPrompt = new RemindMePrompt(title);
            newPrompt.ShowDialog();
            return stringResult;
        }

        /// <summary>
        /// Shows a prompt where the user can enter a number
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <param name="maxValue">The maximum number the user can enter. 0 = unlimited (int.MaxValue)</param>
        /// <returns></returns>
        public static int Show(string title, int maxValue)
        {
            newPrompt = new RemindMePrompt(title, maxValue);
            newPrompt.ShowDialog();
            return intResult;
        }

        private RemindMePrompt(string title)
        {
            InitializeComponent();
            pbCloseApplication.BringToFront();
            BLFormLogic.RemovebuttonBorders(btnOk);
            label1.Text = title;
            this.MaximumSize = this.Size;

            tbInput.Visible = true;
            pnlNumericPrompt.Visible = false;

            //Set the location within the remindme window. 
            //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
        }

        private RemindMePrompt(string title, int maxValue) : this(title)
        {
            numNumber.Maximum = maxValue;

            if (maxValue == 0)
                numNumber.Maximum = int.MaxValue;

            pnlNumericPrompt.Visible = true;
            tbInput.Visible = false;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            intResult = 0;
            stringResult = "";
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            intResult = (int)numNumber.Value;
            this.Dispose();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbInput.Text.Length > 0)
            {
                stringResult = tbInput.Text;
                this.Dispose();
            }
        }

        private void numNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, e);
        }
    }
}
