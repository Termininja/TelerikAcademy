//Task 3: Refactor the following loop

using System;

class Loop
{
    static void Main()
    {
        int[] array = { 25, 3, 66, 4, 75, 232, 63 };

        if (FindValue(array, 660))
        {
            Console.WriteLine("Value Found");
        }
    }

    static bool FindValue(int[] array, int expectedValue)
    {
        int i = 0;
        for (i = 0; i < array.Length; i++)
        {
            if (array[i] * 10 == expectedValue)
            {
                return true;
            }
        }

        return false;
    }
}