//Program which show the all 14 tasks from the homework 3

using System;

class AllTasks
{
    static void Main()
    {
        Console.SetWindowSize(140, 30);                                             // change the window size of the console
        dynamic task = null;                                                        // user's choice variable
        goto charging;                                                              // if we start now → go to 'charging' point
    home:                                                                           // marking home point
        for (int time = 0; ; time++)                                                // this will check continuously for the user's choice
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;                        // change the font color
            Console.WriteLine("\n     Homework 3. Operators and Expressions");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
         Task 1: Write an expression that checks if given integer is odd or even.
         Task 2: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5
                 in the same time.
         Task 3: Write an expression that calculates rectangle’s area by given width and height.
         Task 4: Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 → true.
         Task 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
         Task 6: Write an expression that checks if given point (x, y) is within a circle K(O, 5).
         Task 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
         Task 8: Write an expression that calculates trapezoid's area by given sides a and b and height h.
         Task 9: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
                 and out of the rectangle R(top = 1, left = -1, width = 6, height = 2).
        Task 10: Write a boolean expression that returns if the bit at position p (counting from 0)
                 in a given integer number v has value of 1. Example: v=5; p=1 → false.
        Task 11: Write an expression that extracts from a given integer i the value of a given bit number b.
                 Example: i = 5; b = 2 → value = 1.
        Task 12: We are given integer number n, value v (v = 0 or 1) and a position p. Write a sequence of operators
                 that modifies n to hold the value v at the position p from the binary representation of n.
                 Example:  n = 5 (00000101), p = 3, v = 1 → 13 (00001101)
                           n = 5 (00000101), p = 2, v = 0 → 1 (00000001)
        Task 13: Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
        Task 14: Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
                         ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("     To start some program please, type a task number from 1 to 14 or \"exit\" to exit: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            task = Console.ReadLine();                                              // select which task number (1 - 14) to show
            Console.Clear();

            /*Start of Task 1*/
            if (task == "1")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

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
                                    break;                                          // exit from the program
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

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 2*/
            if (task == "2")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

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
                            break;                                              // exit from the program
                        }
                    }
                    Console.ResetColor();
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 3*/
            if (task == "3")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This program calulates rectangle’s area by given width and height.");
                Console.WriteLine("You can exit at any time by typing \"end\".");
                Console.ResetColor();
                Console.Write("\nPress some key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; ; i++)
                {
                    try                                                             // this checks for some errors (for example if we write some string)
                    {
                        Console.Write("Please, enter the width: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\tw = ");
                        dynamic width = Console.ReadLine();                         // here we can type the 'width value' or "end"
                        if (width == "end")                                         // we will exit if the 'width' is "end"
                        {
                            break;
                        }
                        decimal w = decimal.Parse(width);                           // take the decimal value of the 'width'
                        Console.ResetColor();

                        Console.Write("Please, enter the height: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\th = ");
                        dynamic height = Console.ReadLine();                        // here we can type the 'height value' or "end"
                        if (height == "end")                                        // we will exit if the 'height' is "end"
                        {
                            break;
                        }
                        decimal h = decimal.Parse(height);                          // take the decimal value of the 'height'
                        Console.ResetColor();

                        decimal Area = Math.Round((w * h), 2);                      // it calculates rectangle’s area

                        Console.WriteLine("\nThe rectangle's area is:\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("   S = w . h = {0}", Area);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)                                               // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 4*/
            if (task == "4")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //int n = 1732;
                //bool result = (n / 100) % 10 == 7;

                /*Long variant*/
                for (int i = 0; ; i++)
                {
                    Console.Write("Enter some integer number (3 or more digits), or type \"end\" to exit: ");
                    string str = Console.ReadLine();                                    // here we read the string 'str'
                    int number = 0;                                                     // we use type int for integer numbers in range: -2147483648 to 2147483647
                    if (int.TryParse(str, out number))                                  // check if the string 'str' is a number
                    {
                        double length = Math.Floor(Math.Log10(Math.Abs(number)) + 1);   // this counts the number of the digits
                        int digit = (Math.Abs(number) / 100) % 10;                      // this take the value of the 3rd digit
                        if (digit > 0)                                                  // if the number has more than 3 digits
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nThe number {0} has {1} digits, and the 3rd digit (right-to-left) is {2}!", number, length, digit);
                            Console.Write("\nResult: The 3rd digit is 7: ");
                            bool result = digit == 7;                                   // check if the value of the 3rd digit is = 7
                            if (result == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine(result + "\n");
                            Console.ResetColor();
                        }
                        else                                                            // if the number has less than 3 digits
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThe digits are only {0}!\n", length);
                            Console.ResetColor();
                        }
                    }
                    else                                                                // if the string 'str' is not a number
                    {
                        if (str == "end")                                               // if you want to exit you have to write "end"
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSomething's wrong!\n");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 5*/
            if (task == "5")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //int n = 3456;
                //bool result = (n & (1 << 3)) >> 3 == 1;

                /*Long variant*/
                for (int i = 0; ; i++)                                      // this will check continuously for some number
                {
                    try                                                     // this checks for some errors (for example if we write some string)
                    {
                        Console.Write("Enter some integer number, or type \"end\" to exit: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic str = Console.ReadLine();                   // here we can type the value of the number or "end"
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        int number = int.Parse(str);                        // take the number from the 'str' string
                        Console.ResetColor();
                        int mask = 1 << 3;                                  // create a mask = 1; after that its bit is moved to left by 3 bits
                        int NumAndMask = (number & mask);                   // logical "AND" operation between the number and the mask
                        int result = NumAndMask >> 3;                       // the result is moved back to right by 3 bits

                        /*This calculates the number of the bits from which is created the number (it is needed for the table below)*/
                        double bits = Math.Log(number + 1, 2);
                        if ((int)bits != bits)
                        {
                            bits++;
                        }
                        int length = (int)bits;                             //this is the bit length of the number

                        /*Draw a table with results and decimal and binary*/
                        Console.WriteLine();
                        Console.CursorLeft = 12;
                        Console.WriteLine("│  In decimal        │  In binary");
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Number   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(number);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(number, 2).PadLeft(length, '0'));    // this convert the number from decimal to binary; adds 0s to left
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Mask     │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("1 << 3");
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("&        │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(NumAndMask);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Result   ");
                        Console.ResetColor();
                        Console.Write("│" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(NumAndMask + " >> 3");
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(result, 2).PadLeft(length, '0'));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nThe 3rd bit (counting from 0) of integer {0} is {1}!", number, result);        // the result
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (OverflowException)                                                                           // if the number is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is too big!");
                        Console.ResetColor();
                    }
                    catch (Exception)                                                           // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 6*/
            if (task == "6")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //decimal x = 3.5m;
                //decimal y = -12.8m;
                //bool result = (x * x + y * y) <= 5 * 5;

                /*Long variant*/
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This program compares the position of some point A(x,y) with the position of arbitrary circle K(Ox,Oy,r).");
                Console.WriteLine("You can exit at any time by typing \"end\".");
                Console.ResetColor();
                Console.Write("\nPress some key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; ; i++)
                {
                    try                                                                 // this checks for some errors (for example if we write some string)
                    {
                        Console.WriteLine("Information about the Circle K(Ox,Oy,r):");

                        Console.Write("\tx coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 25;
                        Console.Write("Ox = ");
                        dynamic string_Ox = Console.ReadLine();                          // here we can type the 'Ox' value or "end"
                        if (string_Ox == "end")                                          // we will exit if the 'string_Ox' is "end"
                        {
                            break;
                        }
                        double Ox = double.Parse(string_Ox);                              // take the value of the 'string_Ox'
                        Console.ResetColor();

                        Console.Write("\ty coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 25;
                        Console.Write("Oy = ");
                        dynamic string_Oy = Console.ReadLine();                          // here we can type the 'Oy' value or "end"
                        if (string_Oy == "end")                                          // we will exit if the 'string_Oy' is "end"
                        {
                            break;
                        }
                        double Oy = double.Parse(string_Oy);                              // take the value of the 'string_Oy'
                        Console.ResetColor();

                        Console.Write("\tradius: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 25;
                        Console.Write("r = ");
                        dynamic string_r = Console.ReadLine();                          // here we can type the 'r' value or "end"
                        if (string_r == "end")                                          // we will exit if the 'string_r' is "end"
                        {
                            break;
                        }
                        double r = double.Parse(string_r);                              // take the value of the 'string_r'
                        Console.ResetColor();

                        Console.WriteLine("\nInformation about the Point A(x,y):");

                        Console.Write("\tx coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 25;
                        Console.Write("x = ");
                        dynamic string_x = Console.ReadLine();                          // here we can type the 'x' value or "end"
                        if (string_x == "end")                                          // we will exit if the 'string_x' is "end"
                        {
                            break;
                        }
                        double x = double.Parse(string_x);                              // take the value of the 'string_x'
                        Console.ResetColor();

                        Console.Write("\ty coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 25;
                        Console.Write("y = ");
                        dynamic string_y = Console.ReadLine();                          // here we can type the 'y' value or "end"
                        if (string_y == "end")                                          // we will exit if the 'string_y' is "end"
                        {
                            break;
                        }
                        double y = double.Parse(string_y);                              // take the value of the 'string_y'
                        Console.ResetColor();

                        double D = Math.Sqrt(Math.Pow(Ox - x, 2) + Math.Pow(Oy - y, 2));  // the distance from point A to the center of the circle

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nThe point A({0},{1}) is ", x, y);
                        if (D < r)                                                      // if the point is within the circle
                        {
                            Console.Write("within");
                        }
                        else
                        {
                            if (D > r)                                                  // if the point is without the circle
                            {
                                Console.Write("out of");
                            }
                            else                                                        // if the point is on the circle
                            {
                                Console.Write("on");
                            }
                        }
                        Console.Write(" the circle K({0},{1},{2})!", Ox, Oy, r);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)                                                   // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 7*/
            if (task == "7")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

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

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 8*/
            if (task == "8")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //decimal a = 10.3m;
                //decimal b = 14m;
                //decimal h = 2.8m;
                //decimal Area = (a + b) * h / 2;

                /*Long variant*/
                Console.WriteLine("This calulates trapezoid’s area by given sides a and b and height h.");
                Console.WriteLine("You can exit at any time by typing \"end\".");
                Console.Write("\nPress some key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; ; i++)
                {
                    dynamic str = null;
                    try                                                             // this checks for some errors (for example if we write some string)
                    {
                        Console.Write("Please, enter the 1st side: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\ta = ");
                        str = Console.ReadLine();
                        decimal a = decimal.Parse(str);                             // take the decimal value of the 'str' for 'a'
                        Console.ResetColor();

                        Console.Write("Please, enter the 2nd side: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\tb = ");
                        str = Console.ReadLine();
                        decimal b = decimal.Parse(str);                             // take the decimal value of the 'str' for 'b'
                        Console.ResetColor();

                        Console.Write("Please, enter the height: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\th = ");
                        str = Console.ReadLine();
                        decimal h = decimal.Parse(str);                             // take the decimal value of the 'str' for 'h'
                        Console.ResetColor();

                        decimal Area = Math.Round((a + b) * h / 2, 2);              // it calculates trapezoid’s area

                        Console.WriteLine("\nThe trapezoid's area is:\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("        (a + b) . h");
                        Console.WriteLine("   S = ───────────── = {0}", Area);
                        Console.WriteLine("             2");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)                                               // if there is an error the "Error message" is shown 
                    {
                        if (str == "end")                                           // we will exit if the 'side_a' is "end"
                        {
                            break;
                        }
                        if (str == "")                                              // if we press "Enter"
                        {
                            Console.ResetColor();
                            Console.Clear();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Something's wrong!");
                            Console.ResetColor();
                        }
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 9*/
            if (task == "9")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //double x = 2.45;
                //double y = -16;
                //bool result = (Math.Sqrt(Math.Pow(1 - x, 2) + Math.Pow(1 - y, 2)) < 3) && !((x > -1) && (x < 5) && (y > -1) && (y < 1));

                /*Long variant*/
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This program compares the position of some point A(x,y) according the position of arbitrary circle K(Ox,Oy,r) and rectangle R(Rx,Ry,w,h).");
                Console.WriteLine("You can exit at any time by typing \"end\".");
                Console.ResetColor();
                Console.Write("\nPress some key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; ; i++)
                {
                    dynamic str = null;
                    try                                                                 // this checks for some errors (for example if we write some string)
                    {
                        Console.WriteLine("Information about the Circle K(Ox,Oy,r):");

                        Console.Write("\tx coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\tOx = ");
                        str = Console.ReadLine();
                        double Ox = double.Parse(str);                                  // take the decimal value of the 'str' for 'Ox'
                        Console.ResetColor();

                        Console.Write("\ty coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\tOy = ");
                        str = Console.ReadLine();
                        double Oy = double.Parse(str);                                  // take the decimal value of the 'str' for 'Oy'
                        Console.ResetColor();

                        Console.Write("\tradius: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\tr = ");
                        str = Console.ReadLine();
                        double r = double.Parse(str);                                   // take the decimal value of the 'str' for 'r'
                        Console.ResetColor();

                        Console.WriteLine("\nInformation about the rectangle R(Rx,Ry,w,h):");

                        Console.Write("\tx coordinate (left): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\tRx = ");
                        str = Console.ReadLine();
                        double Rx = double.Parse(str);                                  // take the decimal value of the 'str' for 'Rx'
                        Console.ResetColor();

                        Console.Write("\ty coordinate (top): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\tRy = ");
                        str = Console.ReadLine();
                        double Ry = double.Parse(str);                                  // take the decimal value of the 'str' for 'Ry'
                        Console.ResetColor();

                        Console.Write("\twidth: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\t\tw = ");
                        str = Console.ReadLine();
                        double w = double.Parse(str);                                   // take the decimal value of the 'str' for 'w'
                        Console.ResetColor();

                        Console.Write("\theight: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\th = ");
                        str = Console.ReadLine();
                        double h = double.Parse(str);                                   // take the decimal value of the 'str' for 'h'
                        Console.ResetColor();

                        Console.WriteLine("\nInformation about the Point A(x,y):");

                        Console.Write("\tx coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\tx = ");
                        str = Console.ReadLine();
                        double x = double.Parse(str);                                   // take the decimal value of the 'str' for 'x'
                        Console.ResetColor();

                        Console.Write("\ty coordinate: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\ty = ");
                        str = Console.ReadLine();
                        double y = double.Parse(str);                                   // take the decimal value of the 'str' for 'y'
                        Console.ResetColor();

                        bool result = (Math.Sqrt(Math.Pow(Ox - x, 2) + Math.Pow(Oy - y, 2)) < r) && !((x > Rx) && (x < Rx + w) && (y > Ry - h) && (y < Ry));

                        Console.Write("\nThe point A({0},{1}) is within the circle K({2},{3},{4}) and out of the rectangle R({5},{6},{7},{8}): ", x, y, Ox, Oy, r, Rx, Ry, w, h);
                        if (result == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(result + "!");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)                                                   // if there is an error the "Error message" is shown 
                    {
                        if (str == "end")                                               // we will exit if the 'side_a' is "end"
                        {
                            break;
                        }
                        if (str == "")                                                  // if we press "Enter"
                        {
                            Console.ResetColor();
                            Console.Clear();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Something's wrong!");
                            Console.ResetColor();
                        }
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 10*/
            if (task == "10")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //int n = 124552;
                //int p = 3;
                //bool result = ((n & (1 << p)) >> p) == 1;

                /*Long variant*/
                for (int i = 0; ; i++)                                      // this will check continuously for some number
                {
                    try                                                     // this checks for some errors (for example if we write some string)
                    {
                    number:
                        Console.Write("Enter some integer number, or type \"end\" to exit: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic str = Console.ReadLine();                   // here we can type the value of the number or "end"
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto number;
                        }
                        Console.ResetColor();
                        int v = int.Parse(str);                             // take the number from the 'str' string

                        /*This calculates the number of the bits from which is created the number*/
                        double bits = Math.Log(v + 1, 2);
                        if ((int)bits != bits)
                        {
                            bits++;
                        }
                        int length = (int)bits;                             //this is the bit length of the number

                    position:
                        Console.Write("Enter the position (0 - {0}), or type \"end\" to exit: ", length - 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = Console.ReadLine();                           // here we can type the value of the number or "end"
                        Console.ResetColor();
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto position;
                        }
                        int p = int.Parse(str);                             // take the position value from the 'str' string
                        if (p > length - 1)                                 // it checks if the position 'p' is too big for the number 'v'
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The position is too big!");
                            Console.ResetColor();
                            goto position;
                        }

                        int mask = 1 << p;                                  // create a mask = 1; after that its bit is moved to left by 'p' bits
                        int NumAndMask = (v & mask);                        // logical "AND" operation between the number and the mask
                        int result = NumAndMask >> p;                       // the result is moved back to right by 'p' bits

                        bool compare = result == 1;                         // this checks if the bit at position 'p' is 1

                        /*Draw a table with results and decimal and binary*/
                        Console.WriteLine();
                        Console.CursorLeft = 12;
                        Console.WriteLine("│  In decimal        │  In binary");
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Number   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(v);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(v, 2).PadLeft(length, '0'));         // this convert the number from decimal to binary; adds 0s to left
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Mask     │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("1 << {0}", p);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("&        │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(NumAndMask);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Result   ");
                        Console.ResetColor();
                        Console.Write("│" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(NumAndMask + " >> {0}", p);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(result, 2).PadLeft(length, '0'));
                        Console.ResetColor();
                        Console.Write("\nThe bit at position {0} is 1: ", p);
                        if (compare == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(compare);                                                 // the result from the comparison
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (OverflowException)                                                   // if the number is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is too big!");
                        Console.ResetColor();
                    }
                    catch (Exception)                                                           // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 11*/
            if (task == "11")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //int i = 124552;
                //int b = 8;
                //int value = (i & (1 << b)) >> b;

                /*Long variant*/
                for (int t = 0; ; t++)                                      // this will check continuously for some number
                {
                    try                                                     // this checks for some errors (for example if we write some string)
                    {
                    number:
                        Console.Write("Enter some integer number, or type \"end\" to exit: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic str = Console.ReadLine();                   // here we can type the value of the number or "end"
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto number;
                        }
                        Console.ResetColor();
                        int i = int.Parse(str);                             // take the number from the 'str' string

                        /*This calculates the number of the bits from which is created the number*/
                        double bits = Math.Log(i + 1, 2);
                        if ((int)bits != bits)
                        {
                            bits++;
                        }
                        int length = (int)bits;                             //this is the bit length of the number

                    position:
                        Console.Write("Enter the position (0 - {0}), or type \"end\" to exit: ", length - 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = Console.ReadLine();                           // here we can type the value of the number or "end"
                        Console.ResetColor();
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto position;
                        }
                        int b = int.Parse(str);                             // take the position value from the 'str' string
                        if (b > length - 1)                                 // it checks if the position 'b' is too big for the number 'i'
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The position is too big!");
                            Console.ResetColor();
                            goto position;
                        }

                        int mask = 1 << b;                                  // create a mask = 1; after that its bit is moved to left by 'b' bits
                        int NumAndMask = (i & mask);                        // logical "AND" operation between the number and the mask
                        int value = NumAndMask >> b;                        // the result is moved back to right by 'b' bits

                        /*Draw a table with results and decimal and binary*/
                        Console.WriteLine();
                        Console.CursorLeft = 12;
                        Console.WriteLine("│  In decimal        │  In binary");
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Number   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(i);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(i, 2).PadLeft(length, '0'));         // this convert the number from decimal to binary; adds 0s to left
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("Mask     │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("1 << {0}", b);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.Write("&        │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(NumAndMask);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(length, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                        Console.CursorLeft = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Result   ");
                        Console.ResetColor();
                        Console.Write("│" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(NumAndMask + " >> {0}", b);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(value, 2).PadLeft(length, '0'));
                        Console.ResetColor();
                        Console.Write("\nThe bit at position {0} in integer number {1} is: ", b, i);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(value);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (OverflowException)                                                   // if the number is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is too big!");
                        Console.ResetColor();
                    }
                    catch (Exception)                                                           // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 12*/
            if (task == "12")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //int n = 1234567;
                //int v = 1;
                //int p = 13;
                //int? result = null;
                //if (v == 0)
                //{
                //    result = ~(1 << p) & n;
                //}
                //else if (v == 1)
                //{
                //    result = (1 << p) | n;
                //}

                /*Long variant*/
                for (int t = 0; ; t++)                                      // this will check continuously for some number
                {
                    try                                                     // this checks for some errors (for example if we write some string)
                    {
                    number:
                        Console.Write("Enter some integer number, or type \"end\" to exit: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic str = Console.ReadLine();                   // here we can type the value of the number or "end"
                        if (str == "end")                                   // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto number;
                        }
                        Console.ResetColor();
                        int n = int.Parse(str);                             // take the number from the 'str' string

                        /*This calculates the number of the bits from which is created the number*/
                        double bits = Math.Log(n + 1, 2);
                        if ((int)bits != bits)
                        {
                            bits++;
                        }
                        int length = (int)bits;                             //this is the bit length of the number

                    value:
                        Console.Write("Enter the value (0 or 1): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = Console.ReadLine();                           // here we can type the value of the number or "end"
                        Console.ResetColor();
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto value;
                        }
                        int v = int.Parse(str);                             // take the value from the 'str' string
                        if (v == 0 | v == 1)                                // it checks if the value 'v' is 0 or 1
                        {
                            goto position;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The value has to be 0 or 1!");
                            Console.ResetColor();
                            goto value;
                        }

                    position:
                        Console.Write("Enter the position (0 - {0}): ", length - 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = Console.ReadLine();                           // here we can type the value of the number or "end"
                        Console.ResetColor();
                        if (str == "")                                      // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto position;
                        }
                        int p = int.Parse(str);                             // take the position value from the 'str' string
                        if (p > length - 1)                                 // it checks if the position 'p' is too big for the number 'n'
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The position is too big!");
                            Console.ResetColor();
                            goto position;
                        }

                        int mask = 1;
                        int NumAndMask = 0;
                        if (v == 0)
                        {
                            mask = ~(1 << p);                               // the mask which will be applied to the number
                            NumAndMask = mask & n;                          // logical "AND" operation between the number and the mask
                        }
                        else if (v == 1)
                        {
                            mask = (1 << p);
                            NumAndMask = mask | n;                          // logical "OR" operation between the number and the mask
                        }

                        /*Draw a table with results and decimal and binary*/
                        Console.WriteLine();
                        Console.CursorLeft = 12;
                        Console.WriteLine("│  In decimal        │  In binary");
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Number   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(n);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));         // this convert the number from decimal to binary; adds 0s to left
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Mask     │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        if (v == 0)
                        {
                            Console.Write("~(1 << {0})", p);
                        }
                        else if (v == 1)
                        {
                            Console.Write("1 << {0}", p);
                        }
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Result");
                        Console.ResetColor();
                        Console.Write("   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(NumAndMask);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(32, '0'));
                        Console.ResetColor();
                        Console.Write("\nThe result after modifying of {0} is the integer: ", n);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(NumAndMask);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (OverflowException)                                                   // if the number is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number is too big!");
                        Console.ResetColor();
                    }
                    catch (Exception)                                                           // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 13*/
            if (task == "13")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                /*Short variant*/
                //uint number = 1241232733;
                //long result = (((number & (7 << 3)) >> 3) << 24) | (((number & (7 << 24)) >> 24) << 3) | (number & (~((7 << 3) | (7 << 24))));

                /*Long variant*/
                for (int t = 0; ; t++)                                              // this will check continuously for some number
                {
                    try                                                             // this checks for some errors (for example if we write some string)
                    {
                    number:
                        Console.Write("Enter some integer number, or type \"end\" to exit: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic str = Console.ReadLine();                           // here we can type the value of the number or "end"
                        if (str == "end")                                           // we will exit if the 'str' is "end"
                        {
                            break;
                        }
                        if (str == "")                                              // if you press only "Enter"
                        {
                            Console.ResetColor();
                            goto number;
                        }
                        Console.ResetColor();
                        uint number = uint.Parse(str);                              // take the number from the 'str' string

                        /*This calculates the number of the bits from which is created the number*/
                        double bits = Math.Log(number + 1, 2);
                        if ((int)bits != bits)
                        {
                            bits++;
                        }
                        int length = (int)bits;                                     //this is the bit length of the number

                        uint mask1 = 7 << 3;                                        // we use mask1 to backup the 1st group of bits (3, 4 and 5) 
                        uint bits_group1 = (number & mask1) >> 3;                   // these are the 1st 3 bits (3, 4 and 5) from group1

                        uint mask2 = 7 << 24;                                       // we use mask2 to backup the 2nd group of bits (24, 25 and 26) 
                        uint bits_group2 = (number & mask2) >> 24;                  // these are the 2nd 3 bits (24, 25 and 26) from group2

                        uint mask = ~(mask1 | mask2);                               // we use 'mask' to zeros all bit's groups from the number
                        uint NumAndMask = number & mask;                            // this is the number without the bit's groups

                        uint bits_group = (bits_group1 << 24) | (bits_group2 << 3);
                        uint result = bits_group | NumAndMask;

                        /*Draw a table with results and decimal and binary*/
                        Console.WriteLine();
                        Console.CursorLeft = 12;
                        Console.WriteLine("│  In decimal        │  In binary");
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Number   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(number);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));         // this convert the number from decimal to binary; adds 0s to left
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Mask1    │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("7 << 3");
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.Write("Bits_gr1 │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(bits_group1);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(bits_group1, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Mask2    │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("7 << 24");
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask2, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.Write("Bits_gr2 │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(bits_group2);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(bits_group2, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Mask     │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write("~(Mask1 | Mask2)");
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.Write("Number_0 │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(NumAndMask);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.Write("Bits_gr  │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.Write(bits_group);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(bits_group, 2).PadLeft(32, '0'));
                        Console.CursorLeft = 3;
                        Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                        Console.CursorLeft = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Result");
                        Console.ResetColor();
                        Console.Write("   │" + new string(' ', 20) + "│");
                        Console.CursorLeft = 15;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(result);
                        Console.CursorLeft = 36;
                        Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
                        Console.ResetColor();
                        Console.Write("\nThe result after exchanging the bits of {0} is the integer: ", number);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(result);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (Exception)                                                           // if there is an error the "Error message" is shown 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 14*/
            if (task == "14")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                uint mask = 0;
                int k = 0;
                uint lowBitsValues = 0;
                uint highBitsValues = 0;
                int LBits_Start = 0;
                int HBits_Start = 0;
                int LBits_End = 0;
                int HBits_End = 0;
                bool bitsCountOK = false;
                bool bitPositionsOK = false;
                Console.Write("Please, enter the number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                uint number = uint.Parse(Console.ReadLine());
                Console.ResetColor();
                do
                {
                    Console.Write("Enter how much bits you want to exchange: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    k = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    if ((k < 1) || (k > 16))
                    {
                        Console.WriteLine("{0}You have entered wrong bit count!!!", Environment.NewLine);
                    }
                    else
                    {
                        bitsCountOK = true;
                    }
                }
                while (bitsCountOK == false);
                do
                {
                    Console.WriteLine("Define which bit values you want to exchange:");
                    Console.Write("Enter the start position of the lower bits: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    LBits_Start = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    LBits_End = LBits_Start + k - 1;

                    Console.Write("Enter the start position of the higher bits: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    HBits_Start = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    HBits_End = HBits_Start + k - 1;

                    if (((LBits_Start + k) > HBits_Start) ||
                        (LBits_Start < 0) || (HBits_Start < LBits_End) ||
                        (HBits_Start > 16))
                    {
                        Console.WriteLine("{0}You have entered wrong bits positions!!!", Environment.NewLine);
                    }
                    else
                    {
                        bitPositionsOK = true;
                    }
                }
                while (bitPositionsOK == false);

                mask = (uint)(Convert.ToUInt32(new string('1', k), 2) << LBits_Start);
                lowBitsValues = (number & mask) >> LBits_Start;
                number = number & ~mask;

                mask = (uint)(Convert.ToUInt32(new string('1', k), 2) << HBits_Start);
                highBitsValues = (number & mask) >> HBits_Start;
                number = number & ~mask;

                highBitsValues = highBitsValues << LBits_Start;
                lowBitsValues = lowBitsValues << HBits_Start;
                number = (number | lowBitsValues) | highBitsValues;
                Console.Write("The new number is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(number);
                Console.ResetColor();
                Console.WriteLine();

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            if (task == "exit")                                 // to exit of the basic program you have to press "exit"
            {
                goto charging;
            }
        }
    charging:                                                   // marking of "charging" point
        for (int i = 0; i <= 2000; i++)                         // you will exit (if you typed "exit") or load (by default), after 2k units 
        {
            if (i == 2000)
            {
                if (task != "exit")                             // if you didn't type "exit" → go to 'home' point
                {
                    Console.Clear();
                    goto home;
                }
                Environment.Exit(0);                            // exit from the console
            }
            else                                                // progress bar page
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (task != "exit")                             // if we enter
                {
                    Console.CursorTop = 8; Console.CursorLeft = 66; Console.WriteLine("Welcome!");
                }
                else                                            // if we exit
                {
                    Console.CursorTop = 8; Console.CursorLeft = 67; Console.WriteLine("Goodbye!");
                }
                Console.ResetColor();

                /*Progress bar*/
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.CursorTop = 10; Console.CursorLeft = 20;
                Console.WriteLine("┌" + new string('─', 99) + "┐");
                Console.CursorTop = 11; Console.CursorLeft = 20; Console.Write("│");
                Console.Write(new string('█', Math.Abs(i) / 20));                                                          // bar
                Console.CursorTop = 11; Console.CursorLeft = 120; Console.Write("│");
                Console.CursorTop = 12; Console.CursorLeft = 20;
                Console.WriteLine("└" + new string('─', 99) + "┘");
                Console.CursorTop = 13; Console.CursorLeft = 64; Console.Write(Math.Abs(i * 5) / 100 + " % to ");          // percentage counter
                if (task != "exit")
                {
                    Console.WriteLine("load");
                }
                else
                {
                    Console.WriteLine("go out");
                }
            }
        }

    }
}