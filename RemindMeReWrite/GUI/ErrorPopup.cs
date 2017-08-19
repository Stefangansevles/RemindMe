using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class ErrorPopup : Form
    {
        private string message;
        private string description;
        private Exception ex;        
        public ErrorPopup(string message, Exception ex)
        {
            InitializeComponent();
            this.message = message;
            this.ex = ex;
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


        public ErrorPopup(string message,Exception ex,string description) 
        {
            InitializeComponent();
            this.message = message;
            this.ex = ex;
            this.description = description;
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);

            label3.Focus(); //Like this the textbox won't be focused, else the textbox has the ugly blue selected text
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string t = tbError.Text;
            this.Dispose();
            this.Close();
        }

        private void ErrorPopup_Load(object sender, EventArgs e)
        {
            tbError.Text = message + "\r\n\r\nException type: " + ex.GetType() + "\r\n" + description;

            pbErrorIcon.BringToFront();

            //Make the button look better
            BLFormLogic.RemovebuttonBorders(btnClose);
            BLFormLogic.RemovebuttonBorders(btnOpenErrorLog);
        }

        

        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void btnOpenErrorLog_Click(object sender, EventArgs e)
        {
            Process.Start(Variables.IOVariables.errorLog);
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
