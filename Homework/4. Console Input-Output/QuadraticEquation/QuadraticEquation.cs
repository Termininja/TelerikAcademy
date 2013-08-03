//Task 6: Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class QuadraticEquation
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
                    Console.Write("Please, enter the coefficient: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("a = ");
                    double a = double.Parse(Console.ReadLine());                        // read the 1st coefficient 'a'
                    Console.ResetColor();

                    Console.Write("Please, enter the coefficient: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("b = ");
                    double b = double.Parse(Console.ReadLine());                        // read the 2nd coefficient 'b'
                    Console.ResetColor();

                    Console.Write("Please, enter the coefficient: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("c = ");
                    double c = double.Parse(Console.ReadLine());                        // read the 3rd coefficient 'c'
                    Console.ResetColor();

                    double D = Math.Pow(b, 2) - 4 * a * c;                              // the discriminant of quadratic equation

                    if (D < 0)                                                          // if we don't have real roots
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThe quadratic equation doesn't have real roots!");
                        Console.ResetColor();
                    }
                    else if (D == 0)                                                    // if we have only one real root 'x'
                    {
                        double x = -b / 2 * a;
                        Console.WriteLine("\nThe quadratic equation has only one real root:\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t     -b");
                        Console.WriteLine("\tx = ───── = {0}", Math.Round(x, 2));
                        Console.WriteLine("\t     2.a");
                        Console.ResetColor();
                    }
                    else                                                                // if we have two real roots 'x1' and 'x2'
                    {
                        double x1 = (-b + Math.Sqrt(D)) / 2 * a;
                        double x2 = (-b - Math.Sqrt(D)) / 2 * a;
                        Console.WriteLine("\nThe quadratic equation has two real roots:\n");
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("\t      -b + √D");
                        Console.WriteLine("\tx1 = ───────── = {0}", Math.Round(x1, 2));
                        Console.WriteLine("\t        2.a\n");

                        Console.WriteLine("\t      -b - √D");
                        Console.WriteLine("\tx2 = ───────── = {0}", Math.Round(x2, 2));
                        Console.WriteLine("\t        2.a");

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
            catch (OverflowException)                                                   // for all cases when some of the coefficients is too big
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