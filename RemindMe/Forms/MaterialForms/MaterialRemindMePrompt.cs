using Business_Logic_Layer;
using MaterialSkin.Controls;
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
    public partial class MaterialRemindMePrompt : MaterialForm
    {
        private static PromptReason promptReason;
        private static string strReturnValue;
        private static int intReturnValue;
        private static MaterialRemindMePrompt newPrompt;
        private static int minutes;
        public MaterialRemindMePrompt(string title, PromptReason reason)
        {
            BLIO.Log("Constructing RemindMePrompt (" + title + ")");
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(this);
            InitializeComponent();
            promptReason = reason;
            this.Opacity = 0;
            lblText.MaximumSize = new Size((pnlMain.Width - lblText.Location.X) - 10, 0);            

            this.Text = title;


            //Set the location within the remindme window. 
            //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null && remindme.Visible)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            tmrFadeIn.Start();

            strReturnValue = "";
            intReturnValue = 0;
            minutes = 0;

            switch(reason)
            {
                case PromptReason.MINUTES:
                    tbPrompt.KeyPress += timeOnly_KeyPress;
                    tbPrompt.KeyDown += numericOnly_KeyDown;
                    break;
                case PromptReason.NUMERIC:
                    tbPrompt.KeyPress += numericOnly_KeyPress;
                    tbPrompt.KeyDown += numericOnly_KeyDown;
                    break;                
            }
            BLIO.Log("RemindMePrompt constructed");
        }

        public MaterialRemindMePrompt(string title, string description, PromptReason reason) : this(title, reason)
        {
            lblText.Visible = true;
            lblText.Text = description;
        }

        /// <summary>
        /// Shows a prompt where the user can enter a string
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <returns></returns>
        public static string ShowText(string title)
        {
            newPrompt = new MaterialRemindMePrompt(title, PromptReason.TEXT);
            newPrompt.ShowDialog();
            BLIO.Log("RemindMePrompt closed and returned " + strReturnValue);
            return strReturnValue;
        }
        /// <summary>
        /// Shows a prompt where the user can enter a number
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <returns></returns>
        public static int ShowNumber(string title)
        {
            newPrompt = new MaterialRemindMePrompt(title, PromptReason.NUMERIC);
            newPrompt.ShowDialog();            

            BLIO.Log("RemindMePrompt closed and returned " + intReturnValue);
            if (intReturnValue < 0) intReturnValue = 0;
            return intReturnValue;
        }
        /// <summary>
        /// Shows a prompt where the user can enter a number
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <returns></returns>
        public static int ShowNumber(string title, string description)
        {
            newPrompt = new MaterialRemindMePrompt(title, description, PromptReason.NUMERIC);
            newPrompt.ShowDialog();
            BLIO.Log("RemindMePrompt closed and returned " + intReturnValue);
            if (intReturnValue < 0) intReturnValue = 0;
            return intReturnValue;
        }

        public static int ShowMinutes(string title, string description)
        {
            newPrompt = new MaterialRemindMePrompt(title, description, PromptReason.MINUTES);
            newPrompt.ShowDialog();
            if (minutes < 0) minutes = 0;
            return minutes;
        }
        /// <summary>
        /// Shows a prompt where the user can enter a string
        /// </summary>
        /// <param name="title">The title the user should see when this prompt shows up</param>
        /// <returns></returns>
        public static string ShowText(string title, string description)
        {
            newPrompt = new MaterialRemindMePrompt(title, description, PromptReason.TEXT);
            newPrompt.ShowDialog();
            BLIO.Log("RemindMePrompt closed and returned " + strReturnValue);
            return strReturnValue;
        }

        private void tbPrompt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPrompt.Text))
                return;

            if (promptReason == PromptReason.NUMERIC)
            {
                try
                {
                    intReturnValue = Convert.ToInt32(tbPrompt.Text);
                    this.Close(); //Won't reach this if the input text is not numeric.                    
                }
                catch
                {
                    tbPrompt.Text = "";
                }
            }
            else if (promptReason == PromptReason.TEXT)
            {
                strReturnValue = tbPrompt.Text;
                this.Close();
            }
            else if (promptReason == PromptReason.MINUTES)
            {
                try
                {
                    if (tbPrompt.Text.ToLower().Contains('h'))
                    {
                        BLIO.Log("timer popup contains 'h'. Checking what's before it");

                        //Text without the 'm'. We know the number after 'h' is in minutes, no need to keep it in the string
                        string tbText = tbPrompt.Text.Replace("m", "");

                        //Get the index number of the 'h' in the text
                        int index = tbPrompt.Text.ToLower().IndexOf('h');

                        //Now get all the text before it(should be a numer) and multiply by 60 because the user input hours
                        BLIO.Log("Parsing hours....");
                        minutes += Convert.ToInt32(tbPrompt.Text.Substring(0, index)) * 60;

                        //Now get the number after the 'h' , which should be minutes, and add it to timerMinutes
                        //But, first check if there is actually something after the 'h'

                        if (tbText.Length > index + 1)//+1 because .Length starts from 1, index starts from 0
                        {
                            BLIO.Log("Parsing minutes....");
                            minutes += Convert.ToInt32(tbText.Substring(index + 1, tbText.Length - (index + 1)));
                        }
                    }
                    else
                        minutes = Convert.ToInt32(tbPrompt.Text);
                }
                catch { }

                if (minutes <= 0)
                    tbPrompt.ForeColor = Color.Firebrick;
                else
                    this.Close();
            }
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.08;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }


        private void timeOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar.ToString().ToLower() != "h") && (e.KeyChar.ToString().ToLower() != "m"))
                e.Handled = true;
        }
        private void numericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar.ToString().ToLower() != "."))
                e.Handled = true;
        }
        private void numericOnly_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }

        private void RemindMePrompt_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            this.TopLevel = true;
        }

        private void MaterialRemindMePrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialSkin.MaterialSkinManager.Instance.RemoveFormToManage(this);
        }
    }  

}
