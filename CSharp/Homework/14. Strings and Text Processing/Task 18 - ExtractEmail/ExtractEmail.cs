//Task18: Write a program for extracting all email addresses from given text.
//        All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmail
{
    static void Main()
    {
        Console.Write("Please, enter some text including emails: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();           // reads some text including emails
        Console.ResetColor();

        Console.WriteLine("\nThe emails are:");
        foreach (var email in Regex.Matches(text, @"\w+@\w+\.\w+"))  // for each email in the text
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(email);               // prints the all emails
            Console.ResetColor();
        }
    }
}