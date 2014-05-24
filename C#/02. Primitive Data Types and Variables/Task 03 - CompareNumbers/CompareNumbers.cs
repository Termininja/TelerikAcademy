//Task 3: Write a program that safely compares floating-point numbers with precision of 0.000001.
//        Examples: (5.3 ; 6.01) → false;  (5.00000001 ; 5.00000003) → true

using System;

class CompareNumbers
{
    static void Main()
    {
        // Read two decimal numbers
        Console.Write("Please, enter the 1st number: ");
        decimal number1 = decimal.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd number: ");
        decimal number2 = decimal.Parse(Console.ReadLine());

        // Compare the both numbers with precision 0.000001
        if (Math.Abs(number1 - number2) < 0.000001m)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe both numbers are equal!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe both numbers are not equal!");
        }
        Console.ResetColor();
    }
}