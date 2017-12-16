using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    /// <summary>
    /// This class handles all database-sided logic for sound effects
    /// </summary>
    public class DLSongs
    {
        private DLSongs() { }

        //Instead of connecting with the database everytime, we fill this list and return it when the user calls GetSongs(). 
        private static List<Songs> localSongs;


        /// <summary>
        /// Gets the song object from the database with the given id
        /// </summary>
        /// <param name="id">the unique id</param>
        /// <returns></returns>
        public static Songs GetSongById(long id)
        {
            Songs song;

            song = (from s in localSongs select s).Where(i => i.Id == id).SingleOrDefault();

            return song;
        }

        /// <summary>
        /// Gets the song object from the database with the given path
        /// </summary>
        /// <param name="path">the unique path to the song</param>
        /// <returns></returns>
        public static Songs GetSongByFullPath(string path)
        {
            //the path to the song is always unique.
            Songs song = null;

            song = (from s in localSongs select s).Where(i => i.SongFilePath == path).SingleOrDefault();

            return song;
        }
        /// <summary>
        /// Gets all songs in the database
        /// </summary>
        /// <returns></returns>
        public static List<Songs> GetSongs()
        {
            //If the list  is still null, it means GetSongs() hasn't been called yet. So, we give it a value once. Then, the list will only
            //be altered when the database changes. This way we minimize the amount of database calls
            if (localSongs == null)
                RefreshCacheList();

            //If the list was null, it now returns the list of reminders from the database.
            //If it wasn't null, it will return the list as it was last known, which should be how the database is.
            return localSongs;
        }

        private static void RefreshCacheList()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                localSongs = (from s in db.Songs select s).ToList();
                db.Dispose();
            }
        }

        /// <summary>
        /// Insert a song into the database
        /// </summary>
        /// <param name="song">The song</param>
        public static void InsertSong(Songs song)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                if (db.Songs.Count() > 0)
                    song.Id = db.Songs.Max(i => i.Id) + 1;
                else
                    song.Id = 0;

                db.Songs.Add(song);
                SaveAndCloseDataBase(db);
            }
        } 

        /// <summary>
        /// Insert multiple songs into the database
        /// </summary>
        /// <param name="songs">List of songs</param>
        public static void InsertSongs(List<Songs> songs)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {                
                int songsAdded = 1;
                foreach (Songs sng in songs)
                {
                    if (!SongExistsInDatabase(sng.SongFilePath))
                    {
                        //The id of the new song will be the max of the database, plus the amount of songs added.
                        //The reason why songsAdded is used, is because db.SaveChanges() will only get called after inserting all the songs.
                        //because of this, you can't do Songs.Max +1 everytime, because it will give the same number every time
                        if (db.Songs.Count() > 0)                        
                            sng.Id = db.Songs.Max(i => i.Id) + songsAdded;                        
                        else                        
                            sng.Id = songsAdded;                        

                        songsAdded++;
                        db.Songs.Add(sng);

                    }
                }
                SaveAndCloseDataBase(db);
            }            
        }

        /// <summary>
        /// Removes a song from the database
        /// </summary>
        /// <param name="song">the song you want to remove</param>
        public static void RemoveSong(Songs song)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                db.Songs.Attach(song);
                db.Songs.Remove(song);
                SaveAndCloseDataBase(db);
            }
        }

        /// <summary>
        /// Removes multiple songs from the database
        /// </summary>
        /// <param name="song">the list of songs you want to remove</param>
        public static void RemoveSongs(List<Songs> songs)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                //Go through the loop and add all the remove requests to the list
                foreach (Songs sng in songs)
                {
                    if (SongExistsInDatabase(sng.SongFilePath))
                    {
                        db.Songs.Attach(sng);
                        db.Songs.Remove(sng);
                    }
                }

                //Save all the remove requests and remove them from the database
                SaveAndCloseDataBase(db);
            }            
        }
        
        /// <summary>
        /// Checks if there is a song in the databse with the given path
        /// </summary>
        /// <param name="pathToSong">full path to the song. for example: C:\users\you\music\song.mp3</param>
        /// <returns></returns>
        public static bool SongExistsInDatabase(string pathToSong)
        {
            Songs sng = null;

            sng = (from s in localSongs select s).Where(i => i.SongFilePath == pathToSong).SingleOrDefault();
                        
            return sng != null;
        }

        /// <summary>
        /// Saves pending changes to the database, disposes it, and refreshes the local cache list
        /// </summary>
        /// <param name="db"></param>
        private static void SaveAndCloseDataBase(RemindMeDbEntities db)
        {
            db.SaveChanges();
            RefreshCacheList();
            db.Dispose();
        }
    }
}
