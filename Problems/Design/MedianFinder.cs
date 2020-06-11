using System;
using System.Collections.Generic;

namespace Problems.Design
{
  /**
  * Your MedianFinder object will be instantiated and called as such:
  * MedianFinder obj = new MedianFinder();
  * obj.AddNum(num);
  * double param_2 = obj.FindMedian();
  */
  public class MedianFinder
  {
    private List<int> nums;

    /** initialize your data structure here. */
    public MedianFinder()
    {
      this.nums = new List<int>();
    }

    public void AddNum(int num)
    {
      this.nums.Add(num);
    }

    public double FindMedian()
    {
      // O(n * log(n))
      this.nums.Sort();

      var isEvenSize = this.nums.Count % 2 == 0;

      var middle = this.nums.Count / 2;

      double median = isEvenSize ? (double)(this.nums[middle] + this.nums[middle - 1]) / (double)2.0 : this.nums[middle];

      return median;
    }
  }
}