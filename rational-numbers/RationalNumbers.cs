using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{

    private readonly int a;
    private readonly int b;


    public RationalNumber(int numerator, int denominator)
    {
        if (denominator != 0)
        {
            int gcd = GreatestCommonDivisor(numerator, denominator);
            a = numerator / gcd;
            b = denominator / gcd;
        }
        else throw new ArgumentException();
    }


    private static int GreatestCommonDivisor(int a, int b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.a * r2.b + r2.a * r1.b, r1.b * r2.b);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.a * r2.b - r2.a * r1.b, r1.b * r2.b);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.a * r2.a, r1.b * r2.b);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.a * r2.b, r1.b * r2.a);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(a), Math.Abs(b));

    public RationalNumber Reduce()
    {
        int gcd = GreatestCommonDivisor(a, b);
        int numerator = a / gcd;
        int denominator = b / gcd;
        return denominator < 0 ? new RationalNumber(-numerator, -denominator) : new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power) => new RationalNumber((int)Math.Pow(a, Math.Abs(power)), (int)Math.Pow(b, Math.Abs(power)));

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, (double)a / b);
}
