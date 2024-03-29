﻿using System;
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

namespace RemindMe
{
    public partial class MUCSound : UserControl
    {
        private Image imgPlay = Properties.Resources.Play;
        private Image imgStop = Properties.Resources.Stop;
        public MUCSound()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "Initialization of MUCSound failed!");
            }            
        }


        private void ShowFilePath(bool showPath)
        {
            foreach (ListViewItem item in lvSoundFiles.Items)
            {
                Songs theSong = BLLocalDatabase.Song.GetSongById((long)item.Tag);

                if (showPath)
                    item.Text = theSong.SongFilePath;
                else
                    item.Text = theSong.SongFileName;
            }
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCSound)bunifuSwitch1_Click");
            if (swFilePath.Checked)
                ShowFilePath(true);
            else
                ShowFilePath(false);
        }
        private void LoadSongs()
        {
            try
            {
                lvSoundFiles.Items.Clear();
                List<Songs> songs = BLLocalDatabase.Song.GetSongs().Where(s => Path.GetDirectoryName(s.SongFilePath).ToLower() != "c:\\windows\\media").ToList();
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
            catch(Exception ex)
            {
                BLIO.WriteError(ex, "Loading songs failed");
            }
        }
        private void MUCSound_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSongs();
                btnPreview.Icon = imgPlay;
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "MUCSound Load failed!");
            }
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
            BLIO.Log("(MUCSound)btnAddFiles_Click");
            int songsAdded = 0;
            List<string> songPaths = FSManager.Files.GetSelectedFilesWithPath("Sound files", "*.mp3; *.wav; *.aiff;").ToList();

            if (songPaths.Count == 1 && songPaths[0] == "")//The user canceled out
                return;

            BLIO.Log("user selected " + songPaths.Count + " sound files.");



            List<Songs> songs = new List<Songs>();

            foreach (string songPath in songPaths)
            {
                Songs song = new Songs();
                song.SongFileName = Path.GetFileName(songPath);
                song.SongFilePath = songPath;
                songs.Add(song);
            }
            BLLocalDatabase.Song.InsertSongs(songs);
            BLIO.Log("Inserted " + songs.Count + " sound files into RemindMe");

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
            MaterialMessageFormManager.MakeMessagePopup(songsAdded + " Files added to RemindMe.", 4);
            MaterialForm1.Instance.mucSettings.FillSoundCombobox();
            LoadSongs();
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCSound)btnRemoveFiles_Click");
            List<Songs> toRemoveSongs = new List<Songs>();

            foreach (ListViewItem selectedItem in lvSoundFiles.SelectedItems)
            {
                toRemoveSongs.Add(BLLocalDatabase.Song.GetSongById(Convert.ToInt32(selectedItem.Tag)));
                lvSoundFiles.Items.Remove(selectedItem);
            }

            BLLocalDatabase.Song.RemoveSongs(toRemoveSongs);

            if (toRemoveSongs.Count > 0)
            {
                MaterialMessageFormManager.MakeMessagePopup(toRemoveSongs.Count + " Files removed from RemindMe.", 4);
                MaterialForm1.Instance.mucSettings.FillSoundCombobox();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            BLIO.Log("(MUCSound)btnPreview_Click");
            if (lvSoundFiles.SelectedItems.Count == 1)
            {
                Songs selectedSong = BLLocalDatabase.Song.GetSongById((long)lvSoundFiles.SelectedItems[0].Tag);
                BLIO.Log("Attempting to preview sound file with id " + selectedSong.Id);

                if (btnPreview.Icon == imgPlay)
                {
                    if (System.IO.File.Exists(selectedSong.SongFilePath))
                    {
                        BLIO.Log("Sound file exists on the hard drive");                        

                        int duration = BLIO.PlaySound(selectedSong.SongFilePath);
                        if(duration == -1)
                        {
                            MaterialMessageFormManager.MakeMessagePopup($"Could not preview the selected song. This type of file({Path.GetExtension(selectedSong.SongFilePath)}) is not supported.", 4);
                            return;
                        }

                        btnPreview.Icon = imgStop;
                        tmrMusic.Interval = duration;
                        tmrMusic.Start();
                    }
                    else
                        MaterialMessageFormManager.MakeMessagePopup("Could not preview the selected song. Does it still exist?", 4);
                }
                else
                {
                    BLIO.Log("Stopping sound");
                    btnPreview.Icon = imgPlay;
                    BLIO.StopSound();
                    tmrMusic.Stop();
                }
            }
        }

      
        private void lvSoundFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Icon = imgPlay;
                BLIO.StopSound();
                tmrMusic.Stop();
                btnPreview_Click(sender, e);
            }

        }

        private void lvSoundFiles_DoubleClick(object sender, EventArgs e)
        {
            btnPreview.Icon = imgPlay;
            BLIO.StopSound();
            tmrMusic.Stop();
            btnPreview_Click(sender, e);
        }

        private void MUCSound_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                BLIO.Log("Control MUCSound now visible");
                LoadSongs();
            }
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            btnPreview.Icon = imgPlay;
            tmrMusic.Stop();
            BLIO.Log("Sound file playing ended");
        }
    }
}
