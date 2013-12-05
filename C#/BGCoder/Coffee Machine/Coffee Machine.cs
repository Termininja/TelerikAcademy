using System;

class CoffeeMachine
{
    static decimal change;
    static int[] N = new int[5];

    static void Main()
    {
        for (int n = 0; n < 5; n++) N[n] = int.Parse(Console.ReadLine());
        decimal amount = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());

        if (amount < price) Console.Write("More {0}", price - amount);
        else
        {
            change = amount - price;
            Check(1.00m, 4);
            Check(0.50m, 3);
            Check(0.20m, 2);
            Check(0.10m, 1);
            Check(0.05m, 0);
            if (change == 0) Console.Write("Yes {0}", N[0] * 0.05m + N[1] * 0.10m + N[2] * 0.2m + N[3] * 0.5m + N[4] * 1m);
            else Console.Write("No {0}", change);
        }
    }

    private static void Check(decimal v, byte n)
    {
        while (change >= v && N[n] > 0)
        {
            change = change - v;
            N[n]--;
        }
    }
}