using Problems.SearchSort;
using Xunit;

namespace Problems.Test.SearchSort
{
    public class SearchProblemsTest
    {
        [Theory]
        [InlineData(9, 4, 2)]
        [InlineData(1, 1, 1)]
        [InlineData(5, 3, 1)]
        [InlineData(-2, 1, -2)]
        [InlineData(6, 3, 2)]
        [InlineData(125, 25, 5)]
        [InlineData(-100, -3, 33)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        [InlineData(int.MinValue, -3, int.MaxValue / 3)]
        [InlineData(int.MaxValue, int.MinValue, 0)]
        public void TestDivide(int num1, int num2, int expectedValue)
        {
            var searchProblems = new SearchProblems();

            var actualResult = searchProblems.Divide(num1, num2);

            Assert.Equal<int>(expectedValue, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 7, 8, 1, 2, 3, 4, 5, 6 }, 2, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 4)]
        [InlineData(new int [] { 1, 3, 5 }, 1, 0)]
        [InlineData(new int[] { 5, 7, 8, 0, 3, 4 }, 7, 1)]
        public void TestSearch(int[] nums, int target, int expectedIndex)
        {
            var searchProblems = new SearchProblems();

            var actualIndex = searchProblems.Search(nums, target);

            Assert.Equal<int>(expectedIndex, actualIndex);
        }

        [Theory]
        [InlineData(new int[] {5, 7, 7, 8, 8, 10}, 8, new int[] {3, 4})]
        [InlineData(new int[] {1, 2, 3}, 2, new int[] {1, 1})]
        [InlineData(new int[] {1, 1, 2}, 1, new int[] {0, 1})]
        [InlineData(new int[] {2, 2}, 2, new int[] {0, 1})]
        [InlineData(new int[] {0, 0, 1, 2, 2}, 0, new int[] {0, 1})]
        [InlineData(new int[] {0, 0, 0, 0, 1, 2, 3, 3, 4, 5, 6, 6, 7, 8, 8, 8, 9, 9, 10, 10, 11, 11}, 0, new int[] {0, 3})]
        public void TestSearchRange(int[] nums, int target, int[] expectedResult)
        {
            var searchProblems = new SearchProblems();

            var actualResult = searchProblems.SearchRange(nums, target);

            Assert.True(actualResult[0] == expectedResult[0] && actualResult[1] == expectedResult[1]);
        }

        [Theory]
        [InlineData(new int[] {3, 2, 1, 9, 9, 4, 4}, new int[] {3, 4, 9, 5, 6}, new int[] {3, 4, 9})]
        [InlineData(new int[] {1, 2, 2, 1}, new int[] {2, 2}, new int[] {2, 2} )]
        [InlineData(new int[] { 2, 1 }, new int[] { 1, 1 }, new int[] { 1 })]
        public void TestIntersection(int[] num1, int[] num2, int[] expectedResult)
        {
            var searchProblems = new SearchProblems();

            var actualResult = searchProblems.Intersection(num1, num2);

            Assert.Equal<int>(expectedResult.Length, actualResult.Length);

            for (var i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal<int>(expectedResult[i], actualResult[i]);
            }
        }

        [Theory]
        [InlineData(new int[] {3, 2, 1, 9, 9, 4, 4}, new int[] {3, 4, 9, 5, 6}, new int[] {3, 4, 9})]
        [InlineData(new int[] {1, 2, 2, 1}, new int[] {2, 2}, new int[] {2, 2} )]
        [InlineData(new int[] { 2, 1 }, new int[] { 1, 1 }, new int[] { 1 })]
        public void TestIntersection2(int[] num1, int[] num2, int[] expectedResult)
        {
            var searchProblems = new SearchProblems();

            var actualResult = searchProblems.Intersection2(num1, num2);

            Assert.Equal<int>(expectedResult.Length, actualResult.Length);

            for (var i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal<int>(expectedResult[i], actualResult[i]);
            }
        }

        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        public void TestIsAnagram(string s, string t, bool expectedOutput)
        {
            var searchProblems = new SearchProblems();

            var actualOutput = searchProblems.IsAnagram(s, t);
            
            Assert.Equal<bool>(expectedOutput, actualOutput);
        }
        
        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        public void TestIsAnagramSort(string s, string t, bool expectedOutput)
        {
            var searchProblems = new SearchProblems();

            var actualOutput = searchProblems.IsAnagramSort(s, t);
            
            Assert.Equal<bool>(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(new int[] {5, 2, 6, 1}, new int[] {2, 1, 1, 0})]
        public void TestCountSmallerBruteForce(int[] input, int[] expected)
        {
            var searchProblems = new SearchProblems();

            var actual = searchProblems.CountSmallerBruteForce(input);

            Assert.Equal<int>(expected.Length, actual.Count);
            
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.Equal<int>(expected[i], actual[i]);
            }
        }
    }
}