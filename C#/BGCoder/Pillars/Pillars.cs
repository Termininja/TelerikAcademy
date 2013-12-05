using System;

class Pillars
{
    static void Main()
    {
        int[,] Matrix = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int number = byte.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++) Matrix[i, j] = (number >> 7 - j) & 1;
        }

        int sum_left = 0;
        int sum_right = 0;
        bool win = false;

        for (int col = 0; col < 8; col++)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (Matrix[i, j] == 1) sum_left++;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = col + 1; j < 8; j++)
                {
                    if (Matrix[i, j] == 1) sum_right++;
                }
            }

            if (sum_left == sum_right)
            {
                Console.WriteLine(7 - col);
                Console.WriteLine(sum_left);
                win = true;
                return;
            }
            else
            {
                win = false;
                sum_left = 0;
                sum_right = 0;
            }
        }
        if (win == false) Console.WriteLine("No");
    }
}