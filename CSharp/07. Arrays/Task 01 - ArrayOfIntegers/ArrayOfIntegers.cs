//  Task 1. Write a program that allocates array of 20 integers and initializes each element
//          by its index multiplied by 5. Print the obtained array on the console.

using System;

class ArrayOfIntegers
{
    static void Main()
    {
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)          // allocates the array
        {
            array[i] = 5 * i;
            Console.Write(array[i] + " ");              // prints each one element
        }
        Console.WriteLine();
    }
}