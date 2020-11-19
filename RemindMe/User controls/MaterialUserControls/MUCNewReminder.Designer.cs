namespace RemindMe
{
    partial class MUCNewReminder
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.groupRepeatRadiobuttons = new System.Windows.Forms.GroupBox();
            this.pnlDayCheckBoxes = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.pnlUpdateTime = new System.Windows.Forms.Panel();
            this.tmrCheckbox = new System.Windows.Forms.Timer(this.components);
            this.pnlMarkupButtons = new System.Windows.Forms.Panel();
            this.cbEvery = new MaterialSkin.Controls.MaterialComboBox();
            this.cbEveryXCustom = new MaterialSkin.Controls.MaterialComboBox();
            this.cbMonthlyDays = new MaterialSkin.Controls.MaterialComboBox();
            this.cbMultipleDates = new MaterialSkin.Controls.MaterialComboBox();
            this.cbSound = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAddMonthlyDay = new MaterialSkin.Controls.MaterialButton();
            this.numEveryXDays = new MaterialSkin.Controls.MaterialTextBox();
            this.disableRightclick = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.swUpdateTime = new MaterialSkin.Controls.MaterialSwitch();
            this.btnRemoveMonthlyDay = new MaterialSkin.Controls.MaterialButton();
            this.cbSunday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbThursday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbSaturday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbFriday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbWednesday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbTuesday = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbMonday = new MaterialSkin.Controls.MaterialCheckbox();
            this.tbNote = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.rbNoRepeat = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbEveryXCustom = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbMonthly = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbMultipleDays = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbWorkDays = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbDaily = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnAddDate = new MaterialSkin.Controls.MaterialButton();
            this.btnAddDays = new MaterialSkin.Controls.MaterialButton();
            this.tbReminderName = new MaterialSkin.Controls.MaterialTextBox();
            this.AddDaysMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.addMinutestoCurrentTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTimeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImage = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnStrikethrough = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnUnderline = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnItalic = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnBold = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnAdvancedReminder = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.btnBack = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveDate = new MaterialSkin.Controls.MaterialButton();
            this.btnPlaySound = new MaterialSkin.Controls.MaterialButton();
            this.groupRepeatRadiobuttons.SuspendLayout();
            this.pnlDayCheckBoxes.SuspendLayout();
            this.pnlUpdateTime.SuspendLayout();
            this.pnlMarkupButtons.SuspendLayout();
            this.AddDaysMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStrikethrough)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUnderline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnItalic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBold)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Century Gothic", 11.5F);
            this.dtpDate.Location = new System.Drawing.Point(93, 88);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(242, 26);
            this.dtpDate.TabIndex = 112;
            // 
            // dtpTime
            // 
            this.dtpTime.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTime.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Font = new System.Drawing.Font("Century Gothic", 11.5F);
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(341, 88);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(297, 26);
            this.dtpTime.TabIndex = 111;
            this.dtpTime.Value = new System.DateTime(2016, 9, 4, 12, 0, 0, 0);
            // 
            // groupRepeatRadiobuttons
            // 
            this.groupRepeatRadiobuttons.Controls.Add(this.rbNoRepeat);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbEveryXCustom);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbMonthly);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbMultipleDays);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbWorkDays);
            this.groupRepeatRadiobuttons.Controls.Add(this.rbDaily);
            this.groupRepeatRadiobuttons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupRepeatRadiobuttons.Location = new System.Drawing.Point(93, 175);
            this.groupRepeatRadiobuttons.Name = "groupRepeatRadiobuttons";
            this.groupRepeatRadiobuttons.Size = new System.Drawing.Size(545, 93);
            this.groupRepeatRadiobuttons.TabIndex = 118;
            this.groupRepeatRadiobuttons.TabStop = false;
            this.groupRepeatRadiobuttons.LocationChanged += new System.EventHandler(this.groupRepeatRadiobuttons_LocationChanged);
            // 
            // pnlDayCheckBoxes
            // 
            this.pnlDayCheckBoxes.Controls.Add(this.cbSunday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbThursday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbSaturday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbFriday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbWednesday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbTuesday);
            this.pnlDayCheckBoxes.Controls.Add(this.cbMonday);
            this.pnlDayCheckBoxes.Location = new System.Drawing.Point(96, 274);
            this.pnlDayCheckBoxes.Name = "pnlDayCheckBoxes";
            this.pnlDayCheckBoxes.Size = new System.Drawing.Size(542, 75);
            this.pnlDayCheckBoxes.TabIndex = 120;
            this.pnlDayCheckBoxes.Visible = false;
            this.pnlDayCheckBoxes.VisibleChanged += new System.EventHandler(this.pnlDayCheckBoxes_VisibleChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tmrMusic
            // 
            this.tmrMusic.Interval = 5000;
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick_1);
            // 
            // pnlUpdateTime
            // 
            this.pnlUpdateTime.Controls.Add(this.swUpdateTime);
            this.pnlUpdateTime.Location = new System.Drawing.Point(97, 403);
            this.pnlUpdateTime.Name = "pnlUpdateTime";
            this.pnlUpdateTime.Size = new System.Drawing.Size(238, 39);
            this.pnlUpdateTime.TabIndex = 128;
            this.pnlUpdateTime.VisibleChanged += new System.EventHandler(this.pnlUpdateTime_VisibleChanged);
            // 
            // tmrCheckbox
            // 
            this.tmrCheckbox.Interval = 350;
            this.tmrCheckbox.Tick += new System.EventHandler(this.tmrCheckbox_Tick);
            // 
            // pnlMarkupButtons
            // 
            this.pnlMarkupButtons.Controls.Add(this.btnImage);
            this.pnlMarkupButtons.Controls.Add(this.btnStrikethrough);
            this.pnlMarkupButtons.Controls.Add(this.btnUnderline);
            this.pnlMarkupButtons.Controls.Add(this.btnItalic);
            this.pnlMarkupButtons.Controls.Add(this.btnBold);
            this.pnlMarkupButtons.Location = new System.Drawing.Point(623, 274);
            this.pnlMarkupButtons.Name = "pnlMarkupButtons";
            this.pnlMarkupButtons.Size = new System.Drawing.Size(44, 91);
            this.pnlMarkupButtons.TabIndex = 134;
            // 
            // cbEvery
            // 
            this.cbEvery.AutoResize = false;
            this.cbEvery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbEvery.Depth = 0;
            this.cbEvery.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbEvery.DropDownHeight = 118;
            this.cbEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvery.DropDownWidth = 121;
            this.cbEvery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbEvery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbEvery.FormattingEnabled = true;
            this.cbEvery.IntegralHeight = false;
            this.cbEvery.ItemHeight = 29;
            this.cbEvery.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbEvery.Location = new System.Drawing.Point(97, 266);
            this.cbEvery.MaxDropDownItems = 4;
            this.cbEvery.MouseState = MaterialSkin.MouseState.OUT;
            this.cbEvery.Name = "cbEvery";
            this.cbEvery.Size = new System.Drawing.Size(121, 35);
            this.cbEvery.TabIndex = 131;
            this.cbEvery.UseTallSize = false;
            this.cbEvery.Visible = false;
            this.cbEvery.VisibleChanged += new System.EventHandler(this.cbEvery_VisibleChanged);
            // 
            // cbEveryXCustom
            // 
            this.cbEveryXCustom.AutoResize = false;
            this.cbEveryXCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbEveryXCustom.Depth = 0;
            this.cbEveryXCustom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbEveryXCustom.DropDownHeight = 118;
            this.cbEveryXCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEveryXCustom.DropDownWidth = 121;
            this.cbEveryXCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbEveryXCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbEveryXCustom.FormattingEnabled = true;
            this.cbEveryXCustom.IntegralHeight = false;
            this.cbEveryXCustom.ItemHeight = 29;
            this.cbEveryXCustom.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months"});
            this.cbEveryXCustom.Location = new System.Drawing.Point(155, 266);
            this.cbEveryXCustom.MaxDropDownItems = 4;
            this.cbEveryXCustom.MouseState = MaterialSkin.MouseState.OUT;
            this.cbEveryXCustom.Name = "cbEveryXCustom";
            this.cbEveryXCustom.Size = new System.Drawing.Size(103, 35);
            this.cbEveryXCustom.TabIndex = 133;
            this.cbEveryXCustom.UseTallSize = false;
            this.cbEveryXCustom.Visible = false;
            this.cbEveryXCustom.SelectedIndexChanged += new System.EventHandler(this.cbEveryXCustom_SelectedIndexChanged);
            this.cbEveryXCustom.TextChanged += new System.EventHandler(this.cbEveryXCustom_TextChanged);
            // 
            // cbMonthlyDays
            // 
            this.cbMonthlyDays.AutoResize = false;
            this.cbMonthlyDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbMonthlyDays.Depth = 0;
            this.cbMonthlyDays.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbMonthlyDays.DropDownHeight = 118;
            this.cbMonthlyDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonthlyDays.DropDownWidth = 121;
            this.cbMonthlyDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbMonthlyDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbMonthlyDays.FormattingEnabled = true;
            this.cbMonthlyDays.IntegralHeight = false;
            this.cbMonthlyDays.ItemHeight = 29;
            this.cbMonthlyDays.Location = new System.Drawing.Point(304, 271);
            this.cbMonthlyDays.MaxDropDownItems = 4;
            this.cbMonthlyDays.MouseState = MaterialSkin.MouseState.OUT;
            this.cbMonthlyDays.Name = "cbMonthlyDays";
            this.cbMonthlyDays.Size = new System.Drawing.Size(121, 35);
            this.cbMonthlyDays.TabIndex = 132;
            this.cbMonthlyDays.UseTallSize = false;
            this.cbMonthlyDays.Visible = false;
            // 
            // cbMultipleDates
            // 
            this.cbMultipleDates.AutoResize = false;
            this.cbMultipleDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbMultipleDates.Depth = 0;
            this.cbMultipleDates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbMultipleDates.DropDownHeight = 174;
            this.cbMultipleDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMultipleDates.DropDownWidth = 121;
            this.cbMultipleDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbMultipleDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbMultipleDates.FormattingEnabled = true;
            this.cbMultipleDates.Hint = "Currently Added dates (\"+\" button)";
            this.cbMultipleDates.IntegralHeight = false;
            this.cbMultipleDates.ItemHeight = 43;
            this.cbMultipleDates.Location = new System.Drawing.Point(93, 120);
            this.cbMultipleDates.MaxDropDownItems = 4;
            this.cbMultipleDates.MouseState = MaterialSkin.MouseState.OUT;
            this.cbMultipleDates.Name = "cbMultipleDates";
            this.cbMultipleDates.Size = new System.Drawing.Size(545, 49);
            this.cbMultipleDates.TabIndex = 130;
            this.cbMultipleDates.VisibleChanged += new System.EventHandler(this.cbMultipleDates_VisibleChanged);
            // 
            // cbSound
            // 
            this.cbSound.AutoResize = false;
            this.cbSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbSound.Depth = 0;
            this.cbSound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbSound.DropDownHeight = 174;
            this.cbSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSound.DropDownWidth = 121;
            this.cbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSound.FormattingEnabled = true;
            this.cbSound.Hint = "Select a sound effect";
            this.cbSound.IntegralHeight = false;
            this.cbSound.ItemHeight = 43;
            this.cbSound.Location = new System.Drawing.Point(341, 32);
            this.cbSound.MaxDropDownItems = 4;
            this.cbSound.MouseState = MaterialSkin.MouseState.OUT;
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(297, 49);
            this.cbSound.TabIndex = 129;
            this.cbSound.SelectedIndexChanged += new System.EventHandler(this.cbSound_SelectedIndexChanged);
            // 
            // btnAddMonthlyDay
            // 
            this.btnAddMonthlyDay.AutoSize = false;
            this.btnAddMonthlyDay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddMonthlyDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMonthlyDay.Depth = 0;
            this.btnAddMonthlyDay.DrawShadows = true;
            this.btnAddMonthlyDay.HighEmphasis = true;
            this.btnAddMonthlyDay.Icon = null;
            this.btnAddMonthlyDay.Location = new System.Drawing.Point(224, 279);
            this.btnAddMonthlyDay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddMonthlyDay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddMonthlyDay.Name = "btnAddMonthlyDay";
            this.btnAddMonthlyDay.Size = new System.Drawing.Size(34, 31);
            this.btnAddMonthlyDay.TabIndex = 122;
            this.btnAddMonthlyDay.Text = "+";
            this.btnAddMonthlyDay.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddMonthlyDay.UseAccentColor = false;
            this.btnAddMonthlyDay.UseVisualStyleBackColor = true;
            this.btnAddMonthlyDay.Visible = false;
            this.btnAddMonthlyDay.Click += new System.EventHandler(this.btnAddMonthlyDay_Click);
            // 
            // numEveryXDays
            // 
            this.numEveryXDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numEveryXDays.ContextMenuStrip = this.disableRightclick;
            this.numEveryXDays.Depth = 0;
            this.numEveryXDays.Font = new System.Drawing.Font("Roboto", 12F);
            this.numEveryXDays.Hint = "1";
            this.numEveryXDays.Location = new System.Drawing.Point(96, 265);
            this.numEveryXDays.MaxLength = 50;
            this.numEveryXDays.MouseState = MaterialSkin.MouseState.OUT;
            this.numEveryXDays.Multiline = false;
            this.numEveryXDays.Name = "numEveryXDays";
            this.numEveryXDays.Size = new System.Drawing.Size(52, 36);
            this.numEveryXDays.TabIndex = 125;
            this.numEveryXDays.Text = "";
            this.numEveryXDays.UseTallSize = false;
            this.numEveryXDays.Visible = false;
            this.numEveryXDays.VisibleChanged += new System.EventHandler(this.numEveryXDays_VisibleChanged);
            // 
            // disableRightclick
            // 
            this.disableRightclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.disableRightclick.Depth = 0;
            this.disableRightclick.MouseState = MaterialSkin.MouseState.HOVER;
            this.disableRightclick.Name = "disableRightclick";
            this.disableRightclick.Size = new System.Drawing.Size(61, 4);
            // 
            // swUpdateTime
            // 
            this.swUpdateTime.AutoSize = true;
            this.swUpdateTime.Depth = 0;
            this.swUpdateTime.Location = new System.Drawing.Point(0, 2);
            this.swUpdateTime.Margin = new System.Windows.Forms.Padding(0);
            this.swUpdateTime.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swUpdateTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.swUpdateTime.Name = "swUpdateTime";
            this.swUpdateTime.Ripple = true;
            this.swUpdateTime.Size = new System.Drawing.Size(209, 37);
            this.swUpdateTime.TabIndex = 121;
            this.swUpdateTime.Text = "Update reminder time";
            this.swUpdateTime.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMonthlyDay
            // 
            this.btnRemoveMonthlyDay.AutoSize = false;
            this.btnRemoveMonthlyDay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveMonthlyDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoveMonthlyDay.Depth = 0;
            this.btnRemoveMonthlyDay.DrawShadows = true;
            this.btnRemoveMonthlyDay.HighEmphasis = true;
            this.btnRemoveMonthlyDay.Icon = null;
            this.btnRemoveMonthlyDay.Location = new System.Drawing.Point(261, 279);
            this.btnRemoveMonthlyDay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveMonthlyDay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveMonthlyDay.Name = "btnRemoveMonthlyDay";
            this.btnRemoveMonthlyDay.Size = new System.Drawing.Size(34, 31);
            this.btnRemoveMonthlyDay.TabIndex = 123;
            this.btnRemoveMonthlyDay.Text = "-";
            this.btnRemoveMonthlyDay.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveMonthlyDay.UseAccentColor = false;
            this.btnRemoveMonthlyDay.UseVisualStyleBackColor = true;
            this.btnRemoveMonthlyDay.Visible = false;
            this.btnRemoveMonthlyDay.Click += new System.EventHandler(this.btnRemoveMonthlyDay_Click);
            // 
            // cbSunday
            // 
            this.cbSunday.AutoSize = true;
            this.cbSunday.Depth = 0;
            this.cbSunday.Location = new System.Drawing.Point(240, 42);
            this.cbSunday.Margin = new System.Windows.Forms.Padding(0);
            this.cbSunday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbSunday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbSunday.Name = "cbSunday";
            this.cbSunday.Ripple = true;
            this.cbSunday.Size = new System.Drawing.Size(89, 37);
            this.cbSunday.TabIndex = 6;
            this.cbSunday.Text = "Sunday";
            this.cbSunday.UseVisualStyleBackColor = true;
            // 
            // cbThursday
            // 
            this.cbThursday.AutoSize = true;
            this.cbThursday.Depth = 0;
            this.cbThursday.Location = new System.Drawing.Point(358, 5);
            this.cbThursday.Margin = new System.Windows.Forms.Padding(0);
            this.cbThursday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbThursday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbThursday.Name = "cbThursday";
            this.cbThursday.Ripple = true;
            this.cbThursday.Size = new System.Drawing.Size(102, 37);
            this.cbThursday.TabIndex = 5;
            this.cbThursday.Text = "Thursday";
            this.cbThursday.UseVisualStyleBackColor = true;
            // 
            // cbSaturday
            // 
            this.cbSaturday.AutoSize = true;
            this.cbSaturday.Depth = 0;
            this.cbSaturday.Location = new System.Drawing.Point(122, 42);
            this.cbSaturday.Margin = new System.Windows.Forms.Padding(0);
            this.cbSaturday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbSaturday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbSaturday.Name = "cbSaturday";
            this.cbSaturday.Ripple = true;
            this.cbSaturday.Size = new System.Drawing.Size(99, 37);
            this.cbSaturday.TabIndex = 4;
            this.cbSaturday.Text = "Saturday";
            this.cbSaturday.UseVisualStyleBackColor = true;
            // 
            // cbFriday
            // 
            this.cbFriday.AutoSize = true;
            this.cbFriday.Depth = 0;
            this.cbFriday.Location = new System.Drawing.Point(5, 42);
            this.cbFriday.Margin = new System.Windows.Forms.Padding(0);
            this.cbFriday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbFriday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbFriday.Name = "cbFriday";
            this.cbFriday.Ripple = true;
            this.cbFriday.Size = new System.Drawing.Size(79, 37);
            this.cbFriday.TabIndex = 3;
            this.cbFriday.Text = "Friday";
            this.cbFriday.UseVisualStyleBackColor = true;
            // 
            // cbWednesday
            // 
            this.cbWednesday.AutoSize = true;
            this.cbWednesday.Depth = 0;
            this.cbWednesday.Location = new System.Drawing.Point(240, 5);
            this.cbWednesday.Margin = new System.Windows.Forms.Padding(0);
            this.cbWednesday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbWednesday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbWednesday.Name = "cbWednesday";
            this.cbWednesday.Ripple = true;
            this.cbWednesday.Size = new System.Drawing.Size(117, 37);
            this.cbWednesday.TabIndex = 2;
            this.cbWednesday.Text = "Wednesday";
            this.cbWednesday.UseVisualStyleBackColor = true;
            // 
            // cbTuesday
            // 
            this.cbTuesday.AutoSize = true;
            this.cbTuesday.Depth = 0;
            this.cbTuesday.Location = new System.Drawing.Point(122, 5);
            this.cbTuesday.Margin = new System.Windows.Forms.Padding(0);
            this.cbTuesday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbTuesday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbTuesday.Name = "cbTuesday";
            this.cbTuesday.Ripple = true;
            this.cbTuesday.Size = new System.Drawing.Size(96, 37);
            this.cbTuesday.TabIndex = 1;
            this.cbTuesday.Text = "Tuesday";
            this.cbTuesday.UseVisualStyleBackColor = true;
            // 
            // cbMonday
            // 
            this.cbMonday.AutoSize = true;
            this.cbMonday.Depth = 0;
            this.cbMonday.Location = new System.Drawing.Point(5, 5);
            this.cbMonday.Margin = new System.Windows.Forms.Padding(0);
            this.cbMonday.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbMonday.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbMonday.Name = "cbMonday";
            this.cbMonday.Ripple = true;
            this.cbMonday.Size = new System.Drawing.Size(93, 37);
            this.cbMonday.TabIndex = 0;
            this.cbMonday.Text = "Monday";
            this.cbMonday.UseVisualStyleBackColor = true;
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNote.Depth = 0;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbNote.Hint = "Describe what this reminder is about here";
            this.tbNote.Location = new System.Drawing.Point(96, 274);
            this.tbNote.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbNote.Size = new System.Drawing.Size(521, 91);
            this.tbNote.TabIndex = 119;
            this.tbNote.Text = "";
            this.tbNote.LocationChanged += new System.EventHandler(this.tbNote_LocationChanged);
            this.tbNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNote_KeyDown);
            // 
            // rbNoRepeat
            // 
            this.rbNoRepeat.AutoSize = true;
            this.rbNoRepeat.Checked = true;
            this.rbNoRepeat.Depth = 0;
            this.rbNoRepeat.Location = new System.Drawing.Point(246, 53);
            this.rbNoRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.rbNoRepeat.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbNoRepeat.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbNoRepeat.Name = "rbNoRepeat";
            this.rbNoRepeat.Ripple = true;
            this.rbNoRepeat.Size = new System.Drawing.Size(112, 37);
            this.rbNoRepeat.TabIndex = 5;
            this.rbNoRepeat.TabStop = true;
            this.rbNoRepeat.Text = "Set date(s)";
            this.rbNoRepeat.UseVisualStyleBackColor = true;
            this.rbNoRepeat.CheckedChanged += new System.EventHandler(this.rbNoRepeat_CheckedChanged);
            // 
            // rbEveryXCustom
            // 
            this.rbEveryXCustom.AutoSize = true;
            this.rbEveryXCustom.Depth = 0;
            this.rbEveryXCustom.Location = new System.Drawing.Point(123, 53);
            this.rbEveryXCustom.Margin = new System.Windows.Forms.Padding(0);
            this.rbEveryXCustom.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbEveryXCustom.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbEveryXCustom.Name = "rbEveryXCustom";
            this.rbEveryXCustom.Ripple = true;
            this.rbEveryXCustom.Size = new System.Drawing.Size(90, 37);
            this.rbEveryXCustom.TabIndex = 4;
            this.rbEveryXCustom.TabStop = true;
            this.rbEveryXCustom.Text = "Custom";
            this.rbEveryXCustom.UseVisualStyleBackColor = true;
            this.rbEveryXCustom.CheckedChanged += new System.EventHandler(this.rbEveryXCustom_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Depth = 0;
            this.rbMonthly.Location = new System.Drawing.Point(3, 53);
            this.rbMonthly.Margin = new System.Windows.Forms.Padding(0);
            this.rbMonthly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbMonthly.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Ripple = true;
            this.rbMonthly.Size = new System.Drawing.Size(93, 37);
            this.rbMonthly.TabIndex = 3;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbMonthly_CheckedChanged);
            // 
            // rbMultipleDays
            // 
            this.rbMultipleDays.AutoSize = true;
            this.rbMultipleDays.Depth = 0;
            this.rbMultipleDays.Location = new System.Drawing.Point(246, 16);
            this.rbMultipleDays.Margin = new System.Windows.Forms.Padding(0);
            this.rbMultipleDays.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbMultipleDays.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbMultipleDays.Name = "rbMultipleDays";
            this.rbMultipleDays.Ripple = true;
            this.rbMultipleDays.Size = new System.Drawing.Size(107, 37);
            this.rbMultipleDays.TabIndex = 2;
            this.rbMultipleDays.TabStop = true;
            this.rbMultipleDays.Text = "Weekdays";
            this.rbMultipleDays.UseVisualStyleBackColor = true;
            this.rbMultipleDays.CheckedChanged += new System.EventHandler(this.rbMultipleDays_CheckedChanged);
            // 
            // rbWorkDays
            // 
            this.rbWorkDays.AutoSize = true;
            this.rbWorkDays.Depth = 0;
            this.rbWorkDays.Location = new System.Drawing.Point(123, 16);
            this.rbWorkDays.Margin = new System.Windows.Forms.Padding(0);
            this.rbWorkDays.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbWorkDays.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbWorkDays.Name = "rbWorkDays";
            this.rbWorkDays.Ripple = true;
            this.rbWorkDays.Size = new System.Drawing.Size(109, 37);
            this.rbWorkDays.TabIndex = 1;
            this.rbWorkDays.TabStop = true;
            this.rbWorkDays.Text = "Work days";
            this.rbWorkDays.UseVisualStyleBackColor = true;
            this.rbWorkDays.CheckedChanged += new System.EventHandler(this.rbWorkDays_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Depth = 0;
            this.rbDaily.Location = new System.Drawing.Point(3, 16);
            this.rbDaily.Margin = new System.Windows.Forms.Padding(0);
            this.rbDaily.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbDaily.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Ripple = true;
            this.rbDaily.Size = new System.Drawing.Size(71, 37);
            this.rbDaily.TabIndex = 0;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // btnAddDate
            // 
            this.btnAddDate.AutoSize = false;
            this.btnAddDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddDate.Depth = 0;
            this.btnAddDate.DrawShadows = true;
            this.btnAddDate.HighEmphasis = true;
            this.btnAddDate.Icon = null;
            this.btnAddDate.Location = new System.Drawing.Point(645, 88);
            this.btnAddDate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(22, 26);
            this.btnAddDate.TabIndex = 115;
            this.btnAddDate.Text = "+";
            this.btnAddDate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddDate.UseAccentColor = false;
            this.btnAddDate.UseVisualStyleBackColor = true;
            this.btnAddDate.VisibleChanged += new System.EventHandler(this.btnAddDate_VisibleChanged);
            this.btnAddDate.Click += new System.EventHandler(this.btnAddDate_Click);
            // 
            // btnAddDays
            // 
            this.btnAddDays.AutoSize = false;
            this.btnAddDays.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddDays.Depth = 0;
            this.btnAddDays.DrawShadows = true;
            this.btnAddDays.HighEmphasis = true;
            this.btnAddDays.Icon = null;
            this.btnAddDays.Location = new System.Drawing.Point(668, 88);
            this.btnAddDays.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddDays.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddDays.Name = "btnAddDays";
            this.btnAddDays.Size = new System.Drawing.Size(22, 26);
            this.btnAddDays.TabIndex = 114;
            this.btnAddDays.Text = "...";
            this.btnAddDays.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddDays.UseAccentColor = false;
            this.btnAddDays.UseVisualStyleBackColor = true;
            this.btnAddDays.Click += new System.EventHandler(this.btnAddDays_Click);
            // 
            // tbReminderName
            // 
            this.tbReminderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbReminderName.Depth = 0;
            this.tbReminderName.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbReminderName.Hint = "Reminder Name";
            this.tbReminderName.Location = new System.Drawing.Point(93, 32);
            this.tbReminderName.MaxLength = 500;
            this.tbReminderName.MouseState = MaterialSkin.MouseState.OUT;
            this.tbReminderName.Multiline = false;
            this.tbReminderName.Name = "tbReminderName";
            this.tbReminderName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbReminderName.Size = new System.Drawing.Size(242, 50);
            this.tbReminderName.TabIndex = 0;
            this.tbReminderName.Text = "";
            // 
            // AddDaysMenuStrip
            // 
            this.AddDaysMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.AddDaysMenuStrip.Depth = 0;
            this.AddDaysMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMinutestoCurrentTimeToolStripMenuItem,
            this.addDaysToolStripMenuItem,
            this.addMonthsToolStripMenuItem,
            this.subtractDaysToolStripMenuItem,
            this.subtractMonthsToolStripMenuItem,
            this.resetTimeDateToolStripMenuItem});
            this.AddDaysMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddDaysMenuStrip.Name = "AddDaysMenuStrip";
            this.AddDaysMenuStrip.Size = new System.Drawing.Size(233, 136);
            // 
            // addMinutestoCurrentTimeToolStripMenuItem
            // 
            this.addMinutestoCurrentTimeToolStripMenuItem.Name = "addMinutestoCurrentTimeToolStripMenuItem";
            this.addMinutestoCurrentTimeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.addMinutestoCurrentTimeToolStripMenuItem.Text = "Add Minutes (to current time)";
            this.addMinutestoCurrentTimeToolStripMenuItem.Click += new System.EventHandler(this.addMinutesToolStripMenuItem_Click);
            // 
            // addDaysToolStripMenuItem
            // 
            this.addDaysToolStripMenuItem.Name = "addDaysToolStripMenuItem";
            this.addDaysToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.addDaysToolStripMenuItem.Text = "Add Days";
            this.addDaysToolStripMenuItem.Click += new System.EventHandler(this.addDaysToolStripMenuItem_Click);
            // 
            // addMonthsToolStripMenuItem
            // 
            this.addMonthsToolStripMenuItem.Name = "addMonthsToolStripMenuItem";
            this.addMonthsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.addMonthsToolStripMenuItem.Text = "Add Months";
            this.addMonthsToolStripMenuItem.Click += new System.EventHandler(this.addMonthsToolStripMenuItem_Click);
            // 
            // subtractDaysToolStripMenuItem
            // 
            this.subtractDaysToolStripMenuItem.Name = "subtractDaysToolStripMenuItem";
            this.subtractDaysToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.subtractDaysToolStripMenuItem.Text = "Subtract Days";
            this.subtractDaysToolStripMenuItem.Click += new System.EventHandler(this.subtractDaysToolStripMenuItem_Click);
            // 
            // subtractMonthsToolStripMenuItem
            // 
            this.subtractMonthsToolStripMenuItem.Name = "subtractMonthsToolStripMenuItem";
            this.subtractMonthsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.subtractMonthsToolStripMenuItem.Text = "Subtract Months";
            this.subtractMonthsToolStripMenuItem.Click += new System.EventHandler(this.subtractMonthsToolStripMenuItem_Click);
            // 
            // resetTimeDateToolStripMenuItem
            // 
            this.resetTimeDateToolStripMenuItem.Name = "resetTimeDateToolStripMenuItem";
            this.resetTimeDateToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.resetTimeDateToolStripMenuItem.Text = "Reset Time/Date";
            this.resetTimeDateToolStripMenuItem.Click += new System.EventHandler(this.resetTimeDateToolStripMenuItem_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackColor = System.Drawing.Color.Transparent;
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.Image = global::RemindMe.Properties.Resources.imageDark;
            this.btnImage.ImageActive = null;
            this.btnImage.ImageLocation = "";
            this.btnImage.Location = new System.Drawing.Point(21, 0);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(18, 18);
            this.btnImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImage.TabIndex = 141;
            this.btnImage.TabStop = false;
            this.btnImage.Zoom = -15;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnStrikethrough
            // 
            this.btnStrikethrough.BackColor = System.Drawing.Color.Transparent;
            this.btnStrikethrough.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStrikethrough.Image = global::RemindMe.Properties.Resources.strikethrough_text_interface_option_button;
            this.btnStrikethrough.ImageActive = null;
            this.btnStrikethrough.ImageLocation = "";
            this.btnStrikethrough.Location = new System.Drawing.Point(0, 72);
            this.btnStrikethrough.Name = "btnStrikethrough";
            this.btnStrikethrough.Size = new System.Drawing.Size(18, 18);
            this.btnStrikethrough.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnStrikethrough.TabIndex = 140;
            this.btnStrikethrough.TabStop = false;
            this.btnStrikethrough.Zoom = -15;
            this.btnStrikethrough.Click += new System.EventHandler(this.btnStrikethrough_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.BackColor = System.Drawing.Color.Transparent;
            this.btnUnderline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnderline.Image = global::RemindMe.Properties.Resources.underline;
            this.btnUnderline.ImageActive = null;
            this.btnUnderline.ImageLocation = "";
            this.btnUnderline.Location = new System.Drawing.Point(0, 48);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(18, 18);
            this.btnUnderline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUnderline.TabIndex = 139;
            this.btnUnderline.TabStop = false;
            this.btnUnderline.Zoom = -15;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.BackColor = System.Drawing.Color.Transparent;
            this.btnItalic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItalic.Image = global::RemindMe.Properties.Resources.italic;
            this.btnItalic.ImageActive = null;
            this.btnItalic.ImageLocation = "";
            this.btnItalic.Location = new System.Drawing.Point(0, 24);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(18, 18);
            this.btnItalic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnItalic.TabIndex = 138;
            this.btnItalic.TabStop = false;
            this.btnItalic.Zoom = -15;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnBold
            // 
            this.btnBold.BackColor = System.Drawing.Color.Transparent;
            this.btnBold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBold.Image = global::RemindMe.Properties.Resources.bold;
            this.btnBold.ImageActive = null;
            this.btnBold.ImageLocation = "";
            this.btnBold.Location = new System.Drawing.Point(0, 0);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(18, 18);
            this.btnBold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBold.TabIndex = 137;
            this.btnBold.TabStop = false;
            this.btnBold.Zoom = -15;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnAdvancedReminder
            // 
            this.btnAdvancedReminder.AutoSize = false;
            this.btnAdvancedReminder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdvancedReminder.Depth = 0;
            this.btnAdvancedReminder.DrawShadows = true;
            this.btnAdvancedReminder.HighEmphasis = true;
            this.btnAdvancedReminder.Icon = global::RemindMe.Properties.Resources.codeWhite;
            this.btnAdvancedReminder.Location = new System.Drawing.Point(757, 6);
            this.btnAdvancedReminder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdvancedReminder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdvancedReminder.Name = "btnAdvancedReminder";
            this.btnAdvancedReminder.Size = new System.Drawing.Size(45, 38);
            this.btnAdvancedReminder.TabIndex = 125;
            this.btnAdvancedReminder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdvancedReminder.UseAccentColor = false;
            this.btnAdvancedReminder.UseVisualStyleBackColor = true;
            this.btnAdvancedReminder.Visible = false;
            this.btnAdvancedReminder.Click += new System.EventHandler(this.btnAdvancedReminder_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = false;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Depth = 0;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnClear.DrawShadows = true;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnClear.Location = new System.Drawing.Point(463, 442);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 35);
            this.btnClear.TabIndex = 124;
            this.btnClear.Text = "Reset input";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.DrawShadows = true;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = global::RemindMe.Properties.Resources.Save_white;
            this.btnConfirm.Location = new System.Drawing.Point(280, 442);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(175, 35);
            this.btnConfirm.TabIndex = 123;
            this.btnConfirm.Text = "SAVE";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = false;
            this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBack.Depth = 0;
            this.btnBack.DrawShadows = true;
            this.btnBack.HighEmphasis = true;
            this.btnBack.Icon = global::RemindMe.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(96, 442);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBack.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 35);
            this.btnBack.TabIndex = 122;
            this.btnBack.Text = "Back";
            this.btnBack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBack.UseAccentColor = false;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemoveDate
            // 
            this.btnRemoveDate.AutoSize = false;
            this.btnRemoveDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoveDate.Depth = 0;
            this.btnRemoveDate.DrawShadows = true;
            this.btnRemoveDate.HighEmphasis = true;
            this.btnRemoveDate.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveDate.Location = new System.Drawing.Point(645, 126);
            this.btnRemoveDate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveDate.Name = "btnRemoveDate";
            this.btnRemoveDate.Size = new System.Drawing.Size(44, 38);
            this.btnRemoveDate.TabIndex = 117;
            this.btnRemoveDate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveDate.UseAccentColor = false;
            this.btnRemoveDate.UseVisualStyleBackColor = true;
            this.btnRemoveDate.Click += new System.EventHandler(this.btnRemoveDate_Click);
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.AutoSize = false;
            this.btnPlaySound.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlaySound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlaySound.Depth = 0;
            this.btnPlaySound.DrawShadows = true;
            this.btnPlaySound.HighEmphasis = true;
            this.btnPlaySound.Icon = global::RemindMe.Properties.Resources.Play;
            this.btnPlaySound.Location = new System.Drawing.Point(645, 39);
            this.btnPlaySound.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPlaySound.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(44, 37);
            this.btnPlaySound.TabIndex = 113;
            this.btnPlaySound.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPlaySound.UseAccentColor = false;
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // MUCNewReminder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMarkupButtons);
            this.Controls.Add(this.cbEvery);
            this.Controls.Add(this.cbEveryXCustom);
            this.Controls.Add(this.cbMonthlyDays);
            this.Controls.Add(this.cbMultipleDates);
            this.Controls.Add(this.cbSound);
            this.Controls.Add(this.btnAddMonthlyDay);
            this.Controls.Add(this.numEveryXDays);
            this.Controls.Add(this.pnlUpdateTime);
            this.Controls.Add(this.btnRemoveMonthlyDay);
            this.Controls.Add(this.btnAdvancedReminder);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlDayCheckBoxes);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.groupRepeatRadiobuttons);
            this.Controls.Add(this.btnRemoveDate);
            this.Controls.Add(this.btnAddDate);
            this.Controls.Add(this.btnAddDays);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.tbReminderName);
            this.Name = "MUCNewReminder";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCNewReminder_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCNewReminder_VisibleChanged);
            this.groupRepeatRadiobuttons.ResumeLayout(false);
            this.groupRepeatRadiobuttons.PerformLayout();
            this.pnlDayCheckBoxes.ResumeLayout(false);
            this.pnlDayCheckBoxes.PerformLayout();
            this.pnlUpdateTime.ResumeLayout(false);
            this.pnlUpdateTime.PerformLayout();
            this.pnlMarkupButtons.ResumeLayout(false);
            this.AddDaysMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStrikethrough)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUnderline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnItalic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tbReminderName;        
        private System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.DateTimePicker dtpTime;
        private MaterialSkin.Controls.MaterialButton btnPlaySound;
        private MaterialSkin.Controls.MaterialButton btnAddDays;
        private MaterialSkin.Controls.MaterialButton btnAddDate;        
        private MaterialSkin.Controls.MaterialButton btnRemoveDate;
        private System.Windows.Forms.GroupBox groupRepeatRadiobuttons;
        private MaterialSkin.Controls.MaterialRadioButton rbNoRepeat;
        private MaterialSkin.Controls.MaterialRadioButton rbEveryXCustom;
        private MaterialSkin.Controls.MaterialRadioButton rbMonthly;
        private MaterialSkin.Controls.MaterialRadioButton rbMultipleDays;
        private MaterialSkin.Controls.MaterialRadioButton rbWorkDays;
        private MaterialSkin.Controls.MaterialRadioButton rbDaily;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbNote;
        private System.Windows.Forms.Panel pnlDayCheckBoxes;
        private MaterialSkin.Controls.MaterialCheckbox cbSunday;
        private MaterialSkin.Controls.MaterialCheckbox cbThursday;
        private MaterialSkin.Controls.MaterialCheckbox cbSaturday;
        private MaterialSkin.Controls.MaterialCheckbox cbFriday;
        private MaterialSkin.Controls.MaterialCheckbox cbWednesday;
        private MaterialSkin.Controls.MaterialCheckbox cbTuesday;
        private MaterialSkin.Controls.MaterialCheckbox cbMonday;        
        private MaterialSkin.Controls.MaterialButton btnRemoveMonthlyDay;
        private MaterialSkin.Controls.MaterialButton btnAddMonthlyDay;        
        private MaterialSkin.Controls.MaterialSwitch swUpdateTime;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnBack;        
        private MaterialSkin.Controls.MaterialTextBox numEveryXDays;
        private MaterialSkin.Controls.MaterialButton btnAdvancedReminder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer tmrMusic;
        private System.Windows.Forms.Panel pnlUpdateTime;
        private MaterialSkin.Controls.MaterialContextMenuStrip disableRightclick;
        private MaterialSkin.Controls.MaterialContextMenuStrip AddDaysMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addMinutestoCurrentTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTimeDateToolStripMenuItem;
        private MaterialSkin.Controls.MaterialComboBox cbSound;
        private MaterialSkin.Controls.MaterialComboBox cbMultipleDates;
        private MaterialSkin.Controls.MaterialComboBox cbEvery;
        private MaterialSkin.Controls.MaterialComboBox cbMonthlyDays;
        private MaterialSkin.Controls.MaterialComboBox cbEveryXCustom;
        private System.Windows.Forms.Timer tmrCheckbox;
        private System.Windows.Forms.Panel pnlMarkupButtons;
        private Bunifu.Framework.UI.BunifuImageButton btnBold;
        private Bunifu.Framework.UI.BunifuImageButton btnUnderline;
        private Bunifu.Framework.UI.BunifuImageButton btnItalic;
        private Bunifu.Framework.UI.BunifuImageButton btnStrikethrough;
        private Bunifu.Framework.UI.BunifuImageButton btnImage;
    }
}
