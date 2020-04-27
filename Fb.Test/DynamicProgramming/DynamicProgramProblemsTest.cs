using Xunit;
using fb.DynamicProgramming;

namespace Fb.Test.DynamicProgramming
{
    public class DynamicProgramProblemsTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(11, 55)]
        [InlineData(50, 7778742049)]
        public void TestFibonacci(int n, ulong expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.Fibonacci(n);
            
            Assert.Equal<ulong>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(11, 55)]
        [InlineData(50, 7778742049)]
        public void TestFibonacciConstantSpace(int n, ulong expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.FibonnaciWithConstantSpace(n);
            
            Assert.Equal<ulong>(expectedValue, actualValue);
        }
    }
}