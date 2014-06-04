//Task 2: Refactor the following if statements
namespace Cooking
{
    using System;

    public class IfStatements
    {
        public static bool isVisitedCell { get; set; }

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