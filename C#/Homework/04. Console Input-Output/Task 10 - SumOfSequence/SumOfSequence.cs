//Task 10: Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class SumOfSequence
{
    static void Main()
    {
        while (true)
        {
            decimal S = 1;                              // the 1st member of the sequence is 1
            decimal S_curr = 0;                         // the current sum
            for (decimal i = 2; ; i++)                  // count from 2 to infinity
            {
                System.Threading.Thread.Sleep(20);      // the program will sleep for 30ms
                if (i % 2 == 0) S_curr = 1 / i;         // all even 'i'
                else S_curr = -1 / i;                   // all odd 'i'
                if (Math.Abs(S_curr) < 0.001m) break;   // stop when the current sum is < 0.001
                S += S_curr;                            // the final sum of the sequence

                // Print the current values
                Print("    Member: ", 1, i);
                Print("  Accuracy: ", 2, Math.Round(Math.Abs(S_curr), 5));
                Print("       Sum: ", 3, Math.Round(S, 5));
            }

            // Print the result
            Console.Write("\nThe final sum is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Math.Round(S, 3));
            Console.ResetColor();
            break;
        }
    }

    // Method which print some parameter
    private static void Print(string text, byte row, dynamic value)
    {
        Console.CursorTop = row;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(value);
        Console.ResetColor();
    }
}