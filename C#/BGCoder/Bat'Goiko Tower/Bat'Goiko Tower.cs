using System;

class BatGoikoTower
{
    static void Main()
    {
        int H = int.Parse(Console.ReadLine());
        int l = 1;
        int d = 1;
        for (int h = 1; h <= H; h++)
        {
            Console.Write(new string('.', H - h) + "/");
            Console.Write(new string((h == l + d) ? '-' : '.', 2 * (h - 1)));
            if (h == l + d)
            {
                l = h;
                d++;
            }
            Console.WriteLine("\\" + new string('.', H - h));
        }
    }
}