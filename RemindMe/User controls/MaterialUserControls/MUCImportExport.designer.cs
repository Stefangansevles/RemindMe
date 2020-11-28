namespace RemindMe
{
    partial class MUCImportExport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.lvReminders = new MaterialSkin.Controls.MaterialListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbAction = new MaterialSkin.Controls.MaterialComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 36);
            this.panel1.TabIndex = 125;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Depth = 0;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.DrawShadows = true;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnCancel.Location = new System.Drawing.Point(150, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 36);
            this.btnCancel.TabIndex = 123;
            this.btnCancel.Text = "reset";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfirm.DrawShadows = true;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = global::RemindMe.Properties.Resources.Check_white;
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 36);
            this.btnConfirm.TabIndex = 122;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lvReminders
            // 
            this.lvReminders.AllowDrop = true;
            this.lvReminders.AutoSizeTable = false;
            this.lvReminders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvReminders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReminders.CheckBoxes = true;
            this.lvReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chDate,
            this.chRepeat});
            this.lvReminders.Depth = 0;
            this.lvReminders.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.HideSelection = false;
            this.lvReminders.Location = new System.Drawing.Point(0, 49);
            this.lvReminders.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvReminders.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvReminders.MouseState = MaterialSkin.MouseState.OUT;
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.OwnerDraw = true;
            this.lvReminders.Size = new System.Drawing.Size(806, 411);
            this.lvReminders.TabIndex = 0;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;            
            this.lvReminders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReminders_KeyDown);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 430;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 175;
            // 
            // chRepeat
            // 
            this.chRepeat.Text = "Repeating";
            this.chRepeat.Width = 200;
            // 
            // cbAction
            // 
            this.cbAction.AutoResize = false;
            this.cbAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAction.Depth = 0;
            this.cbAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbAction.DropDownHeight = 174;
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.DropDownWidth = 121;
            this.cbAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Hint = "Select an action";
            this.cbAction.IntegralHeight = false;
            this.cbAction.ItemHeight = 43;
            this.cbAction.Items.AddRange(new object[] {
            "Export reminders",
            "Import reminders",
            "Recover deleted reminders",
            "Recover old reminders"});
            this.cbAction.Location = new System.Drawing.Point(0, 0);
            this.cbAction.MaxDropDownItems = 4;
            this.cbAction.MouseState = MaterialSkin.MouseState.OUT;
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(806, 49);
            this.cbAction.TabIndex = 124;
            this.cbAction.SelectedIndexChanged += new System.EventHandler(this.cbAction_SelectedIndexChanged);
            // 
            // MUCImportExport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvReminders);
            this.Controls.Add(this.cbAction);
            this.Name = "MUCImportExport";
            this.Size = new System.Drawing.Size(806, 498);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chRepeat;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        public MaterialSkin.Controls.MaterialListView lvReminders;
        private MaterialSkin.Controls.MaterialComboBox cbAction;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ColumnHeader chTitle;
    }
}
