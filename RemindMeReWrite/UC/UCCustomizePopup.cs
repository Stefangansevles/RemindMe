using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Database.Entity;

namespace RemindMe
{
    public partial class UCCustomizePopup : UserControl
    {
        Reminder testrem;
        Popup testPop;
        PopupDimensions dimensions;
        public UCCustomizePopup()
        {
            InitializeComponent();            

            testrem = new Reminder();
            testrem.Date = Convert.ToDateTime("2010-10-10 00:00:00").ToString();
            testrem.Name = "Test reminder";
            testrem.Note = "Test Note\r\nWith spaces\r\n\r\nAnd more spaces";
            testrem.Id = -1;//mark it to be invalid
                                   
            FillValues();
        }

        private void FillValues()
        {
            dimensions = BLPopupDimensions.GetPopupDimensions();

            numWidth.Value = dimensions.FormWidth;
            numheight.Value = dimensions.FormHeight;
            numNoteFontSize.Value = dimensions.FontNoteSize;
            numTitleFontSize.Value = dimensions.FontTitleSize;
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            //Screen.GetWorkingArea(this).Width - this.Width, Screen.GetWorkingArea(this).Height
            if (numWidth.Value > Screen.GetWorkingArea(this).Width)
            {
                pbExclamationWidth.Visible = true;
                toolTip1.SetToolTip(pbExclamationWidth, "Entered width is larger than your monitor's width!");
            }
            else
                pbExclamationWidth.Visible = false;

            ApplyPreviewChanges();
        }

        private void numHeigth_ValueChanged(object sender, EventArgs e)
        {
            //Screen.GetWorkingArea(this).Width - this.Width, Screen.GetWorkingArea(this).Height
            if (numheight.Value > Screen.GetWorkingArea(this).Height)
            {
                pbExclamationHeight.Visible = true;
                toolTip1.SetToolTip(pbExclamationHeight, "Entered height is larger than your monitor's height!");
            }
            else
                pbExclamationHeight.Visible = false;

            ApplyPreviewChanges();
        }

        private void btnTestPopup_Click(object sender, EventArgs e)
        {
            
           
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            try
            {
                PopupDimensions dimension = new PopupDimensions();
                dimension.FontNoteSize = (long)numNoteFontSize.Value;
                dimension.FontTitleSize = (long)numTitleFontSize.Value;
                dimension.FormWidth = (long)numWidth.Value;
                dimension.FormHeight = (long)numheight.Value;
                BLPopupDimensions.UpdatePopupDimensions(dimension);


                pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
                lblStatus.Text = "Succesfully changed settings.";
            }
            catch
            {
                pbStatus.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
                lblStatus.Text = "Changing settings failed.";
            }
        }

        private void pbTest_Click(object sender, EventArgs e)
        {            
            if (testPop == null || testPop.IsDisposed)
            {
                testPop = new Popup(testrem); //create a new instance
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
                testPop.Width = (int)numWidth.Value;
                testPop.Height = (int)numheight.Value;
                testPop.tbText.Font = new Font(testPop.tbText.Font.FontFamily, (float)numNoteFontSize.Value, FontStyle.Bold);
                testPop.tbTitle.Font = new Font(testPop.tbTitle.Font.FontFamily, (float)numTitleFontSize.Value, FontStyle.Bold);
                
                testPop.Show();              //show the new instance.            
            }
            else
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);

            if (!testPop.Visible)
            {
                testPop.MaximumSize = new Size(int.MaxValue, int.MaxValue);
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
                testPop.Width = (int)numWidth.Value;
                testPop.Height = (int)numheight.Value;
                testPop.tbText.Font = new Font(testPop.tbText.Font.FontFamily, (float)numNoteFontSize.Value, FontStyle.Bold);
                testPop.tbTitle.Font = new Font(testPop.tbTitle.Font.FontFamily, (float)numTitleFontSize.Value, FontStyle.Bold);
            }          
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pbTest_Click(sender, e);
        }

        private void pbReset_Click(object sender, EventArgs e)
        {
            BLPopupDimensions.ResetToDefaults();
            pbStatus.BackgroundImage = Properties.Resources.dark_green_check_mark_hi;
            lblStatus.Text = "Succesfully reset settings.";

            FillValues();
        }

        private void numTitleFontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyPreviewChanges();
        }

        private void numNoteFontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyPreviewChanges();
        }
    }
}
