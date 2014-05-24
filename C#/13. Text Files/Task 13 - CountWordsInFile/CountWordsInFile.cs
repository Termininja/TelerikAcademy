//Task13. Write a program that reads a list of words from a file words.txt and finds how many
//        timeseach of the words is contained in another file test.txt. The result should be
//        written in the file result.txt and the words should be sorted by the number of their
//        occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class CountWordsInFile
{
    static void Main()
    {
        StringBuilder contents = new StringBuilder();
        List<int> resultKey = new List<int>();
        List<string> resultValue = new List<string>();

        // Reads some text file
        StreamReader readText = new StreamReader("test.txt");
        using (readText) contents.Append(readText.ReadToEnd());

        // Reads some file with words
        StreamReader readWords = new StreamReader("words.txt");
        string word = readWords.ReadLine();

        // For each one word in the file with words
        for (int line = 1; word != null; line++)
        {
            // Counting the current word
            int count = 0;
            foreach (Match item in Regex.Matches(contents.ToString(), String.Format(@"\b{0}\b", word)))
            {
                count++;
            }

            // Put the current word and count in lists
            resultValue.Add(word);
            resultKey.Add(count);

            // Reads the next word
            word = readWords.ReadLine();
        }

        // Converts the lists to arrays
        int[] c = resultKey.ToArray();
        string[] w = resultValue.ToArray();

        // Sorting both arrays by 'count'
        Array.Sort(c, w);

        // Write the result in some text file
        StreamWriter write = new StreamWriter("result.txt");
        using (write)
        {
            for (int i = 0; i < c.Length; i++)
            {
                write.WriteLine("{0}: {1}", w[i], c[i]);
            }
        }
    }
}