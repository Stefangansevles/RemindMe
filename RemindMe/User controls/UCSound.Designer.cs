namespace RemindMe
{
    partial class UCSound
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvSoundFiles = new System.Windows.Forms.ListView();
            this.chSoundFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlfooter = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuSwitch1 = new Bunifu.Framework.UI.BunifuSwitch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.btnPreview = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRemoveFiles = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddFiles = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlfooter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage sound effects";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 58);
            this.panel1.TabIndex = 2;
            // 
            // lvSoundFiles
            // 
            this.lvSoundFiles.AllowDrop = true;
            this.lvSoundFiles.BackColor = System.Drawing.Color.DimGray;
            this.lvSoundFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSoundFile});
            this.lvSoundFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSoundFiles.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lvSoundFiles.ForeColor = System.Drawing.Color.White;
            this.lvSoundFiles.FullRowSelect = true;
            this.lvSoundFiles.Location = new System.Drawing.Point(0, 0);
            this.lvSoundFiles.Name = "lvSoundFiles";
            this.lvSoundFiles.Size = new System.Drawing.Size(666, 338);
            this.lvSoundFiles.TabIndex = 4;
            this.lvSoundFiles.UseCompatibleStateImageBehavior = false;
            this.lvSoundFiles.View = System.Windows.Forms.View.Details;
            this.lvSoundFiles.DoubleClick += new System.EventHandler(this.lvSoundFiles_DoubleClick);
            this.lvSoundFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvSoundFiles_KeyUp);
            // 
            // chSoundFile
            // 
            this.chSoundFile.Text = "Sound File";
            this.chSoundFile.Width = 635;
            // 
            // pnlfooter
            // 
            this.pnlfooter.Controls.Add(this.btnPreview);
            this.pnlfooter.Controls.Add(this.btnRemoveFiles);
            this.pnlfooter.Controls.Add(this.label2);
            this.pnlfooter.Controls.Add(this.bunifuSwitch1);
            this.pnlfooter.Controls.Add(this.btnAddFiles);
            this.pnlfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlfooter.Location = new System.Drawing.Point(0, 396);
            this.pnlfooter.Name = "pnlfooter";
            this.pnlfooter.Size = new System.Drawing.Size(666, 40);
            this.pnlfooter.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(514, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Show File Path";
            // 
            // bunifuSwitch1
            // 
            this.bunifuSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuSwitch1.BorderRadius = 0;
            this.bunifuSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitch1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch1.Location = new System.Drawing.Point(610, 18);
            this.bunifuSwitch1.Name = "bunifuSwitch1";
            this.bunifuSwitch1.Oncolor = System.Drawing.Color.Black;
            this.bunifuSwitch1.Onoffcolor = System.Drawing.Color.DarkGray;
            this.bunifuSwitch1.Size = new System.Drawing.Size(51, 19);
            this.bunifuSwitch1.TabIndex = 7;
            this.bunifuSwitch1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSwitch1.Value = true;
            this.bunifuSwitch1.Click += new System.EventHandler(this.bunifuSwitch1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvSoundFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 338);
            this.panel2.TabIndex = 8;
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // btnPreview
            // 
            this.btnPreview.Activecolor = System.Drawing.Color.DimGray;
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreview.BorderRadius = 5;
            this.btnPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPreview.ButtonText = "   Preview";
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DisabledColor = System.Drawing.Color.Gray;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPreview.Iconimage = global::RemindMe.Properties.Resources.Play;
            this.btnPreview.Iconimage_right = null;
            this.btnPreview.Iconimage_right_Selected = null;
            this.btnPreview.Iconimage_Selected = null;
            this.btnPreview.IconMarginLeft = 0;
            this.btnPreview.IconMarginRight = 0;
            this.btnPreview.IconRightVisible = true;
            this.btnPreview.IconRightZoom = 0D;
            this.btnPreview.IconVisible = true;
            this.btnPreview.IconZoom = 50D;
            this.btnPreview.IsTab = false;
            this.btnPreview.Location = new System.Drawing.Point(334, 0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPreview.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnPreview.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPreview.selected = false;
            this.btnPreview.Size = new System.Drawing.Size(167, 40);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Textcolor = System.Drawing.Color.White;
            this.btnPreview.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Activecolor = System.Drawing.Color.DimGray;
            this.btnRemoveFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFiles.BorderRadius = 5;
            this.btnRemoveFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRemoveFiles.ButtonText = "   Delete selected";
            this.btnRemoveFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFiles.DisabledColor = System.Drawing.Color.Gray;
            this.btnRemoveFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemoveFiles.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFiles.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRemoveFiles.Iconimage = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveFiles.Iconimage_right = null;
            this.btnRemoveFiles.Iconimage_right_Selected = null;
            this.btnRemoveFiles.Iconimage_Selected = null;
            this.btnRemoveFiles.IconMarginLeft = 0;
            this.btnRemoveFiles.IconMarginRight = 0;
            this.btnRemoveFiles.IconRightVisible = true;
            this.btnRemoveFiles.IconRightZoom = 0D;
            this.btnRemoveFiles.IconVisible = true;
            this.btnRemoveFiles.IconZoom = 50D;
            this.btnRemoveFiles.IsTab = false;
            this.btnRemoveFiles.Location = new System.Drawing.Point(167, 0);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveFiles.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnRemoveFiles.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRemoveFiles.selected = false;
            this.btnRemoveFiles.Size = new System.Drawing.Size(167, 40);
            this.btnRemoveFiles.TabIndex = 5;
            this.btnRemoveFiles.Text = "   Delete selected";
            this.btnRemoveFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFiles.Textcolor = System.Drawing.Color.White;
            this.btnRemoveFiles.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Activecolor = System.Drawing.Color.DimGray;
            this.btnAddFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddFiles.BorderRadius = 5;
            this.btnAddFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddFiles.ButtonText = "    Add file(s)";
            this.btnAddFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFiles.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddFiles.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFiles.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddFiles.Iconimage = global::RemindMe.Properties.Resources.Plus_white;
            this.btnAddFiles.Iconimage_right = null;
            this.btnAddFiles.Iconimage_right_Selected = null;
            this.btnAddFiles.Iconimage_Selected = null;
            this.btnAddFiles.IconMarginLeft = 0;
            this.btnAddFiles.IconMarginRight = 0;
            this.btnAddFiles.IconRightVisible = true;
            this.btnAddFiles.IconRightZoom = 0D;
            this.btnAddFiles.IconVisible = true;
            this.btnAddFiles.IconZoom = 50D;
            this.btnAddFiles.IsTab = false;
            this.btnAddFiles.Location = new System.Drawing.Point(0, 0);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddFiles.OnHovercolor = System.Drawing.Color.DimGray;
            this.btnAddFiles.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddFiles.selected = false;
            this.btnAddFiles.Size = new System.Drawing.Size(167, 40);
            this.btnAddFiles.TabIndex = 3;
            this.btnAddFiles.Text = "    Add file(s)";
            this.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.Textcolor = System.Drawing.Color.White;
            this.btnAddFiles.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RemindMe.Properties.Resources.Sound_white;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(605, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 58);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // UCSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlfooter);
            this.Controls.Add(this.panel1);
            this.Name = "UCSound";
            this.Size = new System.Drawing.Size(666, 436);
            this.Load += new System.EventHandler(this.UCSound_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlfooter.ResumeLayout(false);
            this.pnlfooter.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnRemoveFiles;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddFiles;
        public System.Windows.Forms.ListView lvSoundFiles;
        private System.Windows.Forms.ColumnHeader chSoundFile;
        private System.Windows.Forms.Panel pnlfooter;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSwitch bunifuSwitch1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuFlatButton btnPreview;
        private System.Windows.Forms.Timer tmrMusic;
    }
}
