using System;
using System.Collections.Generic;
 
class Zerg
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
                    case "Rawr": num = 0; break;
                    case "Rrrr": num = 1; break;
                    case "Hsst": num = 2; break;
                    case "Ssst": num = 3; break;
                    case "Grrr": num = 4; break;
                    case "Rarr": num = 5; break;
                    case "Mrrr": num = 6; break;
                    case "Psst": num = 7; break;
                    case "Uaah": num = 8; break;
                    case "Uaha": num = 9; break;
                    case "Zzzz": num = 10; break;
                    case "Bauu": num = 11; break;
                    case "Djav": num = 12; break;
                    case "Myau": num = 13; break;
                    case "Gruh": num = 14; break;
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
                result *= 15;
            }
            Sum += (Result[i] * result);
        }
        Console.WriteLine(Sum);
    }
}