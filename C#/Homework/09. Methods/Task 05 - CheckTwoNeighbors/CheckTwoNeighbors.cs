//Task 5: Write a method that checks if the element at given position in given array
//        of integers is bigger than its two neighbors (when such exist).

using System;

class CheckTwoNeighbors
{
    static int[] array = new int[] { };
    static void Main()
    {
        ReadArray();                                                        // calls the "ReadArray" method
        if (array.Length == 1)                                              // is the array from only one element
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe array is from only one element!");
            Console.ResetColor();
        }
        else
        {
            Console.Write("Enter the position of some element: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int position = int.Parse(Console.ReadLine());                   // for which number will check
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nThe element at position {0} is ", position);   // prints the result
            if (IsBigger(position))                                         // calls the "IsBigger" method
            {
                Console.WriteLine("bigger than its neighbors");
            }
            else
            {
                Console.WriteLine("not bigger than its neighbors");
            }
            Console.ResetColor();
        }
    }

    static bool IsBigger(int p)                                             // is the element bigger than its neighbors
    {
        if (p == 0)                                                         // if the element is on 0 position
        {
            return array[0] > array[1];
        }
        else if (p == array.Length - 1)                                     // if the element is in the end of the array
        {
            return array[p] > array[p - 1];
        }
        else
        {
            return array[p] > array[p - 1] && array[p] > array[p + 1];
        }
    }

    static void ReadArray()                                                 // method which reads one array
    {
        Console.Write("Please, enter the number of elements in array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        array = new int[int.Parse(Console.ReadLine())];                     // what is the limit of array
        Console.ResetColor();
        Console.Write("Please, fill the array: {");
        int len = 0;                                                        // length of each one elemtent in array
        for (int i = 0; i < array.Length; i++)
        {
            Console.SetCursorPosition(25 + len + i, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            array[i] = int.Parse(Console.ReadLine());                       // reads the current element
            Console.ResetColor();
            len += array[i].ToString().Length;                              // checks the current length of the element
            if (i < array.Length - 1)                                       // is this the last element in array
            {
                Console.SetCursorPosition(25 + len + i, 1);
                Console.Write(",");
            }
        }
        Console.SetCursorPosition(24 + len + array.Length, 1);
        Console.Write("}\n");
    }
}