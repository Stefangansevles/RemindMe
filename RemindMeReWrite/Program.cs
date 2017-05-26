using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;

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

        //All exceptions will go here instead. We will replace the default windows popup with our own custom one
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            BLIO.WriteError(e.Exception, "Exception in main.", true);
        }
    }
}
