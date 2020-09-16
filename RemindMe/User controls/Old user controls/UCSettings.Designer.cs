﻿namespace RemindMe
{
    partial class UCSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPopupType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRemindMeMessages = new Bunifu.Framework.UI.BunifuCheckbox();
            this.cbOneHourBeforeNotification = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAdvancedReminders = new Bunifu.Framework.UI.BunifuCheckbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInvisible = new System.Windows.Forms.Label();
            this.btnMin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPlus = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCheckTimerHotKey = new System.Windows.Forms.TextBox();
            this.btnPreviewSong = new Bunifu.Framework.UI.BunifuTileButton();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemoveSong = new Bunifu.Framework.UI.BunifuTileButton();
            this.cbSound = new System.Windows.Forms.ComboBox();
            this.cbQuicktimer = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTimerHotkey = new System.Windows.Forms.TextBox();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Window overlay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Popup type:";
            // 
            // cbPopupType
            // 
            this.cbPopupType.BackColor = System.Drawing.Color.DimGray;
            this.cbPopupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
            this.cbPopupType.ForeColor = System.Drawing.Color.White;
            this.cbPopupType.FormattingEnabled = true;
            this.cbPopupType.ItemHeight = 13;
            this.cbPopupType.Items.AddRange(new object[] {
            "Always on top (Recommended)",
            "Minimized"});
            this.cbPopupType.Location = new System.Drawing.Point(117, 44);
            this.cbPopupType.Name = "cbPopupType";
            this.cbPopupType.Size = new System.Drawing.Size(215, 21);
            this.cbPopupType.TabIndex = 67;
            this.cbPopupType.SelectedIndexChanged += new System.EventHandler(this.cbPopupType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(542, 34);
            this.label3.TabIndex = 68;
            this.label3.Text = "Always on top:  reminder will always be visible when it pops up\r\nMinimized:      " +
    "  reminder will show in the taskbar, but will not show until clicked\r\n";
            // 
            // cbRemindMeMessages
            // 
            this.cbRemindMeMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbRemindMeMessages.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbRemindMeMessages.Checked = true;
            this.cbRemindMeMessages.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbRemindMeMessages.ForeColor = System.Drawing.Color.White;
            this.cbRemindMeMessages.Location = new System.Drawing.Point(23, 176);
            this.cbRemindMeMessages.Name = "cbRemindMeMessages";
            this.cbRemindMeMessages.Size = new System.Drawing.Size(20, 20);
            this.cbRemindMeMessages.TabIndex = 94;
            this.cbRemindMeMessages.OnChange += new System.EventHandler(this.cbEnableRemindMeMessages_OnChange);
            // 
            // cbOneHourBeforeNotification
            // 
            this.cbOneHourBeforeNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbOneHourBeforeNotification.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbOneHourBeforeNotification.Checked = true;
            this.cbOneHourBeforeNotification.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbOneHourBeforeNotification.ForeColor = System.Drawing.Color.White;
            this.cbOneHourBeforeNotification.Location = new System.Drawing.Point(23, 202);
            this.cbOneHourBeforeNotification.Name = "cbOneHourBeforeNotification";
            this.cbOneHourBeforeNotification.Size = new System.Drawing.Size(20, 20);
            this.cbOneHourBeforeNotification.TabIndex = 95;
            this.cbOneHourBeforeNotification.OnChange += new System.EventHandler(this.cbEnableOneHourBeforeNotification_OnChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(49, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 17);
            this.label5.TabIndex = 96;
            this.label5.Text = "Today\'s Reminders popup";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(49, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 17);
            this.label6.TabIndex = 97;
            this.label6.Text = "Remind 1 hour before the reminder pops up";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 23);
            this.label7.TabIndex = 98;
            this.label7.Text = "Messages";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 99;
            this.label4.Text = "Advanced";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(49, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 17);
            this.label8.TabIndex = 101;
            this.label8.Text = "Enable advanced reminders";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbAdvancedReminders
            // 
            this.cbAdvancedReminders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbAdvancedReminders.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbAdvancedReminders.Checked = false;
            this.cbAdvancedReminders.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbAdvancedReminders.ForeColor = System.Drawing.Color.White;
            this.cbAdvancedReminders.Location = new System.Drawing.Point(23, 270);
            this.cbAdvancedReminders.Name = "cbAdvancedReminders";
            this.cbAdvancedReminders.Size = new System.Drawing.Size(20, 20);
            this.cbAdvancedReminders.TabIndex = 100;
            this.cbAdvancedReminders.OnChange += new System.EventHandler(this.cbAdvancedReminders_OnChange);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblInvisible);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbCheckTimerHotKey);
            this.panel1.Controls.Add(this.btnPreviewSong);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnRemoveSong);
            this.panel1.Controls.Add(this.cbSound);
            this.panel1.Controls.Add(this.cbQuicktimer);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbTimerHotkey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbAdvancedReminders);
            this.panel1.Controls.Add(this.cbPopupType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbRemindMeMessages);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbOneHourBeforeNotification);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 436);
            this.panel1.TabIndex = 102;
            // 
            // lblInvisible
            // 
            this.lblInvisible.AutoSize = true;
            this.lblInvisible.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblInvisible.ForeColor = System.Drawing.Color.White;
            this.lblInvisible.Location = new System.Drawing.Point(573, 503);
            this.lblInvisible.Name = "lblInvisible";
            this.lblInvisible.Size = new System.Drawing.Size(63, 17);
            this.lblInvisible.TabIndex = 120;
            this.lblInvisible.Text = "invisible";
            // 
            // btnMin
            // 
            this.btnMin.Activecolor = System.Drawing.Color.DimGray;
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.BorderRadius = 5;
            this.btnMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMin.ButtonText = " -";
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.DisabledColor = System.Drawing.Color.Gray;
            this.btnMin.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMin.Iconimage = null;
            this.btnMin.Iconimage_right = null;
            this.btnMin.Iconimage_right_Selected = null;
            this.btnMin.Iconimage_Selected = null;
            this.btnMin.IconMarginLeft = 0;
            this.btnMin.IconMarginRight = 0;
            this.btnMin.IconRightVisible = true;
            this.btnMin.IconRightZoom = 0D;
            this.btnMin.IconVisible = true;
            this.btnMin.IconZoom = 50D;
            this.btnMin.IsTab = false;
            this.btnMin.Location = new System.Drawing.Point(180, 491);
            this.btnMin.Name = "btnMin";
            this.btnMin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMin.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnMin.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMin.selected = false;
            this.btnMin.Size = new System.Drawing.Size(25, 18);
            this.btnMin.TabIndex = 119;
            this.btnMin.Text = " -";
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMin.Textcolor = System.Drawing.Color.White;
            this.btnMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Activecolor = System.Drawing.Color.DimGray;
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.BorderRadius = 5;
            this.btnPlus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPlus.ButtonText = "+";
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.DisabledColor = System.Drawing.Color.Gray;
            this.btnPlus.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPlus.Iconimage = null;
            this.btnPlus.Iconimage_right = null;
            this.btnPlus.Iconimage_right_Selected = null;
            this.btnPlus.Iconimage_Selected = null;
            this.btnPlus.IconMarginLeft = 0;
            this.btnPlus.IconMarginRight = 0;
            this.btnPlus.IconRightVisible = true;
            this.btnPlus.IconRightZoom = 0D;
            this.btnPlus.IconVisible = true;
            this.btnPlus.IconZoom = 50D;
            this.btnPlus.IsTab = false;
            this.btnPlus.Location = new System.Drawing.Point(207, 491);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlus.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnPlus.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPlus.selected = false;
            this.btnPlus.Size = new System.Drawing.Size(25, 18);
            this.btnPlus.TabIndex = 118;
            this.btnPlus.Text = "+";
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlus.Textcolor = System.Drawing.Color.White;
            this.btnPlus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(23, 492);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 17);
            this.label13.TabIndex = 117;
            this.label13.Text = "Adjust side panel text";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(21, 387);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(373, 17);
            this.label12.TabIndex = 116;
            this.label12.Text = "Hotkey combination to check currently running timers:";
            // 
            // tbCheckTimerHotKey
            // 
            this.tbCheckTimerHotKey.BackColor = System.Drawing.Color.DimGray;
            this.tbCheckTimerHotKey.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.tbCheckTimerHotKey.ForeColor = System.Drawing.Color.White;
            this.tbCheckTimerHotKey.Location = new System.Drawing.Point(23, 407);
            this.tbCheckTimerHotKey.Name = "tbCheckTimerHotKey";
            this.tbCheckTimerHotKey.ReadOnly = true;
            this.tbCheckTimerHotKey.Size = new System.Drawing.Size(227, 22);
            this.tbCheckTimerHotKey.TabIndex = 115;
            this.tbCheckTimerHotKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCheckTimerHotKey_KeyUp);
            // 
            // btnPreviewSong
            // 
            this.btnPreviewSong.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviewSong.color = System.Drawing.Color.Transparent;
            this.btnPreviewSong.colorActive = System.Drawing.Color.DarkGray;
            this.btnPreviewSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewSong.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnPreviewSong.ForeColor = System.Drawing.Color.Transparent;
            this.btnPreviewSong.Image = global::RemindMe.Properties.Resources.Play;
            this.btnPreviewSong.ImagePosition = 0;
            this.btnPreviewSong.ImageZoom = 100;
            this.btnPreviewSong.LabelPosition = 0;
            this.btnPreviewSong.LabelText = "";
            this.btnPreviewSong.Location = new System.Drawing.Point(256, 457);
            this.btnPreviewSong.Margin = new System.Windows.Forms.Padding(6);
            this.btnPreviewSong.Name = "btnPreviewSong";
            this.btnPreviewSong.Size = new System.Drawing.Size(24, 24);
            this.btnPreviewSong.TabIndex = 114;
            this.btnPreviewSong.Click += new System.EventHandler(this.btnPreviewSong_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(20, 435);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(296, 17);
            this.label11.TabIndex = 113;
            this.label11.Text = "Sound effect to play when a timer pops up:";
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveSong.color = System.Drawing.Color.Transparent;
            this.btnRemoveSong.colorActive = System.Drawing.Color.DarkGray;
            this.btnRemoveSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSong.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnRemoveSong.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveSong.Image = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveSong.ImagePosition = 0;
            this.btnRemoveSong.ImageZoom = 100;
            this.btnRemoveSong.LabelPosition = 0;
            this.btnRemoveSong.LabelText = "";
            this.btnRemoveSong.Location = new System.Drawing.Point(285, 457);
            this.btnRemoveSong.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveSong.TabIndex = 112;
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
            // 
            // cbSound
            // 
            this.cbSound.BackColor = System.Drawing.Color.DimGray;
            this.cbSound.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.cbSound.ForeColor = System.Drawing.Color.White;
            this.cbSound.FormattingEnabled = true;
            this.cbSound.ItemHeight = 16;
            this.cbSound.Location = new System.Drawing.Point(22, 457);
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(225, 24);
            this.cbSound.TabIndex = 111;
            this.cbSound.SelectedIndexChanged += new System.EventHandler(this.cbSound_SelectedIndexChanged);
            // 
            // cbQuicktimer
            // 
            this.cbQuicktimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbQuicktimer.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbQuicktimer.Checked = false;
            this.cbQuicktimer.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbQuicktimer.ForeColor = System.Drawing.Color.White;
            this.cbQuicktimer.Location = new System.Drawing.Point(23, 298);
            this.cbQuicktimer.Name = "cbQuicktimer";
            this.cbQuicktimer.Size = new System.Drawing.Size(20, 20);
            this.cbQuicktimer.TabIndex = 108;
            this.cbQuicktimer.OnChange += new System.EventHandler(this.cbEnableQuicktimer_OnChange);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(49, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 17);
            this.label10.TabIndex = 107;
            this.label10.Text = "Enable quick timer hotkey";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(284, 17);
            this.label9.TabIndex = 106;
            this.label9.Text = "Hotkey combination to set a quick timer:";
            // 
            // tbTimerHotkey
            // 
            this.tbTimerHotkey.BackColor = System.Drawing.Color.DimGray;
            this.tbTimerHotkey.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.tbTimerHotkey.ForeColor = System.Drawing.Color.White;
            this.tbTimerHotkey.Location = new System.Drawing.Point(22, 357);
            this.tbTimerHotkey.Name = "tbTimerHotkey";
            this.tbTimerHotkey.ReadOnly = true;
            this.tbTimerHotkey.Size = new System.Drawing.Size(227, 22);
            this.tbTimerHotkey.TabIndex = 105;
            this.tbTimerHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTimerHotkey_KeyUp);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // UCSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel1);
            this.Name = "UCSettings";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCWindowOverlay_Load);
            this.VisibleChanged += new System.EventHandler(this.UCSettings_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbPopupType;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuCheckbox cbRemindMeMessages;
        private Bunifu.Framework.UI.BunifuCheckbox cbOneHourBeforeNotification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuCheckbox cbAdvancedReminders;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tbTimerHotkey;
        private Bunifu.Framework.UI.BunifuCheckbox cbQuicktimer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private Bunifu.Framework.UI.BunifuTileButton btnRemoveSong;
        public System.Windows.Forms.ComboBox cbSound;
        private Bunifu.Framework.UI.BunifuTileButton btnPreviewSong;
        private System.Windows.Forms.Timer tmrMusic;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox tbCheckTimerHotKey;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuFlatButton btnMin;
        private Bunifu.Framework.UI.BunifuFlatButton btnPlus;
        private System.Windows.Forms.Label lblInvisible;
    }
}
