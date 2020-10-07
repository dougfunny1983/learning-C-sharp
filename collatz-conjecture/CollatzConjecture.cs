using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException("The expected value must be a natural number");

        int n = number;
        int cont = 0;
        while (n > 1)
        {
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else 
            {
                n = (n * 3) + 1;
            }
            cont++;
        }
        return cont;
    }
}