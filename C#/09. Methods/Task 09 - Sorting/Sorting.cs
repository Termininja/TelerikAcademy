// Task 9: Write a method that return the maximal element in a portion of array
//         of integers starting at given index. Using it write another method
//         that sorts an array in ascending / descending order.

using System;

class Sorting
{
    static void Main()
    {
        // Read some array
        int[] array = ReadArray();

        // Sort the array in descending order and print it
        Console.Write("Descending: ");
        array = Sort(array, false);
        PrintArray(array);

        // Sort the array in ascending order and print it
        Console.Write("Ascending: ");
        array = Sort(array, true);
        PrintArray(array);
    }

    // Reads some array
    private static int[] ReadArray()
    {
        // Read the number of elements in array
        Console.Write("Please, enter the number of elements in array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int[] array = new int[int.Parse(Console.ReadLine())];
        Console.ResetColor();

        // Read each one element from array
        Console.Write("Please, fill the array: {");
        int len = 0;
        for (int i = 0; i < array.Length; i++)
        {
            // Reads the current element
            Console.SetCursorPosition(25 + len + i, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            array[i] = int.Parse(Console.ReadLine());
            Console.ResetColor();

            // Checks the current length of the element
            len += array[i].ToString().Length;

            // Is this the last element in array
            if (i < array.Length - 1)
            {
                Console.SetCursorPosition(25 + len + i, 1);
                Console.Write(",");
            }
        }
        Console.SetCursorPosition(24 + len + array.Length, 1);
        Console.WriteLine("}\n");
        return array;
    }

    // Takes the max number from some portion
    static int Maximal(int[] numbers, int index, int p)
    {
        int max = int.MinValue;
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

    // Sort some array
    static int[] Sort(int[] arr, bool ascending)
    {
        int max = Maximal(arr, 0, arr.Length);
        int[] sorted = new int[arr.Length];

        // Sort the array in descending order
        for (int i = 0; i < arr.Length; i++)
        {
            max = Maximal(arr, 0, arr.Length);
            sorted[i] = arr[max];
            arr[max] = int.MinValue;
        }

        // Sort the array in ascending order
        if (ascending) Array.Reverse(sorted);

        return sorted;
    }

    // Print some array
    static void PrintArray(int[] arr)
    {
        Console.Write("{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(arr[i]);
            Console.ResetColor();
            Console.Write(i == arr.Length - 1 ? "}\n" : ",");
        }
    }
}