//Task 8: Write a program that reads an integer number n from the console
//        and prints all the numbers in the interval [1..n], each on a single line.

using System;

class PrintNumbersInRange
{
    static void Main()
    {
        while (true)                                                                // repeat continuously
        {
        home:
            Console.Write("Please, write some positive integer number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("n = ");
            int n = 0;
            if (int.TryParse(Console.ReadLine(), out n))                            // reads some integer number 'n'
            {
                Console.ResetColor();
                if (n > 0)                                                          // when the number 'n' is positive
                {
                    Console.WriteLine("\nAll numbers in the interval [1..{0}] are: ", n);
                    for (int i = 1; i <= n; i++)
                    {
                        System.Threading.Thread.Sleep(100);                         // the program will sleep for 100ms
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(i);                                       // this prints the all numbers
                        Console.ResetColor();
                    }
                }
                else                                                                // when the number 'n' is a negative or 0
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is not positive!\n");
                    Console.ResetColor();
                    goto home;
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nPress Enter to continue, or X to exit . . .");     // what we want to do
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
            else                                                                    // if the number is not integer
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not an integer number!\n");
                Console.ResetColor();
            }
        }
    }
}