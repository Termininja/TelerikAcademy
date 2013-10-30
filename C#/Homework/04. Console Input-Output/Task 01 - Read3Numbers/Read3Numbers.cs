//Task 1: Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class Read3Numbers
{
    static void Main()
    {
        while (true)
        {
            /* Table */
            Console.WriteLine(@"Please, write 3 integer numbers:

   Number 1    │
   Number 2    │
   Number 3    │
   ────────────┼───────────────
   Sum         │");

            int num1, num2, num3 = 0;
            try
            {
                Console.CursorTop = 2;                                              // move the cursor to position 2 from the top
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorLeft = 17;                                            // move the cursor to position 17 from the left
                num1 = int.Parse(Console.ReadLine());                               // read the 1st number
                Console.CursorLeft = 17;
                num2 = int.Parse(Console.ReadLine());                               // read the 2nd number
                Console.CursorLeft = 17;
                num3 = int.Parse(Console.ReadLine());                               // read the 3rd number

                Console.CursorTop = 6;
                Console.CursorLeft = 17;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(num1 + num2 + num3);                              // the result from the sum

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\nPress Enter to continue, or X to exit . . .");
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
            catch (Exception)                                                       // this rows below will be executed if there are some errors
            {
                Console.CursorTop = 6;
                Console.CursorLeft = 17;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!");                                        // this message will be shown when there is some error
                Console.ReadKey();                                                  // you will continue if you press any Key
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}