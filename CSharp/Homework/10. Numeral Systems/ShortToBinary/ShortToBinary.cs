//Task8: Write a program that shows the binary representation
//       of given 16-bit signed integer number (the C# type short).

using System;

class ShortToBinary
{
    static void Main()
    {
        byte[] N = new byte[16];                    // the number is type short, so the length is 16bits
        for (byte i = 0; i < N.Length; i++)         // fills the array with 0s
        {
            N[i] = 0;
        }
        Console.Write("Please, enter some signed integer number from type short: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int temp = num;
        if (num < 0)                                // if the number is negative
        {
            num = short.MaxValue + num + 1;
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
        Console.Write("Binary representation of this number is: ");
        if (temp != 0)                              // checks is the number equal to 0
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)                 // prints the result
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

