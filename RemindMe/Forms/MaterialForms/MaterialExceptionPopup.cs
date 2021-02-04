using Business_Logic_Layer;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MaterialExceptionPopup : MaterialForm
    {
        private Exception exception;
        private bool customFeedback;
        private static int activePopups = 0;
        MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
        public MaterialExceptionPopup(Exception ex, string message = null)
        {                        
            if (activePopups < 3)
            {
                AddFont(Properties.Resources.Roboto_Medium);
                BLIO.Log("Constructing ExceptionPopup ( " + ex.GetType().ToString() + " )");
                activePopups++;
                skinManager.AddFormToManage(this);
                skinManager.ThemeChanged += SkinManager_ThemeChanged;
                InitializeComponent();

                this.exception = ex;

                lblMessage.MaximumSize = new Size((pnlContent.Width - lblText.Location.X) - 10, 50);

                //Set the location within the remindme window. 
                //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
                Form1 remindme = (Form1)Application.OpenForms["Form1"];
                if (remindme != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
                }

                if (!string.IsNullOrWhiteSpace(message))
                    lblMessage.Text = "Problem description: " + message;

                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;

                BLIO.Log("Constructing ExceptionPopup complete");
            }
            else
            {
                //There are 2 active popups already. Do not show another one! 

                this.Opacity = 0;
                this.ShowInTaskbar = false;

                InitializeComponent(); //so we can call the timer that disposes this form. Closing/disposing from the constructor is not possible

                BLIO.Log("IGNORE Popup(" + ex.GetType().ToString() + "). " + activePopups + " Popups active!");
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        private static uint cFonts = 0;
        private static void AddFont(byte[] fontdata)
        {
            int fontLength; System.IntPtr dataPointer;

            //We are going to need a pointer to the font data, so we are generating it here
            dataPointer = Marshal.AllocCoTaskMem(fontdata.Length);


            //Copying the fontdata into the memory designated by the pointer
            Marshal.Copy(fontdata, 0, dataPointer, (int)fontdata.Length);

            // Register the font with the system.
            AddFontMemResourceEx(dataPointer, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            //Keep track of how many fonts we've added.
            cFonts += 1;

            //Finally, we can actually add the font to our collection
            pfc.AddMemoryFont(dataPointer, (int)fontdata.Length);
        }

        private void SkinManager_ThemeChanged(object sender)
        {
            if (skinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                pbInfo.BackgroundImage = Properties.Resources.infoWhite;
            else
                pbInfo.BackgroundImage = Properties.Resources.infoDark;
        }

        private void ExceptionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string logTxtPath = IOVariables.systemLog;
                BLIO.Log("Closing ExceptionPopup...");
                if (!customFeedback) //If the user didn't leave instructions of how this problem happened, just log the exception / stacktrace and logfile
                    BLOnlineDatabase.AddException(exception, DateTime.UtcNow, logTxtPath, "NONE_SET");
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                
                BLIO.Log("btnOk pressed on ExceptionPopup. textbox text = " + tbFeedback.Text);
                string logTxtPath = IOVariables.systemLog;
                string textBoxText = tbFeedback.Text; //Cant access tbNote in a thread. save the text in a variable instead

                if (string.IsNullOrWhiteSpace(textBoxText) || tbFeedback.ForeColor == Color.Gray)
                    textBoxText = "NONE_SET";

                BLOnlineDatabase.AddException(exception, DateTime.UtcNow, logTxtPath, textBoxText);

                if (textBoxText != null)
                    MaterialMessageFormManager.MakeMessagePopup("Feedback sent.\r\nThank you for taking the time!", 5);

                //Set this boolean to true so that when this popup closes, we won't try to add another db entry
                customFeedback = true;
                btnOk.Enabled = false;

                this.Close();
                this.Dispose();
            }
            catch { }
        }
                
        private void tbFeedback_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFeedback.Text))
            {
                tbFeedback.Text = "If you can, please describe how this happened here...";
                tbFeedback.ForeColor = Color.Gray;
            }
        }

        private void tbFeedback_Enter(object sender, EventArgs e)
        {
            if (tbFeedback.ForeColor == Color.Gray & tbFeedback.Text == "If you can, please describe how this happened here...")
            {
                tbFeedback.Text = "";
                tbFeedback.ForeColor = Color.White;
            }
        }

        private void ExceptionPopup_Load(object sender, EventArgs e)
        {
            if (activePopups > 2)
            {
                BLIO.Log("[ExceptionPopup " + activePopups + "] ExceptionPopup_Load   closing form...");
                this.Close();
            }

            lblMessage.Font = new Font(pfc.Families[0], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            if (skinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                pbInfo.BackgroundImage = Properties.Resources.infoWhite;            
        }
             
        private void MaterialExceptionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            activePopups--;
            skinManager.RemoveFormToManage(this);
        }

        private void lblMessage_SizeChanged(object sender, EventArgs e)
        {
            tbFeedback.Location = new Point(tbFeedback.Location.X, (lblMessage.Location.Y + lblMessage.Height) + 5);
        }
    }
}
