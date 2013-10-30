using System;
using System.Collections.Generic;

class MultiverseCommunication
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<byte> Result = new List<byte>();
        while (input.Length > 0)
        {
            string code = String.Empty;
            byte num = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool go = false;
                code += input[i];
                switch (code)
                {
                    case "CHU": num = 0; break;
                    case "TEL": num = 1; break;
                    case "OFT": num = 2; break;
                    case "IVA": num = 3; break;
                    case "EMY": num = 4; break;
                    case "VNB": num = 5; break;
                    case "POQ": num = 6; break;
                    case "ERI": num = 7; break;
                    case "CAD": num = 8; break;
                    case "K-A": num = 9; break;
                    case "IIA": num = 10; break;
                    case "YLO": num = 11; break;
                    case "PLA": num = 12; break;
                    default: go = true; break;
                }
                if (!go)
                {
                    break;
                }
            }
            Result.Insert(0, num);
            input = input.Remove(0, code.Length);
        }
        ulong Sum = 0;
        for (int i = 0; i < Result.Count; i++)
        {
            ulong result = 1;
            for (int j = 0; j < i; j++)
            {
                result *= 13;
            }
            Sum += (Result[i] * result);
        }
        Console.WriteLine(Sum);
    }
}