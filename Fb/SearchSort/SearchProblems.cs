using System;

namespace fb.SearchSort
{
    public class SearchProblems
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            if (divisor == int.MinValue && dividend != int.MinValue) {
                return 0;
            }
        
            // if the divisor is 1 the answer is always dividend else if -1 it is negating the dividend.
            if (divisor == 1)
            {
                return dividend;
            }

            if (divisor == -1)
            {
                return -dividend;
            }

            // both numbers must be less than zero or greater than zero to have postive result.
            var isResultPositive = ((dividend < 0 && divisor < 0) || (dividend > 0  && divisor > 0));

            // we want to deal with the numbers and add the sign back later.
            long abs_dividend = Math.Abs((long)dividend);
            long abs_divisor =  Math.Abs((long)divisor);

            // check if the divisor is greater than dividend fraction always less than 1.
            if (abs_dividend < abs_divisor)
            {
                return 0;
            }

            // they divisor and dividend are equal return 1.
            if (abs_divisor == abs_dividend)
            {
                return (isResultPositive ? 1 : -1);
            }

            long total = 0;

            // iterate till we cannot make any more moves.
            while (abs_dividend - abs_divisor >= 0)
            {
                int d = 0;

                // search for the largest number to subtract.
                while (abs_dividend - (abs_divisor << 1 << d) >= 0)
                {
                    d++;
                }

                total += 1 << d;
                abs_dividend -= abs_divisor << d;
            }
        
            if (total < int.MinValue) 
            {
                return int.MinValue;
            }
        
            if (total > int.MaxValue) 
            {
                return int.MaxValue;
            }

            return (isResultPositive ? (int)total : -(int)total); 
        }
        
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length < 1)
            {
                return -1;
            }
            
            // find pivot
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var middle = left + (right - left) / 2;

                if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            
            // start is the pivot point we know we are at the smallest value.
            int start = left;
            
            // reset left and right
            left = 0;
            right = nums.Length - 1;

            // if we are within a increasing range start to end.
            // set the left side to start.
            if (nums[start] <= target && target <= nums[right])
            {
                left = start;
            }
            else // else we are looking 0 to start.
            {
                right = start;
            }

            while (left <= right)
            {
                var middle = left + (right - left) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }
                
                if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else // nums[middle] < target;
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
    }
}