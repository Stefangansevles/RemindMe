namespace RemindMe
{
    partial class MaterialAdvancedReminderForm
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
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.tbBatch = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbHideReminder = new MaterialSkin.Controls.MaterialSwitch();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.DrawShadows = true;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = global::RemindMe.Properties.Resources.saveWhite;
            this.btnConfirm.Location = new System.Drawing.Point(13, 364);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(175, 35);
            this.btnConfirm.TabIndex = 126;
            this.btnConfirm.Text = "SAVE";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tbBatch
            // 
            this.tbBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBatch.Depth = 0;
            this.tbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbBatch.Hint = "";
            this.tbBatch.Location = new System.Drawing.Point(38, 152);
            this.tbBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbBatch.Size = new System.Drawing.Size(511, 159);
            this.tbBatch.TabIndex = 129;
            this.tbBatch.Text = "";
            this.tbBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBatch_KeyDown);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(35, 72);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(514, 77);
            this.materialLabel1.TabIndex = 130;
            this.materialLabel1.Text = "You can paste Windows Batch code here. The reminder will Execute\r\nthe code at the" +
    " given reminder date. \r\n\r\n          ONLY USE THIS IF YOU KNOW WHAT YOU ARE DOING" +
    "";
            // 
            // cbHideReminder
            // 
            this.cbHideReminder.AutoSize = true;
            this.cbHideReminder.Depth = 0;
            this.cbHideReminder.Location = new System.Drawing.Point(38, 317);
            this.cbHideReminder.Margin = new System.Windows.Forms.Padding(0);
            this.cbHideReminder.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbHideReminder.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbHideReminder.Name = "cbHideReminder";
            this.cbHideReminder.Ripple = true;
            this.cbHideReminder.Size = new System.Drawing.Size(317, 37);
            this.cbHideReminder.TabIndex = 131;
            this.cbHideReminder.Text = "Hide reminder popup ( Execute-only )";
            this.cbHideReminder.UseVisualStyleBackColor = true;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 406);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(590, 5);
            this.materialProgressBar1.TabIndex = 132;
            this.materialProgressBar1.Value = 100;
            // 
            // pnlRight
            // 
            this.pnlRight.Location = new System.Drawing.Point(586, 63);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(5, 344);
            this.pnlRight.TabIndex = 133;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(0, 63);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(5, 344);
            this.pnlLeft.TabIndex = 134;
            // 
            // MaterialAdvancedReminderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(590, 411);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbHideReminder);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.tbBatch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialAdvancedReminderForm";
            this.Text = "Advanced Reminder functionality";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialAdvancedReminderForm_FormClosing);
            this.Load += new System.EventHandler(this.MaterialAdvancedReminderForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MaterialAdvancedReminderForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbBatch;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch cbHideReminder;
        private System.Windows.Forms.Timer tmrFadeIn;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
    }
}