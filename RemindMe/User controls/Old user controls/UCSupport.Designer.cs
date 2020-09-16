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
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSendMessages = new System.Windows.Forms.Panel();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSend = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlMessageOverview = new System.Windows.Forms.Panel();
            this.btnSendMessage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnView = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.tbSubject = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.tbEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pnlSendMessages.SuspendLayout();
            this.pnlMessageOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.tbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbNote.ForeColor = System.Drawing.Color.Silver;
            this.tbNote.Location = new System.Drawing.Point(176, 210);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(314, 102);
            this.tbNote.TabIndex = 92;
            this.tbNote.Text = "Type your message here...";
            this.tbNote.Enter += new System.EventHandler(this.tbNote_Enter);
            this.tbNote.Leave += new System.EventHandler(this.tbNote_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 32);
            this.label3.TabIndex = 96;
            this.label3.Text = "Did you discover a bug? Do you want to suggest an improvement?\r\nOr do you wish to" +
    " submit something else? This is where you can do that.";
            // 
            // pnlSendMessages
            // 
            this.pnlSendMessages.Controls.Add(this.tbEmail);
            this.pnlSendMessages.Controls.Add(this.tbSubject);
            this.pnlSendMessages.Controls.Add(this.btnBack);
            this.pnlSendMessages.Controls.Add(this.label3);
            this.pnlSendMessages.Controls.Add(this.btnSend);
            this.pnlSendMessages.Controls.Add(this.tbNote);
            this.pnlSendMessages.Location = new System.Drawing.Point(0, 0);
            this.pnlSendMessages.Name = "pnlSendMessages";
            this.pnlSendMessages.Size = new System.Drawing.Size(666, 436);
            this.pnlSendMessages.TabIndex = 97;
            // 
            // btnBack
            // 
            this.btnBack.Activecolor = System.Drawing.Color.DimGray;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 5;
            this.btnBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnBack.ButtonText = "    Back to messages";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DisabledColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBack.Iconimage = global::RemindMe.Properties.Resources.Arrow_back1;
            this.btnBack.Iconimage_right = null;
            this.btnBack.Iconimage_right_Selected = null;
            this.btnBack.Iconimage_Selected = null;
            this.btnBack.IconMarginLeft = 0;
            this.btnBack.IconMarginRight = 0;
            this.btnBack.IconRightVisible = true;
            this.btnBack.IconRightZoom = 0D;
            this.btnBack.IconVisible = true;
            this.btnBack.IconZoom = 50D;
            this.btnBack.IsTab = false;
            this.btnBack.Location = new System.Drawing.Point(309, 318);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBack.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(181, 39);
            this.btnBack.TabIndex = 97;
            this.btnBack.Text = "    Back to messages";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Textcolor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.btnSend.Iconimage = global::RemindMe.Properties.Resources.sendmessage;
            this.btnSend.Iconimage_right = null;
            this.btnSend.Iconimage_right_Selected = null;
            this.btnSend.Iconimage_Selected = null;
            this.btnSend.IconMarginLeft = 0;
            this.btnSend.IconMarginRight = 0;
            this.btnSend.IconRightVisible = true;
            this.btnSend.IconRightZoom = 0D;
            this.btnSend.IconVisible = true;
            this.btnSend.IconZoom = 35D;
            this.btnSend.IsTab = false;
            this.btnSend.Location = new System.Drawing.Point(176, 318);
            this.btnSend.Name = "btnSend";
            this.btnSend.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSend.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSend.selected = false;
            this.btnSend.Size = new System.Drawing.Size(127, 39);
            this.btnSend.TabIndex = 93;
            this.btnSend.Text = "    Send";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Textcolor = System.Drawing.Color.White;
            this.btnSend.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlMessageOverview
            // 
            this.pnlMessageOverview.Controls.Add(this.btnSendMessage);
            this.pnlMessageOverview.Controls.Add(this.btnView);
            this.pnlMessageOverview.Controls.Add(this.lvMessages);
            this.pnlMessageOverview.Controls.Add(this.label4);
            this.pnlMessageOverview.Location = new System.Drawing.Point(667, 0);
            this.pnlMessageOverview.Name = "pnlMessageOverview";
            this.pnlMessageOverview.Size = new System.Drawing.Size(666, 436);
            this.pnlMessageOverview.TabIndex = 98;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Activecolor = System.Drawing.Color.DimGray;
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.BorderRadius = 5;
            this.btnSendMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSendMessage.ButtonText = "    Send a message";
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.DisabledColor = System.Drawing.Color.Gray;
            this.btnSendMessage.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSendMessage.Iconimage = global::RemindMe.Properties.Resources.sendmessage;
            this.btnSendMessage.Iconimage_right = null;
            this.btnSendMessage.Iconimage_right_Selected = null;
            this.btnSendMessage.Iconimage_Selected = null;
            this.btnSendMessage.IconMarginLeft = 0;
            this.btnSendMessage.IconMarginRight = 0;
            this.btnSendMessage.IconRightVisible = true;
            this.btnSendMessage.IconRightZoom = 0D;
            this.btnSendMessage.IconVisible = true;
            this.btnSendMessage.IconZoom = 35D;
            this.btnSendMessage.IsTab = false;
            this.btnSendMessage.Location = new System.Drawing.Point(169, 348);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendMessage.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnSendMessage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSendMessage.selected = false;
            this.btnSendMessage.Size = new System.Drawing.Size(168, 39);
            this.btnSendMessage.TabIndex = 98;
            this.btnSendMessage.Text = "    Send a message";
            this.btnSendMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMessage.Textcolor = System.Drawing.Color.White;
            this.btnSendMessage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // btnView
            // 
            this.btnView.Activecolor = System.Drawing.Color.DimGray;
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnView.BorderRadius = 5;
            this.btnView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnView.ButtonText = "    View";
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.DisabledColor = System.Drawing.Color.Gray;
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Iconcolor = System.Drawing.Color.Transparent;
            this.btnView.Iconimage = global::RemindMe.Properties.Resources.whiteeye;
            this.btnView.Iconimage_right = null;
            this.btnView.Iconimage_right_Selected = null;
            this.btnView.Iconimage_Selected = null;
            this.btnView.IconMarginLeft = 0;
            this.btnView.IconMarginRight = 0;
            this.btnView.IconRightVisible = true;
            this.btnView.IconRightZoom = 0D;
            this.btnView.IconVisible = true;
            this.btnView.IconZoom = 50D;
            this.btnView.IsTab = false;
            this.btnView.Location = new System.Drawing.Point(23, 348);
            this.btnView.Name = "btnView";
            this.btnView.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnView.OnHoverTextColor = System.Drawing.Color.White;
            this.btnView.selected = false;
            this.btnView.Size = new System.Drawing.Size(140, 39);
            this.btnView.TabIndex = 97;
            this.btnView.Text = "    View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Textcolor = System.Drawing.Color.White;
            this.btnView.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // lvMessages
            // 
            this.lvMessages.BackColor = System.Drawing.Color.DimGray;
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMessage});
            this.lvMessages.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMessages.ForeColor = System.Drawing.Color.White;
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.HideSelection = false;
            this.lvMessages.Location = new System.Drawing.Point(23, 62);
            this.lvMessages.MultiSelect = false;
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(618, 280);
            this.lvMessages.TabIndex = 98;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message";
            this.chMessage.Width = 580;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(156, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(401, 32);
            this.label4.TabIndex = 97;
            this.label4.Text = "Here you can revisit the messages sent by the RemindMe developer\r\n               " +
    "                In case you want to read them again";
            // 
            // tbSubject
            // 
            this.tbSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSubject.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubject.ForeColor = System.Drawing.Color.White;
            this.tbSubject.HintForeColor = System.Drawing.Color.DarkGray;
            this.tbSubject.HintText = "Subject";
            this.tbSubject.isPassword = false;
            this.tbSubject.LineFocusedColor = System.Drawing.Color.White;
            this.tbSubject.LineIdleColor = System.Drawing.Color.Silver;
            this.tbSubject.LineMouseHoverColor = System.Drawing.Color.White;
            this.tbSubject.LineThickness = 3;
            this.tbSubject.Location = new System.Drawing.Point(176, 112);
            this.tbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(314, 33);
            this.tbSubject.TabIndex = 113;
            this.tbSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSubject.Enter += new System.EventHandler(this.tbSubject_Enter);
            this.tbSubject.Leave += new System.EventHandler(this.tbSubject_Leave);
            // 
            // tbEmail
            // 
            this.tbEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.ForeColor = System.Drawing.Color.White;
            this.tbEmail.HintForeColor = System.Drawing.Color.DarkGray;
            this.tbEmail.HintText = "(Optional) E-mail";
            this.tbEmail.isPassword = false;
            this.tbEmail.LineFocusedColor = System.Drawing.Color.White;
            this.tbEmail.LineIdleColor = System.Drawing.Color.Silver;
            this.tbEmail.LineMouseHoverColor = System.Drawing.Color.White;
            this.tbEmail.LineThickness = 3;
            this.tbEmail.Location = new System.Drawing.Point(176, 157);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(313, 33);
            this.tbEmail.TabIndex = 114;
            this.tbEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // UCSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pnlMessageOverview);
            this.Controls.Add(this.pnlSendMessages);
            this.Name = "UCSupport";
            this.Size = new System.Drawing.Size(1332, 436);
            this.VisibleChanged += new System.EventHandler(this.UCSupport_VisibleChanged);
            this.pnlSendMessages.ResumeLayout(false);
            this.pnlSendMessages.PerformLayout();
            this.pnlMessageOverview.ResumeLayout(false);
            this.pnlMessageOverview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox tbNote;
        private Bunifu.Framework.UI.BunifuFlatButton btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSendMessages;
        private System.Windows.Forms.Panel pnlMessageOverview;
        private Bunifu.Framework.UI.BunifuFlatButton btnView;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader chMessage;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnSendMessage;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbEmail;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbSubject;
    }
}
