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
        
        [Theory]
        [InlineData("", "", true)]
        [InlineData("#", "#", true)]
        [InlineData("##", "####", true)]
        [InlineData("#", "a#", true)]
        public void TestBackspaceCompare(string S, string T, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.BackspaceCompare(S, T);
            
            Assert.Equal<bool>(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData("", "", true)]
        [InlineData("#", "#", true)]
        [InlineData("##", "####", true)]
        [InlineData("#", "a#", true)]
        [InlineData("a#c", "b", false)]
        [InlineData("bxj##tw", "bxo#j##tw", true)]
        [InlineData("bxj##tw", "bxj###tw", false)]
        [InlineData("ab##", "c#d#", true)]
        public void TestBackspaceCompareConstantSpace(string S, string T, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.BackspaceCompareConstantSpace(S, T);
            
            Assert.Equal<bool>(expectedResult, actualResult);
        }
    }
}