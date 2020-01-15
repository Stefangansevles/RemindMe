namespace RemindMe
{
    partial class ExceptionPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionPopup));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlMainGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbDummy = new System.Windows.Forms.TextBox();
            this.pnlMainGradient.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlFooterButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnlMainGradient
            // 
            this.pnlMainGradient.AutoSize = true;
            this.pnlMainGradient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlMainGradient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMainGradient.BackgroundImage")));
            this.pnlMainGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainGradient.Controls.Add(this.tbDummy);
            this.pnlMainGradient.Controls.Add(this.lblMessage);
            this.pnlMainGradient.Controls.Add(this.tbFeedback);
            this.pnlMainGradient.Controls.Add(this.panel1);
            this.pnlMainGradient.Controls.Add(this.lblText);
            this.pnlMainGradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainGradient.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMainGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlMainGradient.Name = "pnlMainGradient";
            this.pnlMainGradient.Quality = 10;
            this.pnlMainGradient.Size = new System.Drawing.Size(531, 213);
            this.pnlMainGradient.TabIndex = 1;
            // 
            // tbFeedback
            // 
            this.tbFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFeedback.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFeedback.ForeColor = System.Drawing.Color.Gray;
            this.tbFeedback.Location = new System.Drawing.Point(16, 136);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(449, 68);
            this.tbFeedback.TabIndex = 5;
            this.tbFeedback.Text = "If you can, please describe how this happened here...";
            this.tbFeedback.Enter += new System.EventHandler(this.tbFeedback_Enter);
            this.tbFeedback.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFeedback_KeyUp);
            this.tbFeedback.Leave += new System.EventHandler(this.tbFeedback_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbIcon);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 59);
            this.panel1.TabIndex = 4;
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(62, 59);
            this.pbIcon.TabIndex = 3;
            this.pbIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(97, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(337, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Oops! RemindMe didn\'t expect that";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 8.75F);
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(14, 74);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(451, 34);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Well this is emberassing... RemindMe has ran into an unexpected problem :(\r\nDescr" +
    "ibing the problem will higher the likelihood of it getting fixed.\r\n";
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlFooterButtons.Controls.Add(this.pictureBox1);
            this.pnlFooterButtons.Controls.Add(this.label1);
            this.pnlFooterButtons.Controls.Add(this.btnOk);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 213);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(531, 60);
            this.pnlFooterButtons.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RemindMe.Properties.Resources.information_icon_6;
            this.pictureBox1.Location = new System.Drawing.Point(16, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "If you\'re not running the latest version of RemindMe,\r\nUpdating to the latest ver" +
    "sion might fix this.\r\n";
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
            this.btnOk.Location = new System.Drawing.Point(431, 18);
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
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.lblTitle;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.pbIcon;
            this.bunifuDragControl3.Vertical = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(14, 111);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(61, 16);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Extra info";
            // 
            // tbDummy
            // 
            this.tbDummy.Location = new System.Drawing.Point(535, 103);
            this.tbDummy.Name = "tbDummy";
            this.tbDummy.Size = new System.Drawing.Size(100, 20);
            this.tbDummy.TabIndex = 4;
            // 
            // ExceptionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 273);
            this.Controls.Add(this.pnlMainGradient);
            this.Controls.Add(this.pnlFooterButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExceptionPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExceptionPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExceptionPopup_FormClosing);
            this.Load += new System.EventHandler(this.ExceptionPopup_Load);
            this.pnlMainGradient.ResumeLayout(false);
            this.pnlMainGradient.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlFooterButtons.ResumeLayout(false);
            this.pnlFooterButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlMainGradient;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private Bunifu.Framework.UI.BunifuFlatButton btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbFeedback;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbDummy;
    }
}