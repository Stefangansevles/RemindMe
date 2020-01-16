using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLOnlineDatabase
    {
        //The entities for the online database
        private static remindmesqldbEntities db = new remindmesqldbEntities();

        private DLOnlineDatabase() { }

        /// <summary>
        /// Logs an exception to the online database
        /// </summary>
        /// <param name="ex">The exception that is going to be logged</param>
        /// <param name="exceptionDate">The date the exception is logged at</param>
        public static void AddException(Exception ex, DateTime exceptionDate, string pathToSystemLog, string customMessage, string alternativeExceptionMessage)
        {
            try
            {                                
                ExceptionLog log = new ExceptionLog();
                log.ExceptionDate = exceptionDate;

                if (alternativeExceptionMessage == null)
                    log.ExceptionMessage = ex.Message; 
                else
                    log.ExceptionMessage = alternativeExceptionMessage;

                if (customMessage != null)
                    log.CustomMessage = customMessage;

                if (pathToSystemLog != null)
                    log.SystemLog = File.ReadAllText(pathToSystemLog).Replace(Environment.NewLine, "¤");//so we can do a find and replace ¤ to \r\n in notepad++ to make it more readable

                log.ExceptionStackTrace = ex.ToString();
                log.ExceptionType = ex.GetType().ToString();
                log.Username = Environment.UserName;
                

                db.ExceptionLog.Add(log);
                db.SaveChanges();
            }
            catch (DbUpdateException) { }
            catch  { }            
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
                UpdateLog log = new UpdateLog();
                log.UpdateDate = updateDate;
                log.PreviousVersion = previousVersion;
                log.UpdateVersion = updateVersion;
                log.Username = Environment.UserName;

                db.UpdateLog.Add(log);
                db.SaveChanges();
            }
            catch (DbUpdateException) { }
            catch { }
        }

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString, string remindMeVersion)
        {
            try
            {
                Users usr;
                //If the user doesn't exist in the db yet...
                if (db.Users.Where(u => u.UniqueString == uniqueString).Count() == 0)
                {
                    usr = new Users();
                    usr.Username = Environment.UserName;
                    usr.UniqueString = uniqueString;
                    usr.LastOnline = DateTime.UtcNow;
                    usr.RemindMeVersion = remindMeVersion;                   

                    db.Users.Add(usr);                    
                }
                else
                {
                    //Update the LastOnline attribute
                    usr = db.Users.Where(u => u.UniqueString == uniqueString).SingleOrDefault();
                    usr.LastOnline = DateTime.UtcNow;
                    usr.SignIns++;
                    usr.RemindMeVersion = remindMeVersion;                    
                }

                usr.ActiveReminders = DLReminders.GetReminders().Where(r => r.Enabled == 1).Count();
                usr.DisabledReminders = DLReminders.GetReminders().Where(r => r.Enabled == 0).Count();
                usr.DeletedReminders = DLReminders.GetDeletedReminders().Count;
                usr.ArchivedReminders = DLReminders.GetArchivedReminders().Count;
                usr.TotalReminders = DLReminders.GetAllReminders().Count;

                db.SaveChanges();
            }
            catch (DbUpdateException) { }
            catch  { }
        }       

        /// <summary>
        /// Inserts a user into the database for the first time (different database table)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertFirstTimeUser(string uniqueString, string remindMeVersion)
        {
            try
            {
                //If the user doesn't exist in the db yet (It shouldn't!)
                if (db.NewInstallations.Where(u => u.UniqueString == uniqueString).Count() == 0)
                {
                    NewInstallations ni = new NewInstallations();
                    ni.Username = Environment.UserName;
                    ni.UniqueString = uniqueString;                    
                    ni.InstallDate = DateTime.UtcNow;
                    ni.InstallVersion = remindMeVersion;

                    db.NewInstallations.Add(ni);
                    db.SaveChanges();
                }                  
            }
            catch (DbUpdateException) { }
            catch  { }
        }

        /// <summary>
        /// Inserts an e-mail into the database. In case sending the e-mail didn't work, it is still registered in the db
        /// </summary>
        /// <param name="uniqueString">The user's unique string</param>
        /// <param name="emailMessage">The e-mail message</param>
        /// <param name="emailSubject">The e-mail subject</param>
        /// <param name="eMailAddress">The users e-mail address. This is optional</param>
        public static void InsertEmailAttempt(string uniqueString, string emailMessage,string emailSubject, string eMailAddress = "")
        {
            try
            {
                EmailAttempts ea = new EmailAttempts();
                ea.Username = Environment.UserName;
                ea.UserId = uniqueString;
                ea.Message = emailMessage;
                ea.Subject = emailSubject;

                if (!string.IsNullOrWhiteSpace(eMailAddress))
                    ea.E_mail = eMailAddress;

                db.EmailAttempts.Add(ea);
                db.SaveChanges();
            }
            catch (DbUpdateException) { }
            catch  { }
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
                LocalErrorLog loc = new LocalErrorLog();
                loc.TimeStamp = DateTime.UtcNow;
                loc.LogContents = logContents;
                loc.LogLineCount = lineCount;
                loc.Username = Environment.UserName;
                loc.UserId = uniqueString;


                db.LocalErrorLog.Add(loc);
                db.SaveChanges();
            }
            catch (DbUpdateException) { }
            catch { }
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
                    List<Database.Entity.RemindMeMessages> list = new List<Database.Entity.RemindMeMessages>();
                    Database.Entity.RemindMeMessages message;

                    using (db)
                    {
                        //Because it can't be converted, i guess we have to do it ourselves
                        foreach (RemindMeMessages mess in db.RemindMeMessages)
                        {
                            message = new Database.Entity.RemindMeMessages();

                            message.Id = mess.Id;
                            message.MeantForSpecificVersion = mess.MeantForSpecificVersion;
                            message.Message = mess.Message;
                            message.NotificationDuration = mess.NotificationDuration;
                            message.NotificationOnTop = mess.NotificationOnTop;
                            message.NotificationType = mess.NotificationType;
                            message.MeantForSpecificPerson = mess.MeantForSpecificPerson;
                            message.ReadByAmountOfUsers = mess.ReadByAmountOfUsers;
                            message.DateOfCreation = mess.DateOfCreation;

                            list.Add(message);
                        }
                        return list;
                    }                    
                }
                catch (DbUpdateException ex) { AddException(ex, DateTime.Now, null, null, "!!!Something went wrong in DLOnlineDatabase.RemindMeMessages() ? :("); return new List<Database.Entity.RemindMeMessages>(); }
                catch (Exception ex)  { AddException(ex,DateTime.Now,null,null, "!!!Something went wrong in DLOnlineDatabase.RemindMeMessages() ? :(");  return new List<Database.Entity.RemindMeMessages>(); }
            }

        }

        /// <summary>
        /// Gets the RemindMe messages from the database, sent by the creator of RemindMe
        /// </summary>
        public static RemindMeMessages GetRemindMeMessageById(int id)
        {

            try
            {
                return db.RemindMeMessages.Where(m => m.Id == id).FirstOrDefault();                
            }
            catch (DbUpdateException) { return null; }
            catch  { return null; }
        }

        /// <summary>
        /// Adds another count to the amount of times a message is read
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateRemindMeMessageCount(int id)
        {
            RemindMeMessages mess = db.RemindMeMessages.Where(m => m.Id == id).FirstOrDefault();
            mess.ReadByAmountOfUsers++;
            db.SaveChanges();
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
                    using (db)                    
                        return db.Users.Count();
                }
                catch (DbUpdateException) { return -1;  }
                catch  { return -1; }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.MessageCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.MessageCount = value;
                    db.SaveChanges();
                }
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
                    using (db)                    
                        return db.ExceptionLog.Count();
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.TimersCreated;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    misc.TimersCreated = value;
                    db.SaveChanges();
                }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.RemindersCreated;
                    }                        
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.RemindersCreated = value;
                    db.SaveChanges();
                }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.ImportCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.ImportCount = value;
                    db.SaveChanges();
                }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.ExportCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.ExportCount = value;
                    db.SaveChanges();
                }
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
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.RecoverCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.RecoverCount = value;
                    db.SaveChanges();
                }
            }
        }
        //--
        public static int PreviewCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.PreviewCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.PreviewCount = value;
                    db.SaveChanges();
                }
            }
        }
        public static int DuplicateCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.DuplicateCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.DuplicateCount = value;
                    db.SaveChanges();
                }
            }
        }
        public static int HideCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.HideCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.HideCount = value;
                    db.SaveChanges();
                }
            }
        }
        public static int PostponeCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.PostponeCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.PostponeCount = value;
                    db.SaveChanges();
                }
            }
        }
        public static int SkipCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.SkipCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.SkipCount = value;
                    db.SaveChanges();
                }
            }
        }
        public static int PermanentelyDeleteCount
        {
            get
            {
                try
                {
                    using (db)
                    {
                        Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                        return misc.PermanentelyDeleteCount;
                    }
                }
                catch (DbUpdateException) { return -1; }
                catch { return -1; }
            }
            set
            {
                using (db)
                {
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.PermanentelyDeleteCount = value;
                    db.SaveChanges();
                }
            }
        }
    }
}
