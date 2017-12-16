using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace RemindMe
{
    public partial class Popup2 : Form
    {
        private Reminder rem;
        //Will be true if the user pressed the OK button to close the reminder
        private bool formClosedCorrectly = false;

        private int initialWidth;
        private int initialHeight;
        private float initialFontSize;
        public Popup2(Reminder rem)
        {
            InitializeComponent();
            this.rem = rem;

            this.Size = new Size((int)BLPopupDimensions.GetPopupDimensions().FormWidth, (int)BLPopupDimensions.GetPopupDimensions().FormHeight);
            tbTitle.Font = new Font(tbTitle.Font.FontFamily, BLPopupDimensions.GetPopupDimensions().FontTitleSize, FontStyle.Bold);
            tbText.Font = new Font(tbText.Font.FontFamily, BLPopupDimensions.GetPopupDimensions().FontNoteSize, FontStyle.Bold);


            initialWidth = Width;
            initialHeight = Height;
            initialFontSize = lblTitle.Font.Size;


            //Assign the events that the user can raise while doing something on the popup. The stopflash event stops the taskbar icon from flashing            
            tbTitle.MouseClick += stopFlash_Event;
            tbText.MouseClick += stopFlash_Event;
            this.MouseClick += stopFlash_Event;
            this.ResizeEnd += stopFlash_Event;

        
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private const int WS_EX_NOACTIVATE = 0x08000000;

        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;

        protected override void WndProc(ref Message m)
        {
            //Makes the popup draggable
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void pbClosePopup_Click(object sender, EventArgs e)
        {
            this.Close();            
            
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            pnlText.VerticalScroll.Visible = true;

            //Set the maximum width of the panel, so that there won't be a horizontal scrollbar, but only a vertical one(if there is a lot of text)
            lblNoteText.MaximumSize = new Size(pnlText.Width - 20, 0);
            lblTitle.MaximumSize = new Size(pnlTitle.Width - 20,0);

            pnlTopGradient.SendToBack();            
            FlashWindowHelper.Start(this);
            this.MaximumSize = this.Size;

            if (BLSettings.IsAlwaysOnTop())
            {
                this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
                this.TopLevel = true;
            }
            else
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;
            }                                    

            //Show what date this reminder was set for
            if(rem.PostponeDate == null)
                lblDate.Text = "This reminder was set for " + rem.Date.Split(',')[0];
            else
                lblDate.Text = "This reminder was set for " + rem.PostponeDate;


            lblTitle.Text = rem.Name;
            lblNoteText.Text = rem.Note.Replace("\\n", Environment.NewLine);
            
            //Play the sound
            if (rem.SoundFilePath != null && rem.SoundFilePath != "")
            {
                if (System.IO.File.Exists(rem.SoundFilePath))
                {
                    myPlayer.URL = rem.SoundFilePath;
                    myPlayer.controls.play();                    
                }
                else
                {
                    RemindMeBox.Show("Could not play " + Path.GetFileNameWithoutExtension(rem.SoundFilePath) + " located at \"" + rem.SoundFilePath + "\" \r\nDid you move,rename or delete the file ?\r\nThe sound effect has been removed from this reminder. If you wish to re-add it, select it from the drop-down list.", RemindMeBoxReason.OK);
                    //make sure its removed from the reminder
                    rem.SoundFilePath = "";
                }
            }
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;

                handleParam.ExStyle |= WS_EX_NOACTIVATE; 
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        private void pbMinimizePopup_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        private void pbCloseApplication_Click(object sender, EventArgs e)
        {
            if (rem.Id != -1)
            {
                rem.PostponeDate = null;
                BLReminder.UpdateReminder(rem);
                //RefreshMainFormListView();
            }
            this.Close();
            this.Dispose();
        }

        private void pbMinimizeApplication_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;            
        }

        

        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Try to update the reminder before the form unexpectedly closes
            if (rem.Id != -1 && !formClosedCorrectly)
            {
                rem.PostponeDate = null;
                BLReminder.UpdateReminder(rem);
                //RefreshMainFormListView();
            }

            //Stop the sound from playing when the popup closes. You don't want it to keep playing, especially if it is a soundtrack that is quite long
            myPlayer.controls.stop();
        }

        

        private void cbPostponeTime_ValueChanged(object sender, EventArgs e)
        {
            cbPostpone.Checked = true;
        }

        private void cbPostponeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbHours.Checked)
                numPostponeTime.Maximum = 23;
            else
                numPostponeTime.Maximum = 1400;
        }

        private void tbTitle_Enter(object sender, EventArgs e)
        {
            lblNewReminder.Focus();
        }

        private void tbText_Enter(object sender, EventArgs e)
        {
            lblNewReminder.Focus();
        }

        private void ResizeControls()
        {
            //give new locations to the controls if the size changes.            

            tbTitle.Width = (this.Width - tbTitle.Location.X) - 3;
            tbText.Width = (this.Width - tbText.Location.X) - 3;

            lblDate.Location = new Point(lblDate.Location.X, (lblNewReminder.Location.Y + lblNewReminder.Height) + 3);

            

            cbPostpone.Location = new Point(3, pnlFooter.Height - cbPostpone.Height - 3);

            lblPostpone.Location = new Point(cbPostpone.Location.X + cbPostpone.Width + 3, cbPostpone.Location.Y);
            numPostponeTime.Location = new Point(lblPostpone.Location.X + lblPostpone.Width + 5, cbPostpone.Location.Y + 1);
            gbRadioButtons.Location = new Point(numPostponeTime.Location.X + numPostponeTime.Width + 3, numPostponeTime.Location.Y - 7);
            btnOk.Location = new Point(pnlFooter.Width - btnOk.Width - 3, pnlFooter.Height - btnOk.Height - 3);

            lblNewReminder.Location = new Point(pnlHeaderText.Width / 2 - (lblNewReminder.Width / 2), -3);
            lblDate.Location = new Point(lblNewReminder.Location.X - (lblDate.Width / 2 / 2) + 30,lblDate.Location.Y);

            //lblNote.Height = pnlText.Height;

            /*tbTitle.Height = Convert.ToInt32(this.Height * 0.20); //20% of the form
            tbText.Height = (cbPostpone.Location.Y - 5) - (tbTitle.Location.Y + tbTitle.Height) - 3;//height should be y start point through a bit above the postpone combobox
            tbText.Location = new Point(tbText.Location.X, tbTitle.Location.Y + tbTitle.Height + 3);//place the text textbox under the title textbox*/
        }
        private void Popup_SizeChanged(object sender, EventArgs e)
        {
            bunifuGradientPanel1.Size = this.Size;
            ResizeControls();
        }

        

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {                
                //remove the focus from the button so you can't spacebar-close the reminder
                lblDate.Focus();
            }
        }

        private void rbHours_CheckedChanged(object sender, EventArgs e)
        {
            cbPostpone.Checked = true;
        }

        
        /// <summary>
        /// Stops the flashing of the taskbar icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopFlash_Event(object sender, EventArgs e)
        {            
            this.Activate();
            FlashWindowHelper.Stop(this);
        }

     

        private void cbPostpone_OnChange(object sender, EventArgs e)
        {
            if (cbPostpone.Checked)
                btnOk.LabelText = "Postpone";
            else
                btnOk.LabelText = "Ok";            
        }

       
        private void lblTitle_Resize(object sender, EventArgs e)
        {
            SuspendLayout();
            // Get the proportionality of the resize
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Calculate the current font size
            /*lblTitle.Font = new Font(lblTitle.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblTitle.Font.Style);*/
            ResumeLayout();
        }

        private void lblPostpone_Click(object sender, EventArgs e)
        {
            cbPostpone.Checked = !cbPostpone.Checked;
        }

       

        private void lblExit_Click(object sender, EventArgs e)
        {
            if (rem.Id != -1)
            {
                rem.PostponeDate = null;
                BLReminder.UpdateReminder(rem);
                //RefreshMainFormListView();
            }
            this.Close();
            this.Dispose();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rem.Id != -1) //Don't do stuff if the id is -1, invalid. the id is set to -1 when the user previews an reminder
            {
                formClosedCorrectly = true;
                if (cbPostpone.Checked)
                {
                    if (numPostponeTime.Value == 0)
                        return;

                    DateTime newReminderTime = new DateTime();

                    if (rbMinutes.Checked) //postpone option is x minutes                
                        newReminderTime = DateTime.Now.AddMinutes((double)numPostponeTime.Value);
                    else //postpone option is x hours                
                        newReminderTime = DateTime.Now.AddHours((double)numPostponeTime.Value);

                    rem.PostponeDate = newReminderTime.ToString();
                    rem.Enabled = 1;
                    BLReminder.EditReminder(rem);
                }
                else
                {
                    rem.PostponeDate = null;
                    BLReminder.UpdateReminder(rem);
                }
                UCReminders.NotifyChange();
            }
            this.Close();
        }

        private void rbMinutes_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
