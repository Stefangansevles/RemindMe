namespace RemindMe
{
    partial class UCSupport
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
            this.tbSubject = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmail = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.tmrSendMail = new System.Windows.Forms.Timer(this.components);
            this.tmrAllowMail = new System.Windows.Forms.Timer(this.components);
            this.lblSending = new System.Windows.Forms.Label();
            this.pbSending = new System.Windows.Forms.PictureBox();
            this.btnSend = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbSending)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSubject
            // 
            this.tbSubject.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.tbSubject.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSubject.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.tbSubject.BorderThickness = 3;
            this.tbSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSubject.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubject.ForeColor = System.Drawing.Color.White;
            this.tbSubject.isPassword = false;
            this.tbSubject.Location = new System.Drawing.Point(182, 45);
            this.tbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(314, 28);
            this.tbSubject.TabIndex = 0;
            this.tbSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subject:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "(Optional) E-mail:";
            // 
            // tbEmail
            // 
            this.tbEmail.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.tbEmail.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEmail.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.tbEmail.BorderThickness = 3;
            this.tbEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEmail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.ForeColor = System.Drawing.Color.White;
            this.tbEmail.isPassword = false;
            this.tbEmail.Location = new System.Drawing.Point(182, 77);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(314, 28);
            this.tbEmail.TabIndex = 3;
            this.tbEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.DimGray;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbNote.ForeColor = System.Drawing.Color.White;
            this.tbNote.Location = new System.Drawing.Point(182, 124);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(314, 102);
            this.tbNote.TabIndex = 92;
            // 
            // tmrSendMail
            // 
            this.tmrSendMail.Interval = 1000;
            this.tmrSendMail.Tick += new System.EventHandler(this.tmrSendMail_Tick);
            // 
            // tmrAllowMail
            // 
            this.tmrAllowMail.Interval = 10000;
            this.tmrAllowMail.Tick += new System.EventHandler(this.tmrAllowMail_Tick);
            // 
            // lblSending
            // 
            this.lblSending.AutoSize = true;
            this.lblSending.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSending.ForeColor = System.Drawing.Color.White;
            this.lblSending.Location = new System.Drawing.Point(34, 414);
            this.lblSending.Name = "lblSending";
            this.lblSending.Size = new System.Drawing.Size(85, 19);
            this.lblSending.TabIndex = 95;
            this.lblSending.Text = "Sending...";
            this.lblSending.Visible = false;
            // 
            // pbSending
            // 
            this.pbSending.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSending.Image = global::RemindMe.Properties.Resources.loadingGif;
            this.pbSending.Location = new System.Drawing.Point(3, 403);
            this.pbSending.Name = "pbSending";
            this.pbSending.Size = new System.Drawing.Size(30, 30);
            this.pbSending.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSending.TabIndex = 94;
            this.pbSending.TabStop = false;
            this.pbSending.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.Activecolor = System.Drawing.Color.DimGray;
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.BorderRadius = 5;
            this.btnSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSend.ButtonText = "    Send";
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.DisabledColor = System.Drawing.Color.Gray;
            this.btnSend.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSend.Iconimage = global::RemindMe.Properties.Resources.Emailwhite;
            this.btnSend.Iconimage_right = null;
            this.btnSend.Iconimage_right_Selected = null;
            this.btnSend.Iconimage_Selected = null;
            this.btnSend.IconMarginLeft = 0;
            this.btnSend.IconMarginRight = 0;
            this.btnSend.IconRightVisible = true;
            this.btnSend.IconRightZoom = 0D;
            this.btnSend.IconVisible = true;
            this.btnSend.IconZoom = 50D;
            this.btnSend.IsTab = false;
            this.btnSend.Location = new System.Drawing.Point(182, 232);
            this.btnSend.Name = "btnSend";
            this.btnSend.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSend.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSend.selected = false;
            this.btnSend.Size = new System.Drawing.Size(140, 39);
            this.btnSend.TabIndex = 93;
            this.btnSend.Text = "    Send";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Textcolor = System.Drawing.Color.White;
            this.btnSend.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // UCSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.lblSending);
            this.Controls.Add(this.pbSending);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSubject);
            this.Name = "UCSupport";
            this.Size = new System.Drawing.Size(666, 436);
            ((System.ComponentModel.ISupportInitialize)(this.pbSending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMetroTextbox tbSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox tbEmail;
        public System.Windows.Forms.TextBox tbNote;
        private Bunifu.Framework.UI.BunifuFlatButton btnSend;
        private System.Windows.Forms.Timer tmrSendMail;
        private System.Windows.Forms.Timer tmrAllowMail;
        private System.Windows.Forms.PictureBox pbSending;
        private System.Windows.Forms.Label lblSending;
    }
}
