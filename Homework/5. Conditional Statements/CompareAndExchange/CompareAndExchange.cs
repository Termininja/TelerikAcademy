//Task 1: Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class CompareAndExchange
{
    static void Main()
    {
        Console.Write("Please, enter the 1st integer number: ");
        Console.Write("num1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: ");
        Console.Write("num2 = ");
        int num2 = int.Parse(Console.ReadLine());

        if (num1 > num2)                                            // the two numbers will be exchanged only if num1 > num2
        {
            int temp = num1;                                        // we use a temporary variable to keep the value of the 1st number
            num1 = num2;
            num2 = temp;

            Console.WriteLine("\nThe first number is greater than the second one.");
            Console.WriteLine("Their values are exchanged: num1 = {0}, num2 = {1}", num1, num2);
        }
        else if (num1 < num2)
        {
            Console.WriteLine("\nThe second number is greater than the first one!");
        }
        else                                                        // if the two numbers are equal
        {
            Console.WriteLine("\nThe two numbers are equal!");
        }
    }
}