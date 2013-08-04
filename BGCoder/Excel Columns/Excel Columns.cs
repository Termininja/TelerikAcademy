using System;
  
class ExcelColumns
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        long sum = 0;
        for (int l = 1; l <= N; l++)
        {
            char letter = char.Parse(Console.ReadLine());
            sum += (long)Math.Pow(26, N - l) * (letter - 64);
        }
        Console.WriteLine(sum);
    }
}