using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;
using System.Data.SQLite;
using System.IO;
using Business_Logic_Layer;
using System.IO.Pipes;
using System.Text;
using Database.Entity;

namespace RemindMe
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main(string[] args)
        {            
            using (Mutex mutex = new Mutex(false, "Global\\" + "RemindMe"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    //one instance of remindme already running                                                                                                
                    if (args.Length > 0)
                    {//The user double-clicked an .remindme file!                           
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new RemindMeImporter(args[0]));
                    }
                    return;
                }
               
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);                
                Application.Run(new Form1());                
            }    
        }

        private static void ShowError(Exception ex,string message,string description)
        {
            ErrorPopup popup = new ErrorPopup(message, ex, description);
            popup.Show();
        }

        //All uncaught exceptions will go here instead. We will replace the default windows popup with our own custom one and filter out what kind of exception is being thrown
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if(e.Exception is DirectoryNotFoundException)
            {                
                DirectoryNotFoundException theException = (DirectoryNotFoundException)e.Exception; 
                BLIO.WriteError(theException, "Folder not found.");
                ShowError(e.Exception, e.Exception.GetType().ToString(), theException.Message);
            }

            if (e.Exception is UnauthorizedAccessException)
            {
                UnauthorizedAccessException theException = (UnauthorizedAccessException)e.Exception;                
                BLIO.WriteError(e.Exception, "Unauthorized!");
                ShowError(e.Exception, "Unauthorized!", "RemindMe is not authorized for this action.\r\nThis can be resolved by running RemindMe in administrator-mode.");
            }

            //Here we just filter out some type of exceptions and give different messages, at the bottom is the super Exception, which can be anything.              
            else if (e.Exception is FileNotFoundException)
            {
                FileNotFoundException theException = (FileNotFoundException)e.Exception; //needs in instance to call .FileName
                BLIO.WriteError(theException, "Could not find the file located at \"" + theException.FileName);
                ShowError(e.Exception, "File not found.", "Could not find the file located at \"" + theException.FileName + "\"\r\nHave you moved,renamed or deleted the file?");
            }

            else if (e.Exception is System.Data.Entity.Core.EntityException)
            {
                BLIO.WriteError(e.Exception, "System.Data.Entity.Core.EntityException");
                ShowError(e.Exception, "System.Data.Entity.Core.EntityException", "There was a problem executing SQL!");
            }

            else if (e.Exception is ArgumentNullException)
            {
                BLIO.WriteError(e.Exception, "Null argument");
                ShowError(e.Exception, "Null argument", "Null argument exception! Whoops! this is not on your end!");
            }

            else if (e.Exception is NullReferenceException)
            {
                BLIO.WriteError(e.Exception, "Null reference");
                ShowError(e.Exception, "Null reference", "Null reference exception! Whoops! this is not on your end!");
            }

            else if (e.Exception is SQLiteException)
            {
                BLIO.WriteError(e.Exception, "SQLite Database exception");
                ShowError(e.Exception, "SQLite Database exception", "Remindme has encountered a database error!\r\nThis might or might not be on your end. It can be on your end if you modified the database file");
            }

            else if (e.Exception is PathTooLongException)
            {
                BLIO.WriteError(e.Exception, "The path to the file is too long.");
                ShowError(e.Exception, "File Path too long.", "The path to the file is too long!.");
            }

            else if (e.Exception is StackOverflowException)
            {
                BLIO.WriteError(e.Exception, "StackOverFlowException");
                ShowError(e.Exception, "StackOverFlowException", "RemindMe has encountered a stackoverflow! This is probably not your fault. Sorry!");
            }

            else if (e.Exception is OutOfMemoryException)
            {
                BLIO.WriteError(e.Exception, "Out of Memory");
                ShowError(e.Exception, "Out of Memory", "RemindMe is out of memory!");
            }
           
            else if (e.Exception is ReminderException)
            {
                BLIO.WriteError(e.Exception, "Reminder exception");
                ShowError(e.Exception, "Reminder exception", e.Exception.Message);
            }

            else if (e.Exception is Exception)
            {
                BLIO.WriteError(e.Exception, "Unknown exception in main.");
                ShowError(e.Exception, "Unknown", "Unknown exception in main.");
            }
        }
    }
}
