using Xunit;
using Problems.Design;

namespace Problems.Design
{
  public class LoggerTest
  {
    [Fact]
    public void TestLogger()
    {
      var logger = new Logger();

      // hasn't been seen should return true.
      Assert.True(logger.ShouldPrintMessage(1, "foo"));

      // hasn't been seen should return true.
      Assert.True(logger.ShouldPrintMessage(2, "bar"));

      // has been seen and timestamp 3 - 1 = 2 which is less than 10 return false.
      Assert.False(logger.ShouldPrintMessage(3, "foo"));

      // has been seen and timestamp 8 - 2 = 6 which is less than 10 return false.
      Assert.False(logger.ShouldPrintMessage(8, "bar"));

      // has been seen and timestamp 10 - 1 = 9 which is less than 10 return false.
      Assert.False(logger.ShouldPrintMessage(10, "foo"));

      // has been seen and timestamp 11 - 1 = 10 which is greater than or equal to 10 return true.
      // set the "foo" to timestamp 11 should return false once it is past 21 or newer timestamp value.
      Assert.True(logger.ShouldPrintMessage(11, "foo"));
    }
  }
}