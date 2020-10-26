using System;

public static class Triangle
{

    private static double Module(double x, double y) => x > y ? x - y : y - x;


    private static bool IsTriangle(double side1, double side2, double side3) 
    {
        bool test1 = Module(side2, side3) < side1 && side1 < (side2 + side3);
        bool test2 = Module(side1, side3) < side2 && side2 < (side1 + side3);
        bool test3 = Module(side1, side2) < side3 && side3 < (side1 + side2);

        bool answer = test1 && test2 && test3;

        return answer;
    }


    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (IsTriangle(side1, side2, side3))
        {
            if (side1 != side2 && side2 != side3 && side3 != side1)
            {
                return true;
            }
        }
        return false; 
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (IsTriangle(side1, side2, side3))
        {
            if (side1 == side2 || side2 == side3 || side1 == side3)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (IsTriangle(side1, side2, side3)) 
        {
            if (side1 == side2 && side1 == side3) 
            {
                return true;
            }
        }
        return false;
    }
}