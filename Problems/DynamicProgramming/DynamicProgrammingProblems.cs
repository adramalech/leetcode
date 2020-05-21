using System.Collections.Generic;
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
        
        // Time O(n^3)
        // Space O(1)
        public string LongestPalindromeBruteForce(string s) 
        {
            if (string.IsNullOrEmpty(s)) 
            {
                return string.Empty;
            }
            
            var maxPalindrome = s[0].ToString();
            
            // O(n^2)
            for (var size = 2; size <= s.Length; size++)
            {
                for (var i = 0; i + size <= s.Length; i++)
                {
                    var str = s.Substring(i, size);

                    // O(n)
                    if (StringUtility.IsPalindrome(str))
                    {
                        if (str.Length > maxPalindrome.Length) 
                        {
                            maxPalindrome = str;
                        }
                    }
                }
            }

            return maxPalindrome;
        }

        // Time O(n^2)
        // Space O(n)
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) 
            {
                return string.Empty;
            }

            var maxPalindrome = s[0].ToString();
            
            // substring -> is it a palindrome?
            var lookup = new Dictionary<string, bool>();

            for (var size = 2; size <= s.Length; size++)
            {
                for (var i = 0; i + size <= s.Length; i++)
                {
                    var str = s.Substring(i, size);

                    if (!lookup.ContainsKey(str))
                    {
                        lookup.TryGetValue(str.Substring(1, str.Length - 2), out var isSubstringPalindrome);

                        if (isSubstringPalindrome && str[0] == str[str.Length - 1])
                        {
                            lookup.Add(str, true);

                            if (str.Length > maxPalindrome.Length)
                            {
                                maxPalindrome = str;
                            }
                        }
                        else
                        {
                            var isStrAPalindrome = StringUtility.IsPalindrome(str);

                            if (isStrAPalindrome && str.Length > maxPalindrome.Length)
                            {
                                maxPalindrome = str;
                            }

                            lookup.Add(str, isStrAPalindrome);
                        }
                    }
                }
            }

            return maxPalindrome;
        }
    }
}