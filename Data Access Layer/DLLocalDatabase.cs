using Database.Entity;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLLocalDatabase
    {
        public class Hotkey
        {
            private Hotkey() { }


            /// <summary>
            /// Reads the selected hotkeys combination to launch a new Timer popup.
            /// </summary>
            /// <returns>A HotKeys object containing the key combination required to launch a new Timer popup (For example ctrl+shift+r) </returns>
            public static Hotkeys TimerPopup
            {
                get
                {
                    Hotkeys hotKey = null;
                    using (RemindMeDbEntities db = new RemindMeDbEntities())
                    {
                        var count = db.Hotkeys.Where(o => o.Id >= 0).Count();
                        if (count > 0)
                        {

                            hotKey = (from g in db.Hotkeys select g).Where(i => i.Name == "Timer").SingleOrDefault();
                            db.Dispose();
                        }
                    }
                    return hotKey;
                }
                set
                {
                    UpdateHotkey(value);
                }
            }

            /// <summary>
            /// Reads the selected hotkeys combination to launch the TimerCheck window, containing the running timer(s)
            /// </summary>
            /// <returns>A HotKeys object containing the key combination required to launch the TimerCheck window (For example ctrl+shift+e) </returns>
            public static Hotkeys TimerCheck
            {
                get
                {
                    Hotkeys hotKey = null;
                    using (RemindMeDbEntities db = new RemindMeDbEntities())
                    {
                        var count = db.Hotkeys.Where(o => o.Id >= 0).Count();
                        if (count > 0)
                        {

                            hotKey = (from g in db.Hotkeys select g).Where(i => i.Name == "TimerCheck").SingleOrDefault();
                            db.Dispose();
                        }
                    }
                    return hotKey;
                }
                set
                {
                    UpdateHotkey(value);
                }
            }

            /// <summary>
            /// Insert a hotkey combination into the SQLite database
            /// </summary>
            /// <param name="hotkey">The hotkey object</param>
            public static void InsertHotkey(Hotkeys hotkey)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.Hotkeys.Count() > 0)
                        hotkey.Id = db.Hotkeys.Max(i => i.Id) + 1;

                    db.Hotkeys.Add(hotkey);
                    db.SaveChanges();
                    db.Dispose();
                }
            }

            /// <summary>
            /// Update an existing hotkey combination in the SQLite database
            /// </summary>
            /// <param name="hotkey">The hotkey object</param>
            private static void UpdateHotkey(Hotkeys hotkey)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.Hotkeys.Where(o => o.Id >= hotkey.Id).Count();
                    if (count > 0)
                    {
                        db.Hotkeys.Attach(hotkey);
                        var entry = db.Entry(hotkey);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.Hotkeys.Add(hotkey);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// This class handles(creates/updates) settings in the database
        /// </summary>
        public class Setting
        {

            private Setting() { }


            private static Settings settings;
           

            /// <summary>
            /// Reads the settings from the database and checks if reminders should be set to always on top.
            /// </summary>
            /// <returns>True if reminders are set to be always on top, false if not</returns>
            public static bool IsReminderCountPopupEnabled()
            {
                int enablePopupMessage = 1;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    var count = db.Settings.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        enablePopupMessage = Convert.ToInt32((from g in db.Settings select g.EnableReminderCountPopup).SingleOrDefault());
                        db.Dispose();
                    }
                    else
                    {
                        RefreshSettings();
                    }
                }
                return enablePopupMessage == 1;
            }


            /// <summary>
            /// Reads the settings from the database and checks if the user wants to see the popup explaining the hide reminder feature.
            /// </summary>
            /// <returns>True if the user hasn't pressed the don't remind again option yet, false if not</returns>
            public static bool HideReminderOptionEnabled()
            {
                int hideReminderOption = 0;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    var count = db.Settings.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        hideReminderOption = Convert.ToInt32((from g in db.Settings select g.HideReminderConfirmation).SingleOrDefault());
                        db.Dispose();
                    }
                    else
                    {
                        RefreshSettings();
                    }
                }
                return hideReminderOption == 1;
            }

            /// <summary>
            /// Reads the settings from the database and checks if there should be a notification 1 hour before the reminder that there is a reminder
            /// </summary>
            /// <returns>True if the notification is enabled, false if not</returns>
            public static bool IsHourBeforeNotificationEnabled()
            {
                int notificationEnabled = 1;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    var count = db.Settings.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {

                        notificationEnabled = Convert.ToInt32((from g in db.Settings select g.EnableHourBeforeReminder).SingleOrDefault());
                        db.Dispose();
                    }
                    else
                    {
                        RefreshSettings();
                    }
                }
                return notificationEnabled == 1;
            }

            public static Settings Settings
            {
                get
                {
                    if (settings == null)
                        RefreshSettings();

                    return settings;
                }

            }
            /*This was testing a custom color scheme

            public static RemindMeColorScheme GetColorTheme(string themeName)
            {
                RemindMeColorScheme theme;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    theme = (from t in db.RemindMeColorScheme select t).Where(t => t.ThemeName == themeName).ToList().FirstOrDefault();
                    db.Dispose();
                }
                return theme;
            }*/
            private static void RefreshSettings()
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    int count = db.Settings.Where(o => o.Id >= 0).Count();                    
                    if (count == 0)
                    {
                        settings = new Settings();
                        settings.PopupType = "AlwaysOnTop";
                        settings.StickyForm = 0;
                        settings.EnableReminderCountPopup = 1;
                        settings.EnableHourBeforeReminder = 1;
                        settings.HideReminderConfirmation = 0;
                        settings.EnableQuickTimer = 1;                        
                        settings.DefaultTimerSound = "";
                        settings.EnableAdvancedReminders = 0;                        
                        settings.RemindMeTheme = "Default";
                        settings.AutoUpdate = 1;
                        settings.TimerVolume = 100;
                        UpdateSettings(settings);
                    }
                    else
                        settings = (from s in db.Settings select s).ToList().FirstOrDefault();
                    db.Dispose();
                }
            }
            public static void UpdateSettings(Settings set)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.Settings.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        db.Settings.Attach(set);
                        var entry = db.Entry(set);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.Settings.Add(set);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }






        }

        public class PopupDimension
        {
            private PopupDimension
()
            { }

            private static PopupDimensions dimensions;

            private const int DEFAULT_FORM_WIDTH = 371;
            private const int DEFAULT_FORM_HEIGHT = 307;
            private const int DEFAULT_FONT_TITLE_SIZE = 14;
            private const int DEFAULT_FONT_NOTE_SIZE = 14;


            public static PopupDimensions GetPopupDimensions()
            {
                if (dimensions == null)
                    RefreshDimensions();

                return dimensions;
            }

            private static void SaveAndCloseDataBase(RemindMeDbEntities db)
            {
                db.SaveChanges();
                db.Dispose();
                RefreshDimensions();
            }

            private static void RefreshDimensions()
            {

                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    int count = db.PopupDimensions.Where(o => o.Id >= 0).Count();
                    if (count == 0) //no dimensions yet.
                    {
                        dimensions = new PopupDimensions();
                        dimensions.FormWidth = DEFAULT_FORM_WIDTH;
                        dimensions.FormHeight = DEFAULT_FORM_HEIGHT;
                        dimensions.FontTitleSize = DEFAULT_FONT_TITLE_SIZE;
                        dimensions.FontNoteSize = DEFAULT_FONT_NOTE_SIZE;

                        UpdatePopupDimensions(dimensions);
                    }
                    else
                        dimensions = (from s in db.PopupDimensions select s).ToList().FirstOrDefault();

                    db.SaveChanges();
                    db.Dispose();
                }
            }

            public static void ResetToDefaults()
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    dimensions = new PopupDimensions();
                    dimensions.FormWidth = DEFAULT_FORM_WIDTH;
                    dimensions.FormHeight = DEFAULT_FORM_HEIGHT;
                    dimensions.FontTitleSize = DEFAULT_FONT_TITLE_SIZE;
                    dimensions.FontNoteSize = DEFAULT_FONT_NOTE_SIZE;

                    UpdatePopupDimensions(dimensions);
                    db.Dispose();
                }
            }

            public static void UpdatePopupDimensions(PopupDimensions dimensions)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.PopupDimensions.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        db.PopupDimensions.Attach(dimensions);
                        var entry = db.Entry(dimensions);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        SaveAndCloseDataBase(db);
                    }
                    else
                    {//The dimensions table is still empty
                        db.PopupDimensions.Add(dimensions);
                        SaveAndCloseDataBase(db);
                    }
                }
            }
        }

        /// <summary>
        /// This class handles all database-sided logic for sound effects
        /// </summary>
        public class Song
        {
            private Song() { }

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

        public class ReadMessage
        {
            private ReadMessage() { }


            /// <summary>
            /// Save and close the database connection
            /// </summary>
            /// <param name="db"></param>
            private static void SaveAndCloseDataBase(RemindMeDbEntities db)
            {
                db.SaveChanges();
                db.Dispose();
            }

            public static List<ReadMessages> Messages
            {
                get
                {
                    using (RemindMeDbEntities db = new RemindMeDbEntities())
                    {
                        var count = db.ReadMessages.Where(o => o.Id >= 0).Count();

                        if (count > 0)
                            return db.ReadMessages.ToList();
                        else
                            return new List<ReadMessages>();
                    }
                }

            }
        }

        public class AVRProperty
        {
            private AVRProperty() { }

            /// <summary>
            /// Get the advanced Reminder properties for a reminder
            /// </summary>
            /// <param name="remId">The id of the reminder</param>
            /// <returns></returns>
            public static AdvancedReminderProperties GetAVRProperties(long remId)
            {
                AdvancedReminderProperties avr = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    avr = (from g in db.AdvancedReminderProperties select g).Where(r => r.Remid == remId).SingleOrDefault();
                    db.Dispose();
                }
                return avr;
            }
            /// <summary>
            /// Get the advanced Reminder files/folders
            /// </summary>
            /// <param name="remId">The id of the reminder</param>
            /// <returns></returns>
            public static List<AdvancedReminderFilesFolders> GetAVRFilesFolders(long remId)
            {
                List<AdvancedReminderFilesFolders> avr = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    avr = (from g in db.AdvancedReminderFilesFolders select g).Where(r => r.Remid == remId).ToList();
                    db.Dispose();
                }
                return avr;
            }

            /// <summary>
            /// Insert advanced Reminder properties into the database
            /// </summary>
            /// <param name="avr">The avr object</param>
            /// <returns></returns>
            public static long InsertAVRProperties(AdvancedReminderProperties avr)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.AdvancedReminderProperties.Where(r => r.Remid == avr.Remid).Count() > 0)
                    {
                        //Exists already. update.                    
                        db.AdvancedReminderProperties.Attach(avr);
                        var entry = db.Entry(avr);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                                                            
                        db.SaveChanges();
                        db.Dispose();
                    }
                    else
                    {
                        if (db.AdvancedReminderProperties.Count() > 0)
                            avr.Id = db.AdvancedReminderProperties.Max(i => i.Id) + 1;

                        db.AdvancedReminderProperties.Add(avr);
                        db.SaveChanges();
                        db.Dispose();
                    }

                }
                return avr.Id;
            }

            /// <summary>
            /// Insert advanced reminder file(s)/folder(s) options (delete/open) for a specific reminder
            /// </summary>
            /// <param name="avr"></param>
            /// <returns></returns>
            public static long InsertAVRFilesFolders(AdvancedReminderFilesFolders avr)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.AdvancedReminderFilesFolders.Where(r => r.Id == avr.Id).Count() > 0)
                    {
                        //Exists already. update.
                        db.AdvancedReminderFilesFolders.Attach(avr);
                        var entry = db.Entry(avr);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    }
                    else
                    {
                        if (db.AdvancedReminderFilesFolders.Count() > 0)
                            avr.Id = db.AdvancedReminderFilesFolders.Max(i => i.Id) + 1;
                        else
                            avr.Id = 0;

                        db.AdvancedReminderFilesFolders.Add(avr);
                    }
                    db.SaveChanges();
                    db.Dispose();
                }
                return avr.Id;
            }

            /// <summary>
            /// Delete advanced reminder file(s)/folder(s) options (delete/open) for a specific reminder
            /// </summary>
            /// <param name="id">The ID of the avr record in the SQLite database</param>
            public static void DeleteAvrFilesFoldersById(long id)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    foreach (AdvancedReminderFilesFolders avr in db.AdvancedReminderFilesFolders.Where(r => r.Remid == id).ToList())
                    {
                        db.AdvancedReminderFilesFolders.Attach(avr);
                        db.AdvancedReminderFilesFolders.Remove(avr);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
            }
            /// <summary>
            /// Delete Avr properties of a specific reminder
            /// </summary>
            /// <param name="id">Id of the avr properties record in the SQLite database</param>
            public static void DeleteAvrProperties(long id)
            {
                AdvancedReminderProperties prop = GetAVRProperties(id);
                if (prop == null)
                    return;

                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    db.AdvancedReminderProperties.Attach(prop);
                    db.AdvancedReminderProperties.Remove(prop);

                    db.SaveChanges();
                    db.Dispose();
                }
            }
           
        }

        public class ButtonSpacing
        {
            private ButtonSpacing() { }

            /// <summary>
            /// Gets the amount of button spaces for 1 button, right now that's the same for all, but maybe that could change in the future
            /// </summary>
            /// <returns></returns>
            public static int GetButtonSpacing()
            {
                int spacing = -1;

                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    int count = db.ButtonSpaces.Where(o => o.Id >= 0).Count();
                    if (count == 0)
                    {
                        ButtonSpaces spaceObj = new ButtonSpaces();
                        spaceObj.Id = 0;                        
                        spaceObj.Reminders = 5;
                        //spaceObj.MessageCenter = 5; 
                        //more buttons possibly

                        spacing = 5;

                        db.ButtonSpaces.Add(spaceObj);
                        db.SaveChanges();
                    }
                    else
                    {
                        spacing = Convert.ToInt32((from b in db.ButtonSpaces select b.Reminders).SingleOrDefault());
                    }



                    db.Dispose();
                }

                return spacing;
            }

            public static void UpdateButtonSpacing(ButtonSpaces btn)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.ButtonSpaces.Where(o => o.Id >= 0).Count();
                    if (count == 1)
                    {
                        db.ButtonSpaces.Attach(btn);
                        var entry = db.Entry(btn);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.ButtonSpaces.Add(btn);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }

            }
        }

        /// <summary>
        /// This class handles(creates/updates) settings in the database
        /// </summary>
        public class Theme
        {

            private Theme() { }


            private static Themes theme;



            public static Themes ThemesObj
            {
                get
                {
                    if (theme == null)
                        RefreshThemes();

                    return theme;
                }

            }


            /// <summary>
            /// Insert a hotkey combination into the SQLite database
            /// </summary>
            /// <param name="hotkey">The hotkey object</param>
            public static void InsertTheme(Themes theme)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.Themes.Count() > 0)
                        theme.Id = db.Themes.Max(i => i.Id) + 1;

                    db.Themes.Add(theme);
                    db.SaveChanges();
                    db.Dispose();
                }
            }


            public static Themes GetThemeById(long id)
            {

                Themes theme = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    theme = (from g in db.Themes select g).Where(i => i.Id == id).SingleOrDefault();
                    db.Dispose();
                }
                return theme;
            }
            

            public static Themes DeleteThemeById(long id)
            {
                Themes theme = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    theme = (from g in db.Themes select g).Where(i => i.Id == id).SingleOrDefault();
                    db.Themes.Attach(theme);
                    db.Themes.Remove(theme);

                    db.SaveChanges();                                      
                    db.Dispose();
                }
                return theme;
            }


            public static List<Themes> GetThemes()
            {

                List<Themes> themes = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    themes = (from g in db.Themes select g).ToList();
                    db.Dispose();
                }
                return themes;
            }


            private static void RefreshThemes()
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    int count = db.Themes.Where(o => o.Id >= 0).Count();
                    if (count == 0)
                    {
                        theme = new Themes();
                        theme.Primary = 0;
                        theme.DarkPrimary = 0;
                        theme.LightPrimary = 0;
                        theme.Accent = 0;
                        theme.TextShade = 0;                        
                        UpdateTheme(theme);
                    }
                    else
                        theme = (from s in db.Themes select s).ToList().FirstOrDefault();

                    db.Dispose();
                }
            }
            public static void UpdateTheme(Themes theme)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.Themes.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        db.Themes.Attach(theme);
                        var entry = db.Entry(theme);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.Themes.Add(theme);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }


            public static void InsertDefaultThemes()
            {                                
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    Themes theme = new Themes();
                    theme.Mode = 1;
                    theme.ThemeName = "Dark-Red";
                    theme.IsDefault = 0;
                    theme.TextShade = (long)TextShade.WHITE;

                    theme.Primary = (long)Primary.Red700;
                    theme.DarkPrimary = (long)Primary.Red900;
                    theme.LightPrimary = (long)Primary.Red200;
                    theme.Accent = (long)Accent.Red100;

                    if (db.Themes.Count() > 0)
                        theme.Id = db.Themes.Max(i => i.Id) + 1;
                    else
                        theme.Id = 0;

                    db.Themes.Add(theme);
                    db.SaveChanges();

                    //----
                    theme = new Themes();
                    theme.Mode = 0;
                    theme.ThemeName = "(Default) Blue-Light";
                    theme.IsDefault = 1;
                    theme.TextShade = (long)TextShade.WHITE;

                    theme.Primary = (long)Primary.Indigo500;
                    theme.DarkPrimary = (long)Primary.Indigo700;
                    theme.LightPrimary = (long)Primary.Indigo100;
                    theme.Accent = (long)Accent.Pink200;

                    theme.Id = db.Themes.Max(i => i.Id) + 1;                    

                    db.Themes.Add(theme);
                    db.SaveChanges();

                    //----
                    theme = new Themes();
                    theme.Mode = 0;
                    theme.ThemeName = "(Default) Green-Light";
                    theme.IsDefault = 1;
                    theme.TextShade = (long)TextShade.WHITE;

                    theme.Primary = (long)Primary.Green600;
                    theme.DarkPrimary = (long)Primary.Green700;
                    theme.LightPrimary = (long)Primary.Green200;
                    theme.Accent = (long)Accent.Red100;

                    theme.Id = db.Themes.Max(i => i.Id) + 1;

                    db.Themes.Add(theme);
                    db.SaveChanges();


                    //----
                    theme = new Themes();
                    theme.Mode = 0;
                    theme.ThemeName = "(Default) BlueGrey-Light";
                    theme.IsDefault = 1;
                    theme.TextShade = (long)TextShade.WHITE;

                    theme.Primary = (long)Primary.BlueGrey800;
                    theme.DarkPrimary = (long)Primary.BlueGrey900;
                    theme.LightPrimary = (long)Primary.BlueGrey500;
                    theme.Accent = (long)Accent.LightBlue200;

                    theme.Id = db.Themes.Max(i => i.Id) + 1;

                    db.Themes.Add(theme);
                    db.SaveChanges();

                    //lastly, dispose
                    db.Dispose();
                }
            }




        }

        
        public class HttpRequest
        {

            private HttpRequest() { }


            /// <summary>
            /// Get the http-request (advanced reminder) for a reminder
            /// </summary>
            /// <param name="remId">The id of the reminder</param>
            /// <returns></returns>
            public static HttpRequests GetHttpRequest(long remId)
            {
                HttpRequests http = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    http = (from g in db.HttpRequests select g).Where(r => r.reminderId == remId).SingleOrDefault();
                    db.Dispose();
                }
                return http;
            }

            /// <summary>
            /// Get all http-requests (advanced reminder) 
            /// </summary>
            /// <param name="remId">The id of the reminder</param>
            /// <returns></returns>
            public static List<HttpRequests> GetHttpRequests()
            {
                List<HttpRequests> http = null;
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    http = (from g in db.HttpRequests select g).ToList();
                    db.Dispose();
                }
                return http;
            }

            /// <summary>
            /// Insert advanced Reminder HttpRequest into the database
            /// </summary>
            /// <param name="http">The avr object</param>
            /// <returns></returns>
            public static long InsertHttpRequest(HttpRequests http)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.HttpRequests.Where(r => r.reminderId == http.reminderId).Count() > 0)
                    {
                        //Exists already. update.                    
                        db.HttpRequests.Attach(http);
                        var entry = db.Entry(http);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                                                            
                        db.SaveChanges();
                        db.Dispose();
                    }
                    else
                    {
                        if (db.HttpRequests.Count() > 0)
                            http.Id = db.HttpRequests.Max(i => i.Id) + 1;

                        db.HttpRequests.Add(http);
                        db.SaveChanges();
                        db.Dispose();
                    }

                }
                return http.Id;
            }            

            /// <summary>
            /// Delete advanced reminder file(s)/folder(s) options (delete/open) for a specific reminder
            /// </summary>
            /// <param name="id">The ID of the avr record in the SQLite database</param>
            public static void DeleteHttpRequestByReminderId(long id)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    foreach (HttpRequests http in db.HttpRequests.Where(r => r.reminderId == id).ToList())
                    {
                        db.HttpRequests.Attach(http);
                        db.HttpRequests.Remove(http);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
            }
            /// <summary>
            /// Delete advanced reminder file(s)/folder(s) options (delete/open) for a specific reminder
            /// </summary>
            /// <param name="id">The ID of the avr record in the SQLite database</param>
            public static void DeleteHttpRequestById(long id)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    foreach (HttpRequests http in db.HttpRequests.Where(r => r.Id == id).ToList())
                    {
                        db.HttpRequests.Attach(http);
                        db.HttpRequests.Remove(http);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
            }
            public static void UpdateHttpRequest(HttpRequests http)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.HttpRequests.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        db.HttpRequests.Attach(http);
                        var entry = db.Entry(http);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.HttpRequests.Add(http);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }
        }

        public class HttpRequestConditions
        {

            private HttpRequestConditions() { }


            /// <summary>
            /// Get the HttpRequest conditions for a HttpRequest
            /// </summary>
            /// <param name="requestId">The id of the parent HttpRequest</param>
            /// <returns></returns>
            public static List<HttpRequestCondition> GetConditions(long requestId)
            {
                List<HttpRequestCondition> conditions = new List<HttpRequestCondition>();
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    conditions = (from g in db.HttpRequestCondition select g).Where(r => r.RequestId == requestId).ToList();
                    db.Dispose();
                }
                return conditions;
            }

            /// <summary>
            /// Get the HttpRequest conditions for a HttpRequest
            /// </summary>
            /// <param name="requestId">The id of the parent HttpRequest</param>
            /// <returns></returns>
            public static HttpRequestCondition GetCondition(long id)
            {
                HttpRequestCondition condition = new HttpRequestCondition();
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    condition = (from g in db.HttpRequestCondition select g).Where(r => r.Id == id).SingleOrDefault();
                    db.Dispose();
                }
                return condition;
            }

            /// <summary>
            /// Insert a new Request condition into the db
            /// </summary>
            /// <param name="condition"></param>
            /// <returns></returns>
            public static long InsertCondition(HttpRequestCondition condition)
            {                
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    /*if (db.HttpRequestCondition.Where(r => r.Id == condition.Id).Count() > 0)
                    {
                        throw new ArgumentException("Could not insert HttpRequestCondition with ID " + condition.Id + " because it already exists");
                    }
                    else*/
                    {
                        if (db.HttpRequestCondition.Count() > 0)
                            condition.Id = db.HttpRequests.Max(i => i.Id) + 1;                        

                        db.HttpRequestCondition.Add(condition);
                        db.SaveChanges();
                        db.Dispose();
                    }

                }
                return condition.Id;
            }

            /// <summary>
            /// Delete a single condition by its id
            /// </summary>
            /// <param name="id"></param>
            public static void DeleteConditionById(long id)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    foreach (HttpRequestCondition cond in db.HttpRequestCondition.Where(r => r.Id == id).ToList())
                    {
                        db.HttpRequestCondition.Attach(cond);
                        db.HttpRequestCondition.Remove(cond);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
            }
            
            /// <summary>
            /// Delete all conditions that are paired to a HttpRequest
            /// </summary>
            /// <param name="httpRequestId"></param>
            public static void DeleteConditionsForHttpRequest(long httpRequestId)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    foreach (HttpRequestCondition cond in db.HttpRequestCondition.Where(r => r.RequestId == httpRequestId).ToList())
                    {
                        db.HttpRequestCondition.Attach(cond);
                        db.HttpRequestCondition.Remove(cond);
                    }

                    db.SaveChanges();
                    db.Dispose();
                }
            }

            public static void UpdateHttpRequest(HttpRequestCondition cond)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {

                    var count = db.HttpRequestCondition.Where(o => o.Id >= 0).Count();
                    if (count > 0)
                    {
                        db.HttpRequestCondition.Attach(cond);
                        var entry = db.Entry(cond);
                        entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                        db.SaveChanges();                                      //push to database
                        db.Dispose();
                    }
                    else
                    {//The settings table is still empty
                        db.HttpRequestCondition.Add(cond);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }
        }
    }
}

