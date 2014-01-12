//Task1: Write a program to convert decimal numbers to their binary representation.

using System;

public class DecimalToBinary
{
    public static void Main()
    {
        // First variant
        // Console.WriteLine(Convert.ToString(number, 2));

        // Second variant
        byte?[] N = new byte?[32];                  // the number is type int, so the length is 32bits
        for (byte i = 0; i < N.Length; i++)         // fills the array with 0s
        {
            N[i] = 0;
        }
        Console.Write("Please, enter some integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int temp = num;
        if (num < 0)                                // if the number is negative
        {
            num = int.MaxValue + num + 1;
            N[N.Length - 1] = 1;                    // sets 1 on the leftmost bit
        }
        while (num > 0)                             // checks where are the 1s
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (Math.Pow(2, i + 1) > num)       // this finds where has to be 1
                {
                    N[i] = 1;                       // sets 1 for this bit
                    num -= (int)Math.Pow(2, i);     // decrease the number by this bit
                    break;
                }
            }
        }
        Array.Reverse(N);                           // reverses the array
        for (int i = 0; i < N.Length; i++)          // removes the first 0s from positive numbers
        {
            if (N[i] == 0) N[i] = null;
            else break;
        }

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
            Console.Write(0);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}