/*
 * Problem 5. Generic class:
 *     Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
 *     Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
 *     Implement methods for adding element, accessing element by index, removing element by index, inserting element at 
 *     given position, clearing the list, finding element by its value and ToString().
 *     Check all input parameters to avoid accessing elements at invalid positions.
 * 
 * Problem 6. Auto-grow:
 *     Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
 * 
 * Problem 7. Min and Max:
 *     Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
 *     You may need to add a generic constraints for the type T.
 */

namespace List
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Creates a new GenericList
            var genericList = new GenericList<int>();

            // Testing all methods for class GenericList<T>
            genericList.Add(4);
            genericList.Add(44);
            genericList.Add(345);
            genericList.Remove(2);
            genericList.Add(-34);
            genericList.Add(200);
            genericList.Add(23);
            genericList.Insert(4, -93);

            // Prints the result from all tests
            Console.WriteLine(genericList.ToString());
            Console.WriteLine("The length is: {0}", genericList.Count());
            Console.WriteLine("The allocated length is: {0}\n", genericList.Length());
            Console.WriteLine("The index of element with value {0} is: {1}\n", -93, genericList.IndexOf(-93));
            Console.WriteLine("The minimum value is: {0}", genericList.Min<int>());
            Console.WriteLine("The maximum value is: {0}", genericList.Max<int>());
        }
    }
}