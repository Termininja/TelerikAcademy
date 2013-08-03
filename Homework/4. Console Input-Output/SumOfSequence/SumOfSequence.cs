//Task 10: Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class SumOfSequence
{
    static void Main()
    {
        while (true)
        {
            decimal S = 1;                                                      // the first member of the sequence is 1
            decimal S_curr = 0;                                                 // the current sum
            for (decimal i = 2; ; i++)                                          // to count from 2 to infinity
            {
                System.Threading.Thread.Sleep(30);                              // the program will sleep for 30ms
                if (i % 2 == 0)
                {
                    S_curr = 1 / i;                                             // here are all even 'i'
                }
                else
                {
                    S_curr = -1 / i;                                            // here are all odd 'i'
                }
                if (Math.Abs(S_curr) < 0.001m)                                  // program will stop when the current sum < 0.001
                {
                    break;
                }
                S += S_curr;                                                    // the final sum of the sequence

                Console.CursorTop = 1;
                Console.Write("    Member: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(i);
                Console.ResetColor();

                Console.CursorTop = 2;
                Console.Write("  Accuracy: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Math.Round(Math.Abs(S_curr), 5));
                Console.ResetColor();

                Console.CursorTop = 3;
                Console.Write("       Sum: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Math.Round(S, 5));
                Console.ResetColor();
            }
            Console.Write("\nThe final sum is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Math.Round(S, 3));
            Console.ResetColor();

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