//Task 7: Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.

using System;

class SumOfNumbers
{
    static void Main()
    {
        bool end = false;
        while (true)
        {
            try
            {
                if (end == false)
                {
                    Console.WriteLine("How many numbers you want to sum?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n   n = ");
                    int n = int.Parse(Console.ReadLine());          // reads how many numbers 'n' will be summed
                    Console.ResetColor();

                    string str = Convert.ToString(n);
                    byte count = 0;
                    foreach (char a in str)                         // how many digits there are in the 'n'
                    {
                        if (char.IsDigit(a)) count++;
                    }

                    if (n > 0)                                      // only positive number 'n' of numbers can be summed
                    {
                        Console.WriteLine("\nPlease, enter {0} numbers:", n);
                        decimal sum = 0;                            // the sum in beginnig is 0
                        byte w = 0;                                 // from this depends the width where will be placed the number
                        byte h = 0;                                 // from this depends the height where will be placed the number
                        for (int i = 1; i <= n; i++)                // enter 'n' numbers
                        {
                            w++;
                            if (w == 1)                             // the 1st column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 3;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                            }
                            else if (w == 2)                        // the 2nd column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 30;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                            }
                            else if (w == 3)                        // the 3rd column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 57;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                                w = 0;
                                h++;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            decimal number = decimal.Parse(Console.ReadLine());
                            Console.ResetColor();
                            sum = sum + number;                     // the current sum
                        }
                        Console.Write("\nThe sum of all numbers is: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Math.Round(sum, 2));      // the sum at the end
                        Console.ResetColor();
                    }
                    else                                            // if the number 'n' is not positive
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe number has to be positive!");
                        Console.ResetColor();
                    }
                    end = true;                                     // we finish
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nPress Enter to continue, or X to exit . . .");
                key:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.X) break;             // exit if "X" i spressed
                    else if (key.Key != ConsoleKey.Enter)           // continue only when you press "Enter"
                    {
                        Console.Write("\b \b");                     // clear the wrong keys from the console
                        goto key;
                    }
                    end = false;                                    // to continue
                    Console.ResetColor();
                    Console.Clear();
                }
            }
            catch (OverflowException)                               // when some number is too big
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe number is too big!");
                end = true;
            }
            catch (Exception)                                       // in all other cases the error message will be shown
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis is not a number!");
                end = true;
            }
        }
    }
}