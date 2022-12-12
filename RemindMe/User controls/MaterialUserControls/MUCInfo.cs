using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using Business_Logic_Layer;

namespace RemindMe
{
    public partial class MUCInfo : UserControl
    {
        public MUCInfo()
        {
            try
            {
                InitializeComponent();
                AddFont(Properties.Resources.Roboto_Medium);
                lblVersion.Text += IOVariables.RemindMeVersion;

                MaterialSkin.MaterialSkinManager.Instance.ThemeChanged += MaterialSkinManager_ThemeChanged;

                lblPreviousVersions.Font = new Font(pfc.Families[0], 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "Initialization of MUCInfo failed!");
            }
        }

        private void MaterialSkinManager_ThemeChanged(object sender)
        {
            lblPreviousVersions.LinkColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.AccentColor;
            lblPreviousVersions.ActiveLinkColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.LightPrimaryColor;
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


        private void btnSupport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.buymeacoffee.com/RemindMe");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Stefangansevles/RemindMe");
        }

        private void lblPreviousVersions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string releaseNotesString = "";
            foreach (KeyValuePair<string, string> entry in UpdateInformation.ReleaseNotes)
            {
                releaseNotesString += "Version " + entry.Key + "\r\n" + entry.Value + "\r\n\r\n\r\n";                
            }
            MaterialWhatsNew wn = new MaterialWhatsNew("2.4.15", releaseNotesString);
            MaterialForm1.Instance.SkinManager.AddFormToManage(wn);
            wn.Location = this.Location;
            wn.Show();
        }
    }
}
