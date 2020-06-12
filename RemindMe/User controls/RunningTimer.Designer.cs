namespace RemindMe
{
    partial class RunningTimer
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
            this.lblTimerTime = new System.Windows.Forms.Label();
            this.lblTimerName = new System.Windows.Forms.Label();
            this.tmrTickDownTime = new System.Windows.Forms.Timer(this.components);
            this.btnSubtractMinute = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAddMinute = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimerTime
            // 
            this.lblTimerTime.AutoSize = true;
            this.lblTimerTime.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimerTime.ForeColor = System.Drawing.Color.White;
            this.lblTimerTime.Location = new System.Drawing.Point(28, 4);
            this.lblTimerTime.Name = "lblTimerTime";
            this.lblTimerTime.Size = new System.Drawing.Size(56, 16);
            this.lblTimerTime.TabIndex = 2;
            this.lblTimerTime.Text = "00:00:00";
            // 
            // lblTimerName
            // 
            this.lblTimerName.AutoSize = true;
            this.lblTimerName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimerName.ForeColor = System.Drawing.Color.White;
            this.lblTimerName.Location = new System.Drawing.Point(90, 4);
            this.lblTimerName.Name = "lblTimerName";
            this.lblTimerName.Size = new System.Drawing.Size(109, 16);
            this.lblTimerName.TabIndex = 3;
            this.lblTimerName.Text = "Why hello there :)";
            // 
            // tmrTickDownTime
            // 
            this.tmrTickDownTime.Interval = 1000;
            this.tmrTickDownTime.Tick += new System.EventHandler(this.tmrTickDownTime_Tick);
            // 
            // btnSubtractMinute
            // 
            this.btnSubtractMinute.BackColor = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.color = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnSubtractMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubtractMinute.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnSubtractMinute.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.Image = global::RemindMe.Properties.Resources.Minus_white;
            this.btnSubtractMinute.ImagePosition = 3;
            this.btnSubtractMinute.ImageZoom = 70;
            this.btnSubtractMinute.LabelPosition = 0;
            this.btnSubtractMinute.LabelText = "";
            this.btnSubtractMinute.Location = new System.Drawing.Point(252, 2);
            this.btnSubtractMinute.Margin = new System.Windows.Forms.Padding(6);
            this.btnSubtractMinute.Name = "btnSubtractMinute";
            this.btnSubtractMinute.Size = new System.Drawing.Size(20, 20);
            this.btnSubtractMinute.TabIndex = 116;
            this.btnSubtractMinute.Click += new System.EventHandler(this.btnSubtractMinute_Click);
            // 
            // btnAddMinute
            // 
            this.btnAddMinute.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMinute.color = System.Drawing.Color.Transparent;
            this.btnAddMinute.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnAddMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMinute.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnAddMinute.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddMinute.Image = global::RemindMe.Properties.Resources.Plus_white;
            this.btnAddMinute.ImagePosition = 3;
            this.btnAddMinute.ImageZoom = 70;
            this.btnAddMinute.LabelPosition = 0;
            this.btnAddMinute.LabelText = "";
            this.btnAddMinute.Location = new System.Drawing.Point(274, 2);
            this.btnAddMinute.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddMinute.Name = "btnAddMinute";
            this.btnAddMinute.Size = new System.Drawing.Size(20, 20);
            this.btnAddMinute.TabIndex = 115;
            this.btnAddMinute.Click += new System.EventHandler(this.btnAddMinute_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RemindMe.Properties.Resources.speed;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // RunningTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.btnSubtractMinute);
            this.Controls.Add(this.btnAddMinute);
            this.Controls.Add(this.lblTimerName);
            this.Controls.Add(this.lblTimerTime);
            this.Controls.Add(this.pictureBox2);
            this.Name = "RunningTimer";
            this.Size = new System.Drawing.Size(300, 25);
            this.Load += new System.EventHandler(this.RunningTimer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTimerTime;
        private System.Windows.Forms.Label lblTimerName;
        private Bunifu.Framework.UI.BunifuTileButton btnAddMinute;
        private System.Windows.Forms.Timer tmrTickDownTime;
        private Bunifu.Framework.UI.BunifuTileButton btnSubtractMinute;
    }
}
