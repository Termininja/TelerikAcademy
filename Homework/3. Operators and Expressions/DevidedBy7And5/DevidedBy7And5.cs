//Task 2: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class DevidedBy7And5
{
    static void Main()
    {
        /*Short variant*/
        //int n = int.Parse(Console.ReadLine());
        //bool result = n % 35 == 0;

        /*Long variant*/
        for (int i = 0; ; i++)                                          // this will check continuously for some number
        {
            Console.Write("Please, write some integer number or type \"end\" to exit: ");
            string str = Console.ReadLine();                            // here we read the string 'str'
            int number = 0;                                             // we use type int for integer numbers in range: -2147483648 to 2147483647
            if (int.TryParse(str, out number))                          // check if the string 'str' is a number
            {
                if (number % 7 == 0 & number % 5 == 0)                  // check if a 'number' can be divided without remainder by 7 and 5
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The integer number {0} can be divided without remainder by 7 and 5!", number);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The integer number {0} can't be divided without remainder by 7 and 5!", number);
                }
            }
            else                                                        // if the string 'str' is not an number
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not an integer number!");
                Console.ResetColor();
                if (str == "end")                                       // if you want to exit you have to write "end"
                {
                    break;
                }
            }
            Console.ResetColor();
        }
    }
}