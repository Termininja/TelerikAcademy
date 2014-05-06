using System;

class Sheets
{
    static void Main()
    {
        ushort N = ushort.Parse(Console.ReadLine());
        for (int i = 10; i >= 0; i--)
        {
            if ((N & 1) == 0) Console.WriteLine("A{0}", i);
            N >>= 1;
        }
    }
}