using System;
 
class FormulaBit
{
    static void Main()
    {
        int X = 0;
        int Y = 0;
 
        int[,] Track = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                Track[i, j] = (n >> 7 - j) & 1;
            }
        }
 
        int row = 0;
        int col = 7;
        string direction = "down";
        string temp = "down";
 
        if (Track[row, col] != 1)
        {
            X = 1;
            while (row < 8 && col < 8 && col >= 0 && row >= 0)
            {
                if ((direction == "down" && row == 7) || direction == "top" && row == 0)
                {
                    goto check;
                }
                if (direction == "down" && Track[row + 1, col] != 1)
                {
                    row++;
                    X++;
                }
                if (direction == "left" && Track[row, col - 1] != 1)
                {
                    col--;
                    X++;
                }
                if (direction == "top" && Track[row - 1, col] != 1)
                {
                    row--;
                    X++;
                }
            check:
                if ((direction == "top" || direction == "down") && (row == 0 || row == 7))
                {
                    if (col == 0)
                    {
                        break;
                    }
                    else
                    {
                        temp = direction;
                        direction = "left";
                        col--;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                }
                else
                {
                    if ((direction == "down" && Track[row + 1, col] == 1) || (direction == "top" && Track[row - 1, col] == 1))
                    {
                        temp = direction;
                        direction = "left";
                        col--;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                }
                if (row == 7 && col == 0)
                {
                    break;
                }
                if (direction == "left" && col == 0)
                {
                    if (temp == "down")
                    {
                        direction = "top";
                        row--;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                    if (temp == "top")
                    {
                        direction = "down";
                        row++;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                }
                else
                {
                    if (direction == "left" && Track[row, col - 1] == 1 && temp == "down")
                    {
                        direction = "top";
                        row--;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                    if (direction == "left" && Track[row, col - 1] == 1 && temp == "top")
                    {
                        direction = "down";
                        row++;
                        if (Track[row, col] == 1)
                        {
                            break;
                        }
                        X++;
                        Y++;
                    }
                }
            }
        }
        if (row == 7 && col == 0)
        {
            Console.WriteLine("{0} {1}", X, Y);
        }
        else
        {
            Console.WriteLine("No {0}", X);
        }
    }
}