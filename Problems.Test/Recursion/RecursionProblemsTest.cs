using System.Collections.Generic;
using Problems.Recursion;
using Xunit;

namespace Problems.Test.Recursion
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
        [InlineData(")(", 1)] // [""]
        [InlineData("()())()", 2)] // ["()()()", "(())()"]
        [InlineData("((()))", 1)] // [ "((()))" ]
        [InlineData(")(())(", 1)] // [ "(())" ]
        [InlineData("()", 1)]
        [InlineData("(())", 1)]
        [InlineData("()(()())", 1)]
        [InlineData("(()(", 1)]
        [InlineData("(()", 1)]
        [InlineData("(()))", 1)]
        [InlineData("((()))((()(()", 2)]
        public void TestRemoveInvalidParentheses(string input, int expectedCount)
        {
            var recProblems = new RecursionProblems();

            var actualResults = recProblems.RemoveInvalidParentheses(input);
            
            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Count);
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3}, 6)]
        public void TestPermutation(int[] nums, int expectedCount)
        {
            var recProblems = new RecursionProblems();

            var actualResults = recProblems.Permute(nums);
            
            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Count);
        }
        
        [Theory]
        [InlineData(new int[] {1, 2, 1}, 3)]
        public void TestUniquePermutation(int[] nums, int expectedCount)
        {
            var recProblems = new RecursionProblems();

            var actualResults = recProblems.PermuteUnique(nums);
            
            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Count);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("(())", true)]
        [InlineData("()(()())", true)]
        [InlineData(")(", false)]
        [InlineData("(()(", false)]
        [InlineData("(()", false)]
        [InlineData("(()))", false)]
        public void TestDoesStringHaveValidParetheses(string s, bool expectedResult)
        {
            var recProblems = new RecursionProblems();
            
            var actualResult = recProblems.doesStringHaveValidParetheses(s);
            
            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
        [InlineData(4, new string[] { 
            "(((())))",
            "((()()))",
            "((())())",
            "((()))()",
            "(()(()))",
            "(()()())",
            "(()())()",
            "(())(())",
            "(())()()",
            "()((()))",
            "()(()())",
            "()(())()",
            "()()(())",
            "()()()()" 
        })]
        public void GenerateParenthesis(int n, string[] expectedResults)
        {
            var recProblems = new RecursionProblems();
            
            var actualResult = recProblems.GenerateParenthesis(n);

            Assert.Equal<int>(expectedResults.Length, actualResult.Count);
            
            for (var i = 0; i < expectedResults.Length; i++)
            {
                Assert.True(expectedResults[i].Equals(actualResult[i]));
            }
        } 
    }
}