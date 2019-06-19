namespace RemindMe
{
    partial class UCReminderItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReminderItem));
            this.ReminderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.tpInformation = new System.Windows.Forms.ToolTip(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnSettings = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDisable = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnEdit = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblReminderName = new System.Windows.Forms.Label();
            this.pbRepeat = new System.Windows.Forms.PictureBox();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.ReminderMenuStrip.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            this.SuspendLayout();
            // 
            // ReminderMenuStrip
            // 
            this.ReminderMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.ReminderMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReminderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.hideReminderToolStripMenuItem,
            this.postponeToolStripMenuItem,
            this.removePostponeToolStripMenuItem,
            this.skipToNextDateToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ReminderMenuStrip.Name = "ReminderMenuStrip";
            this.ReminderMenuStrip.Size = new System.Drawing.Size(255, 158);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.previewToolStripMenuItem.BackgroundImage = global::RemindMe.Properties.Resources.DimGray;
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewThisReminderNowToolStripMenuItem,
            this.previewThisReminderIn5SecondsToolStripMenuItem,
            this.previewThisReminderIn10SecondsToolStripMenuItem});
            this.previewToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewToolStripMenuItem.Image = global::RemindMe.Properties.Resources.prev;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.previewToolStripMenuItem.Text = "Preview reminder";
            // 
            // previewThisReminderNowToolStripMenuItem
            // 
            this.previewThisReminderNowToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.previewThisReminderNowToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewThisReminderNowToolStripMenuItem.Name = "previewThisReminderNowToolStripMenuItem";
            this.previewThisReminderNowToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.previewThisReminderNowToolStripMenuItem.Text = "Preview this reminder now";
            this.previewThisReminderNowToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderNowToolStripMenuItem_Click);
            // 
            // previewThisReminderIn5SecondsToolStripMenuItem
            // 
            this.previewThisReminderIn5SecondsToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.previewThisReminderIn5SecondsToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewThisReminderIn5SecondsToolStripMenuItem.Name = "previewThisReminderIn5SecondsToolStripMenuItem";
            this.previewThisReminderIn5SecondsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.previewThisReminderIn5SecondsToolStripMenuItem.Text = "Preview this reminder in 5 seconds";
            this.previewThisReminderIn5SecondsToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderIn5SecondsToolStripMenuItem_ClickAsync);
            // 
            // previewThisReminderIn10SecondsToolStripMenuItem
            // 
            this.previewThisReminderIn10SecondsToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.previewThisReminderIn10SecondsToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewThisReminderIn10SecondsToolStripMenuItem.Name = "previewThisReminderIn10SecondsToolStripMenuItem";
            this.previewThisReminderIn10SecondsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.previewThisReminderIn10SecondsToolStripMenuItem.Text = "Preview this reminder in 10 seconds";
            this.previewThisReminderIn10SecondsToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderIn10SecondsToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("duplicateToolStripMenuItem.BackgroundImage")));
            this.duplicateToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.duplicateToolStripMenuItem.Image = global::RemindMe.Properties.Resources.duplicate;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // hideReminderToolStripMenuItem
            // 
            this.hideReminderToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hideReminderToolStripMenuItem.BackgroundImage")));
            this.hideReminderToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hideReminderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableWarningToolStripMenuItem});
            this.hideReminderToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.hideReminderToolStripMenuItem.Image = global::RemindMe.Properties.Resources.hide;
            this.hideReminderToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hideReminderToolStripMenuItem.Name = "hideReminderToolStripMenuItem";
            this.hideReminderToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.hideReminderToolStripMenuItem.Text = "Hide reminder";
            this.hideReminderToolStripMenuItem.Click += new System.EventHandler(this.hideReminderToolStripMenuItem_Click);
            // 
            // enableWarningToolStripMenuItem
            // 
            this.enableWarningToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.enableWarningToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.enableWarningToolStripMenuItem.Image = global::RemindMe.Properties.Resources.err;
            this.enableWarningToolStripMenuItem.Name = "enableWarningToolStripMenuItem";
            this.enableWarningToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.enableWarningToolStripMenuItem.Text = "Enable warning";
            this.enableWarningToolStripMenuItem.Visible = false;
            this.enableWarningToolStripMenuItem.Click += new System.EventHandler(this.enableWarningToolStripMenuItem_Click);
            // 
            // postponeToolStripMenuItem
            // 
            this.postponeToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("postponeToolStripMenuItem.BackgroundImage")));
            this.postponeToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.postponeToolStripMenuItem.Image = global::RemindMe.Properties.Resources.zzz;
            this.postponeToolStripMenuItem.Name = "postponeToolStripMenuItem";
            this.postponeToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.postponeToolStripMenuItem.Text = "Postpone";
            this.postponeToolStripMenuItem.Click += new System.EventHandler(this.postponeToolStripMenuItem_Click);
            // 
            // removePostponeToolStripMenuItem
            // 
            this.removePostponeToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removePostponeToolStripMenuItem.BackgroundImage")));
            this.removePostponeToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.removePostponeToolStripMenuItem.Image = global::RemindMe.Properties.Resources.zzzCancel;
            this.removePostponeToolStripMenuItem.Name = "removePostponeToolStripMenuItem";
            this.removePostponeToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.removePostponeToolStripMenuItem.Text = "Remove Postpone";
            this.removePostponeToolStripMenuItem.Click += new System.EventHandler(this.removePostponeToolStripMenuItem_Click);
            // 
            // skipToNextDateToolStripMenuItem
            // 
            this.skipToNextDateToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skipToNextDateToolStripMenuItem.BackgroundImage")));
            this.skipToNextDateToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.skipToNextDateToolStripMenuItem.Image = global::RemindMe.Properties.Resources.skip_forward;
            this.skipToNextDateToolStripMenuItem.Name = "skipToNextDateToolStripMenuItem";
            this.skipToNextDateToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.skipToNextDateToolStripMenuItem.Text = "Skip to next date";
            this.skipToNextDateToolStripMenuItem.Click += new System.EventHandler(this.skipToNextDateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.BackgroundImage")));
            this.toolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripMenuItem1.Image = global::RemindMe.Properties.Resources.Permanentely_bin;
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            this.toolStripMenuItem1.Text = "Permanentely remove reminder";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pnlActionButtons);
            this.bunifuGradientPanel1.Controls.Add(this.lblReminderName);
            this.bunifuGradientPanel1.Controls.Add(this.pbRepeat);
            this.bunifuGradientPanel1.Controls.Add(this.lblRepeat);
            this.bunifuGradientPanel1.Controls.Add(this.lblDate);
            this.bunifuGradientPanel1.Controls.Add(this.pbDate);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(666, 57);
            this.bunifuGradientPanel1.TabIndex = 116;
            this.bunifuGradientPanel1.DoubleClick += new System.EventHandler(this.bunifuGradientPanel1_DoubleClick);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.btnSettings);
            this.pnlActionButtons.Controls.Add(this.btnDisable);
            this.pnlActionButtons.Controls.Add(this.btnDelete);
            this.pnlActionButtons.Controls.Add(this.btnEdit);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlActionButtons.Location = new System.Drawing.Point(512, 0);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(154, 57);
            this.pnlActionButtons.TabIndex = 117;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::RemindMe.Properties.Resources.gearWhite;
            this.btnSettings.ImageActive = null;
            this.btnSettings.ImageLocation = "";
            this.btnSettings.Location = new System.Drawing.Point(11, 16);
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
            this.btnDisable.Image = global::RemindMe.Properties.Resources.turnedOn;
            this.btnDisable.ImageActive = null;
            this.btnDisable.ImageLocation = "";
            this.btnDisable.Location = new System.Drawing.Point(47, 16);
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
            this.btnDelete.Image = global::RemindMe.Properties.Resources.Bin_white;
            this.btnDelete.ImageActive = null;
            this.btnDelete.ImageLocation = "";
            this.btnDelete.Location = new System.Drawing.Point(83, 16);
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
            this.btnEdit.Image = global::RemindMe.Properties.Resources.EditPenWhite;
            this.btnEdit.ImageActive = null;
            this.btnEdit.ImageLocation = "";
            this.btnEdit.Location = new System.Drawing.Point(119, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 25);
            this.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEdit.TabIndex = 115;
            this.btnEdit.TabStop = false;
            this.btnEdit.Zoom = -15;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblReminderName
            // 
            this.lblReminderName.AutoSize = true;
            this.lblReminderName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblReminderName.ForeColor = System.Drawing.Color.White;
            this.lblReminderName.Location = new System.Drawing.Point(10, 6);
            this.lblReminderName.Name = "lblReminderName";
            this.lblReminderName.Size = new System.Drawing.Size(101, 16);
            this.lblReminderName.TabIndex = 108;
            this.lblReminderName.Text = "Reminder name";
            // 
            // pbRepeat
            // 
            this.pbRepeat.BackgroundImage = global::RemindMe.Properties.Resources.Repeatwhite;
            this.pbRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRepeat.Location = new System.Drawing.Point(168, 26);
            this.pbRepeat.Name = "pbRepeat";
            this.pbRepeat.Size = new System.Drawing.Size(23, 23);
            this.pbRepeat.TabIndex = 109;
            this.pbRepeat.TabStop = false;
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRepeat.ForeColor = System.Drawing.Color.White;
            this.lblRepeat.Location = new System.Drawing.Point(195, 30);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(52, 16);
            this.lblRepeat.TabIndex = 110;
            this.lblRepeat.Text = "Weekly";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(45, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 16);
            this.lblDate.TabIndex = 113;
            this.lblDate.Text = "Date";
            // 
            // pbDate
            // 
            this.pbDate.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
            this.pbDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDate.ImageLocation = "";
            this.pbDate.Location = new System.Drawing.Point(15, 26);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(23, 23);
            this.pbDate.TabIndex = 112;
            this.pbDate.TabStop = false;
            // 
            // UCReminderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "UCReminderItem";
            this.Size = new System.Drawing.Size(666, 57);
            this.Load += new System.EventHandler(this.UCReminderItem_Load);
            this.MouseEnter += new System.EventHandler(this.UCReminderItem_MouseEnter);
            this.ReminderMenuStrip.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.pnlActionButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReminderName;
        private System.Windows.Forms.PictureBox pbRepeat;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pbDate;
        private Bunifu.Framework.UI.BunifuImageButton btnDelete;
        private Bunifu.Framework.UI.BunifuImageButton btnEdit;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuImageButton btnDisable;
        private System.Windows.Forms.Panel pnlActionButtons;
        private Bunifu.Framework.UI.BunifuImageButton btnSettings;
        private System.Windows.Forms.ContextMenuStrip ReminderMenuStrip;
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
        private System.Windows.Forms.ToolTip tpInformation;
    }
}
