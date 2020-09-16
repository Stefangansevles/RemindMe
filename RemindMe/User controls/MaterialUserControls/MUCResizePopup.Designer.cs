namespace RemindMe
{
    partial class MUCResizePopup
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
            this.trbNoteFont = new Bunifu.Framework.UI.BunifuSlider();
            this.trbHeight = new Bunifu.Framework.UI.BunifuSlider();
            this.trbWidth = new Bunifu.Framework.UI.BunifuSlider();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnTest = new MaterialSkin.Controls.MaterialButton();
            this.tbNoteFont = new MaterialSkin.Controls.MaterialTextBox();
            this.disableRightclick = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.tbHeight = new MaterialSkin.Controls.MaterialTextBox();
            this.tbWidth = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // trbNoteFont
            // 
            this.trbNoteFont.BackColor = System.Drawing.Color.Transparent;
            this.trbNoteFont.BackgroudColor = System.Drawing.Color.DarkGray;
            this.trbNoteFont.BorderRadius = 0;
            this.trbNoteFont.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.trbNoteFont.Location = new System.Drawing.Point(202, 214);
            this.trbNoteFont.MaximumValue = 100;
            this.trbNoteFont.Name = "trbNoteFont";
            this.trbNoteFont.Size = new System.Drawing.Size(415, 28);
            this.trbNoteFont.TabIndex = 128;
            this.trbNoteFont.Value = 0;
            this.trbNoteFont.ValueChanged += new System.EventHandler(this.trbNoteFont_ValueChanged);
            // 
            // trbHeight
            // 
            this.trbHeight.BackColor = System.Drawing.Color.Transparent;
            this.trbHeight.BackgroudColor = System.Drawing.Color.DarkGray;
            this.trbHeight.BorderRadius = 0;
            this.trbHeight.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.trbHeight.Location = new System.Drawing.Point(202, 116);
            this.trbHeight.MaximumValue = 100;
            this.trbHeight.Name = "trbHeight";
            this.trbHeight.Size = new System.Drawing.Size(415, 28);
            this.trbHeight.TabIndex = 130;
            this.trbHeight.Value = 0;
            this.trbHeight.ValueChanged += new System.EventHandler(this.trbHeight_ValueChanged);
            // 
            // trbWidth
            // 
            this.trbWidth.BackColor = System.Drawing.Color.Transparent;
            this.trbWidth.BackgroudColor = System.Drawing.Color.DarkGray;
            this.trbWidth.BorderRadius = 0;
            this.trbWidth.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.trbWidth.Location = new System.Drawing.Point(202, 61);
            this.trbWidth.MaximumValue = 1000;
            this.trbWidth.Name = "trbWidth";
            this.trbWidth.Size = new System.Drawing.Size(415, 28);
            this.trbWidth.TabIndex = 131;
            this.trbWidth.Value = 300;
            this.trbWidth.ValueChanged += new System.EventHandler(this.trbWidth_ValueChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(29, 180);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(64, 19);
            this.materialLabel2.TabIndex = 133;
            this.materialLabel2.Text = "Text size";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel1.Location = new System.Drawing.Point(29, 23);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(79, 19);
            this.materialLabel1.TabIndex = 132;
            this.materialLabel1.Text = "Popup size";
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = false;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Depth = 0;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnReset.DrawShadows = true;
            this.btnReset.HighEmphasis = true;
            this.btnReset.Icon = global::RemindMe.Properties.Resources.Repeatwhite;
            this.btnReset.Location = new System.Drawing.Point(397, 308);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(175, 35);
            this.btnReset.TabIndex = 127;
            this.btnReset.Text = "Reset to default";
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReset.UseAccentColor = false;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.DrawShadows = true;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = global::RemindMe.Properties.Resources.saveWhite;
            this.btnSave.Location = new System.Drawing.Point(212, 308);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 35);
            this.btnSave.TabIndex = 126;
            this.btnSave.Text = "SAVE";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = false;
            this.btnTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTest.Depth = 0;
            this.btnTest.DrawShadows = true;
            this.btnTest.HighEmphasis = true;
            this.btnTest.Icon = global::RemindMe.Properties.Resources.test_tube_white;
            this.btnTest.Location = new System.Drawing.Point(26, 308);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(175, 35);
            this.btnTest.TabIndex = 125;
            this.btnTest.Text = "test changes";
            this.btnTest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTest.UseAccentColor = false;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbNoteFont
            // 
            this.tbNoteFont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNoteFont.ContextMenuStrip = this.disableRightclick;
            this.tbNoteFont.Depth = 0;
            this.tbNoteFont.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbNoteFont.Hint = "Description size";
            this.tbNoteFont.Location = new System.Drawing.Point(26, 202);
            this.tbNoteFont.MaxLength = 50;
            this.tbNoteFont.MouseState = MaterialSkin.MouseState.OUT;
            this.tbNoteFont.Multiline = false;
            this.tbNoteFont.Name = "tbNoteFont";
            this.tbNoteFont.Size = new System.Drawing.Size(136, 50);
            this.tbNoteFont.TabIndex = 4;
            this.tbNoteFont.Text = "";
            this.tbNoteFont.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNoteFont_KeyUp);
            // 
            // disableRightclick
            // 
            this.disableRightclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.disableRightclick.Depth = 0;
            this.disableRightclick.MouseState = MaterialSkin.MouseState.HOVER;
            this.disableRightclick.Name = "disableRightclick";
            this.disableRightclick.Size = new System.Drawing.Size(61, 4);
            // 
            // tbHeight
            // 
            this.tbHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHeight.ContextMenuStrip = this.disableRightclick;
            this.tbHeight.Depth = 0;
            this.tbHeight.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbHeight.Hint = "Height";
            this.tbHeight.Location = new System.Drawing.Point(26, 105);
            this.tbHeight.MaxLength = 50;
            this.tbHeight.MouseState = MaterialSkin.MouseState.OUT;
            this.tbHeight.Multiline = false;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(136, 50);
            this.tbHeight.TabIndex = 2;
            this.tbHeight.Text = "";
            this.tbHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbHeight_KeyUp);
            // 
            // tbWidth
            // 
            this.tbWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWidth.ContextMenuStrip = this.disableRightclick;
            this.tbWidth.Depth = 0;
            this.tbWidth.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbWidth.Hint = "Width";
            this.tbWidth.Location = new System.Drawing.Point(26, 49);
            this.tbWidth.MaxLength = 50;
            this.tbWidth.MouseState = MaterialSkin.MouseState.OUT;
            this.tbWidth.Multiline = false;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(136, 50);
            this.tbWidth.TabIndex = 1;
            this.tbWidth.Text = "";
            this.tbWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbWidth_KeyUp);
            // 
            // MUCResizePopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.trbWidth);
            this.Controls.Add(this.trbHeight);
            this.Controls.Add(this.trbNoteFont);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tbNoteFont);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.Name = "MUCResizePopup";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCResizePopup_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCResizePopup_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tbWidth;
        private MaterialSkin.Controls.MaterialTextBox tbHeight;
        private MaterialSkin.Controls.MaterialTextBox tbNoteFont;
        private MaterialSkin.Controls.MaterialButton btnReset;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnTest;
        private Bunifu.Framework.UI.BunifuSlider trbNoteFont;
        private Bunifu.Framework.UI.BunifuSlider trbHeight;
        private Bunifu.Framework.UI.BunifuSlider trbWidth;
        private MaterialSkin.Controls.MaterialContextMenuStrip disableRightclick;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}
