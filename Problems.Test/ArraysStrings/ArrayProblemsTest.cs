using Xunit;
using Problems.ArraysStrings;

namespace Problems.Test.ArraysStrings
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

            Assert.NotNull(list);
            Assert.NotEmpty(list);

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

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int [] { -1, 1 }, 2)]
        public void TestProductExceptSelfBruteForce(int[] nums, int expectedCount)
        {
            var arrayProblems = new ArrayProblems();

            var actualResults = arrayProblems.ProductExceptSelf(nums);

            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Length);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int [] { -1, 1 }, 2)]
        public void TestProductExceptSelfLinear(int[] nums, int expectedCount)
        {
            var arrayProblems = new ArrayProblems();

            var actualResults = arrayProblems.ProductExceptSelfLinear(nums);

            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Length);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int [] { -1, 1 }, 2)]
        public void TestProductExceptSelfLinearConstantSpace(int[] nums, int expectedCount)
        {
            var arrayProblems = new ArrayProblems();

            var actualResults = arrayProblems.ProductExceptSelfLinearConstantSpace(nums);

            Assert.NotNull(actualResults);
            Assert.NotEmpty(actualResults);
            Assert.Equal<int>(expectedCount, actualResults.Length);
        }

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

        [Theory]
        [InlineData(new int[] {1}, 1, 1)]
        [InlineData(new int[] {2, 1}, 1, 2)]
        [InlineData(new int[] {1, 2, 4, 3, 5, 6}, 2, 5)]
        public void TestFindKthLargest(int[] nums, int k, int expectedResult)
        {
            var arrayProblems = new ArrayProblems();

            var actualResult = arrayProblems.FindKthLargest(nums, k);

            Assert.Equal<int>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 0 }, new int[] { 1 })]
        [InlineData(new int[] { 9 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 5 })]
        [InlineData(new int[] { 9, 9, 9, 9, 9 }, new int[] { 1, 0, 0, 0, 0, 0 })]
        public void TestPlusOne(int[] digits, int[] expectedResult)
        {
            var arrayProblems = new ArrayProblems();

            var actualResult = arrayProblems.PlusOne(digits);

            Assert.Equal<int>(expectedResult.Length, actualResult.Length);

            for (var i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal<int>(expectedResult[i], actualResult[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 2, true)]
        public void TestIsNStraightHand(int[] hand, int W, bool expectedResult)
        {
            var arrayProblems = new ArrayProblems();

            var actualResult = arrayProblems.IsNStraightHand(hand, W);

            Assert.True(expectedResult == actualResult);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11 }, 3, true)]
        [InlineData(new int[] { 1, 2, 3, 3, 4, 4, 5, 6 }, 4, true)]
        [InlineData(new int[] { 3, 3, 2, 2, 1, 1 }, 3, true)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 3, false)]
        public void TestIsPossibleDivide(int[] nums, int k, bool expectedResult)
        {
            var arrayProblems = new ArrayProblems();

            var actualResult = arrayProblems.IsPossibleDivide(nums, k);

            Assert.True(expectedResult == actualResult);
        }
    }
}