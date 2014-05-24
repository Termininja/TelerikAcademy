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
        #region First variant
        // Reads some text
        Console.WriteLine("Please, write some sentences:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                                      
        Console.ResetColor();

        // Reads some word
        Console.Write("Please, write some word: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string w = Console.ReadLine();                                         
        Console.ResetColor();

        // Printthe result
        Console.WriteLine("\nThe result is: ");

        // Matches all sentences
        foreach (var sentence in Regex.Matches(text, @"\w[^\.]+"))              
        {
            // Matches all words in each sentence
            foreach (var word in Regex.Matches(sentence.ToString(), @"\w+"))    
            {
                if (word.ToString().ToLower() == w)                             
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sentence + ". ");                        
                    Console.ResetColor();
                    break;
                }
            }
        }
        Console.WriteLine();
        #endregion

        #region Second variant
        foreach (Match sentence in Regex.Matches(text, @"[^\.]*\b" + w + @".*?\."))
        {
            Console.Write(sentence);
        }
        Console.WriteLine();
        #endregion
    }
}