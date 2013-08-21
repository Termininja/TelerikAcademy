//Task22: Write a program that reads a string from the console and lists all different words
//        in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class DifferentWords
{
    static void Main()
    {
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                           // reads some text
        Console.ResetColor();

        Dictionary<string, int> D = new Dictionary<string, int>();  // creates empty Dictionary
        foreach (var word in Regex.Matches(text, @"\w+"))           // for each one word in the text
        {
            if (D.ContainsKey(word.ToString()))                     // if the word is in the Dictionary
            {
                D[word.ToString()] += 1;                            // count++ for the word
            }
            else
            {
                D.Add(word.ToString(), 1);                          // adds this word in the Dictionary
            }
        }

        Console.WriteLine();
        foreach (var w in D)
        {
            Console.Write("{0,15}: ", w.Key);                       // prints the words from the Dictionary
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(w.Value);                             // prints how many times each word is found
            Console.ResetColor();
        }
    }
}