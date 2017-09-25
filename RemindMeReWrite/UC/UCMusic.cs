using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FSManager;
using Database.Entity;
using Business_Logic_Layer;

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
            LoadSongsWithFileNameIntoListview();
        }

        private void LoadSongsWithFileNameIntoListview()
        {
            lvSoundFiles.Items.Clear();
            List<Songs> songs = BLSongs.GetSongs();
            songs = songs.OrderBy(s => s.SongFileName).ToList();
            if (songs != null && songs.Count > 0)
            {

                foreach (Songs sng in songs)
                {
                    ListViewItem item = new ListViewItem(sng.SongFileName);
                    item.Tag = sng.Id;
                    lvSoundFiles.Items.Add(item);
                }
            }
        }
        private void LoadSongsWithFilePathIntoListview()
        {
            lvSoundFiles.Items.Clear();
            List<Songs> songs = BLSongs.GetSongs();
            songs = songs.OrderBy(s => s.SongFilePath).ToList();
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
            List<string> songPaths = FSManager.Files.GetSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();
            
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
            BLSongs.InsertSongs(songs);

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
                if (BLSongs.SongExistsInDatabase(selectedItem.Text))
                    toRemoveSongs.Add(BLSongs.GetSongById(Convert.ToInt32(selectedItem.Tag)));

                lvSoundFiles.Items.Remove(selectedItem);
            }

            BLSongs.RemoveSongs(toRemoveSongs);                                     
        }

        private void cbShowFilePath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowFilePath.Checked)
                LoadSongsWithFilePathIntoListview();
            else
                LoadSongsWithFileNameIntoListview();
        }
    }
}
