//6. Write a program that reads two integer numbers N and K and an array of N elements from the console.
//   Find in the array those K elements that have maximal sum.

using System;

class SumOfElements
{
    static void Main()
    {
        Console.Write("N = ");
        int[] array = new int[int.Parse(Console.ReadLine())];

        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        int max = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int best_i = 0;
        for (int i = 0; i < array.Length - (K - 1); i++)
        {
            int sum = 0;
            for (int k = i; k < i + K; k++)
            {
                sum += array[k];
            }
            if (sum > max)
            {
                max = sum;
                best_i = i;
            }
        }
        Console.WriteLine("Max sum is {0} for elements: ", max);
        for (int i = best_i; i < best_i + K; i++)
        {
            Console.WriteLine("[{0}] = {1}", i, array[i]);
        }
        Console.WriteLine();
    }
}