using System;

class DrunkenNumbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int beersM = 0;
        int beersV = 0;
        for (int i = 0; i < N; i++)
        {
            int drunkenNumber = int.Parse(Console.ReadLine());
            if (drunkenNumber < 0) drunkenNumber *= -1;
            int length = drunkenNumber.ToString().Length;

            if (length % 2 != 0)
            {
                while (drunkenNumber.ToString().Length > length / 2 + 1)
                {
                    beersV += drunkenNumber % 10;
                    drunkenNumber /= 10;
                }
                beersV += drunkenNumber % 10;
                beersM += drunkenNumber % 10;
                drunkenNumber /= 10;
            }
            else
            {
                while (drunkenNumber.ToString().Length > length / 2)
                {
                    beersV += drunkenNumber % 10;
                    drunkenNumber /= 10;
                }
            }
            while (drunkenNumber > 0)
            {
                beersM += drunkenNumber % 10;
                drunkenNumber /= 10;
            }
        }

        if (beersM > beersV) Console.WriteLine("M {0}", beersM - beersV);
        else if (beersV > beersM) Console.WriteLine("V {0}", beersV - beersM);
        else Console.WriteLine("No {0}", beersM + beersV);
    }
}