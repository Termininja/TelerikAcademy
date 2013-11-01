//Task 13: Create a program that assigns null values to an integer and to
//         double variables. Try to print them on the console, try to add
//         some values or the null literal to them and see the result.

using System;

class NullVariable
{
    static void Main()
    {
        int? number1 = null;
        double? number2 = null;

        // Only null
        Console.WriteLine("Integer with null value → {0}", number1);
        Console.WriteLine("Double with null value → {0}\n", number2);

        // Null + 10
        Console.WriteLine("Integer with null value + 10 → {0}", number1 + 10);
        Console.WriteLine("Double with null value + 10 → {0}\n", number2 + 10);
    }
}