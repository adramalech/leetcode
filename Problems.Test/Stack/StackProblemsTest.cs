using Xunit;
using Problems.Stack;

namespace Problems.Test.Stack
{
  public class StackProblemsTest
  {
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 4, 5, 3, 2, 1 }, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 }, false)]
    public void TestValidateStackSequence(int[] pushed, int[] popped, bool expectedResult)
    {
      var stackProblems = new StackProblems();

      var actualResult = stackProblems.ValidateStackSequences(pushed, popped);

      Assert.True(expectedResult == actualResult);
    }
  }
}