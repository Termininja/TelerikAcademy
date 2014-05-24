// Task 4: Write a method that counts how many times given number appears in given array.
//         Write a test program to check if the method is working correctly.

using System;

class CountNumber
{
    static void Main()
    {
        // Read some array
        int[] array = ReadArray();

        // Read some number
        Console.Write("Enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // Prints the result
        Console.Write("\nThe number {0} is apprearing ", number);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(CountNumberInArray(array, number));
        Console.ResetColor();
        Console.WriteLine(" times in the array");
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

    // Counts how many times a number appears in an array
    static int CountNumberInArray(int[] arr, int n)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // Counts only our number
            count += arr[i] == n ? 1 : 0;
        }

        // The result is returned
        return count;
    }
}