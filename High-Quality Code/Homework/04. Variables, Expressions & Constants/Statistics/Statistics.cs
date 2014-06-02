//Task 2: Refactor the following code to apply variable usage and naming best practices

namespace Statistics
{
    using System;

    static class Statistics
    {
        /// <summary>
        /// Calculates the minimal value in the array.
        /// </summary>
        /// <param name="array">An array of double elements.</param>
        /// <param name="count">The number of elements to be compared.</param>
        static double MinElement(double[] array, int count)
        {
            double minElement = double.MaxValue;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        /// <summary>
        /// Calculates the maximal value in the array.
        /// </summary>
        /// <param name="array">An array of double elements.</param>
        /// <param name="count">The number of elements to be compared.</param>
        static double MaxElement(double[] array, int count)
        {
            double maxElement = double.MinValue;
            for (int i = 0; i < count; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Calculates the average value in the array.
        /// </summary>
        /// <param name="array">An array of double elements.</param>
        /// <param name="count">The number of elements to be compared.</param>
        static double Average(double[] array, int count)
        {
            double sumOfElements = 0;
            for (int i = 0; i < count; i++)
            {
                sumOfElements += array[i];
            }

            double average = sumOfElements / count;

            return average;
        }

        /// <summary>
        /// Print the minimal, maximal and the average value in array.
        /// </summary>
        /// <param name="array">An array of double elements.</param>
        /// <param name="count">The number of elements to be compared.</param>
        public static void PrintStatistics(double[] array, int count)
        {
            Console.WriteLine("Max element: " + MaxElement(array, count));
            Console.WriteLine("Min element: " + MinElement(array, count));
            Console.WriteLine("Average: " + Average(array, count));
        }
    }
}