//Task 6: Create console application that prints your first and last name.

using System;

class PrintFirsLastName
{
    static void Main()
    {
        // Read the first name
        Console.Write("Please, enter your first name: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string first = Console.ReadLine();
        Console.ResetColor();

        // Read the second name
        Console.Write("And now enter your last name: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string last = Console.ReadLine();
        Console.ResetColor();

        // Print the full name
        Console.Write("Your full name is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(first + " " + last + "\n");
        Console.ResetColor();
    }
}