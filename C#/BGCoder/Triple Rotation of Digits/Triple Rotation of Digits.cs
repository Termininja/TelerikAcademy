using System;

class TripleRotation
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 3; i++)
        {
            if (number > 9) number = int.Parse((number % 10).ToString() + (number / 10).ToString());
        }
        Console.WriteLine(number);
    }
}