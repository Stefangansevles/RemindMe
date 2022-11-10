namespace RemindMe
{
    partial class MaterialTimerCheck
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
            this.pnlTimers = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlTimers
            // 
            this.pnlTimers.Location = new System.Drawing.Point(0, 37);
            this.pnlTimers.Name = "pnlTimers";
            this.pnlTimers.Size = new System.Drawing.Size(315, 95);
            this.pnlTimers.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(296, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(19, 18);
            this.lblExit.TabIndex = 6;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // MaterialTimerCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 130);
            this.ControlBox = false;
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pnlTimers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialTimerCheck";
            this.ShowInTaskbar = false;
            this.Text = "Running Timers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimerCheck_FormClosed);
            this.Load += new System.EventHandler(this.TimerCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTimers;
        private System.Windows.Forms.Label lblExit;
    }
}