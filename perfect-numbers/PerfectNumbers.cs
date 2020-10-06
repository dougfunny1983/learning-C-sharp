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

    public static Classification Classify(int number)
    {
        if (number <= 0)  throw new ArgumentOutOfRangeException("The expected value must be a natural number");

        List<int> numbers = new List<int>();
        for (int i = 1; i < number; i++)
        {
            if (IsDivideByParams(number, i))
                numbers.Add(i);

        }

        int sumTotaly = numbers.Sum(x => x);

        return sumTotaly > number ? Classification.Abundant : sumTotaly < number ? Classification.Deficient : Classification.Perfect;
    }
}
