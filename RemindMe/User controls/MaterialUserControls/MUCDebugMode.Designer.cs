namespace RemindMe
{
    partial class MUCDebugMode
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
            this.btnAppdataFolder = new MaterialSkin.Controls.MaterialButton();
            this.btnOpenErrorPrompt = new MaterialSkin.Controls.MaterialButton();
            this.bunifuFlatButton2 = new MaterialSkin.Controls.MaterialButton();
            this.btnCheckUpdate = new MaterialSkin.Controls.MaterialButton();
            this.btnRequery = new MaterialSkin.Controls.MaterialButton();
            this.lblMemoryUsage = new MaterialSkin.Controls.MaterialLabel();
            this.tbSystemLog = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tmrDetails = new System.Windows.Forms.Timer(this.components);
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnAppdataFolder
            // 
            this.btnAppdataFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAppdataFolder.Depth = 0;
            this.btnAppdataFolder.DrawShadows = true;
            this.btnAppdataFolder.HighEmphasis = true;
            this.btnAppdataFolder.Icon = null;
            this.btnAppdataFolder.Location = new System.Drawing.Point(16, 7);
            this.btnAppdataFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAppdataFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAppdataFolder.Name = "btnAppdataFolder";
            this.btnAppdataFolder.Size = new System.Drawing.Size(187, 36);
            this.btnAppdataFolder.TabIndex = 0;
            this.btnAppdataFolder.Text = "Open appdata folder";
            this.btnAppdataFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAppdataFolder.UseAccentColor = false;
            this.btnAppdataFolder.UseVisualStyleBackColor = true;
            this.btnAppdataFolder.Click += new System.EventHandler(this.btnAppdataFolder_Click);
            // 
            // btnOpenErrorPrompt
            // 
            this.btnOpenErrorPrompt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenErrorPrompt.Depth = 0;
            this.btnOpenErrorPrompt.DrawShadows = true;
            this.btnOpenErrorPrompt.HighEmphasis = true;
            this.btnOpenErrorPrompt.Icon = null;
            this.btnOpenErrorPrompt.Location = new System.Drawing.Point(211, 7);
            this.btnOpenErrorPrompt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpenErrorPrompt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenErrorPrompt.Name = "btnOpenErrorPrompt";
            this.btnOpenErrorPrompt.Size = new System.Drawing.Size(173, 36);
            this.btnOpenErrorPrompt.TabIndex = 1;
            this.btnOpenErrorPrompt.Text = "Open Error prompt";
            this.btnOpenErrorPrompt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOpenErrorPrompt.UseAccentColor = false;
            this.btnOpenErrorPrompt.UseVisualStyleBackColor = true;
            this.btnOpenErrorPrompt.Click += new System.EventHandler(this.btnOpenErrorPrompt_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bunifuFlatButton2.Depth = 0;
            this.bunifuFlatButton2.DrawShadows = true;
            this.bunifuFlatButton2.HighEmphasis = true;
            this.bunifuFlatButton2.Icon = null;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(392, 7);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bunifuFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Size = new System.Drawing.Size(223, 36);
            this.bunifuFlatButton2.TabIndex = 2;
            this.bunifuFlatButton2.Text = "Create new messageform";
            this.bunifuFlatButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.bunifuFlatButton2.UseAccentColor = false;
            this.bunifuFlatButton2.UseVisualStyleBackColor = true;
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheckUpdate.Depth = 0;
            this.btnCheckUpdate.DrawShadows = true;
            this.btnCheckUpdate.HighEmphasis = true;
            this.btnCheckUpdate.Icon = null;
            this.btnCheckUpdate.Location = new System.Drawing.Point(618, 7);
            this.btnCheckUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCheckUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Size = new System.Drawing.Size(168, 36);
            this.btnCheckUpdate.TabIndex = 3;
            this.btnCheckUpdate.Text = "Check for updates";
            this.btnCheckUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheckUpdate.UseAccentColor = false;
            this.btnCheckUpdate.UseVisualStyleBackColor = true;
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // btnRequery
            // 
            this.btnRequery.AutoSize = false;
            this.btnRequery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRequery.Depth = 0;
            this.btnRequery.DrawShadows = true;
            this.btnRequery.HighEmphasis = true;
            this.btnRequery.Icon = global::RemindMe.Properties.Resources.copy;
            this.btnRequery.Location = new System.Drawing.Point(741, 459);
            this.btnRequery.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRequery.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRequery.Name = "btnRequery";
            this.btnRequery.Size = new System.Drawing.Size(45, 35);
            this.btnRequery.TabIndex = 5;
            this.btnRequery.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRequery.UseAccentColor = false;
            this.btnRequery.UseVisualStyleBackColor = true;
            this.btnRequery.Click += new System.EventHandler(this.btnRequery_Click);
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Depth = 0;
            this.lblMemoryUsage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMemoryUsage.Location = new System.Drawing.Point(22, 459);
            this.lblMemoryUsage.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(59, 19);
            this.lblMemoryUsage.TabIndex = 6;
            this.lblMemoryUsage.Text = "Memory";
            // 
            // tbSystemLog
            // 
            this.tbSystemLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbSystemLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSystemLog.Depth = 0;
            this.tbSystemLog.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSystemLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbSystemLog.Hint = "";
            this.tbSystemLog.Location = new System.Drawing.Point(16, 52);
            this.tbSystemLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbSystemLog.Name = "tbSystemLog";
            this.tbSystemLog.ReadOnly = true;
            this.tbSystemLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbSystemLog.Size = new System.Drawing.Size(770, 398);
            this.tbSystemLog.TabIndex = 7;
            this.tbSystemLog.Text = "";
            // 
            // tmrDetails
            // 
            this.tmrDetails.Interval = 1000;
            this.tmrDetails.Tick += new System.EventHandler(this.tmrDetails_Tick);
            // 
            // tmrLog
            // 
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // MUCDebugMode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tbSystemLog);
            this.Controls.Add(this.lblMemoryUsage);
            this.Controls.Add(this.btnRequery);
            this.Controls.Add(this.btnCheckUpdate);
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.btnOpenErrorPrompt);
            this.Controls.Add(this.btnAppdataFolder);
            this.Name = "MUCDebugMode";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCDebugMode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnAppdataFolder;
        private MaterialSkin.Controls.MaterialButton btnOpenErrorPrompt;
        private MaterialSkin.Controls.MaterialButton bunifuFlatButton2;
        private MaterialSkin.Controls.MaterialButton btnCheckUpdate;
        private MaterialSkin.Controls.MaterialButton btnRequery;
        private MaterialSkin.Controls.MaterialLabel lblMemoryUsage;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbSystemLog;
        private System.Windows.Forms.Timer tmrDetails;
        private System.Windows.Forms.Timer tmrLog;
    }
}
