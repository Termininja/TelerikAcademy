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
            int number = int.Parse(Console.ReadLine());
 
            S += Convert.ToString(number, 2);
        }
        int result = 0;
        int count_0 = 0;
        int count_1 = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (K == 0)
            {
                result = 0;
            }
            else
            {
                if (S[i] == '0')
                {
                    count_1 = 0;
                    count_0++;
                }
                if (S[i] == '1')
                {
                    count_0 = 0;
                    count_1++;
                }
                if (i == S.Length - 1)
                {
                    if (count_0 == K || count_1 == K)
                    {
                        result++;
                    }
                }
                else
                {
                    if ((count_0 == K || count_1 == K) && S[i + 1] != S[i])
                    {
                        result++;
                    }
                }
            }
        }
        Console.WriteLine(result);
    }
}