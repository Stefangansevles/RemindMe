namespace RemindMe
{
    partial class MaterialPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialPopup));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.tbPostpone = new MaterialSkin.Controls.MaterialTextBox();
            this.cbPostpone = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnDisable = new MaterialSkin.Controls.MaterialButton();
            this.btnOk = new MaterialSkin.Controls.MaterialButton();
            this.pnlDateRepeatInformation = new System.Windows.Forms.Panel();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblRepeat = new MaterialSkin.Controls.MaterialLabel();
            this.lblSmallDate = new MaterialSkin.Controls.MaterialLabel();
            this.pbRepeat = new System.Windows.Forms.PictureBox();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.pnlText = new System.Windows.Forms.Panel();
            this.pnlFooter.SuspendLayout();
            this.pnlDateRepeatInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.tbPostpone);
            this.pnlFooter.Controls.Add(this.cbPostpone);
            this.pnlFooter.Controls.Add(this.btnDisable);
            this.pnlFooter.Controls.Add(this.btnOk);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 288);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(412, 33);
            this.pnlFooter.TabIndex = 0;
            // 
            // tbPostpone
            // 
            this.tbPostpone.BackColor = System.Drawing.SystemColors.Control;
            this.tbPostpone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPostpone.Depth = 0;
            this.tbPostpone.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPostpone.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbPostpone.Hint = "1h30m";
            this.tbPostpone.Location = new System.Drawing.Point(110, 0);
            this.tbPostpone.MaxLength = 50;
            this.tbPostpone.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPostpone.Multiline = false;
            this.tbPostpone.Name = "tbPostpone";
            this.tbPostpone.Size = new System.Drawing.Size(76, 36);
            this.tbPostpone.TabIndex = 2;
            this.tbPostpone.Text = "";
            this.tbPostpone.UseTallSize = false;
            this.tbPostpone.Visible = false;
            this.tbPostpone.TextChanged += new System.EventHandler(this.tbPostpone_TextChanged);
            // 
            // cbPostpone
            // 
            this.cbPostpone.AutoSize = true;
            this.cbPostpone.Depth = 0;
            this.cbPostpone.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbPostpone.Location = new System.Drawing.Point(0, 0);
            this.cbPostpone.Margin = new System.Windows.Forms.Padding(0);
            this.cbPostpone.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbPostpone.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbPostpone.Name = "cbPostpone";
            this.cbPostpone.Ripple = true;
            this.cbPostpone.Size = new System.Drawing.Size(110, 33);
            this.cbPostpone.TabIndex = 1;
            this.cbPostpone.Text = "Postpone  ";
            this.cbPostpone.UseVisualStyleBackColor = true;
            this.cbPostpone.CheckedChanged += new System.EventHandler(this.cbPostpone_OnChange_1);
            // 
            // btnDisable
            // 
            this.btnDisable.AutoSize = false;
            this.btnDisable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDisable.Depth = 0;
            this.btnDisable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDisable.DrawShadows = true;
            this.btnDisable.HighEmphasis = true;
            this.btnDisable.Icon = null;
            this.btnDisable.Location = new System.Drawing.Point(239, 0);
            this.btnDisable.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDisable.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(80, 33);
            this.btnDisable.TabIndex = 3;
            this.btnDisable.Text = "Disable";
            this.btnDisable.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnDisable.UseAccentColor = false;
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
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
            this.btnOk.Location = new System.Drawing.Point(319, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 33);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOk.UseAccentColor = false;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlDateRepeatInformation
            // 
            this.pnlDateRepeatInformation.Controls.Add(this.materialProgressBar1);
            this.pnlDateRepeatInformation.Controls.Add(this.lblRepeat);
            this.pnlDateRepeatInformation.Controls.Add(this.lblSmallDate);
            this.pnlDateRepeatInformation.Controls.Add(this.pbRepeat);
            this.pnlDateRepeatInformation.Controls.Add(this.pbDate);
            this.pnlDateRepeatInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDateRepeatInformation.Location = new System.Drawing.Point(0, 243);
            this.pnlDateRepeatInformation.Name = "pnlDateRepeatInformation";
            this.pnlDateRepeatInformation.Size = new System.Drawing.Size(412, 45);
            this.pnlDateRepeatInformation.TabIndex = 1;
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(412, 5);
            this.materialProgressBar1.TabIndex = 1;
            this.materialProgressBar1.Value = 100;
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Depth = 0;
            this.lblRepeat.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRepeat.Location = new System.Drawing.Point(232, 16);
            this.lblRepeat.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(100, 19);
            this.lblRepeat.TabIndex = 3;
            this.lblRepeat.Text = "Every 5 weeks";
            // 
            // lblSmallDate
            // 
            this.lblSmallDate.AutoSize = true;
            this.lblSmallDate.Depth = 0;
            this.lblSmallDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSmallDate.Location = new System.Drawing.Point(42, 16);
            this.lblSmallDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSmallDate.Name = "lblSmallDate";
            this.lblSmallDate.Size = new System.Drawing.Size(116, 19);
            this.lblSmallDate.TabIndex = 2;
            this.lblSmallDate.Text = "12-9-2020 13:00";
            // 
            // pbRepeat
            // 
            this.pbRepeat.BackgroundImage = global::RemindMe.Properties.Resources.Repeatwhite;
            this.pbRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRepeat.Location = new System.Drawing.Point(197, 10);
            this.pbRepeat.Name = "pbRepeat";
            this.pbRepeat.Size = new System.Drawing.Size(28, 28);
            this.pbRepeat.TabIndex = 1;
            this.pbRepeat.TabStop = false;
            // 
            // pbDate
            // 
            this.pbDate.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDate.Location = new System.Drawing.Point(6, 10);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(28, 28);
            this.pbDate.TabIndex = 0;
            this.pbDate.TabStop = false;
            // 
            // pnlText
            // 
            this.pnlText.AutoScroll = true;
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlText.Location = new System.Drawing.Point(0, 63);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(412, 180);
            this.pnlText.TabIndex = 2;
            // 
            // MaterialPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(412, 321);
            this.Controls.Add(this.pnlText);
            this.Controls.Add(this.pnlDateRepeatInformation);
            this.Controls.Add(this.pnlFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaterialPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialPopup_FormClosing);
            this.Load += new System.EventHandler(this.Popup_Load);
            this.SizeChanged += new System.EventHandler(this.Popup_SizeChanged);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlDateRepeatInformation.ResumeLayout(false);
            this.pnlDateRepeatInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlDateRepeatInformation;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private MaterialSkin.Controls.MaterialButton btnDisable;
        private MaterialSkin.Controls.MaterialTextBox tbPostpone;
        private MaterialSkin.Controls.MaterialCheckbox cbPostpone;
        private MaterialSkin.Controls.MaterialLabel lblRepeat;
        private MaterialSkin.Controls.MaterialLabel lblSmallDate;
        private System.Windows.Forms.PictureBox pbRepeat;
        private System.Windows.Forms.PictureBox pbDate;
        private System.Windows.Forms.Panel pnlText;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    }
}