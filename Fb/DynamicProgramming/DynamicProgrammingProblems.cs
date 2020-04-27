namespace fb.DynamicProgramming
{
    public class DynamicProgrammingProblems
    {
        // O(n) with O(n) space.
        public ulong Fibonacci(int n)
        {
            // if we are looking at out of bounds number return 0.
            if (n <= 0)
            {
                return 0;
            }
            
            // return the 1th and 0th fib number which are 1 and 0 respectively.
            if (n <= 1)
            {
                return 1;
            }
            
            var results = new ulong[n];
            results[0] = 0;
            results[1] = 1;

            for (var i = 2; i < n; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return results[n - 1];
        }

        // O(n) with O(4) space
        public ulong FibonnaciWithConstantSpace(int n)
        {
            // if we are looking at out of bounds number return 0.
            if (n <= 0)
            {
                return 0;
            }
            
            // return the 1th and 0th fib number which are 1 and 0 respectively.
            if (n <= 1)
            {
                return 1;
            }

            ulong prev = 1;
            ulong prev_prev = 0;
            ulong total = 1;

            for (var counter = 2; counter < n; counter++)
            {
                total = prev + prev_prev;
                prev_prev = prev;
                prev = total;
            }

            return total;
        }
    }
}