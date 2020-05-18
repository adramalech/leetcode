using System.Collections.Generic;
using System.Linq;
using Common.Utils;

namespace Problems.DynamicProgramming
{
    public class DynamicProgrammingProblems
    {
        // O(n) with O(n) space.
        public ulong Fibonacci(int n)
        {
            // if we are looking at out of bounds number return 0.
            if (n <= 0)
            {
                return 0;
            }
            
            // return the 1th and 0th fib number which are 1 and 0 respectively.
            if (n <= 1)
            {
                return 1;
            }
            
            var results = new ulong[n];
            results[0] = 0;
            results[1] = 1;

            for (var i = 2; i < n; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return results[n - 1];
        }

        // O(n) with O(4) space
        public ulong FibonnaciWithConstantSpace(int n)
        {
            // if we are looking at out of bounds number return 0.
            if (n <= 0)
            {
                return 0;
            }
            
            // return the 1th and 0th fib number which are 1 and 0 respectively.
            if (n <= 1)
            {
                return 1;
            }

            ulong prev = 1;
            ulong prev_prev = 0;
            ulong total = 1;

            for (var counter = 2; counter < n; counter++)
            {
                total = prev + prev_prev;
                prev_prev = prev;
                prev = total;
            }

            return total;
        }

        public string LongestPalindrome(string s)
        {
            return null;
        }
        
        public string LongestPalindromeRecurse(string s) 
        {
            // IsPalindrome -> O(n)
            // if string is null or empty return it as it is the largest palindrome.
            // else if the string is length one it itself is a palindrome.
            // else if entire string is a palindrome return the original string.
            if (string.IsNullOrEmpty(s) || s.Length == 1 || StringUtility.IsPalindrome(s))
            {
                return s;
            }

            // O(n)
            // quickest way to see if all characters in string are unique.
            // if they are, return first character.
            if (StringUtility.AreAllCharactersUnique(s))
            {
                return s.FirstOrDefault().ToString();
            }
            
            var lookupTable = new Dictionary<int, HashSet<string>>();

            //palindromeRecurse(s, null, 0, lookupTable);
            
            var uniquePalindromes = new HashSet<string>();
            
            // length of max palindrome in between lengths 0 to n - 1;
            for (var i = s.Length; i >= 0; i--)
            {
                if (lookupTable.TryGetValue(i, out uniquePalindromes))
                {
                    break;
                }
            }

            // if this has failed return the known palindrome of any string
            // which is any single character in the string.
            if (uniquePalindromes == null || uniquePalindromes.Count < 1)
            {
                return s.FirstOrDefault().ToString();
            }

            // doesn't matter which one we return if they are equal length.
            // instead just return the first one at that max length.
            return uniquePalindromes.FirstOrDefault();
        }

        /*
        private void palindromeRecurse(string s, string t, int start, int count, Dictionary<int, HashSet<string>> lookup)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }
            
            if (IsPalindrome(s.Substring(start, count)))
            {
                // lookup:  length -> [ 0th, nth ]
                if (lookup.ContainsKey(t.Length))
                {
                    lookup[t.Length].Add(t);
                }
                else
                {
                    var set = new HashSet<string> { t };
                    lookup.Add(t.Length, set);
                }
            }

            
            for (var i = 0; i < s.Length - 1; i++)
            {
                var left = s[i];
                var right = s.Substring(i + 1);
                
                palindromeRecurse(right, t + left, lookup);
            }

            palindromeRecurse(s.Substring(index + 1), t + s[0], index + 1, lookup);
        }
        */
    }
}