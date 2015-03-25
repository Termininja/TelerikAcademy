/*
 * Problem 2. IEnumerable extensions:
 *      Implement a set of extension methods for IEnumerable<T> that implement
 *      the following group functions: sum, product, min, max, average.
 */

namespace IEnumerableExtension
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Test<int>("int collection", "{0,12}", 3 / 2, 12);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Console.Write("\b \b");
                    switch (key.Key)
                    {
                        // Test for type integer
                        case ConsoleKey.I:
                            Console.Clear();
                            Test<int>("int collection", "{0,12}", 3 / 2, 12);
                            break;
                        // Test for type double
                        case ConsoleKey.D:
                            Console.Clear();
                            Test<double>("double collection", "{0,12:F2}", 0.73, 8);
                            break;
                        // Test for type float
                        case ConsoleKey.F:
                            Console.Clear();
                            Test<float>("float collection", "{0,12:F1}", 0.49f, 9);
                            break;
                        // Test for type decimal
                        case ConsoleKey.M:
                            Console.Clear();
                            Test<decimal>("decimal collection", "{0,12:F3}", 0.491m, 7);
                            break;
                        // Exit
                        case ConsoleKey.Q:
                            return;
                        default:
                            break;
                    }
                }
            }
        }

        private static void Test<T>(string name, string format, dynamic randCoefficient, int length)
            where T : IComparable<T>
        {
            // Creates an empty collection of elements
            var collection = new T[length];

            // Fill the collection by random generator and print it
            var generator = new Random();
            Console.Write("{0} = {{", name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i] = (dynamic)generator.Next(-9, 10) * randCoefficient;
            }

            Console.Write(string.Join(", ", collection));
            Console.ResetColor();
            Console.WriteLine("}");

            // Prints the result from the test
            Console.WriteLine("\nCount\t:{0,12}", collection.Count());
            Console.WriteLine("Sum\t:" + format, collection.Sum<T>());
            Console.WriteLine("Product\t:" + format, collection.Product<T>());
            Console.WriteLine("Min\t:" + format, collection.Min<T>());
            Console.WriteLine("Max\t:" + format, collection.Max<T>());
            Console.WriteLine("Average\t:" + format, collection.Average<T>());
            Console.WriteLine("\n");

            // Prints the menu
            PrintMenu('I', "Int, ");
            PrintMenu('F', "Float, ");
            PrintMenu('D', "Double, ");
            PrintMenu('M', "Decimal, ");
            PrintMenu('Q', "Exit");
        }

        private static void PrintMenu(char key, string name)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.Write("] {0}", name);
        }
    }
}