﻿using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace RemindMe
{
    public partial class Popup : Form
    {
        private Reminder rem;
        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        
        public Popup(Reminder rem)
        {
            BLIO.Log("Constructing Popup reminderId = " + rem.Id);
            InitializeComponent();
            this.Opacity = 0;
            this.rem = rem;

            this.Size = new Size((int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormWidth, (int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormHeight);
            lblTitle.Font = new Font(lblTitle.Font.FontFamily, BLLocalDatabase.PopupDimension.GetPopupDimensions().FontTitleSize, FontStyle.Bold);
            lblNoteText.Font = new Font(lblNoteText.Font.FontFamily, BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize, FontStyle.Bold);
            this.Text = rem.Name;

            lblNoteText.MaximumSize = new Size((pnlText.Width - lblNoteText.Location.X) - 10, 0);
            lblTitle.MaximumSize = new Size((pnlTitle.Width - lblTitle.Location.X) - 10, 0);


            //Assign the events that the user can raise while doing something on the popup. The stopflash event stops the taskbar icon from flashing            
            lblTitle.MouseClick += stopFlash_Event;
            lblNoteText.MouseClick += stopFlash_Event;
            this.MouseClick += stopFlash_Event;
            this.ResizeEnd += stopFlash_Event;

            BLIO.Log("Popup constructed");
            
            //Don't show postpone options if the reminder isn't real
            if(rem.Id == -1)
            {
                cbPostpone.Visible = false;
                lblPostpone.Visible = false;
                tbPostpone.Visible = false;
            }
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
   

        private void Popup2_Load(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("Popup_load");                
                AdvancedReminderProperties avrProps = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
                List<AdvancedReminderFilesFolders> avrFF = BLLocalDatabase.AVRProperty.GetAVRFilesFolders(rem.Id);
                if (avrProps != null) //Not null? this reminder has advanced properties.
                {
                    BLIO.Log("Reminder " + rem.Id + " has advanced reminder properties!");
                    this.Visible = avrProps.ShowReminder == 1;

                    if (!string.IsNullOrWhiteSpace(avrProps.BatchScript))
                    {
                        if (!this.Visible)
                            RemindMeMessageFormManager.MakeMessagePopup("Activating script of Reminder:\r\n \"" + rem.Name + "\"", 3);

                        BLIO.ExecuteBatch(avrProps.BatchScript);
                    }


                }
                else
                    BLIO.Log("Reminder " + rem.Id + " does not have advanced reminder properties");

                if (avrFF != null && avrFF.Count > 0)
                {
                    //Go through each action, for example c:\test , delete. c:\sometest\testFile.txt , open
                    foreach (AdvancedReminderFilesFolders avr in avrFF)
                    {
                        if (avr.Action.ToString() == "Open")
                        {
                            BLIO.Log("Executing advanced reminder action \"Open\"");

                            if (File.Exists(avr.Path) || Directory.Exists(avr.Path))
                                System.Diagnostics.Process.Start(avr.Path);
                        }
                        else if (avr.Action.ToString() == "Delete")
                        {
                            BLIO.Log("Executing advanced reminder action \"Delete\"");

                            FileAttributes attr = File.GetAttributes(avr.Path);
                            //Check if it's a file or a directory
                            if (File.Exists(avr.Path))
                                File.Delete(avr.Path);
                            else if (Directory.Exists(avr.Path))
                                Directory.Delete(avr.Path, true);
                        }
                    }
                }

                if (this.Visible)
                    tmrFadeIn.Start();
                else
                {
                    btnOk_Click(sender, e);
                    return;
                }

                BLIO.Log("Attempting to parse date...");
                DateTime date = Convert.ToDateTime(rem.Date.Split(',')[0]);
                BLIO.Log("Date succesfully converted (" + date + ")");

                lblSmallDate.Text = date.ToShortDateString() + " " + date.ToShortTimeString();
                lblRepeat.Text = BLReminder.GetRepeatTypeText(rem);

                if (!string.IsNullOrWhiteSpace(rem.PostponeDate))
                {
                    BLIO.Log("Reminder has a postpone date.");

                    pbDate.BackgroundImage = Properties.Resources.RemindMeZzz;
                    lblSmallDate.Text = Convert.ToDateTime(rem.PostponeDate) + " (Postponed)";
                }

                //If some country has a longer date string, move the repeat icon/text more to the right so it doesnt overlap
                while (lblSmallDate.Bounds.IntersectsWith(pbRepeat.Bounds))
                {
                    pbRepeat.Location = new Point(pbRepeat.Location.X + 5, pbRepeat.Location.Y);
                    lblRepeat.Location = new Point(lblRepeat.Location.X + 5, lblRepeat.Location.Y);
                }

                //Play the sound
                if (rem.SoundFilePath != null && rem.SoundFilePath != "")
                {

                    if (System.IO.File.Exists(rem.SoundFilePath))
                    {
                        BLIO.Log("SoundFilePath not null / empty and exists on the hard drive!");
                        myPlayer.URL = rem.SoundFilePath;
                        myPlayer.controls.play();
                        BLIO.Log("Playing sound");
                    }
                    else
                    {
                        BLIO.Log("SoundFilePath not null / empty but doesn't exist on the hard drive!");
                        RemindMeBox.Show("Could not play " + Path.GetFileNameWithoutExtension(rem.SoundFilePath) + " located at \"" + rem.SoundFilePath + "\" \r\nDid you move,rename or delete the file ?\r\nThe sound effect has been removed from this reminder. If you wish to re-add it, select it from the drop-down list.", RemindMeBoxReason.OK);
                        //make sure its removed from the reminder
                        rem.SoundFilePath = "";
                    }
                }

                FlashWindowHelper.Start(this);
                //this.MaximumSize = this.Size;

                if (BLLocalDatabase.Setting.IsAlwaysOnTop())
                {
                    this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
                    this.TopLevel = true;
                }
                else
                {
                    this.TopMost = false;
                    this.WindowState = FormWindowState.Minimized;
                }


                lblTitle.Text = rem.Name;

                if (rem.Note != null)
                    lblNoteText.Text = rem.Note.Replace("\\n", Environment.NewLine);

                if (rem.Note == "")
                    lblNoteText.Text = "( No text set )";

                lblNoteText.Text = Environment.NewLine + lblNoteText.Text;



                if (rem.Date == null)
                    rem.Date = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                ReminderException remEx = new ReminderException(BLReminder.ToString(rem), rem);
                remEx.StackTrace = ex.StackTrace; //Copy the stacktrace                

                BLIO.WriteError(remEx, "Error loading reminder popup");
                BLIO.Log("Popup_load FAILED. Exception -> " + ex.Message);
            }
        }

        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.CornflowerBlue;
        }

        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Transparent;
        }              

        private void lblExit_Click(object sender, EventArgs e)
        {
            btnOk_Click(sender, e);        
        }
       

        private void RepositionControls()
        {
            //give new locations to the controls if the size changes.                                    

            //cbPostpone.Location = new Point(3, pnlFooter.Height - cbPostpone.Height - 3);

            //lblPostpone.Location = new Point(cbPostpone.Location.X + cbPostpone.Width + 3, cbPostpone.Location.Y);
            // remi pnlPostpone.Location = new Point(lblPostpone.Location.X + lblPostpone.Width + 5, cbPostpone.Location.Y + 1);
            //todo tbtime.Location = new Point(numPostponeTime.Location.X + numPostponeTime.Width + 3, numPostponeTime.Location.Y - 7);
            btnOk.Location = new Point(pnlFooter.Width - btnOk.Width - 3, pnlFooter.Height - btnOk.Height - 3);
            
        }

        private void numPostponeTime_ValueChanged(object sender, EventArgs e)
        {            
            cbPostpone.Checked = true;
        }

        private void Popup2_SizeChanged(object sender, EventArgs e)
        {
            RepositionControls();
            lblNoteText.MaximumSize = new Size((pnlText.Width - lblNoteText.Location.X) - 10, 0);
            lblTitle.MaximumSize = new Size((pnlTitle.Width - lblTitle.Location.X) - 10, 0);            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            rem = BLReminder.GetReminderById(rem.Id);

            if (rem == null)
                goto close;

            if (rem.Id != -1 && rem.Deleted == 0) //Don't do stuff if the id is -1, invalid. the id is set to -1 when the user previews an reminder
            {
                if(BLReminder.GetReminderById(rem.Id) == null)
                {
                    //The reminder popped up, it existed, but when pressing OK it doesn't exist anymore (maybe the user deleted it or tempered with the .db file)
                    BLIO.Log("DETECTED NONEXISTING REMINDER WITH ID " + rem.Id + ", Attempted to press OK on a reminder that somehow doesn't exist");
                    goto close;
                }
                
                if (cbPostpone.Checked)
                {
                    BLIO.Log("Postponing reminder with id " + rem.Id);
                    if (numPostponeTime.Value == 0)
                        return;

                    DateTime newReminderTime = new DateTime();

                    if (cbPostpone.Checked && tbPostpone.ForeColor == Color.White && !string.IsNullOrWhiteSpace(tbPostpone.Text)) //postpone option is x minutes                
                    {
                        newReminderTime = DateTime.Now.AddMinutes(BLFormLogic.GetTextboxMinutes(tbPostpone));
                        rem.PostponeDate = newReminderTime.ToString();
                    }
                    else
                    {                        
                        rem.PostponeDate = null;
                        BLReminder.UpdateReminder(rem);
                    }



                    
                    BLIO.Log("Postpone date assigned to reminder");
                    rem.Enabled = 1;
                    BLReminder.EditReminder(rem);
                    new Thread(() =>
                    {
                        //Log an entry to the database, for data!                                                    
                        try
                        {
                            BLOnlineDatabase.PostponeCount++;
                        }
                        catch (ArgumentException ex)
                        {
                            BLIO.Log("Exception at BLOnlineDatabase.PostponeCount++. -> " + ex.Message);
                            BLIO.WriteError(ex, ex.Message, true);
                        }
                    }).Start();
                    BLIO.Log("Reminder postponed!");
                }
                else
                {
                    rem.PostponeDate = null;
                    BLReminder.UpdateReminder(rem);
                }                
            }

            close:
            UCReminders.Instance.UpdateCurrentPage();
            BLIO.Log("Stopping media player & Closing popup");
            myPlayer.controls.stop();
            btnOk.Enabled = false;
            this.Close();
        }

        private void numPostponeTime_KeyUp(object sender, KeyEventArgs e)
        {            
            if(!cbPostpone.Checked) //If its not already checked, then...
                cbPostpone.Checked = char.IsNumber((char)e.KeyCode);            
        }

        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
                e.Cancel = true;
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        private void tbPrompt_KeyUp(object sender, KeyEventArgs e)
        {            
            //Show the user that whatever it is they are inputting is invalid
            if (tbPostpone.Text == "" || BLFormLogic.GetTextboxMinutes(tbPostpone) != -1)
                tbPostpone.BorderColorFocused = Color.FromArgb(64, 64, 64);
            else
                tbPostpone.BorderColorFocused = Color.Red;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            cbPostpone.Checked = !cbPostpone.Checked;

            if (cbPostpone.Checked)
                btnOk.Text = "Postpone";
            else
                btnOk.Text = "Ok";

            tbPostpone.Visible = cbPostpone.Checked;
        }

        private void tbtime_Enter(object sender, EventArgs e)
        {
            if (tbPostpone.ForeColor == Color.Gray)
            {
                tbPostpone.Text = "";
                tbPostpone.ForeColor = Color.White;                
            }
        }

        private void tbtime_Leave(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbPostpone.Text))
            {
                tbPostpone.ForeColor = Color.Gray;
                tbPostpone.Text = "1h30m";
            }
        }

       

        private void cbPostpone_OnChange_1(object sender, EventArgs e)
        {
            if (cbPostpone.Checked)
                btnOk.Text = "Postpone";
            else
                btnOk.Text = "Ok";

            tbPostpone.Visible = cbPostpone.Checked;
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.DarkRed;
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Transparent;
        }
    }
}
