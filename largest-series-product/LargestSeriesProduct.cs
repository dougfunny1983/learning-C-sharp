using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        try
        { 
            IEnumerable<int> listToFindOut = Enumerable.Range(0, digits.Length - span + 1);
            IEnumerable<string> split = listToFindOut.Select(indice => digits.Substring(indice, span));
            IEnumerable<int> multiplication = split.Select(chars => chars.Aggregate(1, (x, y) => x * Convert.ToInt32(y.ToString())));

            return multiplication.Max();
        }
        catch
        {
            throw new ArgumentException();
        }
    }
}