using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    //private readonly int Numerator;
    //private readonly int Denominator;

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    //public static Source operator +(Source s1, Source s2) // SOMA
    //{
    //    return new Source { Number = s1.Number + s2.Number };
    //}

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        //return new RationalNumber ( r1.Numerator + r2.Denominator );
        return new RationalNumber ( r1.Numerator + r2.Denominator, r1.Numerator + r2.Denominator );
        //return new RationalNumber { r1.Numerator + r2.Denominator };
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Reduce()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}