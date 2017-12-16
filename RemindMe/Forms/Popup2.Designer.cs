namespace RemindMe
{
    partial class Popup2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup2));
            this.lblNewReminder = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.numPostponeTime = new System.Windows.Forms.NumericUpDown();
            this.tbTitle = new System.Windows.Forms.RichTextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderText = new System.Windows.Forms.Panel();
            this.lblMinimize = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.lblNoteText = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnOk = new Bunifu.Framework.UI.BunifuTileButton();
            this.lblPostpone = new System.Windows.Forms.Label();
            this.cbPostpone = new Bunifu.Framework.UI.BunifuCheckbox();
            this.pnlTopGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.dragPnlHeaderText = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dragLblNewReminder = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dragLblDate = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dragIcon = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numPostponeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbRadioButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderText.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlTopGradient.SuspendLayout();
            this.SuspendLayout();
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
            // tbText
            // 
            this.tbText.BackColor = System.Drawing.Color.DimGray;
            this.tbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbText.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.tbText.ForeColor = System.Drawing.Color.White;
            this.tbText.Location = new System.Drawing.Point(361, 120);
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
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(25, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(236, 17);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "This reminder was set for xx-xx-xxxx xx:xx:xx\r\n";
            // 
            // numPostponeTime
            // 
            this.numPostponeTime.BackColor = System.Drawing.Color.DimGray;
            this.numPostponeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numPostponeTime.ForeColor = System.Drawing.Color.White;
            this.numPostponeTime.Location = new System.Drawing.Point(91, 8);
            this.numPostponeTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPostponeTime.Name = "numPostponeTime";
            this.numPostponeTime.Size = new System.Drawing.Size(73, 20);
            this.numPostponeTime.TabIndex = 72;
            this.numPostponeTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPostponeTime.ValueChanged += new System.EventHandler(this.cbPostponeTime_ValueChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.DimGray;
            this.tbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTitle.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbTitle.ForeColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(361, 46);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbTitle.Size = new System.Drawing.Size(324, 60);
            this.tbTitle.TabIndex = 74;
            this.tbTitle.Text = "";
            this.tbTitle.Enter += new System.EventHandler(this.tbTitle_Enter);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.BackgroundImage")));
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(48, 49);
            this.pbLogo.TabIndex = 66;
            this.pbLogo.TabStop = false;
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.BackColor = System.Drawing.Color.Transparent;
            this.rbMinutes.Checked = true;
            this.rbMinutes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMinutes.ForeColor = System.Drawing.Color.White;
            this.rbMinutes.Location = new System.Drawing.Point(6, 7);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(45, 19);
            this.rbMinutes.TabIndex = 64;
            this.rbMinutes.TabStop = true;
            this.rbMinutes.Text = "Min";
            this.rbMinutes.UseVisualStyleBackColor = false;
            this.rbMinutes.CheckedChanged += new System.EventHandler(this.rbMinutes_CheckedChanged);
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHours.ForeColor = System.Drawing.Color.White;
            this.rbHours.Location = new System.Drawing.Point(55, 7);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(42, 19);
            this.rbHours.TabIndex = 65;
            this.rbHours.Text = "Hrs";
            this.rbHours.UseVisualStyleBackColor = true;
            this.rbHours.CheckedChanged += new System.EventHandler(this.rbHours_CheckedChanged);
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.BackColor = System.Drawing.Color.Transparent;
            this.gbRadioButtons.Controls.Add(this.rbHours);
            this.gbRadioButtons.Controls.Add(this.rbMinutes);
            this.gbRadioButtons.ForeColor = System.Drawing.Color.White;
            this.gbRadioButtons.Location = new System.Drawing.Point(166, 2);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(105, 26);
            this.gbRadioButtons.TabIndex = 76;
            this.gbRadioButtons.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.pnlHeaderText);
            this.pnlHeader.Controls.Add(this.lblMinimize);
            this.pnlHeader.Controls.Add(this.pbLogo);
            this.pnlHeader.Controls.Add(this.lblExit);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(368, 49);
            this.pnlHeader.TabIndex = 77;
            // 
            // pnlHeaderText
            // 
            this.pnlHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderText.Controls.Add(this.lblNewReminder);
            this.pnlHeaderText.Controls.Add(this.lblDate);
            this.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderText.Location = new System.Drawing.Point(48, 0);
            this.pnlHeaderText.Name = "pnlHeaderText";
            this.pnlHeaderText.Size = new System.Drawing.Size(277, 49);
            this.pnlHeaderText.TabIndex = 83;
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Location = new System.Drawing.Point(325, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(21, 22);
            this.lblMinimize.TabIndex = 82;
            this.lblMinimize.Text = "- ";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Transparent;
            this.lblExit.Location = new System.Drawing.Point(346, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 81;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pnlText);
            this.bunifuGradientPanel1.Controls.Add(this.pnlTitle);
            this.bunifuGradientPanel1.Controls.Add(this.pnlFooter);
            this.bunifuGradientPanel1.Controls.Add(this.pnlTopGradient);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(368, 307);
            this.bunifuGradientPanel1.TabIndex = 78;
            // 
            // pnlText
            // 
            this.pnlText.AutoScroll = true;
            this.pnlText.BackColor = System.Drawing.Color.Transparent;
            this.pnlText.Controls.Add(this.lblNoteText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlText.Location = new System.Drawing.Point(0, 119);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(368, 154);
            this.pnlText.TabIndex = 85;
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
            // pnlTitle
            // 
            this.pnlTitle.AutoScroll = true;
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 54);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(368, 65);
            this.pnlTitle.TabIndex = 81;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Resize += new System.EventHandler(this.lblTitle_Resize);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.btnOk);
            this.pnlFooter.Controls.Add(this.lblPostpone);
            this.pnlFooter.Controls.Add(this.cbPostpone);
            this.pnlFooter.Controls.Add(this.gbRadioButtons);
            this.pnlFooter.Controls.Add(this.numPostponeTime);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 273);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(368, 34);
            this.pnlFooter.TabIndex = 80;
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
            this.btnOk.Location = new System.Drawing.Point(281, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 20);
            this.btnOk.TabIndex = 2;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPostpone
            // 
            this.lblPostpone.AutoSize = true;
            this.lblPostpone.BackColor = System.Drawing.Color.Transparent;
            this.lblPostpone.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblPostpone.ForeColor = System.Drawing.Color.White;
            this.lblPostpone.Location = new System.Drawing.Point(26, 8);
            this.lblPostpone.Name = "lblPostpone";
            this.lblPostpone.Size = new System.Drawing.Size(62, 16);
            this.lblPostpone.TabIndex = 79;
            this.lblPostpone.Text = "Postpone";
            this.lblPostpone.Click += new System.EventHandler(this.lblPostpone_Click);
            // 
            // cbPostpone
            // 
            this.cbPostpone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbPostpone.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbPostpone.Checked = false;
            this.cbPostpone.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbPostpone.ForeColor = System.Drawing.Color.White;
            this.cbPostpone.Location = new System.Drawing.Point(3, 7);
            this.cbPostpone.Name = "cbPostpone";
            this.cbPostpone.Size = new System.Drawing.Size(20, 20);
            this.cbPostpone.TabIndex = 78;
            this.cbPostpone.OnChange += new System.EventHandler(this.cbPostpone_OnChange);
            // 
            // pnlTopGradient
            // 
            this.pnlTopGradient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTopGradient.BackgroundImage")));
            this.pnlTopGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopGradient.Controls.Add(this.pnlHeader);
            this.pnlTopGradient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopGradient.GradientBottomLeft = System.Drawing.Color.Gray;
            this.pnlTopGradient.GradientBottomRight = System.Drawing.Color.White;
            this.pnlTopGradient.GradientTopLeft = System.Drawing.Color.DimGray;
            this.pnlTopGradient.GradientTopRight = System.Drawing.Color.DimGray;
            this.pnlTopGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlTopGradient.Name = "pnlTopGradient";
            this.pnlTopGradient.Quality = 10;
            this.pnlTopGradient.Size = new System.Drawing.Size(368, 54);
            this.pnlTopGradient.TabIndex = 84;
            // 
            // dragPnlHeaderText
            // 
            this.dragPnlHeaderText.Fixed = true;
            this.dragPnlHeaderText.Horizontal = true;
            this.dragPnlHeaderText.TargetControl = this.pnlHeaderText;
            this.dragPnlHeaderText.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dragLblNewReminder
            // 
            this.dragLblNewReminder.Fixed = true;
            this.dragLblNewReminder.Horizontal = true;
            this.dragLblNewReminder.TargetControl = this.lblNewReminder;
            this.dragLblNewReminder.Vertical = true;
            // 
            // dragLblDate
            // 
            this.dragLblDate.Fixed = true;
            this.dragLblDate.Horizontal = true;
            this.dragLblDate.TargetControl = this.lblDate;
            this.dragLblDate.Vertical = true;
            // 
            // dragIcon
            // 
            this.dragIcon.Fixed = true;
            this.dragIcon.Horizontal = true;
            this.dragIcon.TargetControl = this.pbLogo;
            this.dragIcon.Vertical = true;
            // 
            // Popup2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(371, 307);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Popup2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.Load += new System.EventHandler(this.Popup_Load);
            this.SizeChanged += new System.EventHandler(this.Popup_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numPostponeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHeaderText.ResumeLayout(false);
            this.pnlHeaderText.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlTopGradient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.NumericUpDown numPostponeTime;
        public System.Windows.Forms.RichTextBox tbText;
        private System.Windows.Forms.Label lblNewReminder;
        public System.Windows.Forms.RichTextBox tbTitle;
        public System.Windows.Forms.RadioButton rbMinutes;
        public System.Windows.Forms.RadioButton rbHours;
        private System.Windows.Forms.GroupBox gbRadioButtons;
        private System.Windows.Forms.Panel pnlHeader;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblPostpone;
        private Bunifu.Framework.UI.BunifuCheckbox cbPostpone;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMinimize;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuDragControl dragPnlHeaderText;
        private System.Windows.Forms.Panel pnlHeaderText;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl dragLblNewReminder;
        private Bunifu.Framework.UI.BunifuDragControl dragLblDate;
        private Bunifu.Framework.UI.BunifuDragControl dragIcon;
        private Bunifu.Framework.UI.BunifuTileButton btnOk;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlTopGradient;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.Label lblNoteText;
    }
}