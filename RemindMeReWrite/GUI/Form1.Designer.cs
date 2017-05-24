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
            this.lblEveryXDays = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEveryXDays = new System.Windows.Forms.RadioButton();
            this.rbWorkDays = new System.Windows.Forms.RadioButton();
            this.rbNoRepeat = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReminderName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.cbDayBefore = new System.Windows.Forms.CheckBox();
            this.tmrCheckReminder = new System.Windows.Forms.Timer(this.components);
            this.RemindMeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemindMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tmrUpdateListview = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            this.pnlNewReminder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEveryXDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWorkday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(475, 406);
            this.pnlMain.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe;
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
            this.pbSettings.BackgroundImage = global::RemindMe.Properties.Resources.cog;
            this.pbSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSettings.Location = new System.Drawing.Point(433, 381);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(25, 24);
            this.pbSettings.TabIndex = 66;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableEnable.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnDisableEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisableEnable.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDisableEnable.ForeColor = System.Drawing.Color.Transparent;
            this.btnDisableEnable.Location = new System.Drawing.Point(324, 383);
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
            this.btnRemoveReminder.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnRemoveReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveReminder.Location = new System.Drawing.Point(100, 383);
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
            this.btnEditReminder.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnEditReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEditReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnEditReminder.Location = new System.Drawing.Point(224, 383);
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
            this.lvReminders.Size = new System.Drawing.Size(464, 281);
            this.lvReminders.TabIndex = 0;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;
            this.lvReminders.DoubleClick += new System.EventHandler(this.lvReminders_DoubleClick);
            this.lvReminders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReminders_KeyDown);
            // 
            // chName
            // 
            this.chName.Text = "Title";
            this.chName.Width = 200;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 80;
            // 
            // chRepeat
            // 
            this.chRepeat.Text = "Repeating";
            this.chRepeat.Width = 90;
            // 
            // cbEnabled
            // 
            this.cbEnabled.Text = "Enabled";
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.BackColor = System.Drawing.Color.Transparent;
            this.btnAddReminder.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnAddReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddReminder.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddReminder.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddReminder.Location = new System.Drawing.Point(3, 383);
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
            this.pnlNewReminder.Controls.Add(this.lblEveryXDays);
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
            this.pnlNewReminder.Controls.Add(this.groupBox1);
            this.pnlNewReminder.Controls.Add(this.label3);
            this.pnlNewReminder.Controls.Add(this.label2);
            this.pnlNewReminder.Controls.Add(this.label1);
            this.pnlNewReminder.Controls.Add(this.tbReminderName);
            this.pnlNewReminder.Controls.Add(this.dtpDate);
            this.pnlNewReminder.Controls.Add(this.lblNote);
            this.pnlNewReminder.Controls.Add(this.tbNote);
            this.pnlNewReminder.Controls.Add(this.btnBack);
            this.pnlNewReminder.Location = new System.Drawing.Point(530, 22);
            this.pnlNewReminder.Name = "pnlNewReminder";
            this.pnlNewReminder.Size = new System.Drawing.Size(467, 406);
            this.pnlNewReminder.TabIndex = 27;
            this.pnlNewReminder.Visible = false;
            // 
            // lblEveryXDays
            // 
            this.lblEveryXDays.AutoSize = true;
            this.lblEveryXDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEveryXDays.ForeColor = System.Drawing.Color.White;
            this.lblEveryXDays.Location = new System.Drawing.Point(182, 267);
            this.lblEveryXDays.Name = "lblEveryXDays";
            this.lblEveryXDays.Size = new System.Drawing.Size(34, 15);
            this.lblEveryXDays.TabIndex = 72;
            this.lblEveryXDays.Text = "Days";
            this.lblEveryXDays.Visible = false;
            // 
            // numEveryXDays
            // 
            this.numEveryXDays.BackColor = System.Drawing.Color.DimGray;
            this.numEveryXDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numEveryXDays.ForeColor = System.Drawing.Color.White;
            this.numEveryXDays.Location = new System.Drawing.Point(109, 266);
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
            // 
            // pbExclamationWorkday
            // 
            this.pbExclamationWorkday.BackgroundImage = global::RemindMe.Properties.Resources.exl;
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
            this.pbExclamationTitle.BackgroundImage = global::RemindMe.Properties.Resources.exl;
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
            this.pbExclamationDate.BackgroundImage = global::RemindMe.Properties.Resources.exl;
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
            this.btnPlaySound.BackgroundImage = global::RemindMe.Properties.Resources.resume;
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
            this.pbEdit.BackgroundImage = global::RemindMe.Properties.Resources.Create_new;
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
            this.dtpTime.Size = new System.Drawing.Size(234, 20);
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
            this.cbEvery.Location = new System.Drawing.Point(107, 265);
            this.cbEvery.Name = "cbEvery";
            this.cbEvery.Size = new System.Drawing.Size(234, 21);
            this.cbEvery.TabIndex = 58;
            this.cbEvery.Visible = false;
            this.cbEvery.SelectedIndexChanged += new System.EventHandler(this.cbEvery_SelectedIndexChanged);
            // 
            // lblEvery
            // 
            this.lblEvery.AutoSize = true;
            this.lblEvery.BackColor = System.Drawing.Color.Transparent;
            this.lblEvery.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEvery.ForeColor = System.Drawing.Color.White;
            this.lblEvery.Location = new System.Drawing.Point(42, 266);
            this.lblEvery.Name = "lblEvery";
            this.lblEvery.Size = new System.Drawing.Size(42, 15);
            this.lblEvery.TabIndex = 57;
            this.lblEvery.Text = "Every:";
            this.lblEvery.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Location = new System.Drawing.Point(107, 337);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(106, 23);
            this.btnConfirm.TabIndex = 30;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEveryXDays);
            this.groupBox1.Controls.Add(this.rbWorkDays);
            this.groupBox1.Controls.Add(this.rbNoRepeat);
            this.groupBox1.Controls.Add(this.rbWeekly);
            this.groupBox1.Controls.Add(this.rbMonthly);
            this.groupBox1.Controls.Add(this.rbDaily);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(107, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 53);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // rbEveryXDays
            // 
            this.rbEveryXDays.AutoSize = true;
            this.rbEveryXDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbEveryXDays.ForeColor = System.Drawing.Color.White;
            this.rbEveryXDays.Location = new System.Drawing.Point(78, 30);
            this.rbEveryXDays.Name = "rbEveryXDays";
            this.rbEveryXDays.Size = new System.Drawing.Size(87, 18);
            this.rbEveryXDays.TabIndex = 63;
            this.rbEveryXDays.Text = "Every x days";
            this.rbEveryXDays.UseVisualStyleBackColor = true;
            this.rbEveryXDays.CheckedChanged += new System.EventHandler(this.rbEveryXDays_CheckedChanged);
            // 
            // rbWorkDays
            // 
            this.rbWorkDays.AutoSize = true;
            this.rbWorkDays.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbWorkDays.ForeColor = System.Drawing.Color.White;
            this.rbWorkDays.Location = new System.Drawing.Point(78, 11);
            this.rbWorkDays.Name = "rbWorkDays";
            this.rbWorkDays.Size = new System.Drawing.Size(78, 18);
            this.rbWorkDays.TabIndex = 62;
            this.rbWorkDays.Text = "Work days";
            this.rbWorkDays.UseVisualStyleBackColor = true;
            this.rbWorkDays.CheckedChanged += new System.EventHandler(this.rbWorkDays_CheckedChanged);
            // 
            // rbNoRepeat
            // 
            this.rbNoRepeat.AutoSize = true;
            this.rbNoRepeat.Checked = true;
            this.rbNoRepeat.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbNoRepeat.ForeColor = System.Drawing.Color.White;
            this.rbNoRepeat.Location = new System.Drawing.Point(165, 30);
            this.rbNoRepeat.Name = "rbNoRepeat";
            this.rbNoRepeat.Size = new System.Drawing.Size(51, 18);
            this.rbNoRepeat.TabIndex = 61;
            this.rbNoRepeat.TabStop = true;
            this.rbNoRepeat.Text = "None";
            this.rbNoRepeat.UseVisualStyleBackColor = true;
            this.rbNoRepeat.CheckedChanged += new System.EventHandler(this.rbNoRepeat_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.rbWeekly.ForeColor = System.Drawing.Color.White;
            this.rbWeekly.Location = new System.Drawing.Point(165, 11);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(61, 18);
            this.rbWeekly.TabIndex = 60;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbWeekly_CheckedChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Repeat:";
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
            this.tbReminderName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbReminderName_KeyUp);
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.Location = new System.Drawing.Point(107, 164);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(234, 20);
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
            this.lblNote.Location = new System.Drawing.Point(42, 240);
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
            this.tbNote.Location = new System.Drawing.Point(107, 266);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(234, 68);
            this.tbNote.TabIndex = 29;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Location = new System.Drawing.Point(214, 337);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(67, 23);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cbDayBefore
            // 
            this.cbDayBefore.AutoSize = true;
            this.cbDayBefore.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold);
            this.cbDayBefore.ForeColor = System.Drawing.Color.White;
            this.cbDayBefore.Location = new System.Drawing.Point(856, 461);
            this.cbDayBefore.Name = "cbDayBefore";
            this.cbDayBefore.Size = new System.Drawing.Size(157, 19);
            this.cbDayBefore.TabIndex = 61;
            this.cbDayBefore.Text = "Remind the day before";
            this.cbDayBefore.UseVisualStyleBackColor = true;
            this.cbDayBefore.Visible = false;
            // 
            // tmrCheckReminder
            // 
            this.tmrCheckReminder.Interval = 30000;
            this.tmrCheckReminder.Tick += new System.EventHandler(this.tmrCheckReminder_Tick);
            // 
            // RemindMeIcon
            // 
            this.RemindMeIcon.BalloonTipText = "RemindMe";
            this.RemindMeIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.RemindMeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("RemindMeIcon.Icon")));
            this.RemindMeIcon.Text = "RemindMe";
            this.RemindMeIcon.Visible = true;
            this.RemindMeIcon.DoubleClick += new System.EventHandler(this.RemindMeIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit,
            this.showRemindMeToolStripMenuItem,
            this.tsSettings});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 70);
            this.contextMenuStrip1.Text = "contextmenustrip";
            // 
            // tsExit
            // 
            this.tsExit.Image = global::RemindMe.Properties.Resources.bin;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(164, 22);
            this.tsExit.Text = "Exit RemindMe";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // showRemindMeToolStripMenuItem
            // 
            this.showRemindMeToolStripMenuItem.Image = global::RemindMe.Properties.Resources.clock2;
            this.showRemindMeToolStripMenuItem.Name = "showRemindMeToolStripMenuItem";
            this.showRemindMeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showRemindMeToolStripMenuItem.Text = "Show RemindMe";
            this.showRemindMeToolStripMenuItem.Click += new System.EventHandler(this.showRemindMeToolStripMenuItem_Click);
            // 
            // tsSettings
            // 
            this.tsSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsSettings.Image = global::RemindMe.Properties.Resources.cog;
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.Size = new System.Drawing.Size(164, 22);
            this.tsSettings.Text = "Settings";
            this.tsSettings.Click += new System.EventHandler(this.tsSettings_Click);
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
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.BackgroundImage = global::RemindMe.Properties.Resources.clock21;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 22);
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pbMinimizeApplication
            // 
            this.pbMinimizeApplication.BackColor = System.Drawing.Color.Black;
            this.pbMinimizeApplication.BackgroundImage = global::RemindMe.Properties.Resources.min;
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
            this.pbCloseApplication.BackgroundImage = global::RemindMe.Properties.Resources.redx;
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
            this.ClientSize = new System.Drawing.Size(1018, 443);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbDayBefore);
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
            ((System.ComponentModel.ISupportInitialize)(this.numEveryXDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWorkday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAddReminder;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlNewReminder;
        private System.Windows.Forms.ListView lvReminders;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDate;
        public System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbReminderName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.Button btnRemoveReminder;
        public System.Windows.Forms.Button btnEditReminder;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbNoRepeat;
        public System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ColumnHeader chRepeat;
        private System.Windows.Forms.Label lblEvery;
        public System.Windows.Forms.ComboBox cbEvery;
        private System.Windows.Forms.Timer tmrCheckReminder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTime;
        public System.Windows.Forms.Button btnDisableEnable;
        private System.Windows.Forms.ColumnHeader cbEnabled;
        public System.Windows.Forms.NotifyIcon RemindMeIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbEdit;
        private System.Windows.Forms.RadioButton rbWorkDays;
        private System.Windows.Forms.CheckBox cbDayBefore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem showRemindMeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem tsSettings;
        private System.Windows.Forms.Timer tmrUpdateListview;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cbSound;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Timer tmrMusic;
        private System.Windows.Forms.PictureBox pbExclamationDate;
        private System.Windows.Forms.PictureBox pbExclamationTitle;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbExclamationWorkday;
        private System.Windows.Forms.RadioButton rbEveryXDays;
        private System.Windows.Forms.NumericUpDown numEveryXDays;
        private System.Windows.Forms.Label lblEveryXDays;
    }
}

