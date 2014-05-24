// Task 14-15: Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//             Use variable number of arguments. Modify your last program and try to make it work for any number type,
//             not just integer (e.g. decimal, float, byte, etc.).
//             Use generic method (read in Internet about generic methods in C#).

using System;

class GenericMethod
{
    static void Main()
    {
        // Read some array
        dynamic[] array = ReadArray();

        // Print the result
        Print("\nMin", Min(array));
        Print("Max", Max(array));
        Print("Average", Average(array));
        Print("Sum", Sum(array));
        Print("Product", Product(array));
    }

    // Reads some array
    private static dynamic[] ReadArray()
    {
        // Read the number of elements in array
        Console.Write("Please, enter the number of elements in array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        dynamic[] array = new dynamic[int.Parse(Console.ReadLine())];
        Console.ResetColor();

        // Read each one element from array
        Console.Write("Please, fill the array: {");
        int len = 0;
        for (int i = 0; i < array.Length; i++)
        {
            // Reads the current element
            Console.SetCursorPosition(25 + len + i, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            array[i] = Console.ReadLine();
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

    // The minimal value of set of numbers
    static T Min<T>(T[] arr)
    {
        dynamic min = decimal.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (decimal.Parse(arr[i].ToString()) < min) min = i;
        }
        return arr[min];
    }

    // The maximal value of set of numbers
    static T Max<T>(T[] arr)
    {
        dynamic max = decimal.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (decimal.Parse(arr[i].ToString()) > max) max = i;
        }
        return arr[max];
    }

    // The average of set of numbers
    static T Average<T>(T[] arr)
    {
        dynamic result = decimal.Parse(Sum(arr).ToString()) / arr.Length;
        return result;
    }

    // The sum of set of numbers
    static T Sum<T>(T[] arr)
    {
        dynamic result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result += decimal.Parse(arr[i].ToString());
        }
        return result;
    }

    // The product of set of numbers
    static T Product<T>(T[] arr)
    {
        dynamic result = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            result *= decimal.Parse(arr[i].ToString());
        }
        return result;
    }

    // Prints some operation
    static void Print(string str, dynamic n)
    {
        Console.Write(str + ": ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0:F2}", n);
        Console.ResetColor();
    }
}