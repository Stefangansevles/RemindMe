namespace RemindMe
{
    partial class UCTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTimer));
            this.label2 = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKeyCombination = new System.Windows.Forms.Label();
            this.pnlRunningTimers = new System.Windows.Forms.Panel();
            this.lblNoTimers = new System.Windows.Forms.Label();
            this.btnPauseResumeTimer = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTimerTemplate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNewTimer = new Bunifu.Framework.UI.BunifuFlatButton();
            this.TimerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ucTimerDeleteToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimerTitle = new System.Windows.Forms.Label();
            this.pnlTimerTitle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            this.pnlRunningTimers.SuspendLayout();
            this.TimerMenuStrip.SuspendLayout();
            this.pnlTimerTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(584, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Want something short-term? Dont want to create a reminder for it? set a timer ins" +
    "tead.";
            // 
            // numHours
            // 
            this.numHours.BackColor = System.Drawing.Color.DimGray;
            this.numHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHours.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.numHours.ForeColor = System.Drawing.Color.White;
            this.numHours.Location = new System.Drawing.Point(200, 149);
            this.numHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(47, 36);
            this.numHours.TabIndex = 4;
            // 
            // numMinutes
            // 
            this.numMinutes.BackColor = System.Drawing.Color.DimGray;
            this.numMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numMinutes.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.numMinutes.ForeColor = System.Drawing.Color.White;
            this.numMinutes.Location = new System.Drawing.Point(305, 149);
            this.numMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(47, 36);
            this.numMinutes.TabIndex = 5;
            // 
            // numSeconds
            // 
            this.numSeconds.BackColor = System.Drawing.Color.DimGray;
            this.numSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSeconds.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.numSeconds.ForeColor = System.Drawing.Color.White;
            this.numSeconds.Location = new System.Drawing.Point(410, 149);
            this.numSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(47, 36);
            this.numSeconds.TabIndex = 6;
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(197, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(302, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(407, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Seconds";
            // 
            // lblKeyCombination
            // 
            this.lblKeyCombination.AutoSize = true;
            this.lblKeyCombination.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.lblKeyCombination.ForeColor = System.Drawing.Color.White;
            this.lblKeyCombination.Location = new System.Drawing.Point(84, 87);
            this.lblKeyCombination.Name = "lblKeyCombination";
            this.lblKeyCombination.Size = new System.Drawing.Size(388, 15);
            this.lblKeyCombination.TabIndex = 109;
            this.lblKeyCombination.Text = "protip: You can create multiple timers by pressing the key combination: ";
            // 
            // pnlRunningTimers
            // 
            this.pnlRunningTimers.AutoScroll = true;
            this.pnlRunningTimers.Controls.Add(this.lblNoTimers);
            this.pnlRunningTimers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRunningTimers.Location = new System.Drawing.Point(0, 0);
            this.pnlRunningTimers.Name = "pnlRunningTimers";
            this.pnlRunningTimers.Size = new System.Drawing.Size(666, 33);
            this.pnlRunningTimers.TabIndex = 111;
            this.pnlRunningTimers.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlRunningTimers_ControlAdded);
            this.pnlRunningTimers.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlRunningTimers_ControlRemoved);
            // 
            // lblNoTimers
            // 
            this.lblNoTimers.AutoSize = true;
            this.lblNoTimers.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.lblNoTimers.ForeColor = System.Drawing.Color.White;
            this.lblNoTimers.Location = new System.Drawing.Point(270, 9);
            this.lblNoTimers.Name = "lblNoTimers";
            this.lblNoTimers.Size = new System.Drawing.Size(124, 15);
            this.lblNoTimers.TabIndex = 113;
            this.lblNoTimers.Text = "No running timers yet!";
            // 
            // btnPauseResumeTimer
            // 
            this.btnPauseResumeTimer.Activecolor = System.Drawing.Color.DimGray;
            this.btnPauseResumeTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPauseResumeTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPauseResumeTimer.BorderRadius = 5;
            this.btnPauseResumeTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPauseResumeTimer.ButtonText = "";
            this.btnPauseResumeTimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPauseResumeTimer.DisabledColor = System.Drawing.Color.Gray;
            this.btnPauseResumeTimer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseResumeTimer.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPauseResumeTimer.Iconimage = global::RemindMe.Properties.Resources.pause_2x1;
            this.btnPauseResumeTimer.Iconimage_right = null;
            this.btnPauseResumeTimer.Iconimage_right_Selected = null;
            this.btnPauseResumeTimer.Iconimage_Selected = null;
            this.btnPauseResumeTimer.IconMarginLeft = 0;
            this.btnPauseResumeTimer.IconMarginRight = 0;
            this.btnPauseResumeTimer.IconRightVisible = true;
            this.btnPauseResumeTimer.IconRightZoom = 0D;
            this.btnPauseResumeTimer.IconVisible = true;
            this.btnPauseResumeTimer.IconZoom = 50D;
            this.btnPauseResumeTimer.IsTab = false;
            this.btnPauseResumeTimer.Location = new System.Drawing.Point(380, 208);
            this.btnPauseResumeTimer.Name = "btnPauseResumeTimer";
            this.btnPauseResumeTimer.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPauseResumeTimer.OnHovercolor = System.Drawing.Color.Gray;
            this.btnPauseResumeTimer.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPauseResumeTimer.selected = false;
            this.btnPauseResumeTimer.Size = new System.Drawing.Size(39, 39);
            this.btnPauseResumeTimer.TabIndex = 113;
            this.btnPauseResumeTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPauseResumeTimer.Textcolor = System.Drawing.Color.White;
            this.btnPauseResumeTimer.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseResumeTimer.Click += new System.EventHandler(this.btnPauseResumeTimer_Click);
            // 
            // btnTimerTemplate
            // 
            this.btnTimerTemplate.Activecolor = System.Drawing.Color.DimGray;
            this.btnTimerTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTimerTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimerTemplate.BorderRadius = 5;
            this.btnTimerTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTimerTemplate.ButtonText = "    Template";
            this.btnTimerTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimerTemplate.DisabledColor = System.Drawing.Color.Gray;
            this.btnTimerTemplate.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerTemplate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTimerTemplate.Iconimage = global::RemindMe.Properties.Resources.RemindMeTimer;
            this.btnTimerTemplate.Iconimage_right = null;
            this.btnTimerTemplate.Iconimage_right_Selected = null;
            this.btnTimerTemplate.Iconimage_Selected = null;
            this.btnTimerTemplate.IconMarginLeft = 0;
            this.btnTimerTemplate.IconMarginRight = 0;
            this.btnTimerTemplate.IconRightVisible = true;
            this.btnTimerTemplate.IconRightZoom = 0D;
            this.btnTimerTemplate.IconVisible = true;
            this.btnTimerTemplate.IconZoom = 50D;
            this.btnTimerTemplate.IsTab = false;
            this.btnTimerTemplate.Location = new System.Drawing.Point(3, 397);
            this.btnTimerTemplate.Name = "btnTimerTemplate";
            this.btnTimerTemplate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTimerTemplate.OnHovercolor = System.Drawing.Color.Gray;
            this.btnTimerTemplate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnTimerTemplate.selected = false;
            this.btnTimerTemplate.Size = new System.Drawing.Size(123, 39);
            this.btnTimerTemplate.TabIndex = 112;
            this.btnTimerTemplate.Text = "    Template";
            this.btnTimerTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimerTemplate.Textcolor = System.Drawing.Color.White;
            this.btnTimerTemplate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerTemplate.Visible = false;
            // 
            // btnNewTimer
            // 
            this.btnNewTimer.Activecolor = System.Drawing.Color.DimGray;
            this.btnNewTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewTimer.BorderRadius = 5;
            this.btnNewTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNewTimer.ButtonText = "    New timer";
            this.btnNewTimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewTimer.DisabledColor = System.Drawing.Color.Gray;
            this.btnNewTimer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTimer.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNewTimer.Iconimage = global::RemindMe.Properties.Resources.Bellwhite;
            this.btnNewTimer.Iconimage_right = null;
            this.btnNewTimer.Iconimage_right_Selected = null;
            this.btnNewTimer.Iconimage_Selected = null;
            this.btnNewTimer.IconMarginLeft = 0;
            this.btnNewTimer.IconMarginRight = 0;
            this.btnNewTimer.IconRightVisible = true;
            this.btnNewTimer.IconRightZoom = 0D;
            this.btnNewTimer.IconVisible = true;
            this.btnNewTimer.IconZoom = 50D;
            this.btnNewTimer.IsTab = false;
            this.btnNewTimer.Location = new System.Drawing.Point(249, 208);
            this.btnNewTimer.Name = "btnNewTimer";
            this.btnNewTimer.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewTimer.OnHovercolor = System.Drawing.Color.Gray;
            this.btnNewTimer.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNewTimer.selected = false;
            this.btnNewTimer.Size = new System.Drawing.Size(125, 39);
            this.btnNewTimer.TabIndex = 112;
            this.btnNewTimer.Text = "    New timer";
            this.btnNewTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewTimer.Textcolor = System.Drawing.Color.White;
            this.btnNewTimer.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTimer.Click += new System.EventHandler(this.btnNewTimer_Click);
            // 
            // TimerMenuStrip
            // 
            this.TimerMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.TimerMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ucTimerDeleteToolstrip});
            this.TimerMenuStrip.Name = "ReminderMenuStrip";
            this.TimerMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // ucTimerDeleteToolstrip
            // 
            this.ucTimerDeleteToolstrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucTimerDeleteToolstrip.BackgroundImage")));
            this.ucTimerDeleteToolstrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucTimerDeleteToolstrip.ForeColor = System.Drawing.Color.Gainsboro;
            this.ucTimerDeleteToolstrip.Image = global::RemindMe.Properties.Resources.Bin_white;
            this.ucTimerDeleteToolstrip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucTimerDeleteToolstrip.Name = "ucTimerDeleteToolstrip";
            this.ucTimerDeleteToolstrip.Size = new System.Drawing.Size(180, 22);
            this.ucTimerDeleteToolstrip.Text = "Delete this timer";
            this.ucTimerDeleteToolstrip.Click += new System.EventHandler(this.ucTimerDeleteToolstrip_Click);
            // 
            // lblTimerTitle
            // 
            this.lblTimerTitle.AutoSize = true;
            this.lblTimerTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerTitle.ForeColor = System.Drawing.Color.White;
            this.lblTimerTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTimerTitle.Name = "lblTimerTitle";
            this.lblTimerTitle.Size = new System.Drawing.Size(51, 16);
            this.lblTimerTitle.TabIndex = 1;
            this.lblTimerTitle.Text = "Timer: ";
            this.lblTimerTitle.Visible = false;
            // 
            // pnlTimerTitle
            // 
            this.pnlTimerTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTimerTitle.Controls.Add(this.lblTimerTitle);
            this.pnlTimerTitle.Location = new System.Drawing.Point(142, 265);
            this.pnlTimerTitle.Name = "pnlTimerTitle";
            this.pnlTimerTitle.Size = new System.Drawing.Size(330, 48);
            this.pnlTimerTitle.TabIndex = 116;
            // 
            // UCTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pnlTimerTitle);
            this.Controls.Add(this.btnPauseResumeTimer);
            this.Controls.Add(this.btnTimerTemplate);
            this.Controls.Add(this.btnNewTimer);
            this.Controls.Add(this.pnlRunningTimers);
            this.Controls.Add(this.lblKeyCombination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numSeconds);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.label2);
            this.Name = "UCTimer";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCTimer_Load);
            this.VisibleChanged += new System.EventHandler(this.UCTimer_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            this.pnlRunningTimers.ResumeLayout(false);
            this.pnlRunningTimers.PerformLayout();
            this.TimerMenuStrip.ResumeLayout(false);
            this.pnlTimerTitle.ResumeLayout(false);
            this.pnlTimerTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblKeyCombination;
        public System.Windows.Forms.NumericUpDown numHours;
        public System.Windows.Forms.NumericUpDown numMinutes;
        public System.Windows.Forms.NumericUpDown numSeconds;
        public System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.Panel pnlRunningTimers;
        private Bunifu.Framework.UI.BunifuFlatButton btnTimerTemplate;
        private Bunifu.Framework.UI.BunifuFlatButton btnNewTimer;
        private System.Windows.Forms.Label lblNoTimers;
        private Bunifu.Framework.UI.BunifuFlatButton btnPauseResumeTimer;
        private System.Windows.Forms.ContextMenuStrip TimerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ucTimerDeleteToolstrip;
        private System.Windows.Forms.Label lblTimerTitle;
        private System.Windows.Forms.Panel pnlTimerTitle;
    }
}
