using System;

class Calculation
{
    static long complexity = 0;

    static void Main()
    {
        int[] arr = new int[] { 9, 4, 5, 7, 8, 9, 3, 4, 6, 3 };
        int n = arr.Length;
        Compute(arr);

        Console.WriteLine("n = {0}\nThe final complexity is: n*(n-1) = O({1})", n, n * (n - 1));
        Console.WriteLine("\nComplexity from the test: {0}", complexity);
    }

    private static long Compute(int[] arr)
    {
        long count = 0;

        // Repeated n times (n = arr.Length)
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0;
            int end = arr.Length - 1;

            // Repeated n-1 times (n-1 = end) for each n from the previous loop: n*(n-1)
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