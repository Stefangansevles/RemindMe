namespace RemindMe
{
    partial class UCReminderItem
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
            this.lblReminderName = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnEdit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuImageButton();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.pbRepeat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReminderName
            // 
            this.lblReminderName.AutoSize = true;
            this.lblReminderName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblReminderName.ForeColor = System.Drawing.Color.White;
            this.lblReminderName.Location = new System.Drawing.Point(11, 6);
            this.lblReminderName.Name = "lblReminderName";
            this.lblReminderName.Size = new System.Drawing.Size(117, 17);
            this.lblReminderName.TabIndex = 108;
            this.lblReminderName.Text = "Reminder name";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRepeat.ForeColor = System.Drawing.Color.White;
            this.lblRepeat.Location = new System.Drawing.Point(194, 37);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(52, 16);
            this.lblRepeat.TabIndex = 110;
            this.lblRepeat.Text = "Weekly";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(44, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 16);
            this.lblDate.TabIndex = 113;
            this.lblDate.Text = "Date";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnEdit.Image = global::RemindMe.Properties.Resources.Edit_white;
            this.btnEdit.ImageActive = null;
            this.btnEdit.ImageLocation = "";
            this.btnEdit.Location = new System.Drawing.Point(589, 32);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 25);
            this.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEdit.TabIndex = 115;
            this.btnEdit.TabStop = false;
            this.btnEdit.Zoom = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::RemindMe.Properties.Resources.Bin_white;
            this.btnDelete.ImageActive = null;
            this.btnDelete.ImageLocation = "";
            this.btnDelete.Location = new System.Drawing.Point(553, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 114;
            this.btnDelete.TabStop = false;
            this.btnDelete.Zoom = 0;
            // 
            // pbDate
            // 
            this.pbDate.BackgroundImage = global::RemindMe.Properties.Resources.calendarWhite1;
            this.pbDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDate.ImageLocation = "";
            this.pbDate.Location = new System.Drawing.Point(16, 32);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(25, 25);
            this.pbDate.TabIndex = 112;
            this.pbDate.TabStop = false;
            // 
            // pbRepeat
            // 
            this.pbRepeat.BackgroundImage = global::RemindMe.Properties.Resources.Repeatwhite;
            this.pbRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRepeat.Location = new System.Drawing.Point(169, 32);
            this.pbRepeat.Name = "pbRepeat";
            this.pbRepeat.Size = new System.Drawing.Size(25, 25);
            this.pbRepeat.TabIndex = 109;
            this.pbRepeat.TabStop = false;
            // 
            // UCReminderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pbDate);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.pbRepeat);
            this.Controls.Add(this.lblReminderName);
            this.Name = "UCReminderItem";
            this.Size = new System.Drawing.Size(629, 65);
            this.Load += new System.EventHandler(this.UCReminderItem_Load);
            this.MouseEnter += new System.EventHandler(this.UCReminderItem_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReminderName;
        private System.Windows.Forms.PictureBox pbRepeat;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pbDate;
        private Bunifu.Framework.UI.BunifuImageButton btnDelete;
        private Bunifu.Framework.UI.BunifuImageButton btnEdit;
    }
}
