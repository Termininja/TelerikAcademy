//Task 1. Refactor the following examples to produce code with well-named C# identifiers:

namespace Printer
{
    using System;

    public class Printer
    {
        private const int MaxCount = 6;

        /// <summary>
        /// Prints the value of the variable like string
        /// </summary>
        /// <param name="variable">Some boolean variable.</param>
        public void ToString(bool variable)
        {
            Console.WriteLine(variable.ToString());
        }
    }
}