using System;
using System.Collections.Generic;
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
            new Thread(() =>
            {
                ExceptionLog log = new ExceptionLog();
                log.ExceptionDate = exceptionDate;
                log.ExceptionMessage = ex.Message;
                log.ExceptionStackTrace = ex.ToString();
                log.ExceptionType = ex.GetType().ToString();
                log.Username = Environment.UserName;

                db.ExceptionLog.Add(log);
                db.SaveChanges();
            }).Start();
        }
        /// <summary>
        /// Adds a new entry to the database where a user updates their RemindMe version
        /// </summary>
        /// <param name="updateDate">Date of update</param>
        /// <param name="previousVersion">The previously installed RemindMe version on his/her machine</param>
        /// <param name="updateVersion">The version the user updated to</param>
        public static void AddNewUpdate(DateTime updateDate,string previousVersion,string updateVersion)
        {
            new Thread(() =>
            {
                UpdateLog log = new UpdateLog();
                log.UpdateDate = updateDate;
                log.PreviousVersion = previousVersion;
                log.UpdateVersion = updateVersion;
                log.Username = Environment.UserName;

                db.UpdateLog.Add(log);
                db.SaveChanges();
            }).Start();
        }

        /// <summary>
        /// Inserts a user into the database to keep track of how many users RemindMe has (after version 2.6.02)
        /// </summary>
        /// <param name="uniqueString"></param>
        public static void InsertOrUpdateUser(string uniqueString)
        {
            new Thread(() =>
            {
                //If the user doesn't exist in the db yet...
                if(db.Users.Where(u => u.UniqueString == uniqueString).Count() == 0)
                {
                    Users usr = new Users();
                    usr.Username = Environment.UserName;
                    usr.UniqueString = uniqueString;
                    usr.LastOnline = DateTime.Now;

                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                else
                {
                    //Update the LastOnline attribute
                    Users usr = db.Users.Where(u => u.UniqueString == uniqueString).SingleOrDefault();
                    usr.LastOnline = DateTime.Now;
                    db.SaveChanges();
                    
                }
               
            }).Start();
        }
    }
}
