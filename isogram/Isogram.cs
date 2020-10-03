using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return true;
        }
        var dict = new Dictionary<char, int>();

        string newWord = (string)word.Where(char.IsLetter).Select(char.ToLower);

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
