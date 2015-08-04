/* 
 * Problem 3. Range Exceptions:
 *      Define a class InvalidRangeException<T> that holds information about an error condition
 *      related to invalid range. It should hold error message and a range definition [start … end].
 *      
 *      Write a sample application that demonstrates the InvalidRangeException<int> and
 *      InvalidRangeException<DateTime> by entering numbers in the range [1..100] and
 *      dates in the range [1.1.1980 … 31.12.2013].
 */

namespace Exceptions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Numbers in the range: [1 … 100]
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Test 1: Numbers in the range [1 ... 100]");
            Console.ResetColor();
            Console.Write("Enter some integer number: ");
            ValueInRange<int>(1, 100, int.Parse(Console.ReadLine()));

            // Dates in the range: [1.1.1980 … 31.12.2013]
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nTest 2: Dates in the range [1.1.1980 ... 31.12.2013]");
            Console.ResetColor();
            Console.Write("Enter some date /YYYY.MM.DD/: ");
            ValueInRange<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31), DateTime.Parse(Console.ReadLine()));
        }

        private static void ValueInRange<T>(T start, T end, T value) where T : IComparable
        {
            try
            {
                if (value.CompareTo(start) < 0 || value.CompareTo(end) > 0)
                {
                    // The value is out of range
                    throw new InvalidRangeException<T>(start, end);
                }
                else
                {
                    // The value is in the range
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The value is in the range!");
                    Console.ResetColor();
                }
            }
            catch (InvalidRangeException<T> e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}