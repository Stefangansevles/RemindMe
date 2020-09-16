namespace RemindMe
{
    partial class RemindMeMaterialMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindMeMaterialMessageForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrFadeout = new System.Windows.Forms.Timer(this.components);
            this.tmrFadein = new System.Windows.Forms.Timer(this.components);
            this.tmrTimeout = new System.Windows.Forms.Timer(this.components);
            this.pnlText = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.btnDisable = new MaterialSkin.Controls.MaterialButton();
            this.btnPostpone = new MaterialSkin.Controls.MaterialButton();
            this.btnSkip = new MaterialSkin.Controls.MaterialButton();
            this.pnlReminderOptions = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlText.SuspendLayout();
            this.pnlReminderOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tmrFadeout
            // 
            this.tmrFadeout.Interval = 10;
            this.tmrFadeout.Tick += new System.EventHandler(this.tmrFadeout_Tick);
            // 
            // tmrFadein
            // 
            this.tmrFadein.Interval = 10;
            this.tmrFadein.Tick += new System.EventHandler(this.tmrFadein_Tick);
            // 
            // tmrTimeout
            // 
            this.tmrTimeout.Interval = 1000;
            this.tmrTimeout.Tick += new System.EventHandler(this.tmrTimeout_Tick);
            // 
            // pnlText
            // 
            this.pnlText.BackColor = System.Drawing.SystemColors.Control;
            this.pnlText.Controls.Add(this.lblText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlText.Location = new System.Drawing.Point(0, 17);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(356, 80);
            this.pnlText.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(7, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(183, 13);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "You have 420 reminders set for today";
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(336, 1);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(18, 18);
            this.lblExit.TabIndex = 5;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.AutoSize = false;
            this.btnDisable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDisable.Depth = 0;
            this.btnDisable.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDisable.DrawShadows = true;
            this.btnDisable.HighEmphasis = true;
            this.btnDisable.Icon = null;
            this.btnDisable.Location = new System.Drawing.Point(0, 0);
            this.btnDisable.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDisable.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(120, 27);
            this.btnDisable.TabIndex = 0;
            this.btnDisable.Text = "Disable";
            this.btnDisable.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnDisable.UseAccentColor = false;
            this.btnDisable.UseVisualStyleBackColor = true;
            // 
            // btnPostpone
            // 
            this.btnPostpone.AutoSize = false;
            this.btnPostpone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPostpone.Depth = 0;
            this.btnPostpone.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPostpone.DrawShadows = true;
            this.btnPostpone.HighEmphasis = true;
            this.btnPostpone.Icon = null;
            this.btnPostpone.Location = new System.Drawing.Point(120, 0);
            this.btnPostpone.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPostpone.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPostpone.Name = "btnPostpone";
            this.btnPostpone.Size = new System.Drawing.Size(120, 27);
            this.btnPostpone.TabIndex = 1;
            this.btnPostpone.Text = "Postpone";
            this.btnPostpone.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnPostpone.UseAccentColor = false;
            this.btnPostpone.UseVisualStyleBackColor = true;
            // 
            // btnSkip
            // 
            this.btnSkip.AutoSize = false;
            this.btnSkip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSkip.Depth = 0;
            this.btnSkip.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSkip.DrawShadows = true;
            this.btnSkip.HighEmphasis = true;
            this.btnSkip.Icon = null;
            this.btnSkip.Location = new System.Drawing.Point(240, 0);
            this.btnSkip.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSkip.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(120, 27);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "Skip";
            this.btnSkip.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnSkip.UseAccentColor = false;
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // pnlReminderOptions
            // 
            this.pnlReminderOptions.BackColor = System.Drawing.SystemColors.Control;
            this.pnlReminderOptions.Controls.Add(this.btnSkip);
            this.pnlReminderOptions.Controls.Add(this.btnPostpone);
            this.pnlReminderOptions.Controls.Add(this.btnDisable);
            this.pnlReminderOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReminderOptions.Location = new System.Drawing.Point(0, 97);
            this.pnlReminderOptions.Name = "pnlReminderOptions";
            this.pnlReminderOptions.Size = new System.Drawing.Size(356, 27);
            this.pnlReminderOptions.TabIndex = 4;
            this.pnlReminderOptions.Visible = false;
            this.pnlReminderOptions.VisibleChanged += new System.EventHandler(this.pnlReminderOptions_VisibleChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RemindMeMaterialMessageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(356, 124);
            this.ControlBox = false;
            this.Controls.Add(this.pnlText);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pnlReminderOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemindMeMaterialMessageForm";
            this.ShowInTaskbar = false;
            this.Text = "RemindMe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemindMeMaterialMessageForm_FormClosing);
            this.Load += new System.EventHandler(this.RemindMeMessageForm_Load);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlReminderOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer tmrFadeout;
        private System.Windows.Forms.Timer tmrFadein;
        private System.Windows.Forms.Timer tmrTimeout;
        private System.Windows.Forms.Panel pnlText;
        private MaterialSkin.Controls.MaterialButton btnDisable;
        private MaterialSkin.Controls.MaterialButton btnPostpone;
        private MaterialSkin.Controls.MaterialButton btnSkip;
        private System.Windows.Forms.Panel pnlReminderOptions;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblText;
    }
}