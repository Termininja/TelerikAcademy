using System;
using System.Collections.Generic;

class BullsAndCows
{
    static void Main()
    {
        string secretNumber = Console.ReadLine();
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        List<int> result = new List<int>();
        for (int i = 1111; i <= 9999; i++)
        {
            string currSecretNumber = secretNumber;
            string currNumber = i.ToString();
            int currBulls = 0;
            for (int b = 0; b < 4; b++)
            {
                if (currNumber[b] == '0')
                {
                    currBulls = -1;
                    break;
                }
                else if (currNumber[b] == secretNumber[b])
                {
                    currBulls++;
                    currSecretNumber = currSecretNumber.Remove(b, 1).Insert(b, "*");
                    currNumber = currNumber.Remove(b, 1).Insert(b, "*");
                }
            }
            if (currBulls == bulls)
            {
                int currCows = 0;
                for (int c = 0; c < 4; c++)
                {
                    for (int n = 0; n < 4; n++)
                    {
                        if (c != n && currNumber[c] != '*' && currNumber[c] == currSecretNumber[n])
                        {
                            currCows++;
                            currSecretNumber = currSecretNumber.Remove(n, 1).Insert(n, "*");
                            currNumber = currNumber.Remove(c, 1).Insert(c, "*");
                        }
                    }
                }
                if (currCows == cows) result.Add(i);
            }
        }
        Console.WriteLine((result.Count != 0) ? String.Join(" ", result) : "No");
    }
}