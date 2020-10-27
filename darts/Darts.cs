using System;

public static class Darts
{

    private static int Distance(double x, double y) 
    {
        double distance = x * x + y * y;
 
        return (x, y) switch
        {
            var (_, _) when distance > Math.Pow(10.0F, 2) => 0,
            var (_, _) when distance > Math.Pow(5.0F, 2)   => 1,
            var (_, _) when distance > Math.Pow(1.0F, 2)  => 5,
            _ => 10,
        };
    } 

    public static int Score(double x, double y) => Distance(x, y);
}
