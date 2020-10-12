using System;
using System.Linq;

public static class DifferenceOfSquares

{
    private static int Squares(int number) => (int)Math.Pow(number, 2);
    // não deu para fazer com 1UL << n! Simplismente não chego ao resultado esperado;

    public static int CalculateSquareOfSum(int max) => Squares(Enumerable.Range(1, max).Sum());

    public static int CalculateSumOfSquares(int max) => Enumerable.Range(1, max).Select(x => Squares(x)).Sum();

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
 
}