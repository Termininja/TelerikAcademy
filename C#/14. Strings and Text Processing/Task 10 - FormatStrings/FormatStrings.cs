//Task10: Write a program that converts a string to a sequence of C# Unicode character literals.
//        Use format strings. Sample input: "Hi!". Expected output: "\u0048\u0069\u0021"

using System;

class FormatStrings
{
    static void Main()
    {
        // Reads some text
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] text = Console.ReadLine().ToCharArray();
        Console.ResetColor();

        // Prints the result
        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var symbol in text)
        {
            Console.Write("\\u{0:X4}", symbol + 0);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}