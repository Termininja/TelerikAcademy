//Task6: Write a program that reads from the console a string of maximum 20 characters.
//       If the length of the string is less than 20, the rest of the characters should be filled with '*'.
//       Print the result string into the console.

using System;

class LengthOfString
{
    static void Main()
    {
        string str = "";
        while (str.Length > 20 || str.Length == 0)          // if the string is empty or too long
        {
            Console.Write("Please, enter some string of maximum 20 characters: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            str = Console.ReadLine();                       // reads the string
            Console.ResetColor();
        }

        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(str.PadRight(20, '*'));           // prints the result
        Console.ResetColor();
    }
}