using Business_Logic_Layer;
using Database.Entity;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class RemindMeMaterialMessageForm : MaterialForm
    {
        private int timeout = 0;
        private int secondsPassed = 0;
        private bool disableFadeout = false;
        //If this message form created a .showDialog(), the showdialog will return after this form disposes. So, Don't dispose after timeout
        private bool isDialog = false;

        private Reminder theReminder = null;
        private bool closed = false;
        private Point location;
        public RemindMeMaterialMessageForm(string message, int timeout)
        {
            BLIO.Log("Constructing RemindMeMessageForm (" + message + ")");
            this.StatusBarHeight = 0;            
            InitializeComponent();                        

            //Not visible                   
            this.Opacity = 0.0;

            AddFont(Properties.Resources.Roboto_Medium);
            
            lblText.Font = new Font(pfc.Families[0], 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            lblExit.Font = new Font(pfc.Families[0], 15f, FontStyle.Bold, GraphicsUnit.Pixel);            

            //Make it so that the text won't go out of bounds horizontally, so the panel has to grow vertically
            lblText.MaximumSize = new Size(pnlText.Width - 15, 0);
            //Set the text
            lblText.Text = message;
            //Enlarge the panel if needed
            FitPanel(pnlText);


            SetLocation();

            this.LocationChanged += RemindMeMaterialMessageForm_PositionChanged;
            this.timeout = timeout;

            //If the timeout in seconds is "0", don't make the form dissapear at all
            disableFadeout = timeout == 0;

            //Start the timer that will "slowly" make the form more transparent
            tmrFadein.Start();
            pnlText.Focus();

            BLIO.Log("RemindMeMessageForm constructed");
        }

        private void SetLocation()
        {
            //No active popup forms? set it to default position
            if (MaterialMessageFormManager.PopupForms.Count == 0)
            {
                //Set the location to the bottom right corner of the user's screen and a little bit above the taskbar    
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, Screen.GetWorkingArea(this).Height - this.Height - 5);
                location = this.Location;
            }
            else
            {
                int alreadyActiveFormCount = MaterialMessageFormManager.PopupForms.Count;
                //Set the location to the bottom right corner of the user's screen, and above all other active popups
                //this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, Screen.GetWorkingArea(this).Height - (this.Height * (alreadyActiveFormCount + 1)) - ((alreadyActiveFormCount + 1) * 5));
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, (MaterialMessageFormManager.NextAvailableSpace.Value.Y - this.Height) - 5);
                location = this.Location;
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

        private void RemindMeMaterialMessageForm_PositionChanged(object sender, EventArgs e)
        {
            if (this.Location.X != location.X) //user moved? grr
                this.Location = location;
        }

        public Point FormLocation
        {
            get { return location; }
            set { location = value; }
        }
        public RemindMeMaterialMessageForm(string message, int timeout, Reminder rem) : this(message, timeout)
        {
            //If this RemindMeMessageForm is created with an Reminder object, supply reminder options
            pnlReminderOptions.Visible = true;
            theReminder = rem;


            if (!BLReminder.IsRepeatableReminder(rem))
            {
                btnSkip.Enabled = false;
                btnSkip.Cursor = Cursors.Default;
            }


        }

        public bool IsClosed
        {
            get { return closed; }
            set { closed = value; }
        }
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        

        private void FitPanel(Panel pnl)
        {
            int maxright = 0;
            int maxbottom = 0;
            foreach (Control ctl in pnl.Controls)
            {
                maxright = (ctl.Right > maxright ? ctl.Right : maxright);
                maxbottom = (ctl.Bottom > maxbottom ? ctl.Bottom : maxbottom);
            }
            int deltabottom = pnl.Bottom - (pnl.Top + maxbottom);
            int deltaright = pnl.Right - (pnl.Left + maxright);
            Form frm = pnl.FindForm();
            frm.SuspendLayout();

            if (frm.Height - deltabottom > frm.Height) //Dont shrink, only enlarge
            {
                frm.Height = frm.Height - deltabottom;
                frm.Height += 10; //Enlarge it just a little bit more to make it look better
            }

            if (frm.Width - deltaright > frm.Width)     //Dont shrink, only enlarge
                frm.Width = frm.Width - deltaright;

            frm.ResumeLayout();


            //pnlText is docked to bottom, if the form increases, the panel doesnt cover the header-bar anymore, so keep increasing it until the location
            //is back at 23
            int sizeToCheck = 0;
            if (theReminder != null)
                sizeToCheck = 17;
            else
                sizeToCheck = 17 + pnlReminderOptions.Height - 10;

            while (pnlText.Location.Y > sizeToCheck)
            {
                pnlText.Size = new Size(pnlText.Size.Width, pnlText.Size.Height + 1);
            }
            lblText.Location = new Point(9, 9);
        }

        private void tmrFadein_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.02;
            if (this.Opacity >= 1)
            {
                tmrFadein.Stop();

                if (!disableFadeout)
                    tmrTimeout.Start();
            }
            if (this.Bounds.Contains(MousePosition))
            {
                tmrFadein.Stop();

                if (!disableFadeout)
                    tmrTimeout.Start();

                this.Opacity = 1;
                secondsPassed = 0;
            }
        }

        private void tmrFadeout_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(MousePosition)) //Cursor in the message? reset opacity to 1 and restart timeout timer
            {
                this.Opacity = 1;
                secondsPassed = 0;

                if (!disableFadeout)
                    tmrTimeout.Start();
            }
            else //Cursor out of the message? safely reduce opacity "slowly"
            {
                this.Opacity -= 0.02;
                if (this.Opacity <= 0)
                {
                    tmrFadeout.Stop();

                    tmrFadein.Dispose();
                    tmrFadeout.Dispose();
                    tmrTimeout.Dispose();


                    if (!isDialog)
                    {
                        this.Close();
                        this.Dispose();
                        BLIO.Log("Message form (" + lblText.Text + ") disposed.");
                        MaterialMessageFormManager.RepositionActivePopups();
                    }
                    else
                        BLIO.Log("Message form (" + lblText.Text + ") NOT disposed. Form created dialog.");


                }
            }

        }

        private void tmrTimeout_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(MousePosition))
            {
                secondsPassed = 0;
            }
            else
            {
                secondsPassed++;

                if (secondsPassed >= timeout)
                {
                    tmrTimeout.Stop();
                    secondsPassed = 0;
                    tmrFadeout.Start();
                }
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            ///this.CreateHandle
            this.Close();
            this.Dispose();
            MaterialMessageFormManager.RepositionActivePopups();
        }
        

        private void RemindMeMessageForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            this.TopLevel = true;
            pnlText.Focus();
                       
            timer1.Start();
        }



        private void btnSkip_Click(object sender, EventArgs e)
        {
            //The reminder object has now been altered. The first date has been removed and has been "skipped" to it's next date
            BLReminder.SkipToNextReminderDate(theReminder);
            BLIO.Log("Skipped reminder with id " + theReminder.Id + " to it's next date from the RemindMe message form");
            //push the altered reminder to the database 
            BLReminder.EditReminder(theReminder);
            BLIO.Log("Edited reminder with id " + theReminder.Id);
            //Show the change in RemindMe's main listview
            MUCReminders.Instance.UpdateCurrentPage();
            //Finally, close this message            
            this.Close();
            this.Dispose();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            theReminder.Enabled = 0;                                   //Set the enabled flag of this reminder to false
            BLReminder.EditReminder(theReminder);                      //Push the edited reminder to the database                            
            MUCReminders.Instance.UpdateCurrentPage();             //Show the change in RemindMe's main listview
            BLIO.Log("Reminder with id" + theReminder.Id + " Disabled from the RemindMe message form");
            this.Close();
            this.Dispose();
        }




        private void btnPostpone_Click(object sender, EventArgs e)
        {
            BLIO.Log("RemindMeMessageForm option clicked: Postpone (" + theReminder.Id + ")");
            isDialog = true;
            int minutes = MaterialRemindMePrompt.ShowMinutes("Select your postpone time", "(in minutes or in xhxxm format (1h20m) )");

            if (minutes <= 0)
            {
                BLIO.Log("Postponing reminder with " + minutes + " minutes DENIED.");
                return;
            }

            if (theReminder.PostponeDate == null)//No postpone yet, create it
                theReminder.PostponeDate = Convert.ToDateTime(theReminder.Date.Split(',')[0]).AddMinutes(minutes).ToShortDateString() + " " + Convert.ToDateTime(theReminder.Date.Split(',')[0]).AddMinutes(minutes).ToShortTimeString();
            else//Already a postponedate, add the time to that date                
                theReminder.PostponeDate = Convert.ToDateTime(theReminder.PostponeDate).AddMinutes(minutes).ToShortDateString() + " " + Convert.ToDateTime(theReminder.PostponeDate).AddMinutes(minutes).ToShortTimeString();

            BLReminder.EditReminder(theReminder);//Push changes

            MUCReminders.Instance.UpdateCurrentPage();

            new Thread(() =>
            {
                //Log an entry to the database, for data!                                
                try
                {
                    BLOnlineDatabase.PostponeCount++;
                }
                catch (ArgumentException ex)
                {
                    BLIO.Log("Exception at BLOnlineDatabase.PostponeCount++. -> " + ex.Message);
                    BLIO.WriteError(ex, ex.Message, true);
                }
            }).Start();

            this.Close();
            this.Dispose();
        }


        private void RemindMeMaterialMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaterialForm1.MaterialSkinManager.RemoveFormToManage(this);

            closed = true;
            MaterialMessageFormManager.RepositionActivePopups();
        }

        private void lblText_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {                        
            lblExit.BackColor = Color.Transparent;                    
        }

        private void pnlReminderOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlReminderOptions.Visible)
            {
                this.Size = new Size(this.Size.Width, this.Size.Height + pnlReminderOptions.Size.Height);
                SetLocation();
            }
        }
    }
}

