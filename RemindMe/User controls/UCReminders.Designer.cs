namespace RemindMe
{
    partial class UCReminders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReminders));
            this.lvReminders = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReminderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmrCheckReminder = new System.Windows.Forms.Timer(this.components);
            this.tmrClearMessageCache = new System.Windows.Forms.Timer(this.components);
            this.pnlReminderButtons = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnDisableEnable = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEditReminder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRemoveReminder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddReminder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn5SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn10SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedRemindersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unHideReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePostponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipToNextDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ReminderMenuStrip.SuspendLayout();
            this.pnlReminderButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvReminders
            // 
            this.lvReminders.AllowDrop = true;
            this.lvReminders.BackColor = System.Drawing.Color.DimGray;
            this.lvReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chDate,
            this.chRepeat,
            this.chEnabled});
            this.lvReminders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReminders.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lvReminders.ForeColor = System.Drawing.Color.White;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.Location = new System.Drawing.Point(0, 0);
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.Size = new System.Drawing.Size(666, 397);
            this.lvReminders.TabIndex = 0;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;
            this.lvReminders.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvReminders_ColumnWidthChanged);
            this.lvReminders.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvReminders_ItemDrag);
            this.lvReminders.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvReminders_DragDrop);
            this.lvReminders.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvReminders_DragEnter);
            this.lvReminders.DoubleClick += new System.EventHandler(this.lvReminders_DoubleClick);
            this.lvReminders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReminders_KeyDown);
            this.lvReminders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvReminders_MouseClick);
            this.lvReminders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvReminders_MouseUp);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 300;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 100;
            // 
            // chRepeat
            // 
            this.chRepeat.Text = "Repeating";
            this.chRepeat.Width = 135;
            // 
            // chEnabled
            // 
            this.chEnabled.Text = "Enabled";
            this.chEnabled.Width = 100;
            // 
            // ReminderMenuStrip
            // 
            this.ReminderMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.ReminderMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReminderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.exportSelectedRemindersToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.hideReminderToolStripMenuItem,
            this.unHideReminderToolStripMenuItem,
            this.postponeToolStripMenuItem,
            this.removePostponeToolStripMenuItem,
            this.skipToNextDateToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ReminderMenuStrip.Name = "ReminderMenuStrip";
            this.ReminderMenuStrip.Size = new System.Drawing.Size(255, 202);
            // 
            // tmrCheckReminder
            // 
            this.tmrCheckReminder.Interval = 5000;
            this.tmrCheckReminder.Tick += new System.EventHandler(this.tmrCheckReminder_Tick);
            // 
            // tmrClearMessageCache
            // 
            this.tmrClearMessageCache.Interval = 120000;
            this.tmrClearMessageCache.Tick += new System.EventHandler(this.tmrClearMessageCache_Tick);
            // 
            // pnlReminderButtons
            // 
            this.pnlReminderButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlReminderButtons.BackgroundImage")));
            this.pnlReminderButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlReminderButtons.Controls.Add(this.btnDisableEnable);
            this.pnlReminderButtons.Controls.Add(this.btnEditReminder);
            this.pnlReminderButtons.Controls.Add(this.btnRemoveReminder);
            this.pnlReminderButtons.Controls.Add(this.btnAddReminder);
            this.pnlReminderButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReminderButtons.GradientBottomLeft = System.Drawing.Color.Gray;
            this.pnlReminderButtons.GradientBottomRight = System.Drawing.Color.Gray;
            this.pnlReminderButtons.GradientTopLeft = System.Drawing.Color.Gray;
            this.pnlReminderButtons.GradientTopRight = System.Drawing.Color.Gray;
            this.pnlReminderButtons.Location = new System.Drawing.Point(0, 397);
            this.pnlReminderButtons.Name = "pnlReminderButtons";
            this.pnlReminderButtons.Quality = 10;
            this.pnlReminderButtons.Size = new System.Drawing.Size(666, 39);
            this.pnlReminderButtons.TabIndex = 1;
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.Activecolor = System.Drawing.Color.DimGray;
            this.btnDisableEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDisableEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisableEnable.BorderRadius = 5;
            this.btnDisableEnable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDisableEnable.ButtonText = "    Enable/Disable";
            this.btnDisableEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisableEnable.DisabledColor = System.Drawing.Color.Gray;
            this.btnDisableEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDisableEnable.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableEnable.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDisableEnable.Iconimage = global::RemindMe.Properties.Resources.Enable_white;
            this.btnDisableEnable.Iconimage_right = null;
            this.btnDisableEnable.Iconimage_right_Selected = null;
            this.btnDisableEnable.Iconimage_Selected = null;
            this.btnDisableEnable.IconMarginLeft = 0;
            this.btnDisableEnable.IconMarginRight = 0;
            this.btnDisableEnable.IconRightVisible = true;
            this.btnDisableEnable.IconRightZoom = 0D;
            this.btnDisableEnable.IconVisible = true;
            this.btnDisableEnable.IconZoom = 50D;
            this.btnDisableEnable.IsTab = false;
            this.btnDisableEnable.Location = new System.Drawing.Point(501, 0);
            this.btnDisableEnable.Name = "btnDisableEnable";
            this.btnDisableEnable.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDisableEnable.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnDisableEnable.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDisableEnable.selected = false;
            this.btnDisableEnable.Size = new System.Drawing.Size(166, 39);
            this.btnDisableEnable.TabIndex = 3;
            this.btnDisableEnable.Text = "    Enable/Disable";
            this.btnDisableEnable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisableEnable.Textcolor = System.Drawing.Color.White;
            this.btnDisableEnable.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableEnable.Click += new System.EventHandler(this.btnDisableEnable_Click);
            // 
            // btnEditReminder
            // 
            this.btnEditReminder.Activecolor = System.Drawing.Color.DimGray;
            this.btnEditReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditReminder.BorderRadius = 5;
            this.btnEditReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEditReminder.ButtonText = "    Edit Reminder";
            this.btnEditReminder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditReminder.DisabledColor = System.Drawing.Color.Gray;
            this.btnEditReminder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditReminder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReminder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditReminder.Iconimage = global::RemindMe.Properties.Resources.Edit_white;
            this.btnEditReminder.Iconimage_right = null;
            this.btnEditReminder.Iconimage_right_Selected = null;
            this.btnEditReminder.Iconimage_Selected = null;
            this.btnEditReminder.IconMarginLeft = 0;
            this.btnEditReminder.IconMarginRight = 0;
            this.btnEditReminder.IconRightVisible = true;
            this.btnEditReminder.IconRightZoom = 0D;
            this.btnEditReminder.IconVisible = true;
            this.btnEditReminder.IconZoom = 50D;
            this.btnEditReminder.IsTab = false;
            this.btnEditReminder.Location = new System.Drawing.Point(334, 0);
            this.btnEditReminder.Name = "btnEditReminder";
            this.btnEditReminder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditReminder.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnEditReminder.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditReminder.selected = false;
            this.btnEditReminder.Size = new System.Drawing.Size(167, 39);
            this.btnEditReminder.TabIndex = 2;
            this.btnEditReminder.Text = "    Edit Reminder";
            this.btnEditReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditReminder.Textcolor = System.Drawing.Color.White;
            this.btnEditReminder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReminder.Click += new System.EventHandler(this.btnEditReminder_Click);
            // 
            // btnRemoveReminder
            // 
            this.btnRemoveReminder.Activecolor = System.Drawing.Color.DimGray;
            this.btnRemoveReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveReminder.BorderRadius = 5;
            this.btnRemoveReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRemoveReminder.ButtonText = "Remove Reminder";
            this.btnRemoveReminder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveReminder.DisabledColor = System.Drawing.Color.Gray;
            this.btnRemoveReminder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemoveReminder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReminder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRemoveReminder.Iconimage = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveReminder.Iconimage_right = null;
            this.btnRemoveReminder.Iconimage_right_Selected = null;
            this.btnRemoveReminder.Iconimage_Selected = null;
            this.btnRemoveReminder.IconMarginLeft = 0;
            this.btnRemoveReminder.IconMarginRight = 0;
            this.btnRemoveReminder.IconRightVisible = true;
            this.btnRemoveReminder.IconRightZoom = 0D;
            this.btnRemoveReminder.IconVisible = true;
            this.btnRemoveReminder.IconZoom = 50D;
            this.btnRemoveReminder.IsTab = false;
            this.btnRemoveReminder.Location = new System.Drawing.Point(167, 0);
            this.btnRemoveReminder.Name = "btnRemoveReminder";
            this.btnRemoveReminder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveReminder.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnRemoveReminder.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRemoveReminder.selected = false;
            this.btnRemoveReminder.Size = new System.Drawing.Size(167, 39);
            this.btnRemoveReminder.TabIndex = 1;
            this.btnRemoveReminder.Text = "Remove Reminder";
            this.btnRemoveReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveReminder.Textcolor = System.Drawing.Color.White;
            this.btnRemoveReminder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReminder.Click += new System.EventHandler(this.btnRemoveReminder_Click);
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Activecolor = System.Drawing.Color.DimGray;
            this.btnAddReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddReminder.BorderRadius = 5;
            this.btnAddReminder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddReminder.ButtonText = "    New Reminder";
            this.btnAddReminder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddReminder.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddReminder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddReminder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReminder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddReminder.Iconimage = global::RemindMe.Properties.Resources.Plus_white;
            this.btnAddReminder.Iconimage_right = null;
            this.btnAddReminder.Iconimage_right_Selected = null;
            this.btnAddReminder.Iconimage_Selected = null;
            this.btnAddReminder.IconMarginLeft = 0;
            this.btnAddReminder.IconMarginRight = 0;
            this.btnAddReminder.IconRightVisible = true;
            this.btnAddReminder.IconRightZoom = 0D;
            this.btnAddReminder.IconVisible = true;
            this.btnAddReminder.IconZoom = 40D;
            this.btnAddReminder.IsTab = false;
            this.btnAddReminder.Location = new System.Drawing.Point(0, 0);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddReminder.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnAddReminder.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddReminder.selected = false;
            this.btnAddReminder.Size = new System.Drawing.Size(167, 39);
            this.btnAddReminder.TabIndex = 0;
            this.btnAddReminder.Text = "    New Reminder";
            this.btnAddReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddReminder.Textcolor = System.Drawing.Color.White;
            this.btnAddReminder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
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
            this.previewThisReminderIn5SecondsToolStripMenuItem.Click += new System.EventHandler(this.previewThisReminderIn5SecondsToolStripMenuItem_Click);
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
            // exportSelectedRemindersToolStripMenuItem
            // 
            this.exportSelectedRemindersToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportSelectedRemindersToolStripMenuItem.BackgroundImage")));
            this.exportSelectedRemindersToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.exportSelectedRemindersToolStripMenuItem.Image = global::RemindMe.Properties.Resources.export_black;
            this.exportSelectedRemindersToolStripMenuItem.Name = "exportSelectedRemindersToolStripMenuItem";
            this.exportSelectedRemindersToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.exportSelectedRemindersToolStripMenuItem.Text = "Export selected reminders";
            this.exportSelectedRemindersToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedRemindersToolStripMenuItem_Click);
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
            // unHideReminderToolStripMenuItem
            // 
            this.unHideReminderToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("unHideReminderToolStripMenuItem.BackgroundImage")));
            this.unHideReminderToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.unHideReminderToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.unHideReminderToolStripMenuItem.Image = global::RemindMe.Properties.Resources.show;
            this.unHideReminderToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unHideReminderToolStripMenuItem.Name = "unHideReminderToolStripMenuItem";
            this.unHideReminderToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.unHideReminderToolStripMenuItem.Text = "Unhide reminders";
            this.unHideReminderToolStripMenuItem.Click += new System.EventHandler(this.unHideReminderToolStripMenuItem_Click);
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
            this.toolStripMenuItem1.Click += new System.EventHandler(this.permanentelyRemoveToolStripMenuItem_Click);
            // 
            // UCReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lvReminders);
            this.Controls.Add(this.pnlReminderButtons);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UCReminders";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCReminders_Load);
            this.ReminderMenuStrip.ResumeLayout(false);
            this.pnlReminderButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuGradientPanel pnlReminderButtons;
        public System.Windows.Forms.ListView lvReminders;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chRepeat;
        private System.Windows.Forms.ColumnHeader chEnabled;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddReminder;
        private Bunifu.Framework.UI.BunifuFlatButton btnDisableEnable;
        private Bunifu.Framework.UI.BunifuFlatButton btnEditReminder;
        private Bunifu.Framework.UI.BunifuFlatButton btnRemoveReminder;
        private System.Windows.Forms.ContextMenuStrip ReminderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn5SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn10SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedRemindersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePostponeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skipToNextDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unHideReminderToolStripMenuItem;
        private System.Windows.Forms.Timer tmrCheckReminder;
        private System.Windows.Forms.Timer tmrClearMessageCache;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableWarningToolStripMenuItem;
    }
}
