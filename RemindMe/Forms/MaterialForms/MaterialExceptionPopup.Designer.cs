namespace RemindMe
{
    partial class MaterialExceptionPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialExceptionPopup));
            this.lblText = new MaterialSkin.Controls.MaterialLabel();
            this.tbFeedback = new MaterialSkin.Controls.MaterialTextBox();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnOk = new MaterialSkin.Controls.MaterialButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pnlFooterButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Depth = 0;
            this.lblText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblText.Location = new System.Drawing.Point(7, 9);
            this.lblText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(475, 24);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Well damn... RemindMe has ran into an unexpected problem :( \r\n";
            // 
            // tbFeedback
            // 
            this.tbFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFeedback.Depth = 0;
            this.tbFeedback.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbFeedback.Hint = "If you can, please describe how this happened here";
            this.tbFeedback.Location = new System.Drawing.Point(7, 49);
            this.tbFeedback.MaxLength = 0;
            this.tbFeedback.MouseState = MaterialSkin.MouseState.OUT;
            this.tbFeedback.Multiline = false;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(443, 50);
            this.tbFeedback.TabIndex = 1;
            this.tbFeedback.Text = "";
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFooterButtons.Controls.Add(this.materialProgressBar1);
            this.pnlFooterButtons.Controls.Add(this.materialLabel1);
            this.pnlFooterButtons.Controls.Add(this.btnOk);
            this.pnlFooterButtons.Controls.Add(this.pbInfo);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 213);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(531, 60);
            this.pnlFooterButtons.TabIndex = 3;
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(531, 5);
            this.materialProgressBar1.TabIndex = 8;
            this.materialProgressBar1.Value = 100;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel1.Location = new System.Drawing.Point(44, 23);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(383, 22);
            this.materialLabel1.TabIndex = 7;
            this.materialLabel1.Text = "Describing this will higher the chance of it getting fixed.";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.Depth = 0;
            this.btnOk.DrawShadows = true;
            this.btnOk.HighEmphasis = true;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(433, 17);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 30);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOk.UseAccentColor = false;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(7, 33);
            this.lblMessage.MaximumSize = new System.Drawing.Size(450, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(54, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Extra info:";
            this.lblMessage.SizeChanged += new System.EventHandler(this.lblMessage_SizeChanged);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblText);
            this.pnlContent.Controls.Add(this.lblMessage);
            this.pnlContent.Controls.Add(this.tbFeedback);
            this.pnlContent.Location = new System.Drawing.Point(10, 68);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(453, 141);
            this.pnlContent.TabIndex = 6;
            // 
            // pbInfo
            // 
            this.pbInfo.BackgroundImage = global::RemindMe.Properties.Resources.infoDark;
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbInfo.Location = new System.Drawing.Point(10, 20);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(25, 25);
            this.pbInfo.TabIndex = 5;
            this.pbInfo.TabStop = false;
            // 
            // MaterialExceptionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 273);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooterButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialExceptionPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oops! RemindMe didn\'t expect that";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialExceptionPopup_FormClosing);
            this.Load += new System.EventHandler(this.ExceptionPopup_Load);
            this.pnlFooterButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblText;
        private MaterialSkin.Controls.MaterialTextBox tbFeedback;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private System.Windows.Forms.PictureBox pbInfo;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlContent;
    }
}