using System;

class FighterAttack
{
    static void Main()
    {
        int PX1 = int.Parse(Console.ReadLine());
        int PY1 = int.Parse(Console.ReadLine());
        int PX2 = int.Parse(Console.ReadLine());
        int PY2 = int.Parse(Console.ReadLine());
        int FX = int.Parse(Console.ReadLine());
        int FY = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        int damage = 0;

        if (PX1 > PX2)
        {
            int temp1 = PX1;
            PX1 = PX2;
            PX2 = temp1;
        }
        if (PY1 < PY2)
        {
            int temp2 = PY1;
            PY1 = PY2;
            PY2 = temp2;
        }

        FX += D;
        if (FX == PX1 && FX == PX2 && FY == PY1 && FY == PY2) damage = 100;
        else if (FX == PX1 - 1 && FY <= PY1 && FY >= PY2) damage = 75;
        else if ((FX >= PX1 && FX <= PX2) && (FY == PY2 - 1 || FY == PY1 + 1)) damage = 50;
        else if ((FX >= PX1 && FX <= PX2 - 1) && (FY == PY2 || FY == PY1)) damage = 225;
        else if (FX == PX2 && (FY == PY1 || FY == PY2)) damage = 150;
        else if (FX == PX2 && (FY <= PY1 - 1 && FY >= PY2 + 1)) damage = 200;
        else if (FX >= PX1 && FX <= PX2 - 1 && FY <= PY1 - 1 && FY >= PY2 + 1) damage = 275;

        Console.WriteLine(damage + "%");
    }
}