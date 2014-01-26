using System;

class JoroTheRabbit
{
    static void Main()
    {
        string[] input = Console.ReadLine().Replace(" ", "").Split(',');
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }
        int dotsMax = 0;
        for (int startPosition = 0; startPosition < input.Length; startPosition++)
        {
            for (int step = 0; step < input.Length; step++)
            {
                int p = startPosition;
                int d = 1;
                int next = (p + step);
                if (next >= numbers.Length) next -= numbers.Length;
                while (next != startPosition)
                {
                    next = (p + step);
                    if (next >= numbers.Length) next -= numbers.Length;
                    if (numbers[next] <= numbers[p]) break;
                    d++;
                    p = next;
                }
                if (d >= dotsMax) dotsMax = d;
            }
        }
        Console.WriteLine(dotsMax);
    }
}