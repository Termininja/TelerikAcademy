// Task 5: Write a method that checks if the element at given position in given array
//         of integers is bigger than its two neighbors (when such exist).

using System;

class CheckTwoNeighbors
{
    static void Main()
    {
        // Read some array
        int[] array = ReadArray();

        // If the array is from only one element
        if (array.Length == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe array is from only one element!");
            Console.ResetColor();
        }
        else
        {
            // Read the position of some element in array
            Console.Write("Enter the position of some element: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int position = int.Parse(Console.ReadLine());
            Console.ResetColor();

            // Print the result
            if (position < array.Length)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nThe element at position {0} is ", position);
                if (IsBigger(array, position)) Console.WriteLine("bigger than its neighbors");
                else Console.WriteLine("not bigger than its neighbors");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe position is out of array!");
            }
            Console.ResetColor();
        }
    }

    // Checks whether some element is bigger than its neighbors
    static bool IsBigger(int[] arr, int p)
    {
        if (p == 0)                                                         // if the element is on 0 position
        {
            return arr[0] > arr[1];
        }
        else if (p == arr.Length - 1)                                     // if the element is in the end of the array
        {
            return arr[p] > arr[p - 1];
        }
        else
        {
            return arr[p] > arr[p - 1] && arr[p] > arr[p + 1];
        }
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
}