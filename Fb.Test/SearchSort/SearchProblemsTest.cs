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
    }
}