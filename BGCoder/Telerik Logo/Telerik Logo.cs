using System;
 
class TelerikLogo
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Z = X / 2 + 1;
        int max = 2 * X - 1 + 2 * (Z - 1);
 
        char[,] Logo = new char[max, max];
 
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                Logo[i, j] = '.';
            }
        }
        int row = Z - 1;
        int col = 0;
        string direction = "top-right";
 
 
        for (int i = 1; i <= 2 * (X / 2) + 3 * (2 * X - 1) - 2; i++)
        {
            if (direction == "top-right")
            {
                Logo[row, col] = '*';
                row--;
                col++;
            }
            if (direction == "down-right")
            {
                Logo[row, col] = '*';
                row++;
                col++;
            }
            if (direction == "down-left")
            {
                Logo[row, col] = '*';
                row++;
                col--;
            }
            if (direction == "top-left")
            {
                Logo[row, col] = '*';
                row--;
                col--;
            }
 
            if (row < 0)
            {
                direction = "down-right";
                row += 2;
            }
            else if (col > max - Z && i < max)
            {
                direction = "down-left";
                col -= 2;
            }
            else if (row >= max)
            {
                direction = "top-left";
                row -= 2;
            }
            else if (col < Z - 1 && i > max)
            {
                direction = "top-right";
                col += 2;
            }
        }
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                Console.Write(Logo[i, j]);
            }
            Console.WriteLine();
        }
    }
}