//Task 1: Write an if statement that examines two integer variables and exchanges
//        their values if the first one is greater than the second one.

using System;

class CompareAndExchange
{
    static void Main()
    {
        // Read two integer numbers
        Console.Write("Please, enter the 1st integer number: num1 = ");
        int number1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: num2 = ");
        int number2 = int.Parse(Console.ReadLine());

        // The both values will be exchanged only if num1 > num2
        if (number1 > number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;

            Console.WriteLine("\nThe first number is greater than second one.");
            Console.WriteLine("Their values are exchanged: num1 = {0}, num2 = {1}", number1, number2);
        }
        else if (number1 < number2) Console.WriteLine("\nThe second number is greater than first one!");
        else Console.WriteLine("\nThe two numbers are equal!");
    }
}