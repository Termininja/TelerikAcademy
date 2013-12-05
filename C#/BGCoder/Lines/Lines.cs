using System;

class Lines
{
    static void Main()
    {
        int[,] T = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++) T[i, j] = (n >> (7 - j)) & 1;
        }

        int length = 0;
        int max = 0;
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (T[i, j] == 1)
                {
                    length++;
                    if (length > max)
                    {
                        max = length;
                        count = 1;
                    }
                    else if (length == max && max > 0) count++;
                }
                if (T[i, j] == 0 || j == 7) length = 0;
            }
        }

        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (T[i, j] == 1)
                {
                    length++;
                    if (length > max)
                    {
                        max = length;
                        count = 1;
                    }
                    else if (length == max && max > 0) count++;
                }
                if (T[i, j] == 0 || i == 7) length = 0;
            }
        }
        if (max == 1) count /= 2;
        Console.WriteLine(max + "\n" + count);
    }
}