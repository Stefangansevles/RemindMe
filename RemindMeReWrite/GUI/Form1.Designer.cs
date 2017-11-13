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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.btnDisableEnable = new System.Windows.Forms.Button();
            this.btnRemoveReminder = new System.Windows.Forms.Button();
            this.btnEditReminder = new System.Windows.Forms.Button();
            this.lvReminders = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddReminder = new System.Windows.Forms.Button();
            this.pnlNewReminder = new System.Windows.Forms.Panel();
            this.btnAddDays = new System.Windows.Forms.Button();
            this.lblAddedDates = new System.Windows.Forms.Label();
            this.btnAddDate = new System.Windows.Forms.Button();
            this.btnRemoveDate = new System.Windows.Forms.Button();
            this.cbMultipleDates = new System.Windows.Forms.ComboBox();
            this.pnlPopup = new System.Windows.Forms.Panel();
            this.cbMonthlyDays = new System.Windows.Forms.ComboBox();
            this.btnRemoveMonthlyDay = new System.Windows.Forms.Button();
            this.btnAddMonthlyDay = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlDayCheckBoxes = new System.Windows.Forms.Panel();
            this.cbSunday = new System.Windows.Forms.CheckBox();
            this.cbSaturday = new System.Windows.Forms.CheckBox();
            this.cbFriday = new System.Windows.Forms.CheckBox();
            this.cbThursday = new System.Windows.Forms.CheckBox();
            this.cbWednesday = new System.Windows.Forms.CheckBox();
            this.cbTuesday = new System.Windows.Forms.CheckBox();
            this.cbMonday = new System.Windows.Forms.CheckBox();
            this.cbStickyForm = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbEveryXCustom = new System.Windows.Forms.ComboBox();
            this.numEveryXDays = new System.Windows.Forms.NumericUpDown();
            this.pbExclamationWorkday = new System.Windows.Forms.PictureBox();
            this.pbExclamationTitle = new System.Windows.Forms.PictureBox();
            this.pbExclamationDate = new System.Windows.Forms.PictureBox();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.cbSound = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbEdit = new System.Windows.Forms.PictureBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEvery = new System.Windows.Forms.ComboBox();
            this.lblEvery = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupRepeatRadiobuttons = new System.Windows.Forms.GroupBox();
            this.rbMultipleDays = new System.Windows.Forms.RadioButton();
            this.rbEveryXCustom = new System.Windows.Forms.RadioButton();
            this.rbWorkDays = new System.Windows.Forms.RadioButton();
            this.rbNoRepeat = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReminderName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.tmrCheckReminder = new System.Windows.Forms.Timer(this.components);
            this.RemindMeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RemindMeTrayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemindMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tmrUpdateListview = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbCustomizePopup = new System.Windows.Forms.PictureBox();
            this.pbImportExport = new System.Windows.Forms.PictureBox();
            this.pbWindows = new System.Windows.Forms.PictureBox();
            this.pbMusic = new System.Windows.Forms.PictureBox();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.ReminderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn5SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewThisReminderIn10SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permanentelyRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDisableReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedRemindersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnBackFromSettings = new System.Windows.Forms.Button();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tmrAnimationScrollUp = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimationScrollDown = new System.Windows.Forms.Timer(this.components);
            this.tmrMessageFormScrollUp = new System.Windows.Forms.Timer(this.components);
            this.tmrMessageFormScrollDown = new System.Windows.Forms.Timer(this.components);
            this.tmrAllowMail = new System.Windows.Forms.Timer(this.components);
            this.AddDaysMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            this.pnlNewReminder.SuspendLayout();
            this.pnlDayCheckBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEveryXDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWorkday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).BeginInit();
            this.groupRepeatRadiobuttons.SuspendLayout();
            this.RemindMeTrayIconMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomizePopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImportExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusic)).BeginInit();
            this.ReminderMenuStrip.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.AddDaysMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.pbSettings);
            this.pnlMain.Controls.Add(this.btnDisableEnable);
            this.pnlMain.Controls.Add(this.btnRemoveReminder);
            this.pnlMain.Controls.Add(this.btnEditReminder);
            this.pnlMain.Controls.Add(this.lvReminders);
            this.pnlMain.Controls.Add(this.btnAddReminder);
            this.pnlMain.Location = new System.Drawing.Point(0, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(475, 457);
            this.pnlMain.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 97);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // pbSettings
            // 
            this.pbSettings.BackColor = System.Drawing.Color.Transparent;
            this.pbSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSettings.BackgroundImage")));
            this.pbSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSettings.Location = new System.Drawing.Point(433, 426);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(25, 24);
            this.pbSettings.TabIndex = 66;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableEnable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisableEnable.BackgroundImage")));
            this.btnDisableEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisableEnable.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDisableEnable.ForeColor = System.Drawing.Color.Transparent;
            this.btnDisableEnable.Location = new System.Drawing.Point(324, 428);
            this.btnDisableEnable.Name = "btnDisableEnable";
            this.btnDisableEnable.Size = new System.Drawing.Size(105, 23);
            this.btnDisableEnable.TabIndex = 58;
            this.btnDisableEnable.Text = "Disable/Enable";
            this.btnDisableEnable.UseVisualStyleBackColor = false;
            this.btnDisableEnable.Click += new System.EventHandler(this.btnDisableEnable_Click);
            // 
            // btnRemoveReminder
            // 
            this.btnRemoveReminder.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveReminder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveReminder.BackgroundImage")));
            this.btnRemoveReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveReminder.Location = new System.Drawing.Point(100, 428);
            this.btnRemoveReminder.Name = "btnRemoveReminder";
            this.btnRemoveReminder.Size = new System.Drawing.Size(124, 23);
            this.btnRemoveReminder.TabIndex = 29;
            this.btnRemoveReminder.Text = "Remove Reminder";
            this.btnRemoveReminder.UseVisualStyleBackColor = false;
            this.btnRemoveReminder.Click += new System.EventHandler(this.btnRemoveReminder_Click);
            // 
            // btnEditReminder
            // 
            this.btnEditReminder.BackColor = System.Drawing.Color.Transparent;
            this.btnEditReminder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditReminder.BackgroundImage")));
            this.btnEditReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEditReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnEditReminder.Location = new System.Drawing.Point(224, 428);
            this.btnEditReminder.Name = "btnEditReminder";
            this.btnEditReminder.Size = new System.Drawing.Size(100, 23);
            this.btnEditReminder.TabIndex = 28;
            this.btnEditReminder.Text = "Edit Reminder";
            this.btnEditReminder.UseVisualStyleBackColor = false;
            this.btnEditReminder.Click += new System.EventHandler(this.btnEditReminder_Click);
            // 
            // lvReminders
            // 
            this.lvReminders.BackColor = System.Drawing.Color.DimGray;
            this.lvReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDate,
            this.chRepeat,
            this.cbEnabled});
            this.lvReminders.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lvReminders.ForeColor = System.Drawing.Color.White;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.Location = new System.Drawing.Point(0, 95);
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.Size = new System.Drawing.Size(464, 329);
            this.lvReminders.TabIndex = 0;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;
            this.lvReminders.DoubleClick += new System.EventHandler(this.lvReminders_DoubleClick);
            this.lvReminders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReminders_KeyDown);
            this.lvReminders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvReminders_MouseClick);
            // 
            // chName
            // 
            this.chName.Text = "Title";
            this.chName.Width = 183;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 80;
            // 
            // chRepeat
            // 
            this.chRepeat.Text = "Repeating";
            this.chRepeat.Width = 120;
            // 
            // cbEnabled
            // 
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.Width = 58;
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.BackColor = System.Drawing.Color.Transparent;
            this.btnAddReminder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddReminder.BackgroundImage")));
            this.btnAddReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddReminder.Location = new System.Drawing.Point(3, 428);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(97, 23);
            this.btnAddReminder.TabIndex = 25;
            this.btnAddReminder.Text = "Add Reminder";
            this.btnAddReminder.UseVisualStyleBackColor = false;
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // pnlNewReminder
            // 
            this.pnlNewReminder.BackColor = System.Drawing.Color.Transparent;
            this.pnlNewReminder.Controls.Add(this.btnAddDays);
            this.pnlNewReminder.Controls.Add(this.lblAddedDates);
            this.pnlNewReminder.Controls.Add(this.btnAddDate);
            this.pnlNewReminder.Controls.Add(this.btnRemoveDate);
            this.pnlNewReminder.Controls.Add(this.cbMultipleDates);
            this.pnlNewReminder.Controls.Add(this.pnlPopup);
            this.pnlNewReminder.Controls.Add(this.cbMonthlyDays);
            this.pnlNewReminder.Controls.Add(this.btnRemoveMonthlyDay);
            this.pnlNewReminder.Controls.Add(this.btnAddMonthlyDay);
            this.pnlNewReminder.Controls.Add(this.lblVersion);
            this.pnlNewReminder.Controls.Add(this.pnlDayCheckBoxes);
            this.pnlNewReminder.Controls.Add(this.cbStickyForm);
            this.pnlNewReminder.Controls.Add(this.btnClear);
            this.pnlNewReminder.Controls.Add(this.cbEveryXCustom);
            this.pnlNewReminder.Controls.Add(this.numEveryXDays);
            this.pnlNewReminder.Controls.Add(this.pbExclamationWorkday);
            this.pnlNewReminder.Controls.Add(this.pbExclamationTitle);
            this.pnlNewReminder.Controls.Add(this.pbExclamationDate);
            this.pnlNewReminder.Controls.Add(this.btnPlaySound);
            this.pnlNewReminder.Controls.Add(this.cbSound);
            this.pnlNewReminder.Controls.Add(this.label5);
            this.pnlNewReminder.Controls.Add(this.pbEdit);
            this.pnlNewReminder.Controls.Add(this.dtpTime);
            this.pnlNewReminder.Controls.Add(this.label7);
            this.pnlNewReminder.Controls.Add(this.cbEvery);
            this.pnlNewReminder.Controls.Add(this.lblEvery);
            this.pnlNewReminder.Controls.Add(this.btnConfirm);
            this.pnlNewReminder.Controls.Add(this.groupRepeatRadiobuttons);
            this.pnlNewReminder.Controls.Add(this.lblRepeat);
            this.pnlNewReminder.Controls.Add(this.label2);
            this.pnlNewReminder.Controls.Add(this.label1);
            this.pnlNewReminder.Controls.Add(this.tbReminderName);
            this.pnlNewReminder.Controls.Add(this.dtpDate);
            this.pnlNewReminder.Controls.Add(this.lblNote);
            this.pnlNewReminder.Controls.Add(this.tbNote);
            this.pnlNewReminder.Controls.Add(this.btnBack);
            this.pnlNewReminder.Location = new System.Drawing.Point(530, 22);
            this.pnlNewReminder.Name = "pnlNewReminder";
            this.pnlNewReminder.Size = new System.Drawing.Size(467, 458);
            this.pnlNewReminder.TabIndex = 27;
            this.pnlNewReminder.Visible = false;
            // 
            // btnAddDays
            // 
            this.btnAddDays.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDays.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDays.BackgroundImage")));
            this.btnAddDays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.btnAddDays.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddDays.Location = new System.Drawing.Point(317, 164);
            this.btnAddDays.Name = "btnAddDays";
            this.btnAddDays.Size = new System.Drawing.Size(25, 20);
            this.btnAddDays.TabIndex = 86;
            this.btnAddDays.Text = "...";
            this.toolTip1.SetToolTip(this.btnAddDays, " Add/Subtract days");
            this.btnAddDays.UseVisualStyleBackColor = false;
            this.btnAddDays.Click += new System.EventHandler(this.btnAddDays_Click);
            // 
            // lblAddedDates
            // 
            this.lblAddedDates.AutoSize = true;
            this.lblAddedDates.BackColor = System.Drawing.Color.Transparent;
            this.lblAddedDates.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAddedDates.ForeColor = System.Drawing.Color.White;
            this.lblAddedDates.Location = new System.Drawing.Point(42, 219);
            this.lblAddedDates.Name = "lblAddedDates";
            this.lblAddedDates.Size = new System.Drawing.Size(44, 15);
            this.lblAddedDates.TabIndex = 85;
            this.lblAddedDates.Text = "Dates:";
            this.lblAddedDates.Visible = false;
            // 
            // btnAddDate
            // 
            this.btnAddDate.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDate.BackgroundImage")));
            this.btnAddDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddDate.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddDate.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddDate.Location = new System.Drawing.Point(317, 191);
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(25, 20);
            this.btnAddDate.TabIndex = 84;
            this.btnAddDate.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddDate, "Adds the selected date into a list of dates. \r\nThis reminder will then pop up at " +
        "the selected dates.");
            this.btnAddDate.UseVisualStyleBackColor = false;
            this.btnAddDate.Visible = false;
            this.btnAddDate.Click += new System.EventHandler(this.btnAddDate_Click);
            // 
            // btnRemoveDate
            // 
            this.btnRemoveDate.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveDate.BackgroundImage")));
            this.btnRemoveDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveDate.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveDate.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveDate.Location = new System.Drawing.Point(317, 219);
            this.btnRemoveDate.Name = "btnRemoveDate";
            this.btnRemoveDate.Size = new System.Drawing.Size(25, 20);
            this.btnRemoveDate.TabIndex = 83;
            this.btnRemoveDate.Text = "-";
            this.btnRemoveDate.UseVisualStyleBackColor = false;
            this.btnRemoveDate.Visible = false;
            this.btnRemoveDate.Click += new System.EventHandler(this.btnRemoveDate_Click);
            // 
            // cbMultipleDates
            // 
            this.cbMultipleDates.BackColor = System.Drawing.Color.DimGray;
            this.cbMultipleDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbMultipleDates.ForeColor = System.Drawing.Color.White;
            this.cbMultipleDates.FormattingEnabled = true;
            this.cbMultipleDates.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Tuesday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbMultipleDates.Location = new System.Drawing.Point(107, 219);
            this.cbMultipleDates.Name = "cbMultipleDates";
            this.cbMultipleDates.Size = new System.Drawing.Size(205, 21);
            this.cbMultipleDates.TabIndex = 82;
            this.cbMultipleDates.Visible = false;
            this.cbMultipleDates.VisibleChanged += new System.EventHandler(this.cbMultipleDates_VisibleChanged);
            // 
            // pnlPopup
            // 
            this.pnlPopup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPopup.Location = new System.Drawing.Point(242, 401);
            this.pnlPopup.Name = "pnlPopup";
            this.pnlPopup.Size = new System.Drawing.Size(221, 54);
            this.pnlPopup.TabIndex = 81;
            this.pnlPopup.Visible = false;
            this.pnlPopup.VisibleChanged += new System.EventHandler(this.pnlPopup_VisibleChanged);
            // 
            // cbMonthlyDays
            // 
            this.cbMonthlyDays.BackColor = System.Drawing.Color.DimGray;
            this.cbMonthlyDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonthlyDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbMonthlyDays.ForeColor = System.Drawing.Color.White;
            this.cbMonthlyDays.FormattingEnabled = true;
            this.cbMonthlyDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Tuesday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbMonthlyDays.Location = new System.Drawing.Point(267, 276);
            this.cbMonthlyDays.Name = "cbMonthlyDays";
            this.cbMonthlyDays.Size = new System.Drawing.Size(76, 21);
            this.cbMonthlyDays.TabIndex = 80;
            this.cbMonthlyDays.Visible = false;
            // 
            // btnRemoveMonthlyDay
            // 
            this.btnRemoveMonthlyDay.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveMonthlyDay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMonthlyDay.BackgroundImage")));
            this.btnRemoveMonthlyDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveMonthlyDay.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveMonthlyDay.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveMonthlyDay.Location = new System.Drawing.Point(228, 276);
            this.btnRemoveMonthlyDay.Name = "btnRemoveMonthlyDay";
            this.btnRemoveMonthlyDay.Size = new System.Drawing.Size(37, 20);
            this.btnRemoveMonthlyDay.TabIndex = 79;
            this.btnRemoveMonthlyDay.Text = "-";
            this.btnRemoveMonthlyDay.UseVisualStyleBackColor = false;
            this.btnRemoveMonthlyDay.Visible = false;
            this.btnRemoveMonthlyDay.Click += new System.EventHandler(this.btnRemoveMonthlyDay_Click);
            // 
            // btnAddMonthlyDay
            // 
            this.btnAddMonthlyDay.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMonthlyDay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddMonthlyDay.BackgroundImage")));
            this.btnAddMonthlyDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddMonthlyDay.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddMonthlyDay.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddMonthlyDay.Location = new System.Drawing.Point(189, 276);
            this.btnAddMonthlyDay.Name = "btnAddMonthlyDay";
            this.btnAddMonthlyDay.Size = new System.Drawing.Size(37, 20);
            this.btnAddMonthlyDay.TabIndex = 78;
            this.btnAddMonthlyDay.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddMonthlyDay, "Adds the monthly day to this reminder.\r\nYou can also press enter while your curso" +
        "r is in the field");
            this.btnAddMonthlyDay.UseVisualStyleBackColor = false;
            this.btnAddMonthlyDay.Visible = false;
            this.btnAddMonthlyDay.Click += new System.EventHandler(this.btnAddMonthlyDay_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(283, 435);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(135, 16);
            this.lblVersion.TabIndex = 67;
            this.lblVersion.Text = "RemindMe - Version x";
            // 
            // pnlDayCheckBoxes
            // 
            this.pnlDayCheckBoxes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDayCheckBoxes.Controls.Add(this.cbSunday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbSaturday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbFriday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbThursday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbWednesday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbTuesday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbMonday);
            this.pnlDayCheckBoxes.Location = new System.Drawing.Point(112, 276);
            this.pnlDayCheckBoxes.Name = "pnlDayCheckBoxes";
            this.pnlDayCheckBoxes.Size = new System.Drawing.Size(234, 65);
            this.pnlDayCheckBoxes.TabIndex = 77;
            this.pnlDayCheckBoxes.Visible = false;
            this.pnlDayCheckBoxes.VisibleChanged += new System.EventHandler(this.pnlDayCheckBoxes_VisibleChanged);
            // 
            // cbSunday
            // 
            this.cbSunday.AutoSize = true;
            this.cbSunday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbSunday.ForeColor = System.Drawing.Color.White;
            this.cbSunday.Location = new System.Drawing.Point(2, 35);
            this.cbSunday.Name = "cbSunday";
            this.cbSunday.Size = new System.Drawing.Size(62, 18);
            this.cbSunday.TabIndex = 6;
            this.cbSunday.Text = "Sunday";
            this.cbSunday.UseVisualStyleBackColor = true;
            // 
            // cbSaturday
            // 
            this.cbSaturday.AutoSize = true;
            this.cbSaturday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbSaturday.ForeColor = System.Drawing.SystemColors.Window;
            this.cbSaturday.Location = new System.Drawing.Point(148, 18);
            this.cbSaturday.Name = "cbSaturday";
            this.cbSaturday.Size = new System.Drawing.Size(70, 18);
            this.cbSaturday.TabIndex = 5;
            this.cbSaturday.Text = "Saturday";
            this.cbSaturday.UseVisualStyleBackColor = true;
            // 
            // cbFriday
            // 
            this.cbFriday.AutoSize = true;
            this.cbFriday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbFriday.ForeColor = System.Drawing.SystemColors.Window;
            this.cbFriday.Location = new System.Drawing.Point(72, 18);
            this.cbFriday.Name = "cbFriday";
            this.cbFriday.Size = new System.Drawing.Size(56, 18);
            this.cbFriday.TabIndex = 4;
            this.cbFriday.Text = "Friday";
            this.cbFriday.UseVisualStyleBackColor = true;
            // 
            // cbThursday
            // 
            this.cbThursday.AutoSize = true;
            this.cbThursday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbThursday.ForeColor = System.Drawing.Color.White;
            this.cbThursday.Location = new System.Drawing.Point(2, 18);
            this.cbThursday.Name = "cbThursday";
            this.cbThursday.Size = new System.Drawing.Size(71, 18);
            this.cbThursday.TabIndex = 3;
            this.cbThursday.Text = "Thursday";
            this.cbThursday.UseVisualStyleBackColor = true;
            // 
            // cbWednesday
            // 
            this.cbWednesday.AutoSize = true;
            this.cbWednesday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbWednesday.ForeColor = System.Drawing.Color.White;
            this.cbWednesday.Location = new System.Drawing.Point(148, 1);
            this.cbWednesday.Name = "cbWednesday";
            this.cbWednesday.Size = new System.Drawing.Size(83, 18);
            this.cbWednesday.TabIndex = 2;
            this.cbWednesday.Text = "Wednesday";
            this.cbWednesday.UseVisualStyleBackColor = true;
            // 
            // cbTuesday
            // 
            this.cbTuesday.AutoSize = true;
            this.cbTuesday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbTuesday.ForeColor = System.Drawing.Color.White;
            this.cbTuesday.Location = new System.Drawing.Point(72, 1);
            this.cbTuesday.Name = "cbTuesday";
            this.cbTuesday.Size = new System.Drawing.Size(67, 18);
            this.cbTuesday.TabIndex = 1;
            this.cbTuesday.Text = "Tuesday";
            this.cbTuesday.UseVisualStyleBackColor = true;
            // 
            // cbMonday
            // 
            this.cbMonday.AutoSize = true;
            this.cbMonday.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbMonday.ForeColor = System.Drawing.Color.White;
            this.cbMonday.Location = new System.Drawing.Point(2, 1);
            this.cbMonday.Name = "cbMonday";
            this.cbMonday.Size = new System.Drawing.Size(64, 18);
            this.cbMonday.TabIndex = 0;
            this.cbMonday.Text = "Monday";
            this.cbMonday.UseVisualStyleBackColor = true;
            // 
            // cbStickyForm
            // 
            this.cbStickyForm.AutoSize = true;
            this.cbStickyForm.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbStickyForm.ForeColor = System.Drawing.Color.White;
            this.cbStickyForm.Location = new System.Drawing.Point(3, 438);
            this.cbStickyForm.Name = "cbStickyForm";
            this.cbStickyForm.Size = new System.Drawing.Size(84, 18);
            this.cbStickyForm.TabIndex = 76;
            this.cbStickyForm.Text = "Sticky form";
            this.toolTip1.SetToolTip(this.cbStickyForm, "When checked, data from the form will not be\r\ncleared. Data from the previous rem" +
        "inder\r\nwill still be in the fields when adding a new reminder");
            this.cbStickyForm.UseVisualStyleBackColor = true;
            this.cbStickyForm.CheckedChanged += new System.EventHandler(this.cbStickyForm_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(264, 347);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 23);
            this.btnClear.TabIndex = 75;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbEveryXCustom
            // 
            this.cbEveryXCustom.BackColor = System.Drawing.Color.DimGray;
            this.cbEveryXCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbEveryXCustom.ForeColor = System.Drawing.Color.White;
            this.cbEveryXCustom.FormattingEnabled = true;
            this.cbEveryXCustom.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months"});
            this.cbEveryXCustom.Location = new System.Drawing.Point(186, 276);
            this.cbEveryXCustom.Name = "cbEveryXCustom";
            this.cbEveryXCustom.Size = new System.Drawing.Size(156, 21);
            this.cbEveryXCustom.TabIndex = 74;
            this.cbEveryXCustom.Visible = false;
            this.cbEveryXCustom.TextChanged += new System.EventHandler(this.cbEveryXCustom_TextChanged);
            // 
            // numEveryXDays
            // 
            this.numEveryXDays.BackColor = System.Drawing.Color.DimGray;
            this.numEveryXDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numEveryXDays.ForeColor = System.Drawing.Color.White;
            this.numEveryXDays.Location = new System.Drawing.Point(110, 276);
            this.numEveryXDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEveryXDays.Name = "numEveryXDays";
            this.numEveryXDays.Size = new System.Drawing.Size(73, 20);
            this.numEveryXDays.TabIndex = 71;
            this.numEveryXDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEveryXDays.Visible = false;
            this.numEveryXDays.ValueChanged += new System.EventHandler(this.numEveryXDays_ValueChanged);
            this.numEveryXDays.VisibleChanged += new System.EventHandler(this.numEveryXDays_VisibleChanged);
            // 
            // pbExclamationWorkday
            // 
            this.pbExclamationWorkday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExclamationWorkday.BackgroundImage")));
            this.pbExclamationWorkday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExclamationWorkday.Location = new System.Drawing.Point(347, 174);
            this.pbExclamationWorkday.Name = "pbExclamationWorkday";
            this.pbExclamationWorkday.Size = new System.Drawing.Size(27, 24);
            this.pbExclamationWorkday.TabIndex = 70;
            this.pbExclamationWorkday.TabStop = false;
            this.pbExclamationWorkday.Visible = false;
            // 
            // pbExclamationTitle
            // 
            this.pbExclamationTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExclamationTitle.BackgroundImage")));
            this.pbExclamationTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExclamationTitle.Location = new System.Drawing.Point(347, 107);
            this.pbExclamationTitle.Name = "pbExclamationTitle";
            this.pbExclamationTitle.Size = new System.Drawing.Size(27, 24);
            this.pbExclamationTitle.TabIndex = 69;
            this.pbExclamationTitle.TabStop = false;
            this.pbExclamationTitle.Visible = false;
            // 
            // pbExclamationDate
            // 
            this.pbExclamationDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExclamationDate.BackgroundImage")));
            this.pbExclamationDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExclamationDate.Location = new System.Drawing.Point(347, 174);
            this.pbExclamationDate.Name = "pbExclamationDate";
            this.pbExclamationDate.Size = new System.Drawing.Size(27, 24);
            this.pbExclamationDate.TabIndex = 68;
            this.pbExclamationDate.TabStop = false;
            this.pbExclamationDate.Visible = false;
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlaySound.BackgroundImage")));
            this.btnPlaySound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaySound.Location = new System.Drawing.Point(317, 137);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(24, 21);
            this.btnPlaySound.TabIndex = 66;
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // cbSound
            // 
            this.cbSound.BackColor = System.Drawing.Color.DimGray;
            this.cbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbSound.ForeColor = System.Drawing.Color.White;
            this.cbSound.FormattingEnabled = true;
            this.cbSound.Items.AddRange(new object[] {
            "Add files..."});
            this.cbSound.Location = new System.Drawing.Point(107, 137);
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(205, 21);
            this.cbSound.TabIndex = 65;
            this.cbSound.SelectedIndexChanged += new System.EventHandler(this.cbSound_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(42, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 30);
            this.label5.TabIndex = 62;
            this.label5.Text = "Popup \r\nsound:";
            this.toolTip1.SetToolTip(this.label5, "Enter an URL or click the folder button.\r\nWhen an reminder pops up, you will see\r" +
        "\nthe image you selected with it");
            // 
            // pbEdit
            // 
            this.pbEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbEdit.BackgroundImage")));
            this.pbEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEdit.Location = new System.Drawing.Point(0, 0);
            this.pbEdit.Name = "pbEdit";
            this.pbEdit.Size = new System.Drawing.Size(466, 97);
            this.pbEdit.TabIndex = 60;
            this.pbEdit.TabStop = false;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(107, 191);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(205, 20);
            this.dtpTime.TabIndex = 58;
            this.dtpTime.Value = new System.DateTime(2016, 9, 4, 12, 0, 0, 0);
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(42, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "Time:";
            // 
            // cbEvery
            // 
            this.cbEvery.BackColor = System.Drawing.Color.DimGray;
            this.cbEvery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbEvery.ForeColor = System.Drawing.Color.White;
            this.cbEvery.FormattingEnabled = true;
            this.cbEvery.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Tuesday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbEvery.Location = new System.Drawing.Point(110, 276);
            this.cbEvery.Name = "cbEvery";
            this.cbEvery.Size = new System.Drawing.Size(76, 21);
            this.cbEvery.TabIndex = 58;
            this.cbEvery.Visible = false;
            this.cbEvery.SelectedIndexChanged += new System.EventHandler(this.cbEvery_SelectedIndexChanged);
            this.cbEvery.VisibleChanged += new System.EventHandler(this.cbEvery_VisibleChanged);
            this.cbEvery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbEvery_KeyUp);
            // 
            // lblEvery
            // 
            this.lblEvery.AutoSize = true;
            this.lblEvery.BackColor = System.Drawing.Color.Transparent;
            this.lblEvery.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEvery.ForeColor = System.Drawing.Color.White;
            this.lblEvery.Location = new System.Drawing.Point(43, 290);
            this.lblEvery.Name = "lblEvery";
            this.lblEvery.Size = new System.Drawing.Size(42, 15);
            this.lblEvery.TabIndex = 57;
            this.lblEvery.Text = "Every:";
            this.lblEvery.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Location = new System.Drawing.Point(108, 347);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(89, 23);
            this.btnConfirm.TabIndex = 30;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupRepeatRadiobuttons
            // 
            this.groupRepeatRadiobuttons.Controls.Add(this.rbMultipleDays);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbEveryXCustom);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbWorkDays);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbNoRepeat);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbMonthly);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbDaily);
            this.groupRepeatRadiobuttons.Controls.Add(this.radioButton2);
            this.groupRepeatRadiobuttons.Location = new System.Drawing.Point(106, 211);
            this.groupRepeatRadiobuttons.Name = "groupRepeatRadiobuttons";
            this.groupRepeatRadiobuttons.Size = new System.Drawing.Size(234, 59);
            this.groupRepeatRadiobuttons.TabIndex = 56;
            this.groupRepeatRadiobuttons.TabStop = false;
            this.groupRepeatRadiobuttons.LocationChanged += new System.EventHandler(this.groupRepeatRadiobuttons_LocationChanged);
            // 
            // rbMultipleDays
            // 
            this.rbMultipleDays.AutoSize = true;
            this.rbMultipleDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbMultipleDays.ForeColor = System.Drawing.Color.White;
            this.rbMultipleDays.Location = new System.Drawing.Point(154, 11);
            this.rbMultipleDays.Name = "rbMultipleDays";
            this.rbMultipleDays.Size = new System.Drawing.Size(76, 18);
            this.rbMultipleDays.TabIndex = 64;
            this.rbMultipleDays.Text = "Weekdays";
            this.toolTip1.SetToolTip(this.rbMultipleDays, "Reminder repeats on the selected weekdays");
            this.rbMultipleDays.UseVisualStyleBackColor = true;
            this.rbMultipleDays.CheckedChanged += new System.EventHandler(this.rbMultipleDays_CheckedChanged);
            // 
            // rbEveryXCustom
            // 
            this.rbEveryXCustom.AutoSize = true;
            this.rbEveryXCustom.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbEveryXCustom.ForeColor = System.Drawing.Color.White;
            this.rbEveryXCustom.Location = new System.Drawing.Point(73, 30);
            this.rbEveryXCustom.Name = "rbEveryXCustom";
            this.rbEveryXCustom.Size = new System.Drawing.Size(63, 18);
            this.rbEveryXCustom.TabIndex = 63;
            this.rbEveryXCustom.Text = "Custom";
            this.toolTip1.SetToolTip(this.rbEveryXCustom, "Set a custom repeat schedule\r\nExample: Every 5 hours, Every 3 days, etc");
            this.rbEveryXCustom.UseVisualStyleBackColor = true;
            this.rbEveryXCustom.CheckedChanged += new System.EventHandler(this.rbEveryXDays_CheckedChanged);
            // 
            // rbWorkDays
            // 
            this.rbWorkDays.AutoSize = true;
            this.rbWorkDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbWorkDays.ForeColor = System.Drawing.Color.White;
            this.rbWorkDays.Location = new System.Drawing.Point(73, 11);
            this.rbWorkDays.Name = "rbWorkDays";
            this.rbWorkDays.Size = new System.Drawing.Size(78, 18);
            this.rbWorkDays.TabIndex = 62;
            this.rbWorkDays.Text = "Work days";
            this.toolTip1.SetToolTip(this.rbWorkDays, "Reminder repeats every day, except during the weekends");
            this.rbWorkDays.UseVisualStyleBackColor = true;
            this.rbWorkDays.CheckedChanged += new System.EventHandler(this.rbWorkDays_CheckedChanged);
            // 
            // rbNoRepeat
            // 
            this.rbNoRepeat.AutoSize = true;
            this.rbNoRepeat.Checked = true;
            this.rbNoRepeat.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbNoRepeat.ForeColor = System.Drawing.Color.White;
            this.rbNoRepeat.Location = new System.Drawing.Point(154, 30);
            this.rbNoRepeat.Name = "rbNoRepeat";
            this.rbNoRepeat.Size = new System.Drawing.Size(82, 18);
            this.rbNoRepeat.TabIndex = 61;
            this.rbNoRepeat.TabStop = true;
            this.rbNoRepeat.Text = "Set date(s)";
            this.toolTip1.SetToolTip(this.rbNoRepeat, "Reminder does NOT repeat, but has 1 or more dates");
            this.rbNoRepeat.UseVisualStyleBackColor = true;
            this.rbNoRepeat.CheckedChanged += new System.EventHandler(this.rbNoRepeat_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbMonthly.ForeColor = System.Drawing.Color.White;
            this.rbMonthly.Location = new System.Drawing.Point(6, 30);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(64, 18);
            this.rbMonthly.TabIndex = 59;
            this.rbMonthly.Text = "Monthly";
            this.toolTip1.SetToolTip(this.rbMonthly, "Reminder repeats on every selected monthly day");
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbMonthly_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbDaily.ForeColor = System.Drawing.Color.White;
            this.rbDaily.Location = new System.Drawing.Point(6, 11);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(50, 18);
            this.rbDaily.TabIndex = 58;
            this.rbDaily.Text = "Daily";
            this.toolTip1.SetToolTip(this.rbDaily, "Reminder repeats every day.");
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(-397, -337);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 57;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeat.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRepeat.ForeColor = System.Drawing.Color.White;
            this.lblRepeat.Location = new System.Drawing.Point(42, 255);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(52, 15);
            this.lblRepeat.TabIndex = 35;
            this.lblRepeat.Text = "Repeat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Title:";
            // 
            // tbReminderName
            // 
            this.tbReminderName.BackColor = System.Drawing.Color.DimGray;
            this.tbReminderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbReminderName.ForeColor = System.Drawing.Color.White;
            this.tbReminderName.Location = new System.Drawing.Point(107, 111);
            this.tbReminderName.Name = "tbReminderName";
            this.tbReminderName.Size = new System.Drawing.Size(234, 20);
            this.tbReminderName.TabIndex = 32;
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.Location = new System.Drawing.Point(107, 164);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(205, 20);
            this.dtpDate.TabIndex = 31;
            this.dtpDate.Value = new System.DateTime(2016, 9, 2, 0, 0, 0, 0);
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNote.ForeColor = System.Drawing.Color.White;
            this.lblNote.Location = new System.Drawing.Point(42, 275);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(38, 15);
            this.lblNote.TabIndex = 30;
            this.lblNote.Text = "Note:";
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.DimGray;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbNote.ForeColor = System.Drawing.Color.White;
            this.tbNote.Location = new System.Drawing.Point(110, 275);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(234, 68);
            this.tbNote.TabIndex = 29;
            this.tbNote.LocationChanged += new System.EventHandler(this.tbNote_LocationChanged);
            this.tbNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNote_KeyDown);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Location = new System.Drawing.Point(197, 347);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(67, 23);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tmrCheckReminder
            // 
            this.tmrCheckReminder.Interval = 30000;
            this.tmrCheckReminder.Tick += new System.EventHandler(this.tmrCheckReminder_Tick);
            // 
            // RemindMeIcon
            // 
            this.RemindMeIcon.BalloonTipText = "RemindMe";
            this.RemindMeIcon.ContextMenuStrip = this.RemindMeTrayIconMenuStrip;
            this.RemindMeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("RemindMeIcon.Icon")));
            this.RemindMeIcon.Text = "RemindMe";
            this.RemindMeIcon.Visible = true;
            this.RemindMeIcon.DoubleClick += new System.EventHandler(this.RemindMeIcon_DoubleClick);
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
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(463, 22);
            this.textBox1.TabIndex = 63;
            // 
            // tmrUpdateListview
            // 
            this.tmrUpdateListview.Interval = 60000;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::RemindMe.Properties.Resources.HelpIconSmall;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(196, 413);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 40);
            this.pictureBox3.TabIndex = 83;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "Support");
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pbCustomizePopup
            // 
            this.pbCustomizePopup.BackColor = System.Drawing.Color.Transparent;
            this.pbCustomizePopup.BackgroundImage = global::RemindMe.Properties.Resources.resize;
            this.pbCustomizePopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCustomizePopup.Location = new System.Drawing.Point(251, 415);
            this.pbCustomizePopup.Name = "pbCustomizePopup";
            this.pbCustomizePopup.Size = new System.Drawing.Size(49, 40);
            this.pbCustomizePopup.TabIndex = 82;
            this.pbCustomizePopup.TabStop = false;
            this.toolTip1.SetToolTip(this.pbCustomizePopup, "Resize RemindMe\'s Popup");
            this.pbCustomizePopup.Click += new System.EventHandler(this.pbCustomizePopup_Click);
            // 
            // pbImportExport
            // 
            this.pbImportExport.BackColor = System.Drawing.Color.Transparent;
            this.pbImportExport.BackgroundImage = global::RemindMe.Properties.Resources.import_good;
            this.pbImportExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImportExport.Location = new System.Drawing.Point(306, 413);
            this.pbImportExport.Name = "pbImportExport";
            this.pbImportExport.Size = new System.Drawing.Size(49, 40);
            this.pbImportExport.TabIndex = 81;
            this.pbImportExport.TabStop = false;
            this.toolTip1.SetToolTip(this.pbImportExport, "Backup,Import and Recover Reminders");
            this.pbImportExport.Click += new System.EventHandler(this.pbImportExport_Click);
            // 
            // pbWindows
            // 
            this.pbWindows.BackColor = System.Drawing.Color.Transparent;
            this.pbWindows.BackgroundImage = global::RemindMe.Properties.Resources._2windows2;
            this.pbWindows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbWindows.Location = new System.Drawing.Point(416, 412);
            this.pbWindows.Name = "pbWindows";
            this.pbWindows.Size = new System.Drawing.Size(49, 42);
            this.pbWindows.TabIndex = 77;
            this.pbWindows.TabStop = false;
            this.toolTip1.SetToolTip(this.pbWindows, "Manage window overlay & forms");
            this.pbWindows.Click += new System.EventHandler(this.pbWindows_Click);
            // 
            // pbMusic
            // 
            this.pbMusic.BackColor = System.Drawing.Color.Transparent;
            this.pbMusic.BackgroundImage = global::RemindMe.Properties.Resources.sound2;
            this.pbMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMusic.Location = new System.Drawing.Point(361, 412);
            this.pbMusic.Name = "pbMusic";
            this.pbMusic.Size = new System.Drawing.Size(49, 42);
            this.pbMusic.TabIndex = 76;
            this.pbMusic.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMusic, "Manage sound effects");
            this.pbMusic.Click += new System.EventHandler(this.pbMusic_Click);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // ReminderMenuStrip
            // 
            this.ReminderMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.ReminderMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReminderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.removeReminderToolStripMenuItem,
            this.permanentelyRemoveToolStripMenuItem,
            this.editReminderToolStripMenuItem,
            this.enableDisableReminderToolStripMenuItem,
            this.exportSelectedRemindersToolStripMenuItem});
            this.ReminderMenuStrip.Name = "ReminderMenuStrip";
            this.ReminderMenuStrip.ShowImageMargin = false;
            this.ReminderMenuStrip.Size = new System.Drawing.Size(230, 136);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewThisReminderNowToolStripMenuItem,
            this.previewThisReminderIn5SecondsToolStripMenuItem,
            this.previewThisReminderIn10SecondsToolStripMenuItem});
            this.previewToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
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
            // removeReminderToolStripMenuItem
            // 
            this.removeReminderToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.removeReminderToolStripMenuItem.Name = "removeReminderToolStripMenuItem";
            this.removeReminderToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.removeReminderToolStripMenuItem.Text = "Remove reminder";
            this.removeReminderToolStripMenuItem.Click += new System.EventHandler(this.removeReminderToolStripMenuItem_Click);
            // 
            // permanentelyRemoveToolStripMenuItem
            // 
            this.permanentelyRemoveToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.permanentelyRemoveToolStripMenuItem.Name = "permanentelyRemoveToolStripMenuItem";
            this.permanentelyRemoveToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.permanentelyRemoveToolStripMenuItem.Text = "Permanentely remove reminder";
            this.permanentelyRemoveToolStripMenuItem.Click += new System.EventHandler(this.permanentelyRemoveToolStripMenuItem_Click_1);
            // 
            // editReminderToolStripMenuItem
            // 
            this.editReminderToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.editReminderToolStripMenuItem.Name = "editReminderToolStripMenuItem";
            this.editReminderToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.editReminderToolStripMenuItem.Text = "Edit reminder";
            this.editReminderToolStripMenuItem.Click += new System.EventHandler(this.editReminderToolStripMenuItem_Click);
            // 
            // enableDisableReminderToolStripMenuItem
            // 
            this.enableDisableReminderToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.enableDisableReminderToolStripMenuItem.Name = "enableDisableReminderToolStripMenuItem";
            this.enableDisableReminderToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.enableDisableReminderToolStripMenuItem.Text = "Enable/Disable reminder";
            this.enableDisableReminderToolStripMenuItem.Click += new System.EventHandler(this.enableDisableReminderToolStripMenuItem_Click);
            // 
            // exportSelectedRemindersToolStripMenuItem
            // 
            this.exportSelectedRemindersToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.exportSelectedRemindersToolStripMenuItem.Name = "exportSelectedRemindersToolStripMenuItem";
            this.exportSelectedRemindersToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exportSelectedRemindersToolStripMenuItem.Text = "Export selected reminders";
            this.exportSelectedRemindersToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedRemindersToolStripMenuItem_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlSettings.Controls.Add(this.pictureBox3);
            this.pnlSettings.Controls.Add(this.pbCustomizePopup);
            this.pnlSettings.Controls.Add(this.pbImportExport);
            this.pnlSettings.Controls.Add(this.textBox2);
            this.pnlSettings.Controls.Add(this.btnBackFromSettings);
            this.pnlSettings.Controls.Add(this.pbWindows);
            this.pnlSettings.Controls.Add(this.pbMusic);
            this.pnlSettings.Controls.Add(this.pnlUserControls);
            this.pnlSettings.Controls.Add(this.pictureBox2);
            this.pnlSettings.Location = new System.Drawing.Point(1003, 23);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(475, 457);
            this.pnlSettings.TabIndex = 67;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(-4, 409);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(600, 3);
            this.textBox2.TabIndex = 80;
            // 
            // btnBackFromSettings
            // 
            this.btnBackFromSettings.BackgroundImage = global::RemindMe.Properties.Resources.back;
            this.btnBackFromSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackFromSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBackFromSettings.Location = new System.Drawing.Point(7, 418);
            this.btnBackFromSettings.Name = "btnBackFromSettings";
            this.btnBackFromSettings.Size = new System.Drawing.Size(53, 29);
            this.btnBackFromSettings.TabIndex = 79;
            this.btnBackFromSettings.Text = " ";
            this.btnBackFromSettings.UseVisualStyleBackColor = true;
            this.btnBackFromSettings.Click += new System.EventHandler(this.btnBackFromSettings_Click);
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserControls.Location = new System.Drawing.Point(2, 101);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(469, 297);
            this.pnlUserControls.TabIndex = 68;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(463, 97);
            this.pictureBox2.TabIndex = 67;
            this.pictureBox2.TabStop = false;
            // 
            // tmrAnimationScrollUp
            // 
            this.tmrAnimationScrollUp.Interval = 10;
            this.tmrAnimationScrollUp.Tick += new System.EventHandler(this.tmrAnimationScrollUp_Tick);
            // 
            // tmrAnimationScrollDown
            // 
            this.tmrAnimationScrollDown.Interval = 10;
            this.tmrAnimationScrollDown.Tick += new System.EventHandler(this.tmrAnimationScrollDown_Tick);
            // 
            // tmrMessageFormScrollUp
            // 
            this.tmrMessageFormScrollUp.Interval = 10;
            this.tmrMessageFormScrollUp.Tick += new System.EventHandler(this.tmrMessageFormScrollUp_Tick);
            // 
            // tmrMessageFormScrollDown
            // 
            this.tmrMessageFormScrollDown.Interval = 10;
            this.tmrMessageFormScrollDown.Tick += new System.EventHandler(this.tmrMessageFormScrollDown_Tick);
            // 
            // tmrAllowMail
            // 
            this.tmrAllowMail.Interval = 300000;
            this.tmrAllowMail.Tick += new System.EventHandler(this.tmrAllowMail_Tick);
            // 
            // AddDaysMenuStrip
            // 
            this.AddDaysMenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.AddDaysMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDaysMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMinutesToolStripMenuItem,
            this.addDaysToolStripMenuItem,
            this.addMonthsToolStripMenuItem,
            this.subtractDaysToolStripMenuItem,
            this.toolStripMenuItem1});
            this.AddDaysMenuStrip.Name = "ReminderMenuStrip";
            this.AddDaysMenuStrip.ShowImageMargin = false;
            this.AddDaysMenuStrip.Size = new System.Drawing.Size(217, 114);
            // 
            // addMinutesToolStripMenuItem
            // 
            this.addMinutesToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.addMinutesToolStripMenuItem.Name = "addMinutesToolStripMenuItem";
            this.addMinutesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.addMinutesToolStripMenuItem.Text = "Add Minutes (to current time)";
            this.addMinutesToolStripMenuItem.Click += new System.EventHandler(this.addMinutesToolStripMenuItem_Click);
            // 
            // addDaysToolStripMenuItem
            // 
            this.addDaysToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.addDaysToolStripMenuItem.Name = "addDaysToolStripMenuItem";
            this.addDaysToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.addDaysToolStripMenuItem.Text = "Add Days";
            this.addDaysToolStripMenuItem.Click += new System.EventHandler(this.addDaysToolStripMenuItem_Click);
            // 
            // addMonthsToolStripMenuItem
            // 
            this.addMonthsToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.addMonthsToolStripMenuItem.Name = "addMonthsToolStripMenuItem";
            this.addMonthsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.addMonthsToolStripMenuItem.Text = "Add Months";
            this.addMonthsToolStripMenuItem.Click += new System.EventHandler(this.addMonthsToolStripMenuItem_Click);
            // 
            // subtractDaysToolStripMenuItem
            // 
            this.subtractDaysToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.subtractDaysToolStripMenuItem.Name = "subtractDaysToolStripMenuItem";
            this.subtractDaysToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.subtractDaysToolStripMenuItem.Text = "Subtract Days";
            this.subtractDaysToolStripMenuItem.Click += new System.EventHandler(this.subtractDaysToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "Subtract Months";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 22);
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            // 
            // pbMinimizeApplication
            // 
            this.pbMinimizeApplication.BackColor = System.Drawing.Color.Black;
            this.pbMinimizeApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMinimizeApplication.BackgroundImage")));
            this.pbMinimizeApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMinimizeApplication.Location = new System.Drawing.Point(417, 0);
            this.pbMinimizeApplication.Name = "pbMinimizeApplication";
            this.pbMinimizeApplication.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizeApplication.TabIndex = 65;
            this.pbMinimizeApplication.TabStop = false;
            this.pbMinimizeApplication.Click += new System.EventHandler(this.pbMinimizeApplication_Click);
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Black;
            this.pbCloseApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCloseApplication.BackgroundImage")));
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(440, 0);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 64;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1581, 519);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlNewReminder);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RemindMe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            this.pnlNewReminder.ResumeLayout(false);
            this.pnlNewReminder.PerformLayout();
            this.pnlDayCheckBoxes.ResumeLayout(false);
            this.pnlDayCheckBoxes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEveryXDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWorkday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).EndInit();
            this.groupRepeatRadiobuttons.ResumeLayout(false);
            this.groupRepeatRadiobuttons.PerformLayout();
            this.RemindMeTrayIconMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomizePopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImportExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusic)).EndInit();
            this.ReminderMenuStrip.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.AddDaysMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAddReminder;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDate;
        public System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbReminderName;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.Button btnRemoveReminder;
        public System.Windows.Forms.Button btnEditReminder;
        public System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ColumnHeader chRepeat;
        public System.Windows.Forms.ComboBox cbEvery;
        private System.Windows.Forms.Timer tmrCheckReminder;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnDisableEnable;
        private System.Windows.Forms.ColumnHeader cbEnabled;
        public System.Windows.Forms.NotifyIcon RemindMeIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbEdit;
        private System.Windows.Forms.ContextMenuStrip RemindMeTrayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem showRemindMeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer tmrUpdateListview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cbSound;
        private System.Windows.Forms.Timer tmrMusic;
        private System.Windows.Forms.PictureBox pbExclamationDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbExclamationWorkday;
        private System.Windows.Forms.PictureBox pbExclamationTitle;
        public System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip ReminderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn5SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewThisReminderIn10SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDisableReminderToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Panel pnlNewReminder;
        public System.Windows.Forms.ListView lvReminders;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.GroupBox groupRepeatRadiobuttons;
        public System.Windows.Forms.RadioButton rbMonthly;
        public System.Windows.Forms.RadioButton rbDaily;
        public System.Windows.Forms.RadioButton rbNoRepeat;
        public System.Windows.Forms.DateTimePicker dtpTime;
        public System.Windows.Forms.RadioButton rbWorkDays;
        public System.Windows.Forms.PictureBox pbSettings;
        public System.Windows.Forms.Button btnPlaySound;
        public System.Windows.Forms.RadioButton rbEveryXCustom;
        public System.Windows.Forms.NumericUpDown numEveryXDays;
        public System.Windows.Forms.ComboBox cbEveryXCustom;
        public System.Windows.Forms.Panel pnlDayCheckBoxes;
        public System.Windows.Forms.CheckBox cbSunday;
        public System.Windows.Forms.CheckBox cbSaturday;
        public System.Windows.Forms.CheckBox cbFriday;
        public System.Windows.Forms.CheckBox cbThursday;
        public System.Windows.Forms.CheckBox cbWednesday;
        public System.Windows.Forms.CheckBox cbTuesday;
        public System.Windows.Forms.CheckBox cbMonday;
        public System.Windows.Forms.RadioButton rbMultipleDays;
        public System.Windows.Forms.Panel pnlUserControls;
        public System.Windows.Forms.PictureBox pbWindows;
        public System.Windows.Forms.PictureBox pbMusic;
        public System.Windows.Forms.Button btnBackFromSettings;
        public System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.Panel pnlSettings;
        public System.Windows.Forms.Label lblEvery;
        public System.Windows.Forms.CheckBox cbStickyForm;
        public System.Windows.Forms.ComboBox cbMonthlyDays;
        public System.Windows.Forms.Button btnRemoveMonthlyDay;
        public System.Windows.Forms.Button btnAddMonthlyDay;
        private System.Windows.Forms.Panel pnlPopup;
        private System.Windows.Forms.Timer tmrAnimationScrollUp;
        private System.Windows.Forms.Timer tmrAnimationScrollDown;
        public System.Windows.Forms.Button btnRemoveDate;
        public System.Windows.Forms.ComboBox cbMultipleDates;
        public System.Windows.Forms.Button btnAddDate;
        private System.Windows.Forms.Label lblAddedDates;
        public System.Windows.Forms.PictureBox pbImportExport;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedRemindersToolStripMenuItem;
        private System.Windows.Forms.Timer tmrMessageFormScrollUp;
        private System.Windows.Forms.Timer tmrMessageFormScrollDown;
        public System.Windows.Forms.PictureBox pbCustomizePopup;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer tmrAllowMail;
        private System.Windows.Forms.ToolStripMenuItem permanentelyRemoveToolStripMenuItem;
        public System.Windows.Forms.Button btnAddDays;
        private System.Windows.Forms.ContextMenuStrip AddDaysMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

