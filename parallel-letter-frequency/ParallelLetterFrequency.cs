using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts) => texts
            .AsParallel()
            .SelectMany(text => text.ToLower())
            .Where(cha => char.IsLetter(cha))
            .GroupBy(text => text)
            .ToDictionary(text => text.Key, text => text.Count());
}
