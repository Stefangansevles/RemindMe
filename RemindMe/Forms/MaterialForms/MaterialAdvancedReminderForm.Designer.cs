namespace RemindMe
{
    partial class MaterialAdvancedReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialAdvancedReminderForm));
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabHTTP = new System.Windows.Forms.TabPage();
            this.tabBatch = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.tbBatch = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.cbHideReminder = new MaterialSkin.Controls.MaterialSwitch();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainTabControl.SuspendLayout();
            this.tabBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabHTTP);
            this.mainTabControl.Controls.Add(this.tabBatch);
            this.mainTabControl.Depth = 0;
            this.mainTabControl.ImageList = this.imageList;
            this.mainTabControl.Location = new System.Drawing.Point(135, 64);
            this.mainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(777, 516);
            this.mainTabControl.TabIndex = 132;
            // 
            // tabHTTP
            // 
            this.tabHTTP.BackColor = System.Drawing.Color.Transparent;
            this.tabHTTP.ImageKey = "icons8-website-48.png";
            this.tabHTTP.Location = new System.Drawing.Point(4, 33);
            this.tabHTTP.Name = "tabHTTP";
            this.tabHTTP.Padding = new System.Windows.Forms.Padding(3);
            this.tabHTTP.Size = new System.Drawing.Size(769, 479);
            this.tabHTTP.TabIndex = 1;
            this.tabHTTP.Text = "API";
            // 
            // tabBatch
            // 
            this.tabBatch.BackColor = System.Drawing.SystemColors.Control;
            this.tabBatch.Controls.Add(this.materialLabel1);
            this.tabBatch.Controls.Add(this.btnConfirm);
            this.tabBatch.Controls.Add(this.tbBatch);
            this.tabBatch.Controls.Add(this.cbHideReminder);
            this.tabBatch.ImageKey = "consoleBlack.png";
            this.tabBatch.Location = new System.Drawing.Point(4, 33);
            this.tabBatch.Name = "tabBatch";
            this.tabBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabBatch.Size = new System.Drawing.Size(769, 479);
            this.tabBatch.TabIndex = 0;
            this.tabBatch.Text = "Batch";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(40, 27);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(551, 42);
            this.materialLabel1.TabIndex = 134;
            this.materialLabel1.Text = "You can paste Windows Batch code here. The reminder will execute the code \r\nwhen " +
    "the reminder pops up. Either at a date, or through the API configuration\r\n";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.DrawShadows = true;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = global::RemindMe.Properties.Resources.saveWhite;
            this.btnConfirm.Location = new System.Drawing.Point(40, 245);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(175, 35);
            this.btnConfirm.TabIndex = 132;
            this.btnConfirm.Text = "SAVE";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tbBatch
            // 
            this.tbBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBatch.Depth = 0;
            this.tbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.tbBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbBatch.Hint = "";
            this.tbBatch.Location = new System.Drawing.Point(40, 77);
            this.tbBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbBatch.Size = new System.Drawing.Size(551, 159);
            this.tbBatch.TabIndex = 133;
            this.tbBatch.Text = "!! ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING !!\n\ndo not paste batch script her" +
    "e from someone you don\'t trust";
            // 
            // cbHideReminder
            // 
            this.cbHideReminder.AutoSize = true;
            this.cbHideReminder.Depth = 0;
            this.cbHideReminder.Location = new System.Drawing.Point(219, 243);
            this.cbHideReminder.Margin = new System.Windows.Forms.Padding(0);
            this.cbHideReminder.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbHideReminder.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbHideReminder.Name = "cbHideReminder";
            this.cbHideReminder.Ripple = true;
            this.cbHideReminder.Size = new System.Drawing.Size(317, 37);
            this.cbHideReminder.TabIndex = 135;
            this.cbHideReminder.Text = "Hide reminder popup ( Execute-only )";
            this.cbHideReminder.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "consoleBlack.png");
            this.imageList.Images.SetKeyName(1, "icons8-website-48.png");
            // 
            // MaterialAdvancedReminderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(915, 587);
            this.Controls.Add(this.mainTabControl);
            this.DisableDrawerSlide = true;
            this.DrawerAutoHide = false;
            this.DrawerIsOpen = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.mainTabControl;
            this.DrawerWidth = 135;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialAdvancedReminderForm";
            this.Text = "Advanced Reminder functionality";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialAdvancedReminderForm_FormClosing);
            this.Load += new System.EventHandler(this.MaterialAdvancedReminderForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabBatch.ResumeLayout(false);
            this.tabBatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrFadeIn;
        private MaterialSkin.Controls.MaterialTabControl mainTabControl;
        private System.Windows.Forms.TabPage tabBatch;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbBatch;
        private MaterialSkin.Controls.MaterialSwitch cbHideReminder;
        private System.Windows.Forms.TabPage tabHTTP;
        private System.Windows.Forms.ImageList imageList;
    }
}