using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    static class Program
    {
        //Checks if we can send an e-mail, when users come accross an error, they tend to try it multiple times. We don't want to spam e-mails.
        private static bool allowEmail = true;
        private static System.Windows.Forms.Timer tmrAllowEmail = null;

       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            string resource1 = "RemindMe.Bunifu_UI_v1.5.3.dll";            
            EmbeddedAssembly.Load(resource1, "Bunifu_UI_v1.5.3.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            using (Mutex mutex = new Mutex(false, "Global\\" + "RemindMe"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    //one instance of remindme already running                                                                                                
                    if (args.Length > 0)
                    {//The user double-clicked an .remindme file! 
                        BLIO.Log("Detected the double clicking of a .remindme file!");
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
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }


        private static void ShowError(Exception ex, string message, string description)
        {
            //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
            //that has an bunifu control in it(like a button), while there shouldn't be an exception.
            if ( !(ex is System.Runtime.InteropServices.ExternalException) && ex.Source != "System.Drawing" && !ex.StackTrace.Contains("GDI+"))
            {
                BLIO.Log("\r\n=====EXCEPTION!!=====\r\n" + ex.GetType().ToString() + "\r\n" + ex.StackTrace + "\r\n");
                ErrorPopup popup;
                if (allowEmail)
                {
                    popup = new ErrorPopup(message + "\r\n" + description, ex);
                    startTimer();
                }
                else
                    popup = new ErrorPopup(message + "\r\n" + description, ex, false);

                popup.Show();
            }
           
        }

        private static void startTimer()
        {
            if (tmrAllowEmail == null)
            {
                tmrAllowEmail = new System.Windows.Forms.Timer();
                tmrAllowEmail.Interval = 30000; //30 seconds
                tmrAllowEmail.Tick += TmrAllowEmail_Tick; //subscribe to tick event
            }


            if (!tmrAllowEmail.Enabled) //Not running? run.
                tmrAllowEmail.Start();
        }

        private static void TmrAllowEmail_Tick(object sender, EventArgs e)
        {
            if (!allowEmail) //Not allowed? allow.
                allowEmail = true;

            tmrAllowEmail.Stop();
        }


        //All uncaught exceptions will go here instead. We will replace the default windows popup with our own custom one and filter out what kind of exception is being thrown
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
            if (e.Exception is ReminderException)
            {
                ReminderException theException = (ReminderException)e.Exception;
                BLIO.WriteError(e.Exception, "Error with this reminder (" + theException.Reminder.Name + ") !");
                ShowError(e.Exception, "Reminder error!", theException.Message);
                UCReminders.NotifyChange();
            }
            else if(e.Exception is DirectoryNotFoundException)
            {
                DirectoryNotFoundException theException = (DirectoryNotFoundException)e.Exception;
                BLIO.WriteError(theException, "Folder not found.");
                ShowError(e.Exception, e.Exception.GetType().ToString(), theException.Message);
            }

            else if(e.Exception is UnauthorizedAccessException)
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
            else if (e.Exception is DbUpdateConcurrencyException)
            {
                BLIO.WriteError(e.Exception, "Database error.");
                ShowError(e.Exception, "Database error!", "Database error encountered!");
            }

            else if (e.Exception is Exception)
            {
                BLIO.WriteError(e.Exception, "Unknown exception in main.");
                ShowError(e.Exception, "Unknown", "Unknown exception in main.");
            }
            
        }
    }
}
