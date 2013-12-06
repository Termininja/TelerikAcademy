using System;
 
class OnesAndZeros
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string bits = "0000000000000000" + Convert.ToString(N, 2);
        string last16 = bits.Remove(0, bits.Length - 16);
 
        char[,] G = new char[5, 63];
        for (int i = 0; i < G.GetLength(0); i++)
        {
            for (int j = 0; j < G.GetLength(1); j++) G[i, j] = '.';
        }
 
        for (int i = 0; i < G.GetLength(0); i++)
        {
            int n = 0;
            for (int j = 0; j < G.GetLength(1); j += 4, n++)
            {
                if (last16[n] == '0')
                {
                    switch (i)
                    {
                        case 1: 
                        case 2: 
                        case 3: G[i, j] = '#'; G[i, j + 2] = '#'; break;
                        case 0: 
                        case 4: G[i, j] = '#'; G[i, j + 1] = '#'; G[i, j + 2] = '#'; break;
                        default: break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0: 
                        case 2: 
                        case 3: G[i, j + 1] = '#'; break;
                        case 1: G[i, j] = '#'; G[i, j + 1] = '#'; break;
                        case 4: G[i, j] = '#'; G[i, j + 1] = '#'; G[i, j + 2] = '#'; break;
                        default: break;
                    }
                }
            }
        }
 
        for (int i = 0; i < G.GetLength(0); i++)
        {
            for (int j = 0; j < G.GetLength(1); j++) Console.Write(G[i, j]); ;
            Console.WriteLine();
        }
    }
}