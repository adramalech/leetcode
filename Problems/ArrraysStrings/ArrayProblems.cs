using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysStrings
{
    public class ArrayProblems
    {
        public IList<IList<int>> ThreeSums(int[] nums)
        {
            int target = 0;
            var results = new List<IList<int>>();
            
            if (nums == null || nums.Length < 3)
            {
                return results;
            }
            
            var length = nums.Length;
            
            if (length == 3)
            {
                if (nums[0] + nums[1] + nums[2] == 0)
                {
                    results.Add(new List<int>(nums));
                }
                
                return results;
            }

            // O(n * log(n))
            Array.Sort(nums);
            
            var noDups = new Dictionary<string, int>();

            // O(n^2)
            for (var current = 0; current < length - 2; current++)
            {
                var left = current + 1;
                var right = length - 1;
                var targetPick = target - nums[current];
                
                while (left < right)
                {
                    var windowSum = nums[left] + nums[right];

                    // if we found one add it to the results and break out of this loop.
                    if (targetPick == windowSum)
                    {
                        // create a symbol to use for insert to list duplication.
                        var str = $"{nums[current]}{nums[left]}{nums[right]}";
                        
                        // check for duplicates if they exist skip.
                        if (!noDups.ContainsKey(str))
                        {
                            results.Add(new List<int>(new int[] {nums[current], nums[left], nums[right]}));
                            noDups.Add(str, 1);
                        }
                        
                        // success shrink window in both sides.
                        left++;
                        right--;
                    }
                    else if (targetPick < windowSum) // the number is too large move down window to smaller numbers.
                    {
                        right--;
                    }
                    else  // the number is smaller move move up to greater numbers.
                    {
                        left++;
                    }
                }
            }

            return results;
        }

        public int RemoveDuplicates(int[] nums)
        {
            // base case if null or empty return 0.
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            var length = nums.Length;
            var maxIndexValue = length - 1;

            // base if size one return 1.
            if (length == 1)
            {
                return 1;
            }

            var size = 0;
            var current = 0;
            var next = 1;

            while (next < length)
            {
                while (next < length && nums[current] == nums[next]) 
                {
                    if (next >= maxIndexValue)
                    {
                        break;
                    }

                    current++;
                    next++;
                }

                nums[size] = nums[current];
                size++;

                if (next + 1 > maxIndexValue && nums[current] != nums[next]) {
                    nums[size] = nums[next];
                    size++;
                    break;
                }

                current++;
                next++;
            }

            return size;
        }

        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return;
            }

            // if it is a trivial size 2
            if (nums.Length == 2)
            {
                // if they are the same like 00, 11, 22, ... 99. return.
                if (nums[0] == nums[1])
                {
                    return;
                }
                
                // these are either high low or low high.
                // high - 98 41 20 -- if array this would result in ordering the array ascending 89, 14, 20
                // low - 19 48 36  -- if we are low this would result in next highest permutation. 91, 84, 63
                int tmp = nums[0];
                nums[0] = nums[1];
                nums[1] = tmp;
                return;
            }
            
            // length is 3 or greater.
            int length = nums.Length;
            int left = length - 2;
            int right = length - 1;
            int suffixLeftValue = length;

            while (left >= 0)
            {
                // if the left value is greater than the right value move left.
                if (nums[left] > nums[right])
                {
                    left--;
                    suffixLeftValue = left;
                }
                else
                {
                    break;
                }
            }

            if (suffixLeftValue == 0)
            {
                // cannot go any further.
                return;
            }
            
            
        }

        // brute force O(n^2) complexity with O(n) space
        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return null;
            }

            int length = nums.Length;

            var results = new int[length];


            // O(n^2) overall
            // search O(n)
            for (var i = 0; i < length; i++)
            {
                int product = int.MaxValue;
                
                // product O(n)
                for (var j = 0; j < nums.Length; j++)
                {
                    // skip elements that are the same element.
                    if (j == i)
                    {
                        continue;
                    }
                    
                    // seed the product value or multiply.
                    product = (product != int.MaxValue) ? product * nums[j] : nums[j];
                }
                
                results[i] = product;
            }
            
            return results;
        }

        // time O(n) but space is O(n)
        public int[] ProductExceptSelfLinear(int[] nums)
        {
            var length = nums.Length;
            
            var lr = new int[length];
            lr[0] = 1;
            
            var rl = new int[length];
            rl[length - 1] = 1;

            var results = new int[length];

            // left to right iterate O(n - 1)
            for (var i = 1; i < length; i++)
            {
                lr[i] = nums[i - 1] * lr[i - 1];
            }

            // right to left iterate O(n - 1)
            for (var i = length - 2; i > 0; i--)
            {
                rl[i] = nums[i + 1] * rl[i + 1];
            }

            // iterate through multiplying partial products O(n)
            for (var i = 0; i < length; i++)
            {
                results[i] = lr[i] * rl[i];
            }

            return results;
        }
        
        // time complexity O(n)
        // space is O(n)
        public int[] ProductExceptSelfLinearConstantSpace(int[] nums)
        {
            // space O(n + 2)
            var length = nums.Length;
            int tmpNum = 1;
            var results = new int[length];
            results[0] = 1;
            
            // left to right iterate O(n - 1)
            for (var i = 1; i < length; i++)
            {
                results[i] = nums[i - 1] * results[i - 1];
            }

            for (var i = length - 1; i >= 0; i--)
            {
                results[i] *= tmpNum;
                tmpNum *= nums[i];
            }

            return results;
        }
        
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
        
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2) 
            {
                throw new ArgumentException("Cannot find sum of array less than two elements!");
            }

            var lookup = new Dictionary<int, List<int>>();

            int s;

            // O(n)
            for (var i = 0; i < nums.Length; i++)
            {
                s = target - nums[i];
                if (lookup.ContainsKey(s))
                {
                    return new int[] { lookup[s].FirstOrDefault(), i };
                }

                if (lookup.ContainsKey(nums[i])) 
                {
                    lookup[nums[i]].Add(i);
                }
                else 
                {
                    lookup.Add(nums[i], new List<int>() { i });
                }
            }

            throw new ArgumentException("Cannot find sum, required to find exactly one match!");
        }
    }
}