//Task 1: Write an expression that checks if given integer is odd or even.

using System;

class CheckOddOrEven
{
    static void Main()
    {
        /*Short variant*/
        //int n = int.Parse(Console.ReadLine());
        //if (n % 2 == 0) { Console.WriteLine("Even"); }
        //else { Console.WriteLine("Odd"); }

        /*Long variant*/
        for (int i = 0; ; i++)                                              // this will check continuously for some number
        {
            Console.Write("Please, write some integer number, or type \"end\" to exit: ");   // it will return the entire string after pressing enter

        read:                                                               // marking point on which we read the string
            string str = Console.ReadLine();
            long number = 0;                                                // we use type long for integer numbers in range: -9.22E+18 to 9.22E+18
            if (long.TryParse(str, out number))                             // check if the string 'str' is a number
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (number % 2 == 0)                                        // check if a 'number' is even or odd
                {
                    Console.WriteLine("The number {0} is even!", number);
                }
                else
                {
                    Console.WriteLine("The number {0} is odd!", number);
                }
                Console.ResetColor();
            }
            else
            {
                try
                {
                    long check = long.Parse(str);                           // this check the string 'str' and look for errors
                }
                catch (OverflowException)                                   // if the number is too big
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big!");
                    Console.ResetColor();
                    Console.Write("Please, write a number from -9.22E+18 to 9.22E+18: ");
                    goto read;
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
                        if (str == "end")                                   // if you want to exit you have to write "end"
                        {
                            break;
                        }
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