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

        // error:  actual value is 109,586,953,112,635,269
        //       expected value is 121,932,631,112,635,269
        [Theory]
        [InlineData("0", "10", "0")]
        [InlineData("123423423234534", "0", "0")]
        [InlineData("1", "10", "10")]
        [InlineData("1324523457575434", "1", "1324523457575434")]
        [InlineData("4", "5", "20")]
        [InlineData("20", "6", "120")]
        [InlineData("10", "10", "100")] 
        [InlineData("100", "200", "20000")]
        [InlineData("123", "456", "56088")]
        [InlineData("999", "999", "998001")]
        [InlineData("1234", "5678", "7006652")]
        [InlineData("12345", "6789", "83810205")]
        [InlineData("123456789", "987654321", "121932631112635269")]
        public void TestMultiply(string num1, string num2, string expectedValue)
        {
            var strProblems = new StringProblems();

            var actualValue = strProblems.Multiply(num1, num2);
          
            Assert.True(expectedValue.Equals(actualValue));
        }
        
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(10, 1)]
        [InlineData(89, 8)]
        [InlineData(75, 7)]
        [InlineData(55, 5)]
        [InlineData(19, 1)]
        public void TestCarry(int num, int expectedValue)
        {
            var strProblems = new StringProblems();
            
            var actualValue = strProblems.carry(num);
          
            Assert.Equal<int>(expectedValue, actualValue);
        }
        
        [Theory]
        [InlineData(0, 0)]
        [InlineData(11, 1)]
        [InlineData(25, 5)]
        [InlineData(33, 3)]
        [InlineData(48, 8)]
        [InlineData(87, 7)]
        [InlineData(6, 6)]
        public void TestDigit(int num, int expectedValue)
        {
            var strProblems = new StringProblems();
            
            var actualValue = strProblems.digit(num);
          
            Assert.Equal<int>(expectedValue, actualValue);
        }
        
        [Theory]
        [InlineData('0', '9', 0)]
        [InlineData('9', '5', 45)]
        [InlineData('3', '3', 9)]
        [InlineData('5', '4', 20)]
        [InlineData('7', '3', 21)]
        [InlineData('5', '8', 40)]
        [InlineData('6', '3', 18)]
        [InlineData('8', '0', 0)]
        public void TestMulti(char digit1, char digit2, int expectedValue)
        {
            var strProblems = new StringProblems();
            
            var actualValue = strProblems.multi(digit1, digit2);
          
            Assert.Equal<int>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("", "", false)]
        [InlineData("a", "b", false)]
        [InlineData("b", "b", false)]
        [InlineData("aba", "baa", true)]
        [InlineData("abccgabce", "gaabbeccc", true)]
        [InlineData("abccgace", "gaabbecc", false)]
        public void TestIsStringPairAnagram(string s1, string s2, bool expectedResult)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.isStringPairAnagram(s1, s2);
            
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
