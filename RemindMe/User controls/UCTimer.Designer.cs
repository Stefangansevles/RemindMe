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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.cbSound = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStartTimer = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblKeyCombination = new System.Windows.Forms.Label();
            this.btnRemoveSong = new Bunifu.Framework.UI.BunifuTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(279, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set a timer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 50);
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
            this.numHours.Location = new System.Drawing.Point(200, 154);
            this.numHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(47, 36);
            this.numHours.TabIndex = 4;
            this.numHours.Click += new System.EventHandler(this.numHours_Click);
            // 
            // numMinutes
            // 
            this.numMinutes.BackColor = System.Drawing.Color.DimGray;
            this.numMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numMinutes.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.numMinutes.ForeColor = System.Drawing.Color.White;
            this.numMinutes.Location = new System.Drawing.Point(305, 154);
            this.numMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(47, 36);
            this.numMinutes.TabIndex = 5;
            this.numMinutes.Click += new System.EventHandler(this.numMinutes_Click);
            // 
            // numSeconds
            // 
            this.numSeconds.BackColor = System.Drawing.Color.DimGray;
            this.numSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSeconds.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.numSeconds.ForeColor = System.Drawing.Color.White;
            this.numSeconds.Location = new System.Drawing.Point(410, 154);
            this.numSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(47, 36);
            this.numSeconds.TabIndex = 6;
            this.numSeconds.Click += new System.EventHandler(this.numSeconds_Click);
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
            this.label3.Location = new System.Drawing.Point(197, 134);
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
            this.label4.Location = new System.Drawing.Point(302, 134);
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
            this.label5.Location = new System.Drawing.Point(407, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Seconds";
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.DimGray;
            this.tbNote.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.ForeColor = System.Drawing.Color.White;
            this.tbNote.Location = new System.Drawing.Point(214, 326);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(258, 60);
            this.tbNote.TabIndex = 108;
            // 
            // cbSound
            // 
            this.cbSound.BackColor = System.Drawing.Color.DimGray;
            this.cbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cbSound.ForeColor = System.Drawing.Color.White;
            this.cbSound.FormattingEnabled = true;
            this.cbSound.ItemHeight = 16;
            this.cbSound.Location = new System.Drawing.Point(214, 298);
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(225, 24);
            this.cbSound.TabIndex = 107;
            this.cbSound.SelectedIndexChanged += new System.EventHandler(this.cbSound_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(68, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 18);
            this.label6.TabIndex = 106;
            this.label6.Text = "Set a sound effect:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(68, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 18);
            this.label7.TabIndex = 105;
            this.label7.Text = "Set a description:";
            // 
            // btnStartTimer
            // 
            this.btnStartTimer.Activecolor = System.Drawing.Color.DimGray;
            this.btnStartTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStartTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartTimer.BorderRadius = 5;
            this.btnStartTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnStartTimer.ButtonText = "    Start timer";
            this.btnStartTimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTimer.DisabledColor = System.Drawing.Color.Gray;
            this.btnStartTimer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTimer.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStartTimer.Iconimage = global::RemindMe.Properties.Resources.Bellwhite;
            this.btnStartTimer.Iconimage_right = null;
            this.btnStartTimer.Iconimage_right_Selected = null;
            this.btnStartTimer.Iconimage_Selected = null;
            this.btnStartTimer.IconMarginLeft = 0;
            this.btnStartTimer.IconMarginRight = 0;
            this.btnStartTimer.IconRightVisible = true;
            this.btnStartTimer.IconRightZoom = 0D;
            this.btnStartTimer.IconVisible = true;
            this.btnStartTimer.IconZoom = 50D;
            this.btnStartTimer.IsTab = false;
            this.btnStartTimer.Location = new System.Drawing.Point(248, 216);
            this.btnStartTimer.Name = "btnStartTimer";
            this.btnStartTimer.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStartTimer.OnHovercolor = System.Drawing.Color.Gray;
            this.btnStartTimer.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStartTimer.selected = false;
            this.btnStartTimer.Size = new System.Drawing.Size(167, 39);
            this.btnStartTimer.TabIndex = 75;
            this.btnStartTimer.Text = "    Start timer";
            this.btnStartTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartTimer.Textcolor = System.Drawing.Color.White;
            this.btnStartTimer.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTimer.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // lblKeyCombination
            // 
            this.lblKeyCombination.AutoSize = true;
            this.lblKeyCombination.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.lblKeyCombination.ForeColor = System.Drawing.Color.White;
            this.lblKeyCombination.Location = new System.Drawing.Point(84, 67);
            this.lblKeyCombination.Name = "lblKeyCombination";
            this.lblKeyCombination.Size = new System.Drawing.Size(381, 15);
            this.lblKeyCombination.TabIndex = 109;
            this.lblKeyCombination.Text = "protip: You can create a quick timer by pressing the key combination: ";
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveSong.color = System.Drawing.Color.Transparent;
            this.btnRemoveSong.colorActive = System.Drawing.Color.DarkGray;
            this.btnRemoveSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSong.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnRemoveSong.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveSong.Image = global::RemindMe.Properties.Resources.bin;
            this.btnRemoveSong.ImagePosition = 0;
            this.btnRemoveSong.ImageZoom = 100;
            this.btnRemoveSong.LabelPosition = 0;
            this.btnRemoveSong.LabelText = "";
            this.btnRemoveSong.Location = new System.Drawing.Point(448, 298);
            this.btnRemoveSong.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveSong.TabIndex = 110;
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
            // 
            // UCTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.btnRemoveSong);
            this.Controls.Add(this.lblKeyCombination);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.cbSound);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartTimer);
            this.Controls.Add(this.numSeconds);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCTimer";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCTimer_Load);
            this.VisibleChanged += new System.EventHandler(this.UCTimer_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuFlatButton btnStartTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbNote;
        public System.Windows.Forms.ComboBox cbSound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblKeyCombination;
        public System.Windows.Forms.NumericUpDown numHours;
        public System.Windows.Forms.NumericUpDown numMinutes;
        public System.Windows.Forms.NumericUpDown numSeconds;
        public System.Windows.Forms.Timer tmrCountdown;
        private Bunifu.Framework.UI.BunifuTileButton btnRemoveSong;
    }
}
