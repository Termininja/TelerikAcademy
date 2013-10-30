using System;
using System.Collections.Generic;

class DurankulakNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string word = String.Empty;

        List<int> list = new List<int>();
        while (input.Length > 0)
        {
            word = 'a' <= input[0] && input[0] <= 'f' ? input.Substring(0, 2) : input[0].ToString();
            input = 'a' <= input[0] && input[0] <= 'f' ? input.Remove(0, 2) : input.Remove(0, 1);
            list.Add(Durankulak(word));
        }
        list.Reverse();

        ulong result = 0;
        for (int i = 0; i < list.Count; i++)
        {
            result += (ulong)(list[i] * Math.Pow(168, i));
        }
        Console.WriteLine(result);
    }

    static int Durankulak(string word)
    {
        int number = 0;
        switch (word.Length)
        {
            case 1: number = word[0] - 65; break;
            case 2: number = 26 * (word[0] - 96) + (word[1] - 65); break;
            default: break;
        }
        return number;
    }
}