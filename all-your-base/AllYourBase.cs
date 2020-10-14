using System;
using System.Collections.Generic;
using System.Linq;


public static class AllYourBase
{

    private static readonly System.ArgumentException error = new System.ArgumentException();

    private static readonly int[] empty = new[] { 0 };

    private static int ToBaseTen( int[] digits, int from)
    {
        int[] temp = digits;
        Array.Reverse(temp);
        int mult = 1;
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            sum += digits[i] * mult;
            mult *= from;
        }

        return sum;
    }

    private static int[] FromTen(int num,int to) 
    {
        List<int> outs = new List<int>();
        List<int> pows = new List<int>();
        int pow = 1;

        while (pow <= num)
        {
            pows.Add(pow);
            pow *= to;
        }

        pows.Reverse();

        for (int i = 0; i < pows.Count; i++)
        {
            int digit = num / pows[i];
            outs.Add(digit);
            num -= digit * pows[i];
        }

        return outs.Count <= 0 ? empty : outs.ToArray();
    }

    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (double.IsNaN(inputBase) || inputBase == 0) throw error;
        if (inputDigits == null) return empty;
        if (inputDigits.Length == 0) return empty;
        if (inputDigits.Min() < 0) throw error;
        if (inputDigits.Max() >= inputBase) throw error;

        List<int> arr = new List<int>(inputDigits);

        arr.RemoveAt(0);

        int[] digits = inputDigits[0] == 0 ? arr.ToArray() : inputDigits;
       
        if (double.IsNaN(outputBase)) throw error;
        if (inputBase < 2) throw error;
        if (outputBase < 2) throw error;

        return FromTen(ToBaseTen(digits, inputBase), outputBase);
    }
}
