namespace RemindMe
{
    partial class AVR_UCBatch
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbBatch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "          Paste your batch code (.bat) here\r\nOnly use this if you know what you a" +
    "re doing!!\r\n";
            // 
            // tbBatch
            // 
            this.tbBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbBatch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbBatch.ForeColor = System.Drawing.Color.White;
            this.tbBatch.Location = new System.Drawing.Point(0, 62);
            this.tbBatch.Multiline = true;
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBatch.Size = new System.Drawing.Size(395, 184);
            this.tbBatch.TabIndex = 92;
            this.tbBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBatch_KeyDown);
            // 
            // AVR_UCBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tbBatch);
            this.Controls.Add(this.label1);
            this.Name = "AVR_UCBatch";
            this.Size = new System.Drawing.Size(395, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbBatch;
    }
}
