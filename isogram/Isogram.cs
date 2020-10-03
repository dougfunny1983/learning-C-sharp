using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    private const string Pattern = @"[^\\s0-9a-zA-Z]+";
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return true;
        }
        var dict = new Dictionary<char, int>();

        string newWord = Regex.Replace(word, Pattern, string.Empty).ToLower();

        foreach (var key in newWord)
        {
            if (dict.ContainsKey(key))
                dict[key]++;
            else
                dict[key] = 1;
        }

        int answer = dict.Max(kvp => kvp.Value);
        return answer == 1 ;

    }
}
