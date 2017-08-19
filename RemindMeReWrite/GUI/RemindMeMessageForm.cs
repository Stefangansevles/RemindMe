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
    public partial class RemindMeMessageForm : Form
    {
        //the amount of seconds to wait before this form should go down.
        private int popDelay;
        /// <summary>
        /// This class is a custom message form that will appear at the right bottom corner of the user's main monitor.
        /// </summary>
        public RemindMeMessageForm(string messageToShow,int popDelay)
        {
            InitializeComponent();            
            tbMessage.Text = messageToShow;
            EnlargeTextbox();
            this.popDelay = popDelay;
            this.TopMost = true;
            this.TopLevel = true;

            this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width, Screen.GetWorkingArea(this).Height);
        }

        /// <summary>
        /// The amount of seconds before this form should go down.
        /// </summary>
        public int PopDelay
        {
            get { return popDelay; }            
        }
        /// <summary>
        /// Enlarges the textbox and form if there's a lot of text in it
        /// </summary>
        private void EnlargeTextbox()
        {
            Font tempFont = tbMessage.Font;
            int textLength = tbMessage.Text.Length;
            int textLines = tbMessage.GetLineFromCharIndex(textLength) + 1;
            int Margin = tbMessage.Bounds.Height - tbMessage.ClientSize.Height;
            tbMessage.Height = (TextRenderer.MeasureText(" ", tempFont).Height * textLines) + Margin + 2;

            if (tbMessage.Height + 62 > this.Height) //let's only enlarge the form, not shrink it.
                this.Height = tbMessage.Height + 32;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {            
            this.Dispose();
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

        private void RemindMeMessageForm_SizeChanged(object sender, EventArgs e)
        {
            tbBottomBorder.Location = new Point(tbBottomBorder.Location.X, this.Height - 1);
            tbSideBorder.Size = new Size(tbSideBorder.Width, this.Height);
        }

        private void tbMessage_Enter(object sender, EventArgs e)
        {
            pictureBox5.Focus();
        }

        private void RemindMeMessageForm_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void RemindMeMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
