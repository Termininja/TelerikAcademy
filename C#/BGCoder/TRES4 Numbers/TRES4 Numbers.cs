using System;
using System.Numerics;
using System.Text;

class TRES4Numbers
{
    static void Main()
    {
        BigInteger num = BigInteger.Parse(Console.ReadLine());
        string result = String.Empty;
        for (; num != 0; num /= 9)
        {
            BigInteger i = num % 9;
            char get = (i >= 10) ? (char)('A' + i - 10) : (char)('0' + i);
            result = get + result;
        }
        StringBuilder output = new StringBuilder();
        if (result == "") output.Append("LON+");
        else
        {
            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case '0': output.Append("LON+"); break;
                    case '1': output.Append("VK-"); break;
                    case '2': output.Append("*ACAD"); break;
                    case '3': output.Append("^MIM"); break;
                    case '4': output.Append("ERIK|"); break;
                    case '5': output.Append("SEY&"); break;
                    case '6': output.Append("EMY>>"); break;
                    case '7': output.Append("/TEL"); break;
                    case '8': output.Append("<<DON"); break;
                    default: break;
                }
            }
        }
        Console.WriteLine(output);
    }
}