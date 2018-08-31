namespace RemindMe
{
    partial class TimerPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerPopup));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tbNote = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.tbTime = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.lblExit);
            this.bunifuGradientPanel1.Controls.Add(this.tbNote);
            this.bunifuGradientPanel1.Controls.Add(this.tbTime);
            this.bunifuGradientPanel1.Controls.Add(this.lblHeader);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(358, 180);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Transparent;
            this.lblExit.Location = new System.Drawing.Point(336, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 111;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNote.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.ForeColor = System.Drawing.Color.Silver;
            this.tbNote.HintForeColor = System.Drawing.Color.Transparent;
            this.tbNote.HintText = "(Optional) Note";
            this.tbNote.isPassword = false;
            this.tbNote.LineFocusedColor = System.Drawing.Color.White;
            this.tbNote.LineIdleColor = System.Drawing.Color.Silver;
            this.tbNote.LineMouseHoverColor = System.Drawing.Color.White;
            this.tbNote.LineThickness = 3;
            this.tbNote.Location = new System.Drawing.Point(76, 111);
            this.tbNote.Margin = new System.Windows.Forms.Padding(4);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(173, 28);
            this.tbNote.TabIndex = 3;
            this.tbNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTime
            // 
            this.tbTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTime.ForeColor = System.Drawing.Color.Silver;
            this.tbTime.HintForeColor = System.Drawing.Color.Transparent;
            this.tbTime.HintText = "(Set a time in minutes)";
            this.tbTime.isPassword = false;
            this.tbTime.LineFocusedColor = System.Drawing.Color.White;
            this.tbTime.LineIdleColor = System.Drawing.Color.Silver;
            this.tbTime.LineMouseHoverColor = System.Drawing.Color.White;
            this.tbTime.LineThickness = 3;
            this.tbTime.Location = new System.Drawing.Point(76, 75);
            this.tbTime.Margin = new System.Windows.Forms.Padding(4);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(173, 28);
            this.tbTime.TabIndex = 1;
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(78, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(172, 22);
            this.lblHeader.TabIndex = 110;
            this.lblHeader.Text = "Setting a quick timer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.RemindMeTimer;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.bunifuGradientPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.lblHeader;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.pictureBox1;
            this.bunifuDragControl3.Vertical = true;
            // 
            // TimerPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 180);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimerPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set a quick timer";
            this.Load += new System.EventHandler(this.TimerPopup_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbTime;
        private System.Windows.Forms.Label lblHeader;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbNote;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
    }
}