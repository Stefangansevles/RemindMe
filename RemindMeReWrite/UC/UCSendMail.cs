using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace RemindMe
{
    public partial class UCSendMail : UserControl
    {
        UCSendMailInfo ucSendMailInfo;
        public UCSendMail()
        {
            InitializeComponent();
            BLFormLogic.RemovebuttonBorders(btnConfirm);
        }
       

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(cbConfirm.Checked && tbSubject.Text != "" && tbMessage.Text != "")
            {
                Form1 mainForm  = (Form1)Application.OpenForms["Form1"];
                mainForm.StartMailTimer();

                if (!BLEmail.SendEmail(tbSubject.Text, tbMessage.Text))
                    lblCouldNotSendMail.Visible = true;
                else
                {
                    lblCouldNotSendMail.Visible = false;
                    //Take the user back to the info panel
                    ucSendMailInfo = new UCSendMailInfo();
                    Panel parentPanel = (Panel)this.Parent;
                    parentPanel.Controls.Clear();
                    parentPanel.Controls.Add(ucSendMailInfo);
                }

                

            }
        }
    }
}
