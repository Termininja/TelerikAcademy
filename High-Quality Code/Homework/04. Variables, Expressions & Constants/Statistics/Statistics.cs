//Task 2: Refactor the following code to apply variable usage and naming best practices

using System;

class Statistics
{
    public void PrintMinElement(double[] array, int count)
    {
        double minElement = double.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (array[i] < minElement)
            {
                minElement = array[i];
            }
        }

        Console.WriteLine(minElement);
    }

    public void PrintMaxElement(double[] array, int count)
    {
        double maxElement = double.MinValue;
        for (int i = 0; i < count; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
            }
        }

        Console.WriteLine(maxElement);
    }

    public void PrintAverage(double[] array, int count)
    {
        double sumOfElements = 0;
        for (int i = 0; i < count; i++)
        {
            sumOfElements += array[i];
        }

        double average = sumOfElements / count;
        Console.WriteLine(average);
    }

    public void PrintStatistics(double[] array, int count)
    {
        PrintMaxElement(array, count);
        PrintMinElement(array, count);
        PrintAverage(array, count);
    }
}