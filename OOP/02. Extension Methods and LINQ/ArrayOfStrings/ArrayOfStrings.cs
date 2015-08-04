/* 
 * Problem 17. Longest string:
 *      Write a program to return the string with maximum length from an array of strings. Use LINQ.
 */

namespace ArrayOfStrings
{
    using System;
    using System.Linq;

    public class ArrayOfStrings
    {
        public static void Main()
        {
            // Creates an array of strings
            var array = new string[] { "cat", "house", "jumping", "chair", "blue" };

            // Prints the string with maximum length
            Console.WriteLine(Max(array));
        }

        private static string Max(string[] array)
        {
            return array.OrderBy(m => m.Length).Last();
        }
    }
}