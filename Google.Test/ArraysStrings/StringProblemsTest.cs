using Google.ArraysStrings;
using Xunit;

namespace Google.Test.ArraysStrings
{
    public class StringProblemsTest
    {
        [Theory]
        [InlineData("abcdefhi", "afi", "abcdefhi")]
        [InlineData("abcdefhi", "aef", "abcdef")]
        [InlineData("zwsxf", "abc", "")]
        [InlineData("zwsxf", "abcdefghij", "")]
        [InlineData("bba", "ab", "ba")]
        public void TestMinWindow(string s, string t, string expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.MinWindow(s, t);
            
            Assert.True(expectedResult.Equals(actualResult));
        }
    }
}