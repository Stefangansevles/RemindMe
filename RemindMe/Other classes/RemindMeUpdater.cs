using Business_Logic_Layer;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// This class handles updating RemindMe.
    /// </summary>
    ///     
    class RemindMeUpdater
    {
        private bool extractCompleted = false;
        private static bool restartRemindMe = false;
        private bool hasUpdated = false;

        public void UpdateRemindMe() //This is called within a Thread
        {
            try
            {
                //Don't do anything without internet
                if (hasUpdated || !BLIO.HasInternetAccess())
                    return;

                if (GetGithubVersion() > new Version(IOVariables.RemindMeVersion))
                {
                    BLIO.Log("New version of RemindMe on Github! Starting UpdateRemindMe()...");
                    DateTime dateNow = DateTime.UtcNow;
                    //Download the updated files
                    DownloadFile("https://github.com/Stefangansevles/RemindMe/raw/master/Update/UpdateFiles.zip", IOVariables.rootFolder + "UpdateFiles.zip");

                    ZipFile zip = new ZipFile(IOVariables.rootFolder + "UpdateFiles.zip");
                    
                    if (zip == null || !ZipFile.IsZipFile(IOVariables.rootFolder + "UpdateFiles.zip"))
                    {
                        BLIO.Log("UpdateRemindMe ABORTED. Zip is null or invalid.");
                        return;
                    }

                    try
                    {
                        BLIO.Log("UpdateFiles.zip contains files for a new RemindMe version!");

                        //First, move the running files into an /old/ directory
                        MoveOldFiles();                        

                        //Now, move those updates files into the application directory, so that when the program starts the next time, RemindMe is updated! :)
                        zip.ExtractProgress += Zip_ExtractProgress;
                        BLIO.Log("Extracting zip...");
                        zip.ExtractAll(IOVariables.applicationFilesFolder, ExtractExistingFileAction.OverwriteSilently);

                        while (!extractCompleted) { } //Busy waiting, but we're in a thread anyway
                        BLIO.Log("UpdateRemindMe() took: " + (long)(DateTime.UtcNow - dateNow).TotalMilliseconds + " ms");

                        BLIO.Log("Attempting to remove UpdateFiles.zip...");
                        try { File.Delete(IOVariables.rootFolder + "UpdateFiles.zip"); } catch { }

                        if (restartRemindMe && ( (Form1.Instance != null && Form1.Instance.Opacity == 0) || (MaterialForm1.Instance != null && MaterialForm1.Instance.Opacity == 0) ))
                        {
                            BLIO.Log("Restarting RemindMe...");

                            if (MaterialForm1.Instance != null)
                                MaterialForm1.Instance.shouldClose = true;

                            Application.Restart();
                        }
                        else
                        {
                            BLIO.Log("Installation complete! restartRemindMe = " + restartRemindMe);
                            if(Form1.Instance != null)
                                Form1.Instance.restartRemindMeUpdateToolStripMenuItem.Visible = true; 
                            else
                                MaterialForm1.Instance.restartRemindMeUpdateToolStripMenuItem1.Visible = true; 
                        }

                        hasUpdated = true;
                    }
                    catch (Exception ex) //do rollback
                    {
                        BLIO.Log("Something went wrong during extraction in UpdateRemindMe(). Exception: " + ex.GetType().ToString()+ "\r\nDoing rollback...");

                        //Roll the files in /old/ back to the original folder
                        foreach (string fl in Directory.GetFiles(IOVariables.applicationFilesFolder + "\\old"))
                        {
                            if (File.Exists(IOVariables.applicationFilesFolder + Path.GetFileName(fl)))
                            {
                                BLIO.Log(" - Deleting file: " + Path.GetFileName(fl));
                                File.Delete(IOVariables.applicationFilesFolder + Path.GetFileName(fl));
                            }

                            BLIO.Log(" - Restoring /old file: " + Path.GetFileName(fl));
                            File.Move(fl, IOVariables.applicationFilesFolder + Path.GetFileName(fl));
                        }
                        //Delete the /old
                        BLIO.Log("Deleting directory /old");
                        Directory.Delete(IOVariables.applicationFilesFolder + "\\old");
                    }                    
                }
                else if (BLIO.LastLogMessage != null && !BLIO.LastLogMessage.Contains("Updating user"))
                    BLIO.Log("No new version of RemindMe on Github.");
            }
            catch (Exception ex)
            {
                BLIO.Log("First part of UpdateRemindMe failed. Exception: " + ex.GetType().ToString());
            }
        }

        private void Zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {            
            extractCompleted = (e.BytesTransferred == e.TotalBytesToTransfer);

            if (extractCompleted)
                BLIO.Log("[Zip_ExtractProgress]   Zip extract completed.");
        }

        /// <summary>
        /// Moves the currently running RemindMe files (.dll, .exe etc) into an /old/ folder. Then, the application folder is empty.
        /// </summary>
        private void MoveOldFiles()
        {
            BLIO.Log("Moving old installation files...");

            //Create the old folder if it doesnt exist
            Directory.CreateDirectory(IOVariables.applicationFilesFolder + "\\old");

            //Loop through each .dll/.exe etc file
            foreach (string fl in Directory.GetFiles(IOVariables.applicationFilesFolder))
            {
                if (Path.GetExtension(fl) != ".config") //Don't do anything with the config
                {
                    BLIO.Log(" - Moving file: " + Path.GetFileName(fl));
                    File.Move(fl, IOVariables.applicationFilesFolder + "\\old\\" + Path.GetFileName(fl));                    
                }
            }

            BLIO.Log("Done moving old files!");
        }

        public static Version GetGithubVersion()
        {
            try
            {                                        
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                if (BLIO.LastLogMessage != null && !BLIO.LastLogMessage.Contains("Updating user"))
                    BLIO.Log("Starting the process of checking the live version on github...");

                List<string> lines = new List<string>();

                string html;
                using (var client = new WebClient())
                {
                    html = client.DownloadString("https://raw.githubusercontent.com/Stefangansevles/RemindMe/master/Update/version.txt");
                    lines = html.Split(new[] { "\n" }, StringSplitOptions.None).ToList();
                }

                if (lines.Count > 0 && (BLIO.LastLogMessage != null &&  !BLIO.LastLogMessage.Contains("Updating user")) )
                    BLIO.Log("Sucessfully loaded raw version.txt from github");

                //Minor = dont need to restart RemindMe immediately, Major = restart.                    
                restartRemindMe = (lines.Count >= 2 && lines[1].ToLower().Contains("major")); 

                if (Form1.Instance != null && lines.Count >= 3 && lines[2].ToLower().Contains("true")) //true = silent update, the user won't be aware of an update
                    UCReminders.Instance.showUpdateMessage = false;
                else if(MaterialForm1.Instance != null && lines.Count >= 3 && lines[2].ToLower().Contains("true"))
                    MUCReminders.Instance.showUpdateMessage = false;

                return new Version(lines[0]);                
            }
            catch (Exception ex)
            {
                BLIO.Log("BLIO.GetGithubVersion() failed: " + ex.ToString());
            }
            return null;
        }

        //Downloading files - - - - - - - - - - - 
        private void DownloadFile(string sourceUrl, string targetFolder)
        {            
            //"The request was aborted: Could not create SSL/TLS secure channel." fix: 
            //https://stackoverflow.com/questions/2859790/the-request-was-aborted-could-not-create-ssl-tls-secure-channel
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            BLIO.Log("Attempting to download UpdateFiles.zip ...");
            WebClient downloader = new WebClient();
            // fake as if you are a browser making the request.
            downloader.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
            downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
            downloader.DownloadProgressChanged +=
                new DownloadProgressChangedEventHandler(Downloader_DownloadProgressChanged);
            downloader.DownloadFileAsync(new Uri(sourceUrl), targetFolder);
            // wait for the current thread to complete, since the an async action will be on a new thread.
            while (downloader.IsBusy) { }
        }

        private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }

        private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // display completion status.
            if (e.Error != null)
                BLIO.Log("[Downloader_DownloadFileCompleted]   " + e.Error.Message);
            else            
                BLIO.Log("[Downloader_DownloadFileCompleted]  Download of UpdateFiles.zip Completed.");                            
        }
    }
}
