namespace RemindMe
{
    partial class MUCTheme
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
            this.btnDeleteTheme = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbLoadTheme = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSaveTheme = new MaterialSkin.Controls.MaterialButton();
            this.btnOldRemindMeTheme = new MaterialSkin.Controls.MaterialButton();
            this.btnChangeColors = new MaterialSkin.Controls.MaterialButton();
            this.swDrawerHighlight = new MaterialSkin.Controls.MaterialSwitch();
            this.cbAccent = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnTheme = new MaterialSkin.Controls.MaterialButton();
            this.swColors = new MaterialSkin.Controls.MaterialSwitch();
            this.cbPrimary = new MaterialSkin.Controls.MaterialComboBox();
            this.cbTextShade = new MaterialSkin.Controls.MaterialComboBox();
            this.cbDarkPrimary = new MaterialSkin.Controls.MaterialComboBox();
            this.cbLightPrimary = new MaterialSkin.Controls.MaterialComboBox();
            this.swDrawerBackground = new MaterialSkin.Controls.MaterialSwitch();
            this.SuspendLayout();
            // 
            // btnDeleteTheme
            // 
            this.btnDeleteTheme.AutoSize = false;
            this.btnDeleteTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteTheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteTheme.Depth = 0;
            this.btnDeleteTheme.DrawShadows = true;
            this.btnDeleteTheme.HighEmphasis = true;
            this.btnDeleteTheme.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnDeleteTheme.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteTheme.Location = new System.Drawing.Point(255, 439);
            this.btnDeleteTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteTheme.Name = "btnDeleteTheme";
            this.btnDeleteTheme.Size = new System.Drawing.Size(45, 38);
            this.btnDeleteTheme.TabIndex = 97;
            this.btnDeleteTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteTheme.UseAccentColor = false;
            this.btnDeleteTheme.UseVisualStyleBackColor = true;
            this.btnDeleteTheme.Click += new System.EventHandler(this.btnDeleteTheme_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.Location = new System.Drawing.Point(17, 404);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(345, 24);
            this.materialLabel3.TabIndex = 95;
            this.materialLabel3.Text = "Load / delete previously saved themes";
            // 
            // cbLoadTheme
            // 
            this.cbLoadTheme.AutoResize = false;
            this.cbLoadTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbLoadTheme.Depth = 0;
            this.cbLoadTheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbLoadTheme.DropDownHeight = 174;
            this.cbLoadTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoadTheme.DropDownWidth = 121;
            this.cbLoadTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbLoadTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbLoadTheme.FormattingEnabled = true;
            this.cbLoadTheme.Hint = "Select & Load a theme";
            this.cbLoadTheme.IntegralHeight = false;
            this.cbLoadTheme.ItemHeight = 43;
            this.cbLoadTheme.Location = new System.Drawing.Point(15, 435);
            this.cbLoadTheme.MaxDropDownItems = 4;
            this.cbLoadTheme.MouseState = MaterialSkin.MouseState.OUT;
            this.cbLoadTheme.Name = "cbLoadTheme";
            this.cbLoadTheme.Size = new System.Drawing.Size(223, 49);
            this.cbLoadTheme.TabIndex = 94;
            this.cbLoadTheme.SelectedIndexChanged += new System.EventHandler(this.cbLoadTheme_SelectedIndexChanged);
            // 
            // btnSaveTheme
            // 
            this.btnSaveTheme.AutoSize = false;
            this.btnSaveTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveTheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveTheme.Depth = 0;
            this.btnSaveTheme.DrawShadows = true;
            this.btnSaveTheme.HighEmphasis = true;
            this.btnSaveTheme.Icon = global::RemindMe.Properties.Resources.saveWhite;
            this.btnSaveTheme.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveTheme.Location = new System.Drawing.Point(747, 251);
            this.btnSaveTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveTheme.Name = "btnSaveTheme";
            this.btnSaveTheme.Size = new System.Drawing.Size(45, 38);
            this.btnSaveTheme.TabIndex = 93;
            this.btnSaveTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveTheme.UseAccentColor = false;
            this.btnSaveTheme.UseVisualStyleBackColor = true;
            this.btnSaveTheme.Click += new System.EventHandler(this.btnSaveTheme_Click);
            // 
            // btnOldRemindMeTheme
            // 
            this.btnOldRemindMeTheme.AutoSize = false;
            this.btnOldRemindMeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOldRemindMeTheme.Depth = 0;
            this.btnOldRemindMeTheme.DrawShadows = true;
            this.btnOldRemindMeTheme.HighEmphasis = true;
            this.btnOldRemindMeTheme.Icon = null;
            this.btnOldRemindMeTheme.Location = new System.Drawing.Point(565, 454);
            this.btnOldRemindMeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOldRemindMeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOldRemindMeTheme.Name = "btnOldRemindMeTheme";
            this.btnOldRemindMeTheme.Size = new System.Drawing.Size(232, 36);
            this.btnOldRemindMeTheme.TabIndex = 92;
            this.btnOldRemindMeTheme.Text = "Use the old RemindMe theme";
            this.btnOldRemindMeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnOldRemindMeTheme.UseAccentColor = false;
            this.btnOldRemindMeTheme.UseVisualStyleBackColor = true;
            this.btnOldRemindMeTheme.Click += new System.EventHandler(this.btnOldRemindMeTheme_Click);
            // 
            // btnChangeColors
            // 
            this.btnChangeColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeColors.Depth = 0;
            this.btnChangeColors.DrawShadows = true;
            this.btnChangeColors.HighEmphasis = true;
            this.btnChangeColors.Icon = null;
            this.btnChangeColors.Location = new System.Drawing.Point(16, 17);
            this.btnChangeColors.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChangeColors.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeColors.Name = "btnChangeColors";
            this.btnChangeColors.Size = new System.Drawing.Size(83, 36);
            this.btnChangeColors.TabIndex = 81;
            this.btnChangeColors.Text = "Shuffle";
            this.btnChangeColors.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnChangeColors.UseAccentColor = false;
            this.btnChangeColors.UseVisualStyleBackColor = true;
            this.btnChangeColors.Click += new System.EventHandler(this.btnChangeColors_Click);
            // 
            // swDrawerHighlight
            // 
            this.swDrawerHighlight.AutoSize = true;
            this.swDrawerHighlight.Checked = true;
            this.swDrawerHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.swDrawerHighlight.Depth = 0;
            this.swDrawerHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swDrawerHighlight.Location = new System.Drawing.Point(16, 101);
            this.swDrawerHighlight.Margin = new System.Windows.Forms.Padding(0);
            this.swDrawerHighlight.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swDrawerHighlight.MouseState = MaterialSkin.MouseState.HOVER;
            this.swDrawerHighlight.Name = "swDrawerHighlight";
            this.swDrawerHighlight.Ripple = true;
            this.swDrawerHighlight.Size = new System.Drawing.Size(270, 37);
            this.swDrawerHighlight.TabIndex = 83;
            this.swDrawerHighlight.Text = "Drawer - Highlight with Accent";
            this.swDrawerHighlight.UseVisualStyleBackColor = true;
            this.swDrawerHighlight.CheckedChanged += new System.EventHandler(this.materialSwitch5_CheckedChanged);
            // 
            // cbAccent
            // 
            this.cbAccent.AutoResize = false;
            this.cbAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAccent.Depth = 0;
            this.cbAccent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbAccent.DropDownHeight = 174;
            this.cbAccent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccent.DropDownWidth = 121;
            this.cbAccent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbAccent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbAccent.FormattingEnabled = true;
            this.cbAccent.Hint = "Accent";
            this.cbAccent.IntegralHeight = false;
            this.cbAccent.ItemHeight = 43;
            this.cbAccent.Location = new System.Drawing.Point(454, 245);
            this.cbAccent.MaxDropDownItems = 4;
            this.cbAccent.MouseState = MaterialSkin.MouseState.OUT;
            this.cbAccent.Name = "cbAccent";
            this.cbAccent.Size = new System.Drawing.Size(140, 49);
            this.cbAccent.TabIndex = 89;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(15, 210);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(214, 24);
            this.materialLabel1.TabIndex = 85;
            this.materialLabel1.Text = "Create your own theme!";
            // 
            // btnTheme
            // 
            this.btnTheme.AutoSize = false;
            this.btnTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTheme.Depth = 0;
            this.btnTheme.DrawShadows = true;
            this.btnTheme.HighEmphasis = true;
            this.btnTheme.Icon = null;
            this.btnTheme.Location = new System.Drawing.Point(107, 17);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(100, 36);
            this.btnTheme.TabIndex = 80;
            this.btnTheme.Text = "Dark mode";
            this.btnTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTheme.UseAccentColor = false;
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.materialButton7_Click);
            // 
            // swColors
            // 
            this.swColors.AutoSize = true;
            this.swColors.Depth = 0;
            this.swColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swColors.Location = new System.Drawing.Point(16, 64);
            this.swColors.Margin = new System.Windows.Forms.Padding(0);
            this.swColors.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swColors.MouseState = MaterialSkin.MouseState.HOVER;
            this.swColors.Name = "swColors";
            this.swColors.Ripple = true;
            this.swColors.Size = new System.Drawing.Size(193, 37);
            this.swColors.TabIndex = 82;
            this.swColors.Text = "Drawer - Use colors";
            this.swColors.UseVisualStyleBackColor = true;
            this.swColors.CheckedChanged += new System.EventHandler(this.materialSwitch4_CheckedChanged);
            // 
            // cbPrimary
            // 
            this.cbPrimary.AutoResize = false;
            this.cbPrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbPrimary.Depth = 0;
            this.cbPrimary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbPrimary.DropDownHeight = 174;
            this.cbPrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrimary.DropDownWidth = 121;
            this.cbPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbPrimary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbPrimary.FormattingEnabled = true;
            this.cbPrimary.Hint = "Primary";
            this.cbPrimary.IntegralHeight = false;
            this.cbPrimary.ItemHeight = 43;
            this.cbPrimary.Location = new System.Drawing.Point(15, 245);
            this.cbPrimary.MaxDropDownItems = 4;
            this.cbPrimary.MouseState = MaterialSkin.MouseState.OUT;
            this.cbPrimary.Name = "cbPrimary";
            this.cbPrimary.Size = new System.Drawing.Size(140, 49);
            this.cbPrimary.TabIndex = 86;
            // 
            // cbTextShade
            // 
            this.cbTextShade.AutoResize = false;
            this.cbTextShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbTextShade.Depth = 0;
            this.cbTextShade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTextShade.DropDownHeight = 174;
            this.cbTextShade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextShade.DropDownWidth = 121;
            this.cbTextShade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbTextShade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbTextShade.FormattingEnabled = true;
            this.cbTextShade.Hint = "Text Shade";
            this.cbTextShade.IntegralHeight = false;
            this.cbTextShade.ItemHeight = 43;
            this.cbTextShade.Location = new System.Drawing.Point(600, 245);
            this.cbTextShade.MaxDropDownItems = 4;
            this.cbTextShade.MouseState = MaterialSkin.MouseState.OUT;
            this.cbTextShade.Name = "cbTextShade";
            this.cbTextShade.Size = new System.Drawing.Size(140, 49);
            this.cbTextShade.TabIndex = 90;
            // 
            // cbDarkPrimary
            // 
            this.cbDarkPrimary.AutoResize = false;
            this.cbDarkPrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbDarkPrimary.Depth = 0;
            this.cbDarkPrimary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbDarkPrimary.DropDownHeight = 174;
            this.cbDarkPrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDarkPrimary.DropDownWidth = 121;
            this.cbDarkPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbDarkPrimary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbDarkPrimary.FormattingEnabled = true;
            this.cbDarkPrimary.Hint = "Dark Primary";
            this.cbDarkPrimary.IntegralHeight = false;
            this.cbDarkPrimary.ItemHeight = 43;
            this.cbDarkPrimary.Location = new System.Drawing.Point(162, 245);
            this.cbDarkPrimary.MaxDropDownItems = 4;
            this.cbDarkPrimary.MouseState = MaterialSkin.MouseState.OUT;
            this.cbDarkPrimary.Name = "cbDarkPrimary";
            this.cbDarkPrimary.Size = new System.Drawing.Size(140, 49);
            this.cbDarkPrimary.TabIndex = 87;
            // 
            // cbLightPrimary
            // 
            this.cbLightPrimary.AutoResize = false;
            this.cbLightPrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbLightPrimary.Depth = 0;
            this.cbLightPrimary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbLightPrimary.DropDownHeight = 174;
            this.cbLightPrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLightPrimary.DropDownWidth = 121;
            this.cbLightPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbLightPrimary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbLightPrimary.FormattingEnabled = true;
            this.cbLightPrimary.Hint = "Light Primary";
            this.cbLightPrimary.IntegralHeight = false;
            this.cbLightPrimary.ItemHeight = 43;
            this.cbLightPrimary.Location = new System.Drawing.Point(308, 245);
            this.cbLightPrimary.MaxDropDownItems = 4;
            this.cbLightPrimary.MouseState = MaterialSkin.MouseState.OUT;
            this.cbLightPrimary.Name = "cbLightPrimary";
            this.cbLightPrimary.Size = new System.Drawing.Size(140, 49);
            this.cbLightPrimary.TabIndex = 88;
            // 
            // swDrawerBackground
            // 
            this.swDrawerBackground.AutoSize = true;
            this.swDrawerBackground.Depth = 0;
            this.swDrawerBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.swDrawerBackground.Location = new System.Drawing.Point(16, 137);
            this.swDrawerBackground.Margin = new System.Windows.Forms.Padding(0);
            this.swDrawerBackground.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swDrawerBackground.MouseState = MaterialSkin.MouseState.HOVER;
            this.swDrawerBackground.Name = "swDrawerBackground";
            this.swDrawerBackground.Ripple = true;
            this.swDrawerBackground.Size = new System.Drawing.Size(291, 37);
            this.swDrawerBackground.TabIndex = 84;
            this.swDrawerBackground.Text = "Drawer - Background with Accent";
            this.swDrawerBackground.UseVisualStyleBackColor = true;
            this.swDrawerBackground.CheckedChanged += new System.EventHandler(this.materialSwitch6_CheckedChanged);
            // 
            // MUCTheme
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnDeleteTheme);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.cbLoadTheme);
            this.Controls.Add(this.btnSaveTheme);
            this.Controls.Add(this.btnOldRemindMeTheme);
            this.Controls.Add(this.btnChangeColors);
            this.Controls.Add(this.swDrawerHighlight);
            this.Controls.Add(this.cbAccent);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.swColors);
            this.Controls.Add(this.cbPrimary);
            this.Controls.Add(this.cbTextShade);
            this.Controls.Add(this.cbDarkPrimary);
            this.Controls.Add(this.cbLightPrimary);
            this.Controls.Add(this.swDrawerBackground);
            this.Name = "MUCTheme";
            this.Size = new System.Drawing.Size(806, 498);
            this.Load += new System.EventHandler(this.MUCTheme_Load);
            this.VisibleChanged += new System.EventHandler(this.MUCTheme_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnChangeColors;
        private MaterialSkin.Controls.MaterialSwitch swDrawerHighlight;
        private MaterialSkin.Controls.MaterialComboBox cbAccent;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnTheme;
        private MaterialSkin.Controls.MaterialSwitch swColors;
        private MaterialSkin.Controls.MaterialComboBox cbPrimary;
        private MaterialSkin.Controls.MaterialComboBox cbTextShade;
        private MaterialSkin.Controls.MaterialComboBox cbDarkPrimary;
        private MaterialSkin.Controls.MaterialComboBox cbLightPrimary;
        private MaterialSkin.Controls.MaterialSwitch swDrawerBackground;
        private MaterialSkin.Controls.MaterialButton btnOldRemindMeTheme;
        private MaterialSkin.Controls.MaterialButton btnSaveTheme;
        private MaterialSkin.Controls.MaterialComboBox cbLoadTheme;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btnDeleteTheme;
    }
}
