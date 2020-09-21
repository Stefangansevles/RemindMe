using Business_Logic_Layer;
using Database.Entity;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// An option dialogue giving the user the option to choose yes or no, or just ok.
    /// </summary>
    public partial class MaterialRemindMeBox : MaterialForm
    {
        private string description;
        private static DialogResult result;
        private static MaterialRemindMeBox newMessageBox;
        private static bool showDontRemind;
        private MaterialRemindMeBox(string description, RemindMeBoxReason buttons, bool showDontRemindOption)
        {
            BLIO.Log("Constructing RemindMeBox(" + description + "");
            //We will use the default "Attention" title text
            InitializeComponent();
            AddFont(Properties.Resources.Roboto_Medium);
            
            showDontRemind = showDontRemindOption;

            if (buttons == RemindMeBoxReason.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            else
                btnOk.Visible = true;

            if (showDontRemind)
                pnlRemind.Visible = true;

            this.description = description;

            this.Opacity = 0;
            tmrFadeIn.Start();
            lblText.MaximumSize = new Size((pnlMainGradient.Width - lblText.Location.X) - 10, 0);            


            lblText.Text = description;




            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
            {
                this.Height += 35;
                pnlMainGradient.Height += 35;
            }


            Form1 remindme = (Form1)Application.OpenForms["Form1"];
            if (remindme != null && remindme.Visible)
            {
                //Place the message box in the middle of remindme
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            BLIO.Log("RemindMeBox constructed");
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
        

        private MaterialRemindMeBox(string title, string description, RemindMeBoxReason buttons, bool showDontRemindOption) : this(description, buttons, showDontRemindOption)
        {
            this.Text = title;

            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;

        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            newMessageBox.Close();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            if (cbDontRemind.Checked)
            {
                Settings settingsObject = BLLocalDatabase.Setting.Settings;
                settingsObject.HideReminderConfirmation = 1;
                BLLocalDatabase.Setting.UpdateSettings(settingsObject);
            }
            newMessageBox.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            newMessageBox.Close();
            this.Close();
        }

        public static DialogResult Show(string text, bool showDontRemindOption = false)
        {
            newMessageBox = new MaterialRemindMeBox(text, RemindMeBoxReason.OK, showDontRemindOption);
            MaterialForm1.MaterialSkinManager.AddFormToManage(newMessageBox);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);
            return result;
        }
        public static DialogResult Show(string text, RemindMeBoxReason buttons, bool showDontRemindOption = false)
        {
            newMessageBox = new MaterialRemindMeBox(text, buttons, showDontRemindOption);
            MaterialForm1.MaterialSkinManager.AddFormToManage(newMessageBox);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);
            return result;
        }
        public static DialogResult Show(string text, string title, RemindMeBoxReason buttons, bool showDontRemindOption = false)
        {
            newMessageBox = new MaterialRemindMeBox(text, title, buttons, showDontRemindOption);
            MaterialForm1.MaterialSkinManager.AddFormToManage(newMessageBox);
            newMessageBox.ShowDialog();
            BLIO.Log("Closing RemindMeBox with result " + result);
            return result;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            cbDontRemind.Checked = !cbDontRemind.Checked;            
        }

        private void tmrFadeIn_Tick_1(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        private void MaterialRemindMeBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialForm1.MaterialSkinManager.RemoveFormToManage(this);
        }

        private void MaterialRemindMeBox_Load(object sender, EventArgs e)
        {
            lblText.Font = new Font(pfc.Families[0], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            if (MaterialForm1.MaterialSkinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                lblText.ForeColor = Color.White;
        }
    }

   

}
