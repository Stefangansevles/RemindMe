namespace RemindMe
{
    partial class MUCSound
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
            this.lvSoundFiles = new MaterialSkin.Controls.MaterialListView();
            this.chSoundFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.swFilePath = new MaterialSkin.Controls.MaterialSwitch();
            this.btnPreview = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveFiles = new MaterialSkin.Controls.MaterialButton();
            this.btnAddFiles = new MaterialSkin.Controls.MaterialButton();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSoundFiles
            // 
            this.lvSoundFiles.AllowDrop = true;
            this.lvSoundFiles.AutoSizeTable = false;
            this.lvSoundFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvSoundFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSoundFiles.CheckBoxes = true;
            this.lvSoundFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSoundFile});
            this.lvSoundFiles.Depth = 0;
            this.lvSoundFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvSoundFiles.FullRowSelect = true;
            this.lvSoundFiles.HideSelection = false;
            this.lvSoundFiles.Location = new System.Drawing.Point(0, 0);
            this.lvSoundFiles.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvSoundFiles.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvSoundFiles.MouseState = MaterialSkin.MouseState.OUT;
            this.lvSoundFiles.Name = "lvSoundFiles";
            this.lvSoundFiles.OwnerDraw = true;
            this.lvSoundFiles.Size = new System.Drawing.Size(806, 460);
            this.lvSoundFiles.TabIndex = 1;
            this.lvSoundFiles.UseCompatibleStateImageBehavior = false;
            this.lvSoundFiles.View = System.Windows.Forms.View.Details;
            this.lvSoundFiles.DoubleClick += new System.EventHandler(this.lvSoundFiles_DoubleClick);
            // 
            // chSoundFile
            // 
            this.chSoundFile.Text = "Sound File";
            this.chSoundFile.Width = 780;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.swFilePath);
            this.pnlFooter.Controls.Add(this.btnPreview);
            this.pnlFooter.Controls.Add(this.btnRemoveFiles);
            this.pnlFooter.Controls.Add(this.btnAddFiles);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 462);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(806, 36);
            this.pnlFooter.TabIndex = 2;
            // 
            // swFilePath
            // 
            this.swFilePath.AutoSize = true;
            this.swFilePath.Checked = true;
            this.swFilePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.swFilePath.Depth = 0;
            this.swFilePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.swFilePath.Location = new System.Drawing.Point(638, 0);
            this.swFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.swFilePath.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swFilePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.swFilePath.Name = "swFilePath";
            this.swFilePath.Ripple = true;
            this.swFilePath.Size = new System.Drawing.Size(168, 36);
            this.swFilePath.TabIndex = 127;
            this.swFilePath.Text = "Show file path  ";
            this.swFilePath.UseVisualStyleBackColor = true;
            this.swFilePath.Click += new System.EventHandler(this.bunifuSwitch1_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = false;
            this.btnPreview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreview.Depth = 0;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreview.DrawShadows = true;
            this.btnPreview.HighEmphasis = true;
            this.btnPreview.Icon = global::RemindMe.Properties.Resources.Play;
            this.btnPreview.Location = new System.Drawing.Point(340, 0);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreview.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(170, 36);
            this.btnPreview.TabIndex = 126;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreview.UseAccentColor = false;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.AutoSize = false;
            this.btnRemoveFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveFiles.Depth = 0;
            this.btnRemoveFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemoveFiles.DrawShadows = true;
            this.btnRemoveFiles.HighEmphasis = true;
            this.btnRemoveFiles.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnRemoveFiles.Location = new System.Drawing.Point(170, 0);
            this.btnRemoveFiles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveFiles.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(170, 36);
            this.btnRemoveFiles.TabIndex = 125;
            this.btnRemoveFiles.Text = "Delete selected";
            this.btnRemoveFiles.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveFiles.UseAccentColor = false;
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.AutoSize = false;
            this.btnAddFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddFiles.Depth = 0;
            this.btnAddFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddFiles.DrawShadows = true;
            this.btnAddFiles.HighEmphasis = true;
            this.btnAddFiles.Icon = global::RemindMe.Properties.Resources.Plus_white;
            this.btnAddFiles.Location = new System.Drawing.Point(0, 0);
            this.btnAddFiles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddFiles.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(170, 36);
            this.btnAddFiles.TabIndex = 124;
            this.btnAddFiles.Text = "Add file(s)";
            this.btnAddFiles.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddFiles.UseAccentColor = false;
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // MUCSound
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.lvSoundFiles);
            this.Name = "MUCSound";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCSound_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCSound_VisibleChanged);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MaterialSkin.Controls.MaterialListView lvSoundFiles;
        private System.Windows.Forms.ColumnHeader chSoundFile;
        private System.Windows.Forms.Panel pnlFooter;
        private MaterialSkin.Controls.MaterialButton btnRemoveFiles;
        private MaterialSkin.Controls.MaterialButton btnAddFiles;
        private MaterialSkin.Controls.MaterialSwitch swFilePath;
        private MaterialSkin.Controls.MaterialButton btnPreview;
        private System.Windows.Forms.Timer tmrMusic;
    }
}
