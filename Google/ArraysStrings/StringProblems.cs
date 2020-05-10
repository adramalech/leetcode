using System.Collections.Generic;
using System.Linq;

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
            var symbolLookup = new Dictionary<char, int>();
            
            // generate the T symbols into a lookup table.
            foreach (var c in t)
            {
                if (symbolLookup.ContainsKey(c))
                {
                    symbolLookup[c]++;
                }
                else
                {
                    symbolLookup.Add(c, 1);
                }
            }

            // this cache results will allow us to lookup previous results
            // and which symbols matched. so we don't have to rematch after the first match.
            // seed the currentMatchedSymbols of the current window.
            foreach (var c in s.Substring(left, curSize))
            {
                if (symbolLookup.ContainsKey(c))
                {
                    symbolLookup[c]--;
                }
            }
            
            // iterate while:
            //    1. the left position has not proceeded beyond the right size
            //    2. making sure that the right side stays less than the maximum size of the input.
            //    3. if the current window size must be greater than or equal to the length of T
            while (left <= right && curSize >= t.Length && right < s.Length) 
            {
                // if they do match make sure to compare current minimum size and window.
                if (symbolLookup.Values.All(count => count <= 0))
                {
                    // if the minimum size isn't matched or if it is minimum
                    // set the current window size and boundary positions as the new minimum.
                    if (minSize == 0 || minSize > (right - left + 1))
                    {
                        minSize = right - left + 1;
                        minLeft = left;
                    }
                    
                    // if removing the leftmost character,
                    // make sure to see if the left most character matches
                    if (symbolLookup.ContainsKey(s[left]))
                    {
                        // this looks bad but it actually makes sense we want to keep a 0 or less than 0.
                        symbolLookup[s[left]]++;
                    }
                    
                    // increment the left to make sure that we cannot make it any smaller.
                    left++;
                }
                else
                {
                    // if appending a new character as the rightmost character if it matches
                    // add to the cache.
                    if (right + 1 < s.Length)
                    {
                        if (symbolLookup.ContainsKey(s[right + 1]))
                        {
                            symbolLookup[s[right + 1]]--;
                        }
                    }

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
    }
}