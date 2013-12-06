using System;
using System.Numerics;
 
class NaBabaMiSmetalnika
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int[,] Field = new int[8, width];
 
        for (byte i = 0; i < 8; i++)
        {
            int inputNum = int.Parse(Console.ReadLine());
 
            for (int j = 0; j < width; j++)
            {
                Field[i, j] = (inputNum >> width - 1 - j) & 1;
            }
        }
 
        while (true)
        {
            string inputStr = Console.ReadLine();
 
            if (inputStr == "right" || inputStr == "left")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                if (col < 0) col = 0;
                if (col >= width) col = width - 1;
 
                switch (inputStr)
                {
                    case "right":
                        int count1 = 0;
                        for (int j = col; j < width; j++)
                        {
                            if (Field[row, j] == 1) count1++;
                        }
                        for (int j = width - 1; j >= col; j--)
                        {
                            if (count1 > 0)
                            {
                                Field[row, j] = 1;
                                count1--;
                            }
                            else Field[row, j] = 0;
                        }
                        break;
                    case "left":
                        int count2 = 0;
                        for (int j = 0; j <= col; j++)
                        {
                            if (Field[row, j] == 1) count2++;
                        }
                        for (int j = 0; j <= col; j++)
                        {
                            if (count2 > 0)
                            {
                                Field[row, j] = 1;
                                count2--;
                            }
                            else Field[row, j] = 0;
                        }
                        break;
                    default: break;
                }
            }
            else if (inputStr == "reset") Reset(width, Field);
            else if (inputStr == "stop") break;
        }
 
        BigInteger sum = 0;
        for (int i = 0; i < 8; i++)
        {
            string currN = "";
            for (int j = 0; j < width; j++) currN += Field[i, j];
            sum += TwoToTen(currN);
        }
 
        int freeCols = 0;
        for (int j = 0; j < width; j++)
        {
            bool isFree = true;
            for (int i = 0; i < 8; i++)
            {
                if (Field[i, j] == 1)
                {
                    isFree = false;
                    break;
                }
            }
            if (isFree) freeCols++;
        }
        Console.WriteLine(sum * freeCols);
    }
 
    private static void Reset(int width, int[,] Field)
    {
        for (int i = 0; i < 8; i++)
        {
            int count = 0;
            for (int j = 0; j < width; j++) if (Field[i, j] == 1) count++;
            for (int j = 0; j < width; j++)
            {
                if (count > 0)
                {
                    Field[i, j] = 1;
                    count--;
                }
                else Field[i, j] = 0;
            }
        }
    }
 
    static BigInteger TwoToTen(string str)
    {
        BigInteger n = 0;
        BigInteger j = 1;
        for (int i = str.Length - 1; i >= 0; i--, j *= 2) n += (str[i] - '0') * j;
        return n;
    }
}