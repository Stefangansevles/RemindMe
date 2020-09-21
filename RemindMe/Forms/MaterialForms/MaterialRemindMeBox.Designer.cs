namespace RemindMe
{
    partial class MaterialRemindMeBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialRemindMeBox));
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.btnOk = new MaterialSkin.Controls.MaterialButton();
            this.pnlRemind = new System.Windows.Forms.Panel();
            this.cbDontRemind = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnYes = new MaterialSkin.Controls.MaterialButton();
            this.btnNo = new MaterialSkin.Controls.MaterialButton();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.pnlMainGradient = new System.Windows.Forms.Panel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlFooterButtons.SuspendLayout();
            this.pnlRemind.SuspendLayout();
            this.pnlMainGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.Controls.Add(this.materialProgressBar1);
            this.pnlFooterButtons.Controls.Add(this.btnOk);
            this.pnlFooterButtons.Controls.Add(this.pnlRemind);
            this.pnlFooterButtons.Controls.Add(this.btnYes);
            this.pnlFooterButtons.Controls.Add(this.btnNo);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 188);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(374, 70);
            this.pnlFooterButtons.TabIndex = 0;
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(374, 5);
            this.materialProgressBar1.TabIndex = 10;
            this.materialProgressBar1.Value = 100;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.Depth = 0;
            this.btnOk.DrawShadows = true;
            this.btnOk.HighEmphasis = true;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(272, 21);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 30);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOk.UseAccentColor = false;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlRemind
            // 
            this.pnlRemind.Controls.Add(this.cbDontRemind);
            this.pnlRemind.Location = new System.Drawing.Point(4, 16);
            this.pnlRemind.Name = "pnlRemind";
            this.pnlRemind.Size = new System.Drawing.Size(175, 36);
            this.pnlRemind.TabIndex = 8;
            this.pnlRemind.Visible = false;
            // 
            // cbDontRemind
            // 
            this.cbDontRemind.AutoSize = true;
            this.cbDontRemind.Depth = 0;
            this.cbDontRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDontRemind.Location = new System.Drawing.Point(0, 0);
            this.cbDontRemind.Margin = new System.Windows.Forms.Padding(0);
            this.cbDontRemind.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDontRemind.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbDontRemind.Name = "cbDontRemind";
            this.cbDontRemind.Ripple = true;
            this.cbDontRemind.Size = new System.Drawing.Size(169, 37);
            this.cbDontRemind.TabIndex = 0;
            this.cbDontRemind.Text = "Don\'t remind again";
            this.cbDontRemind.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.AutoSize = false;
            this.btnYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYes.Depth = 0;
            this.btnYes.DrawShadows = true;
            this.btnYes.HighEmphasis = true;
            this.btnYes.Icon = null;
            this.btnYes.Location = new System.Drawing.Point(272, 21);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(79, 30);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYes.UseAccentColor = false;
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AutoSize = false;
            this.btnNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNo.Depth = 0;
            this.btnNo.DrawShadows = true;
            this.btnNo.HighEmphasis = true;
            this.btnNo.Icon = null;
            this.btnNo.Location = new System.Drawing.Point(185, 21);
            this.btnNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(79, 30);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNo.UseAccentColor = false;
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick_1);
            // 
            // pnlMainGradient
            // 
            this.pnlMainGradient.Controls.Add(this.pbIcon);
            this.pnlMainGradient.Controls.Add(this.lblText);
            this.pnlMainGradient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMainGradient.Location = new System.Drawing.Point(0, 63);
            this.pnlMainGradient.Name = "pnlMainGradient";
            this.pnlMainGradient.Size = new System.Drawing.Size(374, 125);
            this.pnlMainGradient.TabIndex = 1;
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Location = new System.Drawing.Point(12, 14);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(62, 58);
            this.pbIcon.TabIndex = 6;
            this.pbIcon.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(103, 14);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(32, 17);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Text";
            // 
            // MaterialRemindMeBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(374, 258);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainGradient);
            this.Controls.Add(this.pnlFooterButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialRemindMeBox";
            this.StatusBarHeight = 0;
            this.Text = "Attention!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialRemindMeBox_FormClosing);
            this.Load += new System.EventHandler(this.MaterialRemindMeBox_Load);
            this.pnlFooterButtons.ResumeLayout(false);
            this.pnlRemind.ResumeLayout(false);
            this.pnlRemind.PerformLayout();
            this.pnlMainGradient.ResumeLayout(false);
            this.pnlMainGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooterButtons;
        private MaterialSkin.Controls.MaterialCheckbox cbDontRemind;
        private MaterialSkin.Controls.MaterialButton btnNo;
        private MaterialSkin.Controls.MaterialButton btnYes;
        private System.Windows.Forms.Panel pnlRemind;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.Panel pnlMainGradient;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblText;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    }
}