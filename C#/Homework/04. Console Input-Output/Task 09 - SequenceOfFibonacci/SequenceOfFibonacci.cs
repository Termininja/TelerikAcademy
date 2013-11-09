//Task 9: Write a program to print the first 100 members of the sequence of Fibonacci:
//        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class SequenceOfFibonacci
{
    static void Main()
    {
        Console.Write("The first 100 members of the sequence of Fibonacci are: ");
        ulong prev = 0;                             // the prvious member of the sequence
        ulong curr = 0;                             // the current member of the sequence
        ulong next = 1;                             // the next member of the sequence
        for (int i = 1; i <= 100; i++)
        {
            System.Threading.Thread.Sleep(100);     // the program will sleep for 100ms
            prev = curr;
            curr = next;
            next = prev + curr;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(prev);                    // prints the all members of the sequence 
            Console.ResetColor();
            if (i != 100) Console.Write(", ");
        }
    }
}