using System;
using System.Numerics;

class StrangeLandNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger result = 0;
        int p = 0;
        while (input.Length > 0)
        {
            string tempWord = String.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                tempWord = input[i] + tempWord;
                bool isFinded = true;
                int number = 0;
                switch (tempWord)
                {
                    case "f": number = 0; break;
                    case "bIN": number = 1; break;
                    case "oBJEC": number = 2; break;
                    case "mNTRAVL": number = 3; break;
                    case "lPVKNQ": number = 4; break;
                    case "pNWE": number = 5; break;
                    case "hT": number = 6; break;
                    default: isFinded = false; break;
                }
                if (isFinded)
                {
                    result += number * (BigInteger)Math.Pow(7, p);
                    p++;
                    input = input.Remove(i);
                    break;
                }
            }
        }
        Console.WriteLine(result);
    }
}