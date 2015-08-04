/* 
 * Problem 20.* Infinite convergent series:
 *      By using delegates develop an universal static method to calculate
 *      the sum of infinite convergent series with given precision depending
 *      on a function of its term. By using proper functions for the term
 *      calculate with a 2-digit precision the sum of the infinite series:
 *          1 + 1/2 + 1/4 + 1/8 + 1/16 + …
 *          1 + 1/2! + 1/3! + 1/4! + 1/5! + …
 *          1 + 1/2 - 1/4 + 1/8 - 1/16 + …
 */

namespace Delegates
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + ... = {0:0.000}", Sum(m => 1 / (decimal)Math.Pow(2, m - 1)));
            Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + ... = {0:0.000}", Sum(m => 1m / Enumerable.Range(1, m).Aggregate((a, b) => a * b)));
            Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + ... = {0:0.000}", Sum(m => -1 / (decimal)Math.Pow(-2, m - 1)));
        }

        private static decimal Sum(Func<int, decimal> f)
        {
            var sum = 1m;
            for (int i = 2; Math.Abs(f(i)) > 0.001m; i++)
            {
                sum += f(i);
            }

            return sum;
        }
    }
}