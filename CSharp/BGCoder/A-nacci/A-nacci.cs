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
            int first_number = (first - 64) % 26;
            int second_number = (second - 64) % 26;
 
            if (first_number == 0)
            {
                first_number = 26;
            }
            if (second_number == 0)
            {
                second_number = 26;
            }
            first = (char)(first_number + 64);
            second = (char)(second_number + 64);
 
            if (i == 1)
            {
                Console.WriteLine(first);
            }
 
            if (i % 2 == 0)
            {
                Console.Write(first);
                if (i > 1)
                {
                    Console.Write(new string(' ', i / 2 - 1));
                }
                if (i > 0)
                {
                    Console.Write(second);
                }
                Console.WriteLine();
            }
 
            first = second;
            second = (char)(first_number + second_number + 64);
        }
    }
}