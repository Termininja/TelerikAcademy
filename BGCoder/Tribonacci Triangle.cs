using System;
 
class TribonacciTriangle
{
    static void Main()
    {
        long X1 = long.Parse(Console.ReadLine());
        long X2 = long.Parse(Console.ReadLine());
        long X3 = long.Parse(Console.ReadLine());
        byte L = byte.Parse(Console.ReadLine());
 
        Console.WriteLine(X1);
        if (L >= 2)
        {
            Console.WriteLine(X2 + " " + X3);
        }
        for (int l = 3; l <= L; l++)
        {
            for (int i = 1; i <= l; i++)
            {
                long X4 = X1 + X2 + X3;
                Console.Write(X4);
                if (i < l)
                {
                    Console.Write(" ");
                }
                X1 = X2;
                X2 = X3;
                X3 = X4;
            }
            Console.WriteLine();
        }
    }
}