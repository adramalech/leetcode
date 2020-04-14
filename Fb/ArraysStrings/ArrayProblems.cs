using System;
using System.Collections.Generic;

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

        /*
        public int RemoveDuplicates(int[] nums)
        {
            // base case if null or empty return 0.
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            var length = nums.Length;

            // base if size one return 1.
            if (length == 1)
            {
                return 1;
            }

            bool shiftRequired = false;
            var count = 0;
            var current = 0;
            var next = 1;

            while (next < length)
            {
                // if duplicate found
                var dupFound = (nums[current] == nums[next]);
                var tmpCurrent = current;

                // iterate till you don't find duplicate
                while (next < length && dupFound)
                {
                    var notDuplicate = (nums[tmpCurrent] != nums[next]);
                    nums[tmpCurrent] = nums[next];
                    tmpCurrent++;
                    next++;
                
                    if (notDuplicate)
                    {
                        shiftRequired = true;
                        // add extra count for new thing.
                        count++;
                        break;
                    }
                }

                if (dupFound)
                {
                    current = tmpCurrent;
                }
                else
                {
                    // shift everything over by one if necessary.
                    if (shiftRequired)
                    {
                        nums[current] = nums[next];
                    }

                    current++;
                    next++;
                }

                count++;
            }

            return count;
        }*/

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
    }
}