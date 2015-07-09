// Task 4. Refactor and improve the naming in the current C# source project.
// You are allowed to make other improvements in the code as well
// (not only naming) as well as to fix bugs.

using System;
using System.Collections.Generic;

namespace MinesweeperGame
{
    public class Minesweeper
    {
        public static void Main()
        {
            const int AllCells = 35;

            var winners = new List<Player>(6);
            var command = string.Empty;
            var board = LoadBoard();
            var bombs = LoadBombs();
            var isGameOver = false;
            var isStart = true;
            var areAllCellsOpen = false;
            var openCellCounter = 0;
            var row = 0;
            var col = 0;

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
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", openCellCounter);
                    var nickname = Console.ReadLine();
                    var player = new Player(nickname, openCellCounter);
                    if (winners.Count < 5)
                    {
                        winners.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < player.Points)
                            {
                                winners.Insert(i, player);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    winners.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
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
                    var name = Console.ReadLine();
                    var player = new Player(name, openCellCounter);
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
            }
            else
            {
                Console.WriteLine("prazna klasaciq!");
            }

            Console.WriteLine();
        }

        private static void YourTurn(char[,] board, char[,] bombs, int row, int col)
        {
            var bombCount = CountBombs(bombs, row, col);
            bombs[row, col] = bombCount;
            board[row, col] = bombCount;
        }

        private static void PrintBoard(char[,] board)
        {
            var rows = board.GetLength(0);
            var cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] LoadBoard()
        {
            var boardRows = 5;
            var boardColumns = 10;
            var board = new char[boardRows, boardColumns];
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
            var rows = 5;
            var cols = 10;
            var board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            var randomListNumbers = new List<int>();
            while (randomListNumbers.Count < 15)
            {
                var randomGenerator = new Random();
                var number = randomGenerator.Next(50);
                if (!randomListNumbers.Contains(number))
                {
                    randomListNumbers.Add(number);
                }
            }

            foreach (int number in randomListNumbers)
            {
                var col = (number / cols);
                var row = (number % cols);
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
            var cols = board.GetLength(0);
            var rows = board.GetLength(1);

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
            var count = 0;
            var rows = bombs.GetLength(0);
            var cols = bombs.GetLength(1);

            if (row - 1 >= 0 && bombs[row - 1, col] == '*')
            {
                count++;
            }

            if (row + 1 < rows && bombs[row + 1, col] == '*')
            {
                count++;
            }

            if (col - 1 >= 0 && bombs[row, col - 1] == '*')
            {
                count++;
            }

            if (col + 1 < cols && bombs[row, col + 1] == '*')
            {
                count++;
            }

            if ((row - 1 >= 0) && (col - 1 >= 0) && bombs[row - 1, col - 1] == '*')
            {
                count++;
            }

            if ((row - 1 >= 0) && (col + 1 < cols) && bombs[row - 1, col + 1] == '*')
            {
                count++;
            }

            if ((row + 1 < rows) && (col - 1 >= 0) && bombs[row + 1, col - 1] == '*')
            {
                count++;
            }

            if ((row + 1 < rows) && (col + 1 < cols) && bombs[row + 1, col + 1] == '*')
            {
                count++;
            }

            return char.Parse(count.ToString());
        }
    }
}