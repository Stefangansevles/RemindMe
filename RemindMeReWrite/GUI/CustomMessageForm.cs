using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// The form internally used by <see cref="CustomMessageBox"/> class.
    /// </summary>
    internal partial class CustomMessageForm : Form
    {

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);

            pictureBox1.Focus();
        }              

        public CustomMessageForm(string description, RemindMeBoxIcon icon)
        {
            InitializeComponent();
            this.TopMost = true;
            BLFormLogic.RemovebuttonBorders(btnOk);
            switch (icon)
            {
                case RemindMeBoxIcon.EXCLAMATION:
                    pbErrorIcon.BackgroundImage = SystemIcons.Exclamation.ToBitmap();
                    break;
                case RemindMeBoxIcon.INFORMATION:
                    pbErrorIcon.BackgroundImage = SystemIcons.Information.ToBitmap();
                    break;
                case RemindMeBoxIcon.QUESTION:
                    pbErrorIcon.BackgroundImage = SystemIcons.Question.ToBitmap();
                    break;
                case RemindMeBoxIcon.NONE:
                    pbErrorIcon.BackgroundImage = null;
                    break;
            }            

            

            tbError.Text = description;

            EnlargeTextbox();  
        }

        /// <summary>
        /// Enlarges the textbox if the text exceeds the textbox.
        /// </summary>
        private void EnlargeTextbox()
        {
            Font tempFont = tbError.Font;
            int textLength = tbError.Text.Length;
            int textLines = tbError.GetLineFromCharIndex(textLength) + 1;
            int Margin = tbError.Bounds.Height - tbError.ClientSize.Height;
            tbError.Height = (TextRenderer.MeasureText(" ", tempFont).Height * textLines) + Margin + 2;

            if (tbError.Height + 62 > this.Height) //let's only enlarge the form, not shrink it.
                this.Height = tbError.Height + 62;
        }




        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomMessageForm_SizeChanged(object sender, EventArgs e)
        {
            btnOk.Location = new Point(btnOk.Location.X, this.Size.Height - btnOk.Height);
            tbError.Height = this.Height - 62;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }

    /// <summary>
    /// Custom RemindMe message box helper.
    /// </summary>
    public static class RemindMeBox
    {
        /// <summary>
        /// Pops up the RemindMeBox.
        /// </summary>
        /// <param name="title">The text you want the user to see</param>
        /// <param name="icon">The Icon that the RemindMeBox should show</param>
        public static void Show(string title, RemindMeBoxIcon icon)
        {
            // using construct ensures the resources are freed when form is closed
            using (CustomMessageForm form = new CustomMessageForm(title, icon))
            {
                form.ShowDialog();
            }
        }
    }
}
