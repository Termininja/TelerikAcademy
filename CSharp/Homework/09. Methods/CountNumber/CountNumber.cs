//Task 4: Write a method that counts how many times given number appears in given array.
//        Write a test program to check if the method is working correctly.

using System;

class CountNumber
{        
    static int[] array = new int[] { };
    static void Main()
    {
        ReadArray();                                                // calls the "ReadArray" method
        Console.Write("Enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());                 // for which number will check
        Console.ResetColor();
        Console.Write("\nThe number {0} is apprearing ", number);   // prints the result
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(CountNumberInArray(number));                  // calls the "CountNumberInArray" method
        Console.ResetColor();
        Console.WriteLine(" times in the array");
    }

    static int CountNumberInArray(int n)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)                      // we checks all elements in the array
        {
            count += array[i] == n ? 1 : 0;                         // counts only our number
        }
        return count;                                               // the result is returned
    }

    static void ReadArray()                                         // method which reads one array
    {
        Console.Write("Please, enter the number of elements in array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        array = new int[int.Parse(Console.ReadLine())];             // what is the limit of array
        Console.ResetColor();
        Console.Write("Please, fill the array: {");
        int len = 0;                                                // length of each one elemtent in array
        for (int i = 0; i < array.Length; i++)
        {
            Console.SetCursorPosition(25 + len + i, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            array[i] = int.Parse(Console.ReadLine());               // reads the current element
            Console.ResetColor();
            len += array[i].ToString().Length;                      // checks the current length of the element
            if (i < array.Length - 1)                               // is this the last element in array
            {
                Console.SetCursorPosition(25 + len + i, 1);
                Console.Write(",");
            }
        }
        Console.SetCursorPosition(24 + len + array.Length, 1);
        Console.Write("}\n");
    }
}