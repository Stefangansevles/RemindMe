namespace RemindMe
{
    partial class UCImportedReminders
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
            this.lvImportedReminders = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lvImportedReminders
            // 
            this.lvImportedReminders.BackColor = System.Drawing.Color.DimGray;
            this.lvImportedReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chDate,
            this.chRepeating,
            this.chEnabled});
            this.lvImportedReminders.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.lvImportedReminders.ForeColor = System.Drawing.Color.White;
            this.lvImportedReminders.FullRowSelect = true;
            this.lvImportedReminders.Location = new System.Drawing.Point(3, 22);
            this.lvImportedReminders.Name = "lvImportedReminders";
            this.lvImportedReminders.Size = new System.Drawing.Size(436, 161);
            this.lvImportedReminders.TabIndex = 14;
            this.lvImportedReminders.UseCompatibleStateImageBehavior = false;
            this.lvImportedReminders.View = System.Windows.Forms.View.Details;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 120;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 105;
            // 
            // chRepeating
            // 
            this.chRepeating.Text = "Repeating";
            this.chRepeating.Width = 105;
            // 
            // chEnabled
            // 
            this.chEnabled.Text = "Enabled";
            this.chEnabled.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Do you want to import these reminders?";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.Transparent;
            this.btnYes.Location = new System.Drawing.Point(331, 185);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(53, 23);
            this.btnYes.TabIndex = 85;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.Color.Transparent;
            this.btnNo.Location = new System.Drawing.Point(386, 185);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(53, 23);
            this.btnNo.TabIndex = 84;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(46, 188);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 86;
            // 
            // pbStatus
            // 
            this.pbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStatus.Location = new System.Drawing.Point(2, 184);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(25, 25);
            this.pbStatus.TabIndex = 87;
            this.pbStatus.TabStop = false;
            // 
            // UCImportedReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvImportedReminders);
            this.Name = "UCImportedReminders";
            this.Size = new System.Drawing.Size(442, 209);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvImportedReminders;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chRepeating;
        private System.Windows.Forms.ColumnHeader chEnabled;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnYes;
        public System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbStatus;
    }
}
