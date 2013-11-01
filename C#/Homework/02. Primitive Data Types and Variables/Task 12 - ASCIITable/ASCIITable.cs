//Task 12: Find online more information about ASCII (American Standard
//         Code for Information Interchange). Write a program that
//         prints the entire ASCII table of characters on the console.

using System;

class ASCIITable
{
    static void Main()
    {
        // Print the ASCII table
        for (int i = 0; i < 127; i++)
        {
            Console.WriteLine("{0} → {1}", i, (char)i);
        }
    }
}