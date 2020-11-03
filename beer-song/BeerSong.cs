using System;

public static class BeerSong
{

    private static string PluralOfBottles(int num)
    {
        if (num == 0 || num > 1) 
        {
            return $"{num} bottles of beer on the wall, {num} bottles of beer.";
        }

        return "1 bottle of beer on the wall, 1 bottle of beer.";
    }

    private static string NoMoreBottle(int num) 
    {

        if (num == 0) 
        {
            return "Take it down and pass it around, no more bottles of beer on the wall.";

        }
        if (num == 1) 
        {
            return "Take one down and pass it around, 1 bottle of beer on the wall.";
        }
        return $"Take one down and pass it around, {num} bottles of beer on the wall.";


    }


    public static string Recite(int startBottles, int takeDown)
    {
        
        string answer = "";

        for (int i = 0; i < takeDown; i++)
        {

            if (startBottles != 0)
            {
                answer += $"{PluralOfBottles(startBottles)}\n" +
                          $"{NoMoreBottle(startBottles-1)}";
                startBottles--;

                if(takeDown >= 2)
                {
                    answer += "\n\n";
                }

            }
            else 
            {
                answer+= "No more bottles of beer on the wall, no more bottles of beer.\n" +
                         "Go to the store and buy some more, 99 bottles of beer on the wall.";
            }
            

        }


        return takeDown == 2 ? answer.Remove(answer.Length - 2) : answer; ;
    }
}