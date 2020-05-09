using System;

namespace Google.ArraysStrings
{
    public class ArrayProblems
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
            {
                return 0;
            }

            var left = 0;
            var right = height.Length - 1;
            var maxTotalArea = 0;
            var lrBase = 0;
            var currentArea = 0;
            
            do
            {
                lrBase = right - left;
                currentArea = (height[left] <= height[right]) ? lrBase * height[left] : lrBase * height[right];

                if (currentArea > maxTotalArea)
                {
                    maxTotalArea = currentArea;
                }

                if (height[left] > height[right])
                {
                    right--;
                }
                else if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    left++;
                    right--;
                }
            } while (left < right);
            
            return maxTotalArea;
        }
        
        /*
          https://www.nayuki.io/page/next-lexicographical-permutation-algorithm
         */
        public void NextPermutation(ref int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return;
            }

            var left = nums.Length - 1;

            // find the suffix.
            while (left > 0 && nums[left - 1] >= nums[left] )
            {
                left--;
            }

            // we are at the end and nothing else can be done.
            if (left <= 0)
            {
                // arrange the elements in sorted order.
                Array.Sort(nums);
                
                return;
            }
            
            var right = nums.Length - 1;

            while (nums[right] <= nums[left - 1])
            {
                right--;
            }

            // swap pivot with left side of suffix.
            var tmp = nums[left - 1];
            nums[left - 1] = nums[right];
            nums[right] = tmp;

            right = nums.Length - 1;
            
            // re-order suffix range.
            while (left < right)
            {
                tmp = nums[right];
                nums[right] = nums[left];
                nums[left] = tmp;
                left++;
                right--;
            }
        }

        public void Rotate(ref int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1 || matrix[0].Length < 1)
            {
                return;
            }

            var height = matrix.Length;
            var width = matrix[0].Length;

            if (height != width)
            {
                return;
            }

            int tmp;
            var n = width - 1;

            for (var i = 0; i < (width + 1) / 2; i++)
            {
                for (var j = 0; j < width / 2; j++)
                {
                    tmp = matrix[n - j][i];
                    matrix[n - j][i] = matrix[n - i][n - j];
                    matrix[n - i][n - j] = matrix[j][n - i];
                    matrix[j][n - i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }
        }
    }
}