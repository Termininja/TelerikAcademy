using System;
using System.Text;

class EncodeAndEncrypt
{
    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        Console.WriteLine(RunLength(cypher, Encode(message, cypher)) + cypher.Length);
    }

    private static string RunLength(string cypher, StringBuilder encoded)
    {
        string runLength = encoded.ToString() + cypher;
        int count = 1;
        string result = String.Empty;

        for (int i = 1; i < runLength.Length; i++)
        {
            if (runLength[i] == runLength[i - 1])
            {
                count++;
            }
            else
            {
                if ((count.ToString() + runLength[i - 1]).Length < count)
                {
                    result += count.ToString() + runLength[i - 1];
                }
                else
                {
                    result += new string(runLength[i - 1], count);
                }
                count = 1;
            }
            if (i == runLength.Length - 1)
            {
                if ((count.ToString() + runLength[i - 1]).Length < count)
                {
                    result += count.ToString() + runLength[i - 1];
                }
                else
                {
                    result += new string(runLength[i], count);
                }
            }
        }
        return result;
    }

    private static StringBuilder Encode(string m, string c)
    {
        StringBuilder result = new StringBuilder();
        for (int l = 0; l < m.Length; l++)
        {
            int encode = (m[l] - 65);
            int curr = l;
            curr = curr % c.Length;
            while (curr < c.Length)
            {
                encode ^= (c[curr] - 65);
                curr += m.Length;
            }
            result.Append((char)(encode + 65));
        }
        return result;
    }
}
