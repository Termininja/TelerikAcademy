//Task8: Write a program that shows the binary representation
//       of given 16-bit signed integer number (the C# type short).

using System;

public class ShortToBinary
{
    public static void Main()
    {
        // Create some zero array
        byte[] N = new byte[16];
        for (byte i = 0; i < N.Length; i++)
        {
            N[i] = 0;
        }

        // Read some 16-bit signed integer number
        Console.Write("Please, enter some signed integer number from type short: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int temp = num;
        if (num < 0)
        {
            num = short.MaxValue + num + 1;
            N[N.Length - 1] = 1;
        }
        while (num > 0)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                // Where has to be 1
                if (Math.Pow(2, i + 1) > num)
                {
                    N[i] = 1;
                    num -= (int)Math.Pow(2, i);
                    break;
                }
            }
        }

        // Reverses the array
        Array.Reverse(N);

        // Prints the result
        Console.Write("Binary representation of this number is: ");
        if (temp != 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)
            {
                Console.Write(item);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('0', 16));
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}