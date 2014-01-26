using System;

class GreedyDwarf
{
    static void Main()
    {
        string[] N = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] Numbers = new int[N.Length];
        for (int n = 0; n < Numbers.Length; n++)
        {
            Numbers[n] = int.Parse(N[n]);
        }
        int CoinsMax = int.MinValue;
        int M = int.Parse(Console.ReadLine());
        for (int i = 1; i <= M; i++)
        {
            string[] P = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] Pattern = new int[P.Length];
            for (int p = 0; p < Pattern.Length; p++)
            {
                Pattern[p] = int.Parse(P[p]);
            }
            bool[] used = new bool[Numbers.Length];
            int index = 0;
            int coins = Numbers[index];
            used[index] = true;
            bool brk = false;
            while (!brk)
            {
                for (int p = 0; p < Pattern.Length; p++)
                {
                    index += Pattern[p];
                    if (index > Numbers.Length - 1 || index < 0 || used[index])
                    {
                        brk = true;
                        break;
                    }
                    coins += Numbers[index];
                    used[index] = true;
                }
            }
            if (coins >= CoinsMax) CoinsMax = coins;
        }
        Console.WriteLine(CoinsMax);
    }
}