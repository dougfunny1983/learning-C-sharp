using System.Linq;

public static class Pangram
{
    private const string Pattern = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) => Pattern.All(input.ToLower().Contains);
}
