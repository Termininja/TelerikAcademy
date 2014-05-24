//Task 3: Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

public class MinAndMaxOfSequence
{
    public static void Main()
    {
        // Read the limit of compared numbers
        Console.Write("How many numbers you want to compare?");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        int N = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // The maximal length of each number
        byte len = (byte)(N.ToString().Length);

        // If the number is positive
        if (N > 0)
        {
            Console.WriteLine("\nPlease, enter {0} integer numbers:", N);
            int min = 0;
            int max = 0;
            byte w = 0;
            byte h = 0;

            // Read N numbers
            for (int i = 1; i <= N; i++)
            {
                w++;
                switch (w)
                {
                    // The 1st column
                    case 1:
                        Console.SetCursorPosition(3, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0'));
                        break;

                    // The 2nd column
                    case 2:
                        Console.SetCursorPosition(30, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0'));
                        break;

                    // The 3rd column
                    case 3:
                        Console.SetCursorPosition(57, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0'));
                        w = 0;
                        h++;
                        break;

                    default:
                        break;
                }

                // Read the current number
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int number = int.Parse(Console.ReadLine());
                Console.ResetColor();
                if (i == 1)
                {
                    min = number;
                    max = number;
                }
                if (number > max) max = number;
                if (number < min) min = number;
            }

            // Print the result
            Console.Write("\nThe maximal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(max);
            Console.ResetColor();
            Console.Write("The minumal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(min);
            Console.ResetColor();
        }
    }
}