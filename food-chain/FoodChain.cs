using System.Linq;
using System.Text;

public static class FoodChain
{
    private static readonly string[] Animals =
    {
        "fly",
        "spider that wriggled and jiggled and tickled inside her",
        "bird",
        "cat",
        "dog",
        "goat",
        "cow",
        "horse"
    };

    private const string StartLyrics = "I know an old lady who swallowed a {0}.\n";

    private static readonly string[] MoreLyrics = new[]
    {
        "",
        "It wriggled and jiggled and tickled inside her.\n",
        "How absurd to swallow a bird!\n",
        "Imagine that, to swallow a cat!\n",
        "What a hog, to swallow a dog!\n",
        "Just opened her throat and swallowed a goat!\n",
        "I don't know how she swallowed a cow!\n",
        "She's dead, of course!"
    };

    private const string EndLyrics = "I don't know why she swallowed the fly. Perhaps she'll die.";

    private const string MiddleLyrics = "She swallowed the {0} to catch the {1}.\n";


    public static string Recite(int verseNumber)
    {
        --verseNumber;
        StringBuilder verse = new StringBuilder();

        verse.Append(string.Format(StartLyrics, Animals[verseNumber].Split(' ')[0]));

        verse.Append(MoreLyrics[verseNumber]);

        if (verseNumber < Animals.Length - 1)
        {
            while (verseNumber > 0)
            {
                verse.Append(string.Format(MiddleLyrics, Animals[verseNumber].Split(' ')[0], Animals[verseNumber - 1]));
                --verseNumber;
            }

            verse.Append(EndLyrics);
        }

        return verse.ToString();
    }


    public static string Recite(int startVerse, int endVerse) => string.Join("\n\n", Enumerable.Range(startVerse, endVerse - startVerse + 1)
        .Select(i => Recite(i)));
}
