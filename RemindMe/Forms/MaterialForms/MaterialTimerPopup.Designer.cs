namespace RemindMe
{
    partial class MaterialTimerPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialTimerPopup));
            this.tbTime = new MaterialSkin.Controls.MaterialTextBox();
            this.tbNote = new MaterialSkin.Controls.MaterialTextBox();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.lblErrorText = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // tbTime
            // 
            this.tbTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTime.Depth = 0;
            this.tbTime.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbTime.Hint = "Minutes (1h30m = 90 min)";
            this.tbTime.Location = new System.Drawing.Point(37, 81);
            this.tbTime.MaxLength = 50;
            this.tbTime.MouseState = MaterialSkin.MouseState.OUT;
            this.tbTime.Multiline = false;
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(158, 50);
            this.tbTime.TabIndex = 0;
            this.tbTime.Text = "";
            // 
            // tbNote
            // 
            this.tbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNote.Depth = 0;
            this.tbNote.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbNote.Hint = "Note (Optional)";
            this.tbNote.Location = new System.Drawing.Point(37, 137);
            this.tbNote.MaxLength = 0;
            this.tbNote.MouseState = MaterialSkin.MouseState.OUT;
            this.tbNote.Multiline = false;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(158, 50);
            this.tbNote.TabIndex = 1;
            this.tbNote.Text = "";
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // lblErrorText
            // 
            this.lblErrorText.AlternativeForeColor = System.Drawing.Color.Red;
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.Depth = 0;
            this.lblErrorText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblErrorText.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.lblErrorText.Location = new System.Drawing.Point(75, 191);
            this.lblErrorText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(80, 17);
            this.lblErrorText.TabIndex = 6;
            this.lblErrorText.Text = "Invalid input";
            this.lblErrorText.Visible = false;
            // 
            // MaterialTimerPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(245, 223);
            this.Controls.Add(this.lblErrorText);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.tbTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialTimerPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting a quick timer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimerPopup_FormClosed);
            this.Load += new System.EventHandler(this.TimerPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox tbTime;
        private MaterialSkin.Controls.MaterialTextBox tbNote;
        private System.Windows.Forms.Timer tmrFadeIn;
        private MaterialSkin.Controls.MaterialLabel lblErrorText;
    }
}