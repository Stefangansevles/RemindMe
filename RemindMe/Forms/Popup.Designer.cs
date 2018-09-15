namespace RemindMe
{
    partial class Popup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlHeaderText = new System.Windows.Forms.Panel();
            this.lblMinimize = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblNewReminder = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl4 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlMainGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.lblNoteText = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.numPostponeTime = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new Bunifu.Framework.UI.BunifuTileButton();
            this.cbPostpone = new Bunifu.Framework.UI.BunifuCheckbox();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.lblPostpone = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.pnlHeaderText.SuspendLayout();
            this.pnlMainGradient.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPostponeTime)).BeginInit();
            this.gbRadioButtons.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlHeaderText;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnlHeaderText
            // 
            this.pnlHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderText.Controls.Add(this.lblMinimize);
            this.pnlHeaderText.Controls.Add(this.lblExit);
            this.pnlHeaderText.Controls.Add(this.lblNewReminder);
            this.pnlHeaderText.Controls.Add(this.lblDate);
            this.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderText.Location = new System.Drawing.Point(53, 0);
            this.pnlHeaderText.Name = "pnlHeaderText";
            this.pnlHeaderText.Size = new System.Drawing.Size(318, 49);
            this.pnlHeaderText.TabIndex = 84;
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Location = new System.Drawing.Point(275, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(21, 22);
            this.lblMinimize.TabIndex = 84;
            this.lblMinimize.Text = "- ";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.lblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.lblMinimize_MouseLeave);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Transparent;
            this.lblExit.Location = new System.Drawing.Point(296, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 83;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            // 
            // lblNewReminder
            // 
            this.lblNewReminder.AutoSize = true;
            this.lblNewReminder.BackColor = System.Drawing.Color.Transparent;
            this.lblNewReminder.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewReminder.ForeColor = System.Drawing.Color.White;
            this.lblNewReminder.Location = new System.Drawing.Point(54, 0);
            this.lblNewReminder.Name = "lblNewReminder";
            this.lblNewReminder.Size = new System.Drawing.Size(161, 28);
            this.lblNewReminder.TabIndex = 26;
            this.lblNewReminder.Text = "New reminder!";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(25, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(236, 17);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "This reminder was set for xx-xx-xxxx xx:xx:xx\r\n";
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.pnlHeaderText;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.lblNewReminder;
            this.bunifuDragControl3.Vertical = true;
            // 
            // bunifuDragControl4
            // 
            this.bunifuDragControl4.Fixed = true;
            this.bunifuDragControl4.Horizontal = true;
            this.bunifuDragControl4.TargetControl = this.lblDate;
            this.bunifuDragControl4.Vertical = true;
            // 
            // pnlMainGradient
            // 
            this.pnlMainGradient.AutoSize = true;
            this.pnlMainGradient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMainGradient.BackgroundImage")));
            this.pnlMainGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainGradient.Controls.Add(this.pnlText);
            this.pnlMainGradient.Controls.Add(this.pnlFooter);
            this.pnlMainGradient.Controls.Add(this.pnlTitle);
            this.pnlMainGradient.Controls.Add(this.pnlHeader);
            this.pnlMainGradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainGradient.GradientBottomLeft = System.Drawing.Color.DimGray;
            this.pnlMainGradient.GradientBottomRight = System.Drawing.Color.DimGray;
            this.pnlMainGradient.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMainGradient.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMainGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlMainGradient.Name = "pnlMainGradient";
            this.pnlMainGradient.Quality = 10;
            this.pnlMainGradient.Size = new System.Drawing.Size(371, 307);
            this.pnlMainGradient.TabIndex = 1;
            // 
            // pnlText
            // 
            this.pnlText.AutoScroll = true;
            this.pnlText.BackColor = System.Drawing.Color.Transparent;
            this.pnlText.Controls.Add(this.lblNoteText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlText.Location = new System.Drawing.Point(0, 114);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(371, 159);
            this.pnlText.TabIndex = 86;
            // 
            // lblNoteText
            // 
            this.lblNoteText.AutoSize = true;
            this.lblNoteText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoteText.ForeColor = System.Drawing.Color.White;
            this.lblNoteText.Location = new System.Drawing.Point(1, 1);
            this.lblNoteText.Name = "lblNoteText";
            this.lblNoteText.Size = new System.Drawing.Size(45, 16);
            this.lblNoteText.TabIndex = 1;
            this.lblNoteText.Text = "label1";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.numPostponeTime);
            this.pnlFooter.Controls.Add(this.btnOk);
            this.pnlFooter.Controls.Add(this.cbPostpone);
            this.pnlFooter.Controls.Add(this.gbRadioButtons);
            this.pnlFooter.Controls.Add(this.lblPostpone);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 273);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(371, 34);
            this.pnlFooter.TabIndex = 85;
            // 
            // numPostponeTime
            // 
            this.numPostponeTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.numPostponeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numPostponeTime.ForeColor = System.Drawing.Color.White;
            this.numPostponeTime.Location = new System.Drawing.Point(100, 9);
            this.numPostponeTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPostponeTime.Name = "numPostponeTime";
            this.numPostponeTime.Size = new System.Drawing.Size(73, 20);
            this.numPostponeTime.TabIndex = 82;
            this.numPostponeTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPostponeTime.ValueChanged += new System.EventHandler(this.numPostponeTime_ValueChanged);
            this.numPostponeTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numPostponeTime_KeyUp);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOk.color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOk.colorActive = System.Drawing.Color.DimGray;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Image = null;
            this.btnOk.ImagePosition = 12;
            this.btnOk.ImageZoom = 50;
            this.btnOk.LabelPosition = 18;
            this.btnOk.LabelText = "OK";
            this.btnOk.Location = new System.Drawing.Point(288, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 24);
            this.btnOk.TabIndex = 84;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbPostpone
            // 
            this.cbPostpone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbPostpone.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbPostpone.Checked = false;
            this.cbPostpone.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbPostpone.ForeColor = System.Drawing.Color.White;
            this.cbPostpone.Location = new System.Drawing.Point(7, 9);
            this.cbPostpone.Name = "cbPostpone";
            this.cbPostpone.Size = new System.Drawing.Size(20, 20);
            this.cbPostpone.TabIndex = 80;
            this.cbPostpone.OnChange += new System.EventHandler(this.cbPostpone_OnChange);
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.BackColor = System.Drawing.Color.Transparent;
            this.gbRadioButtons.Controls.Add(this.rbHours);
            this.gbRadioButtons.Controls.Add(this.rbMinutes);
            this.gbRadioButtons.ForeColor = System.Drawing.Color.White;
            this.gbRadioButtons.Location = new System.Drawing.Point(177, 3);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(105, 26);
            this.gbRadioButtons.TabIndex = 83;
            this.gbRadioButtons.TabStop = false;
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHours.ForeColor = System.Drawing.Color.White;
            this.rbHours.Location = new System.Drawing.Point(57, 6);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(42, 19);
            this.rbHours.TabIndex = 65;
            this.rbHours.Text = "Hrs";
            this.rbHours.UseVisualStyleBackColor = true;
            this.rbHours.CheckedChanged += new System.EventHandler(this.rbHours_CheckedChanged);
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.BackColor = System.Drawing.Color.Transparent;
            this.rbMinutes.Checked = true;
            this.rbMinutes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMinutes.ForeColor = System.Drawing.Color.White;
            this.rbMinutes.Location = new System.Drawing.Point(8, 6);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(45, 19);
            this.rbMinutes.TabIndex = 64;
            this.rbMinutes.TabStop = true;
            this.rbMinutes.Text = "Min";
            this.rbMinutes.UseVisualStyleBackColor = false;
            this.rbMinutes.CheckedChanged += new System.EventHandler(this.rbMinutes_CheckedChanged);
            // 
            // lblPostpone
            // 
            this.lblPostpone.AutoSize = true;
            this.lblPostpone.BackColor = System.Drawing.Color.Transparent;
            this.lblPostpone.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblPostpone.ForeColor = System.Drawing.Color.White;
            this.lblPostpone.Location = new System.Drawing.Point(30, 10);
            this.lblPostpone.Name = "lblPostpone";
            this.lblPostpone.Size = new System.Drawing.Size(62, 16);
            this.lblPostpone.TabIndex = 81;
            this.lblPostpone.Text = "Postpone";
            this.lblPostpone.Click += new System.EventHandler(this.lblPostpone_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.AutoScroll = true;
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 49);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(371, 65);
            this.pnlTitle.TabIndex = 82;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(371, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderText);
            this.pnlHeader.Controls.Add(this.pbIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(371, 49);
            this.pnlHeader.TabIndex = 4;
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(53, 49);
            this.pbIcon.TabIndex = 3;
            this.pbIcon.TabStop = false;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 307);
            this.Controls.Add(this.pnlMainGradient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.Load += new System.EventHandler(this.Popup2_Load);
            this.SizeChanged += new System.EventHandler(this.Popup2_SizeChanged);
            this.pnlHeaderText.ResumeLayout(false);
            this.pnlHeaderText.PerformLayout();
            this.pnlMainGradient.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPostponeTime)).EndInit();
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlMainGradient;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderText;
        private System.Windows.Forms.Label lblNewReminder;
        private System.Windows.Forms.Label lblDate;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMinimize;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Panel pnlTitle;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl4;
        private System.Windows.Forms.Label lblPostpone;
        private Bunifu.Framework.UI.BunifuCheckbox cbPostpone;
        private System.Windows.Forms.GroupBox gbRadioButtons;
        public System.Windows.Forms.RadioButton rbHours;
        public System.Windows.Forms.RadioButton rbMinutes;
        private System.Windows.Forms.NumericUpDown numPostponeTime;
        private Bunifu.Framework.UI.BunifuTileButton btnOk;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlText;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblNoteText;
        private System.Windows.Forms.Timer tmrFadeIn;
    }
}