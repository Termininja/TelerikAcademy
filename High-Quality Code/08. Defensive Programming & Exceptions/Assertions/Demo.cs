//Task 01. Use the given source code. Add assertions in the code from the project 
//to ensure all possible preconditions and postconditions are checked.

namespace Assertions
{
    using System;

    class Demo
    {
        /// <summary>
        /// Demonstration of class Assertions
        /// </summary>
        static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            Assertions.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            // Test sorting empty array
            Assertions.SelectionSort(new int[0]);

            // Test sorting single element array
            Assertions.SelectionSort(new int[1]);

            Console.WriteLine(Assertions.BinarySearch(arr, -1000));
            Console.WriteLine(Assertions.BinarySearch(arr, 0));
            Console.WriteLine(Assertions.BinarySearch(arr, 17));
            Console.WriteLine(Assertions.BinarySearch(arr, 10));
            Console.WriteLine(Assertions.BinarySearch(arr, 1000));
        }
    }
}
