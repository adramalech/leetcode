using Xunit;
using Fb.ArraysStrings;

namespace Fb.Test.ArraysStrings
{
    public class ArrayProblemsTest
    {
        [Theory]
        [InlineData(new int[] {-1, 0, 1}, 1)]
        [InlineData(new int[] {-1, 0, 1, 2, -1, -4}, 2)]
        public void TestThreeSums(int[] nums, int count)
        {
            var arrayProblems = new ArrayProblems();

            var list = arrayProblems.ThreeSums(nums);
            
            Assert.True(list != null);

            var actualCount = list.Count;
            
            Assert.True(actualCount == count);
        }

        [Theory]
        [InlineData(new int[] {1}, 1)]
        [InlineData(new int[] {1,1}, 1)]
        [InlineData(new int[] {1,1,1,1}, 1)]
        [InlineData(new int[] {1,1,2,2}, 2)]
        [InlineData(new int[] {2,2,2,3,4}, 3)]
        [InlineData(new int[] {1,2,2,3,3,3,4,4,4,4}, 4)]
        [InlineData(new int[] {1,2,3,3,3,4,5,5,5,5,5}, 5)]
        [InlineData(new int[] {1, 2, 2, 2, 2, 2, 3, 3, 4, 5, 6}, 6)]
        public void TestRemoveDuplicates(int[] nums, int size)
        {
            var arrayProblems = new ArrayProblems();
            var actualLength = arrayProblems.RemoveDuplicates(nums);
            
            Assert.Equal<int>(size, actualLength);
        }
    }
}