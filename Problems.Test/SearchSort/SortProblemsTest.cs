using Xunit;
using System;
using Problems.SearchSort;

namespace Problems.Test.SearchSort
{
  public class SortProblemsTest
  {
    [Fact]
    public void TestAssignBikes()
    {
      var sortProblems = new SortProblems();

      var workers = new int[2][] { new int[2] { 0, 0 }, new int[2] { 2, 1 } };
      var bikes = new int[2][] { new int[2] { 1, 2 }, new int[2] { 3, 3 } };

      var expectedResult = new int[] { 1, 0 };

      var actualResult = sortProblems.AssignBikes(workers, bikes);

      Assert.Equal<int>(expectedResult.Length, actualResult.Length);

      for (var i = 0; i < expectedResult.Length; i++)
      {
        Assert.Equal<int>(expectedResult[i], actualResult[i]);
      }
    }
  }
}