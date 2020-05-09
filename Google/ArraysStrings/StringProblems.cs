using System.Collections.Generic;

namespace Google.ArraysStrings
{
    public class StringProblems
    {
        public string MinWindow(string s, string t) 
        {
            // if t is longer than s, or either are empty/null than return empty string. 
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) 
            {
                return string.Empty;
            }
            
            // we want to initialize the window to the minimum length of T
            var left = 0;
            var right = t.Length - 1;
            var minSize = 0;
            var minLeft = 0;
            var curSize = t.Length;
            
            // iterate while:
            //    1. the left position has not proceeded beyond the right size
            //    2. making sure that the right side stays less than the maximum size of the input.
            //    3. if the current window size must be greater than or equal to the length of T
            while (left <= right && curSize >= t.Length && right < s.Length) 
            {
                // check to see if this current window matches the symbols.
                var areAllSymbolsFound = symbolsMatchString(s.Substring(left, curSize), t);

                // if they do match make sure to compare current minimum size and window.
                // if it is less than the current minimum replace current minimum.
                if (areAllSymbolsFound)
                {
                    // if the minimum size isn't matched or if it is minimum
                    // set the current window size and boundary positions as the new minimum.
                    if (minSize == 0 || minSize > (right - left + 1))
                    {
                        minSize = right - left + 1;
                        minLeft = left;
                    }
                    
                    // increment the left to make sure that we cannot make it any smaller.
                    left++;
                }
                else
                {
                    // we were unable to find a match grow the window size.
                    right++;
                }
                
                // set the current size of the window.
                curSize = right - left + 1;
            }

            // if the size found is zero by not finding anything, 
            // then we should return empty string, else return the window we found.
            return  (minSize < 1) ? string.Empty : s.Substring(minLeft, minSize);
        }
        
        // search string should match.
        public bool symbolsMatchString(string substring, string symbols)
        {
            // how to match symbols exist in substring
            foreach (var c in substring)
            {
                var position = symbols.IndexOf(c);

                if (position < 0)
                {
                    continue;
                }

                symbols = symbols.Remove(position, 1);
                
                if (string.IsNullOrEmpty(symbols))
                {
                    return true;
                }
            }

            return false;
        }
    }
}