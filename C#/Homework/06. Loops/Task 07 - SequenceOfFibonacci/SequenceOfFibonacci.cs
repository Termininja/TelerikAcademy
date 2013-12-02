//Task 7: Write a program that reads a number N and calculates the sum
//        of the first N members of the sequence of Fibonacci:
//        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//        Each member of the Fibonacci sequence (except the first two)
//        is a sum of the previous two members.

using System;
using System.Numerics;
using System.Threading;

public class SequenceOfFibonacci
{
    public static void Main()
    {
        // Read some integer number
        Console.Write("Please, enter some positive integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        ulong N = ulong.Parse(Console.ReadLine());
        Console.ResetColor();

        BigInteger value = 0;           // value of the current member
        BigInteger prev = 0;            // the prvious member of the sequence
        BigInteger next = 1;            // the next member of the sequence
        BigInteger sum = 0;             // the sum

        for (uint member = 1; member <= N; member++)
        {
            Thread.Sleep(40);
            value = prev;
            prev = next;
            next = value + prev;
            sum += value;               // the current sum of the sequence

            if (sum.ToString().Length > 20) Stat(member, (double)value, (double)sum);
            else Stat(member, value, sum);
            if ((double)sum == 1 / (double)0) break;
        }

        // Print the final result
        Console.Write("\nThe final sum is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((double)sum);
        Console.ResetColor();
    }

    // Print the result in time of calculation
    static void Stat(uint m, dynamic v, dynamic s)
    {
        Console.SetCursorPosition(3, 2);
        Console.Write("Member: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(m);
        Console.ResetColor();
        Console.SetCursorPosition(4, 3);
        Console.Write("Value: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(v);
        Console.WriteLine(new string(' ', 12));
        Console.ResetColor();
        Console.SetCursorPosition(6, 4);
        Console.Write("Sum: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(s);
        Console.WriteLine(new string(' ', 12));
        Console.ResetColor();
    }
}