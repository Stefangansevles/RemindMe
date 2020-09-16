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
    public partial class MaterialWhatsNew : MaterialForm
    {
        public MaterialWhatsNew(string lastVersion, string data)
        {
            AddFont(Properties.Resources.Roboto_Medium);
            InitializeComponent();

            lblText.MaximumSize = new Size((pnlContent.Width - lblText.Location.X) - 35, 0);

            lblTitle.Text += lastVersion;
            lblText.Text = data;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            this.Close();
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

        private void MaterialWhatsNew_Load(object sender, EventArgs e)
        {
            lblText.Font = new Font(pfc.Families[0], 14f, FontStyle.Regular, GraphicsUnit.Pixel);

            if (MaterialForm1.MaterialSkinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                lblText.ForeColor = Color.White;
        }

        private void MaterialWhatsNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialForm1.MaterialSkinManager.RemoveFormToManage(this);
        }
    }
}
