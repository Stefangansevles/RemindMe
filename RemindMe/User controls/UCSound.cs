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
using System.IO;
using WMPLib;

namespace RemindMe
{
    public partial class UCSound : UserControl
    {
        //Used to play a sound
        private static WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        private IWMPMedia mediaInfo;

        private Image imgPlay = Properties.Resources.Play;
        private Image imgStop = Properties.Resources.Stop;
        public UCSound()
        {
            InitializeComponent();
        }
        

        private void ShowFilePath(bool showPath)
        {
            foreach(ListViewItem item in lvSoundFiles.Items)
            {
                Songs theSong = BLSongs.GetSongById((long)item.Tag);

                if(showPath)
                    item.Text = theSong.SongFilePath;
                else
                    item.Text = theSong.SongFileName;
            }
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if (bunifuSwitch1.Value)
                ShowFilePath(true);
            else
                ShowFilePath(false);
        }
        private void LoadSongs()
        {
            lvSoundFiles.Items.Clear();
            List<Songs> songs = BLSongs.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").ToList();
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
        private void UCSound_Load(object sender, EventArgs e)
        {
            LoadSongs();
            btnPreview.Iconimage = imgPlay;
        }

        private bool ListViewContains(string songPath)
        {
            foreach (ListViewItem item in lvSoundFiles.Items)
            {
                if (item.Text == songPath)
                    return true;
            }
            return false;
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            int songsAdded = 0;
            List<string> songPaths = FSManager.Files.GetSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();

            if (songPaths.Count == 1 && songPaths[0] == "")//The user canceled out
                return;

            BLIO.Log("user selected " + songPaths.Count + " mp3 / wav files.");

            List<Songs> songs = new List<Songs>();

            foreach (string songPath in songPaths)
            {
                Songs song = new Songs();
                song.SongFileName = Path.GetFileName(songPath);
                song.SongFilePath = songPath;
                songs.Add(song);
            }
            BLSongs.InsertSongs(songs);
            BLIO.Log("Inserted " + songs.Count + " sound files into RemindME");

            foreach (Songs song in songs)
            {
                if (!ListViewContains(song.SongFilePath))
                {
                    songsAdded++;
                    ListViewItem item = new ListViewItem(song.SongFilePath);
                    item.Tag = song.Id;
                    lvSoundFiles.Items.Add(item);
                }
            }
            MessageFormManager.MakeMessagePopup(songsAdded + " Files added to RemindMe.", 4);

            LoadSongs();
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            List<Songs> toRemoveSongs = new List<Songs>();

            foreach (ListViewItem selectedItem in lvSoundFiles.SelectedItems)
            {
                toRemoveSongs.Add(BLSongs.GetSongById(Convert.ToInt32(selectedItem.Tag)));
                lvSoundFiles.Items.Remove(selectedItem);
            }

            BLSongs.RemoveSongs(toRemoveSongs);

            if(toRemoveSongs.Count > 0)
                MessageFormManager.MakeMessagePopup(toRemoveSongs.Count + " Files removed from RemindMe.", 4);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvSoundFiles.SelectedItems.Count == 1)
            {
                Songs selectedSong = BLSongs.GetSongById((long)lvSoundFiles.SelectedItems[0].Tag);
                BLIO.Log("Attempting to preview sound file with id " + selectedSong.Id);

                if (btnPreview.Iconimage == imgPlay)
                {
                    if (System.IO.File.Exists(selectedSong.SongFilePath))
                    {
                        BLIO.Log("Sound file exists on the hard drive");
                        btnPreview.Iconimage = imgStop;

                        myPlayer.URL = selectedSong.SongFilePath;
                        mediaInfo = myPlayer.newMedia(myPlayer.URL);

                        //Start the timer. the timer ticks when the song ends. The timer will then reset the picture of the play button                        
                        if (mediaInfo.duration > 0)
                            tmrMusic.Interval = (int)(mediaInfo.duration * 1000);
                        else
                            tmrMusic.Interval = 1000;
                        tmrMusic.Start();


                        myPlayer.controls.play();
                        BLIO.Log("Playing sound.");
                    }
                    else
                        MessageFormManager.MakeMessagePopup("Could not preview the selected song. Does it still exist?", 4);
                }
                else
                {
                    BLIO.Log("Stopping sound");
                    btnPreview.Iconimage = imgPlay;
                    myPlayer.controls.stop();
                    tmrMusic.Stop();
                }
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPreview.Iconimage = imgPlay;
            tmrMusic.Stop();
            BLIO.Log("Sound file playing ended");
        }

        private void lvSoundFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Iconimage = imgPlay;
                myPlayer.controls.stop();
                tmrMusic.Stop();
                btnPreview_Click(sender, e);
            }
                
        }

        private void lvSoundFiles_DoubleClick(object sender, EventArgs e)
        {
            btnPreview.Iconimage = imgPlay;
            myPlayer.controls.stop();
            tmrMusic.Stop();
            btnPreview_Click(sender, e);
        }
    }
}
