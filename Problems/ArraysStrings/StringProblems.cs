using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utils;

namespace Problems.ArraysStrings
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
      while (left < maxLength && right < maxLength)
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
        int n = StringUtility.ConvertCharToDigit(stack.Pop());

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

        return (int) num;
      }

      // if value is larger than 2147483647 return max value.
      if (num >= int.MaxValue)
      {
        return int.MaxValue;
      }

      // safe to typecast to 32-bit signed int.
      return (int) num;
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
      const string zero = "0";

      if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1) ||
          string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num2) ||
          num1 == zero || num2 == zero
      )
      {
        return zero;
      }

      var length1 = num1.Length;
      var length2 = num2.Length;
      var sumDigitsPlacesLookup = new Dictionary<int, List<int>>();
      int d;
      int m;
      int c;
      int i = length1 - 1;
      int j;
      int shift = 0;
      int count;

      while (i >= 0)
      {
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
          sumDigitsPlacesLookup.Add(shift, new List<int>() {d});
        }

        j--;
        count = shift + 1;

        // single digit, then just add carry if carry is greater than zero.
        if (j < 0 && c > 0)
        {
          if (sumDigitsPlacesLookup.ContainsKey(count))
          {
            sumDigitsPlacesLookup[count].Add(c);
          }
          else
          {
            sumDigitsPlacesLookup.Add(count, new List<int>() {c});
          }
        }
        else
        {
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
              sumDigitsPlacesLookup.Add(count, new List<int>() {d});
            }

            c = carry(m);
            j--;
            count++;
          }

          // this is to handle carry overflow extra digit.
          if (c > 0)
          {
            if (sumDigitsPlacesLookup.ContainsKey(count))
            {
              sumDigitsPlacesLookup[count].Add(c);
            }
            else
            {
              sumDigitsPlacesLookup.Add(count, new List<int>() {c});
            }
          }
        }

        i--;
        shift++;
      }

      int carrySum = 0;
      string sumTotal = "";
      int sum;

      for (var k = 0; k < sumDigitsPlacesLookup.Count; k++)
      {
        sum = sumDigitsPlacesLookup[k].Sum();
        sum = sum + carrySum;
        carrySum = carry(sum);
        sumTotal = digit(sum) + sumTotal;
      }

      if (carrySum > 0)
      {
        sumTotal = carrySum + sumTotal;
      }

      return (string.IsNullOrEmpty(sumTotal) ? zero.ToString() : sumTotal);
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
      var results = new List<IList<string>>();

      if (strs == null || strs.Length < 1)
      {
        return results;
      }

      var grouping = new Dictionary<int, List<string>>();

      // O(n + m )

      // group the strings by length.
      // O(n)
      foreach (var s in strs)
      {
        if (string.IsNullOrEmpty(s))
        {
          if (grouping.ContainsKey(0))
          {
            grouping[0].Add(s);
          }
          else
          {
            grouping.Add(0, new List<string>() {s});
          }
        }
        else
        {
          var length = s.Length;

          if (grouping.ContainsKey(length))
          {
            grouping[length].Add(s);
          }
          else
          {
            grouping.Add(length, new List<string>() {s});
          }
        }
      }

      // O(m)
      foreach (var group in grouping.Values)
      {
        if (group.Count < 2)
        {
          results.Add(group);
        }
        else if (group.Count == 2)
        {
          if (isStringPairAnagram(group[0], group[1]))
          {
            results.Add(group);
          }
          else
          {
            results.Add(new List<string> {group[0]});
            results.Add(new List<string> {group[1]});
          }
        }
        else
        {
          var length = group.Count;

          bool[] track = new bool[length];

          List<string> g;

          for (var i = 0; i < length - 1; i++)
          {
            if (!track[i])
            {
              g = new List<string>() {group[i]};
              track[i] = true;

              for (var j = i + 1; j < length; j++)
              {
                if (!track[j])
                {
                  if (isStringPairAnagram(group[i], group[j]))
                  {
                    g.Add(group[j]);
                    track[j] = true;
                  }
                }
              }

              results.Add(g);
            }
          }

          for (var k = 0; k < length; k++)
          {
            if (!track[k])
            {
              results.Add(new List<string>() {group[k]});
            }
          }
        }
      }

      return results;
    }

    public IList<IList<string>> GroupAnagrams2(string[] strs)
    {
      var results = new List<IList<string>>();

      if (strs == null || strs.Length < 1)
      {
        return results;
      }

      var grouping = new Dictionary<string, List<string>>();

      // O(n * m * log(m))
      foreach (var s in strs)
      {
        string tmpCharStr = s;

        if (!string.IsNullOrEmpty(s))
        {
          var chars = s.ToCharArray();
          Array.Sort(chars);
          tmpCharStr = new string(chars);
        }

        if (grouping.ContainsKey(tmpCharStr))
        {
          grouping[tmpCharStr].Add(s);
        }
        else
        {
          grouping.Add(tmpCharStr, new List<string>() {s});
        }
      }

      foreach (var v in grouping.Values)
      {
        results.Add(v);
      }

      return results;
    }

    public string AddBinary(string a, string b)
    {
      char carry = '0';
      int i = a.Length - 1;
      int j = b.Length - 1;

      string result = "";

      while (i >= 0 && j >= 0)
      {
        int sum = StringUtility.ConvertCharToDigit(a[i]) +
                  StringUtility.ConvertCharToDigit(b[j]) +
                  StringUtility.ConvertCharToDigit(carry);

        if (sum == 3)
        {
          result = "1" + result;
          carry = '1';
        }
        else if (sum == 2)
        {
          result = "0" + result;
          carry = '1';
        }
        else
        {
          result = sum.ToString() + result;
          carry = '0';
        }

        i--;
        j--;
      }

      // if a length is greater than b length.
      if (i >= 0)
      {
        while (i >= 0)
        {
          int sum = StringUtility.ConvertCharToDigit(a[i]) + StringUtility.ConvertCharToDigit(carry);

          if (sum == 2)
          {
            result = "0" + result;
            carry = '1';
          }
          else
          {
            result = sum.ToString() + result;
            carry = '0';
          }

          i--;
        }
      }

      // if b length is greater than a length.
      if (j >= 0)
      {
        while (j >= 0)
        {
          int sum = StringUtility.ConvertCharToDigit(b[j]) + StringUtility.ConvertCharToDigit(carry);

          if (sum == 2)
          {
            result = "0" + result;
            carry = '1';
          }
          else
          {
            result = sum.ToString() + result;
            carry = '0';
          }

          j--;
        }
      }

      var c = StringUtility.ConvertCharToDigit(carry);

      if (c > 0)
      {
        result = "1" + result;
      }

      return result;
    }

    public bool isStringPairAnagram(string s1, string s2)
    {
      if (s1.Length != s2.Length)
      {
        return false;
      }

      var charFrequencyCounter = new Dictionary<char, int>();

      // count the symbols in one of the strings.
      foreach (var c in s1)
      {
        if (charFrequencyCounter.ContainsKey(c))
        {
          charFrequencyCounter[c]++;
        }
        else
        {
          charFrequencyCounter.Add(c, 1);
        }
      }

      // decrement the count of occurrences in the other string
      // if they don't match this will find it.
      foreach (var c in s2)
      {
        if (!charFrequencyCounter.ContainsKey(c))
        {
          return false;
        }

        charFrequencyCounter[c]--;

        if (charFrequencyCounter[c] < 1)
        {
          charFrequencyCounter.Remove(c);
        }
      }

      return true;
    }

    public string NumberToWords(int num)
    {
      if (num <= 0)
      {
        return "Zero";
      }

      // num = 1 to 20.
      if (num < 20)
      {
        return mapNumToWord(num);
      }

      // num = 21 to 99
      if (num < 100)
      {
        return describeTensAndOnes(num);
      }

      int nTens;
      int nHundreds;
      int n;
      string result = "";
      var place = 3;

      // num = 100 - 2,147,483,647
      while (num > 0)
      {
        var words = "";

        n = (int) (num % Math.Pow(10, 3));
        nHundreds = n / 100;

        if (nHundreds > 0)
        {
          // hundreds
          words = describeHundreds(nHundreds);
        }

        // tens and ones.
        nTens = n % 100;

        if (nTens > 0)
        {
          var t = describeTensAndOnes(nTens);

          if (!string.IsNullOrEmpty(t))
          {
            if (!string.IsNullOrEmpty(words))
            {
              t = " " + t;
            }

            words += t;
          }
        }

        if (!string.IsNullOrEmpty(words))
        {
          // add the place
          var p = mapPlaceToWord(place);

          if (!string.IsNullOrEmpty(p))
          {
            words += " " + p;
          }

          // add the constructed word to the result.
          if (!string.IsNullOrEmpty(result))
          {
            result = " " + result;
          }

          result = words + result;
        }

        // remove diff.
        num = (int) Math.Floor(num / Math.Pow(10, 3));

        if (num >= 1000)
        {
          place += 3;
        }
        else if (num >= 100)
        {
          place += 2;
        }
        else
        {
          place++;
        }
      }

      return result;
    }

    public string describeTensAndOnes(int tensOnes)
    {
      string words;
      int ones;
      int twos;

      if (tensOnes <= 20)
      {
        words = mapNumToWord(tensOnes);
      }
      else
      {
        // break it down 22 = 20 + 2.
        ones = tensOnes % 10;
        twos = tensOnes - ones;

        words = mapNumToWord(twos);

        if (ones > 0)
        {
          words += " " + mapNumToWord(ones);
        }
      }

      return words;
    }

    public string describeHundreds(int hundreds)
    {
      var result = "";

      if (hundreds > 0)
      {
        result += mapNumToWord(hundreds) + " Hundred";
      }

      return result;
    }

    public string mapPlaceToWord(int place)
    {
      if (place < 4)
      {
        return "";
      }

      if (place < 7)
      {
        return "Thousand";
      }

      return place < 10 ? "Million" : "Billion";
    }

    public string mapNumToWord(int num)
    {
      return num switch
      {
        1 => "One",
        2 => "Two",
        3 => "Three",
        4 => "Four",
        5 => "Five",
        6 => "Six",
        7 => "Seven",
        8 => "Eight",
        9 => "Nine",
        10 => "Ten",
        11 => "Eleven",
        12 => "Twelve",
        13 => "Thirteen",
        14 => "Fourteen",
        15 => "Fifteen",
        16 => "Sixteen",
        17 => "Seventeen",
        18 => "Eighteen",
        19 => "Nineteen",
        20 => "Twenty",
        30 => "Thirty",
        40 => "Forty",
        50 => "Fifty",
        60 => "Sixty",
        70 => "Seventy",
        80 => "Eighty",
        90 => "Ninety",
        _ => ""
      };
    }

    // single digit multiplied by a single digit
    // the min to max value you could have is 0 to 81.
    public int multi(char num1, char num2) =>
      StringUtility.ConvertCharToDigit(num1) * StringUtility.ConvertCharToDigit(num2);

    public int carry(int num) => (int) (Math.Floor(((double) num) / 10));

    public int digit(int num) => num % 10;

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
      return (minSize < 1) ? string.Empty : s.Substring(minLeft, minSize);
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

    public bool RepeatedSubstringPattern(string s)
    {
      var length = s.Length;
      var maxSubstringLength = length / 2;
      var size = 1;

      while (size <= maxSubstringLength)
      {
        var t = s.Substring(0, size);
        var i = t.Length;

        while (i + t.Length <= length && s.Substring(i, size).Equals(t))
        {
          i += t.Length;
        }

        if (i >= length)
        {
          return true;
        }

        size++;
      }

      return false;
    }

    // Given a string containing just the characters '(', ')', '{', '}', '[' and ']',
    // determine if the input string is valid.
    public bool IsValid(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return true;
      }

      var storage = new Stack<char>();
      const char OPEN_PAREN = '(';
      const char CLOSE_PAREN = ')';
      const char OPEN_CURLY = '{';
      const char CLOSE_CURLY = '}';
      const char OPEN_SQUARE = '[';
      const char CLOSE_SQUARE = ']';
      char temp;

      foreach (var c in s)
      {
        switch (c)
        {
          case OPEN_CURLY:
            storage.Push(c);
            break;

          case OPEN_PAREN:
            storage.Push(c);
            break;

          case OPEN_SQUARE:
            storage.Push(c);
            break;

          case CLOSE_CURLY:
            if (storage.Count == 0)
            {
              return false;
            }

            temp = storage.Pop();

            if (temp != OPEN_CURLY)
            {
              return false;
            }

            break;

          case CLOSE_PAREN:
            if (storage.Count == 0)
            {
              return false;
            }

            temp = storage.Pop();

            if (temp != OPEN_PAREN)
            {
              return false;
            }

            break;

          case CLOSE_SQUARE:
            if (storage.Count == 0)
            {
              return false;
            }

            temp = storage.Pop();

            if (temp != OPEN_SQUARE)
            {
              return false;
            }

            break;

          // skip chars.
          default:
            continue;
        }
      }

      return storage.Count == 0;
    }

    public string AddStrings(string num1, string num2)
    {
      var sum = "";
      var i = num1.Length - 1;
      var j = num2.Length - 1;
      var tmpSum = 0;
      var carry = 0;
      var digit = 0;

      // iterate over list.
      while (i >= 0 && j >= 0)
      {
        tmpSum = atoi(num1[i]) + atoi(num2[j]) + carry;
        digit = tmpSum % 10;
        sum = digit + sum;
        carry = tmpSum / 10;
        i--;
        j--;
      }

      // if the num1 is longer
      while (i >= 0)
      {
        tmpSum = atoi(num1[i]) + carry;
        digit = tmpSum % 10;
        sum = digit + sum;
        carry = tmpSum / 10;
        i--;
      }


      // if the num2 is longer
      while (j >= 0)
      {
        tmpSum = atoi(num2[j]) + carry;
        digit = tmpSum % 10;
        sum = digit + sum;
        carry = tmpSum / 10;
        j--;
      }

      // if we have a trailing carry
      if (carry > 0)
      {
        sum = carry + sum;
      }

      return sum;
    }

    private int atoi(char c)
    {
      return c switch
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
      };
    }

    // time O(n + m)
    // space O(n)
    public int NumUniqueEmails(string[] emails)
    {
        if (emails == null || emails.Length < 1)
        {
            return 0;
        }

        // email address -> count
        var set = new HashSet<string>();

        // O(n)
        foreach (var email in emails)
        {
          // O(m)
          set.Add(formatEmailAddress(email));
        }

        return set.Count;
    }

    private string formatEmailAddress(string emailAddress)
    {
      const char IGNORE = '+';
      const char COMBINE = '.';

      // splits into two parts
      var parts = emailAddress.Split('@');

      var end = "@" + parts[1];

      var formattedUserName = new StringBuilder();

      // parts[0] is username might contain . or +
      foreach (var c in parts[0])
      {
        // if we see ignore break.
        if (c == IGNORE)
        {
          break;
        }

        // if combine skip
        if (c == COMBINE)
        {
          continue;
        }

        // we see not an ignore or a combine we append characters.
        formattedUserName.Append(c.ToString());
      }

      formattedUserName.Append(end);

      return formattedUserName.ToString();
    }

    public int ExpressiveWords(string S, string[] words)
    {
      var totalCount = 0;
      var sLookup = new Dictionary<char, int>();

      // O(S)
      foreach (var c in S)
      {
        if (sLookup.ContainsKey(c))
        {
          sLookup[c]++;
        }
        else
        {
          sLookup.Add(c, 1);
        }
      }

      // O(n)
      foreach (var word in words)
      {
        if (wordStretchy(S, word))
        {
          totalCount++;
        }
      }

      return totalCount;
    }

    private bool wordStretchy(string S, string word)
    {
      var i = 0;
      var j = 0;

      if (word.Length >= S.Length)
      {
        return false;
      }

      while (i < S.Length && j < word.Length)
      {
        // while word doesn't match return false.
        if (S[i] != word[j])
        {
          return false;
        }

        // find where the next non-repeated character is.
        // k will end at a new character that doesn't match.
        // count will have total number of characters.
        var k = i;
        while (k < S.Length && S[k] == S[i])
        {
          k++;
        }

        // find where the next non-repeated character is.
        // l will end at a new character that doesn't match.
        // count will have total number of characters.
        var l = j;
        while (l < word.Length && word[l] == word[j])
        {
          l++;
        }

        var countS = k - i;
        var countW = l - j;

        // if the character is repeated more in word return false.
        // or if the counts are different and the S count is less than 3 return false.
        if ((countS < countW) || (countS != countW && countS < 3))
        {
          return false;
        }

        // set i and j to new characters
        i = k;
        j = l;
      }

      // if we both reached the end then return true.
      if (i == S.Length && j == word.Length)
      {
        return true;
      }

      // otherwise we return false if one side reached end and other side did not!
      return false;
    }

    public bool CanConvert(string str1, string str2)
    {
      if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
      {
          return false;
      }

      if (str1.Equals(str2)) {
          return true;
      }

      // char seen -> char to transform
      var lookup = new Dictionary<char, char>();

      // O(n)
      for (var i = 0; i < str1.Length; i++)
      {
        if (lookup.ContainsKey(str1[i]) && lookup[str1[i]] != str2[i])
        {
          return false;
        }
        else
        {
          if (!lookup.ContainsKey(str1[i]))
          {
            lookup.Add(str1[i], str2[i]);
          }
        }
      }

      var set = new HashSet<char>(lookup.Values);

      return set.Count < 26;
    }

    public string GetHint(string secret, string guess)
    {
      int numCows = 0;
      int numBulls = 0;
      var secretLookup = new Dictionary<char, int>();

      // O(n)
      foreach (var s in secret)
      {
        if (secretLookup.ContainsKey(s))
        {
          secretLookup[s]++;
        }
        else
        {
          secretLookup.Add(s, 1);
        }
      }

      var trackBulls = new bool[secret.Length];


      // O(n)
      for (var i = 0; i < guess.Length; i++)
      {
        if (secret[i] == guess[i])
        {
          numBulls++;
          secretLookup[secret[i]]--;
          trackBulls[i] = true;
        }
      }

      // O(n)
      for (var i = 0; i < guess.Length; i++)
      {
        if (!trackBulls[i] && secretLookup.ContainsKey(guess[i]) && secretLookup[guess[i]] > 0)
        {
          numCows++;
          secretLookup[guess[i]]--;
        }
      }

      return $"{numBulls}A{numCows}B";
    }

    public class HoursMinutes
    {
      public readonly string hours;
      public readonly string minutes;

      public HoursMinutes(string hours, string minutes)
      {
        this.hours = hours;
        this.minutes = minutes;
      }

      public override string ToString()
      {
        return $"{this.hours}:{this.minutes}";
      }

      public float Difference(HoursMinutes hm)
      {
        var thisHours = int.Parse(this.hours);
        var thisMinutes = int.Parse(this.minutes);
        var hmHours = int.Parse(hm.hours);
        var hmMinutes = int.Parse(hm.minutes);
        var minutesSum = (hmMinutes + thisMinutes);
        var minutes = minutesSum % 60;
        var hours = hmHours + thisHours - 24;
        var hoursMinutes = (minutesSum / 60);
        float minutesHours = ((float)minutes / (float)60);

        return hours + hoursMinutes + minutesHours;
      }
    }

    public string NextClosestTime(string time)
    {
      var array = time.Replace(":", "").ToCharArray();
      var tokenizedStr = time.Split(':');
      var originalTime = new HoursMinutes(tokenizedStr[0], tokenizedStr[1]);
      var digits = new HashSet<char>(array);
      var timeList = new List<HoursMinutes>();

      closeTimeRec(digits, ref timeList, "");

      var minTime = time;
      var minHours = float.MaxValue;

      foreach (var t in timeList)
      {
        var hours = t.Difference(originalTime);

        if (minHours > hours)
        {
          minHours = hours;
          minTime = t.ToString();
        }
      }

      return minTime;
    }

    private void closeTimeRec(HashSet<char> symbols, ref List<HoursMinutes> results, string time)
    {
      if (time.Length == 4)
      {
        results.Add(new HoursMinutes(time.Substring(0,2), time.Substring(2, 2)));
        return;
      }

      foreach (var s in symbols)
      {
        // filter out bad times should wrap around 23:59
        if (
          time.Length == 0 && s > '2' ||
          time.Length == 1 && time[0] == '2' && s > '3' ||
          time.Length == 2 && s > '5')
        {
          continue;
        }

        closeTimeRec(symbols, ref results, time + s);
      }
    }


  }
}