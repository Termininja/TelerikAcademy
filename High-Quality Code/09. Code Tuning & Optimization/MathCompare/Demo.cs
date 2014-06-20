//Task 03. Write a program to compare the performance of square root,
//natural logarithm, sinus for float, double and decimal values.

namespace MathCompare
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// All types of operations.
    /// </summary>
    enum Operation { Sqrt, Log, Sin }

    /// <summary>
    /// Demonstration of class MathCompare
    /// </summary>
    class Demo
    {
        static void Main()
        {
            Console.WriteLine(CheckType(Operation.Sqrt));
            Console.WriteLine(CheckType(Operation.Log));
            Console.WriteLine(CheckType(Operation.Sin));
        }

        /// <summary>
        /// Checks the performance for some operation for float, double and decimal.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns>Returns the performance like string.</returns>
        private static StringBuilder CheckType(Operation operation)
        {
            StringBuilder result = new StringBuilder();
            result.Append(operation + ":\n");
            result.Append(StopWatch("float", operation) + "\n");
            result.Append(StopWatch("double", operation) + "\n");
            result.Append(StopWatch("decimal", operation) + "\n");

            return result;
        }

        /// <summary>
        /// Calculates the performance time for some type and some operation.
        /// </summary>
        /// <param name="type">The value type.</param>
        /// <param name="operation">The executed operation.</param>
        /// <returns>Returns the performance time like string.</returns>
        private static string StopWatch(string type, Operation operation)
        {
            Stopwatch intTime = new Stopwatch();
            intTime.Start();
            switch (operation)
            {
                case Operation.Sqrt: MathCompare.Sqrt(type); break;
                case Operation.Log: MathCompare.Log(type); break;
                case Operation.Sin: MathCompare.Sin(type); break;
                default: break;
            }
            intTime.Stop();

            string elapsedTime = String.Format("{0,-10} {1}", type, intTime.Elapsed);

            return elapsedTime;
        }
    }
}
