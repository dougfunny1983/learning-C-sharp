using System.Linq;

public class Anagram
{
    private readonly string baseWord;
    public Anagram(string baseWord) => this.baseWord = baseWord;
    private static string SortString(string input) => new string(input.OrderBy(ch => ch).ToArray());

    private static bool IsAnagram(string a, string b) => a.ToLower()
        != b.ToLower()
        && SortString(a.ToLower())
        == SortString(b.ToLower());

    public string[] FindAnagrams(string[] potentialMatches) => potentialMatches
        .Select(w => w)
        .Where(ch => IsAnagram(baseWord, ch))
        .ToArray();
}
