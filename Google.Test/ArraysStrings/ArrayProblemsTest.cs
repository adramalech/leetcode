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

        [Fact]
        public void TestRotateSimple2By2()
        {
            var nums = new int[2][] { new int[] {1, 2}, new int[] {3, 4} };
            var expectedOutput = new int[2][] { new int[] {3, 1}, new int[] {4, 2} };
            
            var arrayProblems = new ArrayProblems();
            
            arrayProblems.Rotate(ref nums);

            // check for equality in 2d array.
            for (var i = 0; i < expectedOutput.Length; i++)
            {
                for (var j = 0; j < expectedOutput[i].Length; j++)
                {
                    Assert.Equal<int>(expectedOutput[i][j], nums[i][j]);
                }
            }
        }
        
        [Fact]
        public void TestRotateSimple3By3()
        {
            var nums = new int[3][] { new int[] {1, 2, 3}, new int[] {4, 5, 6}, new int[] {7, 8, 9} };
            var expectedOutput = new int[3][] { new int[] {7, 4, 1}, new int[] {8, 5, 2}, new int[] {9, 6, 3} };
            
            var arrayProblems = new ArrayProblems();
            
            arrayProblems.Rotate(ref nums);

            // check for equality in 2d array.
            for (var i = 0; i < expectedOutput.Length; i++)
            {
                for (var j = 0; j < expectedOutput[i].Length; j++)
                {
                    Assert.Equal<int>(expectedOutput[i][j], nums[i][j]);
                }
            }
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int [] { 1, 2 })]
        public void TestTwoSum(int[] nums, int target, int[] expectedResult)
        {
            var arrayProblems = new ArrayProblems();

            var actualResult = arrayProblems.TwoSum(nums, target);

            Assert.Equal<int>(expectedResult.Length, actualResult.Length);
            
            for (var i = 0; i < 2; i++)
            {
                Assert.Equal<int>(expectedResult[i], actualResult[i]);
            }
        }
    }
}