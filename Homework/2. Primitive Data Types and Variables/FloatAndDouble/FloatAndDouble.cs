//Task 2: Which of the following values can be assigned to a variable of type float and which to a variable of type double:
//34.567839023, 12.345, 8923.1234857, 3456.091?

using System;

class FloatAndDouble
{
    static void Main()
    {
        //float is used for numbers that have max 7 digits
        float float1 = 34.567839023f;
        float float2 = 12.345f;
        float float3 = 8923.1234857f;
        float float4 = 3456.091f;

        //double is used for numbers that have max 15 - 16 digits
        double double1 = 34.567839023;
        double double2 = 12.345;
        double double3 = 8923.1234857;
        double double4 = 3456.091;
        Console.WriteLine("Numbers\t\t\t  In float\t  In double");
        Console.WriteLine(new string('-', 55));                             //write line from 55 '-' symbols

        //write a comparing table
        Console.Write("34.567839023\t\t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("X ");
        Console.ResetColor();
        Console.Write(float1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t√ ");
        Console.ResetColor();
        Console.WriteLine(double1);

        Console.Write("12.345\t\t\t");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("√ ");
        Console.ResetColor();
        Console.Write(float2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t√ ");
        Console.ResetColor();
        Console.WriteLine(double2);

        Console.Write("8923.1234857\t\t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("X ");
        Console.ResetColor();
        Console.Write(float3);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t√ ");
        Console.ResetColor();
        Console.WriteLine(double3);

        Console.Write("3456.091\t\t");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("√ ");
        Console.ResetColor();
        Console.Write(float4);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t√ ");
        Console.ResetColor();
        Console.WriteLine(double4);

        Console.WriteLine(new string('-', 55));

        //The conclusion
        Console.WriteLine("The numbers {0} and {1} can be assigned to float", float2, float4);
        Console.WriteLine("The numbers {0}, {1}, {2} and {3} can be assigned to double", double1, double2, double3, double4);
    }
}