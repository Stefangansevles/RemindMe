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
    /// <summary>
    /// This user control is being loaded in an panel when making/editing an reminder. It slowly scrolls up/down
    /// </summary>
    public partial class UCPopupMessage : UserControl
    {
        public UCPopupMessage(string message)
        {
            InitializeComponent();
            tbError.Text = message;
            EnlargeTextbox();
        }

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
            this.Dispose();          
        }
        private void EnlargeTextbox()
        {
            Font tempFont = tbError.Font;
            int textLength = tbError.Text.Length;
            int textLines = tbError.GetLineFromCharIndex(textLength) + 1;
            int Margin = tbError.Bounds.Height - tbError.ClientSize.Height;
            tbError.Height = (TextRenderer.MeasureText(" ", tempFont).Height * textLines) + Margin + 2;

            if (tbError.Height + 62 > this.Height) //let's only enlarge the form, not shrink it.
                this.Height = tbError.Height + 32;
        }
    }
}
