using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public static void AddException(Exception ex, DateTime exceptionDate)
        {
            try
            {                
                ExceptionLog log = new ExceptionLog();
                log.ExceptionDate = exceptionDate;
                log.ExceptionMessage = ex.Message;
                log.ExceptionStackTrace = ex.ToString();
                log.ExceptionType = ex.GetType().ToString();
                log.Username = Environment.UserName;

                db.ExceptionLog.Add(log);
                db.SaveChanges();
            }
            catch (DbUpdateException exc) { }
            catch (Exception exce) { }
            
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
            catch (DbUpdateException exc) { }
            catch (Exception exce) { }
        }

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString, string remindMeVersion)
        {
            try
            {
                //If the user doesn't exist in the db yet...
                if (db.Users.Where(u => u.UniqueString == uniqueString).Count() == 0)
                {
                    Users usr = new Users();
                    usr.Username = Environment.UserName;
                    usr.UniqueString = uniqueString;
                    usr.LastOnline = DateTime.Now;
                    usr.RemindMeVersion = remindMeVersion;

                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                else
                {
                    //Update the LastOnline attribute
                    Users usr = db.Users.Where(u => u.UniqueString == uniqueString).SingleOrDefault();
                    usr.LastOnline = DateTime.Now;
                    usr.RemindMeVersion = remindMeVersion;
                    db.SaveChanges();

                }
            }
            catch (DbUpdateException exc) { }
            catch (Exception exce) { }
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
                    ni.InstallDate = DateTime.Now;
                    ni.InstallVersion = remindMeVersion;

                    db.NewInstallations.Add(ni);
                    db.SaveChanges();
                }                  
            }
            catch (DbUpdateException exc) { }
            catch (Exception exce) { }
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
            catch (DbUpdateException exc) { }
            catch (Exception exce) { }
        }
    }
}
