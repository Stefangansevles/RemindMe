namespace RemindMe
{
    partial class UCMusic
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
            this.lvSoundFiles = new System.Windows.Forms.ListView();
            this.chSound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.pbRemoveSounds = new System.Windows.Forms.PictureBox();
            this.pbAddSounds = new System.Windows.Forms.PictureBox();
            this.cbShowFilePath = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveSounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSounds)).BeginInit();
            this.SuspendLayout();
            // 
            // lvSoundFiles
            // 
            this.lvSoundFiles.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvSoundFiles.BackColor = System.Drawing.Color.DimGray;
            this.lvSoundFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSound});
            this.lvSoundFiles.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.lvSoundFiles.ForeColor = System.Drawing.Color.White;
            this.lvSoundFiles.FullRowSelect = true;
            this.lvSoundFiles.Location = new System.Drawing.Point(5, 57);
            this.lvSoundFiles.Name = "lvSoundFiles";
            this.lvSoundFiles.Size = new System.Drawing.Size(452, 174);
            this.lvSoundFiles.TabIndex = 13;
            this.lvSoundFiles.UseCompatibleStateImageBehavior = false;
            this.lvSoundFiles.View = System.Windows.Forms.View.Details;
            // 
            // chSound
            // 
            this.chSound.Text = "Sound File";
            this.chSound.Width = 420;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 34);
            this.label2.TabIndex = 16;
            this.label2.Text = "These are the popup sounds you\'ve added to RemindMe.\r\nYou can add or remove them " +
    "here";
            // 
            // pbRemoveSounds
            // 
            this.pbRemoveSounds.BackColor = System.Drawing.Color.White;
            this.pbRemoveSounds.BackgroundImage = global::RemindMe.Properties.Resources.minus_xxl;
            this.pbRemoveSounds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRemoveSounds.Location = new System.Drawing.Point(413, 60);
            this.pbRemoveSounds.Name = "pbRemoveSounds";
            this.pbRemoveSounds.Size = new System.Drawing.Size(23, 20);
            this.pbRemoveSounds.TabIndex = 15;
            this.pbRemoveSounds.TabStop = false;
            this.pbRemoveSounds.Click += new System.EventHandler(this.pbRemoveSounds_Click);
            // 
            // pbAddSounds
            // 
            this.pbAddSounds.BackColor = System.Drawing.Color.White;
            this.pbAddSounds.BackgroundImage = global::RemindMe.Properties.Resources.green_plus_add;
            this.pbAddSounds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAddSounds.Location = new System.Drawing.Point(384, 60);
            this.pbAddSounds.Name = "pbAddSounds";
            this.pbAddSounds.Size = new System.Drawing.Size(23, 20);
            this.pbAddSounds.TabIndex = 14;
            this.pbAddSounds.TabStop = false;
            this.pbAddSounds.Click += new System.EventHandler(this.pbAddSounds_Click);
            // 
            // cbShowFilePath
            // 
            this.cbShowFilePath.AutoSize = true;
            this.cbShowFilePath.BackColor = System.Drawing.Color.White;
            this.cbShowFilePath.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.cbShowFilePath.ForeColor = System.Drawing.Color.Black;
            this.cbShowFilePath.Location = new System.Drawing.Point(279, 62);
            this.cbShowFilePath.Name = "cbShowFilePath";
            this.cbShowFilePath.Size = new System.Drawing.Size(99, 18);
            this.cbShowFilePath.TabIndex = 17;
            this.cbShowFilePath.Text = "Show file path";
            this.cbShowFilePath.UseVisualStyleBackColor = false;
            this.cbShowFilePath.CheckedChanged += new System.EventHandler(this.cbShowFilePath_CheckedChanged);
            // 
            // UCMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbShowFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbRemoveSounds);
            this.Controls.Add(this.pbAddSounds);
            this.Controls.Add(this.lvSoundFiles);
            this.Name = "UCMusic";
            this.Size = new System.Drawing.Size(462, 302);
            this.Load += new System.EventHandler(this.UCMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveSounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRemoveSounds;
        private System.Windows.Forms.PictureBox pbAddSounds;
        private System.Windows.Forms.ListView lvSoundFiles;
        private System.Windows.Forms.ColumnHeader chSound;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox cbShowFilePath;
    }
}
