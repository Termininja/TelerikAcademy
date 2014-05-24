//Task6: Write a program that reads from the console a string of maximum 20 characters.
//       If the length of the string is less than 20, the rest of the characters should be filled with '*'.
//       Print the result string into the console.

using System;

class LengthOfString
{
    static void Main()
    {
        string str = String.Empty;
        while (str.Length > 20 || str.Length == 0)
        {
            // Reads some string
            Console.Write("Please, enter some string of maximum 20 characters: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            str = Console.ReadLine();
            Console.ResetColor();
        }

        // Prints the result
        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(str.PadRight(20, '*'));
        Console.ResetColor();
    }
}