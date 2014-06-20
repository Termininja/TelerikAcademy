//Task 02. Write a program to compare the performance of add, subtract,
//increment, multiply, divide for int, long, float, double and decimal values.

namespace TypeCompare
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// All types of operations.
    /// </summary>
    enum Operation { Add, Subtract, Increment, Multiply, Divide }

    /// <summary>
    /// Demonstration of class TypeCompare
    /// </summary>
    class Demo
    {
        static void Main()
        {
            Console.WriteLine(CheckType(Operation.Add));
            Console.WriteLine(CheckType(Operation.Subtract));
            Console.WriteLine(CheckType(Operation.Increment));
            Console.WriteLine(CheckType(Operation.Multiply));
            Console.WriteLine(CheckType(Operation.Divide));
        }

        /// <summary>
        /// Checks the performance for some operation for all types.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns>Returns the performance like string.</returns>
        private static StringBuilder CheckType(Operation operation)
        {
            StringBuilder result = new StringBuilder();
            result.Append(operation + ":\n");
            result.Append(StopWatch("int", operation) + "\n");
            result.Append(StopWatch("long", operation) + "\n");
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
                case Operation.Add: TypeCompare.Add(type); break;
                case Operation.Subtract: TypeCompare.Subtract(type); break;
                case Operation.Increment: TypeCompare.Increment(type); break;
                case Operation.Multiply: TypeCompare.Multiply(type); break;
                case Operation.Divide: TypeCompare.Divide(type); break;
                default: break;
            }
            intTime.Stop();

            string elapsedTime = String.Format("{0,-10} {1}", type, intTime.Elapsed);

            return elapsedTime;
        }
    }
}
