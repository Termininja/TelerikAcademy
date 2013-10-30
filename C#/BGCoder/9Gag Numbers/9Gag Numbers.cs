using System;
using System.Collections.Generic;
using System.Numerics;

class NineGagNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<byte> Result = new List<byte>();

        while (input.Length > 0)
        {
            string code = String.Empty;
            byte number = 0;

            for (int i = 0; i < input.Length; i++)
            {
                bool go = true;
                code += input[i];
                switch (code)
                {
                    case "-!": number = 0; go = false; break;
                    case "**": number = 1; go = false; break;
                    case "!!!": number = 2; go = false; break;
                    case "&&": number = 3; go = false; break;
                    case "&-": number = 4; go = false; break;
                    case "!-": number = 5; go = false; break;
                    case "*!!!": number = 6; go = false; break;
                    case "&*!": number = 7; go = false; break;
                    case "!!**!-": number = 8; go = false; break;
                    default: go = true; break;
                }
                if (!go)
                {
                    break;
                }
            }
            Result.Insert(0, number);
            input = input.Remove(0, code.Length);
        }

        BigInteger Sum = 0;
        for (int i = 0; i < Result.Count; i++)
        {
            BigInteger result = 1;
            for (int j = 0; j < i; j++)
            {
                result *= 9;
            }
            Sum += (Result[i] * result);
        }
        Console.WriteLine(Sum);
    }
}