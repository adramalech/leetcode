using System.Collections.Generic;

namespace Problems.Design
{
  /**
  * Your Logger object will be instantiated and called as such:
  * Logger obj = new Logger();
  * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
  */
  public class Logger
  {
    // holds message -> last known timestamp.
    private Dictionary<string, int> lookup;

    /** Initialize your data structure here. */
    public Logger()
    {
      this.lookup = new Dictionary<string, int>();
    }

    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message)
    {
      // if it has not been found before set it true.
      if (!this.lookup.ContainsKey(message))
      {
        this.lookup.Add(message, timestamp);
        return true;
      }

      // if the timestamp is less than 10 time units ago.
      if (timestamp - this.lookup[message] < 10)
      {
        return false;
      }

      // update timestamp it has been longer.
      this.lookup[message] = timestamp;

      return true;
    }
  }
}