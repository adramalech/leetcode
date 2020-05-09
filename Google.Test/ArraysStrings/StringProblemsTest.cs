using Google.ArraysStrings;
using Xunit;

namespace Google.Test.ArraysStrings
{
    public class StringProblemsTest
    {
        [Theory]
        [InlineData("abcdefhi", "afi", true)]
        public void TestSymbolsMatchString(string s, string t, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.symbolsMatchString(s, t);
            
            Assert.Equal<bool>(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData("abcdefhi", "afi", "abcdefhi")]
        [InlineData("abcdefhi", "aef", "abcdef")]
        [InlineData("zwsxf", "abc", "")]
        [InlineData("zwsxf", "abcdefghij", "")]
        public void TestMinWindow(string s, string t, string expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.MinWindow(s, t);
            
            Assert.True(expectedResult.Equals(actualResult));
        }
    }
}