using System;
 
class Poker
{
    static void Main()
    {
        int[] MyCards = new int[5];
        int[] Counts = new int[13];
 
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;
        int count7 = 0;
        int count8 = 0;
        int count9 = 0;
        int count10 = 0;
        int countJ = 0;
        int countQ = 0;
        int countK = 0;
        int countA = 0;
 
        for (int i = 0; i < 5; i++)
        {
            switch (Console.ReadLine())
            {
                case "2": MyCards[i] = 2; count2++; Counts[0] = count2; break;
                case "3": MyCards[i] = 3; count3++; Counts[1] = count3; break;
                case "4": MyCards[i] = 4; count4++; Counts[2] = count4; break;
                case "5": MyCards[i] = 5; count5++; Counts[3] = count5; break;
                case "6": MyCards[i] = 6; count6++; Counts[4] = count6; break;
                case "7": MyCards[i] = 7; count7++; Counts[5] = count7; break;
                case "8": MyCards[i] = 8; count8++; Counts[6] = count8; break;
                case "9": MyCards[i] = 9; count9++; Counts[7] = count9; break;
                case "10": MyCards[i] = 10; count10++; Counts[8] = count10; break;
                case "J": MyCards[i] = 11; countJ++; Counts[9] = countJ; break;
                case "Q": MyCards[i] = 12; countQ++; Counts[10] = countQ; break;
                case "K": MyCards[i] = 13; countK++; Counts[11] = countK; break;
                case "A": MyCards[i] = 14; countA++; Counts[12] = countA; break;
                default: break;
            }
        }
        Array.Sort(MyCards);
        Array.Sort(Counts);
 
        if (Counts[12] == 5)
        {
            Console.WriteLine("Impossible");
        }
        else if (Counts[12] == 4 ||
            count8 == 4 || count9 == 4 || count10 == 4 || countJ == 4 || countQ == 4 || countK == 4 || countA == 4)
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (Counts[12] == 3 && Counts[11] == 2)
        {
            Console.WriteLine("Full House");
        }
        else if ((MyCards[0] == 2 && MyCards[1] == 11 && MyCards[2] == 12 && MyCards[3] == 13 && MyCards[4] == 14) ||
                 (MyCards[0] == 2 && MyCards[1] == 3 && MyCards[2] == 12 && MyCards[3] == 13 && MyCards[4] == 14) ||
                 (MyCards[0] == 2 && MyCards[1] == 3 && MyCards[2] == 4 && MyCards[3] == 13 && MyCards[4] == 14) ||
                 (MyCards[0] == 2 && MyCards[1] == 3 && MyCards[2] == 4 && MyCards[3] == 5 && MyCards[4] == 14) ||
                 (MyCards[0] == MyCards[1] - 1 && MyCards[1] == MyCards[2] - 1 && MyCards[2] == MyCards[3] - 1 && MyCards[3] == MyCards[4] - 1))
        {
            Console.WriteLine("Straight");
        }
        else if (Counts[12] == 3)
        {
            Console.WriteLine("Three of a Kind");
        }
        else if (Counts[12] == 2 && Counts[11] == 2)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (Counts[12] == 2)
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}