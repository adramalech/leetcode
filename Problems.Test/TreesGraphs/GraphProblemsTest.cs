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
    }
}