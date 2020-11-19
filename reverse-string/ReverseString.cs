using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public static class ReverseString
{

    private static IEnumerable<string> GraphemeClusters(this string s)
    {
        TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(s);

        while (enumerator.MoveNext())
        {
            yield return (string)enumerator.Current;
        }
    }
    private static string ReverseGraphemeClusters(this string s) =>
        string.Join("", s
            .GraphemeClusters()
            .Reverse()
            .ToArray());

    public static string Reverse(string input) => ReverseGraphemeClusters(input);
}