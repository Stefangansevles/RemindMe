namespace RemindMe
{
    partial class RemindMeMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMeMessageForm));
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlReminderOptions = new System.Windows.Forms.Panel();
            this.btnSkip = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPostpone = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDisable = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrFadeout = new System.Windows.Forms.Timer(this.components);
            this.tmrFadein = new System.Windows.Forms.Timer(this.components);
            this.tmrTimeout = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlReminderOptions.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pnlText);
            this.bunifuGradientPanel1.Controls.Add(this.pnlReminderOptions);
            this.bunifuGradientPanel1.Controls.Add(this.pnlTop);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(356, 136);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // pnlText
            // 
            this.pnlText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlText.Controls.Add(this.lblText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlText.Location = new System.Drawing.Point(0, 37);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(356, 75);
            this.pnlText.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(8, 11);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(33, 16);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Text";
            // 
            // pnlReminderOptions
            // 
            this.pnlReminderOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlReminderOptions.Controls.Add(this.btnSkip);
            this.pnlReminderOptions.Controls.Add(this.btnPostpone);
            this.pnlReminderOptions.Controls.Add(this.btnDisable);
            this.pnlReminderOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReminderOptions.Location = new System.Drawing.Point(0, 112);
            this.pnlReminderOptions.Name = "pnlReminderOptions";
            this.pnlReminderOptions.Size = new System.Drawing.Size(356, 24);
            this.pnlReminderOptions.TabIndex = 1;
            this.pnlReminderOptions.Visible = false;
            // 
            // btnSkip
            // 
            this.btnSkip.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSkip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSkip.BorderRadius = 0;
            this.btnSkip.ButtonText = "Skip";
            this.btnSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSkip.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSkip.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSkip.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSkip.Iconimage = null;
            this.btnSkip.Iconimage_right = null;
            this.btnSkip.Iconimage_right_Selected = null;
            this.btnSkip.Iconimage_Selected = null;
            this.btnSkip.IconMarginLeft = 0;
            this.btnSkip.IconMarginRight = 0;
            this.btnSkip.IconRightVisible = true;
            this.btnSkip.IconRightZoom = 0D;
            this.btnSkip.IconVisible = true;
            this.btnSkip.IconZoom = 50D;
            this.btnSkip.IsTab = false;
            this.btnSkip.Location = new System.Drawing.Point(236, 0);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSkip.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnSkip.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSkip.selected = false;
            this.btnSkip.Size = new System.Drawing.Size(118, 24);
            this.btnSkip.TabIndex = 117;
            this.btnSkip.Text = "Skip";
            this.btnSkip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSkip.Textcolor = System.Drawing.Color.White;
            this.btnSkip.TextFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnPostpone
            // 
            this.btnPostpone.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPostpone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPostpone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPostpone.BorderRadius = 0;
            this.btnPostpone.ButtonText = "Postpone";
            this.btnPostpone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPostpone.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPostpone.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPostpone.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostpone.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPostpone.Iconimage = null;
            this.btnPostpone.Iconimage_right = null;
            this.btnPostpone.Iconimage_right_Selected = null;
            this.btnPostpone.Iconimage_Selected = null;
            this.btnPostpone.IconMarginLeft = 0;
            this.btnPostpone.IconMarginRight = 0;
            this.btnPostpone.IconRightVisible = true;
            this.btnPostpone.IconRightZoom = 0D;
            this.btnPostpone.IconVisible = true;
            this.btnPostpone.IconZoom = 50D;
            this.btnPostpone.IsTab = false;
            this.btnPostpone.Location = new System.Drawing.Point(118, 0);
            this.btnPostpone.Name = "btnPostpone";
            this.btnPostpone.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPostpone.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnPostpone.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPostpone.selected = false;
            this.btnPostpone.Size = new System.Drawing.Size(118, 24);
            this.btnPostpone.TabIndex = 118;
            this.btnPostpone.Text = "Postpone";
            this.btnPostpone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPostpone.Textcolor = System.Drawing.Color.White;
            this.btnPostpone.TextFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostpone.Click += new System.EventHandler(this.btnPostpone_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDisable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisable.BorderRadius = 0;
            this.btnDisable.ButtonText = "Disable";
            this.btnDisable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisable.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDisable.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDisable.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisable.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDisable.Iconimage = null;
            this.btnDisable.Iconimage_right = null;
            this.btnDisable.Iconimage_right_Selected = null;
            this.btnDisable.Iconimage_Selected = null;
            this.btnDisable.IconMarginLeft = 0;
            this.btnDisable.IconMarginRight = 0;
            this.btnDisable.IconRightVisible = true;
            this.btnDisable.IconRightZoom = 0D;
            this.btnDisable.IconVisible = true;
            this.btnDisable.IconZoom = 50D;
            this.btnDisable.IsTab = false;
            this.btnDisable.Location = new System.Drawing.Point(0, 0);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDisable.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnDisable.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDisable.selected = false;
            this.btnDisable.Size = new System.Drawing.Size(118, 24);
            this.btnDisable.TabIndex = 7;
            this.btnDisable.Text = "Disable";
            this.btnDisable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDisable.Textcolor = System.Drawing.Color.White;
            this.btnDisable.TextFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlTop.Controls.Add(this.lblExit);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(356, 37);
            this.pnlTop.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(336, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(20, 19);
            this.lblExit.TabIndex = 2;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(132, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(93, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "RemindMe";
            this.lblTitle.Resize += new System.EventHandler(this.lblTitle_Resize);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 37);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tmrFadeout
            // 
            this.tmrFadeout.Interval = 10;
            this.tmrFadeout.Tick += new System.EventHandler(this.tmrFadeout_Tick);
            // 
            // tmrFadein
            // 
            this.tmrFadein.Interval = 10;
            this.tmrFadein.Tick += new System.EventHandler(this.tmrFadein_Tick);
            // 
            // tmrTimeout
            // 
            this.tmrTimeout.Interval = 1000;
            this.tmrTimeout.Tick += new System.EventHandler(this.tmrTimeout_Tick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 100;
            // 
            // RemindMeMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 136);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemindMeMessageForm";
            this.ShowInTaskbar = false;
            this.Text = "RemindMeMessageForm";
            this.Load += new System.EventHandler(this.RemindMeMessageForm_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlReminderOptions.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrFadeout;
        private System.Windows.Forms.Timer tmrFadein;
        private System.Windows.Forms.Timer tmrTimeout;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlReminderOptions;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuFlatButton btnSkip;
        private Bunifu.Framework.UI.BunifuFlatButton btnDisable;
        private Bunifu.Framework.UI.BunifuFlatButton btnPostpone;
    }
}