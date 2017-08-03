using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Import
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + "Import"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    if (args.Length > 0)
                    {//The user double-clicked an .remindme file while remindme is running!   

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1(args[0]));
                    }
                    //one instance of remindme already running                                        
                    return;
                }                
            }
        }
    }
}
