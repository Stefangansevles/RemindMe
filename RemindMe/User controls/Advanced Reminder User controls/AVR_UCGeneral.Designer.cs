namespace RemindMe
{
    partial class AVR_UCGeneral
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
            this.lblShowReminder = new System.Windows.Forms.Label();
            this.cbShowReminder = new Bunifu.Framework.UI.BunifuCheckbox();
            this.SuspendLayout();
            // 
            // lblShowReminder
            // 
            this.lblShowReminder.AutoSize = true;
            this.lblShowReminder.BackColor = System.Drawing.Color.Transparent;
            this.lblShowReminder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblShowReminder.ForeColor = System.Drawing.Color.White;
            this.lblShowReminder.Location = new System.Drawing.Point(47, 18);
            this.lblShowReminder.Name = "lblShowReminder";
            this.lblShowReminder.Size = new System.Drawing.Size(156, 17);
            this.lblShowReminder.TabIndex = 105;
            this.lblShowReminder.Text = "Show reminder popup";
            this.lblShowReminder.Click += new System.EventHandler(this.lblShowReminder_Click);
            // 
            // cbShowReminder
            // 
            this.cbShowReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbShowReminder.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cbShowReminder.Checked = true;
            this.cbShowReminder.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbShowReminder.ForeColor = System.Drawing.Color.White;
            this.cbShowReminder.Location = new System.Drawing.Point(16, 18);
            this.cbShowReminder.Name = "cbShowReminder";
            this.cbShowReminder.Size = new System.Drawing.Size(20, 20);
            this.cbShowReminder.TabIndex = 104;
            // 
            // AVR_UCGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lblShowReminder);
            this.Controls.Add(this.cbShowReminder);
            this.Name = "AVR_UCGeneral";
            this.Size = new System.Drawing.Size(395, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShowReminder;
        private Bunifu.Framework.UI.BunifuCheckbox cbShowReminder;
    }
}
