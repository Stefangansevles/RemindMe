namespace RemindMe
{
    partial class MUCSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbPopupType = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cbRemindMeMessages = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbOneHourBeforeNotification = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbQuicktimer = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbAdvancedReminders = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.tbTimerHotkey = new MaterialSkin.Controls.MaterialTextBox();
            this.tbCheckTimerHotKey = new MaterialSkin.Controls.MaterialTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trbVolume = new Bunifu.Framework.UI.BunifuSlider();
            this.lblVolume = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.cbAutoUpdate = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnRemoveSong = new MaterialSkin.Controls.MaterialButton();
            this.btnPreviewSong = new MaterialSkin.Controls.MaterialButton();
            this.cbSound = new MaterialSkin.Controls.MaterialComboBox();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.tmrSaveTimerVolume = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(9, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(173, 29);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Window Overlay";
            // 
            // cbPopupType
            // 
            this.cbPopupType.AutoResize = false;
            this.cbPopupType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbPopupType.Depth = 0;
            this.cbPopupType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbPopupType.DropDownHeight = 174;
            this.cbPopupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPopupType.DropDownWidth = 5;
            this.cbPopupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPopupType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbPopupType.FormattingEnabled = true;
            this.cbPopupType.Hint = "Popup type";
            this.cbPopupType.IntegralHeight = false;
            this.cbPopupType.ItemHeight = 43;
            this.cbPopupType.Items.AddRange(new object[] {
            "Always on top (Recommended)",
            "Minimized",
            "Sound Only"});
            this.cbPopupType.Location = new System.Drawing.Point(11, 43);
            this.cbPopupType.MaxDropDownItems = 4;
            this.cbPopupType.MouseState = MaterialSkin.MouseState.OUT;
            this.cbPopupType.Name = "cbPopupType";
            this.cbPopupType.Size = new System.Drawing.Size(310, 49);
            this.cbPopupType.TabIndex = 1;
            this.cbPopupType.SelectedIndexChanged += new System.EventHandler(this.cbPopupType_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.materialLabel2.Location = new System.Drawing.Point(13, 104);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(355, 14);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Always on top:  reminder will always be visible when it pops up\r\n\r\n";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.materialLabel3.Location = new System.Drawing.Point(13, 121);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(429, 14);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "Minimized:         reminder will show in the taskbar, but will not show until cli" +
    "cked";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel4.Location = new System.Drawing.Point(9, 148);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(110, 29);
            this.materialLabel4.TabIndex = 4;
            this.materialLabel4.Text = "Messages";
            // 
            // cbRemindMeMessages
            // 
            this.cbRemindMeMessages.AutoSize = true;
            this.cbRemindMeMessages.Checked = true;
            this.cbRemindMeMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemindMeMessages.Depth = 0;
            this.cbRemindMeMessages.Location = new System.Drawing.Point(9, 178);
            this.cbRemindMeMessages.Margin = new System.Windows.Forms.Padding(0);
            this.cbRemindMeMessages.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbRemindMeMessages.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbRemindMeMessages.Name = "cbRemindMeMessages";
            this.cbRemindMeMessages.Ripple = true;
            this.cbRemindMeMessages.Size = new System.Drawing.Size(219, 37);
            this.cbRemindMeMessages.TabIndex = 5;
            this.cbRemindMeMessages.Text = "Today\'s Reminders popup";
            this.cbRemindMeMessages.UseVisualStyleBackColor = true;
            this.cbRemindMeMessages.CheckedChanged += new System.EventHandler(this.cbEnableRemindMeMessages_OnChange);
            // 
            // cbOneHourBeforeNotification
            // 
            this.cbOneHourBeforeNotification.AutoSize = true;
            this.cbOneHourBeforeNotification.Checked = true;
            this.cbOneHourBeforeNotification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOneHourBeforeNotification.Depth = 0;
            this.cbOneHourBeforeNotification.Location = new System.Drawing.Point(9, 215);
            this.cbOneHourBeforeNotification.Margin = new System.Windows.Forms.Padding(0);
            this.cbOneHourBeforeNotification.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbOneHourBeforeNotification.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbOneHourBeforeNotification.Name = "cbOneHourBeforeNotification";
            this.cbOneHourBeforeNotification.Ripple = true;
            this.cbOneHourBeforeNotification.Size = new System.Drawing.Size(340, 37);
            this.cbOneHourBeforeNotification.TabIndex = 6;
            this.cbOneHourBeforeNotification.Text = "Remind 1 hour before the reminder pops up";
            this.cbOneHourBeforeNotification.UseVisualStyleBackColor = true;
            this.cbOneHourBeforeNotification.CheckedChanged += new System.EventHandler(this.cbEnableOneHourBeforeNotification_OnChange);
            // 
            // cbQuicktimer
            // 
            this.cbQuicktimer.AutoSize = true;
            this.cbQuicktimer.Depth = 0;
            this.cbQuicktimer.Location = new System.Drawing.Point(11, 329);
            this.cbQuicktimer.Margin = new System.Windows.Forms.Padding(0);
            this.cbQuicktimer.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbQuicktimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbQuicktimer.Name = "cbQuicktimer";
            this.cbQuicktimer.Ripple = true;
            this.cbQuicktimer.Size = new System.Drawing.Size(216, 37);
            this.cbQuicktimer.TabIndex = 9;
            this.cbQuicktimer.Text = "Enable quick timer hotkey";
            this.cbQuicktimer.UseVisualStyleBackColor = true;
            this.cbQuicktimer.CheckedChanged += new System.EventHandler(this.cbEnableQuicktimer_OnChange);
            // 
            // cbAdvancedReminders
            // 
            this.cbAdvancedReminders.AutoSize = true;
            this.cbAdvancedReminders.Depth = 0;
            this.cbAdvancedReminders.Location = new System.Drawing.Point(11, 292);
            this.cbAdvancedReminders.Margin = new System.Windows.Forms.Padding(0);
            this.cbAdvancedReminders.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbAdvancedReminders.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbAdvancedReminders.Name = "cbAdvancedReminders";
            this.cbAdvancedReminders.Ripple = true;
            this.cbAdvancedReminders.Size = new System.Drawing.Size(230, 37);
            this.cbAdvancedReminders.TabIndex = 8;
            this.cbAdvancedReminders.Text = "Enable advanced reminders";
            this.cbAdvancedReminders.UseVisualStyleBackColor = true;
            this.cbAdvancedReminders.CheckedChanged += new System.EventHandler(this.cbAdvancedReminders_OnChange);
            this.cbAdvancedReminders.Click += new System.EventHandler(this.cbAdvancedReminders_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel5.Location = new System.Drawing.Point(11, 262);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(109, 29);
            this.materialLabel5.TabIndex = 7;
            this.materialLabel5.Text = "Advanced";
            // 
            // tbTimerHotkey
            // 
            this.tbTimerHotkey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimerHotkey.Depth = 0;
            this.tbTimerHotkey.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbTimerHotkey.Hint = "Hotkey combination to set a quick timer                            ctrl/shift/alt" +
    " + ...";
            this.tbTimerHotkey.Location = new System.Drawing.Point(11, 372);
            this.tbTimerHotkey.MaxLength = 50;
            this.tbTimerHotkey.MouseState = MaterialSkin.MouseState.OUT;
            this.tbTimerHotkey.Multiline = false;
            this.tbTimerHotkey.Name = "tbTimerHotkey";
            this.tbTimerHotkey.ReadOnly = true;
            this.tbTimerHotkey.Size = new System.Drawing.Size(403, 50);
            this.tbTimerHotkey.TabIndex = 10;
            this.tbTimerHotkey.Text = "";
            this.tbTimerHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTimerHotkey_KeyUp);
            // 
            // tbCheckTimerHotKey
            // 
            this.tbCheckTimerHotKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCheckTimerHotKey.Depth = 0;
            this.tbCheckTimerHotKey.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbCheckTimerHotKey.Hint = "Hotkey combination to check currently running timers";
            this.tbCheckTimerHotKey.Location = new System.Drawing.Point(11, 432);
            this.tbCheckTimerHotKey.MaxLength = 50;
            this.tbCheckTimerHotKey.MouseState = MaterialSkin.MouseState.OUT;
            this.tbCheckTimerHotKey.Multiline = false;
            this.tbCheckTimerHotKey.Name = "tbCheckTimerHotKey";
            this.tbCheckTimerHotKey.ReadOnly = true;
            this.tbCheckTimerHotKey.Size = new System.Drawing.Size(403, 50);
            this.tbCheckTimerHotKey.TabIndex = 11;
            this.tbCheckTimerHotKey.Text = "";
            this.tbCheckTimerHotKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCheckTimerHotKey_KeyUp);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.trbVolume);
            this.panel1.Controls.Add(this.lblVolume);
            this.panel1.Controls.Add(this.materialLabel6);
            this.panel1.Controls.Add(this.cbAutoUpdate);
            this.panel1.Controls.Add(this.btnRemoveSong);
            this.panel1.Controls.Add(this.btnPreviewSong);
            this.panel1.Controls.Add(this.cbSound);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.tbCheckTimerHotKey);
            this.panel1.Controls.Add(this.cbPopupType);
            this.panel1.Controls.Add(this.tbTimerHotkey);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.cbQuicktimer);
            this.panel1.Controls.Add(this.materialLabel3);
            this.panel1.Controls.Add(this.cbAdvancedReminders);
            this.panel1.Controls.Add(this.materialLabel4);
            this.panel1.Controls.Add(this.materialLabel5);
            this.panel1.Controls.Add(this.cbRemindMeMessages);
            this.panel1.Controls.Add(this.cbOneHourBeforeNotification);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 492);
            this.panel1.TabIndex = 12;
            // 
            // trbVolume
            // 
            this.trbVolume.BackColor = System.Drawing.Color.Transparent;
            this.trbVolume.BackgroudColor = System.Drawing.Color.DarkGray;
            this.trbVolume.BorderRadius = 0;
            this.trbVolume.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.trbVolume.Location = new System.Drawing.Point(11, 542);
            this.trbVolume.MaximumValue = 100;
            this.trbVolume.Name = "trbVolume";
            this.trbVolume.Size = new System.Drawing.Size(153, 30);
            this.trbVolume.TabIndex = 131;
            this.trbVolume.Value = 0;
            this.trbVolume.ValueChanged += new System.EventHandler(this.trbVolume_ValueChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Depth = 0;
            this.lblVolume.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVolume.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblVolume.Location = new System.Drawing.Point(171, 545);
            this.lblVolume.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(136, 19);
            this.lblVolume.TabIndex = 130;
            this.lblVolume.Text = "Timer volume: 25%";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel6.Location = new System.Drawing.Point(11, 591);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(60, 29);
            this.materialLabel6.TabIndex = 121;
            this.materialLabel6.Text = "Other";
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Depth = 0;
            this.cbAutoUpdate.Location = new System.Drawing.Point(9, 620);
            this.cbAutoUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.cbAutoUpdate.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbAutoUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Ripple = true;
            this.cbAutoUpdate.Size = new System.Drawing.Size(289, 37);
            this.cbAutoUpdate.TabIndex = 120;
            this.cbAutoUpdate.Text = "Enable Auto-update (recommended)";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            this.cbAutoUpdate.CheckedChanged += new System.EventHandler(this.cbAutoUpdate_CheckedChanged);
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.AutoSize = false;
            this.btnRemoveSong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoveSong.Depth = 0;
            this.btnRemoveSong.DrawShadows = true;
            this.btnRemoveSong.HighEmphasis = true;
            this.btnRemoveSong.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveSong.Location = new System.Drawing.Point(370, 492);
            this.btnRemoveSong.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveSong.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(44, 38);
            this.btnRemoveSong.TabIndex = 119;
            this.btnRemoveSong.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveSong.UseAccentColor = false;
            this.btnRemoveSong.UseVisualStyleBackColor = true;
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
            // 
            // btnPreviewSong
            // 
            this.btnPreviewSong.AutoSize = false;
            this.btnPreviewSong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviewSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPreviewSong.Depth = 0;
            this.btnPreviewSong.DrawShadows = true;
            this.btnPreviewSong.HighEmphasis = true;
            this.btnPreviewSong.Icon = global::RemindMe.Properties.Resources.Play;
            this.btnPreviewSong.Location = new System.Drawing.Point(322, 492);
            this.btnPreviewSong.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviewSong.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviewSong.Name = "btnPreviewSong";
            this.btnPreviewSong.Size = new System.Drawing.Size(44, 37);
            this.btnPreviewSong.TabIndex = 118;
            this.btnPreviewSong.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviewSong.UseAccentColor = false;
            this.btnPreviewSong.UseVisualStyleBackColor = true;
            this.btnPreviewSong.Click += new System.EventHandler(this.btnPreviewSong_Click);
            // 
            // cbSound
            // 
            this.cbSound.AutoResize = false;
            this.cbSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbSound.Depth = 0;
            this.cbSound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbSound.DropDownHeight = 174;
            this.cbSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSound.DropDownWidth = 5;
            this.cbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSound.FormattingEnabled = true;
            this.cbSound.Hint = "Sound effect for timers";
            this.cbSound.IntegralHeight = false;
            this.cbSound.ItemHeight = 43;
            this.cbSound.Location = new System.Drawing.Point(11, 487);
            this.cbSound.MaxDropDownItems = 4;
            this.cbSound.MouseState = MaterialSkin.MouseState.OUT;
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(304, 49);
            this.cbSound.TabIndex = 12;
            this.cbSound.SelectedIndexChanged += new System.EventHandler(this.cbSound_SelectedIndexChanged);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // tmrSaveTimerVolume
            // 
            this.tmrSaveTimerVolume.Interval = 500;
            this.tmrSaveTimerVolume.Tick += new System.EventHandler(this.tmrSaveTimerVolume_Tick);
            // 
            // MUCSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "MUCSettings";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.UCWindowOverlay_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCSettings_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox cbPopupType;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialCheckbox cbRemindMeMessages;
        private MaterialSkin.Controls.MaterialCheckbox cbOneHourBeforeNotification;
        private MaterialSkin.Controls.MaterialCheckbox cbQuicktimer;
        private MaterialSkin.Controls.MaterialCheckbox cbAdvancedReminders;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox tbTimerHotkey;
        private MaterialSkin.Controls.MaterialTextBox tbCheckTimerHotKey;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialComboBox cbSound;
        private MaterialSkin.Controls.MaterialButton btnRemoveSong;
        private MaterialSkin.Controls.MaterialButton btnPreviewSong;
        private System.Windows.Forms.Timer tmrMusic;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialCheckbox cbAutoUpdate;
        private MaterialSkin.Controls.MaterialLabel lblVolume;
        private Bunifu.Framework.UI.BunifuSlider trbVolume;
        private System.Windows.Forms.Timer tmrSaveTimerVolume;
    }
}
