using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte B = byte.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        for (int n = 0; n < N; n++)
        {
            long number = long.Parse(Console.ReadLine());
            int count = 0;
            while (number != 0)
            {
                if ((byte)(number & 1) == B) count++;
                number >>= 1;
            }
            Console.WriteLine(count);
        }
    }
}