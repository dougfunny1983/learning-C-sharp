using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static readonly Dictionary<int, string[]> myDictionary = new Dictionary<int, string[]>()
    {
        {1, new string[] { "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" } },
        {2, new string[] {"D", "G" } },
        {3, new string[] { "B", "C", "M", "P" } },
        {4, new string[] { "F", "H", "V", "W", "Y" } },
        {5, new string[] { "K" } },
        {8, new string[] { "J", "X" } },
        {10, new string[] { "Q", "Z" } },
    };

    public static int Score(string input)
    {
        int punctuation = 0;
        foreach (var kvp in myDictionary)
        {
            foreach (char item in input.ToUpper())
            {
                if (kvp.Value.Any(x => x.Contains(item)))
                {
                    punctuation += kvp.Key;
                }
            }
        }
        return punctuation;

    }
}