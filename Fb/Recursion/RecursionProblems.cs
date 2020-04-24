using System;
using System.Collections.Generic;
using System.Linq;

namespace fb.Recursion
{
    public class RecursionProblems
    {
        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
      
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }

            combo(digits, 0, "", ref result);

            return result;
        }
        
        private void combo(string digits, int index, string str, ref List<string> results)
        {
            if (index >= digits.Length)
            {
                results.Add(str);
                return;
            }

            foreach (var s in keypadDigitLookup(digits[index]))
            {
                combo(digits, index + 1, str + s, ref results);
            }
        }
    
        private string[] keypadDigitLookup(char num)
        {
            return num switch
            {
                '2' => new string[] { "a", "b", "c" },
                '3' => new string[] { "d", "e", "f" },
                '4' => new string[] { "g", "h", "i" },
                '5' => new string[] { "j", "k", "l" },
                '6' => new string[] { "m", "n", "o" },
                '7' => new string[] { "p", "q", "r", "s" },
                '8' => new string[] { "t", "u", "v" },
                '9' => new string[] { "w", "x", "y", "z"},
                _ => new string[] {}
            };
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            var results = new List<string>();
            
            if (string.IsNullOrEmpty(s))
            {
                return results;
            }
            
            checkParantheses(s, 0, 0, "",  ref results);
            
            return results;
        }

        private bool doesStringHaveValidParatheses(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            int count = 0;
            
            foreach (var c in s)
            {
                if (c == '(')
                {
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                }
            }

            return (count == 0);
        }
        
        private void checkParantheses(string s, int index, int count, string str, ref List<string> results)
        {
            return;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var results = new List<IList<int>>();

            perm(nums.ToList(), new List<int>(), results);
            
            return results;
        }

        private void perm(List<int> nums, List<int> p, List<IList<int>> results)
        {
            if (nums.Count < 1)
            {
                results.Add(p);
                return;
            }
            
            for (var i = 0; i < nums.Count; i++)
            {
                perm(removeElement(nums, i), addElement(p, nums[i]), results);
            }
        }

        private List<int> removeElement(List<int> nums, int index)
        {
            var results = new List<int>(nums);
            results.RemoveAt(index);
            return results;
        }

        private List<int> addElement(List<int> nums, int num)
        {
            var results = new List<int>(nums);
            results.Add(num);
            return results;
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var results = new List<IList<int>>();
            
            if (nums == null)
            {
                return results;
            }

            if (nums.Length < 1)
            {
                return results;
            }

            uniquePerm(nums.ToList(), new List<int>(), results);

            return results;
        }

        /*
         
         start with [1, 2, 1, 1]
         
         [1] [1, 1, 2]                             [2] [1, 1, 1]
         
         [1, 1] [1, 2],  [1, 2] [1, 1]             [2, 1] [1, 1]
        
         unique  constraint on fanning out.  repeated same value skip.
          
         */
        private void uniquePerm(List<int> nums, List<int> p, List<IList<int>> results)
        {
            if (nums.Count < 1)
            {
                results.Add(p);
                return;
            }

            var iterateDupChecker = new HashSet<int>();

            for (var i = 0; i < nums.Count; i++)
            {
                // unique pick the numbers else skip.
                if (!iterateDupChecker.Add(nums[i]))
                {
                    continue;
                }

                uniquePerm(removeElement(nums, i), addElement(p, nums[i]), results);
            }
        }
    }
}