using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{

    private static string RaindropsSwitch(int number, int defaut)
        => number switch
        {
            3 => "Pling",
            5 => "Plang",
            7 => "Plong",
            _ => $"{defaut}",
        };

    public static string Convert(int number)
    {
        StringBuilder answer = new StringBuilder();

        IEnumerable<int> EvenNumbers = Enumerable.Range(1, number).Where(num => number % num == 0).Where(val => val == 3 || val == 5 || val == 7);

        foreach (int x in EvenNumbers.DefaultIfEmpty(0))
        {
            answer.Append(RaindropsSwitch(x, number));
        }

        return answer.ToString(); ;
    }
}