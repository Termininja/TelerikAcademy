// Task 4. Refactor and improve the naming in the current C# source project.
// You are allowed to make other improvements in the code as well
// (not only naming) as well as to fix bugs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class MinesweeperGame
    {
        public class Point
        {
            public Point(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name { get; set; }
            public int Points { get; set; }
        }

        static void Main()
        {
            string command = string.Empty;
            char[,] board = CreateBoard();
            char[,] bombs = LoadBombs();
            int counter = 0;
            bool grum = false;
            List<Point> winners = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool flag = true;
            const int maks = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Let's play “Mines”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    dumpp(board);
                    flag = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        Ranking(winners);
                        break;
                    case "restart":
                        board = CreateBoard();
                        bombs = LoadBombs();
                        dumpp(board);
                        grum = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                tisinahod(board, bombs, row, col);
                                counter++;
                            }
                            if (maks == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                dumpp(board);
                            }
                        }
                        else
                        {
                            grum = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }
                if (grum)
                {
                    dumpp(bombs);
                    Console.Write("\nYou are dead! Your points are {0}. " +
                        "Enter your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Point t = new Point(nickname, counter);
                    if (winners.Count < 5)
                    {
                        winners.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < t.Points)
                            {
                                winners.Insert(i, t);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }
                    winners.Sort((Point r1, Point r2) => r2.Name.CompareTo(r1.Name));
                    winners.Sort((Point r1, Point r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(winners);

                    board = CreateBoard();
                    bombs = LoadBombs();
                    counter = 0;
                    grum = false;
                    flag = true;
                }
                if (flag2)
                {
                    Console.WriteLine("\nCongratulations! You win!");
                    dumpp(bombs);
                    Console.WriteLine("Enter your name: ");
                    string imeee = Console.ReadLine();
                    Point to4kii = new Point(imeee, counter);
                    winners.Add(to4kii);
                    Ranking(winners);
                    board = CreateBoard();
                    bombs = LoadBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void Ranking(List<Point> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, to4kii[i].Name, to4kii[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void tisinahod(char[,] board,
            char[,] BOMBI, int row, int col)
        {
            char kolkoBombi = kolko(BOMBI, row, col);
            BOMBI[row, col] = kolkoBombi;
            board[row, col] = kolkoBombi;
        }

        private static void dumpp(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] LoadBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int kol = (i2 / cols);
                int red = (i2 % cols);
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = cols;
                }
                else
                {
                    red++;
                }
                board[kol, red - 1] = '*';
            }

            return board;
        }

        private static void smetki(char[,] pole)
        {
            int col = pole.GetLength(0);
            int row = pole.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = kolko(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char kolko(char[,] bombs, int row, int col)
        {
            int count = 0;
            int rows = bombs.GetLength(0);
            int cols = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (bombs[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (bombs[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (bombs[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (bombs[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}
