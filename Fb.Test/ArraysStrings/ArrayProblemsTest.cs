using System;
using Xunit;
using Fb.ArraysStrings;

namespace Fb.Test.ArraysStrings
{
    public class ArrayProblemsTest
    {
        [Fact]
        public void TestBasicArrayInts()
        {
            var arrayProblems = new ArrayProblems();

            var list = arrayProblems.ThreeSums(new int[] {-1, 0, 1, 2, -1, -4});
            
            Assert.True(list != null);
            Assert.True(list.Count == 2);
        }

        [Fact]
        public void TestArraySumIntsRepeating()
        {
            var arrayProblems = new ArrayProblems();

            var list = arrayProblems.ThreeSums(new int[] {-2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 2});
            
            Assert.True(list != null);
            Assert.True(list.Count == 3);
        }

        [Fact]
        public void InputWithDuplicateNumbersShouldReturnOnlyOnce()
        {
            var arrayProblems = new ArrayProblems();

            var list = arrayProblems.ThreeSums(new int[] {3, 0, -2, -1, 1, 2});
            
            Assert.True(list != null);
            Assert.True(list.Count == 1);
        }
        
        [Fact]
        public void InputRemoveDuplicates()
        {
            var arrayProblems = new ArrayProblems();
            const int expectedLength = 2;

            var nums = new int[] {1, 1};

            var actualLength = arrayProblems.RemoveDuplicates(nums);
            
            Assert.Equal<int>(expectedLength, actualLength);
        }
        
        [Fact]
        public void InputRemoveLargeNumDups()
        {
            var arrayProblems = new ArrayProblems();
            const int expectedLength = 5;

            var nums = new int[] {1, 1, 1, 1, 1, 1, 1, 1, 4, 5, 6, 7};

            var actualLength = arrayProblems.RemoveDuplicates(nums);
            
            Assert.Equal<int>(expectedLength, actualLength);
        }
    }
}