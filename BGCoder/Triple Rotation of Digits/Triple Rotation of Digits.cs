using System;
 
class TripleRotation
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
 
        for (int i = 1; i <= 3; i++)
        {
            if (number > 9)
            {
                int temp1 = number / 10;
                int temp2 = number % 10;
                string result = temp2.ToString() + temp1.ToString();
                number = int.Parse(result);
            }
        }
        Console.WriteLine(number);
    }
}