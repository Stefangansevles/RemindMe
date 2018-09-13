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

namespace RemindMe
{
    public partial class AVR_UCFiles : UserControl
    {
        private Dictionary<string, string> filesFolders;
        public AVR_UCFiles()
        {
            InitializeComponent();
            filesFolders = new Dictionary<string, string>();
        }

        public Dictionary<string, string> FilesFolders
        {
            get { return filesFolders; }
            set
            {
                filesFolders = value;
                lvItems.Items.Clear();
                foreach (KeyValuePair<string, string> entry in value)
                {                    
                    AddListviewItem(entry.Key, entry.Value);
                }
            }
        }

        private void AddListviewItem(string item1,string item2)
        {          
            if (string.IsNullOrWhiteSpace(item1) || string.IsNullOrWhiteSpace(item2))
                return;

            if (!filesFolders.ContainsKey(item1))            
                filesFolders.Add(item1, item2);                            

            BLIO.Log("(AVR) Add listview item");
            ListViewItem item = new ListViewItem(item1);
            item.SubItems.Add(item2);
            lvItems.Items.Add(item);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BLIO.Log("(AVR) btnAdd click. Select open or delete");
            string option = RemindMeOptionPrompt.Show(new List<string> { "Open", "Delete" },"Choose an action");
            if(!string.IsNullOrWhiteSpace(option))
            {
                BLIO.Log("(AVR) selected: " + option + " Select file or folder");
                string option2 = RemindMeOptionPrompt.Show(new List<string> { "A file", "A folder"},"Choose File/Folder");
                BLIO.Log("(AVR) selected: " + option2);
                if (option2 == "A file")
                {
                    //Get the selected file(s) and display them in the listview
                    foreach (string item in FSManager.Files.GetSelectedFilesWithPath())                    
                        AddListviewItem(item, option);                    
                }
                else if (option2 == "A folder")
                {
                    //Get the selected folder and display them in the listview
                    AddListviewItem(FSManager.Folders.GetSelectedFolderPath(), option);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            BLIO.Log("(AVR) btnRemove click");
            foreach (ListViewItem itm in lvItems.SelectedItems)
            {
                lvItems.Items.Remove(itm);                
                filesFolders.Remove(itm.Text);
            }
        }

        private void lvItems_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Delete)
                btnRemove_Click(sender, e);            

            if (e.Control && e.KeyCode == Keys.A)
            {
                //Ctrl+a = select all items
                BLIO.Log("selecting all items (AVR_UCFILES) (Ctrl + a ).");
                foreach (ListViewItem item in lvItems.Items)
                    item.Selected = true;
            }
        }
    }

    
}
