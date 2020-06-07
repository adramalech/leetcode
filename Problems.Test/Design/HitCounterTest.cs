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

    [Fact]
    public void TestHitCounter2()
    {
      var hitCounter = new HitCounter();

      hitCounter.Hit(2);
      hitCounter.Hit(3);
      hitCounter.Hit(4);

      // count hits 2, 3, 4 with total = 3.
      Assert.Equal<int>(3, hitCounter.GetHits(300));

      // count hits 2, 3, 4 with total = 3.
      Assert.Equal<int>(3, hitCounter.GetHits(301));

      // count hits 3, 4 with total = 2.
      Assert.Equal<int>(2, hitCounter.GetHits(302));

      // count hits 4 with total = 2.
      Assert.Equal<int>(1, hitCounter.GetHits(303));

      // count hits empty with total = 0.
      Assert.Equal<int>(0, hitCounter.GetHits(304));

      hitCounter.Hit(501);

      // count hits 501 with total = 1.
      Assert.Equal<int>(1, hitCounter.GetHits(600));
    }

    [Fact]
    public void TestHitCounter3()
    {
      var hitCounter = new HitCounter();
      // 1 - 100
      hitCounter.Hit(100);

      // 2 - 100, 282
      hitCounter.Hit(282);

      // 2 - 282, 411
      hitCounter.Hit(411);

      // 2 - 411, 609
      hitCounter.Hit(609);

      // 3 - 411, 609, 620
      hitCounter.Hit(620);

      // 3 - 609, 620, 744
      hitCounter.Hit(744);

      // count hits 609, 620, 744 with total = 3.
      Assert.Equal<int>(3, hitCounter.GetHits(879));

      // 2 - 744, 956
      hitCounter.Hit(956);

      // count hits 744, 956 with total = 2.
      Assert.Equal<int>(2, hitCounter.GetHits(976));

      // 3 - 744, 956, 998
      hitCounter.Hit(998);

      // count hits 956, 998, with total = 2
      Assert.Equal<int>(2, hitCounter.GetHits(1055));
    }
  }
}