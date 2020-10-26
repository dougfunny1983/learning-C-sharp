using System;

public struct ComplexNumber
{
   
    private double a
    {
        get;
        set;
    }

    private double b
    {
        get;
        set;
    }

    public ComplexNumber(double real, double imaginary)
    {
        a = real;
        b = imaginary;
    }

    public double Real() => a;

    public double Imaginary() => b;

    public ComplexNumber Mul(ComplexNumber other) => new ComplexNumber(a* other.a - b* other.b, a * other.b + b * other.a);


    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(a + other.a, b + other.b);

    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(a - other.a, b - other.b);

    public ComplexNumber Div(ComplexNumber other)
    {
        var res = new ComplexNumber(0, 0)
        {
            a = (a * other.a + b * other.b) / (other.a * other.a + other.b * other.b),
            b = (b * other.a - a * other.b) / (other.a * other.a + other.b * other.b)
        };
        return res;
    }

    public double Abs() => Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

    public ComplexNumber Conjugate() => new ComplexNumber(a, -b);


    public ComplexNumber Exp() => new ComplexNumber(Math.Exp(a) * Math.Cos(b), Math.Exp(a) * Math.Sin(b));

}