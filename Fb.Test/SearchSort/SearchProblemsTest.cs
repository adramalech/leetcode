using fb.SearchSort;
using Xunit;

namespace Fb.Test.SearchSort
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
    }
}