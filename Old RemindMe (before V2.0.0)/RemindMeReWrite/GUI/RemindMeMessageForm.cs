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
    public partial class RemindMeMessageForm : Form
    {
       
        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;

                handleParam.ExStyle |= WS_EX_NOACTIVATE; //This starts the form without activating it, meaning if you're playing a full-screen game, and you're holding down the w key, this form will not interrupt it. 
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return handleParam;
            }
        }

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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            BLFormLogic.PaintFormBorder(e, this, linethickness: 3, linecolor: Color.White, offsetborder: 0);
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
                this.Height = tbMessage.Height + 30;
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {            
            this.Dispose();
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

        private void RemindMeMessageForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;

            this.ActiveControl = null;
        }
    }
}
