//Task 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class Finding3rdBit
{
    static void Main()
    {
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
    }
}