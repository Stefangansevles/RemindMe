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
        static int intResult2;
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
        public static string ShowText(string title)
        {
            newPrompt = new RemindMePrompt(title);
            newPrompt.ShowDialog();
            return stringResult;
        }


        /// <summary>
        /// Shows a prompt where the user can enter a number
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <param name="useTwoInputFields">Determines if there should be 2 numeric fields that an user can put a number in</param>
        /// <returns>Returns an array with one number if useTwoInputFields is set to false. Returns two numbers if it is set to true</returns>
        public static int[] ShowNumeric(string title,bool useTwoInputFields)
        {                        
            int[] returnValue = new int[2]; //2 possible values                      
            newPrompt = new RemindMePrompt(title,useTwoInputFields);
            newPrompt.ShowDialog();

            returnValue[0] = intResult;
            if (useTwoInputFields)
                returnValue[1] = intResult2;

            return returnValue;
        }

       


        private RemindMePrompt(string title)
        {
            InitializeComponent();
            pbCloseApplication.BringToFront();
            BLFormLogic.RemovebuttonBorders(btnOk);
            BLFormLogic.RemovebuttonBorders(btnOkTwoValues);
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

       
        private RemindMePrompt(string title, bool useTwoInputFields) : this(title)
        {
            labelTextOne.Text = "Hours: ";
            labelTextTwo.Text = "Minutes: ";

            FixTwoValueWidth();

            if (useTwoInputFields)
            {
                pnlNumericPromptTwoValues.Visible = true;
                pnlNumericPrompt.Visible = false;
            }
            else
            {
                pnlNumericPromptTwoValues.Visible = false;
                pnlNumericPrompt.Visible = true;
            }
                                
            tbInput.Visible = false;
            
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            intResult = 0;
            intResult2 = 0;
            stringResult = "";
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            intResult = (int)numNumber.Value;

            if (intResult == 0)
                return;

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

      


        private void FixTwoValueWidth()
        {
            //Place the first numericupdown after the label, the second label after that and the second numericupdown after that
            numericUpDownValueOne.Location = new Point((labelTextOne.Location.X + labelTextOne.Width) + 3, numericUpDownValueOne.Location.Y);
            labelTextTwo.Location = new Point((numericUpDownValueOne.Location.X + numericUpDownValueOne.Width) + 3, labelTextTwo.Location.Y);
            numericUpDownValueTwo.Location = new Point((labelTextTwo.Location.X + labelTextTwo.Width) + 3, numericUpDownValueTwo.Location.Y);
            btnOkTwoValues.Location = new Point((numericUpDownValueTwo.Location.X + numericUpDownValueTwo.Width) + 3, btnOk.Location.Y);
        }

        private void btnOkTwoValues_Click(object sender, EventArgs e)
        {
            intResult = (int)numericUpDownValueOne.Value;
            intResult2 = (int)numericUpDownValueTwo.Value;

            if (intResult == 0 && intResult2 == 0)
                return;

            this.Dispose();
        }

        
    }  
}

