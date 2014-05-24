//Task 5: Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;

class TheGreaterNumber
{
    static void Main()
    {
        bool end = false;                                               // we don't want to finish now
        while (true)                                                    // repeat continuously
        {
            try                                                         // check for errors
            {
                if (end == false)
                {
                    Console.Write("Please, write two numbers: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.CursorTop = 2;
                    Console.CursorLeft = 7;
                    decimal num1 = decimal.Parse(Console.ReadLine());   // read the 1st number 'num1'
                    Console.CursorTop = 2;
                    Console.CursorLeft = 27;
                    decimal num2 = decimal.Parse(Console.ReadLine());   // read the 2nd number 'num2'
                    Console.ResetColor();

                    decimal zerocheck = 1 / (num1 - num2);              // checks whether num1 = num2
                    Console.Write("\nThe greater of these two number is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Math.Max(num1, num2));                // result from the comparison
                    end = true;                                         // we finish
                }                                                   
                else                                                          
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nPress Enter to continue, or X to exit . . ."); 
                key:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.X) break;                 // exit if "X" is pressed
                    else if (key.Key != ConsoleKey.Enter)               // continue only when you press "Enter"
                    {
                        Console.Write("\b \b");                         // clear the wrong keys from the console
                        goto key;
                    }
                    end = false;                                        
                    Console.ResetColor();
                    Console.Clear();
                }
            }
            catch (DivideByZeroException)                               // for all cases when zerocheck = 1/0
            {
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("The two numbers are equal!");
                end = true;
            }
            catch (OverflowException)                                   // for all cases when num1 or num2 is too big
            {
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("The number is too big!");
                end = true;
            }
            catch (Exception)                                           // for all other cases the error message will be shown
            {
                Console.CursorTop = 4;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("This is not a number!");
                end = true;
            }
        }
    }
}