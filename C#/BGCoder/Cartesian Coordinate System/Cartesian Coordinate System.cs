using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        Console.WriteLine((x == 0 && y == 0) ? 0 : ((x > 0) ? ((y > 0) ? 1 :
            ((y < 0) ? 4 : 6)) : ((x < 0) ? ((y > 0) ? 2 : ((y < 0) ? 3 : 6)) : 5)));
    }
}