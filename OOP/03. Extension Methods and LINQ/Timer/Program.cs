/*
 * Problem 7. Timer:
 *      Using delegates write a class Timer that can execute certain method at each t seconds.
 */

namespace Timer
{
    using System;
    using System.Numerics;
    using System.Threading;

    public class Program
    {
        // Define a delegate
        public delegate void D();

        public static void Main()
        {
            BigInteger t = 0;

            // The 't' can be only positive
            while (t <= 0)
            {
                Console.Clear();
                Console.Write("Please, enter the sleep time [in seconds]: t = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                t = BigInteger.Parse(Console.ReadLine());
                Console.ResetColor();
            }

            Console.WriteLine("The task will be executed at each {0} seconds\n", t);

            // Create a delegate
            D timer = new D(Timer.Task);

            Console.WriteLine("Current Time:\t\tLast executed:\t\tWill be executed:");
            Console.WriteLine("\n\n\nPress any key to stop the test...");
            Console.SetCursorPosition(0, 4);
            Console.CursorVisible = false;

            BigInteger left = t;
            for (int second = 0; ; second++)
            {
                Console.Write("\r" + DateTime.Now + "\t");

                // The method will be executed at each 't' seconds
                if (second % t == 0)
                {
                    // Call the delegate
                    timer();
                    left = t;
                }
                Console.SetCursorPosition(48, 4);
                Console.Write("in ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(left);
                Console.ResetColor();
                Console.Write(" seconds\t");

                // Sleep the program for 1 second
                Thread.Sleep(1000);

                // Stop the loop
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.ReadKey(false);
                    Console.Write("\b \b");
                    break;
                }

                left--;
            }
        }
    }
}
