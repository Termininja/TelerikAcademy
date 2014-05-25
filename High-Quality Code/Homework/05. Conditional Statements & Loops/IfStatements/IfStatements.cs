//Task 2: Refactor the following if statements

using System;

class IfStatements
{
    static void Main()
    {
        Potato potato = new Potato();

        if (potato != null)
        {
            if (potato.isPeeled && !potato.isRotten)
            {
                Cook(potato);
            }
        }

        if ((x >= MIN_X && x <= MAX_X) && (y >= MIN_Y && y <= MAX_Y) && !isVisitedCell)
        {
            VisitCell();
        }
    }
}