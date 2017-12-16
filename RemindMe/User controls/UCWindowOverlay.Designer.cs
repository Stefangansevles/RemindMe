namespace RemindMe
{
    partial class UCWindowOverlay
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbEnableRemindMeMessages = new Bunifu.Framework.UI.BunifuCheckbox();
            this.cbEnableOneHourBeforeNotification = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(231, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage windows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
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
            this.cbPopupType.Location = new System.Drawing.Point(157, 89);
            this.cbPopupType.Name = "cbPopupType";
            this.cbPopupType.Size = new System.Drawing.Size(247, 21);
            this.cbPopupType.TabIndex = 67;
            this.cbPopupType.SelectedIndexChanged += new System.EventHandler(this.cbPopupType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 68);
            this.label3.TabIndex = 68;
            this.label3.Text = "Always on top: reminder will always be visible when it pops up\r\n\r\nMinimized: remi" +
    "nder will show in the taskbar, but will not show\r\nuntil clicked\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "Enable messages for:";
            // 
            // cbEnableRemindMeMessages
            // 
            this.cbEnableRemindMeMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbEnableRemindMeMessages.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbEnableRemindMeMessages.Checked = true;
            this.cbEnableRemindMeMessages.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbEnableRemindMeMessages.ForeColor = System.Drawing.Color.White;
            this.cbEnableRemindMeMessages.Location = new System.Drawing.Point(18, 284);
            this.cbEnableRemindMeMessages.Name = "cbEnableRemindMeMessages";
            this.cbEnableRemindMeMessages.Size = new System.Drawing.Size(20, 20);
            this.cbEnableRemindMeMessages.TabIndex = 94;
            this.cbEnableRemindMeMessages.OnChange += new System.EventHandler(this.cbEnableRemindMeMessages_OnChange);
            // 
            // cbEnableOneHourBeforeNotification
            // 
            this.cbEnableOneHourBeforeNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbEnableOneHourBeforeNotification.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbEnableOneHourBeforeNotification.Checked = true;
            this.cbEnableOneHourBeforeNotification.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbEnableOneHourBeforeNotification.ForeColor = System.Drawing.Color.White;
            this.cbEnableOneHourBeforeNotification.Location = new System.Drawing.Point(18, 310);
            this.cbEnableOneHourBeforeNotification.Name = "cbEnableOneHourBeforeNotification";
            this.cbEnableOneHourBeforeNotification.Size = new System.Drawing.Size(20, 20);
            this.cbEnableOneHourBeforeNotification.TabIndex = 95;
            this.cbEnableOneHourBeforeNotification.OnChange += new System.EventHandler(this.cbEnableOneHourBeforeNotification_OnChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 284);
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
            this.label6.Location = new System.Drawing.Point(44, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 17);
            this.label6.TabIndex = 97;
            this.label6.Text = "Remind 1 hour before the reminder pops up";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // UCWindowOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEnableOneHourBeforeNotification);
            this.Controls.Add(this.cbEnableRemindMeMessages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPopupType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCWindowOverlay";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCWindowOverlay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbPopupType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuCheckbox cbEnableRemindMeMessages;
        private Bunifu.Framework.UI.BunifuCheckbox cbEnableOneHourBeforeNotification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
