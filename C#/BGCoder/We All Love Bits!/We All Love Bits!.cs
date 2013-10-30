using System;
 
class WeAllLoveBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            int P = int.Parse(Console.ReadLine());
 
            int P_inverted = P;
            for (int k = 0; k < Convert.ToString(P_inverted, 2).Length; k++)
            {
                P_inverted ^= (1 << k);
            }
 
            int P_reversed = 0;
            int temp = P;
            while (temp > 0)
            {
                P_reversed = (P_reversed << 1) | (temp & 1);
                temp = temp >> 1;
            }
 
            int P_result = (P ^ P_inverted) & P_reversed;
            Console.WriteLine(P_result);
        }
    }
}