using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public static class SumOfMultiples
{

    private static IEnumerable<int> FilterArray(IEnumerable<int> multiples) => from z in multiples
                                                                               where z != 0
                                                                               select z;
 
    private static int[] ContructorArray(int length, IEnumerable<int> multiples)
    {
        List<int> termsList = new List<int>();

        foreach (int x in multiples)
        {
            for (int i = x; i < length; i = x + i)
            {
                termsList.Add(i);
            }
        }

        return termsList.Distinct().ToArray();
    }
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        try
        {

            IEnumerable<int> filerNewEnum = FilterArray(multiples);

            int[] totaly = ContructorArray(max, filerNewEnum);

            int answer = totaly.Sum(x => x);

            return answer;
        }
        catch (IndexOutOfRangeException)
        {
            return 0;
        }
        
    }
}
        
