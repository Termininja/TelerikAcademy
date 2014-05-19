using System;

class DancingBits
{
    static void Main()
    {
        string S = "";
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        for (int n = 0; n < N; n++)
        {
            S += Convert.ToString(int.Parse(Console.ReadLine()), 2);
        }
        int result = 0;
        int count0 = 0;
        int count1 = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (K == 0) result = 0;
            else
            {
                if (S[i] == '0')
                {
                    count1 = 0;
                    count0++;
                }
                if (S[i] == '1')
                {
                    count0 = 0;
                    count1++;
                }
                if ((i == S.Length - 1 && (count0 == K || count1 == K)) || 
                    ((count0 == K || count1 == K) && S[i + 1] != S[i])) result++;
            }
        }
        Console.WriteLine(result);
    }
}