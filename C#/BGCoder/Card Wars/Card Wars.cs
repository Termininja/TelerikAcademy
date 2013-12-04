using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        BigInteger PlayerAScore = 0;
        BigInteger PlayerBScore = 0;
        int gameAWon = 0;
        int gameBWon = 0;
        int XinA = 0;
        int XinB = 0;

        for (int g = 0; g < N; g++)
        {
            int handStrengthA = 0;
            int handStrengthB = 0;
            PlayerAScore = Game(PlayerAScore, ref handStrengthA, ref XinA);
            PlayerBScore = Game(PlayerBScore, ref handStrengthB, ref XinB);

            if (XinA > 0 || XinB > 0)
            {
                if (XinA == XinB)
                {
                    PlayerAScore += 50;
                    PlayerBScore += 50;
                    XinA = 0;
                    XinB = 0;
                }
                else
                {
                    if (XinA > XinB) Console.WriteLine("X card drawn! Player one wins the match!");
                    if (XinA < XinB) Console.WriteLine("X card drawn! Player two wins the match!");
                    break;
                }
            }
            if (handStrengthA > handStrengthB)
            {
                gameAWon++;
                PlayerAScore += handStrengthA;
            }
            else if (handStrengthA < handStrengthB)
            {
                gameBWon++;
                PlayerBScore += handStrengthB;
            }
        }

        if (XinA == 0 && XinB == 0)
        {
            if (PlayerAScore > PlayerBScore)
            {
                Console.WriteLine(
                    "First player wins!\nScore: {0}\nGames won: {1}",
                    PlayerAScore, gameAWon);
            }
            else if (PlayerAScore < PlayerBScore)
            {
                Console.WriteLine(
                    "Second player wins!\nScore: {0}\nGames won: {1}",
                    PlayerBScore, gameBWon);
            }
            else Console.WriteLine("It's a tie!\nScore: {0}", PlayerAScore);
        }
    }

    private static BigInteger Game(BigInteger PlayerScore, ref int handStrength, ref int X)
    {
        for (int c = 0; c < 3; c++)
        {
            string card = Console.ReadLine();
            if (card == "Z") PlayerScore *= 2;
            else if (card == "Y") PlayerScore -= 200;
            else if (card == "X") X++;
            else handStrength += CardStrength(card);
        }
        return PlayerScore;
    }

    private static int CardStrength(string card)
    {
        string[] cards = { "A", "10", "9", "8", "7", "6", "5", "4", "3", "2", "J", "Q", "K" };
        return Array.IndexOf(cards, card) + 1;
    }
}