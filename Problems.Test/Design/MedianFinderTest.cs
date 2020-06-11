using Xunit;
using Problems.Design;

namespace Problems.Test.Design
{
  public class MeidanFinderTest
  {
    [Fact]
    public void TestMedian()
    {
      var medianFinder = new MedianFinder();

      medianFinder.AddNum(1);

      Assert.Equal<double>(1.0, medianFinder.FindMedian());

      medianFinder.AddNum(2);
      medianFinder.AddNum(3);
      medianFinder.AddNum(4);

      Assert.Equal<double>(2.5, medianFinder.FindMedian());

      medianFinder.AddNum(5);

      Assert.Equal<double>(3.0, medianFinder.FindMedian());

      medianFinder.AddNum(6);
      medianFinder.AddNum(6);
      medianFinder.AddNum(6);
      medianFinder.AddNum(7);
      medianFinder.AddNum(8);

      Assert.Equal<double>(5.5, medianFinder.FindMedian());
    }
  }
}