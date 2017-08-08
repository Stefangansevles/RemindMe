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
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlImportedReminders = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlIntro = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbExport = new System.Windows.Forms.PictureBox();
            this.pbImport = new System.Windows.Forms.PictureBox();
            this.pbClearPanel = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pnlIntro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClearPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(164, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 24);
            this.label2.TabIndex = 76;
            this.label2.Text = "Backup / import Reminders";
            this.label2.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(35, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 16);
            this.lblStatus.TabIndex = 79;
            this.lblStatus.Text = " ";
            // 
            // pnlImportedReminders
            // 
            this.pnlImportedReminders.Location = new System.Drawing.Point(6, 64);
            this.pnlImportedReminders.Name = "pnlImportedReminders";
            this.pnlImportedReminders.Size = new System.Drawing.Size(442, 208);
            this.pnlImportedReminders.TabIndex = 81;
            this.pnlImportedReminders.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlImportedReminders_ControlRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 85;
            this.label1.Text = "Import";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 86;
            this.label3.Text = "Export";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pnlIntro
            // 
            this.pnlIntro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlIntro.Controls.Add(this.pictureBox2);
            this.pnlIntro.Controls.Add(this.label6);
            this.pnlIntro.Controls.Add(this.pictureBox1);
            this.pnlIntro.Controls.Add(this.label5);
            this.pnlIntro.Controls.Add(this.label4);
            this.pnlIntro.Location = new System.Drawing.Point(6, 64);
            this.pnlIntro.Name = "pnlIntro";
            this.pnlIntro.Size = new System.Drawing.Size(442, 208);
            this.pnlIntro.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 30);
            this.label5.TabIndex = 88;
            this.label5.Text = "Reminders can be imported and exported here\r\nExporting reminders will give a .rem" +
    "indme file.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 24);
            this.label4.TabIndex = 87;
            this.label4.Text = "Backup / import Reminders";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(397, 30);
            this.label6.TabIndex = 90;
            this.label6.Text = "The .remindme files can be imported by pressing \"Import\"\r\nor by simply double-cli" +
    "cking them";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RemindMe.Properties.Resources.RemindMeImport;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(370, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 58);
            this.pictureBox2.TabIndex = 91;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.remindme_backup_image;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(8, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 26);
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // pbExport
            // 
            this.pbExport.BackgroundImage = global::RemindMe.Properties.Resources.ExportIcon;
            this.pbExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExport.Location = new System.Drawing.Point(11, 3);
            this.pbExport.Name = "pbExport";
            this.pbExport.Size = new System.Drawing.Size(40, 40);
            this.pbExport.TabIndex = 84;
            this.pbExport.TabStop = false;
            this.pbExport.Click += new System.EventHandler(this.pbExport_Click);
            // 
            // pbImport
            // 
            this.pbImport.BackgroundImage = global::RemindMe.Properties.Resources.ImportIcon;
            this.pbImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImport.Location = new System.Drawing.Point(62, 3);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(40, 40);
            this.pbImport.TabIndex = 83;
            this.pbImport.TabStop = false;
            this.pbImport.Click += new System.EventHandler(this.pbImport_Click);
            // 
            // pbClearPanel
            // 
            this.pbClearPanel.BackgroundImage = global::RemindMe.Properties.Resources.red_x4;
            this.pbClearPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClearPanel.Location = new System.Drawing.Point(429, 66);
            this.pbClearPanel.Name = "pbClearPanel";
            this.pbClearPanel.Size = new System.Drawing.Size(18, 18);
            this.pbClearPanel.TabIndex = 82;
            this.pbClearPanel.TabStop = false;
            this.pbClearPanel.Visible = false;
            this.pbClearPanel.Click += new System.EventHandler(this.pbClearPanel_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStatus.Location = new System.Drawing.Point(7, 276);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(20, 20);
            this.pbStatus.TabIndex = 80;
            this.pbStatus.TabStop = false;
            // 
            // UCImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pnlIntro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbExport);
            this.Controls.Add(this.pbImport);
            this.Controls.Add(this.pbClearPanel);
            this.Controls.Add(this.pnlImportedReminders);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Name = "UCImportExport";
            this.Size = new System.Drawing.Size(462, 302);
            this.Load += new System.EventHandler(this.UCImportExport_Load);
            this.pnlIntro.ResumeLayout(false);
            this.pnlIntro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClearPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Panel pnlImportedReminders;
        private System.Windows.Forms.PictureBox pbClearPanel;
        private System.Windows.Forms.PictureBox pbImport;
        private System.Windows.Forms.PictureBox pbExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlIntro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
