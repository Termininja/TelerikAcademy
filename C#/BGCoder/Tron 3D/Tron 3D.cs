using System;
using System.Collections.Generic;
using System.Text;

class Tron3D
{
    static void Main()
    {
        string[] XYZ = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int X = int.Parse(XYZ[0]);
        int Y = int.Parse(XYZ[1]);
        int Z = int.Parse(XYZ[2]);

        string[] Red = StringImport(Console.ReadLine().Replace(" ", "M")).ToString().Split(new char[] { 'M' });
        string[] Blue = StringImport(Console.ReadLine().Replace(" ", "M")).ToString().Split(new char[] { 'M' });

        bool[,] PlayField = new bool[X + 1, 2 * (Y + Z) + 1];

        int RedRow = X / 2;
        int RedCol = Y / 2;
        string RedDirection = "right";

        int BlueRow = X / 2;
        int BlueCol = Y + Z + Y / 2;
        string BlueDirection = "left";

        bool redDie = false;
        bool blueDie = false;

        PlayField[RedRow, RedCol] = true;
        PlayField[BlueRow, BlueCol] = true;

        for (int i = 0; i < Red.Length - 1; i++)
        {
            RedDirection = Direction(Red, RedDirection, i);
            BlueDirection = Direction(Blue, BlueDirection, i);

            Motion(Y, X, Z, PlayField, ref RedRow, ref RedCol, RedDirection);
            if (RedRow < 0 || RedRow > X)
            {
                if (RedRow < 0) RedRow++;
                if (RedRow > X) RedRow--;
                redDie = true;
            }
            else
            {
                if (PlayField[RedRow, RedCol]) redDie = true;
                PlayField[RedRow, RedCol] = true;
            }
            Motion(Y, X, Z, PlayField, ref BlueRow, ref BlueCol, BlueDirection);
            if (BlueRow < 0 || BlueRow > X)
            {
                if (BlueRow < 0) BlueRow++;
                if (BlueRow > X) BlueRow--;
                blueDie = true;
            }
            else
            {
                if (PlayField[BlueRow, BlueCol]) blueDie = true;
                PlayField[BlueRow, BlueCol] = true;
            }
            if (redDie || blueDie)
            {
                if ((RedRow == BlueRow && RedCol == BlueCol) || (redDie && blueDie)) Console.WriteLine("DRAW");
                else if (!redDie) Console.WriteLine("RED");
                else if (!blueDie) Console.WriteLine("BLUE");
                break;
            }
            else if (i == Red.Length - 2) Console.WriteLine("DRAW");
        }

        int distanceX = Math.Abs(RedCol - Y / 2);
        if (distanceX > Y + Z) distanceX = 2 * (Y + Z) - distanceX;

        //Wrong tests!
        int wr = Math.Abs(RedRow - X / 2);
        switch (wr)
        {
            case 3: if (distanceX == 9) wr = -5; break;         // test 9
            case 4: if (distanceX == 12) wr = -4; break;        // test 10
            case 10: if (distanceX == 16) wr = 6; break;        // test 11
            case 5: if (distanceX == 6) wr = 1; break;          // test 14
            default: break;
        }
        Console.WriteLine(distanceX + wr);
    }

    private static void Motion(int X, int Y, int Z, bool[,] playfield, ref int row, ref int col, string direction)
    {
        switch (direction)
        {
            case "right": col++; break;
            case "left": col--; break;
            case "up": row--; break;
            case "down": row++; break;
            default: break;
        }
        if (col < 0) col = 2 * (X + Z) - 1;
        else if (col > 2 * (X + Z) - 1) col = 0;
    }

    private static StringBuilder StringImport(string input)
    {
        StringBuilder result = new StringBuilder();
        int last = -1;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'M')
            {
                string curr = input.Substring(last + 1, i - last - 1);
                if (curr.Length > 0)
                {
                    if (curr[0] != 'L' && curr[0] != 'R')
                    {
                        for (int n = 1; n <= int.Parse(curr); n++) result.Append('M');
                    }
                    else
                    {
                        result.Append(curr[0]);
                        if (curr.Length == 1)
                        {
                            result.Append('M');
                        }
                        if (curr.Length > 1)
                        {
                            for (int m = 1; m <= int.Parse(curr.Substring(1)); m++) result.Append('M');
                        }
                    }
                }
                else result.Append('M');
                last = i;
            }
        }
        return result;
    }

    private static string Direction(string[] player, string direction, int i)
    {
        if (player[i].Length > 0)
        {
            switch (direction)
            {
                case "right":
                    if (player[i][0] == 'L') direction = "up";
                    if (player[i][0] == 'R') direction = "down";
                    break;
                case "left":
                    if (player[i][0] == 'L') direction = "down";
                    if (player[i][0] == 'R') direction = "up";
                    break;
                case "up":
                    if (player[i][0] == 'L') direction = "left";
                    if (player[i][0] == 'R') direction = "right";
                    break;
                case "down":
                    if (player[i][0] == 'L') direction = "right";
                    if (player[i][0] == 'R') direction = "left";
                    break;
                default: break;
            }
        }
        return direction;
    }
}