using Business_Logic_Layer;
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
    internal partial class RemindMeBox : Form
    {

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        static DialogResult result;
        static RemindMeBox newMessageBox;

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);

            pictureBox1.Focus();
        }

        
        public static DialogResult Show(string title, RemindMeBoxIcon icon, MessageBoxButtons buttons)
        {
            newMessageBox = new RemindMeBox(title,icon,buttons);
            newMessageBox.ShowDialog();
            return result;
        }

       
        private RemindMeBox(string description, RemindMeBoxIcon icon, MessageBoxButtons buttons)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.TopMost = true;
            btnOk.Visible = true;
            btnYes.Visible = false;
            btnNo.Visible = false;

            BLFormLogic.RemovebuttonBorders(btnOk);
            BLFormLogic.RemovebuttonBorders(btnYes);
            BLFormLogic.RemovebuttonBorders(btnNo);
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

           

            if (buttons == MessageBoxButtons.YesNo)
            {
                btnOk.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            else
            {
                btnOk.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
        }

        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
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
            result = DialogResult.OK;
            newMessageBox.Dispose();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            newMessageBox.Dispose();
        }

        private void CustomMessageForm_SizeChanged(object sender, EventArgs e)
        {

            btnOk.Location = new Point(btnOk.Location.X, this.Size.Height - btnOk.Height - 5);
            btnYes.Location = new Point(btnYes.Location.X, this.Size.Height - btnYes.Height - 5);
            btnNo.Location = new Point((btnYes.Location.X + btnYes.Width) + 3, this.Size.Height - btnNo.Height - 5);

            
            tbError.Height = this.Height - 62;
        }

        

        private void btnYes_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            newMessageBox.Dispose();         
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            newMessageBox.Dispose();
        }

       
    }

    
}
