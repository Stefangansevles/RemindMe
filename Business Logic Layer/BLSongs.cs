using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Database.Entity;
using System.IO;

namespace Business_Logic_Layer
{
    public class BLSongs
    {
        private BLSongs() { }
        /// <summary>
        /// Gets the song object from the database with the given id
        /// </summary>
        /// <param name="id">the unique id</param>
        /// <returns></returns>
        public static Songs GetSongById(long id)
        {
            return DLSongs.GetSongById(id);
        }

        /// <summary>
        /// Gets the song object from the database with the given path
        /// </summary>
        /// <param name="path">the unique path to the song</param>
        /// <returns></returns>
        public static Songs GetSongByFullPath(string path)
        {
            return DLSongs.GetSongByFullPath(path);
        }
        /// <summary>
        /// Gets all songs in the database
        /// </summary>
        /// <returns></returns>
        public static List<Songs> GetSongs()
        {
            return DLSongs.GetSongs();
        }

        

        /// <summary>
        /// Insert a song into the database
        /// </summary>
        /// <param name="song">The song</param>
        public static void InsertSong(Songs song)
        {
            if (song != null && !DLSongs.SongExistsInDatabase(song.SongFilePath))
            {
                DLSongs.InsertSong(song);
            }
        }

        /// <summary>
        /// Insert multiple songs into the database
        /// </summary>
        /// <param name="songs">List of songs</param>
        public static void InsertSongs(List<Songs> songs)
        {
            if (songs != null)
                DLSongs.InsertSongs(songs);
        }

        /// <summary>
        /// Removes a song from the database
        /// </summary>
        /// <param name="song">the song you want to remove</param>
        public static void RemoveSong(Songs song)
        {
            if (song != null && SongExistsInDatabase(song.SongFilePath))            
                DLSongs.RemoveSong(song);            
        }

        /// <summary>
        /// Removes multiple songs from the database
        /// </summary>
        /// <param name="song">the list of songs you want to remove</param>
        public static void RemoveSongs(List<Songs> songs)
        {
            if (songs != null)
                DLSongs.RemoveSongs(songs);
        }

        /// <summary>
        /// Checks if there is a song in the databse with the given path
        /// </summary>
        /// <param name="pathToSong">full path to the song. for example: C:\users\you\music\song.mp3</param>
        /// <returns></returns>
        public static bool SongExistsInDatabase(string pathToSong)
        {
            //no business logic(yet)
            return DLSongs.SongExistsInDatabase(pathToSong);
        }

        public static void InsertWindowsSystemSounds()
        {
            GetSongs();
            //Now let's add default windows sounds            
            List<Songs> tempSongs = new List<Songs>();
            foreach (string file in Directory.GetFiles(@"C:\Windows\Media", "*.wav"))
            {
                Songs tempSong = new Songs();
                tempSong.SongFilePath = file;

                //File doesnt stary with Windows, make sure the user understands its a default sound
                if (!Path.GetFileNameWithoutExtension(file).ToLower().StartsWith("windows"))
                    tempSong.SongFileName = "(Windows) " + Path.GetFileNameWithoutExtension(file);
                else
                {
                    //Add ( ) to Windows
                    string songName = Path.GetFileNameWithoutExtension(file);
                    songName = songName.Insert(0, "(");
                    songName = songName.Insert(8, ")");
                    tempSong.SongFileName = songName;
                }

                tempSongs.Add(tempSong);                
            }
            InsertSongs(tempSongs);
        }
    }
}
