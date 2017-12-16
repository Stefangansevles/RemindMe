using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// This class is a custom renderer for RemindMe toolstripmenu items. 
    /// It removes the highlight color and border color by setting the color to DimGray(same color as the toolstrips that use this renderer)
    /// The selection text color will be white for each menu item.
    /// </summary>
    public class MyToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        public MyToolStripMenuRenderer() : base(new MyToolStripColors()) { }        
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {            
            if (e.Item.Bounds.Contains(e.ToolStrip.PointToClient(Cursor.Position)))            
                e.TextColor = Color.White; //Set the selected item text color to white.            

            base.OnRenderItemText(e);
        }
    }
    public class MyToolStripColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(105, 105, 105); } //remove the highlight color by setting the color to the same color as the menustrip
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(105, 105, 105); } //remove the border color by setting the color to the same color as the menustrip
        }       
    }
}
