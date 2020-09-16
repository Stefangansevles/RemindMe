using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace RemindMe
{
    public partial class MUCResizePopup : UserControl
    {
        Reminder testrem;
        MaterialPopup testPop;
        PopupDimensions dimensions;
        public MUCResizePopup()
        {
            InitializeComponent();

            testrem = new Reminder();
            testrem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testrem.Name = "Test reminder";
            testrem.Note = "This is some dummy text so that you can see how the text looks. Adding some spaces\r\nAnd some more\r\n\r\nSpaces.";
            testrem.Id = -1;//mark it to be invalid


            tbHeight.KeyPress += numericOnly_KeyPress;
            tbHeight.KeyDown += numericOnly_KeyDown;

            tbWidth.KeyPress += numericOnly_KeyPress;
            tbWidth.KeyDown += numericOnly_KeyDown;

            tbNoteFont.KeyPress += numericOnly_KeyPress;
            tbNoteFont.KeyDown += numericOnly_KeyDown;
            


            trbHeight.MouseUp += Trackbar_Value_End;
            trbWidth.MouseUp += Trackbar_Value_End;
            trbNoteFont.MouseUp += Trackbar_Value_End;
            
            trbWidth.MaximumValue = Screen.GetWorkingArea(this).Width;
            trbHeight.MaximumValue = Screen.GetWorkingArea(this).Height;

            FillValues();
        }

        private void numericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void numericOnly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }

        private void MUCResizePopup_VisibleChanged(object sender, EventArgs e)
        {
            refreshTrackbars();
        }

        /// <summary>
        /// Bunifu trackbar looks good but is a bit buggy, invalidating it kinda fixes it
        /// </summary>
        private void refreshTrackbars()
        {            
            trbWidth.IndicatorColor = MaterialForm1.MaterialSkinManager.ColorScheme.PrimaryColor;
            trbHeight.IndicatorColor = MaterialForm1.MaterialSkinManager.ColorScheme.PrimaryColor;            
            trbNoteFont.IndicatorColor = MaterialForm1.MaterialSkinManager.ColorScheme.PrimaryColor;

            trbWidth.BackgroudColor = Color.DarkGray;
            trbHeight.BackgroudColor = Color.DarkGray;            
            trbNoteFont.BackgroudColor = Color.DarkGray;

            trbWidth.Invalidate();
            trbHeight.Invalidate();            
            trbNoteFont.Invalidate();
        }

        private void FillValues()
        {
            dimensions = BLLocalDatabase.PopupDimension.GetPopupDimensions();

            tbWidth.Text = dimensions.FormWidth.ToString();
            trbWidth.Value = (int)dimensions.FormWidth;

            tbHeight.Text = dimensions.FormHeight.ToString();
            trbHeight.Value = (int)dimensions.FormHeight;

            tbNoteFont.Text = dimensions.FontNoteSize.ToString();
            trbNoteFont.Value = (int)dimensions.FontNoteSize;
            
            refreshTrackbars();
        }



        private void MUCResizePopup_Load(object sender, EventArgs e)
        {
            trbHeight.Refresh();
            trbWidth.Refresh();            
            trbNoteFont.Refresh();
            //refreshTrackbars();

            AddFont(Properties.Resources.Roboto_Medium);
        }

       

        private void Trackbar_Value_End(object sender, MouseEventArgs e)
        {

        }

        private void SaveChanges()
        {
            try
            {
                PopupDimensions dimension = new PopupDimensions();
                dimension.FontNoteSize = (long)trbNoteFont.Value;
                dimension.FontTitleSize = 1;
                dimension.FormWidth = (long)trbWidth.Value;
                dimension.FormHeight = (long)trbHeight.Value;
                BLLocalDatabase.PopupDimension.UpdatePopupDimensions(dimension);


                MaterialMessageFormManager.MakeMessagePopup("Succesfully changed settings.", 4);
            }
            catch
            {
                MaterialMessageFormManager.MakeMessagePopup("Changing settings failed", 4);
            }
        }

      

        private void ApplyPreviewChanges()
        {
            if (testPop != null && testPop.Visible)
            {
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
                testPop.Width = (int)trbWidth.Value;
                testPop.Height = (int)trbHeight.Value;
                testPop.ChangeFontSize(trbNoteFont.Value);                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCResizePopup)btnReset_Click");
            BLLocalDatabase.PopupDimension.ResetToDefaults();
            MaterialMessageFormManager.MakeMessagePopup("Succesfully reset settings.", 4);

            FillValues();
            ApplyPreviewChanges();
            refreshTrackbars();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCResizePopup)btnSave_Click");
            testPop.Close();
            SaveChanges();
            refreshTrackbars();
        }

        private void tbWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BLIO.Log("tbWidth_KeyUp (Enter) with value: " + tbWidth.Text);
                int size = 0;
                bool success = int.TryParse(tbWidth.Text, out size);
                if (success)
                {
                    if (size > trbWidth.MaximumValue)
                        size = trbWidth.MaximumValue;
                    if (size < 350)
                        size = 350;

                    tbWidth.Text = size.ToString();

                    trbWidth.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }

        private void tbHeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BLIO.Log("tbHeight_KeyUp (Enter) with value: " + tbHeight.Text);
                int size = 0;
                bool success = int.TryParse(tbHeight.Text, out size);
                if (success)
                {
                    if (size > trbHeight.MaximumValue)
                        size = trbHeight.MaximumValue;
                    if (size < 300)
                        size = 300;

                    tbHeight.Text = size.ToString();

                    trbHeight.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }



        private void tbNoteFont_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BLIO.Log("tbNoteFont_KeyUp (Enter) with value: " + tbNoteFont.Text);
                int size = 0;
                bool success = int.TryParse(tbNoteFont.Text, out size);
                if (success)
                {
                    if (size > trbNoteFont.MaximumValue)
                        size = trbNoteFont.MaximumValue;
                    if (size < 1)
                        size = 1;

                    tbNoteFont.Text = size.ToString();

                    trbNoteFont.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }        

       

        private void btnTest_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCResizePopup)btnAddReminder_Click");
            if (testPop == null || testPop.IsDisposed)
            {
                testPop = new MaterialPopup(testrem); //create a new instance    
                MaterialForm1.MaterialSkinManager.AddFormToManage(testPop);
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
                testPop.Width = (int)trbWidth.Value;
                testPop.Height = (int)trbHeight.Value;                                                

                testPop.Show();              //show the new instance.            

                
            }

            if (!testPop.Visible)
            {
                testPop.Show();
                testPop.Visible = true;
            }
            else
                ApplyPreviewChanges();

            refreshTrackbars();
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
        private void trbNoteFont_ValueChanged(object sender, EventArgs e)
        {
            tbNoteFont.Text = trbNoteFont.Value.ToString();
            ApplyPreviewChanges();
            trbNoteFont.Invalidate();
        }

 

        private void trbHeight_ValueChanged(object sender, EventArgs e)
        {
            if (trbHeight.Value < 300)
                trbHeight.Value = 300;

            tbHeight.Text = trbHeight.Value.ToString();
            ApplyPreviewChanges();
            trbHeight.Invalidate();
        }

        private void trbWidth_ValueChanged(object sender, EventArgs e)
        {
            if (trbWidth.Value < 350)
                trbWidth.Value = 350;

            tbWidth.Text = trbWidth.Value.ToString();
            ApplyPreviewChanges();
            trbWidth.Invalidate();
        }
    }
}
