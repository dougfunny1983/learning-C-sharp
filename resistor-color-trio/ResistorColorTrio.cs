using System;

public static class ResistorColorTrio
{
    public static int Index(string[] array, string color) => Array.IndexOf(array, color);

    private static readonly string[] Colors = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static string Label(string[] colors)
    {

        foreach (var color in colors)
            if (Index(Colors, color) == -1)
                throw new ArgumentException("invalid color");

        string unit = "ohms";

        double resVal = (Index(Colors, colors[0]) * 10 + Index(Colors, colors[1])) * Math.Pow(10, Index(Colors, colors[2]));

        if (resVal / 1000 > 1)
        {
            unit = "kiloohms";
            resVal /= 1000;
        }

        return $"{resVal} {unit}";
    }
}
