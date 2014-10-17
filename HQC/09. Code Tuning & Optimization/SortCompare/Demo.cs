//Task 04*. Write a program to compare the performance of insertion sort, selection
//sort, quicksort for int, double and string values. Check also the following cases:
//random values, sorted values, values sorted in reversed order.

namespace SortCompare
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// All types of sorting.
    /// </summary>
    enum Sort { Insertion, Selection, Quicksort }

    /// <summary>
    /// Demonstration of class SortCompare
    /// </summary>
    class Demo
    {
        static void Main()
        {
            Console.WriteLine(CheckType(Sort.Insertion));
            Console.WriteLine(CheckType(Sort.Selection));
            Console.WriteLine(CheckType(Sort.Quicksort));
        }

        /// <summary>
        /// Checks the performance for some operation for int, double and string.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns>Returns the performance like string.</returns>
        private static StringBuilder CheckType(Sort operation)
        {
            int[] intArray = { 13, 62, 82, 9, 35, 4, 64, 8, 53, 2, 44 };
            double[] doubleArray = { 1.3, 6.2, 8.2, 9.0, 3.5, 4.0, 6.4, 8.0, 5.3, 2.0, 4.4 };
            string[] stringArray = { "ccc", "ppp", "kkk", "sss", "mmm", "aaa", "zzz", "fff" };

            StringBuilder result = new StringBuilder();
            result.Append(operation + ":\n");
            result.Append(StopWatch("int", operation, intArray) + "\n");
            result.Append(StopWatch("double", operation, doubleArray) + "\n");
            result.Append(StopWatch("string", operation, stringArray) + "\n");

            return result;
        }

        /// <summary>
        /// Calculates the performance time for some type and some operation.
        /// </summary>
        /// <param name="type">The value type.</param>
        /// <param name="operation">The executed operation.</param>
        /// <returns>Returns the performance time like string.</returns>
        private static string StopWatch<T>(string type, Sort operation, T[] array) where T : IComparable<T>
        {
            Stopwatch intTime = new Stopwatch();
            intTime.Start();
            switch (operation)
            {
                case Sort.Insertion: SortCompare.Insertion<T>(array); break;
                case Sort.Selection: SortCompare.Selection<T>(array); break;
                case Sort.Quicksort: SortCompare.Quicksort<T>(array); break;
                default: break;
            }
            intTime.Stop();

            string elapsedTime = String.Format("{0,-10} {1}", type, intTime.Elapsed);

            return elapsedTime;
        }
    }
}
