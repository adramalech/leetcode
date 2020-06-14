using System.Linq;
using Problems.TreesGraphs;
using Xunit;

namespace Problems.Test.TreesGraphs
{
    public class GraphProblemsTest
    {
        [Theory]
        [InlineData("a", "b", new string[] { "a", "b", "c" }, 2)]
        [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }, 5)]
        public void TestLadderLengthBruteForce(string begin, string end, string[] wordList, int expectedCount)
        {
            var graphProblems = new GraphProblems();

            var actualCount = graphProblems.LadderLengthBruteForce(begin, end, wordList.ToList());

            Assert.Equal<int>(expectedCount, actualCount);
        }

        [Theory]
        [InlineData("a", "b", new string[] { "a", "b", "c" }, 2)]
        [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }, 5)]
        public void TestLadderLength(string begin, string end, string[] wordList, int expectedCount)
        {
            var graphProblems = new GraphProblems();

            var actualCount = graphProblems.LadderLength(begin, end, wordList.ToList());

            Assert.Equal<int>(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(new string[] { "a", "b", "c", "d", "e", "f", "g", "h"  }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, true)]
        [InlineData(new string[] { "a", "b", "c", "d", "a", "a", "g", "h"  }, new int[] { 5, 6, 7 }, true)]
        [InlineData(new string[] {  }, new int[] { }, true)]
        [InlineData(new string[] { "a", "b", "c", "d", "e", "f", "g", "h"  }, new int[] { 7, 6, 1, 4, 5, 6, 7, 8 }, false)]
        [InlineData(new string[] { "a", "b", "c", "d", "e", "f", "g", "h"  }, new int[] { 1, 2, 6, 7 }, false)]
        [InlineData(new string[] { "a", "a", "a", "a", "a", "a"  }, new int[] { 5 }, true)]
        public void TestValidateJumpPaths(string[] arr, int[] steps, bool expectedResult)
        {
            var graphProblems = new GraphProblems();

            var actualResult = graphProblems.ValidateJumpPaths(arr, steps);

            Assert.True(expectedResult == actualResult);
        }
    }
}