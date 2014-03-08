using System;

class BatGoikoTower
{
    static void Main()
    {
        int H = int.Parse(Console.ReadLine());
        for (int h = 1, l = 1, d = 1; h <= H; h++)
        {
            Console.WriteLine(new string('.', H - h) + "/" + new string((h == l + d) ? '-' : '.', 2 * h - 2) + "\\" + new string('.', H - h));
            if (h == l + d)
            {
                l = h;
                d++;
            }
        }
    }
}