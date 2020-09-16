namespace RemindMe
{
    partial class MaterialRunningTimer
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
            this.tmrTickDownTime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimerTime = new MaterialSkin.Controls.MaterialLabel();
            this.lblTimerName = new MaterialSkin.Controls.MaterialLabel();
            this.btnSubtractMinute = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAddMinute = new Bunifu.Framework.UI.BunifuTileButton();
            this.pbTimer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrTickDownTime
            // 
            this.tmrTickDownTime.Interval = 1000;
            this.tmrTickDownTime.Tick += new System.EventHandler(this.tmrTickDownTime_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lblTimerTime
            // 
            this.lblTimerTime.AutoSize = true;
            this.lblTimerTime.Depth = 0;
            this.lblTimerTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimerTime.Location = new System.Drawing.Point(30, 4);
            this.lblTimerTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimerTime.Name = "lblTimerTime";
            this.lblTimerTime.Size = new System.Drawing.Size(63, 19);
            this.lblTimerTime.TabIndex = 122;
            this.lblTimerTime.Text = "00:00:00";
            // 
            // lblTimerName
            // 
            this.lblTimerName.AutoSize = true;
            this.lblTimerName.Depth = 0;
            this.lblTimerName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimerName.Location = new System.Drawing.Point(101, 4);
            this.lblTimerName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimerName.Name = "lblTimerName";
            this.lblTimerName.Size = new System.Drawing.Size(122, 19);
            this.lblTimerName.TabIndex = 123;
            this.lblTimerName.Text = "Why hello there ;)";
            // 
            // btnSubtractMinute
            // 
            this.btnSubtractMinute.BackColor = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.color = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.colorActive = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubtractMinute.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnSubtractMinute.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubtractMinute.Image = global::RemindMe.Properties.Resources.minusDark;
            this.btnSubtractMinute.ImagePosition = 3;
            this.btnSubtractMinute.ImageZoom = 70;
            this.btnSubtractMinute.LabelPosition = 0;
            this.btnSubtractMinute.LabelText = "";
            this.btnSubtractMinute.Location = new System.Drawing.Point(270, 2);
            this.btnSubtractMinute.Margin = new System.Windows.Forms.Padding(6);
            this.btnSubtractMinute.Name = "btnSubtractMinute";
            this.btnSubtractMinute.Size = new System.Drawing.Size(20, 20);
            this.btnSubtractMinute.TabIndex = 121;
            this.btnSubtractMinute.Click += new System.EventHandler(this.btnSubtractMinute_Click);
            // 
            // btnAddMinute
            // 
            this.btnAddMinute.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMinute.color = System.Drawing.Color.Transparent;
            this.btnAddMinute.colorActive = System.Drawing.Color.Transparent;
            this.btnAddMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMinute.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnAddMinute.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddMinute.Image = global::RemindMe.Properties.Resources.plusDark;
            this.btnAddMinute.ImagePosition = 3;
            this.btnAddMinute.ImageZoom = 70;
            this.btnAddMinute.LabelPosition = 0;
            this.btnAddMinute.LabelText = "";
            this.btnAddMinute.Location = new System.Drawing.Point(292, 2);
            this.btnAddMinute.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddMinute.Name = "btnAddMinute";
            this.btnAddMinute.Size = new System.Drawing.Size(20, 20);
            this.btnAddMinute.TabIndex = 120;
            this.btnAddMinute.Click += new System.EventHandler(this.btnAddMinute_Click);
            // 
            // pbTimer
            // 
            this.pbTimer.BackgroundImage = global::RemindMe.Properties.Resources.stopwatchDark;
            this.pbTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTimer.Location = new System.Drawing.Point(5, 2);
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new System.Drawing.Size(20, 20);
            this.pbTimer.TabIndex = 117;
            this.pbTimer.TabStop = false;
            // 
            // MaterialRunningTimer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblTimerName);
            this.Controls.Add(this.lblTimerTime);
            this.Controls.Add(this.btnSubtractMinute);
            this.Controls.Add(this.btnAddMinute);
            this.Controls.Add(this.pbTimer);
            this.Name = "MaterialRunningTimer";
            this.Size = new System.Drawing.Size(315, 25);
            this.Load += new System.EventHandler(this.RunningTimer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrTickDownTime;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuTileButton btnSubtractMinute;
        private Bunifu.Framework.UI.BunifuTileButton btnAddMinute;
        private System.Windows.Forms.PictureBox pbTimer;
        private MaterialSkin.Controls.MaterialLabel lblTimerTime;
        private MaterialSkin.Controls.MaterialLabel lblTimerName;
    }
}
