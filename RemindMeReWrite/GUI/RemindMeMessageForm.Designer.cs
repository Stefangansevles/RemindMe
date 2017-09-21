namespace RemindMe
{
    partial class RemindMeMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMeMessageForm));
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.DimGray;
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMessage.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.ForeColor = System.Drawing.Color.White;
            this.tbMessage.Location = new System.Drawing.Point(46, 10);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbMessage.Size = new System.Drawing.Size(192, 39);
            this.tbMessage.TabIndex = 111;
            this.tbMessage.Text = "";
            this.tbMessage.Enter += new System.EventHandler(this.tbMessage_Enter);
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Transparent;
            this.pbCloseApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCloseApplication.BackgroundImage")));
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(236, 2);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 110;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.TabIndex = 109;
            this.pictureBox5.TabStop = false;
            // 
            // RemindMeMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(260, 63);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemindMeMessageForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemindMeMessageForm_FormClosing);
            this.Load += new System.EventHandler(this.RemindMeMessageForm_Load);            
            this.VisibleChanged += new System.EventHandler(this.RemindMeMessageForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbMessage;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}