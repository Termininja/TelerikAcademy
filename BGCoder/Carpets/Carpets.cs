using System;
 
class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[,] Carpet = new string[N, N];
 
        int count = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i < N / 2 && j < N / 2)
                {
                    if (j < N / 2 - 1 - i)
                    {
                        Carpet[i, j] = ".";
                    }
                    else if (count % 2 == 0)
                    {
                        Carpet[i, j] = "/";
                        count++;
                    }
                    else
                    {
                        Carpet[i, j] = " ";
                        count++;
                    }
                }
                if (i < N / 2 && j >= N / 2)
                {
                    if (j > N / 2 + i)
                    {
                        Carpet[i, j] = ".";
                    }
                    else if (count % 2 != 0)
                    {
                        Carpet[i, j] = "\\";
                        count++;
                    }
                    else
                    {
                        Carpet[i, j] = " ";
                        count++;
                    }
                }
                if (i >= N / 2 && j < N / 2)
                {
                    if (j < i - N / 2)
                    {
                        Carpet[i, j] = ".";
                    }
                    else if (count % 2 == 0)
                    {
                        Carpet[i, j] = "\\";
                        count++;
                    }
                    else
                    {
                        Carpet[i, j] = " ";
                        count++;
                    }
                }
                if (i >= N / 2 && j >= N / 2)
                {
                    if (j > 3 * N / 2 - 1 - i)
                    {
                        Carpet[i, j] = ".";
                    }
                    else if (count % 2 != 0)
                    {
                        Carpet[i, j] = "/";
                        count++;
                    }
                    else
                    {
                        Carpet[i, j] = " ";
                        count++;
                    }
                }
            }
            count = 0;
        }
 
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(Carpet[i, j]);
            }
            Console.WriteLine();
        }
    }
}