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
        #region First variant
        // Reads some text
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();
        Console.Write("\nPlease, enter some list of forbidden words: ");

        // Reads the list of forbidden words
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] list = Console.ReadLine().Trim().Replace(" ", ",").Replace(",,", ",").Split(',');
        Console.ResetColor();

        // Matches each one word in the text
        foreach (var word in Regex.Matches(text.ToString(), @"\w+"))
        {
            // For each one word in the list
            foreach (var forbidden in list)
            {
                if (word.ToString() == forbidden)
                {
                    // Replaces the forbidden words with asterisks
                    text = text.Replace(forbidden, new string('*', word.ToString().Length));
                }
            }
        }

        // Prints the result
        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
        #endregion

        #region Second variant
        //string check = "PHP, CLR, Microsoft";
        //Console.WriteLine(Regex.Replace(text, check, m => new String('*', m.Length)));
        #endregion
    }
}