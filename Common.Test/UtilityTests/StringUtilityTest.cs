using Common.Utils;
using Xunit;

namespace Common.Test.UtilityTests
{
    public class StringUtilityTest
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("a", true)]
        [InlineData("ab", false)]
        [InlineData("aba", true)]
        public void TestIsPalindrome(string s, bool expectedValue)
        {
            var actualValue = StringUtility.IsPalindrome(s);
            
            Assert.Equal<bool>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("abc", true)]
        [InlineData("abcdefg2349", true)]
        [InlineData("abceeefggg", false)]
        [InlineData("  a  ", false)]
        public void TestIsStringUnique(string s, bool expectedValue)
        {
            var actualValue = StringUtility.AreAllCharactersUnique(s);
            
            Assert.Equal<bool>(expectedValue, actualValue);
        }
        
        [Theory]
        [InlineData('0', 0)]
        [InlineData('a', 0)]
        [InlineData('1', 1)]
        [InlineData('9', 9)]
        public void TestConvertCharToDigit(char s, int expectedValue)
        {
            var actualValue = StringUtility.ConvertCharToDigit(s);
            
            Assert.Equal<int>(expectedValue, actualValue);
        }
    }
}