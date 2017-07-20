using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            LoadSongsIntoListview();
        }

        private void LoadSongsIntoListview()
        {
            List<Songs> songs = DLSongs.GetSongs();
            if (songs != null && songs.Count > 0)
            {

                foreach (Songs sng in songs)
                {
                    ListViewItem item = new ListViewItem(sng.SongFilePath);
                    item.Tag = sng.Id;
                    lvSoundFiles.Items.Add(item);
                }
            }
        }

        private void pbAddSounds_Click(object sender, EventArgs e)
        {
            List<string> songPaths = FSManager.Files.getSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();

            if(songPaths.Count == 1 && songPaths[0] == "")//The user canceled out
                return;            

            List<Songs> songs = new List<Songs>();

            foreach(string songPath in songPaths)
            {
                Songs song = new Songs();
                song.SongFileName = Path.GetFileName(songPath);
                song.SongFilePath = songPath;
                songs.Add(song);                
            }
            DLSongs.InsertSongs(songs);

            foreach (Songs song in songs)
            {
                if (!ListViewContains(song.SongFilePath))
                {
                    ListViewItem item = new ListViewItem(song.SongFilePath);
                    item.Tag = song.Id;
                    lvSoundFiles.Items.Add(item);
                }
            }
        }

       
        private bool ListViewContains(string songPath)
        {
            foreach(ListViewItem item in lvSoundFiles.Items)
            {
                if (item.Text == songPath)
                    return true;
            }
            return false;
        }
        private void pbRemoveSounds_Click(object sender, EventArgs e)
        {
            List<Songs> toRemoveSongs = new List<Songs>();

            foreach (ListViewItem selectedItem in lvSoundFiles.SelectedItems)
            {
                if (DLSongs.SongExistsInDatabase(selectedItem.Text))
                    toRemoveSongs.Add(DLSongs.GetSongById(Convert.ToInt32(selectedItem.Tag)));

                lvSoundFiles.Items.Remove(selectedItem);
            }

            DLSongs.RemoveSongs(toRemoveSongs);                                     
        }
    }
}
