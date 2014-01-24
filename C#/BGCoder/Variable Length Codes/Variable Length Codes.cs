using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class VariableLengthCoding
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Trim().Split();
        int L = int.Parse(Console.ReadLine());
        Dictionary<char, int> codeTable = new Dictionary<char, int>();

        for (int l = 0; l < L; l++)
        {
            string input = Console.ReadLine();
            codeTable.Add(input[0], int.Parse(input.Substring(1)));
        }

        StringBuilder binary = new StringBuilder();
        for (int i = 0; i < numbers.Length; i++)
        {
            binary.Append(Convert.ToString(int.Parse(numbers[i]), 2).PadLeft(8, '0'));
        }
        StringBuilder Str = new StringBuilder();
        Str.Append(binary.ToString().TrimEnd(new Char[] { '0' }));

        StringBuilder result = new StringBuilder();
        int count = 0;
        for (int i = 0; i < Str.Length; i++)
        {
            if (Str[i] != '0')
            {
                count++;
                if (i == Str.Length - 1) result.Append(codeTable.FirstOrDefault(x => x.Value == count).Key);
            }
            else
            {
                result.Append(codeTable.FirstOrDefault(x => x.Value == count).Key);
                count = 0;
            }
        }
        Console.WriteLine(result);
    }
}