using System.Collections.Generic;

namespace Problems.Stack
{
  public class StackProblems
  {
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
      if (pushed.Length != popped.Length)
      {
        return false;
      }

      var i = 0;
      var j = 0;

      var stack = new Stack<int>();

      while (i <= pushed.Length && j < popped.Length)
      {
        // we match pop off the stack and skip to next.
        if (stack.Count > 0 && stack.Peek() == popped[j])
        {
          stack.Pop();
          j++;
          continue;
        }

        // if we are at the end of the stack and the popping hasn't happened
        // this is a bad case!
        if (i == pushed.Length)
        {
          return false;
        }

        // we are pushing onto the stack.
        stack.Push(pushed[i]);
        i++;
      }

      // if we got to the end the stack should be empty if so return true else false.
      return stack.Count == 0;
    }
  }
}