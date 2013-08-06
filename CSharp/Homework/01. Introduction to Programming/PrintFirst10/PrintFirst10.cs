//Task 9: Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class PrintFirst10
{
    static void Main()
    {
        for (int i = 2; i <= 11; i++)
        {
            if (i % 2 == 0)                        //these are all "i" devided on 2 plus 0
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write(-i + ", ");
            }
        }
        Console.WriteLine();
    }
}