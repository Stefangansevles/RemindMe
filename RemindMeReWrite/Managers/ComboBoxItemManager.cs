using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindMe
{
    /// <summary>
    /// This class manages ComboBoxItems and only ComboBoxItems.
    /// </summary>
    public abstract class ComboBoxItemManager
    {
        /// <summary>
        /// List of all combobox items
        /// </summary>
        private static List<ComboBoxItem> items = new List<ComboBoxItem>();


        /// <summary>
        /// Gets the list of all comboboxitems
        /// </summary>
        /// <returns></returns>
        public static List<ComboBoxItem> GetComboboxItems()
        {
            return items;
        }

        /// <summary>
        /// Get a specific comboboxitem
        /// </summary>
        /// <param name="text">text of the comboboxitem</param>
        /// <param name="value">value of the comboboxitem</param>
        /// <returns>A comboboxitem with the given text and value. null if it doesnt exist</returns>
        public static ComboBoxItem GetComboBoxItem(string text, object value)
        {
            foreach (ComboBoxItem cb in items)            
                if (cb.Text == text && cb.Value.Equals(value))
                    return cb;
            
            return null;
        }
    }
}
