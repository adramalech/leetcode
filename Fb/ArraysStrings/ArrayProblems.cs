using System;
using System.Collections.Generic;
using System.Linq;

namespace Fb.ArraysStrings
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
            
            // space complexity O(n)
            var results = new List<int>();
            
            // O(n^2) overall
            // search O(n)
            for (var i = 0; i < nums.Length; i++)
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
                
                results.Add(product);
            }
            
            return results.ToArray();
        }
    }
}