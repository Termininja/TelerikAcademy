//Task 11: Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
//         The cards should be printed with their English names. Use nested for loops and switch-case.

using System;
using System.Threading;

class CardNames
{
    static void Suits(string name, byte s, string i)
    {
        string[] Suit = { "spades   ", "hearts   ", "diamonds ", "clubs    ", "♠ ", "♥ ", "♦ ", "♣ " };
        Console.Write("{0} of {1}", name, Suit[s]);                         // the names of the cards
        switch (s)                                                          // the colors of suits
        {
            case 1: Console.ForegroundColor = ConsoleColor.Red; break;
            case 2: Console.ForegroundColor = ConsoleColor.Red; break;
            default: Console.ForegroundColor = ConsoleColor.Black; break;
        }
        Console.WriteLine("{0}{1}", i, Suit[s + 4]);                        // card figures       
        Console.ForegroundColor = ConsoleColor.Black;
    }

    static void Main()
    {
        Console.WindowWidth = 95;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        for (byte s = 0; s < 4; s++)                                        // loop for each one suit
        {
            for (byte i = 2; i <= 14; i++)                                  // loop for each one card
            {
                switch (s)                                                  // position of the name
                {
                    case 0: Console.SetCursorPosition(2, i - 1); break;     // for spades
                    case 1: Console.SetCursorPosition(25, i - 1); break;    // for hearts
                    case 2: Console.SetCursorPosition(48, i - 1); break;    // for diamonds
                    case 3: Console.SetCursorPosition(71, i - 1); break;    // for clubs
                }
                switch (i)                                                  // the names
                {
                    case 2: Suits(" Two", s, "  2"); break;
                    case 3: Suits(" Three", s, "3"); break;
                    case 4: Suits(" Four", s, " 4"); break;
                    case 5: Suits(" Five", s, " 5"); break;
                    case 6: Suits(" Six", s, "  6"); break;
                    case 7: Suits(" Seven", s, "7"); break;
                    case 8: Suits(" Eight", s, "8"); break;
                    case 9: Suits(" Nine", s, " 9"); break;
                    case 10: Suits(" Ten", s, " 10"); break;
                    case 11: Suits(" Jack", s, " J"); break;
                    case 12: Suits(" Queen", s, "Q"); break;
                    case 13: Suits(" King", s, " K"); break;
                    case 14: Suits(" Ace", s, "  A"); break;
                }
            }
        }
        Console.ResetColor();
    }
}