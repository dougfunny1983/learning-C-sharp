using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{

    private static bool power(int a, int b, int c) => (long)Math.Pow(a, 2) + (long)Math.Pow(b, 2) == (long)Math.Pow(c, 2);

    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum) => Enumerable.Range(1, sum - 1)
                         .SelectMany(a => Enumerable.Range(a + 1, sum - a - 1)
                                                    .Select(b => (a, b, c: sum - a - b)))
                         .Where(x => power(x.a, x.b, x.c));
}