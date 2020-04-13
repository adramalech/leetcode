using Xunit;
using Fb.ArraysStrings;

namespace Fb.Test.ArraysStrings
{
    public class StringProblemsTests
    {
        [Fact]
        public void GivingStringOfLengthOneShouldReturnSubstringLengthOne() {
          var strProblems = new StringProblems();
          const int expectedLength = 1;

          var actualLength = strProblems.LengthOfLongestSubstring(" ");

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Fact]
        public void GivingUniqueStringOfLengthTwoShouldReturnSubstringLengthTwo() {
          var strProblems = new StringProblems();
          const int expectedLength = 2;

          var actualLength = strProblems.LengthOfLongestSubstring("ab");

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Fact]
        public void GivingNonUniqueStringOfLengthTwoShouldReturnSubstringLengthTwo() {
          var strProblems = new StringProblems();
          const int expectedLength = 1;

          var actualLength = strProblems.LengthOfLongestSubstring("aa");

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Fact]
        public void InputStringRepeatingCharacterShouldReturnSubstringLengthOne() {
          var strProblems = new StringProblems();
          const int expectedLength = 1;

          var actualLength = strProblems.LengthOfLongestSubstring("aaaa");

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Fact]
        public void InputStringComplexShouldResultInSix() {
          var strProblems = new StringProblems();
          const int expectedLength = 6;

          var actualLength = strProblems.LengthOfLongestSubstring("ohvhjdml");

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Fact]
        public void InputNumberShouldResultInIntValueEvenWithJunkFollowing()
        {
          var strProblems = new StringProblems();
          const int expectedValue = 2342;

          var actualLength = strProblems.Atoi(" +2342 h  -222222222 here i am test!");
          
          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Fact]
        public void InputNumberShouldResultInIntValueWhenSurroundedByWhitespace()
        {
          var strProblems = new StringProblems();
          const int expectedValue = 2342;

          var actualLength = strProblems.Atoi("    2342   ");
          
          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Fact]
        public void InputNumberIfTooLongWillReturnMinValue()
        {
          var strProblems = new StringProblems();
          const int expectedValue = int.MinValue;

          var actualLength = strProblems.Atoi("-12345678900");
          
          Assert.Equal<int>(expectedValue, actualLength);
        }
        
        [Fact]
        public void InputNumberIfTooLongWillReturnMaxValue()
        {
          var strProblems = new StringProblems();
          const int expectedValue = int.MaxValue;

          var actualLength = strProblems.Atoi("2147483649");
          
          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Fact]
        public void InputNumberZerosShouldDropOff()
        {
          var strProblems = new StringProblems();
          const int expectedValue = 0;
          
          var actualLength = strProblems.Atoi("0-1");
          
          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Fact]
        public void RomanNumerialToIntEasy()
        {
          var strProblems = new StringProblems();
          const int expectedValue = 14;

          var actualValue = strProblems.RomanNumerialToInt("XIV");
          
          Assert.Equal<int>(expectedValue, actualValue);
        }
        
        [Fact]
        public void RomanNumerialToIntHard()
        {
          var strProblems = new StringProblems();
          const int expectedValue = 621;

          var actualValue = strProblems.RomanNumerialToInt("DCXXI");
          
          Assert.Equal<int>(expectedValue, actualValue);
        }
    }
}
