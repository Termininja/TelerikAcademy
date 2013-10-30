//Task13: Write a program that reverses the words in given sentence. Example:
//        "C# is not C++, not PHP and not Delphi!" → "Delphi not and PHP, not C++ not is C#!".

using System;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("Please, enter some sentence:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string t = Console.ReadLine();                          // reads some text
        Console.ResetColor();
        string[] Signs = { ",", ".", ":", "!", "?", ";" };      // list of special signs
        foreach (var item in Signs)
        {
            t = t.Replace(item, " " + item);
        }
        string[] text = t.Trim().Split(' ');                    // the splitted text with signs

        string w = t;
        foreach (var item in Signs)                             // removes all signs from the text
        {
            w = w.Replace(item, "");
        }
        w = w.Replace("  ", " ");
        string[] words = w.Trim().Split(' ');                   // the splitted text without any signs
        Array.Reverse(words);                                   // reverses the list of words

        string[] result = new string[text.Length];              // list of the reverses words with signs
        int k = 0;
        for (int i = 0; i < text.Length; i++)
        {
            bool sign = false;
            foreach (var sym in Signs)                          // import the any sign in the result list
            {
                if (sym == text[i])
                {
                    result[i] = text[i];
                    k++;
                    sign = true;
                    break;
                }
            }
            if (!sign)
            {
                result[i] = words[i - k];                       // import the reversed words in the result list
            }
        }
        Console.WriteLine("\nThe result is:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result[i]);                           // prints the result list
            Console.ResetColor();
            if (i < result.Length - 1)                          // put space between words in the sentence
            {
                bool space = false;
                foreach (var item in Signs)
                {
                    if (result[i + 1] == item)
                    {
                        space = true;
                        break;
                    }
                }
                if (!space)
                {
                    Console.Write(" ");                         // writes a space
                    space = false;
                }
            }
        }
        Console.WriteLine();
    }
}