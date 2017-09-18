namespace RemindMe
{
    partial class ErrorPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorPopup));
            this.pbErrorIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenErrorLog = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbBottomBorder = new System.Windows.Forms.TextBox();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.tbRight = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // pbErrorIcon
            // 
            this.pbErrorIcon.BackgroundImage = global::RemindMe.Properties.Resources.err;
            this.pbErrorIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbErrorIcon.Location = new System.Drawing.Point(5, 28);
            this.pbErrorIcon.Name = "pbErrorIcon";
            this.pbErrorIcon.Size = new System.Drawing.Size(44, 38);
            this.pbErrorIcon.TabIndex = 0;
            this.pbErrorIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aww Damn! \r\nAn error has occured";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(371, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 25);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(8, 211);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(257, 15);
            this.lblDetails.TabIndex = 24;
            this.lblDetails.Text = "Click \"Error log\" for advanced details";
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Black;
            this.pbCloseApplication.BackgroundImage = global::RemindMe.Properties.Resources.redx;
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(425, 0);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 66;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(-15, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(463, 22);
            this.textBox1.TabIndex = 65;
            // 
            // btnOpenErrorLog
            // 
            this.btnOpenErrorLog.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenErrorLog.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnOpenErrorLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenErrorLog.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenErrorLog.ForeColor = System.Drawing.Color.White;
            this.btnOpenErrorLog.Location = new System.Drawing.Point(270, 203);
            this.btnOpenErrorLog.Name = "btnOpenErrorLog";
            this.btnOpenErrorLog.Size = new System.Drawing.Size(100, 25);
            this.btnOpenErrorLog.TabIndex = 67;
            this.btnOpenErrorLog.Text = "Error log";
            this.btnOpenErrorLog.UseVisualStyleBackColor = false;
            this.btnOpenErrorLog.Click += new System.EventHandler(this.btnOpenErrorLog_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.BackgroundImage = global::RemindMe.Properties.Resources.RemindMe1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 22);
            this.pictureBox4.TabIndex = 70;
            this.pictureBox4.TabStop = false;
            // 
            // pbMinimizeApplication
            // 
            this.pbMinimizeApplication.BackColor = System.Drawing.Color.Black;
            this.pbMinimizeApplication.BackgroundImage = global::RemindMe.Properties.Resources.min;
            this.pbMinimizeApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMinimizeApplication.Location = new System.Drawing.Point(402, 0);
            this.pbMinimizeApplication.Name = "pbMinimizeApplication";
            this.pbMinimizeApplication.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizeApplication.TabIndex = 69;
            this.pbMinimizeApplication.TabStop = false;
            this.pbMinimizeApplication.Click += new System.EventHandler(this.pbMinimizeApplication_Click);
            // 
            // tbError
            // 
            this.tbError.BackColor = System.Drawing.Color.DimGray;
            this.tbError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbError.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbError.ForeColor = System.Drawing.Color.White;
            this.tbError.Location = new System.Drawing.Point(7, 89);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ReadOnly = true;
            this.tbError.Size = new System.Drawing.Size(428, 95);
            this.tbError.TabIndex = 100;
            // 
            // tbBottomBorder
            // 
            this.tbBottomBorder.Location = new System.Drawing.Point(2, 230);
            this.tbBottomBorder.Multiline = true;
            this.tbBottomBorder.Name = "tbBottomBorder";
            this.tbBottomBorder.ReadOnly = true;
            this.tbBottomBorder.Size = new System.Drawing.Size(450, 1);
            this.tbBottomBorder.TabIndex = 113;
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(1, 22);
            this.tbLeft.Multiline = true;
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.ReadOnly = true;
            this.tbLeft.Size = new System.Drawing.Size(1, 210);
            this.tbLeft.TabIndex = 114;
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(445, 23);
            this.tbRight.Multiline = true;
            this.tbRight.Name = "tbRight";
            this.tbRight.ReadOnly = true;
            this.tbRight.Size = new System.Drawing.Size(1, 210);
            this.tbRight.TabIndex = 115;
            // 
            // ErrorPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(447, 231);
            this.Controls.Add(this.tbRight);
            this.Controls.Add(this.tbLeft);
            this.Controls.Add(this.tbBottomBorder);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.btnOpenErrorLog);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbErrorIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorPopup";
            this.Load += new System.EventHandler(this.ErrorPopup_Load);
            this.SizeChanged += new System.EventHandler(this.ErrorPopup_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbErrorIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenErrorLog;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.TextBox tbBottomBorder;
        private System.Windows.Forms.TextBox tbLeft;
        private System.Windows.Forms.TextBox tbRight;
    }
}