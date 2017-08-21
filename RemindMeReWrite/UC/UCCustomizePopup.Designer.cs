namespace RemindMe
{
    partial class UCCustomizePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCustomizePopup));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numheight = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbReset = new System.Windows.Forms.PictureBox();
            this.pbTest = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numNoteFontSize = new System.Windows.Forms.NumericUpDown();
            this.numTitleFontSize = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pbExclamationHeight = new System.Windows.Forms.PictureBox();
            this.pbExclamationWidth = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numheight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTitleFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 91;
            this.label6.Text = "Width:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 15);
            this.label1.TabIndex = 92;
            this.label1.Text = "Customize the RemindMe popup!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 93;
            this.label2.Text = "Height:";
            // 
            // numWidth
            // 
            this.numWidth.BackColor = System.Drawing.Color.DimGray;
            this.numWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numWidth.ForeColor = System.Drawing.Color.White;
            this.numWidth.Location = new System.Drawing.Point(115, 38);
            this.numWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            340,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(73, 20);
            this.numWidth.TabIndex = 94;
            this.numWidth.Value = new decimal(new int[] {
            340,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // numheight
            // 
            this.numheight.BackColor = System.Drawing.Color.DimGray;
            this.numheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numheight.ForeColor = System.Drawing.Color.White;
            this.numheight.Location = new System.Drawing.Point(115, 64);
            this.numheight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numheight.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numheight.Name = "numheight";
            this.numheight.Size = new System.Drawing.Size(73, 20);
            this.numheight.TabIndex = 95;
            this.numheight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numheight.ValueChanged += new System.EventHandler(this.numHeigth_ValueChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            // 
            // pbReset
            // 
            this.pbReset.BackgroundImage = global::RemindMe.Properties.Resources.reset;
            this.pbReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbReset.Location = new System.Drawing.Point(374, 1);
            this.pbReset.Name = "pbReset";
            this.pbReset.Size = new System.Drawing.Size(38, 38);
            this.pbReset.TabIndex = 108;
            this.pbReset.TabStop = false;
            this.toolTip1.SetToolTip(this.pbReset, "Reset to defaults");
            this.pbReset.Click += new System.EventHandler(this.pbReset_Click);
            // 
            // pbTest
            // 
            this.pbTest.BackgroundImage = global::RemindMe.Properties.Resources.TestIconBlack;
            this.pbTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTest.Location = new System.Drawing.Point(-5, 163);
            this.pbTest.Name = "pbTest";
            this.pbTest.Size = new System.Drawing.Size(50, 50);
            this.pbTest.TabIndex = 106;
            this.pbTest.TabStop = false;
            this.pbTest.Click += new System.EventHandler(this.pbTest_Click);
            // 
            // pbSave
            // 
            this.pbSave.BackgroundImage = global::RemindMe.Properties.Resources.SaveIconBlack;
            this.pbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSave.Location = new System.Drawing.Point(418, 1);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(38, 38);
            this.pbSave.TabIndex = 103;
            this.pbSave.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSave, "Save changes");
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 99;
            this.label3.Text = "Title Font size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 100;
            this.label4.Text = "Note Font size:";
            // 
            // numNoteFontSize
            // 
            this.numNoteFontSize.BackColor = System.Drawing.Color.DimGray;
            this.numNoteFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numNoteFontSize.ForeColor = System.Drawing.Color.White;
            this.numNoteFontSize.Location = new System.Drawing.Point(115, 136);
            this.numNoteFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNoteFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNoteFontSize.Name = "numNoteFontSize";
            this.numNoteFontSize.Size = new System.Drawing.Size(73, 20);
            this.numNoteFontSize.TabIndex = 102;
            this.numNoteFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTitleFontSize
            // 
            this.numTitleFontSize.BackColor = System.Drawing.Color.DimGray;
            this.numTitleFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numTitleFontSize.ForeColor = System.Drawing.Color.White;
            this.numTitleFontSize.Location = new System.Drawing.Point(115, 110);
            this.numTitleFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTitleFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTitleFontSize.Name = "numTitleFontSize";
            this.numTitleFontSize.Size = new System.Drawing.Size(73, 20);
            this.numTitleFontSize.TabIndex = 101;
            this.numTitleFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(36, 279);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 107;
            this.label5.Text = "Test changes";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStatus.Location = new System.Drawing.Point(3, 275);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(25, 25);
            this.pbStatus.TabIndex = 105;
            this.pbStatus.TabStop = false;
            // 
            // pbExclamationHeight
            // 
            this.pbExclamationHeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExclamationHeight.BackgroundImage")));
            this.pbExclamationHeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExclamationHeight.Location = new System.Drawing.Point(194, 62);
            this.pbExclamationHeight.Name = "pbExclamationHeight";
            this.pbExclamationHeight.Size = new System.Drawing.Size(27, 24);
            this.pbExclamationHeight.TabIndex = 98;
            this.pbExclamationHeight.TabStop = false;
            this.pbExclamationHeight.Visible = false;
            // 
            // pbExclamationWidth
            // 
            this.pbExclamationWidth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExclamationWidth.BackgroundImage")));
            this.pbExclamationWidth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExclamationWidth.Location = new System.Drawing.Point(194, 36);
            this.pbExclamationWidth.Name = "pbExclamationWidth";
            this.pbExclamationWidth.Size = new System.Drawing.Size(27, 24);
            this.pbExclamationWidth.TabIndex = 97;
            this.pbExclamationWidth.TabStop = false;
            this.pbExclamationWidth.Visible = false;
            // 
            // UCCustomizePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pbReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbTest);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.numNoteFontSize);
            this.Controls.Add(this.numTitleFontSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbExclamationHeight);
            this.Controls.Add(this.pbExclamationWidth);
            this.Controls.Add(this.numheight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Name = "UCCustomizePopup";
            this.Size = new System.Drawing.Size(462, 302);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numheight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTitleFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclamationWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numheight;
        private System.Windows.Forms.PictureBox pbExclamationWidth;
        private System.Windows.Forms.PictureBox pbExclamationHeight;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numNoteFontSize;
        private System.Windows.Forms.NumericUpDown numTitleFontSize;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbReset;
    }
}
