//Task23: Write a program that reads a string from the console and replaces all series of consecutive
//        identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" → "abcdedsa".

using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        #region Long variant
        // Reads some text
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // For each symbol in the text
        for (int i = 0; i < text.Length; i++)
        {
            if (i > 0)
            {
                // If the previous symbol is the same
                if (text[i] == text[i - 1])
                {
                    // Removes the current symbol
                    text = text.Remove(i, 1);

                    // Start from beginning
                    i = -1;
                }
            }
        }

        // Prints the result
        Console.Write("The result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
        #endregion

        #region Short variant (with regular expressions)
        //Console.WriteLine(Regex.Replace(text, @"(\w)\1+", "$1"));
        #endregion
    }
}