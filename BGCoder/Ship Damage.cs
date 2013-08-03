using System;
 
class ShipDamage
{
    static int SX1 = int.Parse(Console.ReadLine());
    static int SY1 = int.Parse(Console.ReadLine());
    static int SX2 = int.Parse(Console.ReadLine());
    static int SY2 = int.Parse(Console.ReadLine());
 
    static int H = int.Parse(Console.ReadLine());
 
    static int CX1 = int.Parse(Console.ReadLine());
    static int CY1 = int.Parse(Console.ReadLine());
 
    static int CX2 = int.Parse(Console.ReadLine());
    static int CY2 = int.Parse(Console.ReadLine());
 
    static int CX3 = int.Parse(Console.ReadLine());
    static int CY3 = int.Parse(Console.ReadLine());
 
    static int damage = 0;
 
    static void Result(int cx, int cy)
    {
        if ((cx == SX1 && cy == SY1) || (cx == SX2 && cy == SY2) || (cx == SX2 && cy == SY1) || (cx == SX1 && cy == SY2))
        {
            damage += 25;
        }
        else if ((cx == SX1 && cy < SY1 && cy > SY2) || (cx == SX2 && cy < SY1 && cy > SY2) || (cy == SY1 && cx < SX2 && cx > SX1) || (cy == SY2 && cx < SX2 && cx > SX1))
        {
            damage += 50;
        }
        else if ((cx < SX2) && (cx > SX1) && (cy < SY1) && (cy > SY2))
        {
            damage += 100;
        }
    }
 
    static void Main()
    {
        if (SX2 < SX1)
        {
            int temp1 = SX1;
            SX1 = SX2;
            SX2 = temp1;
        }
        if (SY2 > SY1)
        {
            int temp2 = SY1;
            SY1 = SY2;
            SY2 = temp2;
        }
 
        CY1 = 2 * H - CY1;
        CY2 = 2 * H - CY2;
        CY3 = 2 * H - CY3;
 
        Result(CX1, CY1);
        Result(CX2, CY2);
        Result(CX3, CY3);
 
        Console.WriteLine(damage + "%");
    }
}