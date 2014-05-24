//Task20: Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Text.RegularExpressions;

class ExtractPalindroms
{
    static void Main()
    {
        // Reads some text
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // For each one word in the text
        Console.WriteLine("\nThe palindromes are:");
        foreach (var word in Regex.Matches(text, @"\w+"))
        {
            string w = word.ToString();
            bool palindrome = false;
            if (w.Length > 2)
            {
                for (int i = 0; i < w.Length / 2; i++)
                {
                    // If the word is palindrome
                    if (w[i] == w[w.Length - 1 - i]) palindrome = true;
                    else
                    {
                        palindrome = false;
                        break;
                    }
                }

                // Prints all palindromes
                Console.ForegroundColor = ConsoleColor.Green;
                if (palindrome) Console.WriteLine(w);
                Console.ResetColor();
            }
        }
    }
}