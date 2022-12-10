using Business_Logic_Layer;
using Database.Entity;
using MaterialSkin.Controls;
using RemindMe.Other_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;
using Newtonsoft.Json.Linq;

namespace RemindMe
{
    public partial class MaterialPopup : MaterialForm
    {
        private Reminder rem;        
        private bool xClose = true;
        private HtmlLabel htmlLblText = new HtmlLabel();        
        public MaterialPopup(Reminder rem)
        {
            BLIO.Log("Constructing Popup reminderId = " + rem.Id);          
            AddFont(Properties.Resources.Roboto_Medium);            
            InitializeComponent();

            if (MaterialForm1.Instance.Visible)            
                BLFormLogic.CenterFormToParent(this, MaterialForm1.Instance);            
            

            this.Opacity = 0;            
            this.rem = rem;
            this.Size = new Size((int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormWidth, (int)BLLocalDatabase.PopupDimension.GetPopupDimensions().FormHeight);            
            //lblNoteText.Font = new Font(lblNoteText.Font.FontFamily, BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize, FontStyle.Bold);
            this.Text = rem.Name;

            //lblNoteText.MaximumSize = new Size((pnlText.Width - lblNoteText.Location.X) - 20, 0);


            htmlLblText.AutoSizeHeightOnly = true;
            htmlLblText.Width = this.Width - 8;
            htmlLblText.Height = pnlText.Height;
            htmlLblText.MaximumSize = new Size(htmlLblText.Width-30, 0);            
            htmlLblText.Location = new Point(8,-5);            

            pnlText.Controls.Add(htmlLblText);            

            tbPostpone.KeyDown += numericOnly_KeyDown;
            tbPostpone.KeyPress += numericOnly_KeyPress;

            //Assign the events that the user can raise while doing something on the popup. The stopflash event stops the taskbar icon from flashing            
            this.MouseClick += stopFlash_Event;            
            this.MouseClick += stopFlash_Event;
            this.ResizeEnd += stopFlash_Event;


            //TODO: #53521 ?
            Color t = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.AccentColor;
            
            //lblNoteText.LinkColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.AccentColor;
            //lblNoteText.ActiveLinkColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.LightPrimaryColor;
            BLIO.Log("Popup constructed");            
        }

        private static String ColorToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        /// <summary>
        /// Generates a HTML Paragraph with the desired text color, text size and reminder text.
        /// </summary>
        /// <param name="previewSize">Used when previewing font-size changes</param>
        /// <returns></returns>
        private string GetPopupHTMLText(string color, string reminderText, float previewSize = 0)
        {                        
            float size = previewSize == 0 ? BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize : previewSize;            

            return "<p style=\"color: " + color + "; font-size: " + Math.Round(size * 1.28) + "px;\">" + reminderText + "</p>";
        }

        /// <summary>
        /// Transforms the part of the textbox string "API{url,data}" to the data from the API
        /// </summary>
        /// <param name="reminderText">The reminder text</param>
        /// <returns>The reminder text with the API{} replaced with the actual API value</returns>
        private async void TransformAPITextToValue(string color, string reminderText, float previewSize = 0)
        {
            float size = previewSize == 0 ? BLLocalDatabase.PopupDimension.GetPopupDimensions().FontNoteSize : previewSize;

            if (!reminderText.Contains("API{"))
                return;            

            try
            {
                int retryCount = 0;
                htmlLblText.Text = "<p style=\"color: " + color + "; font-size: " + Math.Round(size * 1.28) + "px;\">Loading...</p>";
                new Thread(async () =>
                {
                startMethod:



                    try
                    {
                        //if !hasinternetaccess Thread.Sleep(250); , 8 times, then error
                        
                        if(!BLIO.HasInternetAccess())
                        {
                            retryCount++;

                            if (retryCount <= 8)
                            {
                                Thread.Sleep(250);
                                goto startMethod;
                            }
                            else
                            {
                                htmlLblText.Invoke((MethodInvoker)(() =>
                                {
                                    htmlLblText.Text = "An error occured."  + rem.Note;
                                }));

                                return;
                            }
                        }

                        retryCount = 0;

                        //Interner access!

                        int startIndex = reminderText.IndexOf("API{");
                        int endIndex = -1;

                        bool found = false;
                        int count = 1;
                        while (!found)
                        {
                            if (reminderText[startIndex + count] == '}')
                            {
                                endIndex = startIndex + count;
                                found = true;
                            }
                            else
                                count++;
                        }

                        //[url, dataToPick]
                        string[] data = (reminderText.Substring(startIndex + 4, endIndex - (startIndex + 4))).Split(',');
                        JObject response = await BLIO.HttpRequest("GET", data[0]);
                        
                        //This is the API value the user is requesting. Replace API{url,data} with this.
                        string value = response.SelectTokens(data[1]).Select(t => t.Value<string>()).ToList()[0];

                        StringBuilder stringBuilder = new StringBuilder(reminderText);
                        stringBuilder.Remove(startIndex, endIndex - (startIndex) + 1);
                        stringBuilder.Insert(startIndex, value);
                        reminderText = stringBuilder.ToString();

                        //TODO if response.status != 200   stringBuilder.Insert(startIndex, "Error occured");
                        //Bitcoin: $60,001
                        //Superfarm: Error
                        //Reef: $0,04
                        //

                        //Still contains another API{} ? again...
                        if (reminderText.Contains("API{"))
                            goto startMethod;

                        htmlLblText.Invoke((MethodInvoker)(() =>
                        {
                            htmlLblText.Text = "<p style=\"color: " + color + "; font-size: " + Math.Round(size * 1.28) + "px;\">" + reminderText + "</p>";
                        }));
                        //return reminderText;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;

                        if (retryCount <= 8)
                        {
                            Thread.Sleep(250);
                            goto startMethod;
                        } else
                        {                           
                            htmlLblText.Text = "An error occured. (" + ex.GetType().ToString() + ")\r\n" + rem.Note;
                        }
                    }

                }).Start();

            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "TransformAPITextToValue() failed with " + ex.GetType().ToString());
                //return reminderText;
            }
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
            string reminderText = rem.Note != null ? rem.Note.Replace("\n", "<br>") : "( No text set )";
            string color = MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK ? "#e6e6e6" : "#323232";

            htmlLblText.Text = GetPopupHTMLText(color,reminderText);            
        }
        
      
        private void Popup_Load(object sender, EventArgs e)
        {
            try
            {                            
                BLIO.Log("Popup_load");

                if (BLLocalDatabase.Setting.Settings.PopupType == "SoundOnly")
                {
                    //Dont initialize, just play sound                    
                    PlayReminderSound();

                    if (rem.Id != -1) //Dont stop logic when the user is previewing an reminder
                    {
                        btnOk_Click(sender, e);
                        return;
                    }
                }

                string reminderText = rem.Note != null ? rem.Note.Replace("\n", "<br>") : "( No text set )";
                //White font if dark theme, Black text if light theme
                string color = MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK ? "#e6e6e6" : "#323232";

                if (rem.Note.Contains("API{"))
                    TransformAPITextToValue(color, reminderText);
                else
                    htmlLblText.Text = GetPopupHTMLText(color, reminderText);


                AdvancedReminderProperties avrProps = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
                List<AdvancedReminderFilesFolders> avrFF = BLLocalDatabase.AVRProperty.GetAVRFilesFolders(rem.Id);
                if (avrProps != null) //Not null? this reminder has advanced properties.
                {
                    BLIO.Log("Reminder " + rem.Id + " has advanced reminder properties!");
                    this.Visible = avrProps.ShowReminder == 1;

                    if (!string.IsNullOrWhiteSpace(avrProps.BatchScript))
                    {
                        //if (!this.Visible)
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

                if (rem.HttpId == null)
                {
                    BLIO.Log("Attempting to parse date...");
                    DateTime date = Convert.ToDateTime(rem.Date.Split(',')[0]);
                    BLIO.Log("Date succesfully converted (" + date + ")");

                    lblSmallDate.Text = date.ToShortDateString() + " " + date.ToShortTimeString();
                }
                else
                    lblSmallDate.Text = "Conditional";


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

                PlayReminderSound();

                FlashWindowHelper.Start(this);
                //this.MaximumSize = this.Size;

                if (BLLocalDatabase.Setting.Settings.PopupType == "AlwaysOnTop")
                {
                    this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
                    this.TopLevel = true;
                }
                else
                {
                    if (rem.Id != -1) //previewreminders should be topmost
                    {
                        this.TopMost = false;
                        this.WindowState = FormWindowState.Minimized;
                    }
                }


                this.Text = rem.Name;
                string hexColor = ColorToHex(MaterialSkin.MaterialSkinManager.Instance.ColorScheme.AccentColor);

                foreach (string link in GetLinks(htmlLblText.Text)) //Add <a href> to make it into an actual link
                    htmlLblText.Text = htmlLblText.Text.Replace(link, "<a href=\""+link+ "\" style=\"color: " + hexColor + "\"> " +link+"</a>");

                if (rem.Date == null && rem.HttpId == null)
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

        private void PlayReminderSound()
        {
            //Play the sound
            if (rem.SoundFilePath != null && rem.SoundFilePath != "")
            {
                if (File.Exists(rem.SoundFilePath))
                {                    
                    BLIO.Log("SoundFilePath not null / empty and exists on the hard drive!");
                    int volume = 100;

                    if (rem.Id == -1) //timer, set the volume set by the user
                        volume = (int)BLLocalDatabase.Setting.Settings.TimerVolume;
                    
                    BLIO.PlaySound(rem.SoundFilePath, volume);                    
                }
                else
                {
                    BLIO.Log("SoundFilePath not null / empty but doesn't exist on the hard drive!");
                    MaterialRemindMeBox.Show("Could not play " + Path.GetFileNameWithoutExtension(rem.SoundFilePath) + " located at \"" + rem.SoundFilePath + "\" \r\nDid you move,rename or delete the file ?\r\nThe sound effect has been removed from this reminder. If you wish to re-add it, select it from the drop-down list.", RemindMeBoxReason.OK);
                    //make sure its removed from the reminder
                    rem.SoundFilePath = "";
                }
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

        public List<string> GetLinks(string message)
        {
            List<string> list = new List<string>();
            Regex urlRx = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);

            MatchCollection matches = urlRx.Matches(message);
            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }
            return list;
        }

   
        private void Popup_SizeChanged(object sender, EventArgs e)
        {            
            RepositionControls();            
            var test = this.Height - (this.StatusBarHeight + this.ActionBarHeight);
            pnlText.Size = new Size(this.Width, (this.Height - 135));
            htmlLblText.Size = new Size(this.Width, (this.Height - 135));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (xClose)
                xClose = false;

            if (rem != null)
                rem = BLReminder.GetReminderById(rem.Id);

            if (rem == null)
                goto close;

            if(rem.HttpId != null)
            {
                //Conditional reminder
                HttpRequests req = BLLocalDatabase.HttpRequest.GetHttpRequestById(rem.Id);
                if (req.AfterPopup == "Stop")
                {
                    rem.Deleted = 1;
                    BLReminder.EditReminder(rem);
                    goto close;
                }
                else if(req.AfterPopup == "Repeat")
                {
                    goto close;
                }
                //else .... ?
            }

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
                    if (BLFormLogic.GetTextboxMinutes(tbPostpone) <= 0)
                        return;

                    DateTime newReminderTime = new DateTime();

                    if (!string.IsNullOrWhiteSpace(tbPostpone.Text)) //postpone option is x minutes                
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
                    BLIO.Log("Reminder postponed!");
                }
                else
                {
                    rem.PostponeDate = null;
                    BLReminder.UpdateReminder(rem);
                }
            }
            
            close:
            MUCReminders.Instance.UpdateCurrentPage(rem);
            BLIO.Log("Stopping media player & Closing popup");

            if (rem.Id != -1 && BLLocalDatabase.Setting.Settings.PopupType != "SoundOnly")
                BLIO.StopSound();

            this.Close();

            GC.Collect();
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

            if (e.CloseReason == CloseReason.UserClosing && xClose)
                btnOk_Click(sender, e);

            MaterialSkin.MaterialSkinManager.Instance.RemoveFormToManage(this);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnDisable clicked on reminder " + rem.Id);
            if (xClose)
                xClose = false;

            if (rem != null)
                rem = BLReminder.GetReminderById(rem.Id);

            if (rem == null)
                goto close;

            if (rem.Id != -1 && rem.Deleted == 0) //Don't do stuff if the id is -1, invalid. the id is set to -1 when the user previews an reminder
            {
                if (BLReminder.GetReminderById(rem.Id) == null)
                {
                    //The reminder popped up, it existed, but when pressing disable it doesn't exist anymore (maybe the user deleted it or tempered with the .db file)
                    BLIO.Log("DETECTED NONEXISTING REMINDER WITH ID " + rem.Id + ", Attempted to press OK on a reminder that somehow doesn't exist");
                    goto close;
                }

                rem.Enabled = 0;
                BLIO.Log("Reminder marked as disabled");
                BLReminder.EditReminder(rem);
                BLIO.Log("Disabled succesfully.");
            }


        close:
            MUCReminders.Instance.UpdateCurrentPage();
            BLIO.Log("Stopping media player & Closing popup");
            BLIO.StopSound();
            this.Close();

            GC.Collect();
        }
    }
}
