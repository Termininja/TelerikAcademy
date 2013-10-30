//Task 7: Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.

using System;

class SumOfNumbers
{
    static void Main()
    {
        bool end = false;                                                               // we don't want to finish now
        while (true)                                                                    // repeat continuously
        {
            try                                                                         // check for errors
            {
                if (end == false)
                {
                    Console.WriteLine("How many numbers you want to sum?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n   n = ");
                    int n = int.Parse(Console.ReadLine());                              // reads how many numbers 'n' we will sum
                    Console.ResetColor();

                    string str = Convert.ToString(n);
                    byte count = 0;
                    foreach (char a in str)                                             // counts how many digits there are in the 'n'
                    {
                        if (char.IsDigit(a))
                        {
                            count++;
                        }
                    }

                    if (n > 0)                                                          // we can sum only positive number 'n' of numbers
                    {
                        Console.WriteLine("\nPlease, enter {0} numbers:", n);
                        decimal sum = 0;                                                // the sum in beginnig is 0
                        byte w = 0;                                                     // from this depends the width where will be placed the number
                        byte h = 0;                                                     // from this depends the height where will be placed the number
                        for (int i = 1; i <= n; i++)                                    // we start to enter 'n' numbers
                        {
                            w++;
                            if (w == 1)                                                 // here is the 1st column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 3;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));       // we reserve 'count' digits for each one number
                            }
                            else if (w == 2)                                            // here is the 2nd column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 30;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                            }
                            else if (w == 3)                                            // here is the 3rd column
                            {
                                Console.CursorTop = 6 + h;
                                Console.CursorLeft = 57;
                                Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                                w = 0;
                                h++;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            decimal number = decimal.Parse(Console.ReadLine());         // from here we read each one number
                            Console.ResetColor();
                            sum = sum + number;                                         // this is the current sum
                        }
                        Console.Write("\nThe sum of all numbers is: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Math.Round(sum, 2));                          // this is the sum at the end
                        Console.ResetColor();
                    }
                    else                                                                // when the number 'n' is not positive
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe number has to be positive!");
                        Console.ResetColor();
                    }
                    end = true;                                                         // we finished
                }
                else                                                                    // if we finished
                {
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
                    end = false;                                                        // if we don't want to exit
                    Console.ResetColor();
                    Console.Clear();
                }
            }
            catch (OverflowException)                                                   // for all cases when some number is too big
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe number is too big!");
                end = true;
            }
            catch (Exception)                                                           // in all other cases the error message will be shown
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis is not a number!");
                end = true;
            }
        }
    }
}