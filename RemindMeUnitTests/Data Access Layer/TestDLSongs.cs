using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RemindMe;
using System.IO;
using System.Collections.Generic;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestDLSongs
    {
        public TestDLSongs()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", RemindMe.Variables.IOVariables.databaseFile);
            BLIO.CreateDatabaseIfNotExist();
        }
        [TestMethod]
        public void TestGetSongs()
        {
            Assert.IsNotNull(DLSongs.GetSongs());
        }
        [TestMethod]
        public void TestGetSongById()
        {
            if (DLSongs.GetSongs().Count > 0)
                Assert.IsNotNull(DLSongs.GetSongById(DLSongs.GetSongs()[0].Id));

            Assert.IsNull(DLSongs.GetSongById(-1));
        }
        [TestMethod]
        public void TestInsertDeleteSong()
        {
            Songs song = new Songs();
            song.SongFilePath = @"C:\Users\x\test.mp3";
            song.SongFileName = Path.GetFileName(song.SongFilePath);

            Songs song2 = new Songs();
            song2.SongFilePath = @"C:\Users\x\test2.mp3";
            song2.SongFileName = Path.GetFileName(song2.SongFilePath);

            List<Songs> songs = new List<Songs>();
            songs.Add(song);
            songs.Add(song2);

            int songsCountBeforeInsert = DLSongs.GetSongs().Count;
            DLSongs.InsertSongs(songs);
            Assert.AreEqual(songsCountBeforeInsert + songs.Count, DLSongs.GetSongs().Count);

            Assert.IsTrue(DLSongs.SongExistsInDatabase(song.SongFilePath));
            Assert.IsTrue(DLSongs.SongExistsInDatabase(song2.SongFilePath));

            Assert.IsNotNull(DLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNotNull(DLSongs.GetSongByFullPath(song2.SongFilePath));

            

            DLSongs.RemoveSongs(songs);
            Assert.AreEqual(songsCountBeforeInsert, DLSongs.GetSongs().Count);
            Assert.IsNull(DLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNull(DLSongs.GetSongByFullPath(song2.SongFilePath));

            //now to test the single methods removesong and insertsong instead of removesongS and insertsongS
            DLSongs.InsertSong(song);

            Assert.AreEqual(songsCountBeforeInsert + 1, DLSongs.GetSongs().Count);
            Assert.IsTrue(DLSongs.SongExistsInDatabase(song.SongFilePath));

            Assert.IsNotNull(DLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNotNull(DLSongs.GetSongById(DLSongs.GetSongByFullPath(song.SongFilePath).Id));

            DLSongs.RemoveSong(song);

            Assert.IsNull(DLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.AreEqual(songsCountBeforeInsert, DLSongs.GetSongs().Count);
        }
    }
}
