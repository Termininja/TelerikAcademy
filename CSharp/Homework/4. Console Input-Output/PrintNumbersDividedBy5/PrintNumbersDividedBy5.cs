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
                uint num1 = uint.Parse(Console.ReadLine());                         // read the 1st number 'num1'
                Console.CursorTop = 2;
                Console.CursorLeft = 27;
                uint num2 = uint.Parse(Console.ReadLine());                         // read the 2nd number 'num2'
                Console.ResetColor();

                bool print = false;                                                 // to print or not all 'p' numbers
                uint min = num1;                                                    // by default 'num1' is the minimum number
                uint max = num2;

                if (num1 > num2)                                                    // compare the two numbers; if num1 > num2 they will be replaced
                {
                    min = num2;
                    max = num1;
                }
            print:
                uint p = 0;
                for (uint i = min; i <= max; i++)                                   // we take only the numbers between num1 and num2
                {
                    if (i % 5 == 0)
                    {
                        p++;                                                        // here we count how many numbers are devided by 5
                        if (print)
                        {
                            System.Threading.Thread.Sleep(50);                      // the program will sleep for 50ms
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(i);
                            Console.ResetColor();
                            Console.Write(", ");
                        }
                    }
                }
                if (print)
                {
                    Console.Write("\b\b ");                                         // delete the last comma
                }
                else
                {
                    Console.Write("\nBetween {0} and {1} exists ", min, max);       // this prnt the result
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(p);
                    Console.ResetColor();
                    Console.Write(" numbers which can be divided by 5 with remainder of 0");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\nPress Enter to continue, X to exit, or P to see all them . . .");
            key:
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                {
                    break;
                }
                if (key.Key == ConsoleKey.P)                                        // all 'p' numbers will be printed if you press "P"
                {
                    Console.ResetColor();
                    Console.Write("\n\nThe numbers are: ");
                    print = true;
                    goto print;
                }
                else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                {
                    Console.Write("\b \b");                                         // clear the wrong keys from the console
                    goto key;
                }
                Console.ResetColor();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");                            // this message will be shown when there is some error
                Console.ReadKey();                                                  // you will continue if you press any Key
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}