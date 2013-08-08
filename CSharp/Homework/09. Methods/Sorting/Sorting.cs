//Task9: Write a method that return the maximal element in a portion of array
//       of integers starting at given index. Using it write another method
//       that sorts an array in ascending / descending order.

using System;

class Sorting
{
    static void Main()
    {
        Console.Write("Please, enter the number of elements in array: ");
        int?[] numbers = new int?[int.Parse(Console.ReadLine())];
        for (int i = 0; i < numbers.Length; i++)            // reads the array
        {
            Console.Write("Array[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int?[] sorted_descending = new int?[numbers.Length];
        int?[] sorted_ascending = new int?[numbers.Length];

        int index = 2;                                      //from where start the portion
        int portion = 3;                                    //how many numbers will be checked

        int max = Maximal(numbers, index, portion);         //takes the max number from the portion
        Console.Write("Descending: ");
        Descending(numbers, sorted_descending, max);        //sorting in descending order
        Console.Write("Ascending: ");
        Ascending(sorted_descending, sorted_ascending);     //sorting in ascending order
    }

    static void Descending(int?[] numbers, int?[] sorted, int max)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            max = Maximal(numbers, 0, numbers.Length);
            sorted[i] = numbers[max];
            numbers[max] = null;
        }
        foreach (var item in sorted)                        // prints array in descending order
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Ascending(int?[] numbers, int?[] sorted)
    {
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            sorted[numbers.Length - i - 1] = numbers[i];
        }
        foreach (var item in sorted)                        // prints array in ascending order
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static int Maximal(int?[] numbers, int index, int p)
    {
        int? max = int.MinValue;
        int pos = 0;
        for (int j = index; j < index + p; j++)
        {
            if (numbers[j] > max)
            {
                max = numbers[j];
                pos = j;
            }
        }
        return pos;
    }
}