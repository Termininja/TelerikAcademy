using System;

class Slides
{
    static void Main()
    {
        string[] Dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int W = int.Parse(Dimensions[0]);
        int H = int.Parse(Dimensions[1]);
        int D = int.Parse(Dimensions[2]);

        string[, ,] cuboid = new string[W, H, D];

        for (int h = 0; h < H; h++)
        {
            string[] strH = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < D; d++)
            {
                string[] strW = strH[d].Split(new char[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < W; w++)
                {
                    cuboid[w, h, d] = strW[w].Trim();
                }
            }
        }

        int[] Ball = new int[3];
        Ball[1] = 0;
        string[] inputBall = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Ball[0] = int.Parse(inputBall[0]);
        Ball[2] = int.Parse(inputBall[1]);

        bool cont = true;
        bool ballOut = false;
        int[] oldPos = new int[Ball.Length];

        while (cont)
        {
            Array.Copy(Ball, oldPos, Ball.Length);
            switch (cuboid[Ball[0], Ball[1], Ball[2]][0])
            {
                case 'S':
                    switch ((cuboid[Ball[0], Ball[1], Ball[2]]).Remove(0, 2))
                    {
                        case "F": Ball[2]--; break;
                        case "B": Ball[2]++; break;
                        case "L": Ball[0]--; break;
                        case "R": Ball[0]++; break;
                        case "BL": Ball[2]++; Ball[0]--; break;
                        case "BR": Ball[2]++; Ball[0]++; break;
                        case "FL": Ball[2]--; Ball[0]--; break;
                        case "FR": Ball[2]--; Ball[0]++; break;
                        default: break;
                    }
                    Ball[1]++;
                    break;
                case 'T':
                    string[] newValues = (cuboid[Ball[0], Ball[1], Ball[2]]).Remove(0, 2).Split(' ');
                    Ball[0] = int.Parse(newValues[0]);
                    Ball[2] = int.Parse(newValues[1]);
                    break;
                case 'B': cont = false; break;
                case 'E': Ball[1]++; break;
                default: break;
            }
            if (Ball[0] < 0 || Ball[0] >= W || Ball[2] < 0 || Ball[2] >= D)
            {
                cont = false;
            }
            if (Ball[1] >= H)
            {
                cont = false;
                ballOut = true;
            }
        }

        if (ballOut) Console.WriteLine("Yes");
        else Console.WriteLine("No");

        Console.WriteLine(oldPos[0] + " " + oldPos[1] + " " + oldPos[2]);
    }
}