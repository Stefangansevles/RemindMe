namespace RemindMe
{
    partial class ErrorPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorPopup));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlMainGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSubmitFeedback = new System.Windows.Forms.Panel();
            this.btnCancel = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnSubmit = new Bunifu.Framework.UI.BunifuTileButton();
            this.lblPleaseDescribe = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.btnYes = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnNo = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnShowDetails = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlMainGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlSubmitFeedback.SuspendLayout();
            this.pnlFooterButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlMainGradient;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnlMainGradient
            // 
            this.pnlMainGradient.AutoSize = true;
            this.pnlMainGradient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMainGradient.BackgroundImage")));
            this.pnlMainGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainGradient.Controls.Add(this.pbIcon);
            this.pnlMainGradient.Controls.Add(this.lblText);
            this.pnlMainGradient.Controls.Add(this.lblTitle);
            this.pnlMainGradient.Controls.Add(this.pnlSubmitFeedback);
            this.pnlMainGradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainGradient.GradientBottomLeft = System.Drawing.Color.Black;
            this.pnlMainGradient.GradientBottomRight = System.Drawing.Color.Black;
            this.pnlMainGradient.GradientTopLeft = System.Drawing.Color.DimGray;
            this.pnlMainGradient.GradientTopRight = System.Drawing.Color.DimGray;
            this.pnlMainGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlMainGradient.Name = "pnlMainGradient";
            this.pnlMainGradient.Quality = 10;
            this.pnlMainGradient.Size = new System.Drawing.Size(475, 121);
            this.pnlMainGradient.TabIndex = 3;
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.err;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Location = new System.Drawing.Point(33, 12);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(62, 58);
            this.pbIcon.TabIndex = 11;
            this.pbIcon.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(125, 53);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(256, 17);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "Could you report how this happened?";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(124, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(316, 23);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Aww Damn! An error has occured";
            // 
            // pnlSubmitFeedback
            // 
            this.pnlSubmitFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlSubmitFeedback.Controls.Add(this.btnCancel);
            this.pnlSubmitFeedback.Controls.Add(this.btnSubmit);
            this.pnlSubmitFeedback.Controls.Add(this.lblPleaseDescribe);
            this.pnlSubmitFeedback.Controls.Add(this.tbNote);
            this.pnlSubmitFeedback.Location = new System.Drawing.Point(285, 15);
            this.pnlSubmitFeedback.Name = "pnlSubmitFeedback";
            this.pnlSubmitFeedback.Size = new System.Drawing.Size(435, 106);
            this.pnlSubmitFeedback.TabIndex = 8;
            this.pnlSubmitFeedback.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCancel.color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCancel.colorActive = System.Drawing.Color.DimGray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = null;
            this.btnCancel.ImagePosition = 12;
            this.btnCancel.ImageZoom = 50;
            this.btnCancel.LabelPosition = 22;
            this.btnCancel.LabelText = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(88, 73);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 96;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSubmit.color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSubmit.colorActive = System.Drawing.Color.DimGray;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Image = null;
            this.btnSubmit.ImagePosition = 12;
            this.btnSubmit.ImageZoom = 50;
            this.btnSubmit.LabelPosition = 22;
            this.btnSubmit.LabelText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(5, 73);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(79, 30);
            this.btnSubmit.TabIndex = 95;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblPleaseDescribe
            // 
            this.lblPleaseDescribe.AutoSize = true;
            this.lblPleaseDescribe.BackColor = System.Drawing.Color.Transparent;
            this.lblPleaseDescribe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPleaseDescribe.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseDescribe.ForeColor = System.Drawing.Color.White;
            this.lblPleaseDescribe.Location = new System.Drawing.Point(0, 0);
            this.lblPleaseDescribe.Name = "lblPleaseDescribe";
            this.lblPleaseDescribe.Size = new System.Drawing.Size(390, 17);
            this.lblPleaseDescribe.TabIndex = 93;
            this.lblPleaseDescribe.Text = "Please describe how this happened as detailed as possible ";
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbNote.ForeColor = System.Drawing.Color.White;
            this.tbNote.Location = new System.Drawing.Point(5, 20);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(427, 51);
            this.tbNote.TabIndex = 92;
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlFooterButtons.Controls.Add(this.btnYes);
            this.pnlFooterButtons.Controls.Add(this.btnNo);
            this.pnlFooterButtons.Controls.Add(this.btnShowDetails);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 121);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(475, 106);
            this.pnlFooterButtons.TabIndex = 1;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnYes.color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnYes.colorActive = System.Drawing.Color.DimGray;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Image = null;
            this.btnYes.ImagePosition = 12;
            this.btnYes.ImageZoom = 50;
            this.btnYes.LabelPosition = 22;
            this.btnYes.LabelText = "Yes";
            this.btnYes.Location = new System.Drawing.Point(333, 25);
            this.btnYes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(79, 30);
            this.btnYes.TabIndex = 86;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNo.color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNo.colorActive = System.Drawing.Color.DimGray;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Image = null;
            this.btnNo.ImagePosition = 12;
            this.btnNo.ImageZoom = 50;
            this.btnNo.LabelPosition = 22;
            this.btnNo.LabelText = "No";
            this.btnNo.Location = new System.Drawing.Point(248, 25);
            this.btnNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(79, 30);
            this.btnNo.TabIndex = 85;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Activecolor = System.Drawing.Color.DimGray;
            this.btnShowDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnShowDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowDetails.BorderRadius = 5;
            this.btnShowDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnShowDetails.ButtonText = "  Advanced details";
            this.btnShowDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowDetails.DisabledColor = System.Drawing.Color.Gray;
            this.btnShowDetails.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnShowDetails.Iconcolor = System.Drawing.Color.Transparent;
            this.btnShowDetails.Iconimage = null;
            this.btnShowDetails.Iconimage_right = null;
            this.btnShowDetails.Iconimage_right_Selected = null;
            this.btnShowDetails.Iconimage_Selected = null;
            this.btnShowDetails.IconMarginLeft = 0;
            this.btnShowDetails.IconMarginRight = 0;
            this.btnShowDetails.IconRightVisible = true;
            this.btnShowDetails.IconRightZoom = 0D;
            this.btnShowDetails.IconVisible = true;
            this.btnShowDetails.IconZoom = 50D;
            this.btnShowDetails.IsTab = false;
            this.btnShowDetails.Location = new System.Drawing.Point(12, 25);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnShowDetails.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnShowDetails.OnHoverTextColor = System.Drawing.Color.White;
            this.btnShowDetails.selected = false;
            this.btnShowDetails.Size = new System.Drawing.Size(130, 30);
            this.btnShowDetails.TabIndex = 7;
            this.btnShowDetails.Text = "  Advanced details";
            this.btnShowDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowDetails.Textcolor = System.Drawing.Color.White;
            this.btnShowDetails.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.lblTitle;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ErrorPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 227);
            this.Controls.Add(this.pnlMainGradient);
            this.Controls.Add(this.pnlFooterButtons);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ErrorPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorPopup_FormClosing);
            this.pnlMainGradient.ResumeLayout(false);
            this.pnlMainGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlSubmitFeedback.ResumeLayout(false);
            this.pnlSubmitFeedback.PerformLayout();
            this.pnlFooterButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private Bunifu.Framework.UI.BunifuFlatButton btnShowDetails;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlMainGradient;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSubmitFeedback;
        private System.Windows.Forms.Label lblPleaseDescribe;
        public System.Windows.Forms.TextBox tbNote;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuTileButton btnCancel;
        private Bunifu.Framework.UI.BunifuTileButton btnSubmit;
        private Bunifu.Framework.UI.BunifuTileButton btnYes;
        private Bunifu.Framework.UI.BunifuTileButton btnNo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}