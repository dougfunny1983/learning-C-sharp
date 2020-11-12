using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{

    private static IEnumerable<int> RangedEnumeration(int min, int max, int step = -1)
    {
        try
        {
            return step != -1 ? Enumerable.Range(min, max - min + 1)
                .Where(i => (i - min) % step == 0) :
                Enumerable.Range(min, max);
        }
        catch (ArgumentOutOfRangeException)
        {
            return Enumerable.Empty<int>();
        }

    }

    public static int[] Primes(int limit)
    {

        if (limit < 2) throw new ArgumentOutOfRangeException();

        List<int> primes = new List<int>();

        HashSet<int> not_prime = new HashSet<int>();

        foreach (int i in RangedEnumeration(2, limit - 1))
        {
            if (not_prime.Contains(i))
                continue;
            foreach (int j in RangedEnumeration(i * 2, limit + 1, i))
                not_prime.Add(j);
            primes.Add(i);
        }

        return primes.ToArray();
    }
}