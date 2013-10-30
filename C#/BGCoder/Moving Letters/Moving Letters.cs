using System;
using System.Text;
  
class MovingLetters
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        StringBuilder stringResult = new StringBuilder();
  
        bool cont = true;
        int temp = 0;
        while (cont)
        {
            cont = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length - 1 - temp >= 0)
                {
                    stringResult.Append(input[i][input[i].Length - 1 - temp]);
                    cont = true;
                }
            }
            temp++;
        }
  
        for (int l = 0; l < stringResult.Length; l++)
        {
            char currentLetter = stringResult[l];
            int k = currentLetter > 96 ? 96 : 64;
            int newPosition = (l + currentLetter - k) % stringResult.Length;
            stringResult.Remove(l, 1).Insert(newPosition, currentLetter);
        }
  
        Console.WriteLine(stringResult);
    }
}