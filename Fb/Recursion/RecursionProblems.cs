using System.Collections.Generic;

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
    }
}