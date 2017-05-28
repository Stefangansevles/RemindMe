using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// This class handles all database-sided logic for songs that users can import
    /// </summary>
    public abstract class DLSongs
    {
        //List<string> selectedFiles = FSManager.Files.getSelectedFilesWithPath("", "*.mp3; *.wav;").ToList();


        /// <summary>
        /// Gets the song object from the database with the given id
        /// </summary>
        /// <param name="id">the unique id</param>
        /// <returns></returns>
        public static Songs GetSongById(int id)
        {
            Songs song = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                song = (from s in db.Songs select s).Where(i => i.Id == id).SingleOrDefault();
                db.Dispose();
            }
            return song;
        }

        /// <summary>
        /// Gets the song object from the database with the given path
        /// </summary>
        /// <param name="path">the unique path to the song</param>
        /// <returns></returns>
        public static Songs GetSongByFullPath(string path)
        {
            //We can also make a method GetSongByFullPath because the path to the song is always unique.
            Songs song = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                song = (from s in db.Songs select s).Where(i => i.SongFilePath == path).SingleOrDefault();
                db.Dispose();
            }
            return song;
        }
        /// <summary>
        /// Gets all songs in the database
        /// </summary>
        /// <returns></returns>
        public static List<Songs> GetSongs()
        {
            List<Songs> storedSongs = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                storedSongs = (from s in db.Songs select s).ToList();
                db.Dispose();
            }
            return storedSongs;
        }

        public static void InsertSong(Songs song)
        {
            if (!SongExistsInDatabase(song.SongFilePath))
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.Songs.Count() > 0)
                        song.Id = db.Songs.Max(i => i.Id) + 1;
                    else
                        song.Id = 0;

                    db.Songs.Add(song);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }

        public static void RemoveSong(Songs song)
        {
            if (SongExistsInDatabase(song.SongFilePath))
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.Songs.Attach(song);
                    db.Songs.Remove(song);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }
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
                db.SaveChanges();
                db.Dispose();
            }
        }
        public static void InsertSongs(List<Songs> songs)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                int songsAdded = 1;
                foreach(Songs sng in songs)
                {
                    if (!SongExistsInDatabase(sng.SongFilePath))
                    {
                        if (db.Songs.Count() > 0)
                        {
                            sng.Id = db.Songs.Max(i => i.Id) + songsAdded;                            
                        }
                        else
                        {
                            sng.Id = songsAdded;                            
                        }

                        songsAdded++;
                        db.Songs.Add(sng);
                       
                    }
                }
                db.SaveChanges();
                db.Dispose();
            }            
        }

        public static bool SongExistsInDatabase(string pathToSong)
        {
            Songs sng = null;
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                sng = (from s in db.Songs select s).Where(i => i.SongFilePath == pathToSong).SingleOrDefault();
                db.Dispose();
            }

            return sng != null;
        }
    }
}
