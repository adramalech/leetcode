using System;
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

        // O(n) with O(1) space
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
        // Space O(n^2)
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) 
            {
                return string.Empty;
            }

            var left = 0;
            var length = 1;
            
            // set up array
            bool[][] tracking = new bool[s.Length][];
            
            for (var i = 0; i < s.Length; i++)
            {
                tracking[i] = new bool[s.Length];
            }

            // i..i = all palindrome!
            for (var i = 0; i < s.Length; i++)
            {
                tracking[i][i] = true;
            }

            // i ... i +  1 if s[i] == s[i+1] palindrome!
            for (var i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    tracking[i][i + 1] = true;
                    left = i;
                    length = 2;
                }
            }

            for (var size = 3; size <= s.Length; size++)
            {
                for (var i = 0; i + size <= s.Length; i++)
                {
                    var right = i + size - 1;

                    // if we found sub-string is a palindrome and chars match.
                    if (tracking[i + 1][right - 1] && s[i] == s[right])
                    {
                        tracking[i][right] = true;
                        
                        if (size > length)
                        {
                            left = i;
                            length = size;
                        }
                    }
                }
            }

            return s.Substring(left, length);
        }
        
        public int MaxSubArrayGreedy(int[] nums) 
        {
            if (nums == null || nums.Length < 1) 
            {
                return 0;
            }

            int length = nums.Length;
            int maxSum = nums[0];
            int sum = nums[0];

            // O(n)
            for (var i = 1; i < length; i++)
            {
                sum = Math.Max(nums[i], nums[i] + sum);
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }
    }
}