namespace RemindMe
{
    partial class MUCSupport
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
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tbSubject = new MaterialSkin.Controls.MaterialTextBox();
            this.tbEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.tbNote = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(137, 54);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(501, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Did you discover a bug? Do you want to suggest an improvement?\r\n\r\n\r\n";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(136, 76);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(511, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Or do you wish to submit something else? This is where you can do that.";
            // 
            // tbSubject
            // 
            this.tbSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSubject.Depth = 0;
            this.tbSubject.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbSubject.Hint = "Subject";
            this.tbSubject.Location = new System.Drawing.Point(139, 146);
            this.tbSubject.MaxLength = 100;
            this.tbSubject.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSubject.Multiline = false;
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(245, 50);
            this.tbSubject.TabIndex = 1;
            this.tbSubject.Text = "";
            this.tbSubject.Enter += new System.EventHandler(this.tbSubject_Enter);
            this.tbSubject.Leave += new System.EventHandler(this.tbSubject_Leave);
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEmail.Depth = 0;
            this.tbEmail.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbEmail.Hint = "(Optional) E-mail address";
            this.tbEmail.Location = new System.Drawing.Point(390, 146);
            this.tbEmail.MaxLength = 100;
            this.tbEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.tbEmail.Multiline = false;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(245, 50);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.Text = "";
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // tbNote
            // 
            this.tbNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNote.Depth = 0;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbNote.Hint = "";
            this.tbNote.Location = new System.Drawing.Point(140, 202);
            this.tbNote.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(498, 167);
            this.tbNote.TabIndex = 3;
            this.tbNote.Text = "Type your message here...";
            this.tbNote.Enter += new System.EventHandler(this.tbNote_Enter);
            this.tbNote.Leave += new System.EventHandler(this.tbNote_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.tbSubject);
            this.panel1.Controls.Add(this.tbNote);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 498);
            this.panel1.TabIndex = 129;
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend.Depth = 0;
            this.btnSend.DrawShadows = true;
            this.btnSend.HighEmphasis = true;
            this.btnSend.Icon = global::RemindMe.Properties.Resources.sendmessage;
            this.btnSend.Location = new System.Drawing.Point(140, 378);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(164, 35);
            this.btnSend.TabIndex = 127;
            this.btnSend.Text = "send message";
            this.btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend.UseAccentColor = false;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.materialLabel4);
            this.panel2.Controls.Add(this.materialListView1);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.materialButton2);
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.materialButton3);
            this.panel2.Location = new System.Drawing.Point(812, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 498);
            this.panel2.TabIndex = 130;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(42, 446);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(64, 19);
            this.materialLabel4.TabIndex = 130;
            this.materialLabel4.Text = "(unused)";
            // 
            // materialListView1
            // 
            this.materialListView1.AutoSizeTable = false;
            this.materialListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Depth = 0;
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HideSelection = false;
            this.materialListView1.Location = new System.Drawing.Point(140, 108);
            this.materialListView1.MinimumSize = new System.Drawing.Size(200, 100);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(471, 247);
            this.materialListView1.TabIndex = 129;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(137, 54);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(474, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Here you can revisit the messages sent by the RemindMe developer";
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Depth = 0;
            this.materialButton2.DrawShadows = true;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::RemindMe.Properties.Resources.sendmessage;
            this.materialButton2.Location = new System.Drawing.Point(281, 378);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(214, 35);
            this.materialButton2.TabIndex = 128;
            this.materialButton2.Text = "send a message";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(138, 76);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(257, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "in case you want to read them again";
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSize = false;
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Depth = 0;
            this.materialButton3.DrawShadows = true;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = global::RemindMe.Properties.Resources.whiteeye;
            this.materialButton3.Location = new System.Drawing.Point(140, 378);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.Size = new System.Drawing.Size(133, 35);
            this.materialButton3.TabIndex = 127;
            this.materialButton3.Text = "View";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // MUCSupport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MUCSupport";
            this.Size = new System.Drawing.Size(806, 498);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox tbSubject;
        private MaterialSkin.Controls.MaterialTextBox tbEmail;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbNote;
        private MaterialSkin.Controls.MaterialButton btnSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}
