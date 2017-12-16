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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSendErrorMessage = new System.Windows.Forms.Panel();
            this.lblShowDetails = new System.Windows.Forms.Label();
            this.lblCouldYouShare = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.pbShowDetails = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbMinimizeApplication = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.pbErrorIcon = new System.Windows.Forms.PictureBox();
            this.pnlSendErrorMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aww Damn! An error has occured";
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
            // tbError
            // 
            this.tbError.BackColor = System.Drawing.Color.DimGray;
            this.tbError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbError.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbError.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbError.ForeColor = System.Drawing.Color.White;
            this.tbError.Location = new System.Drawing.Point(5, 219);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ReadOnly = true;
            this.tbError.Size = new System.Drawing.Size(428, 95);
            this.tbError.TabIndex = 100;
            this.tbError.Enter += new System.EventHandler(this.tbError_Enter);
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.DimGray;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbNote.ForeColor = System.Drawing.Color.White;
            this.tbNote.Location = new System.Drawing.Point(3, 20);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(423, 93);
            this.tbNote.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 15);
            this.label2.TabIndex = 102;
            this.label2.Text = "Please describe what happened as detailed as possible";
            // 
            // pnlSendErrorMessage
            // 
            this.pnlSendErrorMessage.Controls.Add(this.btnClose);
            this.pnlSendErrorMessage.Controls.Add(this.label2);
            this.pnlSendErrorMessage.Controls.Add(this.btnSubmit);
            this.pnlSendErrorMessage.Controls.Add(this.tbNote);
            this.pnlSendErrorMessage.Location = new System.Drawing.Point(13, 365);
            this.pnlSendErrorMessage.Name = "pnlSendErrorMessage";
            this.pnlSendErrorMessage.Size = new System.Drawing.Size(435, 151);
            this.pnlSendErrorMessage.TabIndex = 104;
            this.pnlSendErrorMessage.Visible = false;
            this.pnlSendErrorMessage.SizeChanged += new System.EventHandler(this.pnlSendErrorMessage_SizeChanged);
            // 
            // lblShowDetails
            // 
            this.lblShowDetails.AutoSize = true;
            this.lblShowDetails.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lblShowDetails.ForeColor = System.Drawing.Color.White;
            this.lblShowDetails.Location = new System.Drawing.Point(42, 165);
            this.lblShowDetails.Name = "lblShowDetails";
            this.lblShowDetails.Size = new System.Drawing.Size(88, 13);
            this.lblShowDetails.TabIndex = 106;
            this.lblShowDetails.Text = "Show details";
            // 
            // lblCouldYouShare
            // 
            this.lblCouldYouShare.AutoSize = true;
            this.lblCouldYouShare.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblCouldYouShare.ForeColor = System.Drawing.Color.White;
            this.lblCouldYouShare.Location = new System.Drawing.Point(9, 84);
            this.lblCouldYouShare.Name = "lblCouldYouShare";
            this.lblCouldYouShare.Size = new System.Drawing.Size(323, 19);
            this.lblCouldYouShare.TabIndex = 109;
            this.lblCouldYouShare.Text = "Could you report how this happened?";
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(402, 157);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(42, 25);
            this.btnNo.TabIndex = 108;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(359, 157);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(42, 25);
            this.btnYes.TabIndex = 107;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // pbShowDetails
            // 
            this.pbShowDetails.BackgroundImage = global::RemindMe.Properties.Resources._2arrows;
            this.pbShowDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbShowDetails.Location = new System.Drawing.Point(6, 152);
            this.pbShowDetails.Name = "pbShowDetails";
            this.pbShowDetails.Size = new System.Drawing.Size(30, 30);
            this.pbShowDetails.TabIndex = 105;
            this.pbShowDetails.TabStop = false;
            this.pbShowDetails.Click += new System.EventHandler(this.pbShowDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(291, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 25);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(350, 114);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(76, 25);
            this.btnSubmit.TabIndex = 103;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            // pbErrorIcon
            // 
            this.pbErrorIcon.BackgroundImage = global::RemindMe.Properties.Resources.err;
            this.pbErrorIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbErrorIcon.Location = new System.Drawing.Point(5, 28);
            this.pbErrorIcon.Name = "pbErrorIcon";
            this.pbErrorIcon.Size = new System.Drawing.Size(35, 35);
            this.pbErrorIcon.TabIndex = 0;
            this.pbErrorIcon.TabStop = false;
            // 
            // ErrorPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(447, 180);
            this.Controls.Add(this.lblCouldYouShare);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblShowDetails);
            this.Controls.Add(this.pbShowDetails);
            this.Controls.Add(this.pnlSendErrorMessage);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbMinimizeApplication);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbErrorIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorPopup_FormClosing);
            this.Load += new System.EventHandler(this.ErrorPopup_Load);
            this.SizeChanged += new System.EventHandler(this.ErrorPopup_SizeChanged);
            this.pnlSendErrorMessage.ResumeLayout(false);
            this.pnlSendErrorMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbErrorIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbMinimizeApplication;
        private System.Windows.Forms.TextBox tbError;
        public System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlSendErrorMessage;
        private System.Windows.Forms.PictureBox pbShowDetails;
        private System.Windows.Forms.Label lblShowDetails;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblCouldYouShare;
        private System.Windows.Forms.Button btnClose;
    }
}