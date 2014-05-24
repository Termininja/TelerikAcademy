/*
 * Task 05: Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
 *          Keep the elements of the list in an array with fixed capacity which is given as parameter
 *          in the class constructor. Implement methods for adding element, accessing element by index,
 *          removing element by index, inserting element at given position, clearing the list, finding element
 *          by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
 * 
 * Task 06: Implement auto-grow functionality: when the internal array is full, create a new array of double size
 *          and move all elements to it.
 * 
 * Task 07: Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element
 *          in the GenericList<T>. You may need to add a generic constraints for the type T.
 */

using System;

namespace List
{
    class Program
    {
        static void Main()
        {
            // Creates a new GenericList
            GenericList<int> test = new GenericList<int>();

            // Testing all methods for this class
            test.Add(4);
            test.Add(44);
            test.Add(345);
            test.Remove(2);
            test.Add(-34);
            test.Add(200);
            test.Add(23);
            test.Insert(4, -93);

            // Prints the result from all tests
            Console.WriteLine(test.ToString());
            Console.WriteLine("The length is: {0}", test.Count());
            Console.WriteLine("The allocated length is: {0}\n", test.Length());
            Console.WriteLine("The index of element with value {0} is: {1}\n", -93, test.IndexOf(-93));
            Console.WriteLine("The minimum value is: {0}", test.Min<int>());
            Console.WriteLine("The maximum value is: {0}", test.Max<int>());
        }
    }
}