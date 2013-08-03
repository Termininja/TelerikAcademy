//Task 3: Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class MinAndMaxOfSequence
{
    static void Main()
    {
        Console.Write("How many numbers you want to compare?");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        int N = int.Parse(Console.ReadLine());                              // the limit of compared numbers
        Console.ResetColor();
        byte len = (byte)(N.ToString().Length);                             // the maximal length of each number
        if (N > 0)                                                         
        {
            Console.WriteLine("\nPlease, enter {0} integer numbers:", N);
            int min = 0;                                                  
            int max = 0;                                                  
            byte w = 0;                                                     // the width where will be placed the number
            byte h = 0;                                                     // the height where will be placed the number
            for (int i = 1; i <= N; i++)                                    // reads N numbers
            {
                w++;
                switch (w)
                {
                    case 1:                                                 // here is the 1st column
                        Console.SetCursorPosition(3, 6 + h);                                
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0')); break;
                    case 2:                                                 // here is the 2nd column
                        Console.SetCursorPosition(30, 6 + h);                        
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0')); break;
                    case 3:                                                 // here is the 3rd column
                        Console.SetCursorPosition(57, 6 + h);                       
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0'));
                        w = 0;
                        h++;
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int number = int.Parse(Console.ReadLine());                 // reads the current number
                Console.ResetColor();
                if (i == 1)
                {
                    min = number;
                    max = number;
                }
                if (number > max)                                           // if the number is maximal
                {
                    max = number;
                }
                if (number < min)                                           // if the number is minimal
                {
                    min = number;
                }
            }
            Console.Write("\nThe maximal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(max);                                         // this is the sum at the end
            Console.ResetColor();
            Console.Write("The minumal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(min);                                         // this is the sum at the end
            Console.ResetColor();
        }
        else                                                                // if the number is not positive
        {
            throw new Exception();                                          // generates an exception
        }
    }
}