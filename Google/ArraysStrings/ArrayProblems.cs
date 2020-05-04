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
    }
}