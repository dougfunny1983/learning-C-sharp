using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}



public static class PerfectNumbers
{

    private static bool IsDivideByParams(int divider, int dividend) => divider % dividend == 0;

    private static Classification GetEnumAnswer(int x, int y) => (x, y) switch
     {
         var (_, _) when x > y => Classification.Abundant,
         var (_, _) when x < y => Classification.Deficient,
         var (_, _) when x == y => Classification.Perfect,
         _ => throw new NotImplementedException(),
     };

    public static Classification Classify(int number)
    {
        if (number <= 0)  throw new ArgumentOutOfRangeException("The expected value must be a natural number");

        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (IsDivideByParams(number, i))
                sum += i;
        }

        return GetEnumAnswer(sum, number);

    }
}
