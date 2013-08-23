//Task23: Write a program that reads a string from the console and replaces all series of consecutive
//        identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" → "abcdedsa".

using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        /* Long variant */
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();               // reads some text
        Console.ResetColor();

        for (int i = 0; i < text.Length; i++)           // for each symbol in the text
        {
            if (i > 0)
            {
                if (text[i] == text[i - 1])             // if the previous symbol is the same
                {
                    text = text.Remove(i, 1);           // removes the current symbol
                    i = -1;                             // to start from beginning
                }
            }
        }
        Console.Write("The result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);                        // prints the result
        Console.ResetColor();

        /* Short variant (with regular expressions) */
        //Console.WriteLine(Regex.Replace(text, @"(\w)\1+", "$1"));
    }
}