// Task 07. Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Numerics;
using System.Threading;

namespace Timer
{
    public class Program
    {
        public delegate void D();                                   // define a delegate

        public static void Main()
        {
            BigInteger t = 0;
            while (t <= 0)                                          // 't' can be only positive
            {
                Console.Clear();
                Console.Write("Please, enter the sleep time: t = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                t = BigInteger.Parse(Console.ReadLine());           // time (in seconds)
                Console.ResetColor();
            }
            Console.WriteLine("The task will be executed at each {0} seconds\n", t);
            D timer = new D(Timer.Task);                            // create a delegate

            Console.WriteLine("Current Time:\t\tLast executed:\t\tWill be executed:");
            Console.WriteLine("\n\n\nPress any key to stop the test...");
            Console.SetCursorPosition(0, 4);

            BigInteger left = t;
            for (int second = 0; ; second++)
            {
                Console.Write("\r" + DateTime.Now + "\t");
                if (second % t == 0)                                // the method will be executed at each 't' seconds
                {
                    timer();                                        // call the delegate
                    left = t;
                }
                Console.SetCursorPosition(48, 4);
                Console.Write("in ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(left);
                Console.ResetColor();
                Console.Write(" seconds\t");

                Thread.Sleep(1000);                                 // sleep the program for 1 second
                if (Console.KeyAvailable)                           // stop the loop
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
