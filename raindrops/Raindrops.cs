using System;
using System.Text;

public static class Raindrops
{
    private static string RaindropsSwitch(int number)
        => number switch
        {
            3 => "Pling",
            5 => "Plang",
            7 => "Plong",
            _ => throw new NotImplementedException(),
        };

    private static bool DecisionMakerOnFactors(int number, int factor) => number % factor == 0;

    public static string Convert(int number)
    {
        StringBuilder str = new StringBuilder();

        if (DecisionMakerOnFactors(number, 3))
            str.Append(RaindropsSwitch(3));

        if (DecisionMakerOnFactors(number, 5))
            str.Append(RaindropsSwitch(5));

        if (DecisionMakerOnFactors(number, 7))
            str.Append(RaindropsSwitch(7));

        string answer = str.ToString();

        return answer == string.Empty ? number.ToString() : answer;

    }
}
