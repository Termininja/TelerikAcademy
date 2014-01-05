// Task 6: Write a method that returns the index of the first element in array that is bigger than its neighbors,
//         or -1, if there’s no such element. Use the method from the previous exercise.

using System;

class FirstBigger
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
            // Print the result
            if (CheckTheFirst(array) == -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThere’s no element that is bigger than its neighbors!");
            }
            else
            {
                Console.Write("\nThe first element that is bigger than its neighbors is:\nelement ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(array[CheckTheFirst(array)]);
                Console.ResetColor();
                Console.Write(" at position ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(CheckTheFirst(array));
            }
            Console.ResetColor();
        }
    }

    // Finds the 1st bigger element in array
    static int CheckTheFirst(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsBigger(arr, i)) return i;
        }
        return -1;
    }

    // If the element is bigger than its neighbors
    static bool IsBigger(int[] arr, int p)
    {
        if (p == 0) return arr[0] > arr[1];
        else if (p == arr.Length - 1) return arr[p] > arr[p - 1];
        else return arr[p] > arr[p - 1] && arr[p] > arr[p + 1];
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