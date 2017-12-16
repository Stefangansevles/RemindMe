namespace RemindMe
{
    partial class RemindMePrompt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMePrompt));
            this.tbInput = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbCloseApplication = new System.Windows.Forms.PictureBox();
            this.tbBlackTopBar = new System.Windows.Forms.TextBox();
            this.pnlNumericPrompt = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.numNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlNumericPromptTwoValues = new System.Windows.Forms.Panel();
            this.labelTextTwo = new System.Windows.Forms.Label();
            this.numericUpDownValueTwo = new System.Windows.Forms.NumericUpDown();
            this.btnOkTwoValues = new System.Windows.Forms.Button();
            this.numericUpDownValueOne = new System.Windows.Forms.NumericUpDown();
            this.labelTextOne = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).BeginInit();
            this.pnlNumericPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumber)).BeginInit();
            this.pnlNumericPromptTwoValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueOne)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.Color.DimGray;
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbInput.ForeColor = System.Drawing.Color.White;
            this.tbInput.Location = new System.Drawing.Point(85, 73);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(234, 20);
            this.tbInput.TabIndex = 33;
            this.toolTip1.SetToolTip(this.tbInput, "Press enter to submit");
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 44);
            this.panel1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 44);
            this.label1.TabIndex = 36;
            this.label1.Text = "Title:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Black;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(0, -1);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 22);
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            // 
            // pbCloseApplication
            // 
            this.pbCloseApplication.BackColor = System.Drawing.Color.Black;
            this.pbCloseApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCloseApplication.BackgroundImage")));
            this.pbCloseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCloseApplication.Location = new System.Drawing.Point(356, 0);
            this.pbCloseApplication.Name = "pbCloseApplication";
            this.pbCloseApplication.Size = new System.Drawing.Size(22, 22);
            this.pbCloseApplication.TabIndex = 69;
            this.pbCloseApplication.TabStop = false;
            this.pbCloseApplication.Click += new System.EventHandler(this.pbCloseApplication_Click);
            // 
            // tbBlackTopBar
            // 
            this.tbBlackTopBar.BackColor = System.Drawing.Color.Black;
            this.tbBlackTopBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBlackTopBar.Enabled = false;
            this.tbBlackTopBar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbBlackTopBar.Location = new System.Drawing.Point(0, 0);
            this.tbBlackTopBar.Multiline = true;
            this.tbBlackTopBar.Name = "tbBlackTopBar";
            this.tbBlackTopBar.Size = new System.Drawing.Size(381, 22);
            this.tbBlackTopBar.TabIndex = 68;
            // 
            // pnlNumericPrompt
            // 
            this.pnlNumericPrompt.Controls.Add(this.btnOk);
            this.pnlNumericPrompt.Controls.Add(this.numNumber);
            this.pnlNumericPrompt.Controls.Add(this.label2);
            this.pnlNumericPrompt.Location = new System.Drawing.Point(3, 85);
            this.pnlNumericPrompt.Name = "pnlNumericPrompt";
            this.pnlNumericPrompt.Size = new System.Drawing.Size(334, 26);
            this.pnlNumericPrompt.TabIndex = 71;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.Transparent;
            this.btnOk.Location = new System.Drawing.Point(228, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(38, 20);
            this.btnOk.TabIndex = 73;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // numNumber
            // 
            this.numNumber.BackColor = System.Drawing.Color.DimGray;
            this.numNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numNumber.ForeColor = System.Drawing.Color.White;
            this.numNumber.Location = new System.Drawing.Point(149, 4);
            this.numNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNumber.Name = "numNumber";
            this.numNumber.Size = new System.Drawing.Size(73, 20);
            this.numNumber.TabIndex = 72;
            this.numNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Please enter a number";
            // 
            // pnlNumericPromptTwoValues
            // 
            this.pnlNumericPromptTwoValues.Controls.Add(this.labelTextTwo);
            this.pnlNumericPromptTwoValues.Controls.Add(this.numericUpDownValueTwo);
            this.pnlNumericPromptTwoValues.Controls.Add(this.btnOkTwoValues);
            this.pnlNumericPromptTwoValues.Controls.Add(this.numericUpDownValueOne);
            this.pnlNumericPromptTwoValues.Controls.Add(this.labelTextOne);
            this.pnlNumericPromptTwoValues.Location = new System.Drawing.Point(3, 86);
            this.pnlNumericPromptTwoValues.Name = "pnlNumericPromptTwoValues";
            this.pnlNumericPromptTwoValues.Size = new System.Drawing.Size(334, 26);
            this.pnlNumericPromptTwoValues.TabIndex = 74;
            // 
            // labelTextTwo
            // 
            this.labelTextTwo.AutoSize = true;
            this.labelTextTwo.BackColor = System.Drawing.Color.Transparent;
            this.labelTextTwo.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTextTwo.ForeColor = System.Drawing.Color.White;
            this.labelTextTwo.Location = new System.Drawing.Point(151, 6);
            this.labelTextTwo.Name = "labelTextTwo";
            this.labelTextTwo.Size = new System.Drawing.Size(13, 15);
            this.labelTextTwo.TabIndex = 75;
            this.labelTextTwo.Text = "x";
            // 
            // numericUpDownValueTwo
            // 
            this.numericUpDownValueTwo.BackColor = System.Drawing.Color.DimGray;
            this.numericUpDownValueTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownValueTwo.ForeColor = System.Drawing.Color.White;
            this.numericUpDownValueTwo.Location = new System.Drawing.Point(199, 3);
            this.numericUpDownValueTwo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownValueTwo.Name = "numericUpDownValueTwo";
            this.numericUpDownValueTwo.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownValueTwo.TabIndex = 74;
            // 
            // btnOkTwoValues
            // 
            this.btnOkTwoValues.BackColor = System.Drawing.Color.Transparent;
            this.btnOkTwoValues.BackgroundImage = global::RemindMe.Properties.Resources.bbuttonEDIT2;
            this.btnOkTwoValues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOkTwoValues.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOkTwoValues.ForeColor = System.Drawing.Color.Transparent;
            this.btnOkTwoValues.Location = new System.Drawing.Point(293, 3);
            this.btnOkTwoValues.Name = "btnOkTwoValues";
            this.btnOkTwoValues.Size = new System.Drawing.Size(38, 20);
            this.btnOkTwoValues.TabIndex = 73;
            this.btnOkTwoValues.Text = "OK";
            this.btnOkTwoValues.UseVisualStyleBackColor = false;
            this.btnOkTwoValues.Click += new System.EventHandler(this.btnOkTwoValues_Click);
            // 
            // numericUpDownValueOne
            // 
            this.numericUpDownValueOne.BackColor = System.Drawing.Color.DimGray;
            this.numericUpDownValueOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownValueOne.ForeColor = System.Drawing.Color.White;
            this.numericUpDownValueOne.Location = new System.Drawing.Point(56, 3);
            this.numericUpDownValueOne.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownValueOne.Name = "numericUpDownValueOne";
            this.numericUpDownValueOne.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownValueOne.TabIndex = 72;
            // 
            // labelTextOne
            // 
            this.labelTextOne.AutoSize = true;
            this.labelTextOne.BackColor = System.Drawing.Color.Transparent;
            this.labelTextOne.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTextOne.ForeColor = System.Drawing.Color.White;
            this.labelTextOne.Location = new System.Drawing.Point(2, 5);
            this.labelTextOne.Name = "labelTextOne";
            this.labelTextOne.Size = new System.Drawing.Size(13, 15);
            this.labelTextOne.TabIndex = 34;
            this.labelTextOne.Text = "x";
            // 
            // RemindMePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(380, 113);
            this.Controls.Add(this.pnlNumericPromptTwoValues);
            this.Controls.Add(this.pnlNumericPrompt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.pbCloseApplication);
            this.Controls.Add(this.tbBlackTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemindMePrompt";
            this.Text = "RemindMePrompt";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseApplication)).EndInit();
            this.pnlNumericPrompt.ResumeLayout(false);
            this.pnlNumericPrompt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumber)).EndInit();
            this.pnlNumericPromptTwoValues.ResumeLayout(false);
            this.pnlNumericPromptTwoValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pbCloseApplication;
        private System.Windows.Forms.TextBox tbBlackTopBar;
        private System.Windows.Forms.Panel pnlNumericPrompt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNumber;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlNumericPromptTwoValues;
        private System.Windows.Forms.Label labelTextTwo;
        private System.Windows.Forms.NumericUpDown numericUpDownValueTwo;
        private System.Windows.Forms.Button btnOkTwoValues;
        private System.Windows.Forms.NumericUpDown numericUpDownValueOne;
        private System.Windows.Forms.Label labelTextOne;
    }
}