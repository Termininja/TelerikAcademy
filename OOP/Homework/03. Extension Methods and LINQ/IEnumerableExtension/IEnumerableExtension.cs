// Task 02. Implement a set of extension methods for IEnumerable<T> that implement
//          the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Threading;

public static class IEnumerableExtension
{
    static ConsoleKeyInfo key;
    public static void Main()
    {
        Test<int>("int collection", "{0,3}", "{0,12}", 3 / 2, 12);
        while (true)
        {
            if (key.Key != ConsoleKey.Q) Console.Clear();
            if (key.Key == ConsoleKey.I) Test<int>("int collection", "{0,3}", "{0,12}", 3 / 2, 12);                     // test for type int
            else if (key.Key == ConsoleKey.D) Test<double>("double collection", "{0,6:F2}", "{0,12:F2}", 0.73, 8);      // test for type double
            else if (key.Key == ConsoleKey.F) Test<float>("float collection", "{0,5:F1}", "{0,12:F1}", 0.49f, 9);       // test for type float
            else if (key.Key == ConsoleKey.M) Test<decimal>("decimal collection", "{0,7:F3}", "{0,12:F3}", 0.491m, 7);  // test for type decimal
            else if (key.Key == ConsoleKey.Q) break;                                                                    // exit
        }
    }

    // Testing method
    private static void Test<T>(string name, String f1, String f2, dynamic coefficient, int length) where T : IComparable<T>
    {
        while (true)
        {
            // Creates some empty collection of elements
            T[] collection = new T[length];

            // Fill the collection by random generator and print it
            Random generator = new Random();
            Console.Write("{0} = {{", name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i] = (dynamic)generator.Next(-9, 10) * coefficient;
                Console.Write(f1, collection[i]);
                if (i != collection.Length - 1) Console.Write(",");
                else
                {
                    Console.ResetColor();
                    Console.WriteLine("}");
                }
            }

            // Prints the result from the test
            Console.WriteLine("\nCount\t:{0,12}", collection.Count<T>());
            Console.WriteLine("First\t:" + f2, collection.First<T>());
            Console.WriteLine("Sum\t:" + f2, collection.Sum<T>());
            Console.WriteLine("Product\t:" + f2, collection.Product<T>());
            Console.WriteLine("Min\t:" + f2, collection.Min<T>());
            Console.WriteLine("Max\t:" + f2, collection.Max<T>());
            Console.WriteLine("Average\t:" + f2, collection.Average<T>());
            Console.WriteLine();

            // Switch to another test
            Console.WriteLine();
            PrintMenu('I', "Int, ");
            PrintMenu('F', "Float, ");
            PrintMenu('D', "Double, ");
            PrintMenu('M', "Decimal, ");
            PrintMenu('Q', "Exit...");
            Thread.Sleep(1000);
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                Console.Write("\b \b");
                if (key.Key == ConsoleKey.I |
                    key.Key == ConsoleKey.D |
                    key.Key == ConsoleKey.F |
                    key.Key == ConsoleKey.M |
                    key.Key == ConsoleKey.Q) break;
            }
            Console.Clear();
        }
    }

    // Methods
    private static void PrintMenu(char key, string name)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(key);
        Console.ResetColor();
        Console.Write("] {0}", name);
    }

    // Extension methods
    static T Sum<T>(this IEnumerable<T> collection)                                 // sum function
    {
        dynamic sum = 0;
        foreach (var item in collection) sum += (dynamic)item;
        return sum;
    }

    static T Product<T>(this IEnumerable<T> collection)                             // product function
    {
        dynamic product = 1;
        foreach (var item in collection) product *= (dynamic)item;
        return product;
    }

    static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>        // min function
    {
        T min = collection.First<T>();
        foreach (var item in collection)
        {
            if (((dynamic)item).CompareTo(min) < 0) min = item;
        }
        return min;
    }

    static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>        // max function
    {
        T max = collection.First<T>();
        foreach (var item in collection)
        {
            if (((dynamic)item).CompareTo(max) > 0) max = item;
        }
        return max;
    }

    static T Average<T>(this IEnumerable<T> collection) where T : IComparable<T>    // average function
    {
        return (dynamic)collection.Sum<T>() / collection.Count<T>();
    }

    static T First<T>(this IEnumerable<T> collection)                               // first element function
    {
        foreach (var item in collection) return item;
        return default(T);
    }

    static T Count<T>(this IEnumerable<T> collection)                               // count function
    {
        dynamic count = 0;
        foreach (var item in collection) count++;
        return count;
    }
}