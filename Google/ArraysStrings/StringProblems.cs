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
        
        // Time = O(n + m)
        // Space = O(n + m)
        public bool BackspaceCompare(string S, string T)
        {
            var sChars = ""; 
            var tChars = "";
            var skipCount = 0;
            const char SKIP_CHAR = '#';
            
            // O(n)
            for (var i = S.Length - 1; i >= 0; i--)
            {
                // if we match the skip character increment skip count
                if (S[i] == SKIP_CHAR)
                {
                    skipCount++;
                    continue;
                }
                
                // if skip count is greater than zero skip until it is zero.
                if (skipCount > 0)
                {
                    skipCount--;
                    continue;
                }
                
                // we aren't on a character to be skipped, and we haven't seen the skip character.
                // add to the current string.
                sChars = S[i] + sChars;
            }

            // clear skip for next loop
            skipCount = 0;
            
            // O(m)
            for (var i = T.Length - 1; i >= 0; i--)
            {
                // if we match the skip character increment skip count
                if (T[i] == SKIP_CHAR)
                {
                    skipCount++;
                    continue;
                }
                
                // if skip count is greater than zero skip until it is zero.
                if (skipCount > 0)
                {
                    skipCount--;
                    continue;
                }

                // we aren't on a character to be skipped, and we haven't seen the skip character.
                // add to the current string.
                tChars = T[i] + tChars;
            }
            
            return sChars.Equals(tChars);
        }
        
        // Time O(m + n)
        // Space O(1)
        public bool BackspaceCompareConstantSpace(string S, string T)
        {
            const char SKIP_CHAR = '#';
            var i = S.Length - 1;
            var j = T.Length - 1;
            var skipCountS = 0;
            var skipCountT = 0;
            
            // while i or j is greater than 0 continue iterating.
            while (i >= 0 || j >= 0)
            {
                // detected a skip character
                if ((i >= 0 && S[i] == SKIP_CHAR) || (j >= 0 && T[j] == SKIP_CHAR))
                {
                    if (i >= 0 && S[i] == SKIP_CHAR)
                    {
                        skipCountS++;
                        i--;
                    }
                    
                    if (j >= 0 && T[j] == SKIP_CHAR)
                    {
                        skipCountT++;
                        j--;
                    }

                    continue;
                }
                
                // skip character.
                if (skipCountS > 0 || skipCountT > 0)
                {
                    if (skipCountS > 0)
                    {
                        skipCountS--;
                        i--;
                    }
                    
                    if (skipCountT > 0)
                    {
                        skipCountT--;
                        j--;
                    }

                    continue;
                }

                // we are not skipping the character so
                // check if i and j are not comparable or if one is comparable and other isn't then fail.
                if ((i >= 0 && j >= 0 && S[i] != T[j]) || (i < 0 ^ j < 0))
                {
                    return false;
                }

                i--;
                j--;
            }

            return true;
        }
    }
}