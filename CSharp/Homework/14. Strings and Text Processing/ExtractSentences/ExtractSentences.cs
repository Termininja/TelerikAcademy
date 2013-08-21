//Task8: Write a program that extracts from a given text all sentences containing given word.
//       Example: The word is "in". The text is:
//          "We are living in a yellow submarine. We don't have anything else. Inside the submarine
//          is very tight. So we are drinking all the day. We will move out of it in 5 days."
//       The expected result is:
//          "We are living in a yellow submarine. We will move out of it in 5 days."
//       Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main()
    {
        /* 1st variant*/
        Console.WriteLine("Please, write some sentences:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                                       // reads some text
        Console.ResetColor();
        Console.Write("Please, write some word: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string w = Console.ReadLine();                                          // reads some word
        Console.ResetColor();

        Console.WriteLine("\nThe result is: ");
        foreach (var sentence in Regex.Matches(text, @"\w[^\.]+"))              // matches all sentences
        {
            foreach (var word in Regex.Matches(sentence.ToString(), @"\w+"))    // matches all words in each sentence
            {
                if (word.ToString().ToLower() == w)                             // is the word eaqual to our word 'w'
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sentence + ". ");                             // prints the sentence including 'w'
                    Console.ResetColor();
                    break;
                }
            }
        }
        Console.WriteLine();

        /* 2nd variant*/
        foreach (Match sentence in Regex.Matches(text, @"[^\.]*\b" + w + @".*?\."))
        {
            Console.Write(sentence);
        }
        Console.WriteLine();
    }
}