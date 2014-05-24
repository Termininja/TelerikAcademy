//Task2: Write a method ReadNumber(int start, int end) that enters
//       an integer number in given range [start…end]. If an invalid
//       number or non-number text is entered, the method should
//       throw an exception. Using this method write a program that
//       enters 10 numbers: a1, a2, … a10, such that 1<a1<…<a10<100

using System;

class ReadNumberMethod
{
    static int a;
    static void Main()
    {
        // The minimum number is 1
        int start = 1;

        // For each 10 numbers
        for (a = 1; a <= 10; a++)
        {
            // Calls the ReadNumber() method
            start = ReadNumber(start, 100);
        }
    }

    static int ReadNumber(int start, int end)
    {
        // Reads some integer number
        Console.Write("Please, enter some number ({0} < a{2} < {1}): ", start, end, a);
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // If the number is in our range
        if (!(start < number && number < end))
        {
            // Throw Exception if the number is out of our range
            throw new ArgumentOutOfRangeException();
        }
        return number;
    }
}