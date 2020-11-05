using System.Collections.Generic;
using System.Text;

public static class RomanNumeralExtension
{

    private static readonly Dictionary<int, string> numberRoman = new Dictionary<int, string>()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" },
    };

 
    private static string Multiply(this string source, int multiplier)
    {
        StringBuilder sb = new StringBuilder(multiplier * source.Length);
        for (int i = 0; i < multiplier; i++)
        {
            sb.Append(source);
        }
        return sb.ToString();
    }


    public static string ToRoman(this int value)
    {
        StringBuilder answer = new StringBuilder();

        foreach (KeyValuePair<int, string> kvp in numberRoman)
        {
            if (value >= kvp.Key)
            {
                int count = value / kvp.Key;
                string str = Multiply(kvp.Value, count);
                answer.Append(str);
                value -= kvp.Key * count;
            }
        }

        return answer.ToString();
    }
}