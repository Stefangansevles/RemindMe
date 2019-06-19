using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemindMe
{
    class RemindMeUpdater
    {
        private bool completed;        

        public void startDownload()
        {            
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();                
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("https://github.com/Stefangansevles/RemindMe/raw/master/SetupRemindMe.msi"), IOVariables.rootFolder + "SetupRemindMe.msi");
            });
            thread.Start();
        }        
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            completed = true;
        }
       
       public bool Completed
        {
            get { return completed; }
        }
    }
}
