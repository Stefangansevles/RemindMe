using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Business_Logic_Layer
{
    public class BLOnlineDatabase
    {
        private BLOnlineDatabase() {  }
        
        /// <summary>
        /// Logs an exception to the online database
        /// </summary>
        /// <param name="ex">The exception that is going to be logged</param>
        /// <param name="exceptionDate">The date the exception is logged at</param>
        public static void AddException(Exception ex, DateTime exceptionDate, string pathToSystemLog, string customMessage = null)
        {
            try
            {                
                new Thread(() =>
                {                   
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (ex != null && ex.Message != null && ex.StackTrace != null && exceptionDate != null)
                        DLOnlineDatabase.AddException(ex, exceptionDate, pathToSystemLog, customMessage, GetAlternativeExceptionMessage(ex));
                    else
                        BLIO.Log("BLOnlineDatabase.AddException() failed: parameter(s) null");
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.AddException() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.AddException() failed: exception occured: " + exc.ToString(), false);
            }
        }
        private static string GetAlternativeExceptionMessage(Exception ex)
        {
            string mess = "Oops! An error has occured. Here's the details:\r\n\r\n" + ex.ToString();


            if (ex != null && ex.GetType().ToString().Contains("ReminderException"))
            {
                ReminderException theException = (ReminderException)ex;
                theException.Reminder.Note = "Removed for privacy reasons";
                theException.Reminder.Name = "Removed for privacy reasons";

                mess += "\r\n\r\nThis exception is an ReminderException! Let's see if we can figure out what's wrong with it....\r\n";
                mess += "ID:    " + theException.Reminder.Id + "\r\n";
                mess += "Corrupted:    " + theException.Reminder.Corrupted + "\r\n";
                mess += "Deleted:    " + theException.Reminder.Deleted + "\r\n";
                mess += "Date:  " + theException.Reminder.Date + "\r\n";
                mess += "RepeatType:    " + theException.Reminder.RepeatType + "\r\n";
                mess += "Enabled:   " + theException.Reminder.Enabled + "\r\n";
                mess += "DayOfMonth:    " + theException.Reminder.DayOfMonth + "\r\n";
                mess += "EveryXCustom:  " + theException.Reminder.EveryXCustom + "\r\n";
                mess += "RepeatDays:    " + theException.Reminder.RepeatDays + "\r\n";
                mess += "SoundFilePath: " + theException.Reminder.SoundFilePath + "\r\n";
                mess += "PostponeDate:  " + theException.Reminder.PostponeDate + "\r\n";
                mess += "Hide:  " + theException.Reminder.Hide + "\r\n";
                mess += "UpdateTime:  " + theException.Reminder.UpdateTime + "\r\n\r\n";

                mess += "=== Displaying date culture info, so you might be able to re-create the reminder ===\r\n";
                mess += "Current culture DisplayName: " + CultureInfo.CurrentCulture.DisplayName + "\r\n";
                mess += "Current culture ShortTimePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern + "\r\n";
                mess += "Current culture ShortDatePattern: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + "\r\n";
                mess += "Current culture ToString(): " + CultureInfo.CurrentCulture.ToString() + "\r\n";
            }
            else
                return null;

            return mess;
        }

        /// <summary>
        /// Adds a new entry to the database where a user updates their RemindMe version
        /// </summary>
        /// <param name="updateDate">Date of update</param>
        /// <param name="previousVersion">The previously installed RemindMe version on his/her machine</param>
        /// <param name="updateVersion">The version the user updated to</param>
        public static void AddNewUpgrade(DateTime updateDate, string previousVersion, string updateVersion)
        {
            try
            {
                new Thread(() =>
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (!string.IsNullOrWhiteSpace(previousVersion) && !string.IsNullOrWhiteSpace(updateVersion))
                        DLOnlineDatabase.AddNewUpgrade(updateDate, previousVersion, updateVersion);
                    else
                        BLIO.Log("Invalid previous/update version string parameter in BLOnlineDatabase.AddNewUpdate()");
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.AddNewUpdate() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.AddNewUpdate() failed: exception occured: " + exc.ToString(), false);
            }
        }


        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString)
        {
            try
            {
                new Thread(() =>
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    BLIO.Log("Updating user");

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertOrUpdateUser(uniqueString, IOVariables.RemindMeVersion);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertUser(). String: " + uniqueString);
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.InsertUser() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.InsertUser() failed: exception occured: " + exc.ToString(),false);
            }
        }

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertFirstTimeUser(string uniqueString)
        {
            try
            {
                new Thread(() =>
                {                    
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertFirstTimeUser(uniqueString, IOVariables.RemindMeVersion);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertFirstTimeUser(). String: " + uniqueString);
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.InsertFirstTimeUser() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.InsertFirstTimeUser() failed: exception occured: " + exc.ToString(), false);
            }
        }

        /// <summary>
        /// Inserts an e-mail into the database. In case sending the e-mail didn't work, it is still registered in the db
        /// </summary>
        /// <param name="uniqueString">The user's unique string</param>
        /// <param name="emailMessage">The e-mail message</param>
        /// <param name="emailSubject">The e-mail subject</param>
        /// <param name="eMailAddress">The users e-mail address. This is optional</param>
        public static void InsertEmailAttempt(string uniqueString, string emailMessage, string emailSubject, string eMailAddress = "")
        {
            try
            {
                new Thread(() =>
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertEmailAttempt(uniqueString,emailMessage,emailSubject,eMailAddress);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertEmailAttempt(). String: " + uniqueString);

                    MessageCount++;
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.ToString(), false);
            }
        }

        /// <summary>
        /// Inserts the contents of the local errorlog.txt into the database
        /// </summary>
        /// <param name="uniqueString">The unique user identifier</param>
        /// <param name="logContents">The contents of errorlog.txt</param>
        /// <param name="lineCount">The amount of lines in errorlog.txt</param>
        public static void InsertLocalErrorLog(string uniqueString, string logContents, int lineCount)
        {
            try
            {
                new Thread(() =>
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertLocalErrorLog(uniqueString, logContents,lineCount);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertLocalErrorLog(). String: " + uniqueString);
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.InsertLocalErrorLog() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.InsertLocalErrorLog() failed: exception occured: " + exc.ToString(), false);
            }
        }


        /// <summary>
        /// Gets the RemindMe messages from the database, sent by the creator of RemindMe
        /// </summary>
        public static List<Database.Entity.RemindMeMessages> RemindMeMessages
        {
            get
            {
                try
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return new List<Database.Entity.RemindMeMessages>();
                    else
                        return DLOnlineDatabase.RemindMeMessages;                    
                }
                catch (Exception exc)
                {                    
                    BLIO.Log("BLOnlineDatabase.UserCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.UserCount failed: exception occured: " + exc.ToString(), false);
                    AddException(exc, DateTime.Now, BLIO.GetLogTxtPath(), null);
                    return new List<Database.Entity.RemindMeMessages>();
                }
            }

        }

        /// <summary>
        /// Adds another count to the amount of times a message is read
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateRemindMeMessageCount(int id)
        {
            if(id > -1)
                DLOnlineDatabase.UpdateRemindMeMessageCount(id);
        }


        /// <summary>
        /// Gets the RemindMe messages from the database, sent by the creator of RemindMe
        /// </summary>
        public static Database.Entity.RemindMeMessages GetRemindMeMessageById(int id)
        {
            //Don't do anything without internet
            if (!BLIO.HasInternetAccess())
                return null;

            Data_Access_Layer.RemindMeMessages dbObject = DLOnlineDatabase.GetRemindMeMessageById(id);

            if (dbObject == null)
                return null;

            Database.Entity.RemindMeMessages message = new Database.Entity.RemindMeMessages();

            message.Id = dbObject.Id;
            message.MeantForSpecificVersion = dbObject.MeantForSpecificVersion;
            message.Message = dbObject.Message;
            message.NotificationDuration = dbObject.NotificationDuration;
            message.NotificationOnTop = dbObject.NotificationOnTop;
            message.NotificationType = dbObject.NotificationType;
            message.ReadByAmountOfUsers = dbObject.ReadByAmountOfUsers;
            message.DateOfCreation = dbObject.DateOfCreation;

            return message;            
        }

        /// <summary>
        /// Gets the amount of users in the misc table
        /// </summary>
        public static int UserCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.UserCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.UserCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.UserCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
        }
        /// <summary>
        /// Gets the amount of messages sent in the misc table
        /// </summary>
        public static int MessageCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.MessageCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.MessageCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.MessageCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to MessageCount.");

                DLOnlineDatabase.MessageCount = value;
            }

        }
   

        /// <summary>
        /// Gets the amount of timers that have been created
        /// </summary>
        public static int TimersCreated
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.TimersCreated;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.TimersCreated failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.TimersCreated failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to TimersCreated.");

                DLOnlineDatabase.TimersCreated = value;
            }
        }

        /// <summary>
        /// Gets the amount of reminders that have been created
        /// </summary>
        public static int RemindersCreated
        {
            get
            {
                try
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.RemindersCreated;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.RemindersCreated failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.RemindersCreated failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to RemindersCreated.");

                DLOnlineDatabase.RemindersCreated = value;
            }
        }

        /// <summary>
        /// Gets the amount of times reminders have been imported
        /// </summary>
        public static int ImportCount
        {
            get
            {
                try
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.ImportCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.ImportCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.ImportCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to ImportCount.");

                DLOnlineDatabase.ImportCount = value;
            }
        }

        /// <summary>
        /// Gets the amount of times reminders have been exported
        /// </summary>
        public static int ExportCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.ExportCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.ExportCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.ExportCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to ExportCount.");

                DLOnlineDatabase.ExportCount = value;
            }
        }
        /// <summary>
        /// Gets the amount of times reminders have been recovered
        /// </summary>
        public static int RecoverCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.RecoverCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.RecoverCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.RecoverCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to RecoverCount.");

                DLOnlineDatabase.RecoverCount = value;
            }
        }
        /// <summary>
        /// Gets the amount of exceptions in the misc table
        /// </summary>
        public static int ExceptionCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.ExceptionCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.ExceptionCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.ExceptionCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }            
        }
        public static int PreviewCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.PreviewCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.PreviewCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.PreviewCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to PreviewCount.");

                DLOnlineDatabase.PreviewCount = value;
            }
        }
        public static int DuplicateCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.DuplicateCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.DuplicateCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.DuplicateCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to DuplicateCount.");

                DLOnlineDatabase.DuplicateCount = value;
            }
        }
        public static int HideCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.HideCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.HideCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.HideCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to HideCount.");

                DLOnlineDatabase.HideCount = value;
            }
        }
        public static int PostponeCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.PostponeCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.PostponeCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.PostponeCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to PostponeCount.");

                DLOnlineDatabase.PostponeCount = value;
            }
        }
        public static int SkipCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.SkipCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.SkipCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.SkipCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to SkipCount.");

                DLOnlineDatabase.SkipCount = value;
            }
        }
        public static int PermanentelyDeleteCount
        {
            get
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return -1;
                    else
                        return DLOnlineDatabase.PermanentelyDeleteCount;
                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.PermanentelyDeleteCount failed: exception occured: " + exc.ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.PermanentelyDeleteCount failed: exception occured: " + exc.ToString(), false);
                    return -1;
                }
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cannot assign value " + value + " to PermanentelyDeleteCount.");

                DLOnlineDatabase.PermanentelyDeleteCount = value;
            }
        }
    }
}
