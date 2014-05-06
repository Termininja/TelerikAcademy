using System;
using System.Collections.Generic;
using System.Linq;

class TwoIsBetterThanOne
{
    static void Main()
    {
        Console.WriteLine(Task1(Console.ReadLine().Split(' ')));
        Console.WriteLine(Task2(Console.ReadLine().Split(','), int.Parse(Console.ReadLine())));
    }

    static int Task1(string[] input)
    {
        long A = long.Parse(input[0]);
        long B = long.Parse(input[1]);

        List<long> list = new List<long> { 3, 5 };

        int start = 0;
        while (list.Last() <= B)
        {
            int end = list.Count;
            for (int i = start; i < end; i++)
            {
                list.Add((10 * list[i]) + 3);
                list.Add((10 * list[i]) + 5);
            }
            start = end;
        }

        int count = 0;
        foreach (var num in list)
        {
            if (num >= A && num <= B)
            {
                bool isPalindrome = true;
                string word = num.ToString();
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - i - 1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome) count++;
            }
        }
        return count;
    }

    static int Task2(string[] input, int P)
    {
        List<int> list = new List<int>();
        foreach (var num in input)
        {
            list.Add(int.Parse(num));
        }

        list.Sort();
        for (int i = 0; i < list.Count; i++)
        {
            int count = 0;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] <= list[i]) count++;
            }

            if (count >= P * list.Count / 100d) return list[i];
        }
        return 0;
    }
}