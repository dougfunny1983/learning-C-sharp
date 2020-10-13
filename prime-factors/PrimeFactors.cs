using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    private static bool IsDivisible(long number1, long number2) => number1 % number2 == 0;

    private static long Divisible(long number1, long number2) => number1 / number2;

    public static long[] Factors(long number)
    {
        List<long> answer = new List<long>();

        long numberDivider = number;

        for (long i = 2; i <= number; i++)
        {
            while (IsDivisible(numberDivider, i))
            {
                answer.Add(i);
                numberDivider = Divisible(numberDivider, i);
            }
            if (numberDivider == 1)
            {
                break;
            }
        }

        return answer.ToArray();
    }
}