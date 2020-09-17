using Business_Logic_Layer;
using Database.Entity;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace RemindMe
{
    public partial class MaterialPopup : MaterialForm
    {
        private Reminder rem;
        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();

        public MaterialPopup(Reminder rem)
        {
            AddFont(Properties.Resources.Roboto_Medium);

            BLIO.Log("Constructing Popup reminderId = " + rem.Id);            
            InitializeComponent();
            
            this.Opacity = 0;
            this.rem = rem;

            this.Size = new Size((int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormWidth, (int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormHeight);            
            //lblNoteText.Font = new Font(lblNoteText.Font.FontFamily, BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize, FontStyle.Bold);
            this.Text = rem.Name;

            lblNoteText.MaximumSize = new Size((pnlText.Width - lblNoteText.Location.X) - 10, 0);            

            
            

            tbPostpone.KeyDown += numericOnly_KeyDown;
            tbPostpone.KeyPress += numericOnly_KeyPress;

            //Assign the events that the user can raise while doing something on the popup. The stopflash event stops the taskbar icon from flashing            
            this.MouseClick += stopFlash_Event;
            lblNoteText.MouseClick += stopFlash_Event;
            this.MouseClick += stopFlash_Event;
            this.ResizeEnd += stopFlash_Event;
            
            BLIO.Log("Popup constructed");            
        }

        private void numericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar.ToString().ToLower() != "h") && (e.KeyChar.ToString().ToLower() != "m"))
                e.Handled = true;
        }
        private void numericOnly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }



        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        private static uint cFonts = 0;
        private static void AddFont(byte[] fontdata)
        {
            int fontLength; System.IntPtr dataPointer;

            //We are going to need a pointer to the font data, so we are generating it here
            dataPointer = Marshal.AllocCoTaskMem(fontdata.Length);


            //Copying the fontdata into the memory designated by the pointer
            Marshal.Copy(fontdata, 0, dataPointer, (int)fontdata.Length);

            // Register the font with the system.
            AddFontMemResourceEx(dataPointer, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            //Keep track of how many fonts we've added.
            cFonts += 1;

            //Finally, we can actually add the font to our collection
            pfc.AddMemoryFont(dataPointer, (int)fontdata.Length);
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

        public void ChangeFontSize(float size)
        {
            lblNoteText.Font = new Font(pfc.Families[0], size, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        private void Popup2_Load(object sender, EventArgs e)
        {
            try
            {
                BLIO.Log("Popup_load");
                lblNoteText.Font = new Font(pfc.Families[0], (float)BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize, FontStyle.Regular, GraphicsUnit.Pixel);


                AdvancedReminderProperties avrProps = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
                List<AdvancedReminderFilesFolders> avrFF = BLLocalDatabase.AVRProperty.GetAVRFilesFolders(rem.Id);
                if (avrProps != null) //Not null? this reminder has advanced properties.
                {
                    BLIO.Log("Reminder " + rem.Id + " has advanced reminder properties!");
                    this.Visible = avrProps.ShowReminder == 1;

                    if (!string.IsNullOrWhiteSpace(avrProps.BatchScript))
                    {
                        if (!this.Visible)
                            MaterialMessageFormManager.MakeMessagePopup("Activating script of Reminder:\r\n \"" + rem.Name + "\"", 3);

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
                    lblSmallDate.Text = Convert.ToDateTime(rem.PostponeDate) + "";
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
                        MaterialRemindMeBox.Show("Could not play " + Path.GetFileNameWithoutExtension(rem.SoundFilePath) + " located at \"" + rem.SoundFilePath + "\" \r\nDid you move,rename or delete the file ?\r\nThe sound effect has been removed from this reminder. If you wish to re-add it, select it from the drop-down list.", RemindMeBoxReason.OK);
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


                this.Text = rem.Name;

                if (rem.Note != null)
                    lblNoteText.Text = rem.Note.Replace("\\n", Environment.NewLine);

                if (rem.Note == "")
                    lblNoteText.Text = "( No text set )";

                lblNoteText.Text = Environment.NewLine + lblNoteText.Text;



                if (rem.Date == null)
                    rem.Date = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                ReminderException remEx = new ReminderException(BLReminder.ToString(rem), rem);
                remEx.StackTrace = ex.StackTrace; //Copy the stacktrace                

                BLIO.WriteError(remEx, "Error loading reminder popup");
                BLIO.Log("Popup_load FAILED. Exception -> " + ex.Message);
            }
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
            
        }

        private void Popup2_SizeChanged(object sender, EventArgs e)
        {
            RepositionControls();
            lblNoteText.MaximumSize = new Size((pnlText.Width - lblNoteText.Location.X) - 10, 0);
            var test = this.Height - (this.StatusBarHeight + this.ActionBarHeight);
            pnlText.Size = new Size(this.Width, (this.Height - 145));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            rem = BLReminder.GetReminderById(rem.Id);

            if (rem == null)
                goto close;

            if (rem.Id != -1 && rem.Deleted == 0) //Don't do stuff if the id is -1, invalid. the id is set to -1 when the user previews an reminder
            {
                if (BLReminder.GetReminderById(rem.Id) == null)
                {
                    //The reminder popped up, it existed, but when pressing OK it doesn't exist anymore (maybe the user deleted it or tempered with the .db file)
                    BLIO.Log("DETECTED NONEXISTING REMINDER WITH ID " + rem.Id + ", Attempted to press OK on a reminder that somehow doesn't exist");
                    goto close;
                }

                if (cbPostpone.Checked)
                {
                    BLIO.Log("Postponing reminder with id " + rem.Id);
                    if (Convert.ToInt32(tbPostpone.Text) == 0)
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
            MUCReminders.Instance.UpdateCurrentPage();
            BLIO.Log("Stopping media player & Closing popup");
            myPlayer.controls.stop();
            btnOk.Enabled = false;
            this.Close();
        }

        private void numPostponeTime_KeyUp(object sender, KeyEventArgs e)
        {
            if (!cbPostpone.Checked) //If its not already checked, then...
                cbPostpone.Checked = char.IsNumber((char)e.KeyCode);
        }

      

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

       



        private void cbPostpone_OnChange_1(object sender, EventArgs e)
        {
            if (cbPostpone.Checked)
                btnOk.Text = "Postpone";
            else
                btnOk.Text = "Ok";

            if (cbPostpone.Checked)
                tbPostpone.Visible = true;
                    
        }




        private void tbPostpone_TextChanged(object sender, EventArgs e)
        {
            if (!tbPostpone.ContainsFocus)
                return;

            cbPostpone.Checked = true;

            if (BLFormLogic.GetTextboxMinutes(tbPostpone) == -1)
                cbPostpone.Checked = false;
        }

        private void MaterialPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
                e.Cancel = true;

            MaterialForm1.MaterialSkinManager.RemoveFormToManage(this);
        }
    }
}
