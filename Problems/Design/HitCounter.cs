using System.Collections.Generic;
using System.Linq;

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
    private SortedDictionary<int, int> lookup;
    private int oldestTimestamp;
    private int count;

    /** Initialize your data structure here. */
    public HitCounter()
    {
      lookup = new SortedDictionary<int, int>();
      oldestTimestamp = 0;
      count = 0;
    }

    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    // O(1)
    public void Hit(int timestamp)
    {
      // trim out old records if the record count is larger than 300
      // or if oldest known timestamp is older than 300 from current timestamp.
      if (timestamp >= oldestTimestamp + MAX_TIME)
      {
        this.Remove(timestamp);
      }

      if (lookup.ContainsKey(timestamp))
      {
        lookup[timestamp]++;
      }
      else
      {
        lookup.Add(timestamp, 1);
      }

      this.count++;
    }

    private void Remove(int timestamp)
    {
      foreach (var key in this.lookup.Keys.ToList())
      {
        if (timestamp - key >= MAX_TIME)
        {
          this.count -= this.lookup[key];
          this.lookup.Remove(key);
        }
        else
        {
          this.oldestTimestamp = key;
          break;
        }
      }
    }

    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    // O(s) where s is 300 second window.
    public int GetHits(int timestamp)
    {
      // trim out old records if the record count is larger than 300
      // or if oldest known timestamp is older than 300 from current timestamp.
      if (timestamp >= oldestTimestamp + MAX_TIME)
      {
        this.Remove(timestamp);
      }

      return this.count;
    }
  }
}