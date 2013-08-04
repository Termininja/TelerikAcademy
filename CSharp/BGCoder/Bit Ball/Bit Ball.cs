using System;
  
class BitBall
{
    static void Main()
    {
        byte[,] Top = new byte[8, 8];
        byte[,] Bottom = new byte[8, 8];
        char[,] Result = new char[8, 8];
  
        for (int number = 0; number < 8; number++)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (int i = 7; i >= 0; i--)
            {
                Top[number, i] = byte.Parse(((Convert.ToString(n, 2).PadLeft(8, '0'))[i]).ToString());
            }
        }
        for (int number = 0; number < 8; number++)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (int i = 7; i >= 0; i--)
            {
                Bottom[number, i] = byte.Parse(((Convert.ToString(n, 2).PadLeft(8, '0'))[i]).ToString());
            }
        }
  
  
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Top[i, j] == Bottom[i, j] && Top[i, j] == 1)
                {
                    Top[i, j] = 0;
                    Bottom[i, j] = 0;
                }
                else if (Top[i, j] == 1)
                {
                    Result[i, j] = 'T';
                }
                else if (Bottom[i, j] == 1)
                {
                    Result[i, j] = 'B';
                }
            }
        }
        int CountT = 0;
        int CountB = 0;
        bool T = false;
        bool B = false;
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Result[i, j] == 'T')
                {
                    if (i == 7)
                    {
                        CountT++;
                    }
                    else
                    {
                        for (int k = i + 1; k < 8; k++)
                        {
                            if (Result[k, j] == 'B' || Result[k, j] == 'T')
                            {
                                T = false;
                                break;
                            }
                            else
                            {
                                T = true;
                            }
                        }
                        if (T == true)
                        {
                            CountT++;
                        }
                    }
                }
                if (Result[i, j] == 'B')
                {
                    if (i == 0)
                    {
                        CountB++;
                    }
                    else
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (Result[k, j] == 'T' || Result[k, j] == 'B')
                            {
                                B = false;
                                break;
                            }
                            else
                            {
                                B = true;
                            }
                        }
                        if (B == true)
                        {
                            CountB++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("{0}:{1}", CountT, CountB);
    }
}