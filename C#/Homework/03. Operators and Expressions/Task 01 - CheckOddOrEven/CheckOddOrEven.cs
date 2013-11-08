//Task 1: Write an expression that checks if given integer is odd or even.

using System;

class CheckOddOrEven
{
    static void Main()
    {
        /* Short variant */
        //int n = int.Parse(Console.ReadLine());
        //if (n % 2 == 0) { Console.WriteLine("Even"); }
        //else { Console.WriteLine("Odd"); }

        /* Long variant */
        while (true)
        {
            Console.Write(@"Please, write some integer number, or type ""end"" to exit: ");
            string str = Console.ReadLine();
            long number = 0;                                                // type long for integer numbers in range: -9.22E+18 to 9.22E+18
            if (long.TryParse(str, out number))                             // check if the string 'str' is a number
            {
                Console.ForegroundColor = ConsoleColor.Green;

                // Check if a 'number' is even or odd
                if (number % 2 == 0) Console.WriteLine("The number {0} is even!", number);
                else Console.WriteLine("The number {0} is odd!", number);
                Console.ResetColor();
            }
            else
            {
                try
                {
                    long check = long.Parse(str);                           // check the string 'str' and look for errors
                }
                catch (OverflowException)                                   // if the number is too big
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big!");
                    Console.ResetColor();
                }
                catch (FormatException)                                      // if the string 'str' is not an integer number
                {
                    decimal decimalNum = 0m;
                    if (decimal.TryParse(str, out decimalNum) == true)       // if the number is not integer
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is not an integer number!");
                        Console.ResetColor();
                    }
                    else                                                    // if the string is text
                    {
                        if (str == "end") break;                            // if you want to exit you have to write "end"
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is not a number!");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}