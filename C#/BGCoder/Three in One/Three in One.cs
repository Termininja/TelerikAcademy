using System;
using System.Collections.Generic;

class ThreeInOne
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
    }

    private static void Task1()
    {
        string[] Players = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> Winers = new List<int>();
        int max = 0;
        for (int i = 0; i < Players.Length; i++)
        {
            int points = int.Parse(Players[i]);
            if (points <= 21)
            {
                if (points > max)
                {
                    max = points;
                    Winers.Clear();
                    Winers.Add(i);
                }
                else if (points == max) Winers.Add(i);
            }
        }
        if (Winers.Count == 1) Console.WriteLine(Winers[0]);
        else Console.WriteLine("-1");
    }

    private static void Task2()
    {
        string[] Input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] Elements = new int[Input.Length];
        for (int i = 0; i < Elements.Length; i++)
        {
            Elements[i] = int.Parse(Input[i]);
        }
        int F = int.Parse(Console.ReadLine());
        Array.Sort(Elements);
        int bites = 0;
        for (int e = Elements.Length - 1; e >= 0; e -= F + 1)
        {
            bites += Elements[e];
        }
        Console.WriteLine(bites);
    }

    private static void Task3()
    {
        string[] Coins = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int G1 = int.Parse(Coins[0]);
        int S1 = int.Parse(Coins[1]);
        int B1 = int.Parse(Coins[2]);
        int G2 = int.Parse(Coins[3]);
        int S2 = int.Parse(Coins[4]);
        int B2 = int.Parse(Coins[5]);

        int diffG = G1 - G2;
        int diffS = S1 - S2;
        int diffB = B1 - B2;

        int operations = 0;

        while (true)
        {
            int temp = operations;
            if (diffS >= 1 && diffB < 0)
            {
                operations++;
                S1 -= 1;
                B1 += 9;
                Diff(G1, S1, B1, G2, S2, B2, ref diffG, ref diffS, ref diffB);
            }
            else if (diffS >= 11 && diffG < 0)
            {
                operations++;
                S1 -= 11;
                G1 += 1;
                Diff(G1, S1, B1, G2, S2, B2, ref diffG, ref diffS, ref diffB);
            }
            else if (diffG >= 1 && (diffS < 0 || diffB < 0))
            {
                operations++;
                G1 -= 1;
                S1 += 9;
                Diff(G1, S1, B1, G2, S2, B2, ref diffG, ref diffS, ref diffB);
            }
            else if (diffB >= 11 && (diffS < 0 || diffG < 0))
            {
                operations++;
                B1 -= 11;
                S1 += 1;
                Diff(G1, S1, B1, G2, S2, B2, ref diffG, ref diffS, ref diffB);
            }
            if (temp == operations) break;
        }

        if (G1 >= G2 && S1 >= S2 && B1 >= B2) Console.WriteLine(operations);
        else Console.WriteLine("-1");
    }

    private static void Diff(int G1, int S1, int B1, int G2, int S2, int B2, ref int diffG, ref int diffS, ref int diffB)
    {
        diffG = G1 - G2;
        diffS = S1 - S2;
        diffB = B1 - B2;
    }
}