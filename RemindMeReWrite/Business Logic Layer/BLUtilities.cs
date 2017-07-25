using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace RemindMe
{
    public abstract class BLUtilities
    {
        /// <summary>
        /// Strips an string between 2 characters.
        /// </summary>
        /// <param name="text">The string that needs to be stripped</param>
        /// <param name="startChar">The first character</param>
        /// <param name="endChar">The last character</param>
        /// <returns>The remainder of the string that is between the startChar and the endChar</returns>
        public static string stripString(string text, string startChar, string endChar)
        {
            string s = text;
            int start = s.IndexOf(startChar) + 1;
            int end = s.IndexOf(endChar, start);
            string result = s.Substring(start, end - start);
            return result;
        }

        
    }
}
