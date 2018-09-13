using Business_Logic_Layer;
using Microsoft.Win32;
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
    public partial class AdvancedReminderForm : Form
    {
        //Create user controls
        private AVR_UCFiles ucFiles;
        private AVR_UCBatch ucBatch;
        private AVR_UCGeneral ucGeneral;
        public AdvancedReminderForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            ucFiles = new AVR_UCFiles();
            ucBatch = new AVR_UCBatch();
            ucGeneral = new AVR_UCGeneral();


            BLIO.Log("Advanced reminder form created!");

            btnFile.MouseEnter += btn_MouseEnter;
            btnFile.MouseLeave += btn_MouseLeave;

            btnScript.MouseEnter += btn_MouseEnter;
            btnScript.MouseLeave += btn_MouseLeave;

            btnGeneral.MouseEnter += btn_MouseEnter;
            btnGeneral.MouseLeave += btn_MouseLeave;
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }
        public string BatchScript
        {
            get { return ucBatch.BatchScript; }
            set { ucBatch.BatchScript = value; }
        }

        public Dictionary<string,string> FilesFolders
        {
            get { return ucFiles.FilesFolders; }
            set { ucFiles.FilesFolders = value; }
        }
        public long ShowReminder
        {
            get { return ucGeneral.ShowReminder ? 1 : 0; }
            set
            {
                if (value == 1) { ucGeneral.ShowReminder = true; }
                else if (value == 0) { ucGeneral.ShowReminder = false; }
            }
        }
        private void AdvancedReminderForm_Load(object sender, EventArgs e)
        {            
            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null)
            {
                //Place the message box in the middle of remindme
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            tmrFadeIn.Start();

            btnScript_Click(sender, e);        
        }

       
        //Global color-change events for multiple buttons
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuImageButton button = (Bunifu.Framework.UI.BunifuImageButton)sender;
            button.BackColor = Color.FromArgb(100,100,100);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuImageButton button = (Bunifu.Framework.UI.BunifuImageButton)sender;
            button.BackColor = Color.FromArgb(80, 80, 80);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "File / folder control";
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucFiles);
            BLIO.Log("(AVR) File / folder UC selected");
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            BLIO.Log("(AVR) hiding AVR form");
            ucBatch.BatchScript = "";
            ucFiles.FilesFolders.Clear();
            ucFiles.lvItems.Items.Clear();
            Hide();
        }
       

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BLIO.Log("(AVR) Saving & hiding AVR form");            
            MessageFormManager.MakeMessagePopup("Advanced settings applied to this reminder!", 5);
            Hide();
        }

       

        private void btnScript_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Execute Windows batch (.bat)";
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucBatch);
            BLIO.Log("(AVR) UC Batch selected");
        }

        public string GetBatch()
        {
            return "";
        }
        public Dictionary<string,string> GetFoldersFiles()
        {
            return null;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {

            lblTitle.Text = "General settings";
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucGeneral);
            BLIO.Log("(AVR) UC General selected");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            BLIO.Log("(AVR) hiding AVR form");            
            Hide();
        }
    }
}
