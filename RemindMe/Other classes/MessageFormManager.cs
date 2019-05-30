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
    /// Manages the RemindMeMessageForm. Keeps track of active message forms and has methods
    /// </summary>
    public class MessageFormManager
    {
        //Keep track of all popupforms. There should only be one at a time, but if two are visible, the second one should be on top of the other one
        private static List<RemindMeMessageForm> popupForms = new List<RemindMeMessageForm>();
        private MessageFormManager() { }


        /// <summary>
        /// makes the popup that shows howmany reminders are set for today
        /// </summary>
        public static void MakeTodaysRemindersPopup()
        {
            int reminderCount = BLReminder.GetTodaysReminders().Count;
            if (BLSettings.IsReminderCountPopupEnabled())
            {
                if (reminderCount > 0)
                    MakeMessagePopup("You have " + reminderCount + " Reminder(s) set for today.", 3);
                else
                    MakeMessagePopup("You have no reminders set for today.", 3);
            }

        }

        /// <summary>
        /// Creates an animated message popup at the bottom-right corner of the screen
        /// </summary>
        /// <param name="message">The message this form should display</param>
        /// <param name="popDelay">The time this form will be visible in seconds</param>
        public static void MakeMessagePopup(string message, int popDelay)
        {
            RemindMeMessageForm popupForm = new RemindMeMessageForm(message, popDelay);
            popupForm.Show();

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
            RemindMeMessageForm popupForm = new RemindMeMessageForm(message, popDelay, rem);
            popupForm.Show();

            popupForms.Add(popupForm); //Add the popupform            
        }

        /// <summary>
        /// Get all currently visible popupforms. Usually there will be none.
        /// </summary>
        /// <returns></returns>
        public static List<RemindMeMessageForm> GetPopupforms()
        {
            return popupForms.Where(frm => !frm.IsDisposed).ToList();
        }

        /// <summary>
        /// Reposition every (active) RemindMeMessageForms so that if the first(on the bottom) form disposes, the other forms should go down.
        /// </summary>
        public static void RepositionActivePopups()
        {
            int activeFormCount = GetPopupforms().Count;

            //No active popup forms? set it to default position
            if (activeFormCount == 1)
            {
                //Set the location to the bottom right corner of the user's screen and a little bit above the taskbar since there's only one left
                RemindMeMessageForm form = GetPopupforms()[0];
                form.Location = new Point(Screen.GetWorkingArea(form).Width - form.Width - 5, Screen.GetWorkingArea(form).Height - form.Height - 5);
            }
            else
            {
                foreach (RemindMeMessageForm form in GetPopupforms())
                {
                    //Do NOT move the form down if it is the bottom one
                    if (form.Location.Y != Screen.GetWorkingArea(form).Height - form.Height - 5)
                    {
                        //Check if there is one below you
                        if (!IsFormAt(new Point(form.Location.X, (form.Location.Y + form.Height) + 5)))
                        {
                            //Put all messageforms one down.
                            form.Location = new Point(form.Location.X, (form.Location.Y + form.Height) + 5);
                        }

                    }
                }
            }


            //Lets just clear the disposed forms
            List<RemindMeMessageForm> toRemoveForms = popupForms.Where(form => form.IsDisposed).ToList();

            foreach (RemindMeMessageForm form in toRemoveForms)
                popupForms.Remove(form);

            toRemoveForms.Clear();
        }

        /// <summary>
        /// Check if there is a message form at the given position
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsFormAt(Point p)
        {
            return GetPopupforms().Where(frm => frm.Location == p).ToList().Count > 0;            
        }
    }



}

