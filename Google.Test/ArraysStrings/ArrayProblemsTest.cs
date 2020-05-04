using Google.ArraysStrings;
using Xunit;

namespace Google.Test.ArraysStrings
{
    public class ArrayProblemTests
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData(new int[] { 5, 6 }, 5)] // 1 * 5 = 10
        [InlineData(new int[] { 12 }, 0)] // 0 * 12 = 0
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)] // 7 * 7 = 49
        public void TestMaxArea(int[] nums, int expectedMaxArea)
        {
            var arrayProblems = new ArrayProblems();

            var actualMaxArea = arrayProblems.MaxArea(nums);
            
            Assert.Equal<int>(expectedMaxArea, actualMaxArea);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]
        [InlineData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        public void TestNextPermutation(int[] nums, int[] expectedOutput)
        {
            var arrayProblems = new ArrayProblems();

            arrayProblems.NextPermutation(ref nums);

            for (var i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal<int>(expectedOutput[i], nums[i]);
            }
        }
    }
}