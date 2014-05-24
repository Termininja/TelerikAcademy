//Task 4: Write a program that reads two positive integer numbers and prints how many numbers p exist between them
//        such that the remainder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class PrintNumbersDividedBy5
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Please, write two positive integer numbers: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorTop = 2;
                Console.CursorLeft = 7;
                uint num1 = uint.Parse(Console.ReadLine());         // read the 1st number 'num1'
                Console.CursorTop = 2;
                Console.CursorLeft = 27;
                uint num2 = uint.Parse(Console.ReadLine());         // read the 2nd number 'num2'
                Console.ResetColor();

                bool print = false;                                 // to print or not all 'p' numbers
                uint min = num1;                                    // by default 'num1' is the minimum number
                uint max = num2;

                if (num1 > num2)                                    // compare the both numbers
                {
                    min = num2;
                    max = num1;
                }
            print:
                uint p = 0;
                for (uint i = min; i <= max; i++)                   // take only the numbers between num1 and num2
                {
                    if (i % 5 == 0)
                    {
                        p++;                                        // count how many numbers are devided by 5
                        if (print)
                        {
                            System.Threading.Thread.Sleep(50);      // the program will sleep for 50ms
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(i);
                            Console.ResetColor();
                            Console.Write(", ");
                        }
                    }
                }
                if (print) Console.Write("\b\b ");                  // delete the last comma
                else
                {
                    // Print the result
                    Console.Write("\nBetween {0} and {1} exists ", min, max);       
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(p);
                    Console.ResetColor();
                    Console.Write(" numbers which can be divided by 5 with remainder of 0");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\nPress Enter to continue, X to exit, or P to see all them . . .");
            key:
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.X) break;                 // exit if "X" is pressed
                if (key.Key == ConsoleKey.P)                        // all 'p' numbers will be printed if you press "P"
                {
                    Console.ResetColor();
                    Console.Write("\n\nThe numbers are: ");
                    print = true;
                    goto print;
                }
                else if (key.Key != ConsoleKey.Enter)               // continue only when you press "Enter"
                {
                    Console.Write("\b \b");                         // clear the wrong keys from the console
                    goto key;
                }
                Console.ResetColor();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");            // the message will be shown when there is some error
                Console.ReadKey();                                  // continue if any Key is pressed
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}