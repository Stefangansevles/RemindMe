using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Business_Logic_Layer;
using System.Threading;

namespace RemindMe
{
    public partial class MUCDebugMode : UserControl
    {
        List<string> localCacheList = new List<string>();
        public MUCDebugMode()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "Initialization of MUCDebugMode failed!");
            }
        }


        private void btnOpenErrorPrompt_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnOpenErrorPrompt_Click");
            //string text = MaterialRemindMePrompt.ShowText("Enter a message");
            //MaterialExceptionPopup pop = new MaterialExceptionPopup(new ReminderException("Test", null), text);
            //pop.Show();
        }

        private void btnAppdataFolder_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnAppdataFolder_Click");
            Process.Start(Path.GetDirectoryName(IOVariables.errorLog));
        }

        private void tmrDetails_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
                SetMemory();
        }

        private void MUCDebugMode_Load(object sender, EventArgs e)
        {
            try
            {
                tmrDetails.Start();
                tmrLog.Start();
                localCacheList.AddRange(BLIO.systemLog);
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "MUCDebugMode Load failed!");
            }
        }

        /// <summary>
        /// Returns memory usage
        /// </summary>
        /// <returns></returns>
        private void SetMemory()
        {
            new Thread(() =>
            {
                PerformanceCounter pc = new PerformanceCounter();
                pc.CategoryName = "Process";
                pc.CounterName = "Working Set - Private";
                pc.InstanceName = Process.GetCurrentProcess().ProcessName;

                lblMemoryUsage.Invoke((MethodInvoker)(() =>
                {
                    lblMemoryUsage.Text = "Memory: " + (Convert.ToInt32(pc.NextValue()) / (int)(1024)) / 1000 + " Mb";
                }));

            }).Start();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string text = MaterialRemindMePrompt.ShowText("Enter a message");
            
            if (!string.IsNullOrWhiteSpace(text))
                MaterialMessageFormManager.MakeMessagePopup(text, 11);
            else
                MaterialMessageFormManager.MakeMessagePopup("This is a test.", 4);
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (localCacheList.Count != BLIO.systemLog.Count)
                {//todo: append from localcachelist index, systemlog[i]
                    tbSystemLog.Clear();
                    tbSystemLog.AppendText(string.Join(Environment.NewLine, BLIO.systemLog));

                    localCacheList.Clear();
                    localCacheList.AddRange(BLIO.systemLog);
                }
            }
        }

        private void MUCDebugMode_VisibleChanged(object sender, EventArgs e)
        {
            BLIO.Log("Showing debug mode");
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            BLIO.Log("btnCheckUpdate_Click");
            new RemindMeUpdater().UpdateRemindMe();
        }

        private void btnRequery_Click(object sender, EventArgs e)
        {
            //Copy the contents of the textbox to the system clipboard                  
            Clipboard.SetText(tbSystemLog.Text);
            BLIO.Log("Copied system log to clipboard");
        }
    }
}
