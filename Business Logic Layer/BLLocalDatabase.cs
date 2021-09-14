using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business_Logic_Layer
{
    public class BLLocalDatabase
    {
        public static bool HasAllTables()
        {
            return DLDatabase.HasAllTables();
        }

        public class ReadMessage
        {            
            private ReadMessage() { }

            /// <summary>
            /// Gets the column sizes of the Listview in the SQLite database 
            /// </summary>
            /// <returns></returns>
            public static List<ReadMessages> Messages
            {                
                get { return DLLocalDatabase.ReadMessage.Messages; }
            }

            /// <summary>
            /// Inserts the reminder into the database.
            /// </summary>
            /// <param name="rem">The reminder you want added into the database</param>
            public static bool MarkMessageRead(Database.Entity.RemindMeMessages message)
            {
                try
                {
                    ReadMessages msg = new ReadMessages();
                    msg.ReadMessageId = message.Id;
                    msg.MessageText = message.Message;
                    msg.ReadDate = message.DateOfCreation.Value.ToString();

                    using (RemindMeDbEntities db = new RemindMeDbEntities())
                    {
                        if (db.ReadMessages.Count() > 0)
                            msg.Id = db.ReadMessages.Max(i => i.Id) + 1;
                        else
                            msg.Id = 0;

                        db.ReadMessages.Add(msg);
                        db.SaveChanges();
                        db.Dispose();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// Removes a message that is marked as read from the local database
            /// </summary>
            /// <param name="onlineMessageId">the Id of the online message in the database</param>
            public static void DeleteMessage(int onlineMessageId)
            {
                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    ReadMessages readMess = db.ReadMessages.Where(rm => rm.ReadMessageId == onlineMessageId).FirstOrDefault();
                    if (readMess != null)
                    {
                        db.ReadMessages.Attach(readMess);
                        db.ReadMessages.Remove(readMess);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
            }
        }
        public class Setting
        {
            private Setting() { }          

            /// <summary>
            /// Reads the settings from the database and checks if reminders should be set to always on top.
            /// </summary>
            /// <returns>True if reminders are set to be always on top, false if not</returns>
            public static bool IsReminderCountPopupEnabled()
            {
                //no business logic (yet)
                return DLLocalDatabase.Setting.IsReminderCountPopupEnabled();
            }

            /// <summary>
            /// Reads the settings from the database and checks if the user wants to see the popup explaining the hide reminder feature.
            /// </summary>
            /// <returns>True if the user hasn't pressed the don't remind again option yet, false if not</returns>
            public static bool HideReminderOptionEnabled
            {
                get { return DLLocalDatabase.Setting.HideReminderOptionEnabled(); }
            }



            /// <summary>
            /// Reads the settings from the database and checks if there should be a notification 1 hour before the reminder that there is a reminder
            /// </summary>
            /// <returns>True if the notification is enabled, false if not</returns>
            public static bool IsHourBeforeNotificationEnabled()
            {
                //no business logic (yet)
                return DLLocalDatabase.Setting.IsHourBeforeNotificationEnabled();
            }

            /// <summary>
            /// Gets the settings table from the SQLite database
            /// </summary>
            /// <returns></returns>
            public static Settings Settings
            {
                get { return DLLocalDatabase.Setting.Settings; }
            }

            /// <summary>
            /// Update the settings in the SQLite database
            /// </summary>
            /// <param name="set">The new settings object</param>
            public static void UpdateSettings(Settings set)
            {
                if (set != null)
                    DLLocalDatabase.Setting.UpdateSettings(set);
            }

        }
        public class PopupDimension
        {
            private PopupDimension() { }

            /// <summary>
            /// Gets the popup dimensions from the SQLite database. This determines how big the RemindMe popup should be in length and height
            /// </summary>
            /// <returns></returns>
            public static PopupDimensions GetPopupDimensions()
            {                
                return DLLocalDatabase.PopupDimension.GetPopupDimensions();
            }


            /// <summary>
            /// Updates the popup dimensions in the SQLite database. This determines how big the RemindMe popup should be in length and height
            /// </summary>        
            /// <param name="dimensions"></param>
            public static void UpdatePopupDimensions(PopupDimensions dimensions)
            {
                if (dimensions != null)
                    DLLocalDatabase.PopupDimension.UpdatePopupDimensions(dimensions);
            }

            /// <summary>
            /// Resets the popup dimensions to their default sizes
            /// </summary>
            public static void ResetToDefaults()
            {
                DLLocalDatabase.PopupDimension.ResetToDefaults();
            }
        }
        public class Hotkey
        {
            private Hotkey() { }

            /// <summary>
            /// Reads the settings from the database and checks if the controls should be cleared after making a new reminder.
            /// </summary>
            /// <returns>True to use sticky form, false if not</returns>
            public static Hotkeys TimerPopup
            {
                get
                {                    
                    //Let's also insert the quick timer hotkey if it doesnt exist                
                    if (DLLocalDatabase.Hotkey.TimerPopup == null)
                    {
                        Hotkeys timerHotkey = DLLocalDatabase.Hotkey.TimerPopup;
                        if (timerHotkey == null)
                        {
                            timerHotkey = new Hotkeys(); //No hotkey in the database for the quick timer? insert the default hotkey
                            timerHotkey.Key = "R";
                            timerHotkey.Name = "Timer";
                            timerHotkey.Modifiers = "Shift,Control";
                        }
                        InsertHotkey(timerHotkey);
                    }

                    return DLLocalDatabase.Hotkey.TimerPopup;
                }
                set
                {
                    //Before we push the new hotkey value, let's check if it's valid 
                    if (string.IsNullOrWhiteSpace(value.Key) || string.IsNullOrWhiteSpace(value.Modifiers) || string.IsNullOrWhiteSpace(value.Name))
                        return;

                    DLLocalDatabase.Hotkey.TimerPopup = value;
                }

            }

            /// <summary>
            /// Reads the settings from the database and checks if the controls should be cleared after making a new reminder.
            /// </summary>
            /// <returns>True to use sticky form, false if not</returns>
            public static Hotkeys TimerCheck
            {
                get
                {
                    //Let's also insert the quick timer hotkey if it doesnt exist                
                    if (DLLocalDatabase.Hotkey.TimerCheck == null)
                    {
                        Hotkeys timerCheck = DLLocalDatabase.Hotkey.TimerCheck;
                        if (timerCheck == null)
                        {
                            timerCheck = new Hotkeys(); //No hotkey in the database for the quick timer? insert the default hotkey
                            timerCheck.Key = "E";
                            timerCheck.Name = "TimerCheck";
                            timerCheck.Modifiers = "Shift,Control";
                        }
                        InsertHotkey(timerCheck);
                    }

                    return DLLocalDatabase.Hotkey.TimerCheck;
                }
                set
                {
                    //Before we push the new hotkey value, let's check if it's valid 
                    if (string.IsNullOrWhiteSpace(value.Key) || string.IsNullOrWhiteSpace(value.Modifiers) || string.IsNullOrWhiteSpace(value.Name))
                        return;

                    DLLocalDatabase.Hotkey.TimerCheck = value;
                }

            }
            public static void InsertHotkey(Hotkeys hotkey)
            {
                if (hotkey != null && !(string.IsNullOrWhiteSpace(hotkey.Key) || string.IsNullOrWhiteSpace(hotkey.Modifiers) || string.IsNullOrWhiteSpace(hotkey.Name)))
                    DLLocalDatabase.Hotkey.InsertHotkey(hotkey);
            }
        }
        public class Song
        {
            private Song() { }
            /// <summary>
            /// Gets the song object from the database with the given id
            /// </summary>
            /// <param name="id">the unique id</param>
            /// <returns></returns>
            public static Songs GetSongById(long id)
            {                
                return DLLocalDatabase.Song.GetSongById(id);
            }

            /// <summary>
            /// Gets the song object from the database with the given path
            /// </summary>
            /// <param name="path">the unique path to the song</param>
            /// <returns></returns>
            public static Songs GetSongByFullPath(string path)
            {
                return DLLocalDatabase.Song.GetSongByFullPath(path);
            }
            /// <summary>
            /// Gets all songs in the database
            /// </summary>
            /// <returns></returns>
            public static List<Songs> GetSongs()
            {
                return DLLocalDatabase.Song.GetSongs();
            }

            /// <summary>
            /// Insert multiple songs into the database
            /// </summary>
            /// <param name="songs">List of songs</param>
            public static void InsertSongs(List<Songs> songs)
            {
                if (songs != null)
                    DLLocalDatabase.Song.InsertSongs(songs);
            }

            /// <summary>
            /// Removes a song from the database
            /// </summary>
            /// <param name="song">the song you want to remove</param>
            public static void RemoveSong(Songs song)
            {
                if (song != null && SongExistsInDatabase(song.SongFilePath))
                    DLLocalDatabase.Song.RemoveSong(song);
            }

            /// <summary>
            /// Removes multiple songs from the database
            /// </summary>
            /// <param name="song">the list of songs you want to remove</param>
            public static void RemoveSongs(List<Songs> songs)
            {
                if (songs != null)
                    DLLocalDatabase.Song.RemoveSongs(songs);
            }

            /// <summary>
            /// Checks if there is a song in the databse with the given path
            /// </summary>
            /// <param name="pathToSong">full path to the song. for example: C:\users\you\music\song.mp3</param>
            /// <returns></returns>
            public static bool SongExistsInDatabase(string pathToSong)
            {
                //no business logic(yet)
                return DLLocalDatabase.Song.SongExistsInDatabase(pathToSong);
            }

            /// <summary>
            /// Insert the default Windows sound effects into the RemindMe SQLite database
            /// </summary>
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
                //First check if the reminder exists
                if (DLReminders.GetReminderById(remId) == null)
                    return null;

                return DLLocalDatabase.AVRProperty.GetAVRProperties(remId);
            }
            /// <summary>
            /// Get the advanced Reminder files/folders
            /// </summary>
            /// <param name="remId">The id of the reminder</param>
            /// <returns></returns>
            public static List<AdvancedReminderFilesFolders> GetAVRFilesFolders(long remId)
            {
                //First check if the reminder exists
                if (DLReminders.GetReminderById(remId) == null)
                    return null;
                
                return DLLocalDatabase.AVRProperty.GetAVRFilesFolders(remId);
            }



            /// <summary>
            /// Inserts Advanced reminder properties into the database, with a link to the reminder by it's ID
            /// </summary>
            /// <param name="avr"></param>
            /// <returns>The id of the newly inserted row. -1 if something went wrong</returns>
            public static long InsertAVRProperties(AdvancedReminderProperties avr)
            {
                //First check if the reminder exists
                if (DLReminders.GetReminderById(avr.Remid) == null)
                    return -1;

                return DLLocalDatabase.AVRProperty.InsertAVRProperties(avr);
            }

            /// <summary>
            /// Inserts file/folder actions into the database, with a link to the reminder by it's ID
            /// </summary>
            /// <param name="avr"></param>
            /// <returns>The id of the newly inserted row. -1 if something went wrong</returns>
            public static long InsertAVRFilesFolders(AdvancedReminderFilesFolders avr)
            {
                //First check if the reminder exists
                if (DLReminders.GetReminderById(avr.Remid) == null)
                    return -1;

                return DLLocalDatabase.AVRProperty.InsertAVRFilesFolders(avr);
            }


            public static void DeleteAvrFilesFoldersById(long id)
            {
                DLLocalDatabase.AVRProperty.DeleteAvrFilesFoldersById(id);
            }
        }

        public class ButtonSpacing
        {
            private ButtonSpacing() { }

            public static int GetButtonSpacing()
            {
                return DLLocalDatabase.ButtonSpacing.GetButtonSpacing();
            }
            public static void UpdateButtonSpacing(ButtonSpaces btn)
            {
                if(btn != null)
                    DLLocalDatabase.ButtonSpacing.UpdateButtonSpacing(btn);                
            }
        }

        public class Theme
        {
            private Theme() { }
           
            public static Themes GetThemeById(long id)
            {
                return DLLocalDatabase.Theme.GetThemeById(id);
            }

            public static Themes DeleteThemeById(long id)
            {
                return DLLocalDatabase.Theme.DeleteThemeById(id);
            }

            public static List<Themes> GetThemes()
            {
                return DLLocalDatabase.Theme.GetThemes();
            }

            public static void InsertTheme(Themes theme)
            {
                if (theme != null)
                    DLLocalDatabase.Theme.InsertTheme(theme);
            }
            /// <summary>
            /// Update the settings in the SQLite database
            /// </summary>
            /// <param name="set">The new settings object</param>
            public static void UpdateTheme(Themes t)
            {
                if (t != null)
                    DLLocalDatabase.Theme.UpdateTheme(t);
            }

            public static void InsertDefaultThemes()
            {
                DLLocalDatabase.Theme.InsertDefaultThemes();
            }

            

        }

        public class HttpRequest
        {
            private HttpRequest() { }

            public static HttpRequests GetHttpRequestById(long id)
            {
                return DLLocalDatabase.HttpRequest.GetHttpRequest(id);
            }

            public static void DeleteHttpRequestByReminderId(long id)
            {
                DLLocalDatabase.HttpRequest.DeleteHttpRequestByReminderId(id);
            }
            public static void DeleteHttpRequestById(long id)
            {
                DLLocalDatabase.HttpRequest.DeleteHttpRequestById(id);
            }
            public static List<HttpRequests> GetHttpRequests()
            {
                return DLLocalDatabase.HttpRequest.GetHttpRequests();
            }

            public static long InsertHttpRequest(HttpRequests http)
            {
                if (http != null)
                    return DLLocalDatabase.HttpRequest.InsertHttpRequest(http);
                else return -1;
            }
            /// <summary>
            /// Update the settings in the SQLite database
            /// </summary>
            /// <param name="set">The new settings object</param>
            public static void UpdateTheme(HttpRequests http)
            {
                if (http != null)
                    DLLocalDatabase.HttpRequest.UpdateHttpRequest(http);
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
                return DLLocalDatabase.HttpRequestConditions.GetConditions(requestId);
            }

            /// <summary>
            /// Get the HttpRequest conditions for a HttpRequest
            /// </summary>
            /// <param name="requestId">The id of the parent HttpRequest</param>
            /// <returns></returns>
            public static HttpRequestCondition GetCondition(long id)
            {
                return DLLocalDatabase.HttpRequestConditions.GetCondition(id);
            }

            /// <summary>
            /// Insert a new Request condition into the db
            /// </summary>
            /// <param name="condition"></param>
            /// <returns></returns>
            public static long InsertCondition(HttpRequestCondition condition)
            {
                if (condition != null)
                {
                    condition.Property = condition.Property.Trim(); //remove whitespace

                    return DLLocalDatabase.HttpRequestConditions.InsertCondition(condition);
                }
                else
                    return -1;
            }

            /// <summary>
            /// Delete a single condition by its id
            /// </summary>
            /// <param name="id"></param>
            public static void DeleteConditionById(long id)
            {
                DLLocalDatabase.HttpRequestConditions.DeleteConditionById(id);
            }

            /// <summary>
            /// Delete all conditions that are paired to a HttpRequest
            /// </summary>
            /// <param name="httpRequestId"></param>
            public static void DeleteConditionsForHttpRequest(long httpRequestId)
            {
                DLLocalDatabase.HttpRequestConditions.DeleteConditionsForHttpRequest(httpRequestId);
            }

            public static void UpdateHttpRequest(HttpRequestCondition cond)
            {
                if(cond != null)
                    DLLocalDatabase.HttpRequestConditions.UpdateHttpRequest(cond);
            }
        }
    }
}
