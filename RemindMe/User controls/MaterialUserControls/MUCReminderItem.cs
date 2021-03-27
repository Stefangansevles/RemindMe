using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Collections.Generic;

namespace RemindMe
{
    public partial class MUCReminderItem : UserControl
    {
        //Fill this user control with the details of this reminder
        private Reminder rem;

        private static readonly Color TEXT_HIGH_EMPHASIS_LIGHT = Color.FromArgb(222, 255, 255, 255); // Alpha 87%         
        private static readonly Color TEXT_HIGH_EMPHASIS_DARK = Color.FromArgb(222, 0, 0, 0); // Alpha 87%

        private static readonly Color BACKGROUND_LIGHT = Color.FromArgb(255, 255, 255, 255);        
        private static readonly Color BACKGROUND_DARK = Color.FromArgb(255, 80, 80, 80);

        public MUCReminderItem(Reminder rem)
        {
            InitializeComponent();
            this.Reminder = rem;

            AddFont(Properties.Resources.Roboto_Medium);

            MaterialSkin.MaterialSkinManager.Instance.ThemeChanged += UpdateTheme;
            
            //todo: make black/white
            tpInformation.SetToolTip(btnSettings, "Click for more options");
            tpInformation.SetToolTip(btnDisable, "Enable/Disable the reminder");
            tpInformation.SetToolTip(btnDelete, "Delete a reminder");
            tpInformation.SetToolTip(btnEdit, "Edit a reminder");

            //Assign right-click settings popup to these 2 panels
            this.MouseClick += rightClick_Settings;
            pnlActionButtons.MouseClick += rightClick_Settings;

            SetTooltips();        
        }

        private void SetTooltips()
        {
            if (this.Reminder == null)
                return;

            tooltipReminderNote.SetToolTip(this, this.Reminder.Note.Replace("\\n", Environment.NewLine));

            //Unsubscribe to make sure you dont subscribe twice
            tooltipReminderNote.Draw -= TooltipReminderNote_Draw;
            tooltipReminderNote.Popup -= TooltipReminderNote_Popup;

            tooltipReminderNote.Draw += TooltipReminderNote_Draw;
            tooltipReminderNote.Popup += TooltipReminderNote_Popup;


            AdvancedReminderProperties props = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
            if (props != null && !string.IsNullOrWhiteSpace(props.BatchScript))
            {
                tooltipAdvancedReminder.SetToolTip(pbDate, "This reminder has been configured to\r\nRun code on popup:\r\n\r\n" + props.BatchScript);

                //Unsubscribe to make sure you dont subscribe twice
                tooltipAdvancedReminder.Popup -= TooltipAdvancedReminder_Popup;
                tooltipAdvancedReminder.Draw -= TooltipAdvancedReminder_Draw;

                tooltipAdvancedReminder.Popup += TooltipAdvancedReminder_Popup;
                tooltipAdvancedReminder.Draw += TooltipAdvancedReminder_Draw;
            }
            else
                tooltipAdvancedReminder.SetToolTip(pbDate, "");            
        }

        private void TooltipAdvancedReminder_Draw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush b;
            AdvancedReminderProperties props = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);

