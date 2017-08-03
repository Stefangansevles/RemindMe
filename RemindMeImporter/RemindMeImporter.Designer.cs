namespace RemindMeImporter
{
    partial class RemindMeImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMeImporter));
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lvImportedReminders = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepeating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(196, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 24);
            this.label2.TabIndex = 81;
            this.label2.Text = "Importing reminders";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(595, 22);
            this.textBox1.TabIndex = 77;
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
            this.lvImportedReminders.Location = new System.Drawing.Point(12, 90);
            this.lvImportedReminders.Name = "lvImportedReminders";
            this.lvImportedReminders.Size = new System.Drawing.Size(562, 179);
            this.lvImportedReminders.TabIndex = 88;
            this.lvImportedReminders.UseCompatibleStateImageBehavior = false;
            this.lvImportedReminders.View = System.Windows.Forms.View.Details;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 200;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 135;
            // 
            // chRepeating
            // 
            this.chRepeating.Text = "Repeating";
            this.chRepeating.Width = 115;
            // 
            // chEnabled
            // 
            this.chEnabled.Text = "Enabled";
            this.chEnabled.Width = 70;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(55, 274);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 16);
            this.label1.TabIndex = 89;
            this.label1.Text = "Do you want to import these reminders?";
            // 
            // pbStatus
            // 
            this.pbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStatus.Location = new System.Drawing.Point(11, 270);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(25, 25);
            this.pbStatus.TabIndex = 93;
            this.pbStatus.TabStop = false;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.BackgroundImage = global::RemindMeImporter.Properties.Resources.bbuttonEDIT2;
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.Transparent;
            this.btnYes.Location = new System.Drawing.Point(464, 271);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(53, 23);
            this.btnYes.TabIndex = 91;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.BackgroundImage = global::RemindMeImporter.Properties.Resources.bbuttonEDIT2;
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.Color.Transparent;
            this.btnNo.Location = new System.Drawing.Point(519, 271);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(53, 23);
            this.btnNo.TabIndex = 90;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.BackgroundImage = global::RemindMeImporter.Properties.Resources.RemindMe;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 22);
            this.pictureBox4.TabIndex = 80;
            this.pictureBox4.TabStop = false;
            // 
            // pbMinimizeApplication
            // 
            this.pbMinimizeApplication.BackColor = System.Drawing.Color.Black;
            this.pbMinimizeApplication.BackgroundImage = global::RemindMeImporter.Properties.Resources.min;
            this.pbMinimizeApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMinimizeApplication.Location = new System.Drawing.Point(534, 0);
            this.pbMinimizeApplication.Name = "pbMinimizeApplication";
            this.pbMinimizeApplication.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizeApplication.TabIndex = 79;
            this.pbMinimizeApplication.TabStop = false;
            this.pbMinimizeApplication.Click += new System.EventHandler(this.pbMinimizeApplication_Click);
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Black;
            this.pbCloseApplication.BackgroundImage = global::RemindMeImporter.Properties.Resources.redx;
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(557, 0);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 78;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // RemindMeImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(581, 302);
            this.Controls.Add(this.lvImportedReminders);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemindMeImporter";
            this.Text = "ReminderImporter";
            this.Load += new System.EventHandler(this.RemindMeImporter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView lvImportedReminders;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chRepeating;
        private System.Windows.Forms.ColumnHeader chEnabled;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Button btnYes;
        public System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label label1;
    }
}

