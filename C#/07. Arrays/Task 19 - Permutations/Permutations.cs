//19. * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
//      Example: N = 3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;
using System.Collections.Generic;
using System.Linq;

class Permutations
{
    static void Main()
    {
        // Read some integer number
        Console.Write("Please, enter some integer number: ");
        int N = int.Parse(Console.ReadLine());

        // Create one word with all needed numbers
        string word = String.Empty;
        for (int i = 1; i <= N; i++)
        {
            word += i;
        }

        // Find all permutations of the numbers
        List<string> numbers = new List<string>();
        numbers = AllPermutations(numbers, "", word);

        // Print all possible permutations
        Console.WriteLine("All possible permutations are:");
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers[i].Length; j++)
            {
                Console.Write(numbers[i][j]);
            }
            Console.WriteLine();
        }
    }

    // Returns all permutation of 'str'
    public static List<string> AllPermutations(List<string> list, String start, String str)
    {
        if (str.Length <= 1)
            list.Add(start + str);
        else
            for (int i = 0; i < str.Length; i++)
            {
                String newStr = str.Substring(0, i) + str.Substring(i + 1);
                AllPermutations(list, start + str.ElementAt(i), newStr);
            }
        return list;
    }
}