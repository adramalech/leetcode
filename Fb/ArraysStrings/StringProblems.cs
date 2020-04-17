using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fb.ArraysStrings
{
  public class StringProblems
  {
    public int LengthOfLongestSubstring(string s)
    {
      // base case if input string is null, empty or whitespace length is 0.
      if (string.IsNullOrEmpty(s))
      {
        return 0;
      }

      int maxLength = s.Length;
      int left = 0;
      int right = 0;
      var uniqueString = new HashSet<char>();
      int totalSubStringLength = 0;
      int uniqueStringCount = 0;

      // base case if string is length one.
      if (maxLength == 1)
      {
        return 1;
      }

      // base case if string is length 2 then if characters don't match return 2 else return 1.
      if (maxLength <= 2)
      {
        if (s[0] != s[1])
        {
          return 2;
        }

        return 1;
      }

      // iterate once through original input (O(n))
      while (left < maxLength && right < maxLength )
      {
        // resolve substring unique conflict.
        while (!uniqueString.Add(s[right]))
        {
          // remove the far left character
          uniqueString.Remove(s[left]);
          // decrease size by one
          uniqueStringCount--;
          // shrink window by one
          left++;
        }

        // add new character.
        uniqueStringCount++;
        // move to grow window size right by one.
        right++;

        // update total count tracking the maximum length unique sub-string.
        if (totalSubStringLength < uniqueStringCount)
        {
          totalSubStringLength = uniqueStringCount;
        }
      }

      return totalSubStringLength;
    }

    public int Atoi(string s)
    {
      // base case s is null or empty return 0
      if (string.IsNullOrEmpty(s))
      {
        return 0;
      }

      var countDigits = 0;
      var haveSeenDigit = false;
      var haveSeenSign = false;
      var haveSeenNegativeSign = false;
      var haveSeenNonDigit = false;
      var haveSeenLeadingZero = false;
      long num = 0;
      var stack = new Stack<char>();

      // iterate through each character worst case O(n)
      foreach (char c in s)
      {
        // if we have seen a non-digit character stop iterating.
        if (haveSeenNonDigit)
        {
          break;
        }
        
        switch (c)
        {
          // whitespace skip
          case ' ':
            if (haveSeenLeadingZero)
            {
              return 0;
            }

            // if we have seen a + or - but not a digit and now seeing space error!
            if (haveSeenSign && !haveSeenDigit)
            {
              return 0;
            }

            // if whitespace found after encountering a digit return
            if (haveSeenDigit)
            {
              haveSeenNonDigit = true;
            }
            break;

          // positive or negative sign is optional
          case '+':
          case '-':
            if (haveSeenLeadingZero)
            {
              return 0;
            }

            // have seen non-digit!
            if (haveSeenDigit)
            {
              haveSeenNonDigit = true;
              continue;
            }

            // if we have already seen a sign return 0.  like double sign.
            // immediately following a sign should be a digit!
            if (haveSeenSign)
            {
              return 0;
            }

            haveSeenSign = true;
            // determine if the sign is negative or positive.
            haveSeenNegativeSign = (c == '-');
            break;

          case '0':
            // if we have seen digits [1-9] then add 0s else skip.
            if (!haveSeenDigit)
            {
              haveSeenLeadingZero = true;
              continue;
            }

            countDigits++;

            // stop if processed more than billionth digit.
            if (countDigits > 10)
            {
              return ((haveSeenNegativeSign) ? int.MinValue : int.MaxValue);
            }

            stack.Push(c);
            break;
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
          case '9':
            // keep pushing digits on to the stack.
            //stack.Push(c);
            haveSeenDigit = true;
            countDigits++;

            // stop if processed more than billionth digit.
            if (countDigits > 10)
            {
              return ((haveSeenNegativeSign) ? int.MinValue : int.MaxValue);
            }

            stack.Push(c);
            break;

          // any non-digit character or symbol not \d, \s, +, or - will end up here.
          default:
            // if we haven't seen digits yet this is a failure!
            if (!haveSeenDigit)
            {
              return 0;
            }

            // make sure to signal to break the loop
            haveSeenNonDigit = true;
            break;
        }
      }

      // if we see a + or - sign and haven't seen a digit return 0
      if (!haveSeenDigit || countDigits < 1)
      {
        return 0;
      }

      long i = 1;
      // start adding
      while (stack.Count > 0)
      {
        int n = convertCharToDigit(stack.Pop());

        // error found.
        if (n == -1)
        {
          return 0;
        }

        num += n * i;
        i *= 10;
      }

      if (haveSeenNegativeSign)
      {
        num = -num;

        // if value is lower than -2147483648 return min value.
        if (num <= int.MinValue)
        {
          return int.MinValue;
        }

        return (int)num;
      }

      // if value is larger than 2147483647 return max value.
      if (num >= int.MaxValue)
      {
        return int.MaxValue;
      }

      // safe to typecast to 32-bit signed int.
      return (int)num;
    }
    
    /**
     * I = 1
     * V = 5
     * X = 10
     * L = 50
     * C = 100
     * D = 500
     * M = 1000
     * IV = 4
     * IX = 9
     * XL = 40
     * XC = 90
     * CD = 400
     * CM = 900
     */
    public int RomanNumerialToInt(string s)
    {
      if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
      {
        return 0;
      }

      s = s.ToUpper();

      var total = 0;
      var length = s.Length;
      
      for (var i = 0; i < length; i++)
      {
        int num = i + 1 < length ? compareCurrentAndNext(s[i], s[i + 1]) : mapNumerialToInt(s[i]);
        total += num;
      }

      return total;
    }
    private int compareCurrentAndNext(char c, char n)
    {
      var num = mapNumerialToInt(c);
      if (
        (c == 'I' && (n == 'V' || n == 'X')) ||
        (c == 'X' && (n == 'L' || n == 'C')) ||
        (c == 'C' && (n == 'D' || n == 'M'))
      )
      {
        return -num;
      }

      return num;
    }
    
    public string Multiply(string num1, string num2)
    {
      const char zero = '0';
      
      if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1) ||
          string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num2)
      ) {
        return zero.ToString();
      }
      
      var length1 = num1.Length;
      var length2 = num2.Length;
      var total = 0;
      var sumDigitsPlacesLookup = new Dictionary<int, List<int>>();
      int tmpNum = 0;
      int d;
      int m;
      int c;
      int i = length1 - 1;
      int j;
      int shift = 0;
      var nums = new List<string>();
      var n1 = char. MinValue;
      var n2 = char.MinValue;
      int count;
      
      while (i >= 0)
      {
        // if this is zero then skip 
        if (num1[i] == zero)
        {
          i--;
          continue;
        }
        
        // first digit of iteration seed.
        j = length2 - 1;
        m = multi(num1[i], num2[j]);
        d = digit(m);
        c = carry(m);

        if (sumDigitsPlacesLookup.ContainsKey(shift))
        {
            sumDigitsPlacesLookup[shift].Add(d);
        }
        else
        {
          sumDigitsPlacesLookup.Add(shift, new List<int>() { d });
        }
        
        j--;
        count = shift + 1;
        
        while (j >= 0)
        {
          m = multi(num1[i], num2[j]) + c;
          d = digit(m);
          
          if (sumDigitsPlacesLookup.ContainsKey(count))
          {
            sumDigitsPlacesLookup[count].Add(d);
          }
          else
          {
            sumDigitsPlacesLookup.Add(count, new List<int>() { d });
          }
          
          c = carry(m);
          j--;
          count++;
        }

        i--;
        shift++;
      }

      int carrySum = 0;
      int sumDigit = 0;
      string sumTotal = "";
      int sum;
      
      foreach (var place in sumDigitsPlacesLookup.Values)
      {
        sum = place.Sum() + carrySum;
        carrySum = carry(sum);
        sumTotal = digit(sum) + sumTotal;
      }

      if (carrySum > 0)
      {
        sumTotal = carrySum + sumTotal;
      }
      
      return (string.IsNullOrEmpty(sumTotal) ? zero.ToString() : sumTotal);
    }

    // single digit multiplied by a single digit
    // the min to max value you could have is 0 to 81.
    private int multi(char num1, char num2) => convertCharToDigit(num1) * convertCharToDigit(num2);
    
    private int carry(int num) => num / 10;
    
    private int digit(int num) => num % 10;
    
    private int mapNumerialToInt(char c)
    {
      return c switch
      {
        'I' => 1,
        'V' => 5,
        'X' => 10,
        'L' => 50,
        'C' => 100,
        'D' => 500,
        'M' => 1000,
        _ => 0
      };
    }
    
    private int convertCharToDigit(char c)
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
        _ => -1
      };

      return n;
    }

    private char digitToChar(int n)
    {
      char c = n switch
      {
        0 => '0',
        1 => '1',
        2 => '2',
        3 => '3',
        4 => '4',
        5 => '5',
        6 => '6',
        7 => '7',
        8 => '8',
        9 => '9',
        _ => char.MinValue
      };

      return c;
    }
  }
}