using System;
using System.Text;

class Indices
{
    static void Main()
    {
        Console.ReadLine();
        string[] input = Console.ReadLine().Split(' ');
        int index = 0;
        bool loop = false;
        StringBuilder result = new StringBuilder();
        while (true)
        {
            if (index < input.Length && index >= 0)
            {
                if (input[index] == "*") loop = true;
                else
                {
                    int tempIndex = index;
                    index = int.Parse(input[index]);
                    result.Append(tempIndex + " ");
                    input[tempIndex] = "*";
                    continue;
                }
            }
            break;
        }
        if (loop)
        {
            if (index == 0) result.Insert(0, "(");
            else result.Replace(" " + index + " ", "(" + index + " ");
        }
        Console.WriteLine(result.ToString().TrimEnd() + ((loop) ? ")" : ""));
    }
}