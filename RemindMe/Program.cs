using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RemindMe
{
    static class Program
    {
        //default to true
        private static bool isMaterial = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string resource1 = "RemindMe.Bunifu_UI_v1.5.3.dll";
            EmbeddedAssembly.Load(resource1, "Bunifu_UI_v1.5.3.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            AppDomain.CurrentDomain.SetData("DataDirectory", IOVariables.databaseFile);
            BLIO.CreateDatabaseIfNotExist();

            if (!BLLocalDatabase.HasAllTables())
                isMaterial = true;
            else
            {
                //See if the user wants Material Design or old RemindMe-Design (Default = Material)
                Settings set = BLLocalDatabase.Setting.Settings;
                if (set != null && set.MaterialDesign != null && set.MaterialDesign.HasValue) //not null               
                    isMaterial = Convert.ToBoolean(BLLocalDatabase.Setting.Settings.MaterialDesign.Value);
            }



            if (args.Length > 0)
            {//The user double-clicked an .remindme file! 
                BLIO.Log("Detected the double clicking of a .remindme file!");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (isMaterial)
                    Application.Run(new MaterialRemindMeImporter(args[0]));
                else
                    Application.Run(new RemindMeImporter(args[0]));
            }

            using (Mutex mutex = new Mutex(false, "Global\\" + "RemindMe"))
            {
                if (!mutex.WaitOne(0, false)) //one instance of remindme already running                                 
                    return;

                // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.                
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                if (isMaterial)
                    Application.Run(new MaterialForm1());
                else
                    Application.Run(new Form1());
            }

        }

        /// <summary>
        /// Application_ThreadException handles most exceptions. However, some exceptions do not get handled there, and will still crash RemindMe. This prevents most of it.
        /// </summary>        
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            BLIO.Log("CurrentDomain_UnhandledException [ " + e.ExceptionObject.ToString() + " ]");

            Exception ex = (Exception)e.ExceptionObject;
            if (ex != null)
            {                
                BLIO.WriteError(ex, "Special CurrentDomain Error! " + ex.GetType());
                ShowError(ex, "Unknown error!", ex.Message);
                UCReminders.Instance.UpdateCurrentPage();
            }            
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        /// <summary>
        /// Show an RemindMe error popup
        /// </summary>
        /// <param name="ex">The exception that happened</param>
        /// <param name="message">An message that could decribe the error</param>
        /// <param name="description">NO LONGER BEING USED</param>
        private static void ShowError(Exception ex, string message, string description)
        {
            //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
            //that has an bunifu control in it(like a button), while there shouldn't be an exception.
            if (!(ex is System.Runtime.InteropServices.ExternalException) && ex.Source != "System.Drawing" && !ex.StackTrace.Contains("GDI+"))
            {
                BLIO.Log("\r\n=====EXCEPTION!!=====\r\n" + ex.GetType().ToString() + "\r\n" + ex.StackTrace + "\r\n");   

                if(isMaterial)
                    new MaterialExceptionPopup(ex,message).Show();
                else
                    new ExceptionPopup(ex, message).Show();
            }
           
        }

        //All uncaught exceptions will go here instead. We will replace the default windows popup with our own custom one and filter out what kind of exception is being thrown
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //Here we just filter out some type of exceptions and give different messages, at the bottom is the super Exception, which can be anything.   
            BLIO.Log("Application_ThreadException [ " + e.Exception + " ]");
            if (e.Exception is ReminderException)
            {
                ReminderException theException = (ReminderException)e.Exception;
                BLIO.WriteError(e.Exception, "Error with this reminder (" + theException.Reminder.Name + ") !", false);
                ShowError(e.Exception, "Reminder error!", theException.Message);
                UCReminders.Instance.UpdateCurrentPage();
            }
            else if (e.Exception is DbEntityValidationException)
            {
                Exception raise = (DbEntityValidationException)e.Exception;
                DbEntityValidationException ex = (DbEntityValidationException)e.Exception;
                foreach (var validationErrors in ex.EntityValidationErrors)
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
                BLIO.WriteError(raise, raise.Message, false);
                ShowError(e.Exception, e.Exception.GetType().ToString(), raise.Message);
            }
            else if (e.Exception is ArgumentException)
            {
                ArgumentException theException = (ArgumentException)e.Exception;
                BLIO.WriteError(theException, "Invalid argument.", false);
                ShowError(e.Exception, e.Exception.GetType().ToString(), theException.Message);
            }
            else if (e.Exception is DirectoryNotFoundException)
            {
                DirectoryNotFoundException theException = (DirectoryNotFoundException)e.Exception;
                BLIO.WriteError(theException, "Folder not found.", false);
                ShowError(e.Exception, e.Exception.GetType().ToString(), theException.Message);
            }

            else if (e.Exception is UnauthorizedAccessException)
            {
                UnauthorizedAccessException theException = (UnauthorizedAccessException)e.Exception;
                BLIO.WriteError(e.Exception, "Unauthorized!");
                ShowError(e.Exception, "Unauthorized!", "RemindMe is not authorized for this action.\r\nThis can be resolved by running RemindMe in administrator-mode.");
            }
                      
            else if (e.Exception is FileNotFoundException)
            {
                FileNotFoundException theException = (FileNotFoundException)e.Exception; //needs in instance to call .FileName
                BLIO.WriteError(theException, "Could not find the file located at \"" + theException.FileName, false);
                ShowError(e.Exception, "File not found.", "Could not find file \"" + theException.FileName + "\"\r\nHave you moved,renamed or deleted it?");
            }
          
            else if (e.Exception is System.Data.Entity.Core.EntityException || e.Exception is System.Data.Entity.Core.EntityCommandExecutionException)
            {
                BLIO.WriteError(e.Exception, "System.Data.Entity.Core exception", false);
                ShowError(e.Exception, "System.Data.Entity.Core.EntityException", "There was a problem executing SQL!");
            }

            else if (e.Exception is System.Runtime.InteropServices.COMException && e.Exception.Message.ToLower().Contains("database"))
            {
                BLIO.WriteError(e.Exception, "Database error.");
                ShowError(e.Exception, "System.Data.Entity.Core.EntityException", "There was a problem executing SQL!");
            }

            else if (e.Exception is ArgumentNullException)
            {
                BLIO.WriteError(e.Exception, "Null argument", false);
                ShowError(e.Exception, "Null argument", "Null argument exception! Whoops! this is not on your end!");
            }

            else if (e.Exception is NullReferenceException)
            {
                BLIO.WriteError(e.Exception, "Null reference", false);
                ShowError(e.Exception, "Null reference", "Null reference exception! Whoops! this is not on your end!");
            }

            else if (e.Exception.GetType().ToString() == "SQLiteException") //SQLiteException could not be found error, fkin weird
            {
                
                BLIO.WriteError(e.Exception, "SQLite Database exception", false);
                ShowError(e.Exception, "SQLite Database exception", "Remindme has encountered a database error!\r\nThis might or might not be on your end. It can be on your end if you modified the database file");
            }

            else if (e.Exception is PathTooLongException)
            {
                BLIO.WriteError(e.Exception, "The path to the file is too long.", false);
                ShowError(e.Exception, "File Path too long.", "The path to the file is too long!.");
            }

            else if (e.Exception is StackOverflowException)
            {
                BLIO.WriteError(e.Exception, "StackOverFlowException", false);
                ShowError(e.Exception, "StackOverFlowException", "RemindMe has encountered a stackoverflow! This is probably not your fault. Sorry!");
            }

            else if (e.Exception is OutOfMemoryException)
            {
                BLIO.WriteError(e.Exception, "Out of Memory", false);
                ShowError(e.Exception, "Out of Memory", "RemindMe is out of memory!");
            }
            else if (e.Exception is DbUpdateConcurrencyException)
            {
                BLIO.WriteError(e.Exception, "Database error.", false);
                ShowError(e.Exception, "Database error!", "Database error encountered!");
            }
            else if (e.Exception is IOException)
            {
                BLIO.WriteError(e.Exception, "IO Exception.");

                if(!e.Exception.StackTrace.Contains("UpdateFiles.zip"))
                    ShowError(e.Exception, "File error!", "RemindMe has encountered an IO issue.");
            }

            else if (e.Exception is Exception)
            {
                BLIO.WriteError(e.Exception, "Unknown exception in main.", false);
                ShowError(e.Exception, "Unknown", "Unknown exception in main.");
            }
            
        }
    }
}
