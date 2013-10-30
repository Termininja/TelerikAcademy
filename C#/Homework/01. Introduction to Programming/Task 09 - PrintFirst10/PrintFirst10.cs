//Task 9: Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class PrintFirst10
{
    static void Main()
    {
        // Set the number of members in the sequence
        int lenght = 10;

        // Generate a sequence
        for (int i = 2; i < lenght + 2; i++)
        {
            // Print the members of the sequence
            Console.Write(i * ((i % 2 == 0) ? 1 : -1));

            // Print the comma
            if (i != lenght + 1) Console.Write(", ");
            else Console.Write("\n");
        }
    }
}