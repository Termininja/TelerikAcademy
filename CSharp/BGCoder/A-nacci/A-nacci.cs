using System;

class ANacci
{
    static void Main()
    {
        char first = char.Parse(Console.ReadLine());
        char second = char.Parse(Console.ReadLine());
        byte L = byte.Parse(Console.ReadLine());

        for (int i = 1; i < 2 * L; i++)
        {
            int firstNum = (first - 64) % 26;
            int secondNum = (second - 64) % 26;

            if (firstNum == 0) firstNum = 26;
            if (secondNum == 0) secondNum = 26;

            first = (char)(firstNum + 64);
            second = (char)(secondNum + 64);

            if (i == 1) Console.WriteLine(first);
            if (i % 2 == 0)
            {
                Console.Write(first);
                if (i > 1) Console.Write(new string(' ', i / 2 - 1));
                if (i > 0) Console.Write(second);
                Console.WriteLine();
            }

            first = second;
            second = (char)(firstNum + secondNum + 64);
        }
    }
}