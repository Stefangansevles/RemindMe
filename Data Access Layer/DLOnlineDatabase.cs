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
        private DLOnlineDatabase() { }
        private const int MAX_ATTEMPTS = 15;
        //If the db is unreachable, stop trying to connect to it.
        private static bool terminateDatabaseAccess = false;
        private static bool CanConnect(remindmesqldbEntities db)
        {
            if (terminateDatabaseAccess)
                return false;

            try
            {
                terminateDatabaseAccess = !db.Database.Exists();

                if (terminateDatabaseAccess)
                    return false;

                db.Database.Connection.Open();
                db.Database.Connection.Close();
            }
            catch { return false; }

            return true;
        }
        public static void ReAllowDatabaseAccess()
        {
            if (terminateDatabaseAccess)
                terminateDatabaseAccess = false;
        }
        /// <summary>
        /// Logs an exception to the online database
        /// </summary>
        /// <param name="ex">The exception that is going to be logged</param>
        /// <param name="exceptionDate">The date the exception is logged at</param>
        public static void AddException(Exception ex, DateTime exceptionDate, string pathToSystemLog, string customMessage)
        {
            int attemptCount = 0;
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                while(!terminateDatabaseAccess && !terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }

                db.Database.Connection.Open();
                ExceptionLog log = new ExceptionLog();
                log.ExceptionDate = exceptionDate;

                log.ExceptionMessage = ex.Message;               

                if (customMessage != null)
                    log.CustomMessage = customMessage;

                if (pathToSystemLog != null && File.Exists(pathToSystemLog))
                    log.SystemLog = File.ReadAllText(pathToSystemLog).Replace(Environment.NewLine, "¤");//so we can do a find and replace ¤ to \r\n in notepad++ to make it more readable

                log.ExceptionStackTrace = ex.ToString();
                log.ExceptionType = ex.GetType().ToString();
                log.Username = Environment.UserName;


                db.ExceptionLog.Add(log);
                db.SaveChanges();
            }
        }

        public static bool IsUniqueString(string uniqueString)
        {
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                int attemptCount = 0;
                while (!terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }
                db.Database.Connection.Open();

                return db.Users.Where(u => u.UniqueString == uniqueString).SingleOrDefault() == null;                 
            }
        }

        public static void InsertTheme(Database.Entity.Themes theme)
        {
            try
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();

                    UserThemes usrTheme = new UserThemes();
                    usrTheme.NormalPrimary = theme.Primary;
                    usrTheme.DarkPrimary = theme.DarkPrimary;
                    usrTheme.LightPrimary = theme.LightPrimary;
                    usrTheme.Accent = theme.Accent;
                    usrTheme.TextShade = theme.TextShade;
                    usrTheme.Mode = theme.Mode.Value;
                    usrTheme.ThemeName = theme.ThemeName;

                    db.UserThemes.Add(usrTheme);
                    db.SaveChanges();

                    db.Database.Connection.Close();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString, string remindMeVersion)
        {
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                int attemptCount = 0;
                while (!terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }
                db.Database.Connection.Open();
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
                    usr.UniqueString = uniqueString;
                    usr.LastOnline = DateTime.UtcNow;
                    usr.SignIns++;
                    usr.RemindMeVersion = remindMeVersion;
                    usr.Material = (int)DLLocalDatabase.Setting.Settings.MaterialDesign.Value;
                }

                usr.ActiveReminders = DLReminders.GetReminders().Where(r => r.Enabled == 1).Count();
                usr.DisabledReminders = DLReminders.GetReminders().Where(r => r.Enabled == 0).Count();
                usr.DeletedReminders = DLReminders.GetDeletedReminders().Count;
                usr.ArchivedReminders = DLReminders.GetArchivedReminders().Count;
                usr.TotalReminders = DLReminders.GetAllReminders().Count;

                db.SaveChanges();
            }
        }

        public static void TransformUniqueString(string uniqueStringOld, string uniqueStringNew, string remindMeVersion)
        {
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                int attemptCount = 0;
                while (!terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }
                db.Database.Connection.Open();
                Users usr;
                //If the user doesn't exist in the db yet...
                if (db.Users.Where(u => u.UniqueString == uniqueStringOld).Count() > 0)
                {
                    //Update the LastOnline attribute
                    usr = db.Users.Where(u => u.UniqueString == uniqueStringOld).SingleOrDefault();
                    usr.UniqueString = uniqueStringNew;
                    usr.LastOnline = DateTime.UtcNow;
                    usr.SignIns++;
                    usr.RemindMeVersion = remindMeVersion;
                    db.SaveChanges();
                }               
                
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
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                int attemptCount = 0;
                while (!terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }
                db.Database.Connection.Open();
                
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
        }



        /// <summary>
        /// Gets the RemindMe messages from the database, sent by the creator of RemindMe
        /// </summary>
        public static List<Database.Entity.RemindMeMessages> RemindMeMessages
        {
            get
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    List<Database.Entity.RemindMeMessages> list = new List<Database.Entity.RemindMeMessages>();
                    Database.Entity.RemindMeMessages message;


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
        }

        /// <summary>
        /// Gets the RemindMe messages from the database, sent by the creator of RemindMe
        /// </summary>
        public static RemindMeMessages GetRemindMeMessageById(int id)
        {

            try
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    return db.RemindMeMessages.Where(m => m.Id == id).FirstOrDefault();
                }
            }
            catch (DbUpdateException) { return null; }
            catch { return null; }            
        }

        /// <summary>
        /// Adds another count to the amount of times a message is read
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateRemindMeMessageCount(int id)
        {
            using (remindmesqldbEntities db = new remindmesqldbEntities())
            {
                int attemptCount = 0;
                while (!terminateDatabaseAccess && !CanConnect(db))
                {
                    Thread.Sleep(500);
                    if (attemptCount > MAX_ATTEMPTS)
                        break;
                }
                db.Database.Connection.Open();
                RemindMeMessages mess = db.RemindMeMessages.Where(m => m.Id == id).FirstOrDefault();
                mess.ReadByAmountOfUsers++;
                db.SaveChanges();
            }
        }
       
        /// <summary>
        /// Gets the amount of messages sent in the misc table
        /// </summary>
        public static int MessageCount
        {
            get
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.MessageCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    return db.ExceptionLog.Count();
                }
            }

        }

        /// <summary>
        /// Gets the amount of timers that have been created
        /// </summary>
        public static int TimersCreated
        {
            get
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.TimersCreated;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.RemindersCreated;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.ImportCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.ExportCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.RecoverCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.PreviewCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.DuplicateCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.HideCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.PostponeCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.SkipCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
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
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault(m => m.Id == 1);
                    return misc.PermanentelyDeleteCount;
                }
            }
            set
            {
                using (remindmesqldbEntities db = new remindmesqldbEntities())
                {
                    int attemptCount = 0;
                    while (!terminateDatabaseAccess && !CanConnect(db))
                    {
                        Thread.Sleep(500);
                        if (attemptCount > MAX_ATTEMPTS)
                            break;
                    }
                    db.Database.Connection.Open();
                    Misc misc = db.Misc.SingleOrDefault();
                    misc.PermanentelyDeleteCount = value;
                    db.SaveChanges();
                }
            }
        }
    }
}
