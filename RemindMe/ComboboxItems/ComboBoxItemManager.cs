using Database.Entity;
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
        /// Gets the (read-only)list of all comboboxitems
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<ComboBoxItem> GetComboboxItems()
        {
            return items.AsReadOnly();            
        }

        /// <summary>
        /// Adds an combobox item to the list
        /// </summary>
        /// <param name="item">The object you wish to add</param>
        public static void AddComboboxItem(ComboBoxItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Clears the entire list of combobox items
        /// </summary>
        public static void ClearComboboxItems()
        {
            items.Clear();
        }

        /// <summary>
        /// Removes the specified comboboxitem from the list
        /// </summary>
        /// <param name="item">The object you wish to remove</param>
        public static void RemoveComboboxItem(ComboBoxItem item)
        {
            items.Remove(item);
        }
        
        /// <summary>
        /// Get a specific comboboxitem
        /// </summary>
        /// <param name="text">text of the comboboxitem</param>
        /// <param name="value">value of the comboboxitem</param>
        /// <returns>A comboboxitem with the given text and value. null if it doesnt exist</returns>
        public static ComboBoxItem GetComboBoxItem(string text, object value)
        {
            Songs paramSong = (Songs)value;
            if (paramSong != null)
            {
                foreach (ComboBoxItem cbItem in items)
                {
                    Songs cbItemSong = (Songs)cbItem.Value;
                    if (cbItem.Text == text && cbItemSong.SongFilePath == paramSong.SongFilePath)
                        return cbItem;
                }
            }
            
            return null;
        }
    }
}
