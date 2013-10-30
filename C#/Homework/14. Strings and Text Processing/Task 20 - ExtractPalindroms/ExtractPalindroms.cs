//Task20: Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Text.RegularExpressions;

class ExtractPalindroms
{
    static void Main()
    {
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                   // reads some text
        Console.ResetColor();

        Console.WriteLine("\nThe palindromes are:");
        foreach (var word in Regex.Matches(text, @"\w+"))   // for each one word in the text
        {
            string w = word.ToString();
            bool palindrome = false;
            if (w.Length > 2)                               // if the word has more than 2 letters
            {
                for (int i = 0; i < w.Length / 2; i++)      // is the word palindrome
                {
                    if (w[i] == w[w.Length - 1 - i])        // if the word is palindrome
                    {
                        palindrome = true;
                    }
                    else                                    // if the word is not palindrome
                    {
                        palindrome = false;
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (palindrome)
                {
                    Console.WriteLine(w);                   // prints all palindromes
                }
                Console.ResetColor();
            }
        }
    }
}