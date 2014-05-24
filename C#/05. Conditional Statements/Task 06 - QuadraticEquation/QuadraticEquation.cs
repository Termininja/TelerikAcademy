//Task 6: Write a program that enters the coefficients a, b and c of a quadratic
//        equation a*x2 + b*x + c = 0 and calculates and prints its real roots.
//        Note that quadratic equations may have 0, 1 or 2 real roots.

using System;

class QuadraticEquation
{
    static void Main()
    {
        // Read the three coefficients
        double a = ReadCoefficient("a = ");
        double b = ReadCoefficient("b = ");
        double c = ReadCoefficient("c = ");

        // The discriminant of quadratic equation
        double D = Math.Pow(b, 2) - 4 * a * c;

        // If doesn't have real roots
        if (D < 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe quadratic equation doesn't have real roots!");
        }

        // If there is only one real root 'x'
        else if (D == 0)
        {
            double x = -b / 2 * a;
            Console.WriteLine("\nThe quadratic equation has only one real root:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t     -b\n\tx = ───── = {0}\n\t     2.a", Math.Round(x, 2));
        }

        // If there are two real roots 'x1' and 'x2'
        else
        {
            double x1 = (-b + Math.Sqrt(D)) / 2 * a;
            double x2 = (-b - Math.Sqrt(D)) / 2 * a;
            Console.WriteLine("\nThe quadratic equation has two real roots:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t      -b + √D\n\tx1 = ───────── = {0}\n\t        2.a\n", Math.Round(x1, 2));
            Console.WriteLine("\t      -b - √D\n\tx2 = ───────── = {0}\n\t        2.a", Math.Round(x2, 2));
        }
        Console.ResetColor();
    }

    // Method which read some coefficient
    private static double ReadCoefficient(string text)
    {
        Console.Write("Coefficient: {0}", text);
        return double.Parse(Console.ReadLine());
    }
}