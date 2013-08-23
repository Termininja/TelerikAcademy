//Task9: We are given a string containing a list of forbidden words and a text containing some
//       of these words. Write a program that replaces the forbidden words with asterisks.
//       Example:
//          "Microsoft announced its next generation PHP compiler today.
//          It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR."
//       Words: "PHP, CLR, Microsoft"
//       The expected result:
//          "********* announced its next generation *** compiler today.
//          It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***."

using System;
using System.Text.RegularExpressions;

class ReplaceForbiddenWords
{
    static void Main()
    {
        /* 1st variant */
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                               // reads some text
        Console.ResetColor();
        Console.Write("\nPlease, enter some list of forbidden words: ");

        // reads the list of forbidden words
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] list = Console.ReadLine().Trim().Replace(" ", ",").Replace(",,", ",").Split(',');
        Console.ResetColor();

        foreach (var word in Regex.Matches(text.ToString(), @"\w+"))    // matches each one word in the text
        {
            foreach (var forbidden in list)                             // for each one word in the list
            {
                if (word.ToString() == forbidden)
                {
                    // replaces the forbidden words with asterisks
                    text = text.Replace(forbidden, new string('*', word.ToString().Length));
                }
            }
        }
        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);                                        // prints the result
        Console.ResetColor();

        /* 2nd variant */
        //string check = "PHP, CLR, Microsoft";
        //Console.WriteLine(Regex.Replace(text, check, m => new String('*', m.Length)));
    }
}