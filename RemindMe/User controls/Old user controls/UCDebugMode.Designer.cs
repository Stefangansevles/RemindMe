namespace RemindMe
{
    partial class UCDebugMode
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
            this.btnAppdataFolder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOpenErrorPrompt = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.tmrDetails = new System.Windows.Forms.Timer(this.components);
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tbSystemLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.btnCheckUpdate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRequery = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnRequery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAppdataFolder
            // 
            this.btnAppdataFolder.Activecolor = System.Drawing.Color.DimGray;
            this.btnAppdataFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAppdataFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppdataFolder.BorderRadius = 5;
            this.btnAppdataFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAppdataFolder.ButtonText = "Open appdata folder";
            this.btnAppdataFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppdataFolder.DisabledColor = System.Drawing.Color.Gray;
            this.btnAppdataFolder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppdataFolder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAppdataFolder.Iconimage = null;
            this.btnAppdataFolder.Iconimage_right = null;
            this.btnAppdataFolder.Iconimage_right_Selected = null;
            this.btnAppdataFolder.Iconimage_Selected = null;
            this.btnAppdataFolder.IconMarginLeft = 0;
            this.btnAppdataFolder.IconMarginRight = 0;
            this.btnAppdataFolder.IconRightVisible = true;
            this.btnAppdataFolder.IconRightZoom = 0D;
            this.btnAppdataFolder.IconVisible = true;
            this.btnAppdataFolder.IconZoom = 50D;
            this.btnAppdataFolder.IsTab = false;
            this.btnAppdataFolder.Location = new System.Drawing.Point(17, 12);
            this.btnAppdataFolder.Name = "btnAppdataFolder";
            this.btnAppdataFolder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAppdataFolder.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnAppdataFolder.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAppdataFolder.selected = false;
            this.btnAppdataFolder.Size = new System.Drawing.Size(150, 47);
            this.btnAppdataFolder.TabIndex = 5;
            this.btnAppdataFolder.Text = "Open appdata folder";
            this.btnAppdataFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAppdataFolder.Textcolor = System.Drawing.Color.White;
            this.btnAppdataFolder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppdataFolder.Click += new System.EventHandler(this.btnAppdataFolder_Click);
            // 
            // btnOpenErrorPrompt
            // 
            this.btnOpenErrorPrompt.Activecolor = System.Drawing.Color.DimGray;
            this.btnOpenErrorPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenErrorPrompt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenErrorPrompt.BorderRadius = 5;
            this.btnOpenErrorPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnOpenErrorPrompt.ButtonText = "Open Error prompt";
            this.btnOpenErrorPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenErrorPrompt.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenErrorPrompt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenErrorPrompt.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenErrorPrompt.Iconimage = null;
            this.btnOpenErrorPrompt.Iconimage_right = null;
            this.btnOpenErrorPrompt.Iconimage_right_Selected = null;
            this.btnOpenErrorPrompt.Iconimage_Selected = null;
            this.btnOpenErrorPrompt.IconMarginLeft = 0;
            this.btnOpenErrorPrompt.IconMarginRight = 0;
            this.btnOpenErrorPrompt.IconRightVisible = true;
            this.btnOpenErrorPrompt.IconRightZoom = 0D;
            this.btnOpenErrorPrompt.IconVisible = true;
            this.btnOpenErrorPrompt.IconZoom = 50D;
            this.btnOpenErrorPrompt.IsTab = false;
            this.btnOpenErrorPrompt.Location = new System.Drawing.Point(173, 12);
            this.btnOpenErrorPrompt.Name = "btnOpenErrorPrompt";
            this.btnOpenErrorPrompt.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenErrorPrompt.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnOpenErrorPrompt.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenErrorPrompt.selected = false;
            this.btnOpenErrorPrompt.Size = new System.Drawing.Size(150, 47);
            this.btnOpenErrorPrompt.TabIndex = 6;
            this.btnOpenErrorPrompt.Text = "Open Error prompt";
            this.btnOpenErrorPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOpenErrorPrompt.Textcolor = System.Drawing.Color.White;
            this.btnOpenErrorPrompt.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenErrorPrompt.Click += new System.EventHandler(this.btnOpenErrorPrompt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Memory";
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemoryUsage.ForeColor = System.Drawing.Color.White;
            this.lblMemoryUsage.Location = new System.Drawing.Point(34, 406);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(0, 16);
            this.lblMemoryUsage.TabIndex = 8;
            // 
            // tmrDetails
            // 
            this.tmrDetails.Interval = 1000;
            this.tmrDetails.Tick += new System.EventHandler(this.tmrDetails_Tick);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 5;
            this.bunifuFlatButton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton2.ButtonText = "Create new messageform";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = null;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 50D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(329, 12);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(150, 47);
            this.bunifuFlatButton2.TabIndex = 9;
            this.bunifuFlatButton2.Text = "Create new messageform";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // tbSystemLog
            // 
            this.tbSystemLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.tbSystemLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbSystemLog.ForeColor = System.Drawing.Color.White;
            this.tbSystemLog.Location = new System.Drawing.Point(17, 89);
            this.tbSystemLog.Multiline = true;
            this.tbSystemLog.Name = "tbSystemLog";
            this.tbSystemLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSystemLog.Size = new System.Drawing.Size(631, 288);
            this.tbSystemLog.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 94;
            this.label2.Text = "System log";
            // 
            // tmrLog
            // 
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.Activecolor = System.Drawing.Color.DimGray;
            this.btnCheckUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheckUpdate.BorderRadius = 5;
            this.btnCheckUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCheckUpdate.ButtonText = "Check for updates";
            this.btnCheckUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckUpdate.DisabledColor = System.Drawing.Color.Gray;
            this.btnCheckUpdate.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckUpdate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCheckUpdate.Iconimage = null;
            this.btnCheckUpdate.Iconimage_right = null;
            this.btnCheckUpdate.Iconimage_right_Selected = null;
            this.btnCheckUpdate.Iconimage_Selected = null;
            this.btnCheckUpdate.IconMarginLeft = 0;
            this.btnCheckUpdate.IconMarginRight = 0;
            this.btnCheckUpdate.IconRightVisible = true;
            this.btnCheckUpdate.IconRightZoom = 0D;
            this.btnCheckUpdate.IconVisible = true;
            this.btnCheckUpdate.IconZoom = 50D;
            this.btnCheckUpdate.IsTab = false;
            this.btnCheckUpdate.Location = new System.Drawing.Point(485, 12);
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckUpdate.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnCheckUpdate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCheckUpdate.selected = false;
            this.btnCheckUpdate.Size = new System.Drawing.Size(150, 47);
            this.btnCheckUpdate.TabIndex = 95;
            this.btnCheckUpdate.Text = "Check for updates";
            this.btnCheckUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCheckUpdate.Textcolor = System.Drawing.Color.White;
            this.btnCheckUpdate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // btnRequery
            // 
            this.btnRequery.BackColor = System.Drawing.Color.Transparent;
            this.btnRequery.Image = global::RemindMe.Properties.Resources.copy1;
            this.btnRequery.ImageActive = null;
            this.btnRequery.Location = new System.Drawing.Point(613, 383);
            this.btnRequery.Name = "btnRequery";
            this.btnRequery.Size = new System.Drawing.Size(35, 35);
            this.btnRequery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRequery.TabIndex = 96;
            this.btnRequery.TabStop = false;
            this.btnRequery.Zoom = 2;
            this.btnRequery.Click += new System.EventHandler(this.btnRequery_Click);
            // 
            // UCDebugMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.btnRequery);
            this.Controls.Add(this.btnCheckUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSystemLog);
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.lblMemoryUsage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenErrorPrompt);
            this.Controls.Add(this.btnAppdataFolder);
            this.Name = "UCDebugMode";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCDebugMode_Load);
            this.VisibleChanged += new System.EventHandler(this.UCDebugMode_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.btnRequery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnAppdataFolder;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenErrorPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Timer tmrDetails;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        public System.Windows.Forms.TextBox tbSystemLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrLog;
        private Bunifu.Framework.UI.BunifuFlatButton btnCheckUpdate;
        private Bunifu.Framework.UI.BunifuImageButton btnRequery;
    }
}
