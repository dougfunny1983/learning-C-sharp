using System;

public static class CollatzConjecture
{
    private static int ApplyConjecture(int number) => number % 2 == 0 ? number / 2 : 3 * number + 1;
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException("The expected value must be a natural number and positive!");

        int n = number;
        int cont = 0;
        while (n > 1)
        {
            n = ApplyConjecture(n);
            cont++;
        }
        return cont;
    }
}