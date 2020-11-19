namespace RemindMe
{
    partial class MUCReminderItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnSettings = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDisable = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnEdit = new Bunifu.Framework.UI.BunifuImageButton();
            this.tpInformation = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSideColor = new System.Windows.Forms.Panel();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.pbRepeat = new System.Windows.Forms.PictureBox();
            this.lblReminderNameDisabled = new System.Windows.Forms.Label();
            this.btnShadow = new MaterialSkin.Controls.MaterialButton();
            this.lblReminderName = new MaterialSkin.Controls.MaterialLabel();
            this.lblDate = new MaterialSkin.Controls.MaterialLabel();
            this.lblRepeat = new MaterialSkin.Controls.MaterialLabel();
            this.ReminderMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn5SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn10SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePostponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipToNextDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).BeginInit();
            this.ReminderMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlActionButtons.Controls.Add(this.btnSettings);
            this.pnlActionButtons.Controls.Add(this.btnDisable);
            this.pnlActionButtons.Controls.Add(this.btnDelete);
            this.pnlActionButtons.Controls.Add(this.btnEdit);
            this.pnlActionButtons.Location = new System.Drawing.Point(644, 7);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(154, 50);
            this.pnlActionButtons.TabIndex = 124;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::RemindMe.Properties.Resources.gearDark;
            this.btnSettings.ImageActive = null;
            this.btnSettings.ImageLocation = "";
            this.btnSettings.Location = new System.Drawing.Point(11, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(25, 25);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSettings.TabIndex = 117;
            this.btnSettings.TabStop = false;
            this.btnSettings.Zoom = -15;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.BackColor = System.Drawing.Color.Transparent;
            this.btnDisable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisable.Image = global::RemindMe.Properties.Resources.disableDark;
            this.btnDisable.ImageActive = null;
            this.btnDisable.ImageLocation = "";
            this.btnDisable.Location = new System.Drawing.Point(47, 13);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(25, 25);
            this.btnDisable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDisable.TabIndex = 116;
            this.btnDisable.TabStop = false;
            this.btnDisable.Zoom = -15;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::RemindMe.Properties.Resources.binDark;
            this.btnDelete.ImageActive = null;
            this.btnDelete.ImageLocation = "";
            this.btnDelete.Location = new System.Drawing.Point(83, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 114;
            this.btnDelete.TabStop = false;
            this.btnDelete.Zoom = -15;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::RemindMe.Properties.Resources.editPenDark;
            this.btnEdit.ImageActive = null;
            this.btnEdit.ImageLocation = "";
            this.btnEdit.Location = new System.Drawing.Point(119, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 25);
            this.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEdit.TabIndex = 115;
            this.btnEdit.TabStop = false;
            this.btnEdit.Zoom = -15;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tpInformation
            // 
            this.tpInformation.AutomaticDelay = 100;
            this.tpInformation.AutoPopDelay = 5000;
            this.tpInformation.BackColor = System.Drawing.Color.DimGray;
            this.tpInformation.ForeColor = System.Drawing.Color.White;
            this.tpInformation.InitialDelay = 100;
            this.tpInformation.ReshowDelay = 20;
            // 
            // pnlSideColor
            // 
            this.pnlSideColor.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlSideColor.Location = new System.Drawing.Point(-1, -1);
            this.pnlSideColor.Name = "pnlSideColor";
            this.pnlSideColor.Size = new System.Drawing.Size(9, 62);
            this.pnlSideColor.TabIndex = 128;
            // 
            // pbDate
            // 
            this.pbDate.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDate.ImageLocation = "";
            this.pbDate.Location = new System.Drawing.Point(14, 31);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(23, 23);
            this.pbDate.TabIndex = 121;
            this.pbDate.TabStop = false;
            // 
            // pbRepeat
            // 
            this.pbRepeat.BackgroundImage = global::RemindMe.Properties.Resources.Repeatwhite;
            this.pbRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRepeat.Location = new System.Drawing.Point(164, 31);
            this.pbRepeat.Name = "pbRepeat";
            this.pbRepeat.Size = new System.Drawing.Size(23, 23);
            this.pbRepeat.TabIndex = 122;
            this.pbRepeat.TabStop = false;
            // 
            // lblReminderNameDisabled
            // 
            this.lblReminderNameDisabled.AutoSize = true;
            this.lblReminderNameDisabled.Location = new System.Drawing.Point(16, 7);
            this.lblReminderNameDisabled.Name = "lblReminderNameDisabled";
            this.lblReminderNameDisabled.Size = new System.Drawing.Size(39, 13);
            this.lblReminderNameDisabled.TabIndex = 129;
            this.lblReminderNameDisabled.Text = "Empty.";
            this.lblReminderNameDisabled.Visible = false;
            this.lblReminderNameDisabled.VisibleChanged += new System.EventHandler(this.lblReminderNameDisabled_VisibleChanged);
            // 
            // btnShadow
            // 
            this.btnShadow.AutoSize = false;
            this.btnShadow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShadow.Depth = 0;
            this.btnShadow.DrawShadows = true;
            this.btnShadow.HighEmphasis = true;
            this.btnShadow.Icon = null;
            this.btnShadow.Location = new System.Drawing.Point(-3, 62);
            this.btnShadow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShadow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShadow.Name = "btnShadow";
            this.btnShadow.Size = new System.Drawing.Size(805, 4);
            this.btnShadow.TabIndex = 127;
            this.btnShadow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShadow.UseAccentColor = false;
            this.btnShadow.UseVisualStyleBackColor = true;
            this.btnShadow.Visible = false;
            // 
            // lblReminderName
            // 
            this.lblReminderName.AutoSize = true;
            this.lblReminderName.Depth = 0;
            this.lblReminderName.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblReminderName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblReminderName.ForeColor = System.Drawing.Color.White;
            this.lblReminderName.Location = new System.Drawing.Point(16, 7);
            this.lblReminderName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReminderName.Name = "lblReminderName";
            this.lblReminderName.Size = new System.Drawing.Size(45, 17);
            this.lblReminderName.TabIndex = 120;
            this.lblReminderName.Text = "Empty.";
            this.lblReminderName.TextChanged += new System.EventHandler(this.lblReminderName_TextChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Depth = 0;
            this.lblDate.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblDate.Location = new System.Drawing.Point(43, 34);
            this.lblDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(98, 17);
            this.lblDate.TabIndex = 123;
            this.lblDate.Text = "5-9-2020 08:01";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Depth = 0;
            this.lblRepeat.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRepeat.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblRepeat.Location = new System.Drawing.Point(207, 34);
            this.lblRepeat.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(90, 17);
            this.lblRepeat.TabIndex = 125;
            this.lblRepeat.Text = "Every 3 weeks";
            // 
            // ReminderMenuStrip
            // 
            this.ReminderMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ReminderMenuStrip.Depth = 0;
            this.ReminderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.hideReminderToolStripMenuItem,
            this.postponeToolStripMenuItem,
            this.removePostponeToolStripMenuItem,
            this.skipToNextDateToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ReminderMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.ReminderMenuStrip.Name = "materialContextMenuStrip1";
            this.ReminderMenuStrip.Size = new System.Drawing.Size(298, 208);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewThisReminderNowToolStripMenuItem,
            this.previewThisReminderIn5SecondsToolStripMenuItem,
            this.previewThisReminderIn10SecondsToolStripMenuItem});
            this.previewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.previewToolStripMenuItem.Image = global::RemindMe.Properties.Resources.eyeDark;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.previewToolStripMenuItem.Text = "Preview reminder";
            // 
            // previewThisReminderNowToolStripMenuItem
            // 
            this.previewThisReminderNowToolStripMenuItem.Name = "previewThisReminderNowToolStripMenuItem";
            this.previewThisReminderNowToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.previewThisReminderNowToolStripMenuItem.Text = "Preview this reminder now";
            this.previewThisReminderNowToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderNowToolStripMenuItem_Click);
            // 
            // previewThisReminderIn5SecondsToolStripMenuItem
            // 
            this.previewThisReminderIn5SecondsToolStripMenuItem.Name = "previewThisReminderIn5SecondsToolStripMenuItem";
            this.previewThisReminderIn5SecondsToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.previewThisReminderIn5SecondsToolStripMenuItem.Text = "Preview this reminder in 5 seconds";
            this.previewThisReminderIn5SecondsToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderIn5SecondsToolStripMenuItem_ClickAsync);
            // 
            // previewThisReminderIn10SecondsToolStripMenuItem
            // 
            this.previewThisReminderIn10SecondsToolStripMenuItem.Name = "previewThisReminderIn10SecondsToolStripMenuItem";
            this.previewThisReminderIn10SecondsToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.previewThisReminderIn10SecondsToolStripMenuItem.Text = "Preview this reminder in 10 seconds";
            this.previewThisReminderIn10SecondsToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderIn10SecondsToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.duplicateToolStripMenuItem.Image = global::RemindMe.Properties.Resources.duplicateDark;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // hideReminderToolStripMenuItem
            // 
            this.hideReminderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableWarningToolStripMenuItem});
            this.hideReminderToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hideReminderToolStripMenuItem.Image = global::RemindMe.Properties.Resources.hideDark;
            this.hideReminderToolStripMenuItem.Name = "hideReminderToolStripMenuItem";
            this.hideReminderToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.hideReminderToolStripMenuItem.Text = "Hide reminder";
            this.hideReminderToolStripMenuItem.Click += new System.EventHandler(this.hideReminderToolStripMenuItem_Click);
            // 
            // enableWarningToolStripMenuItem
            // 
            this.enableWarningToolStripMenuItem.Image = global::RemindMe.Properties.Resources.err;
            this.enableWarningToolStripMenuItem.Name = "enableWarningToolStripMenuItem";
            this.enableWarningToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.enableWarningToolStripMenuItem.Text = "Enable warning";
            this.enableWarningToolStripMenuItem.Click += new System.EventHandler(this.enableWarningToolStripMenuItem_Click);
            // 
            // postponeToolStripMenuItem
            // 
            this.postponeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.postponeToolStripMenuItem.Image = global::RemindMe.Properties.Resources.zzzDark;
            this.postponeToolStripMenuItem.Name = "postponeToolStripMenuItem";
            this.postponeToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.postponeToolStripMenuItem.Text = "Postpone";
            this.postponeToolStripMenuItem.Click += new System.EventHandler(this.postponeToolStripMenuItem_Click);
            // 
            // removePostponeToolStripMenuItem
            // 
            this.removePostponeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.removePostponeToolStripMenuItem.Image = global::RemindMe.Properties.Resources.zzzCancelDark;
            this.removePostponeToolStripMenuItem.Name = "removePostponeToolStripMenuItem";
            this.removePostponeToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.removePostponeToolStripMenuItem.Text = "Remove postpone";
            this.removePostponeToolStripMenuItem.Click += new System.EventHandler(this.removePostponeToolStripMenuItem_Click);
            // 
            // skipToNextDateToolStripMenuItem
            // 
            this.skipToNextDateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.skipToNextDateToolStripMenuItem.Image = global::RemindMe.Properties.Resources.skipForwardDark;
            this.skipToNextDateToolStripMenuItem.Name = "skipToNextDateToolStripMenuItem";
            this.skipToNextDateToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.skipToNextDateToolStripMenuItem.Text = "Skip to next date";
            this.skipToNextDateToolStripMenuItem.Click += new System.EventHandler(this.skipToNextDateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripMenuItem1.Image = global::RemindMe.Properties.Resources.permanentelyDark;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(297, 26);
            this.toolStripMenuItem1.Text = "Permanentely remove reminder";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MUCReminderItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblReminderNameDisabled);
            this.Controls.Add(this.pnlSideColor);
            this.Controls.Add(this.btnShadow);
            this.Controls.Add(this.lblReminderName);
            this.Controls.Add(this.pnlActionButtons);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.pbDate);
            this.Controls.Add(this.pbRepeat);
            this.Name = "MUCReminderItem";
            this.Size = new System.Drawing.Size(799, 65);
            this.Load += new System.EventHandler(this.MUCReminderItem_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCReminderItem_VisibleChanged);
            this.DoubleClick += new System.EventHandler(this.bunifuGradientPanel1_DoubleClick);
            this.pnlActionButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).EndInit();
            this.ReminderMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblReminderName;
        private System.Windows.Forms.Panel pnlActionButtons;
        private Bunifu.Framework.UI.BunifuImageButton btnSettings;
        private Bunifu.Framework.UI.BunifuImageButton btnDisable;
        private Bunifu.Framework.UI.BunifuImageButton btnDelete;
        private Bunifu.Framework.UI.BunifuImageButton btnEdit;
        private MaterialSkin.Controls.MaterialLabel lblDate;
        private MaterialSkin.Controls.MaterialLabel lblRepeat;
        private System.Windows.Forms.PictureBox pbDate;
        private System.Windows.Forms.PictureBox pbRepeat;
        private System.Windows.Forms.ToolTip tpInformation;
        private MaterialSkin.Controls.MaterialButton btnShadow;
        public System.Windows.Forms.Panel pnlSideColor;
        private MaterialSkin.Controls.MaterialContextMenuStrip ReminderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn5SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn10SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableWarningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePostponeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skipToNextDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label lblReminderNameDisabled;
    }
}
