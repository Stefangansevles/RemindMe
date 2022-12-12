using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Net;
using HtmlAgilityPack;
using System.Management;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using NAudio.Wave;
using System.Runtime.CompilerServices;

namespace Business_Logic_Layer
{
    public class BLIO
    {
        private static int noInternetNotLoggedCounter = 0;               
        public static List<string> systemLog = new List<string>();                
        private BLIO() { }       

        /// <summary>
        /// Log an entry to the system log
        /// </summary>
        /// <param name="entry"></param>
        public static void Log(string entry)
        {
            if (systemLog.Count > 0 && systemLog[systemLog.Count - 1] == "No internet access!") //Let's not spam "no internet access" if there is no internet access
            {
                noInternetNotLoggedCounter++;
                return;
            }
            else
            {
                if (noInternetNotLoggedCounter > 0)
                {
                    systemLog.Add(noInternetNotLoggedCounter + " \"No internet access\" messages blocked");                    
                    noInternetNotLoggedCounter = 0; //reset
                }
            }
                                              
            systemLog.Add("[" + DateTime.Now.ToString() + "]  " + entry);
        }

        public static string LastLogMessage
        {
            get { return systemLog[systemLog.Count - 1]; }
        }

        /// <summary>
        /// Checks for internet connectivity
        /// </summary>
        /// <returns>True if you have internet access, false if not</returns>
        public static bool HasInternetAccess()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                Log("No internet access!");
                return false;
            }
        }
        public static WaveOut CurrentReader {get;set;}

        public static void StopSound()
        {
            try
            {
                if (CurrentReader != null)
                {
                    CurrentReader.Stop();
                    CurrentReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex, "Stopping sound file failed?");
            }
        }

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="path">Path to the audio file</param>
        /// <param name="volume">Volume level 0-100</param>
        /// <returns>Returns the duration of the audio file in miliseconds</returns>
        public static int PlaySound(string path, int volume = 100)
        {            
            var waveOut = new WaveOut();
            try
            {
                var reader = new AudioFileReader(path);
                int duration = (int)reader.TotalTime.TotalMilliseconds;
                waveOut.Init(reader);
                CurrentReader = waveOut;

                Log("Playing sound... (MUCNewReminder)");                
                waveOut.Volume = (float)(volume / 100m); //nAudio expects 0.0 - 1.0
                waveOut.Play();                

                return duration;
            }
            catch(Exception ex)
            {
                WriteError(ex, $"Playing sound file {path} failed. Sound file Exists = {File.Exists(path)}");
                return -1;
            }                                   
        }

        /// <summary>
        /// Writes the system log to a .txt file
        /// </summary>
        /// <returns></returns>
        public static int DumpLogTxt()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(IOVariables.systemLog));

                File.WriteAllText(IOVariables.systemLog, ""); //Clear log

                using (FileStream fs = new FileStream(IOVariables.systemLog, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs)) //Write log
                    {
                        foreach (string line in systemLog)
                            sw.WriteLine(line);
                    }
                }
                return systemLog.Count;
            }
            catch (Exception ex)
            {
                systemLog.Add("[" + DateTime.Now.ToString() + "]  BLIO.DumpLogTxt() FAILED  -> " + ex.GetType().ToString());
                return -1;
            }
        }
        
        
        /// <summary>
        /// Creates the folders and files needed by RemindMe. This should only occur once, during first use.
        /// </summary>
        public static void CreateSettings()
        {                        
            Directory.CreateDirectory(IOVariables.rootFolder);            
        }        
        /// <summary>
        /// If the user deleted the .db file, or if the user is using RemindMe for the first time, this method created the neccesary database + tables.
        /// </summary>
        public static void CreateDatabaseIfNotExist()
        {
            if (!System.IO.File.Exists(IOVariables.databaseFile))            
                DLDatabase.CreateDatabase();            
            else
            {
                //great! the .db file exists. Now lets check if the user's .db file is up-to-date. let's see if the reminder table has all the required columns.
                if (DLDatabase.HasAllTables())
                {
                    if (!DLDatabase.HasAllColumns())
                        DLDatabase.InsertNewColumns(); //not up to date. insert !
                }
                else
                {
                    DLDatabase.InsertMissingTables();
                    //re-run the method, since the .db file **should** now have all the tables.
                    CreateDatabaseIfNotExist();
                }
                                
            }

            
        }

        /// <summary>
        /// Creates a batch file, puts the batch script into the file and runs it.
        /// </summary>
        /// <param name="batch">The batch script you want to execute</param>
        public static void ExecuteBatch(string batch)
        {
            if (!Directory.Exists(Path.GetDirectoryName(IOVariables.batchFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(IOVariables.batchFile));

            using (StreamWriter wr = new StreamWriter(IOVariables.batchFile))
            {
                wr.Write("@echo **Executing advanced reminder script (RemindMe)**\r\n\r\n" + batch);
            }

            if(!File.Exists(IOVariables.batchFile))
                throw new FileNotFoundException("Could not found the file neccesary to execute a batch script");

            System.Diagnostics.Process.Start(IOVariables.batchFile);
        }

      
        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message, [CallerMemberName] string caller = null)
        {
            //The bunifu framework makes a better looking ui, but it also throws annoying null reference exceptions when disposing an form/usercontrol
            //that has an bunifu control in it(like a button), while there shouldn't be an exception.
            if ((ex is System.Runtime.InteropServices.ExternalException) && ex.Source == "System.Drawing" && ex.Message.Contains("GDI+"))
                return;


            Log($"Function {caller} failed! - {message} - {ex.GetType()} - Stacktrace: {ex}");

            using (FileStream fs = new FileStream(IOVariables.errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
            }
        }

        public static async Task<JObject> HttpRequest(string method, string uri, string headers = "{ }", string accept = "", string contentType = "", string body = "{ }")
        {
            try
            {
                Log("Starting " + method + " for " + uri);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;                
                request.Method = method;

                if (!string.IsNullOrWhiteSpace(accept))
                    request.Accept = accept;

                if (!string.IsNullOrWhiteSpace(contentType))
                    request.ContentType = contentType;

                //Parse user-input headers into JSON
                JObject jsonHeaders = JObject.Parse(headers);

                //Initialize collection
                WebHeaderCollection headerCollection = new WebHeaderCollection();                
                foreach (var header in jsonHeaders)
                {
                    if (!WebHeaderCollection.IsRestricted(header.Key))
                        headerCollection.Add(header.Key, header.Value.ToString());
                    else
                        Log("Detected restricted header " + header.Key);
                }

                //Set the headers
                request.Headers = headerCollection;
                request.UserAgent = "RemindMe-application";

                if (method == "POST")
                {
                    //Add Body
                    byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                    request.ContentLength = bodyBytes.Length;                    
                    using (var dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(bodyBytes, 0, bodyBytes.Length);
                    }
                }               

                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
                    {
                        string bod = await reader.ReadToEndAsync();
                        Log(method + " succeeded with status code " + response.StatusCode.ToString());
                        return (JObject)JsonConvert.DeserializeObject(bod);
                    }
                    else
                    {
                        Log(method + " Failed with status code " + response.StatusCode.ToString());
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(method + " [ " + uri + " ] Failed! Exception " + ex.GetType().ToString() + " - " + ex.ToString());
                return null;
            }
        }             
    }
}
