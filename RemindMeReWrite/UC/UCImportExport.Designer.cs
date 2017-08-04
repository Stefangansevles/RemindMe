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
            this.pbClearPanel = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbClearPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 24);
            this.label2.TabIndex = 76;
            this.label2.Text = "Backup / import Reminders";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(46, 68);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 16);
            this.lblStatus.TabIndex = 79;
            this.lblStatus.Text = " ";
            // 
            // pnlImportedReminders
            // 
            this.pnlImportedReminders.Location = new System.Drawing.Point(11, 87);
            this.pnlImportedReminders.Name = "pnlImportedReminders";
            this.pnlImportedReminders.Size = new System.Drawing.Size(442, 212);
            this.pnlImportedReminders.TabIndex = 81;
            this.pnlImportedReminders.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlImportedReminders_ControlRemoved);
            // 
            // pbClearPanel
            // 
            this.pbClearPanel.BackgroundImage = global::RemindMe.Properties.Resources.red_x4;
            this.pbClearPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClearPanel.Location = new System.Drawing.Point(432, 88);
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
            this.pbStatus.Location = new System.Drawing.Point(15, 59);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(25, 25);
            this.pbStatus.TabIndex = 80;
            this.pbStatus.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.Transparent;
            this.btnImport.Location = new System.Drawing.Point(144, 29);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(127, 23);
            this.btnImport.TabIndex = 78;
            this.btnImport.Text = "Import Reminders";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.Transparent;
            this.btnExport.Location = new System.Drawing.Point(11, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(127, 23);
            this.btnExport.TabIndex = 77;
            this.btnExport.Text = "Export Reminders";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UCImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pbClearPanel);
            this.Controls.Add(this.pnlImportedReminders);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Name = "UCImportExport";
            this.Size = new System.Drawing.Size(462, 302);
            this.Load += new System.EventHandler(this.UCImportExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClearPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Panel pnlImportedReminders;
        private System.Windows.Forms.PictureBox pbClearPanel;
    }
}
