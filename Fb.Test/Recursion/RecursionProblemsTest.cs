using fb.Recursion;
using Xunit;

namespace Fb.Test.Recursion
{
    public class RecursionProblemsTest
    {
        [Theory]
        [InlineData("23", 9)]
        public void TestLetterCombinations(string nums, int expectedCount)
        {
            var recProblems = new RecursionProblems();

            var actualResult = recProblems.LetterCombinations(nums);
            
            Assert.NotNull(actualResult);
            Assert.NotEmpty(actualResult);
            Assert.Equal<int>(expectedCount, actualResult.Count);
        }

        [Theory]
        [InlineData(")(", 0)] // [""]
        [InlineData("()())()", 2)] // ["()()()", "(())()"]
        public void TestRemoveInvalidParentheses(string input, int expectedCount)
        {
            var recProblems = new RecursionProblems();

            var actualResults = recProblems.RemoveInvalidParentheses(input);
            
            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Count);
        }
    }
}