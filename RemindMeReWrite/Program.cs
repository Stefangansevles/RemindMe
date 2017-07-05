using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;
using System.Data.SQLite;
using System.IO;

namespace RemindMe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + "RemindMe"))
            {
                if (!mutex.WaitOne(0, false))
                {                    
                    //one instance of remindme already running                                        
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new Form1());
            }    
        }

        //All uncaught exceptions will go here instead. We will replace the default windows popup with our own custom one and filter out what kind of exception is being thrown
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {         
            //Here we just filter out some type of exceptions and give different messages, at the bottom is the super Exception, which can be anything.              
            if(e.Exception is FileNotFoundException)
            {
                FileNotFoundException theException = (FileNotFoundException)e.Exception; //needs in instance to call .FileName
                BLIO.WriteError(theException, "File not found.","Could not find the file located at \"" + theException.FileName + "\"\r\nHave you moved,renamed or deleted the file?" , true);                
            }            
            else if(e.Exception is SQLiteException)            
                BLIO.WriteError(e.Exception, "SQLite Database exception","Remindme has encountered a database error!\r\nThis might or might not be on your end. It can be on your end if you modified the database file", true);            

            else if (e.Exception is PathTooLongException)            
                BLIO.WriteError(e.Exception, "File Path too long.","The path to the file is too long!.", true);            

            else if (e.Exception is StackOverflowException)            
                BLIO.WriteError(e.Exception, "StackOverFlowException","RemindMe has encountered a stackoverflow! This is probably not your fault. Sorry!", true);            

            else if (e.Exception is OutOfMemoryException)            
                BLIO.WriteError(e.Exception, "Out of Memory","RemindMe is out of memory!", true);            

            else if(e.Exception is Exception)            
                BLIO.WriteError(e.Exception, "Unknown","Unknown exception in main.", true);                          
            
        }
    }
}
