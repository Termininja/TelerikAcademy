// Task 4. Refactor and improve the naming in the current C# source project.
// You are allowed to make other improvements in the code as well
// (not only naming) as well as to fix bugs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperGame
{
    public class Minesweeper
    {
        public class Player
        {
            public Player(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name { get; set; }
            public int Points { get; set; }
        }

        static void Main()
        {
            List<Player> winners = new List<Player>(6);
            string command = string.Empty;
            char[,] board = LoadBoard();
            char[,] bombs = LoadBombs();
            bool isGameOver = false;
            bool isStart = true;
            bool areAllCellsOpen = false;
            int openCellCounter = 0;
            int row = 0;
            int col = 0;
            const int AllCells = 35;

            do
            {
                if (isStart)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                  " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(board);
                    isStart = false;
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
                        board = LoadBoard();
                        bombs = LoadBombs();
                        PrintBoard(board);
                        isGameOver = false;
                        isStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                YourTurn(board, bombs, row, col);
                                openCellCounter++;
                            }
                            if (AllCells == openCellCounter)
                            {
                                areAllCellsOpen = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }
                if (isGameOver)
                {
                    PrintBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", openCellCounter);
                    string nickname = Console.ReadLine();
                    Player t = new Player(nickname, openCellCounter);
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
                    winners.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    winners.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(winners);

                    board = LoadBoard();
                    bombs = LoadBombs();
                    openCellCounter = 0;
                    isGameOver = false;
                    isStart = true;
                }
                if (areAllCellsOpen)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, openCellCounter);
                    winners.Add(player);
                    Ranking(winners);
                    board = LoadBoard();
                    bombs = LoadBombs();
                    openCellCounter = 0;
                    areAllCellsOpen = false;
                    isStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Ranking(List<Player> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void YourTurn(char[,] board, char[,] bombs, int row, int col)
        {
            char bombCount = CountBombs(bombs, row, col);
            bombs[row, col] = bombCount;
            board[row, col] = bombCount;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] LoadBoard()
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

            List<int> randomListNumbers = new List<int>();
            while (randomListNumbers.Count < 15)
            {
                Random randomGenerator = new Random();
                int number = randomGenerator.Next(50);
                if (!randomListNumbers.Contains(number))
                {
                    randomListNumbers.Add(number);
                }
            }

            foreach (int number in randomListNumbers)
            {
                int col = (number / cols);
                int row = (number % cols);
                if (row == 0 && number != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void GetBombsCount(char[,] board)
        {
            int cols = board.GetLength(0);
            int rows = board.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (board[i, j] != '*')
                    {
                        board[i, j] = CountBombs(board, i, j);
                    }
                }
            }
        }

        private static char CountBombs(char[,] bombs, int row, int col)
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
