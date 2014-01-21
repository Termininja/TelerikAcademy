using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        for (int i = 0; i < n; i++) words.Add(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string tempWord = words[i];
            words[i] = null;
            words.Insert(tempWord.Length % (n + 1), tempWord);
            words.Remove(null);
        }
        StringBuilder result = new StringBuilder();
        bool loop = true;
        int letter = 0;
        while (loop)
        {
            loop = false;
            for (int i = 0; i < n; i++)
            {
                if (words[i].Length > letter)
                {
                    result.Append(words[i][letter]);
                    loop = true;
                }
            }
            letter++;
        }
        Console.WriteLine(result);
    }
}