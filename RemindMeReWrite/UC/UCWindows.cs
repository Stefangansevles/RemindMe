using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class UCWindows : UserControl
    {
        bool alwaysOnTop = true;
        public UCWindows()
        {
            InitializeComponent();
        }

        private void cbPopupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cbPopupType.SelectedItem.ToString() == "Always on top (Recommended)")
                alwaysOnTop = true;            
            else
                alwaysOnTop = false;

            BLIO.WriteSettings(BLIO.ReadSoundFiles(), false, alwaysOnTop);
        }

        private void UCWindows_Load(object sender, EventArgs e)
        {
            //Since we're not going to change the contents of this combobox anyway, we're just going to do it like this
            if (BLIO.ReadAlwaysOnTop())
                cbPopupType.SelectedItem = cbPopupType.Items[0]; 
            else
                cbPopupType.SelectedItem = cbPopupType.Items[1];
        }
    }
}
