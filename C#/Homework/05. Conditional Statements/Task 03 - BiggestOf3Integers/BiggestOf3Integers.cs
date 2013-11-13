//Task 3: Write a program that finds the biggest of three integers using nested if statements.

using System;

class BiggestOf3Integers
{
    static void Main()
    {
        // Read three integer numbers
        Console.Write("Please, enter the 1st integer number: ");
        int number1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: ");
        int number2 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 3rd integer number: ");
        int number3 = int.Parse(Console.ReadLine());

        // If the three numbers are equal
        if (number1 == number2 && number2 == number3) Console.WriteLine("The three numbers are equal!");

        // If the 1st number is the biggest
        else if (number1 > number2 && number1 > number3) Console.WriteLine("The biggest number is {0}", number1);

        // If the 2nd number is the biggest
        else if (number2 > number1 && number2 > number3) Console.WriteLine("The biggest number is {0}", number2);

        // If the 3rd number is the biggest
        else if (number3 > number1 && number3 > number2) Console.WriteLine("The biggest number is {0}", number3);
    }
}