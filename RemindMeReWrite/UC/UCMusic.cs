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
    public partial class UCMusic : UserControl
    {
        public UCMusic()
        {
            InitializeComponent();
        }

        private void UCMusic_Load(object sender, EventArgs e)
        {
            List<string> sounds = BLIO.ReadSoundFiles();
            if(sounds != null && sounds.Count > 0)
                AddItemToListView(sounds);            
        }

        private void pbAddSounds_Click(object sender, EventArgs e)
        {
            List<string> sounds = BLIO.AddSoundsToFile();
            if(sounds.Count > 0)
                AddItemToListView(sounds);
        }

        private void AddItemToListView(List<string> files)
        {
            foreach(string file in files)
            {
                if(file != "")
                lvSoundFiles.Items.Add(file);
            }
        }

        private void pbRemoveSounds_Click(object sender, EventArgs e)
        {
            List<string> currentSounds = BLIO.ReadSoundFiles();

            foreach (ListViewItem selectedItem in lvSoundFiles.SelectedItems)
            {                
                if (currentSounds.Contains(selectedItem.Text))
                {
                    currentSounds.Remove(selectedItem.Text);
                }
                lvSoundFiles.Items.Remove(selectedItem);
            }

            BLIO.WriteSettings(currentSounds,true, BLIO.ReadAlwaysOnTop());
                //if(song == lvSoundFiles.SelectedItems)
            
        }
    }
}
