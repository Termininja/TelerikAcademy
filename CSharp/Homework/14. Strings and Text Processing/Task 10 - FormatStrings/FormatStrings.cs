//Task10: Write a program that converts a string to a sequence of C# Unicode character literals.
//        Use format strings. Sample input: "Hi!". Expected output: "\u0048\u0069\u0021"

using System;

class FormatStrings
{
    static void Main()
    {
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] text = Console.ReadLine().ToCharArray();     // reads some text
        Console.ResetColor();

        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var symbol in text)                        // for each character in the text
        {
            Console.Write("\\u{0:X4}", symbol + 0);         // prints the result
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}