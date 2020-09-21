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
        public static void AddException(Exception ex, DateTime exceptionDate, string pathToSystemLog, string customMessage = "Invisible")
        {
            new Thread(() =>
            {
                try
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                       return;
                   
                    //Don't log these kind of exceptions
                    if (ex is System.Data.Entity.Core.EntityException || ex is System.Data.Entity.Core.EntityCommandExecutionException
                     || ex is System.Data.SqlClient.SqlException)
                    {
                        BLIO.Log("AddException() Skipped. Exception is " + ex.GetType().ToString());
                        return;
                    }

                    //Write the system log contents to the .txt file, so that the database record contains the latest system log info
                    BLIO.DumpLogTxt(); 

                    if (ex != null && ex.Message != null && ex.StackTrace != null && exceptionDate != null)
                        DLOnlineDatabase.AddException(ex, exceptionDate, pathToSystemLog, customMessage);
                    else
                        BLIO.Log("BLOnlineDatabase.AddException() failed: parameter(s) null");

                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.AddException() failed: exception occured: " + exc.GetType().ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.AddException() failed: exception occured: " + exc.ToString(), false);
                }
            }).Start();
        }

        public static bool IsUniqueString(string uniqueString)
        {
            return DLOnlineDatabase.IsUniqueString(uniqueString);                        
        }

        

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString)
        {
            new Thread(() =>
            {
                try
                {
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (BLIO.LastLogMessage != null && !BLIO.LastLogMessage.Contains("Updating user"))
                        BLIO.Log("Updating user");

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertOrUpdateUser(uniqueString, IOVariables.RemindMeVersion);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertUser(). String: " + uniqueString);

                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.InsertUser() failed: exception occured: " + exc.GetType().ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.InsertUser() failed: exception occured: " + exc.ToString(), false);
                }
            }).Start();
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
            new Thread(() =>
            {
                try
                {

                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (!string.IsNullOrWhiteSpace(uniqueString))
                        DLOnlineDatabase.InsertEmailAttempt(uniqueString, emailMessage, emailSubject, eMailAddress);
                    else
                        BLIO.Log("Invalid uniqueString version string parameter in BLOnlineDatabase.InsertEmailAttempt(). String: " + uniqueString);

                    MessageCount++;

                }
                catch (Exception exc)
                {
                    BLIO.Log("BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.GetType().ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.ToString(), false);
                }
            }).Start();
        }       

        public static void ReAllowDatabaseAccess()
        {
            DLOnlineDatabase.ReAllowDatabaseAccess();
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
                    string logTxtPath = IOVariables.systemLog;
                    BLIO.Log("BLOnlineDatabase.RemindMeMessages failed: exception occured: " + exc.GetType().ToString());
                    BLIO.WriteError(exc, "BLOnlineDatabase.RemindMeMessages failed: exception occured: " + exc.ToString(), false);
                    AddException(exc, DateTime.Now, logTxtPath, null);
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
            new Thread(() =>
            {
                if (id > -1)
                    DLOnlineDatabase.UpdateRemindMeMessageCount(id);
            }).Start();
        }

        /// <summary>
        /// Adds another count to the amount of times a message is read
        /// </summary>
        /// <param name="id"></param>
        public static void InsertTheme(Themes theme)
        {
            new Thread(() =>
            {                
                if(theme != null && theme.IsDefault == 0)
                    DLOnlineDatabase.InsertTheme(theme);

            }).Start();
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
                    BLIO.Log("BLOnlineDatabase.MessageCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.TimersCreated failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.RemindersCreated failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.ImportCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.ExportCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.RecoverCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.ExceptionCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.PreviewCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.DuplicateCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.HideCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.PostponeCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.SkipCount failed: exception occured: " + exc.GetType().ToString());
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
                    BLIO.Log("BLOnlineDatabase.PermanentelyDeleteCount failed: exception occured: " + exc.GetType().ToString());
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
