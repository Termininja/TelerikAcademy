    //9. Write a program that finds the most frequent number in an array.
    //   Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} → 4 (5 times)

using System;

class MostFrequentElement
{
    static void Main()
    {
        Console.Write("Enter the number of elements in arrays: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int max = int.MinValue;
        int number = int.MinValue;
        int max_number = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    number = array[i];
                    count++;
                }
            }
            if (count >= max)
            {
                max = count;
                max_number = number;
            }
        }
        Console.WriteLine(max_number + " (" + max + " times)");
    }
}