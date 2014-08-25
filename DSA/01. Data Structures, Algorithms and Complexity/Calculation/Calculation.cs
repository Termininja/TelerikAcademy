using System;

class Calculation
{
    static long complexity = 0;

    static void Main()
    {
        int[] arr = new int[] { 9, 4, 5, 7, 8, 9, 3, 4, 6, 3 };
        int n = arr.Length;
        Compute(arr);

        Console.WriteLine("n = {0}", n);
        Console.WriteLine("\nThe final complexity is: n*(n-1) = O({0})", n * (n - 1));
        Console.WriteLine("\nComplexity from the test: " + complexity);
    }

    private static long Compute(int[] arr)
    {
        long count = 0;

        // repeated n times (n = arr.Length)
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0;
            int end = arr.Length - 1;

            // repeated n-1 times (n-1 = end) for each n from the previous loop: n*(n-1)
            while (start < end)
            {
                if (arr[start] < arr[end])
                {
                    start++;
                    count++;
                }
                else
                {
                    end--;
                }

                complexity++;
            }
        }

        return count;
    }
}