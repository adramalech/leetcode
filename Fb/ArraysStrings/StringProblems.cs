using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils;

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
      const string zero = "0";
      
      if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1) ||
          string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num2) ||
          num1 == zero || num2 == zero
      ) {
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
          sumDigitsPlacesLookup.Add(shift, new List<int>() { d });
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
              g = new List<string>() { group[i] };
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
              results.Add(new List<string>() { group[k] });
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
        int sum = StringUtility.ConvertCharToDigit(a[i]) + StringUtility.ConvertCharToDigit(b[j]) + StringUtility.ConvertCharToDigit(carry);
        
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
    public int multi(char num1, char num2) => StringUtility.ConvertCharToDigit(num1) * StringUtility.ConvertCharToDigit(num2);
    
    public int carry(int num) => (int)(Math.Floor(((double)num) / 10));

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
  }
}