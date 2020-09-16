namespace RemindMe
{
    partial class MaterialRemindMePrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialRemindMePrompt));
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.tbPrompt = new MaterialSkin.Controls.MaterialTextBox();
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.btnOk = new MaterialSkin.Controls.MaterialButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblText = new MaterialSkin.Controls.MaterialLabel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlFooterButtons.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // tbPrompt
            // 
            this.tbPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.tbPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrompt.Depth = 0;
            this.tbPrompt.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbPrompt.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbPrompt.Location = new System.Drawing.Point(0, 0);
            this.tbPrompt.MaxLength = 0;
            this.tbPrompt.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPrompt.Multiline = false;
            this.tbPrompt.Name = "tbPrompt";
            this.tbPrompt.Size = new System.Drawing.Size(437, 36);
            this.tbPrompt.TabIndex = 8;
            this.tbPrompt.Text = "";
            this.tbPrompt.UseTallSize = false;
            this.tbPrompt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPrompt_KeyUp);
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFooterButtons.Controls.Add(this.tbPrompt);
            this.pnlFooterButtons.Controls.Add(this.btnOk);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 163);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(512, 34);
            this.pnlFooterButtons.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.Depth = 0;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.DrawShadows = true;
            this.btnOk.HighEmphasis = true;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(437, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 34);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOk.UseAccentColor = false;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Controls.Add(this.pbIcon);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMain.Location = new System.Drawing.Point(0, 64);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(512, 99);
            this.pnlMain.TabIndex = 11;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Depth = 0;
            this.lblText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblText.Location = new System.Drawing.Point(112, 20);
            this.lblText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(257, 19);
            this.lblText.TabIndex = 10;
            this.lblText.Text = "Enter a value and press \"OK\" or enter";
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Location = new System.Drawing.Point(23, 17);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(62, 58);
            this.pbIcon.TabIndex = 7;
            this.pbIcon.TabStop = false;
            // 
            // MaterialRemindMePrompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(512, 197);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooterButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialRemindMePrompt";
            this.Text = "Attention!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialRemindMePrompt_FormClosing);
            this.Load += new System.EventHandler(this.RemindMePrompt_Load);
            this.pnlFooterButtons.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.PictureBox pbIcon;
        private MaterialSkin.Controls.MaterialTextBox tbPrompt;
        private System.Windows.Forms.Panel pnlFooterButtons;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private System.Windows.Forms.Panel pnlMain;
        private MaterialSkin.Controls.MaterialLabel lblText;
    }
}