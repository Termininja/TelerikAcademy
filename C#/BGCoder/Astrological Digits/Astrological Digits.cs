using System;

class AstroDigits
{
    static void Main()
    {
        string N = Console.ReadLine();
        int Sum = 0;
        while (true)
        {
            Sum = 0;
            for (int i = 0; i < N.Length; i++)
            {
                if (N[i] != '.' && N[i] != '-') Sum += int.Parse(N[i].ToString());
            }
            if (Sum < 10) break;
            N = Sum.ToString();
        }
        Console.WriteLine(Sum);
    }
}