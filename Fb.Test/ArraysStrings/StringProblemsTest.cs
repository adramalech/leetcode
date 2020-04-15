using Xunit;
using Fb.ArraysStrings;

namespace Fb.Test.ArraysStrings
{
    public class StringProblemsTests
    {
        [Theory]
        [InlineData(" ", 1)]
        [InlineData("aa", 1)]
        [InlineData("aaaa", 1)]
        [InlineData("ab", 2)]
        [InlineData("ohvhjdml", 6)]
        public void TestLengthOfLongestSubstring(string s, int expectedLength) {
          var strProblems = new StringProblems();

          var actualLength = strProblems.LengthOfLongestSubstring(s);

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Theory]
        [InlineData("    2342   ", 2342)]
        [InlineData("-12345678900", int.MinValue)]
        [InlineData("2147483649", int.MaxValue)]
        [InlineData("0-1", 0)]
        public void TestAtoi(string s, int expectedValue)
        {
          var strProblems = new StringProblems();

          var actualLength = strProblems.Atoi(s);
          
          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Theory]
        [InlineData("XIV", 14)]
        [InlineData("XCIX", 99)]
        [InlineData("DCXXI", 621)]
        [InlineData("DCCLVI", 756)]
        [InlineData("MMXX", 2020)]
        [InlineData("MMMCMXCIX", 3999)]
        public void TestRomanNumerial(string s, int expectedValue)
        {
          var strProblems = new StringProblems();

          var actualValue = strProblems.RomanNumerialToInt(s);
          
          Assert.Equal<int>(expectedValue, actualValue);
        }
    }
}
