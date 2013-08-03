//Task 3: Write a program that safely compares floating-point numbers with precision of 0.000001.
//Examples:(5.3 ; 6.01) → false;  (5.00000001 ; 5.00000003) → true

using System;

class CompareNumbers
{
    static void Main()
    {
        Console.Write("Please, enter the 1st number: ");
        decimal number1 = decimal.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd number: ");
        decimal number2 = decimal.Parse(Console.ReadLine());

        if (Math.Abs(number1 - number2) < 0.000001m)                //compare the two numbers with precision 0.000001
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The two numbers are equal!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The two numbers are not equal!");
        }
        Console.ResetColor();
    }
}