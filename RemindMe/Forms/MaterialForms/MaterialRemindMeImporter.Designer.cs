namespace RemindMe
{
    partial class MaterialRemindMeImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialRemindMeImporter));
            this.pnlFooterButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnImport = new MaterialSkin.Controls.MaterialButton();
            this.lvReminders = new MaterialSkin.Controls.MaterialListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlFooterButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooterButtons
            // 
            this.pnlFooterButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFooterButtons.Controls.Add(this.btnCancel);
            this.pnlFooterButtons.Controls.Add(this.btnImport);
            this.pnlFooterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterButtons.Location = new System.Drawing.Point(0, 294);
            this.pnlFooterButtons.Name = "pnlFooterButtons";
            this.pnlFooterButtons.Size = new System.Drawing.Size(416, 60);
            this.pnlFooterButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Depth = 0;
            this.btnCancel.DrawShadows = true;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(228, 17);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = false;
            this.btnImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImport.Depth = 0;
            this.btnImport.DrawShadows = true;
            this.btnImport.HighEmphasis = true;
            this.btnImport.Icon = null;
            this.btnImport.Location = new System.Drawing.Point(313, 17);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(79, 30);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "Import";
            this.btnImport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnImport.UseAccentColor = false;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lvReminders
            // 
            this.lvReminders.AutoSizeTable = false;
            this.lvReminders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvReminders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chDate});
            this.lvReminders.Depth = 0;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.HideSelection = false;
            this.lvReminders.Location = new System.Drawing.Point(0, 64);
            this.lvReminders.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvReminders.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvReminders.MouseState = MaterialSkin.MouseState.OUT;
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.OwnerDraw = true;
            this.lvReminders.Size = new System.Drawing.Size(416, 236);
            this.lvReminders.TabIndex = 3;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 296;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 120;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // MaterialRemindMeImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 354);
            this.Controls.Add(this.lvReminders);
            this.Controls.Add(this.pnlFooterButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MaterialRemindMeImporter";
            this.Text = "Import Reminders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialRemindMeImporter_FormClosing);
            this.Load += new System.EventHandler(this.RemindMeImporter_Load);
            this.pnlFooterButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooterButtons;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnImport;
        private MaterialSkin.Controls.MaterialListView lvReminders;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.Timer timer1;
    }
}