using System;

class Bittris
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] Field = new int[4, 8];
        int[] shape = new int[8];

        int points = 0;
        bool isStopped = false;
        bool gameOver = false;
        for (int n = 0; n < N; n++)
        {
            if (n % 4 == 0)
            {
                isStopped = false;
                int input = int.Parse(Console.ReadLine());

                if (input > 255)
                {
                    string bin = Convert.ToString(input, 2);
                    points += (bin.Remove(bin.Length - 8)).Replace("0", "").Length;
                    bin = bin.Remove(0, bin.Length - 8);
                    input = int.Parse(bin);
                }

                for (int j = 0; j < 8; j++)
                {
                    shape[7 - j] = (input >> j) & 1;
                    Field[0, 7 - j] = shape[7 - j];
                }
            }
            else
            {
                switch (Console.ReadLine())
                {
                    case "L":
                        if (!isStopped && shape[0] != 1)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (shape[j] == 1 && Field[n % 4 - 1, j - 1] != 1)
                                {
                                    Field[n % 4 - 1, j] = 0;
                                    Field[n % 4 - 1, j - 1] = 1;
                                    shape[j] = 0;
                                    shape[j - 1] = 1;
                                }
                            }
                        }
                        break;
                    case "R":
                        if (!isStopped && shape[7] != 1)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (shape[7 - j] == 1 && Field[n % 4 - 1, 7 - j + 1] != 1)
                                {
                                    Field[n % 4 - 1, 7 - j] = 0;
                                    Field[n % 4 - 1, 7 - j + 1] = 1;
                                    shape[7 - j] = 0;
                                    shape[7 - j + 1] = 1;
                                }
                            }
                        }
                        break;
                    default: break;
                }
                if (!isStopped)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (shape[j] == 1 && Field[n % 4, j] == 1)
                        {
                            isStopped = true;
                            break;
                        }
                        else isStopped = false;
                    }
                }

                if (!isStopped)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (shape[j] == 1)
                        {
                            Field[n % 4 - 1, j] = 0;
                            Field[n % 4, j] = 1;
                        }
                    }
                }

                if (isStopped || n % 4 == 3)
                {
                    for (int row = 0; row < 4; row++)
                    {
                        bool isLine = true;
                        for (int j = 0; j < 8; j++)
                        {
                            if (Field[row, j] != 1) isLine = false;
                        }
                        for (int j = 0; j < 8; j++)
                        {
                            if (row == 0 && Field[row, j] == 1)
                            {
                                gameOver = true;
                                break;
                            }
                        }
                        if (isLine)
                        {
                            int p = 0;
                            foreach (var item in shape) if (item == 1) p++;

                            for (int i = row; i > 0; i--)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Field[i, j] = Field[i - 1, j];
                                    shape[j] = 0;
                                }
                            }
                            if (row == 0)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Field[0, j] = 0;
                                    shape[j] = 0;
                                }
                                gameOver = false;
                            }
                            points += p * 10;
                        }
                        if (gameOver) break;
                    }
                    foreach (var item in shape) if (item == 1 && (n % 4 == 3 || gameOver)) points++;
                }
            }
            if (gameOver) break;
        }
        Console.WriteLine(points);
    }
}