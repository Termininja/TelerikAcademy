using System;

class Laser
{
    static void Main()
    {
        int[] dimensions = Split();
        int[] startPos = Split();
        int[] Direction = Split();

        int[] result = new int[3];
        result = startPos;

        bool[, ,] fired = new bool[dimensions[0] + 1, dimensions[1] + 1, dimensions[2] + 1];

        for (int i = 1; i <= dimensions[1]; i++)
        {
            fired[dimensions[0], i, dimensions[2]] = true; fired[dimensions[0], i, 1] = true; fired[1, i, dimensions[2]] = true; fired[1, i, 1] = true;
        }
        for (int i = 1; i <= dimensions[0]; i++)
        {
            fired[i, dimensions[1], dimensions[2]] = true; fired[i, dimensions[1], 1] = true; fired[i, 1, dimensions[2]] = true; fired[i, 1, 1] = true;
        }
        for (int i = 1; i <= dimensions[2]; i++)
        {
            fired[dimensions[0], dimensions[1], i] = true; fired[dimensions[0], 1, i] = true; fired[1, dimensions[1], i] = true; fired[1, 1, i] = true;
        }

        int[] final = new int[3];
        while (!fired[result[0], result[1], result[2]])
        {
            fired[result[0], result[1], result[2]] = true;
            Array.Copy(result, final, 3);

            result[0] += Direction[0];
            result[1] += Direction[1];
            result[2] += Direction[2];

            if (result[0] == 1) Direction[0] = 1;
            if (result[0] == dimensions[0]) Direction[0] = -1;

            if (result[1] == 1) Direction[1] = 1;
            if (result[1] == dimensions[1]) Direction[1] = -1;

            if (result[2] == 1) Direction[2] = 1;
            if (result[2] == dimensions[2]) Direction[2] = -1;
        }
        Console.Write(final[0] + " " + final[1] + " " + final[2]);
    }

    static int[] Split()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[3];
        for (int i = 0; i < 3; i++)
        {
            result[i] = int.Parse(input[i]);
        }
        return result;
    }
}