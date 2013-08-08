//5. Write a program that finds the maximal increasing sequence in an array.
//   Example: {3, 2, 3, 4, 2, 2, 4} → {2, 3, 4}.

using System;

class MaxIncreasingSequence
{
    static void Main()
    {
        Console.Write("Enter the number of elements in array: ");
        int[] array = new int[int.Parse(Console.ReadLine())];

        int count = 1;
        int max = 1;
        int num = 0;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());

            if (i > 0 && array[i] == array[i - 1] + 1)
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count >= max)
            {
                max = count;
                num = array[i];
            }
        }
        num = num - (max - 1);
        Console.Write("{");
        for (int i = 1; i <= max; i++)
        {
            Console.Write(num + i - 1);
            if (i < max)
            {
                Console.Write(", ");
            }
        }
        Console.Write("}");
        Console.WriteLine();
    }
}