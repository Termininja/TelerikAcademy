using System;

class Garden
{
    static void Main()
    {
        decimal seed = 0;
        int area = 0;
        for (int v = 1; v <= 6; v++)
        {
            switch (v)
            {
                case 1: seed += int.Parse(Console.ReadLine()) * 0.5M; break;
                case 2: seed += int.Parse(Console.ReadLine()) * 0.4M; break;
                case 3: seed += int.Parse(Console.ReadLine()) * 0.25M; break;
                case 4: seed += int.Parse(Console.ReadLine()) * 0.6M; break;
                case 5: seed += int.Parse(Console.ReadLine()) * 0.3M; break;
                case 6: seed += int.Parse(Console.ReadLine()) * 0.4M; break;
                default: break;
            }
            if (v != 6) area += int.Parse(Console.ReadLine());
        }
        int areaB = 250 - area;

        Console.WriteLine("Total costs: {0:F2}", seed);
        if (areaB == 0) Console.WriteLine("No area for beans");
        else if (areaB < 0) Console.WriteLine("Insufficient area");
        else if (true) Console.WriteLine("Beans area: {0}", areaB);
    }
}