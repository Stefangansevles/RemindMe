using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    /// <summary>
    /// Manages the RemindMeMaterialMessageForm. Keeps track of active message forms and has methods
    /// </summary>
    public class MaterialMessageFormManager
    {
        //Keep track of all popupforms. There should only be one at a time, but if two are visible, the second one should be on top of the other one
        private static List<RemindMeMaterialMessageForm> popupForms = new List<RemindMeMaterialMessageForm>();
        private MaterialMessageFormManager() { }


        /// <summary>
        /// makes the popup that shows howmany reminders are set for today
        /// </summary>
        public static void MakeTodaysRemindersPopup()
        {
            int reminderCount = BLReminder.GetTodaysReminders().Count;
            if (BLLocalDatabase.Setting.IsReminderCountPopupEnabled())
            {
                if (reminderCount > 0)
                    MakeMessagePopup("You have " + reminderCount + " Reminder(s) set for today.", 3);
                else
                    MakeMessagePopup("You have no reminders set for today.", 3);
            }

        }
        public static Point? NextAvailableSpace
        {
            get
            {
                if (popupForms.Count > 0)
                    return new Point(popupForms[popupForms.Count - 1].Location.X, popupForms[popupForms.Count - 1].Location.Y);
                else
                    return null;
            }
        }
        /// <summary>
        /// Creates an animated message popup at the bottom-right corner of the screen
        /// </summary>
        /// <param name="message">The message this form should display</param>
        /// <param name="popDelay">The time this form will be visible in seconds</param>
        public static void MakeMessagePopup(string message, int popDelay, string title = "")
        {
            RemindMeMaterialMessageForm popupForm = new RemindMeMaterialMessageForm(message, popDelay);
            MaterialForm1.MaterialSkinManager.AddFormToManage(popupForm);
            if (title != "")
                popupForm.Title = title;

            popupForm.Invoke((MethodInvoker)(() =>
            {
                popupForm.Show();
            }));
            popupForms.Add(popupForm); //Add the popupform            
        }
       

        /// <summary>
        /// Creates an animated message popup at the bottom-right corner of the screen
        /// </summary>
        /// <param name="message">The message this form should display</param>
        /// <param name="popDelay">The time this form will be visible in seconds</param>
        /// <param name="rem">The reminder that is in this message popup. Gives the user the option to disable it</param>
        public static void MakeMessagePopup(string message, int popDelay, Reminder rem)
        {
            RemindMeMaterialMessageForm popupForm = new RemindMeMaterialMessageForm(message, popDelay, rem);
            popupForm.Show();

            popupForms.Add(popupForm); //Add the popupform            
        }

        /// <summary>
        /// Get all currently visible popupforms. Usually there will be none.
        /// </summary>
        /// <returns></returns>
        public static List<RemindMeMaterialMessageForm> PopupForms
        {
            get { return popupForms.Where(frm => !frm.IsClosed).ToList(); }
        }

        /// <summary>
        /// Reposition every (active) RemindMeMaterialMessageForms so that if the first(on the bottom) form disposes, the other forms should go down.
        /// </summary>
        public static void RepositionActivePopups()
        {
            int activeFormCount = PopupForms.Count;

            //One active popup form? set it to default position
            if (activeFormCount == 1)
            {
                //Set the location to the bottom right corner of the user's screen and a little bit above the taskbar since there's only one left
                RemindMeMaterialMessageForm form = PopupForms[0];
                try
                {
                    form.Invoke((MethodInvoker)(() =>
                    {
                        form.Location = new Point(Screen.GetWorkingArea(form).Width - form.Width - 5, Screen.GetWorkingArea(form).Height - form.Height - 5);
                    }));
                }
                catch
                {
                    form.IsClosed = true;
                    form.Dispose();
                }

            }
            else
            {
                List<RemindMeMaterialMessageForm> forms = popupForms.Where(f => !f.IsClosed).ToList();

                //Reset all forms to the bottom right corner
                foreach (RemindMeMaterialMessageForm frm in forms)
                {
                    if (frm.IsDisposed)
                        frm.IsClosed = true;
                    else
                        frm.Location = new Point(Screen.GetWorkingArea(frm).Width - frm.Width - 5, Screen.GetWorkingArea(frm).Height - frm.Height - 5);
                }

                RemindMeMaterialMessageForm form;
                //Now work our way up
                for (int i = 0; i < forms.Count; i++)
                {
                    form = forms[i];
                    if (i > 0)
                        form.Location = new Point(form.Location.X, (forms[i - 1].Location.Y - form.Height) - 5);
                }
            }


            //Lets just clear the disposed forms
            List<RemindMeMaterialMessageForm> toRemoveForms = popupForms.Where(form => form.IsClosed).ToList();

            foreach (RemindMeMaterialMessageForm form in toRemoveForms)
                popupForms.Remove(form);
        }

    }



}

