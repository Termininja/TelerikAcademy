//Task 2: Which of the following values can be assigned to a variable of type float which
//        to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

using System;

class FloatAndDouble
{
    static void Main()
    {
        //Float is used for numbers with max 7 digits
        float float1 = 34.567839023f;
        float float2 = 12.345f;
        float float3 = 8923.1234857f;
        float float4 = 3456.091f;

        //Double is used for numbers with max 15 - 16 digits
        double double1 = 34.567839023;
        double double2 = 12.345;
        double double3 = 8923.1234857;
        double double4 = 3456.091;

        // Print the result in comparing table
        Console.WriteLine("Numbers\t\t\t  In float\t  In double");
        Console.WriteLine(new string('-', 55));
        PrintLine("34.567839023\t\t", float1, double1, ConsoleColor.Red);
        PrintLine("12.345\t\t\t", float2, double2, ConsoleColor.Green);
        PrintLine("8923.1234857\t\t", float3, double3, ConsoleColor.Red);
        PrintLine("3456.091\t\t", float4, double4, ConsoleColor.Green);
        Console.WriteLine(new string('-', 55));

        //Conclusion
        Console.WriteLine("The numbers {0} and {1} can be assigned to float", float2, float4);
        Console.WriteLine("The numbers {0}, {1}, {2} and {3} can be assigned to double", double1, double2, double3, double4);
    }

    // Print some line from the table
    private static void PrintLine(string text, float f, double d, ConsoleColor color)
    {
        Console.Write(text);
        Console.ForegroundColor = color;
        Console.Write("X ");
        Console.ResetColor();
        Console.Write(f);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t√ ");
        Console.ResetColor();
        Console.WriteLine(d);
    }
}