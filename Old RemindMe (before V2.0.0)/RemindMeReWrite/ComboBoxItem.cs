using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// This class is used to store an object and text in a combobox
    /// </summary>
    public class ComboBoxItem
    {
        
  

        private string text;
        private object value;
        
        public ComboBoxItem(string text, object value)
        {
            this.text = text;
            this.value = value;

            //Automatically add it to the manager's list when a new object is created
            ComboBoxItemManager.AddComboboxItem(this);            
        }       
                       
        public override string ToString()
        {
            return text;
        }
        

        /// <summary>
        /// The text displayed in the ComboBox
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// The value of the ComboBoxItem. 
        /// </summary>
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
