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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReminderItem));
            this.lblReminderName = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnEdit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuImageButton();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.pbRepeat = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReminderName
            // 
            this.lblReminderName.AutoSize = true;
            this.lblReminderName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblReminderName.ForeColor = System.Drawing.Color.White;
            this.lblReminderName.Location = new System.Drawing.Point(10, 7);
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
            this.lblRepeat.Location = new System.Drawing.Point(193, 38);
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
            this.lblDate.Location = new System.Drawing.Point(43, 38);
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
            this.btnEdit.Location = new System.Drawing.Point(627, 33);
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
            this.btnDelete.Location = new System.Drawing.Point(591, 33);
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
            this.pbDate.Location = new System.Drawing.Point(15, 33);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(25, 25);
            this.pbDate.TabIndex = 112;
            this.pbDate.TabStop = false;
            // 
            // pbRepeat
            // 
            this.pbRepeat.BackgroundImage = global::RemindMe.Properties.Resources.Repeatwhite;
            this.pbRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRepeat.Location = new System.Drawing.Point(168, 33);
            this.pbRepeat.Name = "pbRepeat";
            this.pbRepeat.Size = new System.Drawing.Size(25, 25);
            this.pbRepeat.TabIndex = 109;
            this.pbRepeat.TabStop = false;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.lblReminderName);
            this.bunifuGradientPanel1.Controls.Add(this.btnEdit);
            this.bunifuGradientPanel1.Controls.Add(this.pbRepeat);
            this.bunifuGradientPanel1.Controls.Add(this.btnDelete);
            this.bunifuGradientPanel1.Controls.Add(this.lblRepeat);
            this.bunifuGradientPanel1.Controls.Add(this.lblDate);
            this.bunifuGradientPanel1.Controls.Add(this.pbDate);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Silver;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(666, 65);
            this.bunifuGradientPanel1.TabIndex = 116;
            // 
            // UCReminderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "UCReminderItem";
            this.Size = new System.Drawing.Size(666, 65);
            this.Load += new System.EventHandler(this.UCReminderItem_Load);
            this.MouseEnter += new System.EventHandler(this.UCReminderItem_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRepeat)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReminderName;
        private System.Windows.Forms.PictureBox pbRepeat;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pbDate;
        private Bunifu.Framework.UI.BunifuImageButton btnDelete;
        private Bunifu.Framework.UI.BunifuImageButton btnEdit;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
    }
}
