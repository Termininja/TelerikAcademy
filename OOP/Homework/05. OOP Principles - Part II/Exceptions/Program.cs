/* Task 03.
 * Define a class InvalidRangeException<T> that holds information about an  
 * related to invalid range. It should hold error message and a range definition [start … end].
 * 
 * Write a sample application that demonstrates the InvalidRangeException<int> and
 * InvalidRangeException<DateTime> by entering:
 *      numbers in the range → [1..100]
 *      dates in the range → [1.1.1980 … 31.12.2013]
 */

using System;
using System.Threading;

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            // Numbers in the range
            Console.WriteLine("Test 1: Numbers in the range\n");
            Thread.Sleep(3000);

            InvalidRangeException<int> newEx = new InvalidRangeException<int>();
            newEx.ErrorMessage = "Wrong number!";
            for (int number = 1; number <= 100; number++)
            {
                Console.Write("\n" + number + "\t: ");
                newEx.ErrorCondition(number, 48, 72);
                Thread.Sleep(100);
            }

            // Dates in the range
            Console.WriteLine("\n\nTest 2: Dates in the range\n");
            Thread.Sleep(3000);

            InvalidRangeException<DateTime> newDate = new InvalidRangeException<DateTime>();
            newDate.ErrorMessage = "Wrong date!";
            for (DateTime date = new DateTime(1980, 1, 1); date < new DateTime(2013, 12, 31); date = date.AddDays(1))
            {
                Console.Write("\n" + date + "\t: ");
                newDate.ErrorCondition(date, new DateTime(1990, 4, 7), new DateTime(2007, 11, 23));
                Thread.Sleep(10);
            }
        }
    }
}