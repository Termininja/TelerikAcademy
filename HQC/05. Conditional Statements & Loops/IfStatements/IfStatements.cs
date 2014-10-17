//Task 2: Refactor the following if statements
namespace Cooking
{
    using System;

    public class IfStatements
    {
        public static bool isVisitedCell { get; set; }

        public static void IfStatement1()
        {
            Potato potato = new Potato();
            potato.IsPeeled = true;

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        public static void IfStatement2()
        {
            int x = 5;
            int y = 20;
            int minX = 0;
            int minY = 0;
            int maxX = 100;
            int maxY = 100;

            if ((x >= minX && x <= maxX) && (y >= minY && y <= maxY) && !IfStatements.isVisitedCell)
            {
                VisitCell();
            }
        }

        public static void Cook(Vegetable vegetable)
        {
            Console.WriteLine("Cooking");
        }

        public static void VisitCell()
        {
            Console.WriteLine("Cell is visited");
        }
    }
}