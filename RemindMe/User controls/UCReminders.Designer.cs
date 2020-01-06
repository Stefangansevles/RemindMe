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
            this.tmrCheckReminder = new System.Windows.Forms.Timer(this.components);
            this.tmrClearMessageCache = new System.Windows.Forms.Timer(this.components);
            this.pnlBackground = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUnhideReminders = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNextPage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPreviousPage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddReminder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlReminders = new RemindMe.NonFlickerPanel();
            this.pnlBackground.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // pnlBackground
            // 
            this.pnlBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackground.BackgroundImage")));
            this.pnlBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackground.Controls.Add(this.pnlReminders);
            this.pnlBackground.Controls.Add(this.panel1);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.GradientBottomLeft = System.Drawing.Color.Gray;
            this.pnlBackground.GradientBottomRight = System.Drawing.Color.DimGray;
            this.pnlBackground.GradientTopLeft = System.Drawing.Color.Gray;
            this.pnlBackground.GradientTopRight = System.Drawing.Color.Gray;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Quality = 10;
            this.pnlBackground.Size = new System.Drawing.Size(666, 436);
            this.pnlBackground.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.btnUnhideReminders);
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.btnPreviousPage);
            this.panel1.Controls.Add(this.btnAddReminder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 42);
            this.panel1.TabIndex = 5;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // btnUnhideReminders
            // 
            this.btnUnhideReminders.Activecolor = System.Drawing.Color.DimGray;
            this.btnUnhideReminders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUnhideReminders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUnhideReminders.BorderRadius = 5;
            this.btnUnhideReminders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUnhideReminders.ButtonText = "  Unhide reminders";
            this.btnUnhideReminders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnhideReminders.DisabledColor = System.Drawing.Color.Gray;
            this.btnUnhideReminders.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUnhideReminders.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnhideReminders.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUnhideReminders.Iconimage = global::RemindMe.Properties.Resources.show1;
            this.btnUnhideReminders.Iconimage_right = null;
            this.btnUnhideReminders.Iconimage_right_Selected = null;
            this.btnUnhideReminders.Iconimage_Selected = null;
            this.btnUnhideReminders.IconMarginLeft = 0;
            this.btnUnhideReminders.IconMarginRight = 0;
            this.btnUnhideReminders.IconRightVisible = true;
            this.btnUnhideReminders.IconRightZoom = 0D;
            this.btnUnhideReminders.IconVisible = true;
            this.btnUnhideReminders.IconZoom = 40D;
            this.btnUnhideReminders.IsTab = false;
            this.btnUnhideReminders.Location = new System.Drawing.Point(501, 0);
            this.btnUnhideReminders.Name = "btnUnhideReminders";
            this.btnUnhideReminders.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUnhideReminders.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnUnhideReminders.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUnhideReminders.selected = false;
            this.btnUnhideReminders.Size = new System.Drawing.Size(167, 42);
            this.btnUnhideReminders.TabIndex = 3;
            this.btnUnhideReminders.Text = "  Unhide reminders";
            this.btnUnhideReminders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnhideReminders.Textcolor = System.Drawing.Color.White;
            this.btnUnhideReminders.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnhideReminders.Click += new System.EventHandler(this.btnUnhideReminders_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Activecolor = System.Drawing.Color.DimGray;
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNextPage.BorderRadius = 5;
            this.btnNextPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNextPage.ButtonText = "    Next page";
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.DisabledColor = System.Drawing.Color.Gray;
            this.btnNextPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNextPage.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNextPage.Iconimage = global::RemindMe.Properties.Resources.NextGray2;
            this.btnNextPage.Iconimage_right = null;
            this.btnNextPage.Iconimage_right_Selected = null;
            this.btnNextPage.Iconimage_Selected = null;
            this.btnNextPage.IconMarginLeft = 0;
            this.btnNextPage.IconMarginRight = 0;
            this.btnNextPage.IconRightVisible = true;
            this.btnNextPage.IconRightZoom = 0D;
            this.btnNextPage.IconVisible = true;
            this.btnNextPage.IconZoom = 40D;
            this.btnNextPage.IsTab = false;
            this.btnNextPage.Location = new System.Drawing.Point(334, 0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNextPage.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnNextPage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNextPage.selected = false;
            this.btnNextPage.Size = new System.Drawing.Size(167, 42);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Text = "    Next page";
            this.btnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextPage.Textcolor = System.Drawing.Color.White;
            this.btnNextPage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Activecolor = System.Drawing.Color.DimGray;
            this.btnPreviousPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreviousPage.BorderRadius = 5;
            this.btnPreviousPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPreviousPage.ButtonText = "    Previous page";
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.DisabledColor = System.Drawing.Color.Gray;
            this.btnPreviousPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreviousPage.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPreviousPage.Iconimage = global::RemindMe.Properties.Resources.PreviousGray1;
            this.btnPreviousPage.Iconimage_right = null;
            this.btnPreviousPage.Iconimage_right_Selected = null;
            this.btnPreviousPage.Iconimage_Selected = null;
            this.btnPreviousPage.IconMarginLeft = 0;
            this.btnPreviousPage.IconMarginRight = 0;
            this.btnPreviousPage.IconRightVisible = true;
            this.btnPreviousPage.IconRightZoom = 0D;
            this.btnPreviousPage.IconVisible = true;
            this.btnPreviousPage.IconZoom = 40D;
            this.btnPreviousPage.IsTab = false;
            this.btnPreviousPage.Location = new System.Drawing.Point(167, 0);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreviousPage.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnPreviousPage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPreviousPage.selected = false;
            this.btnPreviousPage.Size = new System.Drawing.Size(167, 42);
            this.btnPreviousPage.TabIndex = 1;
            this.btnPreviousPage.Text = "    Previous page";
            this.btnPreviousPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreviousPage.Textcolor = System.Drawing.Color.White;
            this.btnPreviousPage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
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
            this.btnAddReminder.Size = new System.Drawing.Size(167, 42);
            this.btnAddReminder.TabIndex = 0;
            this.btnAddReminder.Text = "    New Reminder";
            this.btnAddReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddReminder.Textcolor = System.Drawing.Color.White;
            this.btnAddReminder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // pnlReminders
            // 
            this.pnlReminders.AllowDrop = true;
            this.pnlReminders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlReminders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReminders.Location = new System.Drawing.Point(0, 0);
            this.pnlReminders.Name = "pnlReminders";
            this.pnlReminders.Size = new System.Drawing.Size(666, 394);
            this.pnlReminders.TabIndex = 6;
            // 
            // UCReminders
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBackground);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UCReminders";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCReminders_Load);
            this.VisibleChanged += new System.EventHandler(this.UCReminders_VisibleChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UCReminders_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UCReminders_DragEnter);
            this.pnlBackground.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton btnAddReminder;
        private System.Windows.Forms.Timer tmrCheckReminder;
        private System.Windows.Forms.Timer tmrClearMessageCache;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlBackground;
        private NonFlickerPanel pnlReminders;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnNextPage;
        private Bunifu.Framework.UI.BunifuFlatButton btnPreviousPage;
        private Bunifu.Framework.UI.BunifuFlatButton btnUnhideReminders;
    }
}