            if (MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
            {
                b = new SolidBrush(BACKGROUND_DARK);

                g.FillRectangle(b, e.Bounds);

                TextRenderer.DrawText(e.Graphics, e.ToolTipText, new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel), new Point(e.Bounds.X + 5, e.Bounds.Y + 5), TEXT_HIGH_EMPHASIS_LIGHT);                
            }
            else
            {
                b = new SolidBrush(BACKGROUND_LIGHT);

                g.FillRectangle(b, e.Bounds);

                TextRenderer.DrawText(e.Graphics, e.ToolTipText, new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel), new Point(e.Bounds.X + 5, e.Bounds.Y + 5), TEXT_HIGH_EMPHASIS_DARK);                
            }

            b.Dispose();
            g.Dispose();            
        }

        private void TooltipAdvancedReminder_Popup(object sender, PopupEventArgs e)
        {
            AdvancedReminderProperties props = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
            e.ToolTipSize = TextRenderer.MeasureText("This reminder has been configured to\r\nRun code on popup:\r\n\r\n" + props.BatchScript, new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel));
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 8, e.ToolTipSize.Height + 10);
        }

        private void TooltipReminderNote_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(this.Reminder.Note.Replace("\\n", Environment.NewLine), new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel));
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 8, e.ToolTipSize.Height + 10);
        }

        private void TooltipReminderNote_Draw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush b;
            if (MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
            {
                b = new SolidBrush(BACKGROUND_DARK);              

                g.FillRectangle(b, e.Bounds);                        

                TextRenderer.DrawText(e.Graphics, e.ToolTipText, new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel), new Point(e.Bounds.X + 5, e.Bounds.Y + 5), TEXT_HIGH_EMPHASIS_LIGHT);                                                
            }
            else
            {
                b = new SolidBrush(BACKGROUND_LIGHT);

                g.FillRectangle(b, e.Bounds);

                TextRenderer.DrawText(e.Graphics, e.ToolTipText, new Font(pfc.Families[0], 13f, FontStyle.Regular, GraphicsUnit.Pixel), new Point(e.Bounds.X + 5, e.Bounds.Y + 5), TEXT_HIGH_EMPHASIS_DARK);                
            }
            g.Dispose();
            b.Dispose();
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
        /// Change this user controls's icons based on the theme
        /// </summary>
        /// <param name="theme"></param>
        public void UpdateTheme(object sender)
        {            
            if (this.Reminder == null)
            {
                btnDelete.Image = Properties.Resources.Bin_Disabled;
                btnEdit.Image = Properties.Resources.Edit_Disabled;
                btnSettings.Image = Properties.Resources.gearDisabled;
                btnDisable.Image = Properties.Resources.turnedOffTwo;                
            }
            else if (MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
            {
                btnEdit.Image = Properties.Resources.EditPenWhite;
                btnDelete.Image = Properties.Resources.Bin_white;
                btnDisable.Image = Properties.Resources.disableWhite;
                btnSettings.Image = Properties.Resources.gearWhite;

                //toolstrip
                previewToolStripMenuItem.Image = Properties.Resources.eyeWhite;
                duplicateToolStripMenuItem.Image = Properties.Resources.duplicateWhite;
                hideReminderToolStripMenuItem.Image = Properties.Resources.hideWhite;
                postponeToolStripMenuItem.Image = Properties.Resources.zzzWhite;
                removePostponeToolStripMenuItem.Image = Properties.Resources.zzzCancelWhite;
                skipToNextDateToolStripMenuItem.Image = Properties.Resources.skipWhite;                
                toolStripMenuItem1.Image = Properties.Resources.permanentelyWhite;                 //permanentelydelete toolstrip
                pbConditionalReminder.Image = Properties.Resources.wwwLight;                
            }
            else if (MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkin.MaterialSkinManager.Themes.LIGHT)
            {//Light
                btnEdit.Image = Properties.Resources.editPenDark;
                btnDelete.Image = Properties.Resources.binDark;
                btnDisable.Image = Properties.Resources.disableDark;
                btnSettings.Image = Properties.Resources.gearDark;

                //toolstrip
                previewToolStripMenuItem.Image = Properties.Resources.eyeDark;
                duplicateToolStripMenuItem.Image = Properties.Resources.duplicateDark;
                hideReminderToolStripMenuItem.Image = Properties.Resources.hideDark;
                postponeToolStripMenuItem.Image = Properties.Resources.zzzDark;
                removePostponeToolStripMenuItem.Image = Properties.Resources.zzzCancelDark;
                skipToNextDateToolStripMenuItem.Image = Properties.Resources.skipForwardDark;
                toolStripMenuItem1.Image = Properties.Resources.permanentelyDark;
                pbConditionalReminder.Image = Properties.Resources.wwwDark;                
            }

            BLFormLogic.SetImageAlpha(pbConditionalReminder, 50);

            if (this.Reminder != null && this.Reminder.Enabled == 0)
            {
                btnDisable.Image = Properties.Resources.turnedOffTwo;

                
                lblReminderName.Visible = false;
                lblReminderNameDisabled.Visible = true;
                lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
                lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            }
        }

        public bool IsEmpty()
        {
            return rem == null;
        }

        public Reminder Reminder
        {
            get
            {                
                return rem;
            }
            set
            {
                rem = value;
                if (rem == null)
                    Disable();
                else
                    Enable();
            }
        }

        /// <summary>
        /// Disable this reminder item. This occurs when the Reminder object is null. Initially on load of RemindMe, each "page" has 7 disabled items, which can be filled.
        /// </summary>
        private void Disable()
        {
            //Empty text
            lblDate.Text = "";
            lblReminderName.Text = "Empty.";
            lblRepeat.Text = "";


            lblReminderName.Visible = true;
            lblReminderNameDisabled.Visible = false;
            lblReminderName.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;            

            //Grayed out icons
            btnDelete.Image = Properties.Resources.Bin_Disabled;
            btnEdit.Image = Properties.Resources.Edit_Disabled;
            btnSettings.Image = Properties.Resources.gearDisabled;
            btnDisable.Image = Properties.Resources.turnedOffTwo;
            pbDate.BackgroundImage = Properties.Resources.RemindMe;
            pbConditionalReminder.Visible = false;
            

            //Reset location
            pbRepeat.Location = new Point(168, pbRepeat.Location.Y);
            lblRepeat.Location = new Point(195, lblRepeat.Location.Y);

            //Disable button click functionality
            btnSettings.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnDisable.Enabled = false;

            GC.Collect();
        }


        

        private void MUCReminderItem_Load(object sender, EventArgs e)
        {
            lblReminderNameDisabled.Font = new Font(pfc.Families[0], 14f, FontStyle.Strikeout, GraphicsUnit.Pixel);

            if (this.Reminder != null)
                Enable();
            else
                Disable();

            
        }

        //Loads reminder data into the controls
        private void Enable()
        {
            MaterialSkin.MaterialSkinManager.Themes theme = MaterialSkin.MaterialSkinManager.Instance.Theme;

            lblReminderName.Visible = true;
            lblReminderNameDisabled.Visible = false;
            lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            //Enabled icons
            if (theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
            {
                btnDelete.Image = Properties.Resources.Bin_white;
                btnEdit.Image = Properties.Resources.EditPenWhite;
                btnSettings.Image = Properties.Resources.gearWhite;                
                btnDisable.Image = Properties.Resources.disableWhite;
                pbConditionalReminder.Image = Properties.Resources.wwwLight;                
            }
            else
            {                
                btnDelete.Image = Properties.Resources.binDark;
                btnEdit.Image = Properties.Resources.editPenDark;
                btnSettings.Image = Properties.Resources.gearDark;
                btnDisable.Image = Properties.Resources.disableDark;
                pbConditionalReminder.Image = Properties.Resources.wwwDark;                
            }

            BLFormLogic.SetImageAlpha(pbConditionalReminder, 50);

            //if the reminder is disabled, use this icon instead
            if (rem.Enabled == 0)
            {
                btnDisable.Image = Properties.Resources.turnedOffTwo;

                lblReminderName.Visible = false;
                lblReminderNameDisabled.Visible = true;
                lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
                lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            }

            //Reset location
            pbRepeat.Location = new Point(168, pbRepeat.Location.Y);
            lblRepeat.Location = new Point(195, lblRepeat.Location.Y);

            if (rem.HttpId == null)
            {
                pbConditionalReminder.Visible = false;

                DateTime date = Convert.ToDateTime(rem.Date.Split(',')[0]);

                if (date.ToShortDateString() == DateTime.Now.ToShortDateString())
                    lblDate.Text = "Today  " + date.ToShortTimeString();
                else
                    lblDate.Text = date.ToShortDateString() + " " + date.ToShortTimeString();

                //Postpone logic
                if (rem.PostponeDate != null && !string.IsNullOrWhiteSpace(rem.PostponeDate))
                {
                    pbDate.BackgroundImage = Properties.Resources.RemindMeZzz;
                    Font font = new Font(lblRepeat.Font, FontStyle.Bold | FontStyle.Italic);
                    lblDate.Font = font;

                    if (Convert.ToDateTime(rem.PostponeDate).ToShortDateString() == DateTime.Now.ToShortDateString())
                        lblDate.Text = "Today " + Convert.ToDateTime(rem.PostponeDate).ToShortTimeString();
                    else
                        lblDate.Text = Convert.ToDateTime(rem.PostponeDate).ToShortDateString() + " " + Convert.ToDateTime(rem.PostponeDate).ToShortTimeString();
                }
                else
                {
                    pbDate.BackgroundImage = Properties.Resources.RemindMe;
                    Font font = new Font(lblRepeat.Font, FontStyle.Bold);
                    lblDate.Font = font;
                }
            }
            else
            {                
                pbConditionalReminder.Visible = true;
                lblDate.Text = "Conditional";
                pbDate.BackgroundImage = Properties.Resources.RemindMe;
            }
            

           

            AdvancedReminderProperties props = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
            if (props != null && !string.IsNullOrWhiteSpace(props.BatchScript))            
                pbDate.BackgroundImage = Properties.Resources.terminal1;

            //If some country has a longer date string, move the repeat icon/text more to the right so it doesnt overlap
            while (lblDate.Bounds.IntersectsWith(pbRepeat.Bounds))
            {
                pbRepeat.Location = new Point(pbRepeat.Location.X + 5, pbRepeat.Location.Y);
                lblRepeat.Location = new Point(lblRepeat.Location.X + 5, lblRepeat.Location.Y);
            }

            lblReminderName.Text = rem.Name;
            lblRepeat.Text = BLReminder.GetRepeatTypeText(rem);

            SetTooltips();

            /*if (rem.Enabled == 1)
            {
                btnDisable.Image = Properties.Resources.turnedOn;
                lblReminderName.ForeColor = Color.White;
                lblDate.ForeColor = Color.White;
                lblRepeat.ForeColor = Color.White;
            }
            else
            {
                //Disabled reminder, make text gray
                
                lblReminderName.ForeColor = Color.Silver;
                lblDate.ForeColor = Color.Silver;
                lblRepeat.ForeColor = Color.Silver;
            }*/

            btnSettings.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnDisable.Enabled = true;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            BLIO.Log("Disable button clicked on reminder item (" + rem.Id + ")");
            if (rem.Enabled == 1)
            {
                btnDisable.Image = Properties.Resources.turnedOffTwo;

                lblReminderName.Visible = false;
                lblReminderNameDisabled.Visible = true;
                lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
                lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
                rem.Enabled = 0;
            }
            else
            {
                btnDisable.Image = Properties.Resources.turnedOn;
                rem.Enabled = 1;
            }

            BLReminder.EditReminder(rem);
            MUCReminders.Instance.UpdateCurrentPage(rem);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {            
            BLIO.Log("Settings button clicked on reminder item (" + rem.Id + ")");
            
            HideOrShowRemovePostponeMenuItem(rem);
            HideOrShowSkipForwardMenuItem(rem);

            ToolStripItem skipToNextDateItem = ReminderMenuStrip.Items.Find("skipToNextDateToolStripMenuItem", false)[0];
            ToolStripItem removePostPoneItem = ReminderMenuStrip.Items.Find("removePostponeToolStripMenuItem", false)[0];
            ToolStripItem postPoneItem = ReminderMenuStrip.Items.Find("postponeToolStripMenuItem", false)[0];

            if (rem.HttpId != null)
            { //conditional reminder, don't ever show these options
                skipToNextDateItem.Visible = false;
                postPoneItem.Visible = false;
                removePostPoneItem.Visible = false;
            }
            
            ReminderMenuStrip.Show(Cursor.Position);            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MUCReminders.Instance.EditReminder(rem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BLIO.Log("Delete button clicked on reminder item (" + rem.Id + ")");
            BLReminder.DeleteReminder(rem);

            Reminder copy = new Reminder(); // 
            copy.Id = rem.Id;
            copy.Deleted = rem.Deleted;
            copy.HttpId = rem.HttpId;

            this.Reminder = null;            
            MUCReminders.Instance.UpdateCurrentPage(copy);
            copy = null;
        }

        private void previewThisReminderNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If you preview in 5 seconds, then delete the reminder, it will preview the new reminder that is loaded into MUCReminderItem, I'm aware of this and it is not something worth putting effort into            
            PreviewReminder();            
        }
        private void PreviewReminder()
        {
            if (rem == null)
            {
                BLIO.Log("Reminder in PreviewReminder() is null. Interesting... ;)");
                MaterialMessageFormManager.MakeMessagePopup("Could not preview that reminder. It doesn't exist anymore!", 4, "Error");
                return;
            }

            BLIO.Log("Previewing reminder with id " + rem.Id);
            Reminder previewRem = CopyReminder(rem);
            previewRem.Id = -1; //give the >temporary< reminder an invalid id, so that the real reminder won't be altered            
            
            MaterialPopup p = new MaterialPopup(previewRem);
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(p);
            p.Show();

            
            

            new Thread(() =>
            {
                //Log an entry to the database, for data!                
                try
                {
                    try
                    {
                        BLOnlineDatabase.PreviewCount++;
                    }
                    catch (ArgumentException ex)
                    {
                        BLIO.Log("Exception at BLOnlineDatabase.PreviewCount++. -> " + ex.Message);
                        BLIO.WriteError(ex, ex.Message, true);
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.PreviewCount++. -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
            }).Start();

            this.Invalidate();
            this.Refresh();
        }
        private Reminder CopyReminder(Reminder rem)
        {
            //Wouldn't it be nice if there was some sort of general C# method that copies objects?
            Reminder copy = new Reminder();
            copy.Corrupted = rem.Corrupted;
            copy.Date = rem.Date;
            copy.DayOfMonth = rem.DayOfMonth;
            copy.Deleted = rem.Deleted;
            copy.EnableAdvancedReminder = rem.EnableAdvancedReminder;
            copy.Enabled = rem.Enabled;
            copy.EveryXCustom = rem.EveryXCustom;
            copy.Hide = rem.Hide;
            copy.Id = -1;
            copy.Name = rem.Name;
            copy.Note = rem.Note;
            copy.PostponeDate = rem.PostponeDate;
            copy.RepeatDays = rem.RepeatDays;
            copy.RepeatType = rem.RepeatType;
            copy.SoundFilePath = rem.SoundFilePath;
            copy.UpdateTime = rem.UpdateTime;
            copy.HttpId = rem.HttpId;
            return copy;
        }

        private async void previewThisReminderIn5SecondsToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            PreviewReminder();
        }

        private async void previewThisReminderIn10SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Delay(10000);
            PreviewReminder();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Duplicate (" + rem.Id + ")");
            BLIO.Log("Setting up the duplicating process...");
            BLIO.Log("duplicating reminder with id " + rem.Id);
            long oldRemId = rem.Id;
            long newRemId = BLReminder.PushReminderToDatabase(rem);

            AdvancedReminderProperties props = BLLocalDatabase.AVRProperty.GetAVRProperties(rem.Id);
            if (props != null)
            {
                props.Remid = newRemId;
                BLLocalDatabase.AVRProperty.InsertAVRProperties(props);
            }

            HttpRequests req = BLLocalDatabase.HttpRequest.GetHttpRequestById(oldRemId);            
            if (req != null)
            {
                long oldHttpId = req.Id;
                req.reminderId = newRemId;
                long newHttpId = BLLocalDatabase.HttpRequest.InsertHttpRequest(req);
                List<HttpRequestCondition> conditions = BLLocalDatabase.HttpRequestConditions.GetConditions(oldHttpId);
                foreach(HttpRequestCondition cond in conditions)
                {
                    cond.RequestId = newHttpId;
                    BLLocalDatabase.HttpRequestConditions.InsertCondition(cond);
                }

                //Now update the duplicated reminder with the httprequest            
                Reminder dup = BLReminder.GetReminderById(newRemId);
                dup.HttpId = req.Id;
                BLReminder.EditReminder(dup);
            }                        

            BLIO.Log("reminder duplicated.");
            MUCReminders.Instance.UpdateCurrentPage();

            new Thread(() =>
            {
                //Log an entry to the database, for data!                
                try
                {
                    BLOnlineDatabase.DuplicateCount++;
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.DuplicateCount++. -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
                finally
                {
                    GC.Collect();
                }
            }).Start();
        }
        /// <summary>
        /// When right-clicking reminder(s), this method will hide the skip to next date option if one of the reminder(s) does not have a next date.
        /// </summary>
        private void HideOrShowSkipForwardMenuItem(Reminder reminder)
        {
            //Check if the repeat type is NONE, and check if the amount of dates after split by comma is smaller or equal than 1.
            //If this is the case, we have a reminder that doesn't have a next day, and therefore is not repeatable
            //Then simply return if the count is equal to 0. No reminders that aren't repeatable? return true;
            bool hideMenuItem = reminder.RepeatType == ReminderRepeatType.NONE.ToString() && rem.Date.Split(',').Length <= 1;


            //The option
            ToolStripItem skipToNextDateItem = ReminderMenuStrip.Items.Find("skipToNextDateToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Skip to next date" option based on the boolean hideMenuItem
            skipToNextDateItem.Visible = !hideMenuItem;
            BLIO.Log("Showing skip to next date option from right click menu: " + hideMenuItem);

        }

        /// <summary>
        /// When right-clicking a reminder, this method will hide the remove postpone option if the reminder does not have a postpone date.
        /// </summary>
        private void HideOrShowRemovePostponeMenuItem(Reminder reminder)
        {
            //Check if there is even a single reminder that is not postponed from the selected reminders. We only want to show this option if every
            //selected reminder is postponed
            bool hideMenuItem = rem.PostponeDate != null && !string.IsNullOrWhiteSpace(rem.PostponeDate);

            //The option
            ToolStripItem removePostponeItem = ReminderMenuStrip.Items.Find("removePostponeToolStripMenuItem", false)[0];

            //determine if we are going to hide the "Remove postpone" option based on the boolean hideMenuItem

            removePostponeItem.Visible = hideMenuItem;
            BLIO.Log("Showing remove postpone option from right click menu: " + hideMenuItem);

        }

        private void hideReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Hide (" + rem.Id + ")");

            string message = "You can hide reminders with this option. The reminder will not be deleted, you just won't be able to see it"
                 + " in the list of reminders. This creates a sense of surprise.\r\n\r\nDo you wish to hide this reminder?";

            BLIO.Log("Attempting to hide reminder(s)");
            if (BLLocalDatabase.Setting.HideReminderOptionEnabled || MaterialRemindMeBox.Show(message, RemindMeBoxReason.YesNo, true) == DialogResult.Yes)
            {
                //Enable the hide flag here                                
                rem.Hide = 1;
                BLIO.Log("Marked reminder with id " + rem.Id + " as hidden");
                BLReminder.EditReminder(rem);
                this.Reminder = null;
                MUCReminders.Instance.UpdateCurrentPage();

                new Thread(() =>
                {
                    //Log an entry to the database, for data!                    
                    try
                    {
                        BLOnlineDatabase.HideCount++;
                    }
                    catch (ArgumentException ex)
                    {
                        BLIO.Log("Exception at BLOnlineDatabase.HideCount++. -> " + ex.Message);
                        BLIO.WriteError(ex, ex.Message, true);
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }).Start();
            }
            else
                BLIO.Log("Attempting to hide reminder(s) failed.");
        }

        private void enableWarningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Attempting to re-enable the hide warning on reminders....");

            //Get the current settings from the database
            Settings currentSettings = BLLocalDatabase.Setting.Settings;

            //Set the hiding of the confirmation on hiding a reminder to false
            currentSettings.HideReminderConfirmation = 0;

            //Make the right-click menu option invisible
            enableWarningToolStripMenuItem.Visible = false;

            //Push the updated settings to the database
            BLLocalDatabase.Setting.UpdateSettings(currentSettings);

            BLIO.Log("Re-enabled the hide warning on reminders!");
        }

        private void postponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Postpone (" + rem.Id + ")");
            int minutes = MaterialRemindMePrompt.ShowMinutes("Select your postpone time", "(in minutes or in xhxxm format (1h20m) )");

            if (minutes <= 0)
            {
                BLIO.Log("Postponing reminder with " + minutes + " minutes DENIED.");
                return;
            }

            if (rem.PostponeDate == null)//No postpone yet, create it
                rem.PostponeDate = Convert.ToDateTime(rem.Date.Split(',')[0]).AddMinutes(minutes).ToShortDateString() + " " + Convert.ToDateTime(rem.Date.Split(',')[0]).AddMinutes(minutes).ToShortTimeString();
            else//Already a postponedate, add the time to that date                
                rem.PostponeDate = Convert.ToDateTime(rem.PostponeDate).AddMinutes(minutes).ToShortDateString() + " " + Convert.ToDateTime(rem.PostponeDate).AddMinutes(minutes).ToShortTimeString();

            BLReminder.EditReminder(rem);//Push changes

            MUCReminders.Instance.UpdateCurrentPage();

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
                finally
                {
                    GC.Collect();
                }
            }).Start();
        }

        private void removePostponeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Remove postpone (" + rem.Id + ")");
            rem.PostponeDate = null;
            BLReminder.EditReminder(rem);

            pbRepeat.Location = new Point(168, pbRepeat.Location.Y);
            lblRepeat.Location = new Point(195, lblRepeat.Location.Y);
            Enable();
            MUCReminders.Instance.UpdateCurrentPage();
        }

        private void skipToNextDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Skip (" + rem.Id + ")");
            //The reminder object has now been altered. The first date has been removed and has been "skipped" to it's next date
            BLReminder.SkipToNextReminderDate(rem);
            //push the altered reminder to the database 
            BLReminder.EditReminder(rem);

            //Refresh to show changes
            MUCReminders.Instance.UpdateCurrentPage();

            new Thread(() =>
            {
                //Log an entry to the database, for data!                
                try
                {
                    BLOnlineDatabase.SkipCount++;
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.SkipCount++. -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
                finally
                {
                    GC.Collect();
                }
            }).Start();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BLIO.Log("Toolstrip option clicked: Permanentely delete (" + rem.Id + ")");
            if (MaterialRemindMeBox.Show("Are you really sure you wish to permanentely delete \"" + rem.Name + "\" ?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
            {
                BLIO.Log("Permanentely deleting reminder with id " + rem.Id + " ...");
                BLReminder.PermanentelyDeleteReminder(rem);
                BLIO.Log("Reminder permanentely deleted.");

                this.Reminder = null;
                MUCReminders.Instance.UpdateCurrentPage(rem);

                new Thread(() =>
                {
                    //Log an entry to the database, for data!                    
                    try
                    {
                        BLOnlineDatabase.PermanentelyDeleteCount++;
                    }
                    catch (ArgumentException ex)
                    {
                        BLIO.Log("Exception at BLOnlineDatabase.PermanentelyDeleteCount++. -> " + ex.Message);
                        BLIO.WriteError(ex, ex.Message, true);
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }).Start();
            }
            else
                BLIO.Log("Permanent deletion of reminder " + rem.Id + " cancelled.");
        }

        private void bunifuGradientPanel1_DoubleClick(object sender, EventArgs e)
        {
            BLIO.Log("Reminder item double clicked");
            btnEdit_Click(sender, e);
        }


        private void rightClick_Settings(object sender, MouseEventArgs e)
        {
            //Right-click settings
            if (e.Button == MouseButtons.Right && rem != null)
            {
                BLIO.Log("Right mouse button click on reminder item (" + rem.Id + ")");
                btnSettings_Click(sender, e);
            }
        }

        private void MUCReminderItem_VisibleChanged(object sender, EventArgs e)
        {
            btnShadow.BringToFront();
            pnlSideColor.BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.DarkPrimaryColor;

            pnlSideColor.Visible = !MaterialForm1.Instance.DrawerUseColors;            
        }

        private void lblReminderNameDisabled_VisibleChanged(object sender, EventArgs e)
        {
            lblReminderNameDisabled.Font = new Font(pfc.Families[0], 14f, FontStyle.Strikeout, GraphicsUnit.Pixel);
        }

        private void lblReminderName_TextChanged(object sender, EventArgs e)
        {
            lblReminderNameDisabled.Text = lblReminderName.Text;
            
        }

        //Workaround fix, the label can reset to regular text, instead of bold-ish material text
        public void RefreshLabelFont()
        {
            if(rem != null && rem.Enabled == 1)
                lblReminderName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
        }

        private void MUCReminderItem_MouseHover(object sender, EventArgs e)
        {                        
        }

        private void MUCReminderItem_MouseLeave(object sender, EventArgs e)
        {
            //tooltipReminderNote.Hide(this);
        }
    }
}
