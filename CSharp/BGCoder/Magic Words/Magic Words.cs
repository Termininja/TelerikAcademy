using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        List<string> list = new List<string>();
        int n = int.Parse(Console.ReadLine());
        for (int word = 0; word < n; word++)
            list.Add(Console.ReadLine());

        for (int word = 0; word < n; word++)
        {
            string tempWord = list[word];
            list[word] = null;
            if (tempWord.Length % (n + 1) == n)
                list.Add(tempWord);
            else 
                list.Insert(tempWord.Length % (n + 1), tempWord);
            list.Remove(null);
        }

        StringBuilder result = new StringBuilder();
        bool cont = true;
        for (int letter = 0; cont == true; letter++)
        {
            cont = false;
            for (int word = 0; word < n; word++)
            {
                if (letter < list[word].Length)
                {
                    result.Append(list[word][letter]);
                    cont = true;
                }
            }
        }
        Console.WriteLine(result);
    }
}