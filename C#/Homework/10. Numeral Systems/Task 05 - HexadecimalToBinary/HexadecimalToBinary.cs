//Task5: Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

public class HexadecimalToBinary
{
    public static void Main()
    {
        // Reads some hexadecimal number
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine().ToLower();
        Console.ResetColor();

        // convert hex to bin number
        Console.Write("Binary representation of this number is: ");
        int temp;
        for (int i = 0; i < hex.Length; i++)
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 : temp = hex[i] - 48;
            int?[] N = new int?[4];

            // Fills the array with 0s
            for (int j = 0; j < 4; j++)
            {
                N[j] = 0;
            }

            // Checks where are the 1s
            while (temp > 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Where has to be 1
                    if (Math.Pow(2, j + 1) > temp)
                    {
                        N[j] = 1;
                        temp -= (int)Math.Pow(2, j);
                        break;
                    }
                }
            }
            Array.Reverse(N);
            if (i == 0)
            {
                // Removes the first 0s from the number
                for (int j = 0; j < 4; j++)
                {
                    if (N[j] == 0) N[j] = null;
                    else break;
                }
            }

            // Prints the result
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)
            {
                Console.Write(item);
            }
            Console.ResetColor();
        }

        // Checks is the number equal to 0
        if (hex == "0")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(0);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}