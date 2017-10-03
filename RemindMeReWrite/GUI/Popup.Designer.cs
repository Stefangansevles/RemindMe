namespace RemindMe
{
    partial class Popup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>e
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.lblNewReminder = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbBlackTopBar = new System.Windows.Forms.TextBox();
            this.cbPostponeTime = new System.Windows.Forms.NumericUpDown();
            this.cbPostpone = new System.Windows.Forms.CheckBox();
            this.tbTitle = new System.Windows.Forms.RichTextBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbMinimizePopup = new System.Windows.Forms.PictureBox();
            this.pbClosePopup = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbPostponeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizePopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClosePopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNewReminder
            // 
            this.lblNewReminder.AutoSize = true;
            this.lblNewReminder.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewReminder.ForeColor = System.Drawing.Color.White;
            this.lblNewReminder.Location = new System.Drawing.Point(54, 25);
            this.lblNewReminder.Name = "lblNewReminder";
            this.lblNewReminder.Size = new System.Drawing.Size(161, 28);
            this.lblNewReminder.TabIndex = 26;
            this.lblNewReminder.Text = "New reminder!";
            // 
            // tbText
            // 
            this.tbText.BackColor = System.Drawing.Color.DimGray;
            this.tbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbText.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.tbText.ForeColor = System.Drawing.Color.White;
            this.tbText.Location = new System.Drawing.Point(9, 156);
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.Size = new System.Drawing.Size(324, 112);
            this.tbText.TabIndex = 24;
            this.tbText.Text = "";
            this.tbText.Enter += new System.EventHandler(this.tbText_Enter);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(57, 52);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 17);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "date";
            // 
            // tbBlackTopBar
            // 
            this.tbBlackTopBar.BackColor = System.Drawing.Color.Black;
            this.tbBlackTopBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBlackTopBar.Enabled = false;
            this.tbBlackTopBar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbBlackTopBar.Location = new System.Drawing.Point(0, 0);
            this.tbBlackTopBar.Multiline = true;
            this.tbBlackTopBar.Name = "tbBlackTopBar";
            this.tbBlackTopBar.Size = new System.Drawing.Size(342, 22);
            this.tbBlackTopBar.TabIndex = 18;
            // 
            // cbPostponeTime
            // 
            this.cbPostponeTime.BackColor = System.Drawing.Color.DimGray;
            this.cbPostponeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbPostponeTime.ForeColor = System.Drawing.Color.White;
            this.cbPostponeTime.Location = new System.Drawing.Point(85, 281);
            this.cbPostponeTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cbPostponeTime.Name = "cbPostponeTime";
            this.cbPostponeTime.Size = new System.Drawing.Size(73, 20);
            this.cbPostponeTime.TabIndex = 72;
            this.cbPostponeTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cbPostponeTime.ValueChanged += new System.EventHandler(this.cbPostponeTime_ValueChanged);
            // 
            // cbPostpone
            // 
            this.cbPostpone.AutoSize = true;
            this.cbPostpone.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.cbPostpone.ForeColor = System.Drawing.Color.White;
            this.cbPostpone.Location = new System.Drawing.Point(6, 281);
            this.cbPostpone.Name = "cbPostpone";
            this.cbPostpone.Size = new System.Drawing.Size(78, 21);
            this.cbPostpone.TabIndex = 73;
            this.cbPostpone.Text = "Postpone";
            this.cbPostpone.UseVisualStyleBackColor = true;
            this.cbPostpone.CheckedChanged += new System.EventHandler(this.cbPostpone_CheckedChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.DimGray;
            this.tbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTitle.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbTitle.ForeColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(9, 97);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbTitle.Size = new System.Drawing.Size(324, 60);
            this.tbTitle.TabIndex = 74;
            this.tbTitle.Text = "";
            this.tbTitle.Enter += new System.EventHandler(this.tbTitle_Enter);
            // 
            // pbMinimizeApplication
            // 
            this.pbMinimizeApplication.BackColor = System.Drawing.Color.Black;
            this.pbMinimizeApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMinimizeApplication.BackgroundImage")));
            this.pbMinimizeApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMinimizeApplication.Location = new System.Drawing.Point(300, 0);
            this.pbMinimizeApplication.Name = "pbMinimizeApplication";
            this.pbMinimizeApplication.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizeApplication.TabIndex = 67;
            this.pbMinimizeApplication.TabStop = false;
            this.pbMinimizeApplication.Click += new System.EventHandler(this.pbMinimizeApplication_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Black;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(0, -1);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 22);
            this.pictureBox6.TabIndex = 66;
            this.pictureBox6.TabStop = false;
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Black;
            this.pbCloseApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCloseApplication.BackgroundImage")));
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(322, 0);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 65;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(1, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(47, 41);
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(421, 23);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 50);
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(265, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 25);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);            
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOk_KeyDown);
            // 
            // pbMinimizePopup
            // 
            this.pbMinimizePopup.BackColor = System.Drawing.Color.Black;
            this.pbMinimizePopup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMinimizePopup.BackgroundImage")));
            this.pbMinimizePopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMinimizePopup.Location = new System.Drawing.Point(297, 0);
            this.pbMinimizePopup.Name = "pbMinimizePopup";
            this.pbMinimizePopup.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizePopup.TabIndex = 20;
            this.pbMinimizePopup.TabStop = false;
            this.pbMinimizePopup.Click += new System.EventHandler(this.pbMinimizePopup_Click);
            // 
            // pbClosePopup
            // 
            this.pbClosePopup.BackColor = System.Drawing.Color.Black;
            this.pbClosePopup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbClosePopup.BackgroundImage")));
            this.pbClosePopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClosePopup.Location = new System.Drawing.Point(320, 0);
            this.pbClosePopup.Name = "pbClosePopup";
            this.pbClosePopup.Size = new System.Drawing.Size(22, 22);
            this.pbClosePopup.TabIndex = 19;
            this.pbClosePopup.TabStop = false;
            this.pbClosePopup.Click += new System.EventHandler(this.pbClosePopup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 22);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.Checked = true;
            this.rbMinutes.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F, System.Drawing.FontStyle.Bold);
            this.rbMinutes.ForeColor = System.Drawing.Color.White;
            this.rbMinutes.Location = new System.Drawing.Point(6, 7);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(43, 18);
            this.rbMinutes.TabIndex = 64;
            this.rbMinutes.TabStop = true;
            this.rbMinutes.Text = "Min";
            this.rbMinutes.UseVisualStyleBackColor = true;
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F, System.Drawing.FontStyle.Bold);
            this.rbHours.ForeColor = System.Drawing.Color.White;
            this.rbHours.Location = new System.Drawing.Point(55, 7);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(42, 18);
            this.rbHours.TabIndex = 65;
            this.rbHours.Text = "Hrs";
            this.rbHours.UseVisualStyleBackColor = true;
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.Controls.Add(this.rbHours);
            this.gbRadioButtons.Controls.Add(this.rbMinutes);
            this.gbRadioButtons.ForeColor = System.Drawing.Color.White;
            this.gbRadioButtons.Location = new System.Drawing.Point(160, 275);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(105, 26);
            this.gbRadioButtons.TabIndex = 76;
            this.gbRadioButtons.TabStop = false;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(343, 307);
            this.Controls.Add(this.gbRadioButtons);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.cbPostpone);
            this.Controls.Add(this.cbPostponeTime);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.tbBlackTopBar);
            this.Controls.Add(this.lblNewReminder);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pbMinimizePopup);
            this.Controls.Add(this.pbClosePopup);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.Load += new System.EventHandler(this.Popup_Load);
            this.SizeChanged += new System.EventHandler(this.Popup_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cbPostponeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizePopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClosePopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbBlackTopBar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pbMinimizePopup;
        private System.Windows.Forms.PictureBox pbClosePopup;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.NumericUpDown cbPostponeTime;
        private System.Windows.Forms.CheckBox cbPostpone;
        public System.Windows.Forms.RichTextBox tbText;
        private System.Windows.Forms.Label lblNewReminder;
        public System.Windows.Forms.RichTextBox tbTitle;
        public System.Windows.Forms.RadioButton rbMinutes;
        public System.Windows.Forms.RadioButton rbHours;
        private System.Windows.Forms.GroupBox gbRadioButtons;
    }
}