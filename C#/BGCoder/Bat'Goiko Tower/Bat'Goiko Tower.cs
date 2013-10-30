using System;

class BatGoikoTower
{
    static void Main()
    {
        int H = int.Parse(Console.ReadLine());
        int temp = 1;
        int k = 1;
        for (int i = 0; i < H; i++)
        {
            Console.Write(new string('.', H - 1 - i) + "/");
            if (i == temp)
            {
                Console.Write(new string('-', 2 * i));
                k++;
                temp = i + k;
            }
            else Console.Write(new string('.', 2 * i));
            Console.Write("\\" + new string('.', H - 1 - i) + "\n");
        }
    }
}