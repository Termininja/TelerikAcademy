using System;
using System.Collections.Generic;
 
class MissCat
{
    static void Main()
    {
        int[] CatVotes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            int vote = int.Parse(Console.ReadLine());
            CatVotes[vote - 1]++;
        }
        int max = 0;
        int cat = 0;
        for (int i = 0; i < 10; i++)
        {
            if (CatVotes[i] > max)
            {
                max = CatVotes[i];
                cat = 1 + i;
            }
        }
        Console.WriteLine(cat);
    }
}