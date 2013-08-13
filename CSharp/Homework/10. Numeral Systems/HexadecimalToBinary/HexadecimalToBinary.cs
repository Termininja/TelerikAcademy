//Task5: Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexadecimalToBinary
{
    static void Main()
    {
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine().ToLower();      // reads the hexadecimal number
        Console.ResetColor();

        Console.Write("Binary representation of this number is: ");
        int temp;

        for (int i = 0; i < hex.Length; i++)            // checks the symbol is it capital or not
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 : temp = hex[i] - 48;

            int?[] N = new int?[4];
            for (int j = 0; j < 4; j++)                 // fills the array with 0s
            {
                N[j] = 0;
            }
            while (temp > 0)                            // checks where are the 1s
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Math.Pow(2, j + 1) > temp)      // this finds where has to be 1
                    {
                        N[j] = 1;                       // sets 1 for this bit
                        temp -= (int)Math.Pow(2, j);    // decrease the number by this bit
                        break;
                    }
                }
            }
            Array.Reverse(N);
            if (i == 0)
            {
                for (int j = 0; j < 4; j++)             // removes the first 0s from the number
                {
                    if (N[j] == 0)
                    {
                        N[j] = null;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)
            {
                Console.Write(item);                    // prints the result
            }
            Console.ResetColor();
        }

        if (hex == "0")                                 // checks is the number equal to 0
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(0);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}