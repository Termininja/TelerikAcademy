using System;
using System.Numerics;

class MultiverseCommunication
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string output = String.Empty;
        while (input.Length > 0)
        {
            switch ((input.Length > 3) ? input.Remove(3) : input)
            {
                case "CHU": output += "0"; break;
                case "TEL": output += "1"; break;
                case "OFT": output += "2"; break;
                case "IVA": output += "3"; break;
                case "EMY": output += "4"; break;
                case "VNB": output += "5"; break;
                case "POQ": output += "6"; break;
                case "ERI": output += "7"; break;
                case "CAD": output += "8"; break;
                case "K-A": output += "9"; break;
                case "IIA": output += "A"; break;
                case "YLO": output += "B"; break;
                case "PLA": output += "C"; break;
                default: break;
            }
            input = input.Remove(0, 3);
        }

        BigInteger result = 0;
        for (int i = output.Length - 1, p = 1; i >= 0; i--, p *= 13)
        {
            BigInteger get = (output[i] >= 'A') ? output[i] - 'A' + 10 : output[i] - '0';
            result += get * p;
        }
        Console.WriteLine(result);
    }
}