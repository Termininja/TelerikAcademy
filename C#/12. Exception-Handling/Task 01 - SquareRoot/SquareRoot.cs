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
            // Reads some integer number
            Console.Write("Please, enter some integer number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int number = int.Parse(Console.ReadLine());
            Console.ResetColor();

            // Throw exception if the number is negative
            if (number < 0)
            {
                throw new FormatException();
            }

            // Prints the result from Sqrt()
            Console.Write("The square root of {0} is: ", number);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Math.Sqrt(number));
            Console.ResetColor();
        }
        catch (FormatException)
        {
            // If there is some format exception
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number");

        }
        catch (OverflowException)
        {
            // If the number is too big
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Too big number!");
        }
        finally
        {
            // Finally is printed "Good bye"
            Console.ResetColor();
            Console.WriteLine("\nGood bye");
        }
    }
}