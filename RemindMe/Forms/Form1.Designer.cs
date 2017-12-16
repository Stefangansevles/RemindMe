namespace RemindMe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblMinimize = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.RemindMeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RemindMeTrayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemindMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnlSide = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnSupport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnResizePopup = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnWindowOverlay = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSoundEffects = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBackupImport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReminders = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlBanner.SuspendLayout();
            this.RemindMeTrayIconMenuStrip.SuspendLayout();
            this.pnlSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlBanner;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe1;
            this.pnlBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBanner.Controls.Add(this.lblMinimize);
            this.pnlBanner.Controls.Add(this.lblExit);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(200, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(666, 126);
            this.pnlBanner.TabIndex = 1;
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Location = new System.Drawing.Point(623, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(21, 22);
            this.lblMinimize.TabIndex = 3;
            this.lblMinimize.Text = "- ";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.lblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.lblMinimize_MouseLeave);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Transparent;
            this.lblExit.Location = new System.Drawing.Point(644, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 2;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // RemindMeIcon
            // 
            this.RemindMeIcon.BalloonTipText = "RemindMe";
            this.RemindMeIcon.ContextMenuStrip = this.RemindMeTrayIconMenuStrip;
            this.RemindMeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("RemindMeIcon.Icon")));
            this.RemindMeIcon.Text = "RemindMe";
            this.RemindMeIcon.Visible = true;
            this.RemindMeIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RemindMeIcon_MouseDoubleClick);
            // 
            // RemindMeTrayIconMenuStrip
            // 
            this.RemindMeTrayIconMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.RemindMeTrayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit,
            this.showRemindMeToolStripMenuItem});
            this.RemindMeTrayIconMenuStrip.Name = "contextMenuStrip1";
            this.RemindMeTrayIconMenuStrip.ShowImageMargin = false;
            this.RemindMeTrayIconMenuStrip.Size = new System.Drawing.Size(133, 48);
            this.RemindMeTrayIconMenuStrip.Text = "contextmenustrip";
            // 
            // tsExit
            // 
            this.tsExit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.tsExit.ForeColor = System.Drawing.Color.Silver;
            this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(132, 22);
            this.tsExit.Text = "Exit RemindMe";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // showRemindMeToolStripMenuItem
            // 
            this.showRemindMeToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.showRemindMeToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.showRemindMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showRemindMeToolStripMenuItem.Image")));
            this.showRemindMeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.showRemindMeToolStripMenuItem.Name = "showRemindMeToolStripMenuItem";
            this.showRemindMeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.showRemindMeToolStripMenuItem.Text = "Show RemindMe";
            this.showRemindMeToolStripMenuItem.Click += new System.EventHandler(this.showRemindMeToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.GradientBottomLeft = System.Drawing.Color.DimGray;
            this.pnlMain.GradientBottomRight = System.Drawing.Color.DimGray;
            this.pnlMain.GradientTopLeft = System.Drawing.Color.DimGray;
            this.pnlMain.GradientTopRight = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(200, 126);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Quality = 10;
            this.pnlMain.Size = new System.Drawing.Size(666, 436);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlSide
            // 
            this.pnlSide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSide.BackgroundImage")));
            this.pnlSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSide.Controls.Add(this.lblVersion);
            this.pnlSide.Controls.Add(this.btnSupport);
            this.pnlSide.Controls.Add(this.btnResizePopup);
            this.pnlSide.Controls.Add(this.btnWindowOverlay);
            this.pnlSide.Controls.Add(this.btnSoundEffects);
            this.pnlSide.Controls.Add(this.btnBackupImport);
            this.pnlSide.Controls.Add(this.btnReminders);
            this.pnlSide.Controls.Add(this.pbLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.GradientBottomLeft = System.Drawing.Color.DimGray;
            this.pnlSide.GradientBottomRight = System.Drawing.Color.Gray;
            this.pnlSide.GradientTopLeft = System.Drawing.Color.DimGray;
            this.pnlSide.GradientTopRight = System.Drawing.Color.White;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Quality = 10;
            this.pnlSide.Size = new System.Drawing.Size(200, 562);
            this.pnlSide.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(0, 546);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(81, 16);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version x.x.x";
            // 
            // btnSupport
            // 
            this.btnSupport.Activecolor = System.Drawing.Color.DimGray;
            this.btnSupport.BackColor = System.Drawing.Color.Transparent;
            this.btnSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupport.BorderRadius = 0;
            this.btnSupport.ButtonText = "     Support";
            this.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupport.DisabledColor = System.Drawing.Color.White;
            this.btnSupport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupport.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSupport.Iconimage = global::RemindMe.Properties.Resources.if_mail_115714;
            this.btnSupport.Iconimage_right = null;
            this.btnSupport.Iconimage_right_Selected = null;
            this.btnSupport.Iconimage_Selected = null;
            this.btnSupport.IconMarginLeft = 0;
            this.btnSupport.IconMarginRight = 0;
            this.btnSupport.IconRightVisible = true;
            this.btnSupport.IconRightZoom = 0D;
            this.btnSupport.IconVisible = true;
            this.btnSupport.IconZoom = 50D;
            this.btnSupport.IsTab = true;
            this.btnSupport.Location = new System.Drawing.Point(0, 366);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSupport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSupport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSupport.selected = false;
            this.btnSupport.Size = new System.Drawing.Size(200, 48);
            this.btnSupport.TabIndex = 13;
            this.btnSupport.Text = "     Support";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.Textcolor = System.Drawing.Color.White;
            this.btnSupport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnResizePopup
            // 
            this.btnResizePopup.Activecolor = System.Drawing.Color.DimGray;
            this.btnResizePopup.BackColor = System.Drawing.Color.Transparent;
            this.btnResizePopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResizePopup.BorderRadius = 0;
            this.btnResizePopup.ButtonText = "     Resize popup";
            this.btnResizePopup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResizePopup.DisabledColor = System.Drawing.Color.White;
            this.btnResizePopup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResizePopup.Iconcolor = System.Drawing.Color.Transparent;
            this.btnResizePopup.Iconimage = global::RemindMe.Properties.Resources.if_resize_62244;
            this.btnResizePopup.Iconimage_right = null;
            this.btnResizePopup.Iconimage_right_Selected = null;
            this.btnResizePopup.Iconimage_Selected = null;
            this.btnResizePopup.IconMarginLeft = 0;
            this.btnResizePopup.IconMarginRight = 0;
            this.btnResizePopup.IconRightVisible = true;
            this.btnResizePopup.IconRightZoom = 0D;
            this.btnResizePopup.IconVisible = true;
            this.btnResizePopup.IconZoom = 50D;
            this.btnResizePopup.IsTab = true;
            this.btnResizePopup.Location = new System.Drawing.Point(0, 318);
            this.btnResizePopup.Name = "btnResizePopup";
            this.btnResizePopup.Normalcolor = System.Drawing.Color.Transparent;
            this.btnResizePopup.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnResizePopup.OnHoverTextColor = System.Drawing.Color.White;
            this.btnResizePopup.selected = false;
            this.btnResizePopup.Size = new System.Drawing.Size(200, 48);
            this.btnResizePopup.TabIndex = 12;
            this.btnResizePopup.Text = "     Resize popup";
            this.btnResizePopup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResizePopup.Textcolor = System.Drawing.Color.White;
            this.btnResizePopup.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResizePopup.Click += new System.EventHandler(this.btnResizePopup_Click);
            // 
            // btnWindowOverlay
            // 
            this.btnWindowOverlay.Activecolor = System.Drawing.Color.DimGray;
            this.btnWindowOverlay.BackColor = System.Drawing.Color.Transparent;
            this.btnWindowOverlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWindowOverlay.BorderRadius = 0;
            this.btnWindowOverlay.ButtonText = "     Window overlay";
            this.btnWindowOverlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWindowOverlay.DisabledColor = System.Drawing.Color.White;
            this.btnWindowOverlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWindowOverlay.Iconcolor = System.Drawing.Color.Transparent;
            this.btnWindowOverlay.Iconimage = global::RemindMe.Properties.Resources._2windows2;
            this.btnWindowOverlay.Iconimage_right = null;
            this.btnWindowOverlay.Iconimage_right_Selected = null;
            this.btnWindowOverlay.Iconimage_Selected = null;
            this.btnWindowOverlay.IconMarginLeft = 0;
            this.btnWindowOverlay.IconMarginRight = 0;
            this.btnWindowOverlay.IconRightVisible = true;
            this.btnWindowOverlay.IconRightZoom = 0D;
            this.btnWindowOverlay.IconVisible = true;
            this.btnWindowOverlay.IconZoom = 50D;
            this.btnWindowOverlay.IsTab = true;
            this.btnWindowOverlay.Location = new System.Drawing.Point(0, 270);
            this.btnWindowOverlay.Name = "btnWindowOverlay";
            this.btnWindowOverlay.Normalcolor = System.Drawing.Color.Transparent;
            this.btnWindowOverlay.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnWindowOverlay.OnHoverTextColor = System.Drawing.Color.White;
            this.btnWindowOverlay.selected = false;
            this.btnWindowOverlay.Size = new System.Drawing.Size(200, 48);
            this.btnWindowOverlay.TabIndex = 11;
            this.btnWindowOverlay.Text = "     Window overlay";
            this.btnWindowOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWindowOverlay.Textcolor = System.Drawing.Color.White;
            this.btnWindowOverlay.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowOverlay.Click += new System.EventHandler(this.btnWindowOverlay_Click);
            // 
            // btnSoundEffects
            // 
            this.btnSoundEffects.Activecolor = System.Drawing.Color.DimGray;
            this.btnSoundEffects.BackColor = System.Drawing.Color.Transparent;
            this.btnSoundEffects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSoundEffects.BorderRadius = 0;
            this.btnSoundEffects.ButtonText = "     Sound effects";
            this.btnSoundEffects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoundEffects.DisabledColor = System.Drawing.Color.White;
            this.btnSoundEffects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoundEffects.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSoundEffects.Iconimage = global::RemindMe.Properties.Resources.if_sound_115787;
            this.btnSoundEffects.Iconimage_right = null;
            this.btnSoundEffects.Iconimage_right_Selected = null;
            this.btnSoundEffects.Iconimage_Selected = null;
            this.btnSoundEffects.IconMarginLeft = 0;
            this.btnSoundEffects.IconMarginRight = 0;
            this.btnSoundEffects.IconRightVisible = true;
            this.btnSoundEffects.IconRightZoom = 0D;
            this.btnSoundEffects.IconVisible = true;
            this.btnSoundEffects.IconZoom = 50D;
            this.btnSoundEffects.IsTab = true;
            this.btnSoundEffects.Location = new System.Drawing.Point(0, 222);
            this.btnSoundEffects.Name = "btnSoundEffects";
            this.btnSoundEffects.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSoundEffects.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSoundEffects.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSoundEffects.selected = false;
            this.btnSoundEffects.Size = new System.Drawing.Size(200, 48);
            this.btnSoundEffects.TabIndex = 10;
            this.btnSoundEffects.Text = "     Sound effects";
            this.btnSoundEffects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoundEffects.Textcolor = System.Drawing.Color.White;
            this.btnSoundEffects.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoundEffects.Click += new System.EventHandler(this.btnSoundEffects_Click);
            // 
            // btnBackupImport
            // 
            this.btnBackupImport.Activecolor = System.Drawing.Color.DimGray;
            this.btnBackupImport.BackColor = System.Drawing.Color.Transparent;
            this.btnBackupImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackupImport.BorderRadius = 0;
            this.btnBackupImport.ButtonText = "     Backup / Import";
            this.btnBackupImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupImport.DisabledColor = System.Drawing.Color.White;
            this.btnBackupImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackupImport.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBackupImport.Iconimage = global::RemindMe.Properties.Resources.RemindMeImport;
            this.btnBackupImport.Iconimage_right = null;
            this.btnBackupImport.Iconimage_right_Selected = null;
            this.btnBackupImport.Iconimage_Selected = null;
            this.btnBackupImport.IconMarginLeft = 0;
            this.btnBackupImport.IconMarginRight = 0;
            this.btnBackupImport.IconRightVisible = true;
            this.btnBackupImport.IconRightZoom = 0D;
            this.btnBackupImport.IconVisible = true;
            this.btnBackupImport.IconZoom = 50D;
            this.btnBackupImport.IsTab = true;
            this.btnBackupImport.Location = new System.Drawing.Point(0, 174);
            this.btnBackupImport.Name = "btnBackupImport";
            this.btnBackupImport.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBackupImport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnBackupImport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBackupImport.selected = false;
            this.btnBackupImport.Size = new System.Drawing.Size(200, 48);
            this.btnBackupImport.TabIndex = 9;
            this.btnBackupImport.Text = "     Backup / Import";
            this.btnBackupImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupImport.Textcolor = System.Drawing.Color.White;
            this.btnBackupImport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupImport.Click += new System.EventHandler(this.btnBackupImport_Click);
            // 
            // btnReminders
            // 
            this.btnReminders.Activecolor = System.Drawing.Color.DimGray;
            this.btnReminders.BackColor = System.Drawing.Color.DimGray;
            this.btnReminders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReminders.BorderRadius = 0;
            this.btnReminders.ButtonText = "     Reminders";
            this.btnReminders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReminders.DisabledColor = System.Drawing.Color.White;
            this.btnReminders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReminders.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReminders.Iconimage = global::RemindMe.Properties.Resources.RemindMe;
            this.btnReminders.Iconimage_right = null;
            this.btnReminders.Iconimage_right_Selected = null;
            this.btnReminders.Iconimage_Selected = null;
            this.btnReminders.IconMarginLeft = 0;
            this.btnReminders.IconMarginRight = 0;
            this.btnReminders.IconRightVisible = true;
            this.btnReminders.IconRightZoom = 0D;
            this.btnReminders.IconVisible = true;
            this.btnReminders.IconZoom = 50D;
            this.btnReminders.IsTab = true;
            this.btnReminders.Location = new System.Drawing.Point(0, 126);
            this.btnReminders.Name = "btnReminders";
            this.btnReminders.Normalcolor = System.Drawing.Color.Transparent;
            this.btnReminders.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnReminders.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReminders.selected = true;
            this.btnReminders.Size = new System.Drawing.Size(200, 48);
            this.btnReminders.TabIndex = 6;
            this.btnReminders.Text = "     Reminders";
            this.btnReminders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReminders.Textcolor = System.Drawing.Color.White;
            this.btnReminders.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReminders.Click += new System.EventHandler(this.btnReminders_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 126);
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 562);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.pnlSide);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.RemindMeTrayIconMenuStrip.ResumeLayout(false);
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel pnlSide;
        private System.Windows.Forms.Panel pnlBanner;
        private Bunifu.Framework.UI.BunifuFlatButton btnReminders;
        private System.Windows.Forms.PictureBox pbLogo;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMinimize;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuFlatButton btnBackupImport;
        private Bunifu.Framework.UI.BunifuFlatButton btnResizePopup;
        private Bunifu.Framework.UI.BunifuFlatButton btnWindowOverlay;
        private Bunifu.Framework.UI.BunifuFlatButton btnSoundEffects;
        private Bunifu.Framework.UI.BunifuFlatButton btnSupport;
        public System.Windows.Forms.NotifyIcon RemindMeIcon;
        private System.Windows.Forms.ContextMenuStrip RemindMeTrayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem showRemindMeToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlMain;
        private System.Windows.Forms.Label lblVersion;
    }
}

