using Xunit;
using Problems.Design;

namespace Problems.Test.Design
{
  public class HitCounterTest
  {
    [Fact]
    public void TestHitCounter()
    {
      var hitCounter = new HitCounter();

      hitCounter.Hit(1);
      hitCounter.Hit(2);
      hitCounter.Hit(3);
      hitCounter.Hit(4);
      hitCounter.Hit(300);

      // count hits 1, 2, 3, 4, 300 with total = 5.
      Assert.Equal<int>(5, hitCounter.GetHits(300));

      // count hits 2, 3, 4, 300 with total = 4.
      Assert.Equal<int>(4, hitCounter.GetHits(301));
    }
  }
}