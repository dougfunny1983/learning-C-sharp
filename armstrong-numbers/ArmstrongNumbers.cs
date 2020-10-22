using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{

    private static IEnumerable<int> GetUDCM(int number) 
    {
        List<int> house = new List<int>();

        int module = 10;
        int division = 1;

        while ((number * 10) > module)
        {
            house.Add(number % module / division);
            module *= 10;
            division *= 10;
        }

        return house;
    }

    public static bool IsArmstrongNumber(int number)
    {
       double length = Math.Floor(Math.Log10(number) + 1);
       
       double answer = GetUDCM(number).Aggregate(0, (acc, x) => (int)(acc + Math.Pow(x, length)));

       return answer == number;
    }
}
