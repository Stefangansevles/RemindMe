namespace RemindMe
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
            this.cbQuicktimer = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTimerHotkey = new System.Windows.Forms.TextBox();
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
            this.label8.Location = new System.Drawing.Point(49, 347);
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
            this.cbAdvancedReminders.Location = new System.Drawing.Point(23, 347);
            this.cbAdvancedReminders.Name = "cbAdvancedReminders";
            this.cbAdvancedReminders.Size = new System.Drawing.Size(20, 20);
            this.cbAdvancedReminders.TabIndex = 100;
            this.cbAdvancedReminders.OnChange += new System.EventHandler(this.cbAdvancedReminders_OnChange);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
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
            // cbQuicktimer
            // 
            this.cbQuicktimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbQuicktimer.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbQuicktimer.Checked = false;
            this.cbQuicktimer.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbQuicktimer.ForeColor = System.Drawing.Color.White;
            this.cbQuicktimer.Location = new System.Drawing.Point(23, 266);
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
            this.label10.Location = new System.Drawing.Point(49, 268);
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
            this.label9.Location = new System.Drawing.Point(20, 295);
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
            this.tbTimerHotkey.Location = new System.Drawing.Point(22, 315);
            this.tbTimerHotkey.Name = "tbTimerHotkey";
            this.tbTimerHotkey.ReadOnly = true;
            this.tbTimerHotkey.Size = new System.Drawing.Size(227, 22);
            this.tbTimerHotkey.TabIndex = 105;
            this.tbTimerHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTimerHotkey_KeyUp);
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
    }
}
