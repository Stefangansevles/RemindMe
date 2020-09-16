namespace RemindMe
{
    partial class MaterialForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialForm1));
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabReminders = new System.Windows.Forms.TabPage();
            this.tabTimer = new System.Windows.Forms.TabPage();
            this.tabBackupImport = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabSoundEffects = new System.Windows.Forms.TabPage();
            this.tabResizePopup = new System.Windows.Forms.TabPage();
            this.tabMessageCenter = new System.Windows.Forms.TabPage();
            this.tabTheme = new System.Windows.Forms.TabPage();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.drawerIconsList = new System.Windows.Forms.ImageList(this.components);
            this.tmrInitialHide = new System.Windows.Forms.Timer(this.components);
            this.tmrCheckRemindMeMessages = new System.Windows.Forms.Timer(this.components);
            this.tmrDumpLogTxtContents = new System.Windows.Forms.Timer(this.components);
            this.tmrEnableDatabaseAccess = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateRemindMe = new System.Windows.Forms.Timer(this.components);
            this.tmrDebugMode = new System.Windows.Forms.Timer(this.components);
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.tmrPingActivity = new System.Windows.Forms.Timer(this.components);
            this.RemindMeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RemindMeTrayIconMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.restartRemindMeUpdateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitRemindMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemindMeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrRemoveDebug = new System.Windows.Forms.Timer(this.components);
            this.mainTabControl.SuspendLayout();
            this.RemindMeTrayIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabReminders);
            this.mainTabControl.Controls.Add(this.tabTimer);
            this.mainTabControl.Controls.Add(this.tabBackupImport);
            this.mainTabControl.Controls.Add(this.tabSettings);
            this.mainTabControl.Controls.Add(this.tabSoundEffects);
            this.mainTabControl.Controls.Add(this.tabResizePopup);
            this.mainTabControl.Controls.Add(this.tabMessageCenter);
            this.mainTabControl.Controls.Add(this.tabTheme);
            this.mainTabControl.Controls.Add(this.tabDebug);
            this.mainTabControl.Depth = 0;
            this.mainTabControl.ImageList = this.drawerIconsList;
            this.mainTabControl.Location = new System.Drawing.Point(62, 64);
            this.mainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(838, 502);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaterialForm1_KeyDown);
            // 
            // tabReminders
            // 
            this.tabReminders.BackColor = System.Drawing.SystemColors.Control;
            this.tabReminders.ImageKey = "icons8-calendar-50.png";
            this.tabReminders.Location = new System.Drawing.Point(4, 27);
            this.tabReminders.Name = "tabReminders";
            this.tabReminders.Padding = new System.Windows.Forms.Padding(3);
            this.tabReminders.Size = new System.Drawing.Size(830, 471);
            this.tabReminders.TabIndex = 0;
            this.tabReminders.Text = "Reminders";
            // 
            // tabTimer
            // 
            this.tabTimer.BackColor = System.Drawing.Color.Transparent;
            this.tabTimer.ImageKey = "icons8-stopwatch-24.png";
            this.tabTimer.Location = new System.Drawing.Point(4, 27);
            this.tabTimer.Name = "tabTimer";
            this.tabTimer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimer.Size = new System.Drawing.Size(830, 471);
            this.tabTimer.TabIndex = 1;
            this.tabTimer.Text = "Timer";
            // 
            // tabBackupImport
            // 
            this.tabBackupImport.ImageKey = "icons8-database-backup-24.png";
            this.tabBackupImport.Location = new System.Drawing.Point(4, 27);
            this.tabBackupImport.Name = "tabBackupImport";
            this.tabBackupImport.Size = new System.Drawing.Size(830, 471);
            this.tabBackupImport.TabIndex = 2;
            this.tabBackupImport.Text = "Backup / Import";
            this.tabBackupImport.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.ImageKey = "baseline_build_black_24dp.png";
            this.tabSettings.Location = new System.Drawing.Point(4, 27);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(830, 471);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabSoundEffects
            // 
            this.tabSoundEffects.ImageKey = "icons8-speaker-24.png";
            this.tabSoundEffects.Location = new System.Drawing.Point(4, 27);
            this.tabSoundEffects.Name = "tabSoundEffects";
            this.tabSoundEffects.Size = new System.Drawing.Size(830, 471);
            this.tabSoundEffects.TabIndex = 4;
            this.tabSoundEffects.Text = "Sound Effects";
            this.tabSoundEffects.UseVisualStyleBackColor = true;
            // 
            // tabResizePopup
            // 
            this.tabResizePopup.ImageKey = "icons8-group-objects-96.png";
            this.tabResizePopup.Location = new System.Drawing.Point(4, 27);
            this.tabResizePopup.Name = "tabResizePopup";
            this.tabResizePopup.Size = new System.Drawing.Size(830, 471);
            this.tabResizePopup.TabIndex = 5;
            this.tabResizePopup.Text = "Resize popup";
            this.tabResizePopup.UseVisualStyleBackColor = true;
            // 
            // tabMessageCenter
            // 
            this.tabMessageCenter.ImageKey = "icons8-sent-24.png";
            this.tabMessageCenter.Location = new System.Drawing.Point(4, 27);
            this.tabMessageCenter.Name = "tabMessageCenter";
            this.tabMessageCenter.Size = new System.Drawing.Size(830, 471);
            this.tabMessageCenter.TabIndex = 6;
            this.tabMessageCenter.Text = "Message center";
            this.tabMessageCenter.UseVisualStyleBackColor = true;
            // 
            // tabTheme
            // 
            this.tabTheme.ImageKey = "icons8-fill-color-24.png";
            this.tabTheme.Location = new System.Drawing.Point(4, 27);
            this.tabTheme.Name = "tabTheme";
            this.tabTheme.Size = new System.Drawing.Size(830, 471);
            this.tabTheme.TabIndex = 7;
            this.tabTheme.Text = "Theme";
            this.tabTheme.ToolTipText = "Set a custom theme for RemindMe!";
            this.tabTheme.UseVisualStyleBackColor = true;
            // 
            // tabDebug
            // 
            this.tabDebug.ImageKey = "icons8-bug-24.png";
            this.tabDebug.Location = new System.Drawing.Point(4, 27);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(830, 471);
            this.tabDebug.TabIndex = 8;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // drawerIconsList
            // 
            this.drawerIconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("drawerIconsList.ImageStream")));
            this.drawerIconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.drawerIconsList.Images.SetKeyName(0, "icons8-fill-color-24.png");
            this.drawerIconsList.Images.SetKeyName(1, "baseline_build_black_24dp.png");
            this.drawerIconsList.Images.SetKeyName(2, "icons8-sent-24.png");
            this.drawerIconsList.Images.SetKeyName(3, "icons8-group-objects-96.png");
            this.drawerIconsList.Images.SetKeyName(4, "icons8-speaker-48.png");
            this.drawerIconsList.Images.SetKeyName(5, "icons8-speaker-24.png");
            this.drawerIconsList.Images.SetKeyName(6, "icons8-calendar-50.png");
            this.drawerIconsList.Images.SetKeyName(7, "icons8-database-backup-24.png");
            this.drawerIconsList.Images.SetKeyName(8, "icons8-stopwatch-24.png");
            this.drawerIconsList.Images.SetKeyName(9, "icons8-bug-24.png");
            // 
            // tmrInitialHide
            // 
            this.tmrInitialHide.Interval = 1000;
            this.tmrInitialHide.Tick += new System.EventHandler(this.tmrInitialHide_Tick);
            // 
            // tmrCheckRemindMeMessages
            // 
            this.tmrCheckRemindMeMessages.Interval = 5000;
            this.tmrCheckRemindMeMessages.Tick += new System.EventHandler(this.tmrCheckRemindMeMessages_Tick);
            // 
            // tmrDumpLogTxtContents
            // 
            this.tmrDumpLogTxtContents.Interval = 2000;
            this.tmrDumpLogTxtContents.Tick += new System.EventHandler(this.tmrDumpLogTxtContents_Tick);
            // 
            // tmrEnableDatabaseAccess
            // 
            this.tmrEnableDatabaseAccess.Interval = 600000;
            this.tmrEnableDatabaseAccess.Tick += new System.EventHandler(this.tmrEnableDatabaseAccess_Tick);
            // 
            // tmrUpdateRemindMe
            // 
            this.tmrUpdateRemindMe.Interval = 300000;
            this.tmrUpdateRemindMe.Tick += new System.EventHandler(this.tmrUpdateRemindMe_Tick);
            // 
            // tmrDebugMode
            // 
            this.tmrDebugMode.Interval = 1000;
            this.tmrDebugMode.Tick += new System.EventHandler(this.tmrDebugMode_Tick);
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrOpacity_Tick);
            // 
            // tmrPingActivity
            // 
            this.tmrPingActivity.Interval = 300000;
            this.tmrPingActivity.Tick += new System.EventHandler(this.tmrPingActivity_Tick);
            // 
            // RemindMeIcon
            // 
            this.RemindMeIcon.BalloonTipText = "RemindMe";
            this.RemindMeIcon.ContextMenuStrip = this.RemindMeTrayIconMenuStrip;
            this.RemindMeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("RemindMeIcon.Icon")));
            this.RemindMeIcon.Text = "RemindMe";
            this.RemindMeIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RemindMeIcon_MouseDoubleClick);
            // 
            // RemindMeTrayIconMenuStrip
            // 
            this.RemindMeTrayIconMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.RemindMeTrayIconMenuStrip.Depth = 0;
            this.RemindMeTrayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartRemindMeUpdateToolStripMenuItem1,
            this.exitRemindMeToolStripMenuItem,
            this.showRemindMeToolStripMenuItem1});
            this.RemindMeTrayIconMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemindMeTrayIconMenuStrip.Name = "materialContextMenuStrip1";
            this.RemindMeTrayIconMenuStrip.Size = new System.Drawing.Size(232, 70);
            // 
            // restartRemindMeUpdateToolStripMenuItem1
            // 
            this.restartRemindMeUpdateToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartRemindMeUpdateToolStripMenuItem1.ForeColor = System.Drawing.Color.DarkGreen;
            this.restartRemindMeUpdateToolStripMenuItem1.Name = "restartRemindMeUpdateToolStripMenuItem1";
            this.restartRemindMeUpdateToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.restartRemindMeUpdateToolStripMenuItem1.Text = "Restart RemindMe (Update)";
            this.restartRemindMeUpdateToolStripMenuItem1.Visible = false;
            this.restartRemindMeUpdateToolStripMenuItem1.Click += new System.EventHandler(this.restartRemindMeUpdateToolStripMenuItem1_Click);
            // 
            // exitRemindMeToolStripMenuItem
            // 
            this.exitRemindMeToolStripMenuItem.Name = "exitRemindMeToolStripMenuItem";
            this.exitRemindMeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.exitRemindMeToolStripMenuItem.Text = "Exit RemindMe";
            this.exitRemindMeToolStripMenuItem.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // showRemindMeToolStripMenuItem1
            // 
            this.showRemindMeToolStripMenuItem1.Name = "showRemindMeToolStripMenuItem1";
            this.showRemindMeToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.showRemindMeToolStripMenuItem1.Text = "Show RemindMe";
            this.showRemindMeToolStripMenuItem1.Click += new System.EventHandler(this.showRemindMeToolStripMenuItem_Click);
            // 
            // tmrRemoveDebug
            // 
            this.tmrRemoveDebug.Interval = 2000;
            this.tmrRemoveDebug.Tick += new System.EventHandler(this.tmrRemoveDebug_Tick);
            // 
            // MaterialForm1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(866, 562);
            this.Controls.Add(this.mainTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.mainTabControl;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(866, 562);
            this.Name = "MaterialForm1";
            this.Text = "Remindme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialForm1_FormClosing);
            this.Load += new System.EventHandler(this.MaterialForm1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaterialForm1_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.RemindMeTrayIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList drawerIconsList;
        private System.Windows.Forms.Timer tmrInitialHide;
        private System.Windows.Forms.Timer tmrCheckRemindMeMessages;
        private System.Windows.Forms.Timer tmrDumpLogTxtContents;
        private System.Windows.Forms.Timer tmrEnableDatabaseAccess;
        private System.Windows.Forms.Timer tmrUpdateRemindMe;
        private System.Windows.Forms.Timer tmrDebugMode;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.Timer tmrPingActivity;
        public System.Windows.Forms.NotifyIcon RemindMeIcon;
        public MaterialSkin.Controls.MaterialTabControl mainTabControl;
        public System.Windows.Forms.TabPage tabReminders;
        public System.Windows.Forms.TabPage tabTimer;
        public System.Windows.Forms.TabPage tabBackupImport;
        public System.Windows.Forms.TabPage tabSettings;
        public System.Windows.Forms.TabPage tabSoundEffects;
        public System.Windows.Forms.TabPage tabResizePopup;
        public System.Windows.Forms.TabPage tabMessageCenter;
        public System.Windows.Forms.TabPage tabTheme;
        public System.Windows.Forms.TabPage tabDebug;
        private MaterialSkin.Controls.MaterialContextMenuStrip RemindMeTrayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitRemindMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRemindMeToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem restartRemindMeUpdateToolStripMenuItem1;
        private System.Windows.Forms.Timer tmrRemoveDebug;
    }
}

