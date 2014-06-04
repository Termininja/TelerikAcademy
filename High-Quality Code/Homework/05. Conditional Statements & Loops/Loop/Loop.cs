//Task 3: Refactor the given loop

namespace Loop
{
    using System;

    class Loop
    {
        static void Main()
        {
            int[] array = { 25, 3, -66, -4, 75, 232, -4, 35, 5, 39, 63, 17 };
            FindValue(array, 63);
        }

        static void FindValue(int[] array, int expectedValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                    }
                }
            }
        }
    }
}
