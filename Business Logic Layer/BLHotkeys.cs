using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLHotkeys
    {
        private BLHotkeys() { }

        /// <summary>
        /// Reads the settings from the database and checks if the controls should be cleared after making a new reminder.
        /// </summary>
        /// <returns>True to use sticky form, false if not</returns>
        public static Hotkeys TimerPopup
        {
            get
            {
                //Let's also insert the quick timer hotkey if it doesnt exist                
                if (DLHotkeys.TimerPopup == null)
                {
                    Hotkeys timerHotkey = DLHotkeys.TimerPopup;
                    if (timerHotkey == null)
                    {
                        timerHotkey = new Hotkeys(); //No hotkey in the database for the quick timer? insert the default hotkey
                        timerHotkey.Key = "R";
                        timerHotkey.Name = "Timer";
                        timerHotkey.Modifiers = "Shift,Control";
                    }
                    InsertHotkey(timerHotkey);
                }

                return DLHotkeys.TimerPopup;
            }
            set
            {
                //Before we push the new hotkey value, let's check if it's valid 
                if (string.IsNullOrWhiteSpace(value.Key) || string.IsNullOrWhiteSpace(value.Modifiers) || string.IsNullOrWhiteSpace(value.Name))
                    return;
                
                DLHotkeys.TimerPopup = value;
            }
            
        }  
        public static void InsertHotkey(Hotkeys hotkey)
        {
            if(hotkey != null && !(string.IsNullOrWhiteSpace(hotkey.Key) || string.IsNullOrWhiteSpace(hotkey.Modifiers) || string.IsNullOrWhiteSpace(hotkey.Name)))
                DLHotkeys.InsertHotkey(hotkey);
        }
    }
}
