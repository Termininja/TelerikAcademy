//Task1: Write a program that reads an integer number and calculates and prints its square root.
//       If the number is invalid or negative, print "Invalid number".
//       In all cases finally print "Good bye". Use try-catch-finally.

using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Please, enter some integer number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int number = int.Parse(Console.ReadLine());     // reads some integer number
            Console.ResetColor();
            if (number < 0)                                 // throw exception if the number is negative
            {
                throw new FormatException();
            }
            Console.Write("The square root of {0} is: ", number);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Math.Sqrt(number));           // prints the result from Sqrt()
            Console.ResetColor();
        }
        catch (FormatException)                             // when there is "FormatException"
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number");

        }
        catch (OverflowException)                           // when the number is too big
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Too big number!");
        }
        finally                                             // finally is printed "Good bye"
        {
            Console.ResetColor();
            Console.WriteLine("\nGood bye");
        }
    }
}