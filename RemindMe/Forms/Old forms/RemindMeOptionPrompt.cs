using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class RemindMeOptionPrompt : Form
    {
        private static string option;        
        private static RemindMeOptionPrompt self;        
        public RemindMeOptionPrompt(List<string> options, string title = "Choose an option")
        {
            InitializeComponent();
            cbOptions.Items.AddRange(options.ToArray());            

            this.StartPosition = FormStartPosition.CenterParent;        
            lblTitle.Text = title;

            option = "";
        }        

       

        public static string Show(List<string> options, string title = "Choose an option")
        {
            self = new RemindMeOptionPrompt(options,title);
            self.ShowDialog();
            BLIO.Log("Closing RemindMeOptionPrompt with result " + option);
            return option;
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            option = cbOptions.SelectedItem.ToString();
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
