﻿using Business_Logic_Layer;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class MaterialExceptionPopup : MaterialForm
    {
        private Exception exception;
        private string message;
        private bool customFeedback;
        private static int activePopups = 0;
        MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
        public MaterialExceptionPopup(Exception ex, string message = null)
        {                        
            if (activePopups < 3)
            {
                AddFont(Properties.Resources.Roboto_Medium);
                BLIO.Log("Constructing ExceptionPopup ( " + ex.GetType().ToString() + " )");
                activePopups++;
                skinManager.AddFormToManage(this);
                skinManager.ThemeChanged += SkinManager_ThemeChanged;
                InitializeComponent();

                this.exception = ex;
                this.message = message;

                lblMessage.MaximumSize = new Size((pnlContent.Width - lblText.Location.X) - 10, 50);

                //Set the location within the remindme window. 
                //This prompt can be moved, but inititally will be set to the middle of the location of RemindMe
                Form1 remindme = (Form1)Application.OpenForms["Form1"];
                if (remindme != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(remindme.Location.X + ((remindme.Width / 2) - this.Width / 2), remindme.Location.Y + ((remindme.Height / 2) - (this.Height / 2)));
                }

                if (!string.IsNullOrWhiteSpace(message))
                    lblMessage.Text = "Problem description: " + message;

                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;

                BLIO.Log("Constructing ExceptionPopup complete");
            }
            else
            {
                //There are 2 active popups already. Do not show another one! 

                this.Opacity = 0;
                this.ShowInTaskbar = false;

                InitializeComponent(); //so we can call the timer that disposes this form. Closing/disposing from the constructor is not possible

                BLIO.Log("IGNORE Popup(" + ex.GetType().ToString() + "). " + activePopups + " Popups active!");
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        private static uint cFonts = 0;
        private static void AddFont(byte[] fontdata)
        {
            int fontLength; System.IntPtr dataPointer;

            //We are going to need a pointer to the font data, so we are generating it here
            dataPointer = Marshal.AllocCoTaskMem(fontdata.Length);


            //Copying the fontdata into the memory designated by the pointer
            Marshal.Copy(fontdata, 0, dataPointer, (int)fontdata.Length);

            // Register the font with the system.
            AddFontMemResourceEx(dataPointer, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            //Keep track of how many fonts we've added.
            cFonts += 1;

            //Finally, we can actually add the font to our collection
            pfc.AddMemoryFont(dataPointer, (int)fontdata.Length);
        }

        private void SkinManager_ThemeChanged(object sender)
        {
            if (skinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                pbInfo.BackgroundImage = Properties.Resources.infoWhite;
            else
                pbInfo.BackgroundImage = Properties.Resources.infoDark;
        }

        private void ExceptionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string logTxtPath = IOVariables.systemLog;
                BLIO.Log("Closing ExceptionPopup...");
                if (!customFeedback) //If the user didn't leave instructions of how this problem happened, just log the exception / stacktrace and logfile
                {
                    
                }
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {                
                BLIO.Log("btnOk pressed on ExceptionPopup. textbox text = " + tbFeedback.Text);
                string logTxtPath = IOVariables.systemLog;
                string textBoxText = tbFeedback.Text; //Cant access tbNote in a thread. save the text in a variable instead

                if (string.IsNullOrWhiteSpace(textBoxText) || tbFeedback.ForeColor == Color.Gray)
                {
                    textBoxText = "NONE_SET";
                } 
                else
                {
                    MaterialMessageFormManager.MakeMessagePopup("Feedback sent.\r\nThank you for taking the time!", 5);
                }

                //Set this boolean to true so that when this popup closes, we won't try to add another db entry
                customFeedback = true;
                btnOk.Enabled = false;

                _ = CreateIssue(this.exception, this.message, textBoxText);

                this.Close();
                this.Dispose();
            }
            catch { }
        }
                
        private void tbFeedback_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFeedback.Text))
            {
                tbFeedback.Text = "If you can, please describe how this happened here...";
                tbFeedback.ForeColor = Color.Gray;
            }
        }

        private void tbFeedback_Enter(object sender, EventArgs e)
        {
            if (tbFeedback.ForeColor == Color.Gray & tbFeedback.Text == "If you can, please describe how this happened here...")
            {
                tbFeedback.Text = "";
                tbFeedback.ForeColor = Color.White;
            }
        }

        private void ExceptionPopup_Load(object sender, EventArgs e)
        {
            if (activePopups > 2)
            {
                BLIO.Log("[ExceptionPopup " + activePopups + "] ExceptionPopup_Load   closing form...");
                this.Close();
            }

            lblMessage.Font = new Font(pfc.Families[0], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            if (skinManager.Theme == MaterialSkin.MaterialSkinManager.Themes.DARK)
                pbInfo.BackgroundImage = Properties.Resources.infoWhite;            
        }
             
        private void MaterialExceptionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            activePopups--;
            skinManager.RemoveFormToManage(this);
        }

        private void lblMessage_SizeChanged(object sender, EventArgs e)
        {
            tbFeedback.Location = new Point(tbFeedback.Location.X, (lblMessage.Location.Y + lblMessage.Height) + 5);
        }

        private string GitHeader
        {
            get
            {
                string t = "Au", tt = "thorization";
                string x = "Be", xx = "arer ";
                string y = "";
                return "{\"" + t + tt + "\": \"" + x + xx + y + "\"}";                
            }
        }
        private async Task<bool> IssueExists(string title)
        {
            try
            {
                var response = (JArray)await BLIO.HttpRequest(
                    "GET",
                    "https://api.github.com/repos/Stefangansevles/Remindme/issues",
                    GitHeader,
                    "application/vnd.github+json",
                    "application/json"
                    );                
                                
                var issues = response.Values<JToken>().ToList();
                return issues.Where(iss => JsonConvert.ToString(iss.SelectToken("title").ToString()) == title).Count() > 0;
            }
            catch(Exception ex)
            {
                BLIO.WriteError(ex, "Failed to get GitHub issues");
                return false;
            }
        }
        private async Task<bool> CreateIssue(Exception ex, string description, string customMessage)
        {
            try
            {                
                string title = JsonConvert.ToString($"[Automatic] {(customMessage == "NONE_SET" ? "" : "[C]")} Error occured: {description} ({ex.GetType()})");                
                var exists = await IssueExists(title);
                if (!exists)
                {
                    BLIO.Log($"Creating Github issue for {title}");

                    BLIO.DumpLogTxt();
                    bool isMaterial = Convert.ToBoolean(BLLocalDatabase.Setting.Settings.MaterialDesign.Value);
                    string log = System.IO.File.ReadAllText(IOVariables.systemLog).Replace(Environment.NewLine, "<br />");
                    string body = JsonConvert.ToString($"**RemindMe version**: {IOVariables.RemindMeVersion} {(!isMaterial ? "(Old RemindMe)" : "")}<br /><br />**Stacktrace**: {ex.StackTrace}<br /><br />**Custom user feedback**: {customMessage}<br /><br />**RemindMe Log:**<br />{log}");

                    var resp = BLIO.HttpRequest(
                    "POST",
                    "https://api.github.com/repos/Stefangansevles/Remindme/issues",
                    GitHeader,
                    "application/vnd.github+json",
                    "application/json",
                    "{\r\n    \"title\": " + title + ",\r\n    \"body\":" + body + ",\r\n    \"labels\": [\r\n        \"bug\"\r\n    ], \"assignees\": [\r\n        \"Stefangansevles\"\r\n    ]\r\n}"
                    );
                    return resp != null;
                }

                return false;
            }
            catch(Exception cEx)
            {
                BLIO.WriteError(ex, $"Failed to create GitHub issue for {ex.GetType()} - {cEx}");
                return false;
            }
        }
    }
}
