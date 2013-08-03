using System;
 
class FallDown
{
    static void Main()
    {
        int[,] Matrix = new int[8, 8];
        int[,] Result = new int[8, 8];
 
        for (int i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                Matrix[i, j] = (n >> (7 - j)) & 1;
            }
        }
        for (int j = 0; j < 8; j++)
        {
            int cell = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Matrix[i, j] == 1)
                {
                    Result[7 - cell, j] = 1;
                    cell++;
                }
            }
        }
 
        int number = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                number = number | (Result[i, j] << (7 - j));
            }
            Console.WriteLine(number);
        }
    }
}