namespace Cooking
{
    using System;

    class Program
    {
        static void Main()
        {
            Potato potato = new Potato();
            potato.IsPeeled = true;

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    IfStatements.Cook(potato);
                }
            }

            int x = 5;
            int y = 20;
            int minX = 0;
            int minY = 0;
            int maxX = 100;
            int maxY = 100;

            if ((x >= minX && x <= maxX) && (y >= minY && y <= maxY) && !IfStatements.isVisitedCell)
            {
                IfStatements.VisitCell();
            }
        }
    }
}
