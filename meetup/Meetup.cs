using System;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    public Meetup(int month, int year)
    {
        Month = month;
        Year = year;
    }

    public int Month { get; }
    public int Year { get; }


    private readonly Dictionary<string, int[]> DayRange = new Dictionary<string, int[]>()
        {
            { "Teenth", new int[] { 13, 14, 15, 16, 17, 18, 19 } },
            { "First", new int[] { 1, 2, 3, 4, 5, 6, 7} },
            { "Second", new int[] { 8, 9, 10, 11, 12, 13, 14 } },
            { "Third", new int[] { 15, 16, 17, 18, 19, 20, 21, 22 } },
            { "Fourth", new int[] { 22, 23, 24, 25, 26, 27, 28, 29 } },
            { "Last", new int[] { 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21 } }
        };

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime answer = new DateTime(Year, Month, 1);

        string key = $"{schedule}";
        
        foreach (int num in DayRange[key])
        {
            try
            {
                answer = new DateTime(Year, Month, num);

                if (answer.DayOfWeek == dayOfWeek)
                {
                    return answer;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                continue;
            }
        }
        
        return answer;

    }
}
