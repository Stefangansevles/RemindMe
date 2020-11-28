namespace RemindMe
{
    partial class MUCTimer
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
            this.pnlRunningTimers = new System.Windows.Forms.Panel();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.btnMinSeconds = new MaterialSkin.Controls.MaterialButton();
            this.btnPlusSeconds = new MaterialSkin.Controls.MaterialButton();
            this.btnMinMinutes = new MaterialSkin.Controls.MaterialButton();
            this.btnPlusMinutes = new MaterialSkin.Controls.MaterialButton();
            this.btnMinHours = new MaterialSkin.Controls.MaterialButton();
            this.btnPlusHours = new MaterialSkin.Controls.MaterialButton();
            this.numSeconds = new MaterialSkin.Controls.MaterialTextBox();
            this.disableRightclick = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.numMinutes = new MaterialSkin.Controls.MaterialTextBox();
            this.numHours = new MaterialSkin.Controls.MaterialTextBox();
            this.lblKeyCombination = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblNoTimers = new MaterialSkin.Controls.MaterialLabel();
            this.btnDeleteTimer = new MaterialSkin.Controls.MaterialButton();
            this.btnPauseResumeTimer = new MaterialSkin.Controls.MaterialButton();
            this.btnNewTimer = new MaterialSkin.Controls.MaterialButton();
            this.btnTimerTemplate = new MaterialSkin.Controls.MaterialButton();
            this.pnlRunningTimers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRunningTimers
            // 
            this.pnlRunningTimers.AutoScroll = true;
            this.pnlRunningTimers.Controls.Add(this.lblNoTimers);
            this.pnlRunningTimers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRunningTimers.Location = new System.Drawing.Point(0, 0);
            this.pnlRunningTimers.Name = "pnlRunningTimers";
            this.pnlRunningTimers.Size = new System.Drawing.Size(806, 33);
            this.pnlRunningTimers.TabIndex = 112;
            this.pnlRunningTimers.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlRunningTimers_ControlAdded);
            this.pnlRunningTimers.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlRunningTimers_ControlRemoved);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // btnMinSeconds
            // 
            this.btnMinSeconds.AutoSize = false;
            this.btnMinSeconds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinSeconds.Depth = 0;
            this.btnMinSeconds.DrawShadows = true;
            this.btnMinSeconds.HighEmphasis = true;
            this.btnMinSeconds.Icon = null;
            this.btnMinSeconds.Location = new System.Drawing.Point(559, 213);
            this.btnMinSeconds.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinSeconds.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinSeconds.Name = "btnMinSeconds";
            this.btnMinSeconds.Size = new System.Drawing.Size(22, 22);
            this.btnMinSeconds.TabIndex = 128;
            this.btnMinSeconds.Text = "-";
            this.btnMinSeconds.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnMinSeconds.UseAccentColor = false;
            this.btnMinSeconds.UseVisualStyleBackColor = true;
            this.btnMinSeconds.Click += new System.EventHandler(this.btnMinSeconds_Click);
            // 
            // btnPlusSeconds
            // 
            this.btnPlusSeconds.AutoSize = false;
            this.btnPlusSeconds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlusSeconds.Depth = 0;
            this.btnPlusSeconds.DrawShadows = true;
            this.btnPlusSeconds.HighEmphasis = true;
            this.btnPlusSeconds.Icon = null;
            this.btnPlusSeconds.Location = new System.Drawing.Point(559, 185);
            this.btnPlusSeconds.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPlusSeconds.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPlusSeconds.Name = "btnPlusSeconds";
            this.btnPlusSeconds.Size = new System.Drawing.Size(22, 22);
            this.btnPlusSeconds.TabIndex = 127;
            this.btnPlusSeconds.Text = "+";
            this.btnPlusSeconds.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPlusSeconds.UseAccentColor = false;
            this.btnPlusSeconds.UseVisualStyleBackColor = true;
            this.btnPlusSeconds.Click += new System.EventHandler(this.btnPlusSeconds_Click);
            // 
            // btnMinMinutes
            // 
            this.btnMinMinutes.AutoSize = false;
            this.btnMinMinutes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinMinutes.Depth = 0;
            this.btnMinMinutes.DrawShadows = true;
            this.btnMinMinutes.HighEmphasis = true;
            this.btnMinMinutes.Icon = null;
            this.btnMinMinutes.Location = new System.Drawing.Point(436, 212);
            this.btnMinMinutes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinMinutes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinMinutes.Name = "btnMinMinutes";
            this.btnMinMinutes.Size = new System.Drawing.Size(22, 22);
            this.btnMinMinutes.TabIndex = 126;
            this.btnMinMinutes.Text = "-";
            this.btnMinMinutes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnMinMinutes.UseAccentColor = false;
            this.btnMinMinutes.UseVisualStyleBackColor = true;
            this.btnMinMinutes.Click += new System.EventHandler(this.btnMinMinutes_Click);
            // 
            // btnPlusMinutes
            // 
            this.btnPlusMinutes.AutoSize = false;
            this.btnPlusMinutes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlusMinutes.Depth = 0;
            this.btnPlusMinutes.DrawShadows = true;
            this.btnPlusMinutes.HighEmphasis = true;
            this.btnPlusMinutes.Icon = null;
            this.btnPlusMinutes.Location = new System.Drawing.Point(436, 184);
            this.btnPlusMinutes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPlusMinutes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPlusMinutes.Name = "btnPlusMinutes";
            this.btnPlusMinutes.Size = new System.Drawing.Size(22, 22);
            this.btnPlusMinutes.TabIndex = 125;
            this.btnPlusMinutes.Text = "+";
            this.btnPlusMinutes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPlusMinutes.UseAccentColor = false;
            this.btnPlusMinutes.UseVisualStyleBackColor = true;
            this.btnPlusMinutes.Click += new System.EventHandler(this.btnPlusMinutes_Click);
            // 
            // btnMinHours
            // 
            this.btnMinHours.AutoSize = false;
            this.btnMinHours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinHours.Depth = 0;
            this.btnMinHours.DrawShadows = true;
            this.btnMinHours.HighEmphasis = true;
            this.btnMinHours.Icon = null;
            this.btnMinHours.Location = new System.Drawing.Point(306, 212);
            this.btnMinHours.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinHours.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinHours.Name = "btnMinHours";
            this.btnMinHours.Size = new System.Drawing.Size(22, 22);
            this.btnMinHours.TabIndex = 124;
            this.btnMinHours.Text = "-";
            this.btnMinHours.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnMinHours.UseAccentColor = false;
            this.btnMinHours.UseVisualStyleBackColor = true;
            this.btnMinHours.Click += new System.EventHandler(this.btnMinHours_Click);
            // 
            // btnPlusHours
            // 
            this.btnPlusHours.AutoSize = false;
            this.btnPlusHours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlusHours.Depth = 0;
            this.btnPlusHours.DrawShadows = true;
            this.btnPlusHours.HighEmphasis = true;
            this.btnPlusHours.Icon = null;
            this.btnPlusHours.Location = new System.Drawing.Point(306, 184);
            this.btnPlusHours.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPlusHours.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPlusHours.Name = "btnPlusHours";
            this.btnPlusHours.Size = new System.Drawing.Size(22, 22);
            this.btnPlusHours.TabIndex = 123;
            this.btnPlusHours.Text = "+";
            this.btnPlusHours.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPlusHours.UseAccentColor = false;
            this.btnPlusHours.UseVisualStyleBackColor = true;
            this.btnPlusHours.Click += new System.EventHandler(this.btnPlusHours_Click);
            // 
            // numSeconds
            // 
            this.numSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSeconds.ContextMenuStrip = this.disableRightclick;
            this.numSeconds.Depth = 0;
            this.numSeconds.Font = new System.Drawing.Font("Roboto", 12F);
            this.numSeconds.Hint = "Seconds";
            this.numSeconds.Location = new System.Drawing.Point(475, 184);
            this.numSeconds.MaxLength = 50;
            this.numSeconds.MouseState = MaterialSkin.MouseState.OUT;
            this.numSeconds.Multiline = false;
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(77, 50);
            this.numSeconds.TabIndex = 121;
            this.numSeconds.Text = "0";
            this.numSeconds.TextChanged += new System.EventHandler(this.numSeconds_TextChanged);
            // 
            // disableRightclick
            // 
            this.disableRightclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.disableRightclick.Depth = 0;
            this.disableRightclick.MouseState = MaterialSkin.MouseState.HOVER;
            this.disableRightclick.Name = "disableRightclick";
            this.disableRightclick.Size = new System.Drawing.Size(61, 4);
            // 
            // numMinutes
            // 
            this.numMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numMinutes.ContextMenuStrip = this.disableRightclick;
            this.numMinutes.Depth = 0;
            this.numMinutes.Font = new System.Drawing.Font("Roboto", 12F);
            this.numMinutes.Hint = "Minutes";
            this.numMinutes.Location = new System.Drawing.Point(351, 184);
            this.numMinutes.MaxLength = 50;
            this.numMinutes.MouseState = MaterialSkin.MouseState.OUT;
            this.numMinutes.Multiline = false;
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(77, 50);
            this.numMinutes.TabIndex = 120;
            this.numMinutes.Text = "0";
            this.numMinutes.TextChanged += new System.EventHandler(this.numMinutes_TextChanged);
            // 
            // numHours
            // 
            this.numHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHours.ContextMenuStrip = this.disableRightclick;
            this.numHours.Depth = 0;
            this.numHours.Font = new System.Drawing.Font("Roboto", 12F);
            this.numHours.Hint = "Hours";
            this.numHours.Location = new System.Drawing.Point(222, 185);
            this.numHours.MaxLength = 50;
            this.numHours.MouseState = MaterialSkin.MouseState.OUT;
            this.numHours.Multiline = false;
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(77, 50);
            this.numHours.TabIndex = 119;
            this.numHours.Text = "0";
            // 
            // lblKeyCombination
            // 
            this.lblKeyCombination.AutoSize = true;
            this.lblKeyCombination.Depth = 0;
            this.lblKeyCombination.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblKeyCombination.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.lblKeyCombination.Location = new System.Drawing.Point(142, 115);
            this.lblKeyCombination.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblKeyCombination.Name = "lblKeyCombination";
            this.lblKeyCombination.Size = new System.Drawing.Size(387, 14);
            this.lblKeyCombination.TabIndex = 116;
            this.lblKeyCombination.Text = "protip: You can create multiple timers by pressing the key combination: ";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(99, 94);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(605, 19);
            this.materialLabel1.TabIndex = 114;
            this.materialLabel1.Text = "Want something short-term? Dont want to create a reminder for it? set a timer ins" +
    "tead.";
            // 
            // lblNoTimers
            // 
            this.lblNoTimers.AutoSize = true;
            this.lblNoTimers.Depth = 0;
            this.lblNoTimers.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNoTimers.Location = new System.Drawing.Point(325, 6);
            this.lblNoTimers.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNoTimers.Name = "lblNoTimers";
            this.lblNoTimers.Size = new System.Drawing.Size(156, 19);
            this.lblNoTimers.TabIndex = 0;
            this.lblNoTimers.Text = "No running timers yet!";
            // 
            // btnDeleteTimer
            // 
            this.btnDeleteTimer.AutoSize = false;
            this.btnDeleteTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteTimer.Depth = 0;
            this.btnDeleteTimer.DrawShadows = false;
            this.btnDeleteTimer.HighEmphasis = true;
            this.btnDeleteTimer.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnDeleteTimer.Location = new System.Drawing.Point(474, 261);
            this.btnDeleteTimer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteTimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteTimer.Name = "btnDeleteTimer";
            this.btnDeleteTimer.Size = new System.Drawing.Size(45, 38);
            this.btnDeleteTimer.TabIndex = 118;
            this.btnDeleteTimer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteTimer.UseAccentColor = false;
            this.btnDeleteTimer.UseVisualStyleBackColor = true;
            this.btnDeleteTimer.Visible = false;
            this.btnDeleteTimer.Click += new System.EventHandler(this.btnDeleteTimer_Click);
            // 
            // btnPauseResumeTimer
            // 
            this.btnPauseResumeTimer.AutoSize = false;
            this.btnPauseResumeTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPauseResumeTimer.Depth = 0;
            this.btnPauseResumeTimer.DrawShadows = true;
            this.btnPauseResumeTimer.HighEmphasis = true;
            this.btnPauseResumeTimer.Icon = global::RemindMe.Properties.Resources.pause_2x1;
            this.btnPauseResumeTimer.Location = new System.Drawing.Point(421, 261);
            this.btnPauseResumeTimer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPauseResumeTimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPauseResumeTimer.Name = "btnPauseResumeTimer";
            this.btnPauseResumeTimer.Size = new System.Drawing.Size(45, 38);
            this.btnPauseResumeTimer.TabIndex = 118;
            this.btnPauseResumeTimer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPauseResumeTimer.UseAccentColor = false;
            this.btnPauseResumeTimer.UseVisualStyleBackColor = true;
            this.btnPauseResumeTimer.Click += new System.EventHandler(this.btnPauseResumeTimer_Click);
            // 
            // btnNewTimer
            // 
            this.btnNewTimer.AutoSize = false;
            this.btnNewTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewTimer.Depth = 0;
            this.btnNewTimer.DrawShadows = true;
            this.btnNewTimer.HighEmphasis = true;
            this.btnNewTimer.Icon = global::RemindMe.Properties.Resources.Bellwhite;
            this.btnNewTimer.Location = new System.Drawing.Point(270, 261);
            this.btnNewTimer.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewTimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewTimer.Name = "btnNewTimer";
            this.btnNewTimer.Size = new System.Drawing.Size(143, 38);
            this.btnNewTimer.TabIndex = 117;
            this.btnNewTimer.Text = "New timer";
            this.btnNewTimer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNewTimer.UseAccentColor = false;
            this.btnNewTimer.UseVisualStyleBackColor = true;
            this.btnNewTimer.Click += new System.EventHandler(this.btnNewTimer_Click);
            // 
            // btnTimerTemplate
            // 
            this.btnTimerTemplate.AutoSize = false;
            this.btnTimerTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTimerTemplate.Depth = 0;
            this.btnTimerTemplate.DrawShadows = true;
            this.btnTimerTemplate.HighEmphasis = true;
            this.btnTimerTemplate.Icon = global::RemindMe.Properties.Resources.RemindMe;
            this.btnTimerTemplate.Location = new System.Drawing.Point(16, 497);
            this.btnTimerTemplate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTimerTemplate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTimerTemplate.Name = "btnTimerTemplate";
            this.btnTimerTemplate.Size = new System.Drawing.Size(112, 36);
            this.btnTimerTemplate.TabIndex = 113;
            this.btnTimerTemplate.Text = "text";
            this.btnTimerTemplate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTimerTemplate.UseAccentColor = false;
            this.btnTimerTemplate.UseVisualStyleBackColor = true;
            this.btnTimerTemplate.Visible = false;
            // 
            // MUCTimer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnMinSeconds);
            this.Controls.Add(this.btnPlusSeconds);
            this.Controls.Add(this.btnMinMinutes);
            this.Controls.Add(this.btnPlusMinutes);
            this.Controls.Add(this.btnMinHours);
            this.Controls.Add(this.btnPlusHours);
            this.Controls.Add(this.numSeconds);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.btnDeleteTimer);
            this.Controls.Add(this.btnPauseResumeTimer);
            this.Controls.Add(this.btnNewTimer);
            this.Controls.Add(this.lblKeyCombination);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnTimerTemplate);
            this.Controls.Add(this.pnlRunningTimers);
            this.Name = "MUCTimer";
            this.Size = new System.Drawing.Size(806, 500);
            this.Load += new System.EventHandler(this.UCTimer_Load);
            this.pnlRunningTimers.ResumeLayout(false);
            this.pnlRunningTimers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRunningTimers;
        private MaterialSkin.Controls.MaterialLabel lblNoTimers;
        private MaterialSkin.Controls.MaterialButton btnTimerTemplate;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblKeyCombination;
        private MaterialSkin.Controls.MaterialButton btnNewTimer;
        private MaterialSkin.Controls.MaterialButton btnPauseResumeTimer;
        private MaterialSkin.Controls.MaterialButton btnPlusHours;
        private MaterialSkin.Controls.MaterialButton btnMinHours;
        private MaterialSkin.Controls.MaterialButton btnMinMinutes;
        private MaterialSkin.Controls.MaterialButton btnPlusMinutes;
        private MaterialSkin.Controls.MaterialButton btnMinSeconds;
        private MaterialSkin.Controls.MaterialButton btnPlusSeconds;
        private MaterialSkin.Controls.MaterialContextMenuStrip disableRightclick;
        public System.Windows.Forms.Timer tmrCountdown;
        public MaterialSkin.Controls.MaterialTextBox numHours;
        public MaterialSkin.Controls.MaterialTextBox numMinutes;
        public MaterialSkin.Controls.MaterialTextBox numSeconds;
        private MaterialSkin.Controls.MaterialButton btnDeleteTimer;
    }
}
