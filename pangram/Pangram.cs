using System;
using System.Text.RegularExpressions;

public static class Pangram
{
    private const string Pattern = "abcdefghijklmnopqrstuvwxyz";

    private const string PatternRepalce = @"[^\\s0-9a-zA-Z]+";

    public static bool IsPangram(string input)
    {

        string new_input = Regex.Replace(input, PatternRepalce, "").ToLower();

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        foreach (var x in Pattern)
        {
            var isTrue = new_input.Contains(x);
            if (!isTrue)
            {
                return false;
            }
        }
        return true;

    }
}
