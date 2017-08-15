namespace RemindMe
{
    partial class UCWindows
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPopupType = new System.Windows.Forms.ComboBox();
            this.cbEnableRemindMeMessages = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 60);
            this.label2.TabIndex = 6;
            this.label2.Text = "Always on top: reminder will always be visible when it pops up\r\n\r\nMinimized: remi" +
    "nder will show in the taskbar, but will not show\r\nuntil clicked";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Popup type:";
            // 
            // cbPopupType
            // 
            this.cbPopupType.BackColor = System.Drawing.Color.DimGray;
            this.cbPopupType.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbPopupType.ForeColor = System.Drawing.Color.White;
            this.cbPopupType.FormattingEnabled = true;
            this.cbPopupType.Items.AddRange(new object[] {
            "Always on top (Recommended)",
            "Minimized"});
            this.cbPopupType.Location = new System.Drawing.Point(119, 19);
            this.cbPopupType.Name = "cbPopupType";
            this.cbPopupType.Size = new System.Drawing.Size(230, 24);
            this.cbPopupType.TabIndex = 4;
            this.cbPopupType.SelectedIndexChanged += new System.EventHandler(this.cbPopupType_SelectedIndexChanged);
            // 
            // cbEnableRemindMeMessages
            // 
            this.cbEnableRemindMeMessages.AutoSize = true;
            this.cbEnableRemindMeMessages.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbEnableRemindMeMessages.ForeColor = System.Drawing.Color.White;
            this.cbEnableRemindMeMessages.Location = new System.Drawing.Point(13, 175);
            this.cbEnableRemindMeMessages.Name = "cbEnableRemindMeMessages";
            this.cbEnableRemindMeMessages.Size = new System.Drawing.Size(240, 19);
            this.cbEnableRemindMeMessages.TabIndex = 8;
            this.cbEnableRemindMeMessages.Text = "Enable today\'s reminders popup\r\n";
            this.cbEnableRemindMeMessages.UseVisualStyleBackColor = true;
            this.cbEnableRemindMeMessages.CheckedChanged += new System.EventHandler(this.cbEnableRemindMeMessages_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe_message_popup;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // UCWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbEnableRemindMeMessages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPopupType);
            this.Name = "UCWindows";
            this.Size = new System.Drawing.Size(462, 302);
            this.Load += new System.EventHandler(this.UCWindows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPopupType;
        private System.Windows.Forms.CheckBox cbEnableRemindMeMessages;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
