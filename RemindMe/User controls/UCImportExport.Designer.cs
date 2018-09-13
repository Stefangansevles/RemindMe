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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lvReminders = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRecoverOld = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRecoverDeleted = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnImport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnExport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnConfirm = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlFooter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnConfirm);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 395);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(666, 41);
            this.pnlFooter.TabIndex = 5;
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
            this.lvReminders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReminders.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lvReminders.ForeColor = System.Drawing.Color.White;
            this.lvReminders.FullRowSelect = true;
            this.lvReminders.Location = new System.Drawing.Point(0, 0);
            this.lvReminders.Name = "lvReminders";
            this.lvReminders.Size = new System.Drawing.Size(666, 354);
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
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnRecoverOld);
            this.pnlTop.Controls.Add(this.btnRecoverDeleted);
            this.pnlTop.Controls.Add(this.btnImport);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(666, 41);
            this.pnlTop.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvReminders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 354);
            this.panel1.TabIndex = 8;
            // 
            // btnRecoverOld
            // 
            this.btnRecoverOld.Activecolor = System.Drawing.Color.Silver;
            this.btnRecoverOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecoverOld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecoverOld.BorderRadius = 5;
            this.btnRecoverOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRecoverOld.ButtonText = "    Recover old";
            this.btnRecoverOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecoverOld.DisabledColor = System.Drawing.Color.Gray;
            this.btnRecoverOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecoverOld.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoverOld.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRecoverOld.Iconimage = global::RemindMe.Properties.Resources.RevertIcon;
            this.btnRecoverOld.Iconimage_right = null;
            this.btnRecoverOld.Iconimage_right_Selected = null;
            this.btnRecoverOld.Iconimage_Selected = null;
            this.btnRecoverOld.IconMarginLeft = 0;
            this.btnRecoverOld.IconMarginRight = 0;
            this.btnRecoverOld.IconRightVisible = true;
            this.btnRecoverOld.IconRightZoom = 0D;
            this.btnRecoverOld.IconVisible = true;
            this.btnRecoverOld.IconZoom = 50D;
            this.btnRecoverOld.IsTab = true;
            this.btnRecoverOld.Location = new System.Drawing.Point(482, 0);
            this.btnRecoverOld.Name = "btnRecoverOld";
            this.btnRecoverOld.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecoverOld.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnRecoverOld.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRecoverOld.selected = false;
            this.btnRecoverOld.Size = new System.Drawing.Size(184, 41);
            this.btnRecoverOld.TabIndex = 5;
            this.btnRecoverOld.Text = "    Recover old";
            this.btnRecoverOld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecoverOld.Textcolor = System.Drawing.Color.White;
            this.btnRecoverOld.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoverOld.Click += new System.EventHandler(this.btnRecoverOld_Click);
            // 
            // btnRecoverDeleted
            // 
            this.btnRecoverDeleted.Activecolor = System.Drawing.Color.Silver;
            this.btnRecoverDeleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecoverDeleted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecoverDeleted.BorderRadius = 5;
            this.btnRecoverDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRecoverDeleted.ButtonText = "    Recover deleted";
            this.btnRecoverDeleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecoverDeleted.DisabledColor = System.Drawing.Color.Gray;
            this.btnRecoverDeleted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRecoverDeleted.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoverDeleted.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRecoverDeleted.Iconimage = global::RemindMe.Properties.Resources.RevertIcon;
            this.btnRecoverDeleted.Iconimage_right = null;
            this.btnRecoverDeleted.Iconimage_right_Selected = null;
            this.btnRecoverDeleted.Iconimage_Selected = null;
            this.btnRecoverDeleted.IconMarginLeft = 0;
            this.btnRecoverDeleted.IconMarginRight = 0;
            this.btnRecoverDeleted.IconRightVisible = true;
            this.btnRecoverDeleted.IconRightZoom = 0D;
            this.btnRecoverDeleted.IconVisible = true;
            this.btnRecoverDeleted.IconZoom = 50D;
            this.btnRecoverDeleted.IsTab = true;
            this.btnRecoverDeleted.Location = new System.Drawing.Point(290, 0);
            this.btnRecoverDeleted.Name = "btnRecoverDeleted";
            this.btnRecoverDeleted.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecoverDeleted.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnRecoverDeleted.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRecoverDeleted.selected = false;
            this.btnRecoverDeleted.Size = new System.Drawing.Size(192, 41);
            this.btnRecoverDeleted.TabIndex = 4;
            this.btnRecoverDeleted.Text = "    Recover deleted";
            this.btnRecoverDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecoverDeleted.Textcolor = System.Drawing.Color.White;
            this.btnRecoverDeleted.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoverDeleted.Click += new System.EventHandler(this.btnRecoverDeleted_Click);
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
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.btnImport.Location = new System.Drawing.Point(145, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnImport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnImport.selected = false;
            this.btnImport.Size = new System.Drawing.Size(145, 41);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "    Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Textcolor = System.Drawing.Color.White;
            this.btnImport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.btnExport.Location = new System.Drawing.Point(0, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExport.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnExport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExport.selected = false;
            this.btnExport.Size = new System.Drawing.Size(145, 41);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "    Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Textcolor = System.Drawing.Color.White;
            this.btnExport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.btnCancel.Iconimage = global::RemindMe.Properties.Resources.Cancel_white;
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
            this.btnCancel.Size = new System.Drawing.Size(121, 41);
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
            this.btnConfirm.Iconimage = global::RemindMe.Properties.Resources.Check_white;
            this.btnConfirm.Iconimage_right = null;
            this.btnConfirm.Iconimage_right_Selected = null;
            this.btnConfirm.Iconimage_Selected = null;
            this.btnConfirm.IconMarginLeft = 0;
            this.btnConfirm.IconMarginRight = 0;
            this.btnConfirm.IconRightVisible = true;
            this.btnConfirm.IconRightZoom = 0D;
            this.btnConfirm.IconVisible = true;
            this.btnConfirm.IconZoom = 60D;
            this.btnConfirm.IsTab = false;
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirm.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnConfirm.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConfirm.selected = false;
            this.btnConfirm.Size = new System.Drawing.Size(121, 41);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "    Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Textcolor = System.Drawing.Color.White;
            this.btnConfirm.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // UCImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlFooter);
            this.Name = "UCImportExport";
            this.Size = new System.Drawing.Size(666, 436);
            this.pnlFooter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Panel pnlTop;
        private Bunifu.Framework.UI.BunifuFlatButton btnRecoverDeleted;
        private Bunifu.Framework.UI.BunifuFlatButton btnRecoverOld;
        private System.Windows.Forms.Panel panel1;
    }
}
