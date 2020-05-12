using System.Collections.Generic;
using System.Linq;

namespace Common.Utils
{
    public class StringUtility
    {
        public static int ConvertCharToDigit(char c)
        {
            int n = c switch
            {
                '0' => 0,
                '1' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                _ => 0
            };

            return n;
        }
        
        public static bool IsPalindrome(string original)
        {
            if (original == null)
            {
                return false;
            }

            if (original.Length == 0 || original.Length == 1)
            {
                return true;
            }

            // O(n)
            string reverse = new string(original.Reverse().ToArray());

            // O(n)
            return original.Equals(reverse);
        }
        
        public static bool AreAllCharactersUnique(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            
            var set = new HashSet<char>(s.ToCharArray());
            return (s.Length == set.Count);
        }
        
        public static string ReplaceCharAt(string s, int index, char symbol)
        {
            if (index < 0 || index >= s.Length)
            {
                return s;
            }

            var chars = s.ToCharArray();
            chars[index] = symbol;
            return new string(chars);
        }
    }
}