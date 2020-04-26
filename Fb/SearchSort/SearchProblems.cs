using System;
using System.Collections.Generic;
using System.Linq;

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

        public int[] SearchRange(int[] nums, int target)
        {
            var indices = new int[] { -1, -1 };

            // empty
            if (nums == null || nums.Length < 1)
            {
                return indices;
            }

            if (nums.Length == 2)
            {
                if (nums[0] == target)
                {
                    indices[0] = 0;

                    indices[1] = (nums[1] == target ? 1 : 0);
                }
                else if (nums[1] == target)
                {
                    indices[0] = 1;
                    indices[1] = 1;
                }

                return indices;
            }

            var left = 0;
            var right = nums.Length - 1;
            int middle = right / 2;

            while (left <= right)
            {
                middle = left + (right - left) / 2;

                // we found it!
                if (nums[middle] == target)
                {
                    break;
                }

                if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            // if we didn't find anything return.
            if (left > right)
            {
                return indices;
            }

            left = middle;
            right = middle;

            // grow both right and left
            while (left - 1 >= 0 && right + 1 < nums.Length)
            {
                if (nums[left - 1] != target && nums[right + 1] != target)
                {
                    break;
                }

                if (nums[left - 1] == target)
                {
                    left--;
                }

                if (nums[right + 1] == target)
                {
                    right++;
                }
            }

            // grow right
            while (right + 1 < nums.Length)
            {
                if (nums[right + 1] != target)
                {
                    break;
                }

                right++;
            }

            // grow left
            while (left - 1 >= 0)
            {
                if (nums[left - 1] != target)
                {
                    break;
                }

                left--;
            }


            // else we found something!
            indices[0] = left;
            indices[1] = right;

            return indices;
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length < 1 || nums2 == null || nums2.Length < 1)
            {
                return new int[0];
            }

            var results = new HashSet<int>();
            var lookup = new Dictionary<int, List<int>>();

            // O(n)
            for (var i = 0; i < nums1.Length; i++)
            {
                if (lookup.ContainsKey(nums1[i]))
                {
                    lookup[nums1[i]].Add(i);
                }
                else
                {
                    lookup.Add(nums1[i], new List<int>(){ i });
                }
            }

            // O(m)
            foreach (var n in nums2)
            {
                if (lookup.ContainsKey(n) && lookup[n] != null && lookup[n].Count > 0)
                {
                    results.Add(n);
                    lookup[n].RemoveAt(0);
                }
            }

            return results.ToArray();
        }

        // bug in it from breaking on repeated.
        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length < 1 || nums2 == null || nums2.Length < 1)
            {
                return new int[0];
            }

            var results = new List<int>();
            var lookup = new Dictionary<int, List<int>>();

            if (nums1.Length >= nums2.Length)
            {
                // O(n)
                for (var i = 0; i < nums1.Length; i++)
                {
                    if (lookup.ContainsKey(nums1[i]))
                    {
                        lookup[nums1[i]].Add(i);
                    }
                    else
                    {
                        lookup.Add(nums1[i], new List<int>(){ i });
                    }
                }

                // O(m)
                foreach (var n in nums2)
                {
                    if (lookup.ContainsKey(n) && lookup[n] != null && lookup[n].Count > 0)
                    {
                        results.Add(n);
                        lookup[n].RemoveAt(0);
                    }
                }
            }
            else
            {
                // O(m)
                for (var i = 0; i < nums2.Length; i++)
                {
                    if (lookup.ContainsKey(nums2[i]))
                    {
                        lookup[nums2[i]].Add(i);
                    }
                    else
                    {
                        lookup.Add(nums2[i], new List<int>(){ i });
                    }
                }

                // O(n)
                foreach (var n in nums1)
                {
                    if (lookup.ContainsKey(n) && lookup[n] != null && lookup[n].Count > 0)
                    {
                        results.Add(n);
                        lookup[n].RemoveAt(0);
                    }
                }
            }

            return results.ToArray();
        }
    }
}