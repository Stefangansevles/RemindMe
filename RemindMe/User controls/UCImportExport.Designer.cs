namespace RemindMe
{
    partial class UCImportExport
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnConfirm = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lvReminders = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRecover = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnImport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup / Import Reminders";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnConfirm);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 389);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(666, 47);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.DimGray;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCancel.ButtonText = "    Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = global::RemindMe.Properties.Resources.if_cancel_216128;
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 50D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(121, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(121, 47);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "    Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Activecolor = System.Drawing.Color.DimGray;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.BorderRadius = 5;
            this.btnConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnConfirm.ButtonText = "    Confirm";
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DisabledColor = System.Drawing.Color.Gray;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConfirm.Iconimage = global::RemindMe.Properties.Resources.if_Check_circle_2202263;
            this.btnConfirm.Iconimage_right = null;
            this.btnConfirm.Iconimage_right_Selected = null;
            this.btnConfirm.Iconimage_Selected = null;
            this.btnConfirm.IconMarginLeft = 0;
            this.btnConfirm.IconMarginRight = 0;
            this.btnConfirm.IconRightVisible = true;
            this.btnConfirm.IconRightZoom = 0D;
            this.btnConfirm.IconVisible = true;
            this.btnConfirm.IconZoom = 50D;
            this.btnConfirm.IsTab = false;
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirm.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnConfirm.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConfirm.selected = false;
            this.btnConfirm.Size = new System.Drawing.Size(121, 47);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "    Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Textcolor = System.Drawing.Color.White;
            this.btnConfirm.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lvReminders
            // 
            this.lvReminders.AllowDrop = true;
            this.lvReminders.BackColor = System.Drawing.Color.DimGray;
            this.lvReminders.CheckBoxes = true;
            this.lvReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chDate,
            this.chRepeat,
            this.chEnabled});
            this.lvReminders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvReminders.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lvReminders.ForeColor = System.Drawing.Color.White;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.Location = new System.Drawing.Point(0, 106);
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.Size = new System.Drawing.Size(666, 283);
            this.lvReminders.TabIndex = 6;
            this.lvReminders.UseCompatibleStateImageBehavior = false;
            this.lvReminders.View = System.Windows.Forms.View.Details;
            this.lvReminders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReminders_KeyDown);
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
            this.chEnabled.Width = 110;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnRecover);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 100);
            this.panel1.TabIndex = 7;
            // 
            // btnRecover
            // 
            this.btnRecover.Activecolor = System.Drawing.Color.Silver;
            this.btnRecover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecover.BorderRadius = 5;
            this.btnRecover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRecover.ButtonText = "    Recover";
            this.btnRecover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecover.DisabledColor = System.Drawing.Color.Gray;
            this.btnRecover.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRecover.Iconimage = global::RemindMe.Properties.Resources.RevertIcon;
            this.btnRecover.Iconimage_right = null;
            this.btnRecover.Iconimage_right_Selected = null;
            this.btnRecover.Iconimage_Selected = null;
            this.btnRecover.IconMarginLeft = 0;
            this.btnRecover.IconMarginRight = 0;
            this.btnRecover.IconRightVisible = true;
            this.btnRecover.IconRightZoom = 0D;
            this.btnRecover.IconVisible = true;
            this.btnRecover.IconZoom = 50D;
            this.btnRecover.IsTab = true;
            this.btnRecover.Location = new System.Drawing.Point(268, 54);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecover.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnRecover.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRecover.selected = false;
            this.btnRecover.Size = new System.Drawing.Size(133, 39);
            this.btnRecover.TabIndex = 4;
            this.btnRecover.Text = "    Recover";
            this.btnRecover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecover.Textcolor = System.Drawing.Color.White;
            this.btnRecover.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // btnImport
            // 
            this.btnImport.Activecolor = System.Drawing.Color.Silver;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.BorderRadius = 5;
            this.btnImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnImport.ButtonText = "    Import";
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.DisabledColor = System.Drawing.Color.Gray;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Iconcolor = System.Drawing.Color.Transparent;
            this.btnImport.Iconimage = global::RemindMe.Properties.Resources.ImportIcon;
            this.btnImport.Iconimage_right = null;
            this.btnImport.Iconimage_right_Selected = null;
            this.btnImport.Iconimage_Selected = null;
            this.btnImport.IconMarginLeft = 0;
            this.btnImport.IconMarginRight = 0;
            this.btnImport.IconRightVisible = true;
            this.btnImport.IconRightZoom = 0D;
            this.btnImport.IconVisible = true;
            this.btnImport.IconZoom = 50D;
            this.btnImport.IsTab = true;
            this.btnImport.Location = new System.Drawing.Point(131, 54);
            this.btnImport.Name = "btnImport";
            this.btnImport.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnImport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnImport.selected = false;
            this.btnImport.Size = new System.Drawing.Size(133, 39);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "    Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Textcolor = System.Drawing.Color.White;
            this.btnImport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.RemindMeImport;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(566, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Activecolor = System.Drawing.Color.Silver;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.BorderRadius = 5;
            this.btnExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExport.ButtonText = "    Export";
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DisabledColor = System.Drawing.Color.Gray;
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExport.Iconimage = global::RemindMe.Properties.Resources.ExportIcon;
            this.btnExport.Iconimage_right = null;
            this.btnExport.Iconimage_right_Selected = null;
            this.btnExport.Iconimage_Selected = null;
            this.btnExport.IconMarginLeft = 0;
            this.btnExport.IconMarginRight = 0;
            this.btnExport.IconRightVisible = true;
            this.btnExport.IconRightZoom = 0D;
            this.btnExport.IconVisible = true;
            this.btnExport.IconZoom = 50D;
            this.btnExport.IsTab = true;
            this.btnExport.Location = new System.Drawing.Point(6, 54);
            this.btnExport.Name = "btnExport";
            this.btnExport.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnExport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExport.selected = false;
            this.btnExport.Size = new System.Drawing.Size(121, 39);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "    Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Textcolor = System.Drawing.Color.White;
            this.btnExport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UCImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvReminders);
            this.Controls.Add(this.pnlFooter);
            this.Name = "UCImportExport";
            this.Size = new System.Drawing.Size(666, 436);
            this.pnlFooter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnExport;
        private Bunifu.Framework.UI.BunifuFlatButton btnImport;
        private System.Windows.Forms.Panel pnlFooter;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnConfirm;
        public System.Windows.Forms.ListView lvReminders;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chRepeat;
        private System.Windows.Forms.ColumnHeader chEnabled;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnRecover;
    }
}
