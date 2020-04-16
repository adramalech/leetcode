using System;
using System.Collections.Generic;

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

    public string Multiply(string num1, string num2)
    {
      if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num1) || string.IsNullOrWhiteSpace(num2))
      {
        return "0";
      }
      
      var length1 = num1.Length;
      var length2 = num2.Length;

      var isNumberLargerThanMaxIntValue = (length1 + length2 > 10); 
      
      var total = 0;
      
      var lookupDigitToValue = new Dictionary<int, int>();
      
      for (var i = 0; i < length1; i++)
      {
        // how much we have to shift this number.
        var shift = (i == 0) ? 1 : (i + 1) * 10;

        var carryOver = 0;

        var tmpNum = 0;

        // if the work for this digit hasn't been done before then do it and cache it for later use.
        if (!lookupDigitToValue.ContainsKey(num1[i]))
        {
          for (var j = 0; j < length2; j++)
          {
            var tmpshift = (j == 0) ? 1 : (j + 0) * 10;

            // get multiple at this number
            var m = multi(num1[i], num2[j]);

            // if we put in multi(9, 9) it would return 81. digit = 1, and nextDigitAdd = 8.
            var digit = m % 10;

            var tmpDigit = digit + carryOver;

            carryOver = (tmpDigit / 10) + (m / 10);

            tmpNum += tmpDigit * tmpshift;
          }

          lookupDigitToValue.Add(num1[i], tmpNum);
          
          total += tmpNum * shift;
        }
        else
        {
          // skip doing work if the same work has been done before.
          total += (lookupDigitToValue[num1[i]] * shift);
        }
      }

      return "0";
    }

    // single digit multiplied by a single digit
    // the min to max value you could have is 0 to 81.
    public int multi(char num1, char num2)
    {
      var n1 = convertCharToDigit(num1);
      var n2 = convertCharToDigit(num2);
      return n1 * n2;
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
    
    private int mapNumerialToInt(char c)
    {
      switch (c)
      {
        case 'I':
          return 1;
        case 'V':
          return 5;
        case 'X':
          return 10;
        case 'L':
          return 50;
        case 'C':
          return 100;
        case 'D':
          return 500;
        case 'M':
          return 1000;
        default:
          return 0;
      }
    }
    
    private int convertCharToDigit(char c)
    {
      int n;

      switch (c)
      {
        case '0':
          n = 0;
          break;
        case '1':
          n = 1;
          break;
        case '2':
          n = 2;
          break;
        case '3':
          n = 3;
          break;
        case '4':
          n = 4;
          break;
        case '5':
          n = 5;
          break;
        case '6':
          n = 6;
          break;
        case '7':
          n = 7;
          break;
        case '8':
          n = 8;
          break;
        case '9':
          n = 9;
          break;
        default:
          n = -1;
          break;
      }

      return n;
    }

    private char digitToChar(int n)
    {
      char c = char.MinValue;

      switch (n)
      {
        case 0:
          c = '0';
          break;
        case 1:
          c = '1';
          break;
        case 2:
          c = '2';
          break;
        case 3:
          c = '3';
          break;
        case 4:
          c = '4';
          break;
        case 5:
          c = '5';
          break;
        case 6:
          c = '6';
          break;
        case 7:
          c = '7';
          break;
        case 8:
          c = '8';
          break;
        case 9:
          c = '9';
          break;
      }

      return c;
    }
  }
}