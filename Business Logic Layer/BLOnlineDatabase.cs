using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public static void AddException(Exception ex, DateTime exceptionDate)
        {
            try
            {
                new Thread(() =>
                {                   
                    //Don't do anything without internet
                    if (!BLIO.HasInternetAccess())
                        return;

                    if (ex != null && ex.Message != null && ex.StackTrace != null && exceptionDate != null)
                        DLOnlineDatabase.AddException(ex, exceptionDate);
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
                }).Start();
            }
            catch (Exception exc)
            {
                BLIO.Log("BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.ToString());
                BLIO.WriteError(exc, "BLOnlineDatabase.InsertEmailAttempt() failed: exception occured: " + exc.ToString(), false);
            }
        }
    }
}
