using System;
 
class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int j = 0; j < n; j++)
        {
            int p = int.Parse(Console.ReadLine());
 
            int inverted = p;
            for (int k = 0; k < Convert.ToString(inverted, 2).Length; k++)
            {
                inverted ^= (1 << k);
            }
 
            int reversed = 0;
            int temp = p;
            while (temp > 0)
            {
                reversed = (reversed << 1) | (temp & 1);
                temp = temp >> 1;
            }
 
            Console.WriteLine((p ^ inverted) & reversed);
        }
    }
}