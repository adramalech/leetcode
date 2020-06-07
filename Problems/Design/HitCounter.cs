using System.Collections.Generic;

namespace Problems.Design
{
  /**
    * Your HitCounter object will be instantiated and called as such:
    * HitCounter obj = new HitCounter();
    * obj.Hit(timestamp);
    * int param_2 = obj.GetHits(timestamp);
    */
  public class HitCounter
  {
    private const int MAX_TIME = 300;
    private Dictionary<int, int> lookup;

    /** Initialize your data structure here. */
    public HitCounter()
    {
      lookup = new Dictionary<int, int>();
    }

    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    // O(1)
    public void Hit(int timestamp)
    {
      if (lookup.ContainsKey(timestamp))
      {
        lookup[timestamp]++;
      }
      else
      {
        lookup.Add(timestamp, 1);
      }
    }

    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    // O(s) where s is 300 second window.
    public int GetHits(int timestamp)
    {
      var remainder = timestamp % MAX_TIME;
      var multi = timestamp / MAX_TIME;
      var i = (timestamp - 300) + 1;

      if (i < 1)
      {
        i = 1;
      }

      int hits = 0;

      while (i <= timestamp)
      {
        if (lookup.TryGetValue(i, out var count))
        {
          hits += count;
        }

        i++;
      }

      return hits;
    }
  }
}