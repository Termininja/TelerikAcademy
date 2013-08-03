//Task 9: Write a program to print the first 100 members of the sequence of Fibonacci:
//        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class SequenceOfFibonacci
{
    static void Main()
    {
        while (true)                                                            // repeat continuously
        {
            Console.Write("The first 100 members of the sequence of Fibonacci are: ");
            decimal prev = 0;                                                   // the prvious member of the sequence
            decimal curr = 0;                                                   // the current member of the sequence
            decimal next = 1;                                                   // the next member of the sequence
            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(100);                             // the program will sleep for 100ms
                prev = curr;
                curr = next;
                next = prev + curr;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(prev);                                            // this prints the all members of the sequence 
                Console.ResetColor();
                Console.Write(", ");
            }
            Console.Write("\b\b ");                                             // delete the last comma

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
        key:
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
            {
                break;
            }
            else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
            {
                Console.Write("\b \b");                                         // clear the wrong keys from the console
                goto key;
            }
            Console.ResetColor();
            Console.Clear();
        }
    }
}