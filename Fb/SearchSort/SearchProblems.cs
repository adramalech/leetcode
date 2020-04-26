using System;

namespace fb.SearchSort
{
    public class SearchProblems
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
            
            // if the divisor is 1 the answer is always dividend else if -1 it is negating the dividend.
            if (divisor == 1)
            {
                return dividend;
            }

            if (divisor == -1)
            {
                return -dividend;
            }
            
            // both numbers must be less than zero or greater than zero to have postive result.
            var isResultPositive = ((dividend < 0 && divisor < 0) || (dividend > 0  && divisor > 0));

            // we want to deal with the numbers and add the sign back later.
            int abs_dividend = (dividend > int.MinValue) ? Math.Abs(dividend) : int.MaxValue;
            int abs_divisor =  (divisor > int.MinValue) ? Math.Abs(divisor) : int.MaxValue;
            
            // check if the divisor is greater than dividend fraction always less than 1.
            if (abs_dividend < abs_divisor)
            {
                return 0;
            }
            
            // they divisor and dividend are equal return 1.
            if (abs_divisor == abs_dividend)
            {
                return (isResultPositive ? 1 : -1);
            }

            int total = 0;
            
            // iterate till we cannot make any more moves.
            while (abs_dividend - abs_divisor >= 0)
            {
                int d = 0;
                
                // search for the largest number to subtract.
                while (abs_dividend - (abs_divisor << 1 << d) >= 0)
                {
                    d++;
                }

                total += 1 << d;
                abs_dividend -= abs_divisor << d;
            }
            
            return (isResultPositive ? total : -total);
        }
    }
}