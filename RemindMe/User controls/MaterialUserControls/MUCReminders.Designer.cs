namespace RemindMe
{
    partial class MUCReminders
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnUnhideReminders = new MaterialSkin.Controls.MaterialButton();
            this.btnNextPage = new MaterialSkin.Controls.MaterialButton();
            this.btnPreviousPage = new MaterialSkin.Controls.MaterialButton();
            this.btnAddReminder = new MaterialSkin.Controls.MaterialButton();
            this.pnlReminders = new System.Windows.Forms.Panel();
            this.tmrCheckReminder = new System.Windows.Forms.Timer(this.components);
            this.tmrClearMessageCache = new System.Windows.Forms.Timer(this.components);
            this.tmrCheckForUpdates = new System.Windows.Forms.Timer(this.components);
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnUnhideReminders);
            this.pnlFooter.Controls.Add(this.btnNextPage);
            this.pnlFooter.Controls.Add(this.btnPreviousPage);
            this.pnlFooter.Controls.Add(this.btnAddReminder);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 460);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(806, 38);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnUnhideReminders
            // 
            this.btnUnhideReminders.AutoSize = false;
            this.btnUnhideReminders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUnhideReminders.Depth = 0;
            this.btnUnhideReminders.DrawShadows = true;
            this.btnUnhideReminders.HighEmphasis = false;
            this.btnUnhideReminders.Icon = global::RemindMe.Properties.Resources.eyeDark;
            this.btnUnhideReminders.Location = new System.Drawing.Point(591, 0);
            this.btnUnhideReminders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUnhideReminders.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUnhideReminders.Name = "btnUnhideReminders";
            this.btnUnhideReminders.Size = new System.Drawing.Size(218, 38);
            this.btnUnhideReminders.TabIndex = 4;
            this.btnUnhideReminders.Text = "unhide reminders";
            this.btnUnhideReminders.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUnhideReminders.UseAccentColor = false;
            this.btnUnhideReminders.UseVisualStyleBackColor = true;
            this.btnUnhideReminders.Click += new System.EventHandler(this.btnUnhideReminders_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSize = false;
            this.btnNextPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextPage.Depth = 0;
            this.btnNextPage.DrawShadows = true;
            this.btnNextPage.HighEmphasis = false;
            this.btnNextPage.Icon = global::RemindMe.Properties.Resources.nextDark;
            this.btnNextPage.Location = new System.Drawing.Point(393, 0);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(199, 38);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = "next page";
            this.btnNextPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNextPage.UseAccentColor = false;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AutoSize = false;
            this.btnPreviousPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviousPage.Depth = 0;
            this.btnPreviousPage.DrawShadows = true;
            this.btnPreviousPage.HighEmphasis = false;
            this.btnPreviousPage.Icon = global::RemindMe.Properties.Resources.previousDark;
            this.btnPreviousPage.Location = new System.Drawing.Point(195, 0);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviousPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(199, 38);
            this.btnPreviousPage.TabIndex = 2;
            this.btnPreviousPage.Text = "Previous page";
            this.btnPreviousPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousPage.UseAccentColor = false;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.AutoSize = false;
            this.btnAddReminder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddReminder.Depth = 0;
            this.btnAddReminder.DrawShadows = true;
            this.btnAddReminder.HighEmphasis = false;
            this.btnAddReminder.Icon = global::RemindMe.Properties.Resources.plusDark;
            this.btnAddReminder.Location = new System.Drawing.Point(-3, 0);
            this.btnAddReminder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddReminder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(199, 38);
            this.btnAddReminder.TabIndex = 1;
            this.btnAddReminder.Text = "New Reminder";
            this.btnAddReminder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddReminder.UseAccentColor = false;
            this.btnAddReminder.UseVisualStyleBackColor = true;
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // pnlReminders
            // 
            this.pnlReminders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReminders.Location = new System.Drawing.Point(0, 0);
            this.pnlReminders.Name = "pnlReminders";
            this.pnlReminders.Size = new System.Drawing.Size(806, 460);
            this.pnlReminders.TabIndex = 1;
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
            // tmrCheckForUpdates
            // 
            this.tmrCheckForUpdates.Interval = 5000;
            this.tmrCheckForUpdates.Tick += new System.EventHandler(this.tmrCheckForUpdates_Tick);
            // 
            // MUCReminders
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlReminders);
            this.Controls.Add(this.pnlFooter);
            this.Name = "MUCReminders";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCReminders_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCReminders_VisibleChanged);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private MaterialSkin.Controls.MaterialButton btnUnhideReminders;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnPreviousPage;
        private MaterialSkin.Controls.MaterialButton btnAddReminder;
        private System.Windows.Forms.Panel pnlReminders;
        private System.Windows.Forms.Timer tmrCheckReminder;
        private System.Windows.Forms.Timer tmrClearMessageCache;
        private System.Windows.Forms.Timer tmrCheckForUpdates;
    }
}
