namespace RemindMe
{
    partial class RemindMeBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMeBox));
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlMainGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.pnlRemind = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbDontRemind = new Bunifu.Framework.UI.BunifuCheckbox();
            this.btnYes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlMainGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlFooterButtons.SuspendLayout();
            this.pnlRemind.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlMainGradient.Controls.Add(this.lblTitle);
            this.pnlMainGradient.Controls.Add(this.lblText);
            this.pnlMainGradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainGradient.GradientBottomLeft = System.Drawing.Color.Black;
            this.pnlMainGradient.GradientBottomRight = System.Drawing.Color.Black;
            this.pnlMainGradient.GradientTopLeft = System.Drawing.Color.DimGray;
            this.pnlMainGradient.GradientTopRight = System.Drawing.Color.DimGray;
            this.pnlMainGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlMainGradient.Name = "pnlMainGradient";
            this.pnlMainGradient.Quality = 10;
            this.pnlMainGradient.Size = new System.Drawing.Size(374, 172);
            this.pnlMainGradient.TabIndex = 0;
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Location = new System.Drawing.Point(12, 34);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(62, 58);
            this.pbIcon.TabIndex = 3;
            this.pbIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(103, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Attention!";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(104, 75);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(32, 17);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Text";
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlFooterButtons.Controls.Add(this.pnlRemind);
            this.pnlFooterButtons.Controls.Add(this.btnYes);
            this.pnlFooterButtons.Controls.Add(this.btnNo);
            this.pnlFooterButtons.Controls.Add(this.btnOk);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 172);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(374, 86);
            this.pnlFooterButtons.TabIndex = 0;
            // 
            // pnlRemind
            // 
            this.pnlRemind.Controls.Add(this.label13);
            this.pnlRemind.Controls.Add(this.cbDontRemind);
            this.pnlRemind.Location = new System.Drawing.Point(8, 23);
            this.pnlRemind.Name = "pnlRemind";
            this.pnlRemind.Size = new System.Drawing.Size(151, 30);
            this.pnlRemind.TabIndex = 7;
            this.pnlRemind.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(27, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 17);
            this.label13.TabIndex = 105;
            this.label13.Text = "Don\'t remind again";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // cbDontRemind
            // 
            this.cbDontRemind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbDontRemind.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbDontRemind.Checked = false;
            this.cbDontRemind.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbDontRemind.ForeColor = System.Drawing.Color.White;
            this.cbDontRemind.Location = new System.Drawing.Point(5, 6);
            this.cbDontRemind.Name = "cbDontRemind";
            this.cbDontRemind.Size = new System.Drawing.Size(20, 20);
            this.cbDontRemind.TabIndex = 104;
            // 
            // btnYes
            // 
            this.btnYes.Activecolor = System.Drawing.Color.DimGray;
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.BorderRadius = 5;
            this.btnYes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnYes.ButtonText = "    Yes";
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.DisabledColor = System.Drawing.Color.Gray;
            this.btnYes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnYes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnYes.Iconimage = null;
            this.btnYes.Iconimage_right = null;
            this.btnYes.Iconimage_right_Selected = null;
            this.btnYes.Iconimage_Selected = null;
            this.btnYes.IconMarginLeft = 0;
            this.btnYes.IconMarginRight = 0;
            this.btnYes.IconRightVisible = true;
            this.btnYes.IconRightZoom = 0D;
            this.btnYes.IconVisible = true;
            this.btnYes.IconZoom = 50D;
            this.btnYes.IsTab = false;
            this.btnYes.Location = new System.Drawing.Point(256, 23);
            this.btnYes.Name = "btnYes";
            this.btnYes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnYes.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnYes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnYes.selected = false;
            this.btnYes.Size = new System.Drawing.Size(79, 30);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "    Yes";
            this.btnYes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Textcolor = System.Drawing.Color.White;
            this.btnYes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Activecolor = System.Drawing.Color.DimGray;
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.BorderRadius = 5;
            this.btnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNo.ButtonText = "    No";
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DisabledColor = System.Drawing.Color.Gray;
            this.btnNo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnNo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNo.Iconimage = null;
            this.btnNo.Iconimage_right = null;
            this.btnNo.Iconimage_right_Selected = null;
            this.btnNo.Iconimage_Selected = null;
            this.btnNo.IconMarginLeft = 0;
            this.btnNo.IconMarginRight = 0;
            this.btnNo.IconRightVisible = true;
            this.btnNo.IconRightZoom = 0D;
            this.btnNo.IconVisible = true;
            this.btnNo.IconZoom = 50D;
            this.btnNo.IsTab = false;
            this.btnNo.Location = new System.Drawing.Point(171, 23);
            this.btnNo.Name = "btnNo";
            this.btnNo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNo.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnNo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNo.selected = false;
            this.btnNo.Size = new System.Drawing.Size(79, 30);
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "    No";
            this.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Textcolor = System.Drawing.Color.White;
            this.btnNo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOk
            // 
            this.btnOk.Activecolor = System.Drawing.Color.DimGray;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.BorderRadius = 5;
            this.btnOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnOk.ButtonText = "    OK";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DisabledColor = System.Drawing.Color.Gray;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnOk.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOk.Iconimage = null;
            this.btnOk.Iconimage_right = null;
            this.btnOk.Iconimage_right_Selected = null;
            this.btnOk.Iconimage_Selected = null;
            this.btnOk.IconMarginLeft = 0;
            this.btnOk.IconMarginRight = 0;
            this.btnOk.IconRightVisible = true;
            this.btnOk.IconRightZoom = 0D;
            this.btnOk.IconVisible = true;
            this.btnOk.IconZoom = 50D;
            this.btnOk.IsTab = false;
            this.btnOk.Location = new System.Drawing.Point(256, 23);
            this.btnOk.Name = "btnOk";
            this.btnOk.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnOk.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnOk.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOk.selected = false;
            this.btnOk.Size = new System.Drawing.Size(79, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "    OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Textcolor = System.Drawing.Color.White;
            this.btnOk.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // RemindMeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 258);
            this.Controls.Add(this.pnlMainGradient);
            this.Controls.Add(this.pnlFooterButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemindMeBox";
            this.Text = "Attention!";
            this.pnlMainGradient.ResumeLayout(false);
            this.pnlMainGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlFooterButtons.ResumeLayout(false);
            this.pnlRemind.ResumeLayout(false);
            this.pnlRemind.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrFadeIn;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlMainGradient;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private Bunifu.Framework.UI.BunifuFlatButton btnNo;
        private Bunifu.Framework.UI.BunifuFlatButton btnOk;
        private Bunifu.Framework.UI.BunifuFlatButton btnYes;
        private System.Windows.Forms.Panel pnlRemind;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuCheckbox cbDontRemind;
    }
}