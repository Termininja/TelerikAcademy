using System;
 
class AngryBits
{
    static void Main()
    {
        int[,] Playground = new int[8, 16];
        byte path = 0;
        int scores = 0;
        for (byte i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++)
            {
                Playground[i, j] = (n >> 15 - j) & 1;
            }
        }
 
        int pigs = 0;
        int pigs_start = 0;
        for (int i_pigs = 0; i_pigs < 8; i_pigs++)
        {
            for (int j_pigs = 8; j_pigs < 16; j_pigs++)
            {
                if (Playground[i_pigs, j_pigs] == 1)
                {
                    pigs_start++;
                }
            }
        }
 
        for (int j = 7; j >= 0; j--)
        {
            if (pigs_start > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Playground[i, j] == 1)
                    {
                        Playground[i, j] = 0;
                        string direction = "up";
                        while (true)
                        {
                            if (direction == "up")
                            {
                                i--; j++; path++;
                            }
                            if (direction == "down")
                            {
                                i++; j++; path++;
                            }
 
                            if (i < 0)
                            {
                                i += 2;
                                direction = "down";
                            }
                            if (i > 7 || j > 15)
                            {
                                path = 0;
                                break;
                            }
                            if (Playground[i, j] == 1)
                            {
                                for (int p = i - 1; p <= i + 1; p++)
                                {
                                    for (int q = j - 1; q <= j + 1; q++)
                                    {
                                        if (p >= 0 && p <= 7 && q <= 15)
                                        {
                                            Playground[p, q] = 0;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        pigs = 0;
                        for (int i_pigs = 0; i_pigs < 8; i_pigs++)
                        {
                            for (int j_pigs = 8; j_pigs < 16; j_pigs++)
                            {
                                if (Playground[i_pigs, j_pigs] == 1)
                                {
                                    pigs++;
                                }
                            }
                        }
 
                        scores = scores + (pigs_start - pigs) * path;
                        pigs_start = pigs;
                        path = 0;
                        j = 7;
                        break;
                    }
                }
            }
        }
        string win = "Yes";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 8; j < 16; j++)
            {
                if (Playground[i, j] == 1)
                {
                    win = "No";
                    break;
                }
            }
        }
        Console.WriteLine("{0} {1}", scores, win);
    }
}