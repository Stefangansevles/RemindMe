using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RemindMe;
using System.IO;
using System.Collections.Generic;
using Database;
using Business_Logic_Layer;

namespace RemindMeUnitTests
{
    [TestClass]
    public class TestBLSongs
    {
        public TestBLSongs()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", RemindMe.Variables.IOVariables.databaseFile);
            BLIO.CreateDatabaseIfNotExist();
        }
        [TestMethod]
        public void TestGetSongs()
        {
            Assert.IsNotNull(BLSongs.GetSongs());
        }
        [TestMethod]
        public void TestGetSongById()
        {
            if (BLSongs.GetSongs().Count > 0)
                Assert.IsNotNull(BLSongs.GetSongById(BLSongs.GetSongs()[0].Id));

            Assert.IsNull(BLSongs.GetSongById(-1));
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

            int songsCountBeforeInsert = BLSongs.GetSongs().Count;
            BLSongs.InsertSongs(songs);
            Assert.AreEqual(songsCountBeforeInsert + songs.Count, BLSongs.GetSongs().Count);

            Assert.IsTrue(BLSongs.SongExistsInDatabase(song.SongFilePath));
            Assert.IsTrue(BLSongs.SongExistsInDatabase(song2.SongFilePath));

            Assert.IsNotNull(BLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNotNull(BLSongs.GetSongByFullPath(song2.SongFilePath));

            

            BLSongs.RemoveSongs(songs);
            Assert.AreEqual(songsCountBeforeInsert, BLSongs.GetSongs().Count);
            Assert.IsNull(BLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNull(BLSongs.GetSongByFullPath(song2.SongFilePath));

            //now to test the single methods removesong and insertsong instead of removesongS and insertsongS
            BLSongs.InsertSong(song);

            Assert.AreEqual(songsCountBeforeInsert + 1, BLSongs.GetSongs().Count);
            Assert.IsTrue(BLSongs.SongExistsInDatabase(song.SongFilePath));

            Assert.IsNotNull(BLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.IsNotNull(BLSongs.GetSongById(BLSongs.GetSongByFullPath(song.SongFilePath).Id));

            BLSongs.RemoveSong(song);

            Assert.IsNull(BLSongs.GetSongByFullPath(song.SongFilePath));
            Assert.AreEqual(songsCountBeforeInsert, BLSongs.GetSongs().Count);
        }
    }
}
