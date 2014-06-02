namespace Statistics
{
    using System;

    /// <summary>
    /// Demonstration of class Statistics
    /// </summary>
    class Program
    {
        static void Main()
        {
            double[] arrayOfNumbers = new double[] { 23.4, -23, 235, -3.3, 4, 748 };
            int numberOfElements = 4;

            Statistics.PrintStatistics(arrayOfNumbers, numberOfElements);
        }
    }
}
