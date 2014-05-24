//Task18: Write a program for extracting all email addresses from given text.
//        All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmail
{
    static void Main()
    {
        // Reads some text including emails
        Console.Write("Please, enter some text including emails: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // Prints the all emails
        Console.WriteLine("\nThe emails are:");

        // For each email in the text
        foreach (var email in Regex.Matches(text, @"\w+@\w+\.\w+"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(email);
            Console.ResetColor();
        }
    }
}