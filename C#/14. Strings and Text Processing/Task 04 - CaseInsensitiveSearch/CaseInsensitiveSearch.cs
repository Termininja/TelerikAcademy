//Task4: Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//       Example: The target substring is "in". The text is as follows:
//                "We are living in an yellow submarine. We don't have anything else.
//                Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."
//       The result is: 9.

using System;
using System.Text.RegularExpressions;

class CaseInsensitiveSearch
{
    static void Main()
    {
        #region Long variant
        // Reads some text and convert it to lowercase
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine().ToLower();
        Console.ResetColor();

        // Reads some subtext and convert it to lowercase
        Console.Write("Write some subtext: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string subtext = Console.ReadLine().ToLower();
        Console.ResetColor();

        int count = 0;
        int position = 0;
        while (true)
        {
            // Change the position for each one subtext
            position = text.IndexOf(subtext, position) + 1;

            // If subtext is not found in the text
            if (position == 0) break;
            else count++;
        }
        // Prints the result
        Console.Write("\nThe subtext is contained ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(count);
        Console.ResetColor();
        Console.WriteLine(" times in the text!");
        #endregion

        #region Short variant (with regular expressions)
        //Console.WriteLine(Regex.Matches(text, subtext, RegexOptions.IgnoreCase).Count);
        #endregion
    }
}