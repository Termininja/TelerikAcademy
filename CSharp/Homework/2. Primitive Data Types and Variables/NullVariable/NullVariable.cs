//Task 13: Create a program that assigns null values to an integer and to double variables.
//Try to print them on the console, try to add some values or the null literal to them and see the result.

using System;

class NullVariable
{
    static void Main()
    {
        int? number1 = null;
        double? number2 = null;
        Console.WriteLine("Integer with null value → {0}\nDouble with null value → {1}\n", number1, number2);                       //only null
        Console.WriteLine("Integer with null value + 10 → {0}\nDouble with null value + 10 → {1}\n", number1 + 10, number2 + 10);   //null + 10
    }
}