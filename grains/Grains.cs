using System;

public static class Grains
{

    public static ulong Square(int n) => n <= 0 || n > 64 ? throw new ArgumentOutOfRangeException("square must be between 1 and 64") : (ulong)Math.Pow(2, n - 1);

    public static ulong Total() => (ulong) Math.Pow(2, 64)-1;

}
