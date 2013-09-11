using System;

class KukataIsDancing
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[,] Square = { { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE" }, { "RED", "BLUE", "RED" } };
            sbyte col = 1;
            sbyte row = 1;
            string direction = "top";

            string input = Console.ReadLine();
            for (int s = 0; s < input.Length; s++)
            {
                switch (input[s])
                {
                    case 'L':
                        switch (direction)
                        {
                            case "left": direction = "down"; break;
                            case "right": direction = "top"; break;
                            case "top": direction = "left"; break;
                            case "down": direction = "right"; break;
                            default: break;
                        }
                        break;
                    case 'R':
                        switch (direction)
                        {
                            case "left": direction = "top"; break;
                            case "right": direction = "down"; break;
                            case "top": direction = "right"; break;
                            case "down": direction = "left"; break;
                            default: break;
                        }
                        break;
                    case 'W':
                        switch (direction)
                        {
                            case "left": col--; break;
                            case "right": col++; break;
                            case "top": row--; break;
                            case "down": row++; break;
                            default: break;
                        }
                        break;
                    default: break;
                }
                if (col < 0) col = 2;
                if (col > 2) col = 0;
                if (row < 0) row = 2;
                if (row > 2) row = 0;
            }
            Console.WriteLine(Square[row, col]);
        }
    }
}