using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Recursion
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
            if (string.IsNullOrEmpty(s))
            {
                return new List<string>() { s };
            }

            var results = new Dictionary<int, HashSet<string>>();
            var length = s.Length;

            checkParentheses(s, 0, results);

            // find the minimal count return that list.
            var result = new List<string>();

            for (var i = 0; i <= length; i++)
            {
                if (results.ContainsKey(i))
                {
                    result = results[i].ToList();
                    break;
                }
            }

            return result;
        }

        public bool doesStringHaveValidParetheses(string s)
        {
            // nothing is valid.
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var count = 0;

            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                        count++;
                        break;
                    case ')':
                        count--;
                        break;
                }

                // we saw too many close brackets.
                if (count < 0)
                {
                    return false;
                }
            }

            return (count == 0);
        }

        private void checkParentheses(string s, int count, Dictionary<int, HashSet<string>> results)
        {
            // base case if it is valid add it.
            if (doesStringHaveValidParetheses(s))
            {
                if (results.ContainsKey(count))
                {
                    results[count].Add(s);
                }
                else
                {
                    results.Add(count, new HashSet<string>() { s });
                }

                return;
            }

            var unique = new HashSet<string>();

            for (var i = 0; i < s.Length; i++)
            {
                // skip if not parentheses we are removing
                if (s[i] == ')' || s[i] == '(')
                {
                    var n = s.Remove(i, 1);

                    // if we haven't seen this result before.
                    if (unique.Add(n))
                    {
                        checkParentheses(n, count + 1, results);
                    }
                }
            }
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

        public IList<string> GenerateParenthesis(int n)
        {
            var results = new List<string>();

            generateParens(n, results, "", 0, 0);

            return results;
        }

        private void generateParens(int n, IList<string> results, string result, int open, int close)
        {
            if (result.Count() == n * 2)
            {
                results.Add(result);
                return;
            }

            if (open < n)
            {
                generateParens(n, results, result + "(", open + 1, close);
            }

            if (close < open)
            {
                generateParens(n, results, result + ")", open, close + 1);
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var results = new List<IList<int>>();

            if (candidates == null || candidates.Length < 1)
            {
                return results;
            }

            Array.Sort(candidates);

            comboSum(candidates, target, results, new List<int>(), 0, new HashSet<string>());

            return results;
        }

        private void comboSum(int[] c, int target, List<IList<int>> sums, List<int> sumTracking, int curSum, HashSet<string> set)
        {
            if (curSum == target)
            {
                if (set.Add(String.Concat(sumTracking.OrderBy(s => s).Select(s => s.ToString()))))
                {
                    sums.Add(sumTracking);
                }

                return;
            }

            for (var i = 0; i < c.Length; i++)
            {
                if (curSum + c[i] <= target)
                {
                    comboSum(c, target, sums, addElement(sumTracking, c[i]), curSum + c[i], set);
                }
            }
        }
    }
}