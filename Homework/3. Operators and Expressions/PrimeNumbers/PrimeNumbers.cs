//Task 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class PrimeNumbers
{
    static void Main()
    {
        /*Short variant*/
        //int n = 79;
        //bool isPrime = (n != 1) && (((n % 2 > 0) && (n % 3 > 0) && (n % 5 > 0) && (n % 7 > 0)) || (n == 2 || n == 3 || n == 5 || n == 7));

        /*Long variant*/
        for (int i = 0; ; i++)
        {
            Console.WriteLine("The program checking whether an integer (0 to 18,45E+18) is a prime number.\n");
            Console.Write("Please, enter some integer number, or type \"end\" to exit: ");
            Console.ForegroundColor = ConsoleColor.Green;
            dynamic str = Console.ReadLine();                               // read everything
            try                                                             // this checks for some errors (for example if we write some string)
            {
                Console.ResetColor();
                ulong number = ulong.Parse(str);                            // we use type 'ulong' to cover the range from 0 to 18,45E+18
                if (number == 0 | number == 1)                              // if the number is 0 or 1
                {
                    Console.CursorTop = 6;
                    Console.Write("The number {0} is a prime: ", number);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("False!");
                    Console.ResetColor();
                }
                for (ulong n = 2; n <= number; n++)                         // this start checking whether the 'number' is prime
                {
                    bool isPrime = true;
                    for (ulong k = 2; k < n; k++)
                    {
                        if (n % k == 0)                                     // if the number is not prime
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)                                            // this is counter for prime numbers
                    {
                        Console.CursorTop = 5;
                        Console.CursorLeft = 0;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(n);
                        Console.ResetColor();
                        if (number != n)
                        {
                            isPrime = false;
                        }
                    }
                    if (n == number)                                        // the counter will stop when the 'number' = 'n'
                    {
                        Console.WriteLine(" is the last prime number!");
                        Console.Write("The number {0} is a prime: ", number);
                        if (isPrime == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(isPrime + "!");
                        Console.ResetColor();
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)
            {
                if (str == "end")                                           // if you want to exit you have to write "end"
                {
                    break;
                }
                if (str == "")                                              // if you press "Enter"
                {
                    Console.ResetColor();
                    Console.Clear();
                }
                else                                                        // if you type some string the "Error message" will be shown 
                {
                    Console.CursorTop = 5;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Something's wrong!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}