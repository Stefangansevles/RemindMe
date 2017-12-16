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

namespace RemindMe
{
    public partial class UCResizePopup : UserControl
    {
        Reminder testrem;
        Popup testPop;
        PopupDimensions dimensions;
        public UCResizePopup()
        {
            InitializeComponent();

            testrem = new Reminder();
            testrem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testrem.Name = "Test reminder";
            testrem.Note = "Test Note\r\nWith spaces\r\n\r\nAnd more spaces";
            testrem.Id = -1;//mark it to be invalid

            trbWidth.Maximum = Screen.GetWorkingArea(this).Width;
            trbHeight.Maximum = Screen.GetWorkingArea(this).Height;


            trbHeight.MouseUp += Trackbar_Value_End;
            trbWidth.MouseUp += Trackbar_Value_End;
            trbNoteFont.MouseUp += Trackbar_Value_End;
            trbTitleFont.MouseUp += Trackbar_Value_End;
            

            FillValues();
        }        

        private void FillValues()
        {
            dimensions = BLPopupDimensions.GetPopupDimensions();

            tbWidth.Text = dimensions.FormWidth.ToString();
            trbWidth.Value = (int)dimensions.FormWidth;

            tbHeight.Text = dimensions.FormHeight.ToString();
            trbHeight.Value = (int)dimensions.FormHeight;

            tbNoteFont.Text = dimensions.FontNoteSize.ToString();
            trbNoteFont.Value = (int)dimensions.FontNoteSize;

            tbTitleFont.Text = dimensions.FontTitleSize.ToString();
            trbTitleFont.Value = (int)dimensions.FontTitleSize;
            
        }

     

        private void UCResizePopup_Load(object sender, EventArgs e)
        {
            trbHeight.Refresh();
            trbWidth.Refresh();
            trbTitleFont.Refresh();
            trbNoteFont.Refresh();
        }

        private void trbTitleFont_Scroll(object sender, EventArgs e)
        {
            tbTitleFont.Text = trbTitleFont.Value.ToString();
            ApplyPreviewChanges();
        }

        private void trbNoteFont_Scroll(object sender, EventArgs e)
        {
            tbNoteFont.Text = trbNoteFont.Value.ToString();
            ApplyPreviewChanges();
        }

        private void trbHeight_Scroll(object sender, EventArgs e)
        {
            tbHeight.Text = trbHeight.Value.ToString();
            ApplyPreviewChanges();
        }

        private void trbWidth_Scroll(object sender, EventArgs e)
        {
            tbWidth.Text = trbWidth.Value.ToString();
            ApplyPreviewChanges();
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
                dimension.FontTitleSize = (long)trbTitleFont.Value;
                dimension.FormWidth = (long)trbWidth.Value;
                dimension.FormHeight = (long)trbHeight.Value;
                BLPopupDimensions.UpdatePopupDimensions(dimension);


                MessageFormManager.MakeMessagePopup("Succesfully changed settings.", 4);
            }
            catch
            {
                MessageFormManager.MakeMessagePopup("Changing settings failed", 4);
            }
        }

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            if (testPop == null || testPop.IsDisposed)
            {
                testPop = new Popup(testrem); //create a new instance                
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
                testPop.Width = (int)trbWidth.Value;
                testPop.Height = (int)trbHeight.Value;
                testPop.lblNoteText.Font = new Font(testPop.lblNoteText.Font.FontFamily, (float)trbNoteFont.Value, FontStyle.Bold);
                testPop.lblTitle.Font = new Font(testPop.lblTitle.Font.FontFamily, (float)trbTitleFont.Value, FontStyle.Bold);
                
                testPop.Show();              //show the new instance.            
            }
                            
            if (!testPop.Visible)
            {                
                testPop.Show();
                testPop.Visible = true;
            }
            else
                ApplyPreviewChanges();
        }

        private void ApplyPreviewChanges()
        {
            if (testPop != null && testPop.Visible)
            {
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
                testPop.Width = (int)trbWidth.Value;
                testPop.Height = (int)trbHeight.Value;
                testPop.lblNoteText.Font = new Font(testPop.lblNoteText.Font.FontFamily, (float)trbNoteFont.Value, FontStyle.Bold);
                testPop.lblTitle.Font = new Font(testPop.lblTitle.Font.FontFamily, (float)trbTitleFont.Value, FontStyle.Bold);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BLPopupDimensions.ResetToDefaults();            
            MessageFormManager.MakeMessagePopup("Succesfully reset settings.",4);

            FillValues();
            ApplyPreviewChanges();            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void tbWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int size = 0;
                bool success = int.TryParse(tbWidth.Text, out size);
                if(success)
                {
                    trbWidth.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }

        private void tbHeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int size = 0;
                bool success = int.TryParse(tbHeight.Text, out size);
                if (success)
                {
                    trbHeight.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }

        private void tbTitleFont_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int size = 0;
                bool success = int.TryParse(tbTitleFont.Text, out size);
                if (success)
                {
                    trbTitleFont.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }

        private void tbNoteFont_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int size = 0;
                bool success = int.TryParse(tbNoteFont.Text, out size);
                if (success)
                {
                    trbNoteFont.Value = size;
                    ApplyPreviewChanges();
                }
            }
        }
    }
}
