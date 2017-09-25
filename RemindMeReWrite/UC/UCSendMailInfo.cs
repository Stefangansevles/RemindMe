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
    /// This is the user control the user sees before the user has the option to send a mail.
    /// </summary>
    public partial class UCSendMailInfo : UserControl
    {
        UCSendMail ucSendMail;
        public UCSendMailInfo()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)Application.OpenForms["Form1"];
            if (!mainForm.IsMailTimerTicking())
            {
                lblNoEmailAllowed.Visible = false;

                ucSendMail = new UCSendMail();

                Panel parentPanel = (Panel)this.Parent;
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(ucSendMail);
                
            }
            else
                lblNoEmailAllowed.Visible = true;
            
        }

       
    }
}
