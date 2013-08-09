//Task14-15: Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//           Use variable number of arguments. Modify your last program and try to make it work for any number type,
//           not just integer (e.g. decimal, float, byte, etc.).
//           Use generic method (read in Internet about generic methods in C#).

using System;

class GenericMethod
{
    static void Main()
    {
        dynamic[] array = new dynamic[] { };
        array = ReadArray(array);

        PrintResult("\nMin: ", Min(array));
        PrintResult("Max: ", Max(array));
        PrintResult("Average: ", Average(array));
        PrintResult("Sum: ", Sum(array));
        PrintResult("Product: ", Product(array));
    }

    static void PrintResult(string str, dynamic res)            // prints the result
    {
        Console.Write(str);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(res);
        Console.ResetColor();
    }

    static dynamic[] ReadArray(dynamic[] arr)                   // method which reads one array
    {
        Console.Write("Please, enter the number of elements in array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        arr = new dynamic[int.Parse(Console.ReadLine())];       // what is the limit of array
        Console.ResetColor();
        Console.Write("Please, fill the array: {");
        int len = 0;                                            // length of each one elemtent in array
        for (int i = 0; i < arr.Length; i++)
        {
            Console.SetCursorPosition(25 + len + i, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            arr[i] = Console.ReadLine();                        // reads the current element
            Console.ResetColor();
            len += arr[i].ToString().Length;                    // checks the current length of the element
            if (i < arr.Length - 1)                             // is this the last element in array
            {
                Console.SetCursorPosition(25 + len + i, 1);
                Console.Write(",");
            }
        }
        Console.SetCursorPosition(24 + len + arr.Length, 1);
        Console.Write("}\n");
        return arr;
    }

    static T Min<T>(T[] arr)
    {
        dynamic min = decimal.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (decimal.Parse(arr[i].ToString()) < min)
            {
                min = i;
            }
        }
        return arr[min];
    }

    static T Max<T>(T[] arr)
    {
        dynamic max = decimal.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (decimal.Parse(arr[i].ToString()) > max)
            {
                max = i;
            }
        }
        return arr[max];
    }

    static T Average<T>(T[] arr)
    {
        dynamic res = decimal.Parse(Sum(arr).ToString()) / arr.Length;
        return res;
    }

    static T Sum<T>(T[] arr)
    {
        dynamic res = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            res += decimal.Parse(arr[i].ToString());
        }
        return res;
    }

    static T Product<T>(T[] arr)
    {
        dynamic res = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            res *= decimal.Parse(arr[i].ToString());
        }
        return res;
    }
}