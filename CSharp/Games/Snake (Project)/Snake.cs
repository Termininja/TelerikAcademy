using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Media;
using System.IO;

namespace SnakeTheGame
{
    /* Coordinates of any object */
    struct ObjectCordinates
    {
        public int col;                                             // x coordinate
        public int row;                                             // y coordinate
        public ObjectCordinates(int col, int row)
        {
            this.col = col;
            this.row = row;
        }
    }

    class SnakeTheGame
    {
        static Random Generator = new Random();                 // generator of random values
        static int maxLifes = 2;                                // bonus Life appears maximum 2 times for level
        static string snakeName = "";
        static double sleepTime = 0;                            // speed of the Snake!
        static int levelTime = 100000;                          // duration of the level (in ms)
        static string difficulty = "";
        static int lifeTime = 0;                                // timeout (in ms) for bonus Life
        static int bonusFoodTime = 0;
        static int pauseTime = 0;
        static int countLifes = 0;
        static SoundPlayer snd = new SoundPlayer();

        /* Moving Directions */
        static int[,] Directions = {
                                        { 1, 0 },               //Go in Right ">" Position
                                        { -1, 0 },              //Go in Left  "<" Position
                                        { 0, 1 },               //Go in Down  "v" Position
                                        { 0, -1 }               //Go in Top   "^" Position
                                    };

        static void Main()
        {
            WindowSize();
            Console.Title = new string(' ', 100) + "Snake - The Game :)";   // centered title text

            WelcomeScreen();                                                // WelcomeScreen

            DateTime gameStart = DateTime.Now;

            int scores = 0;                                                 // Current scores
            byte level = 1;                                                 // Current level;
            byte maxLevels = 20;                                            // Total Levels Count;
            byte lifes = 5;                                                 // Total lifes
            bool bonusLife = true;                                          // Bonus Life For The Level
            bool nextLevel = true;                                          // to go to the next level
            bool isBonusFood = false;
            bool isBonusLifePrinted = false;

            List<int[]> Snake = new List<int[]>();                          // Our snake
            List<int[]> Boss1 = new List<int[]>();                          // Boss snake 1
            List<int[]> Boss2 = new List<int[]>();                          // Boss snake 2

            int direction = 0;     //0 for Right-"^", 1 for Left-">", 2 for Down-"v", 3 for Up-"<"
            int bossDirection1 = 0;
            int bossDirection2 = 0;

            while (true)
            {
                if (level > maxLevels)
                {
                    YouWinScreen(snakeName, gameStart, scores);
                    break;
                }
                else
                {
                    StartCountDown(nextLevel, level);                       // CountDown;
                    switch (level)                                          // Schedule for each one level
                    {
                        case 1: Snake = StartSnake(4, 0, 2); direction = 0; break;
                        case 2: Snake = StartSnake(4, 92, 2); direction = 2; break;
                        case 3: Snake = StartSnake(4, 92, 2); direction = 2; break;
                        case 4: Snake = StartSnake(4, 92, 30); direction = 3; break;
                        case 5: Snake = StartSnake(4, 0, 30); direction = 3; break;
                        case 6: Snake = StartSnake(4, 0, 2); Boss1 = StartSnake(8, 6, 30); direction = 2; break;
                        case 7: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 6, 30); direction = 0; break;
                        case 8: Snake = StartSnake(4, 32, 30); Boss1 = StartSnake(8, 80, 30); direction = 3; break;
                        case 9: Snake = StartSnake(4, 32, 2); Boss1 = StartSnake(8, 60, 2); direction = 2; break;
                        case 10: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); direction = 0; break;
                        case 11: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 12: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 13: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 14: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 15: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 16: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 17: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 18: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 19: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        case 20: Snake = StartSnake(4, 32, 21); Boss1 = StartSnake(8, 80, 30); Boss2 = StartSnake(12, 70, 2); direction = 0; break;
                        default: break;
                    }
                }

                int mapStart = Environment.TickCount;                                   // the time when we start the Map
                int lastLifeTime = 0;

                Console.BackgroundColor = ConsoleColor.Black;                           // background color

                /* Generate some level map */
                string map = "maps/map " + level.ToString().PadLeft(2, '0') + ".txt";   //the path to map file
                MapVisualiser(map);

                /* Generate random food position */
                ObjectCordinates food = GenerateObject(map, Snake);

                /* Generate random BonusFood position */
                ObjectCordinates bonusFood = GenerateObject(map, Snake);

                /* Generate random life position */
                ObjectCordinates life = GenerateObject(map, Snake);
                lastLifeTime = Environment.TickCount;

                countLifes = 0;
                pauseTime = 0;

                int[] SnakeHead = new int[] { };
                int[] BossHead1 = new int[] { };
                int[] BossHead2 = new int[] { };

                bool bossSound1 = true;
                bool bossSound2 = true;

                while (Environment.TickCount - mapStart - pauseTime < levelTime)        // each one level
                {
                    Bar(snakeName, scores, mapStart, level, levelTime, lifes);

                    /* Our Snake */
                    {
                        direction = SnakeMove(direction);

                        /* Head of the Snake - Last element in the List */
                        SnakeHead = new int[] { Snake.Last()[0] + 2 * Directions[direction, 0], Snake.Last()[1] + Directions[direction, 1] };

                        /* When some BOSS eats our snake, the Snake eats itself or it is over the wall */
                        if (OverWallCheck(map, SnakeHead) ||
                            Snake.Any(x => x.SequenceEqual(SnakeHead)) ||
                            Snake.Any(x => x.SequenceEqual(BossHead1)) ||
                            Snake.Any(x => x.SequenceEqual(BossHead2)))
                        {
                            lifes--;
                            if (lifes == 0)                                             // if no more lifes
                            {
                                GameOverScreen(gameStart, scores, snakeName);
                                return;
                            }
                            else
                            {
                                using (MemoryStream death = new MemoryStream(File.ReadAllBytes("sound/die.wav")))
                                {
                                    SoundPlayer snakeDie = new SoundPlayer(death);
                                    snakeDie.Play();
                                }
                                Thread.Sleep(1000);
                            }
                            bossSound1 = true;
                            bossSound2 = true;
                            isBonusFood = false;
                            nextLevel = false;
                            bonusLife = true;
                            break;
                        }

                        /* That add element of our Snake - After Snake Head */
                        Snake.Add(SnakeHead);
                        PrintSnake(Snake, ConsoleColor.Gray);
                    }

                    /* Two BOSS Snakes with the same logic of movement */
                    {
                        /* The 1st BOSS */
                        if (Environment.TickCount - mapStart - pauseTime > 20000 && level > 5)        // appears in 20sec after level 5
                        {
                            if (bossSound1)
                            {
                                MemoryStream file1 = new MemoryStream(File.ReadAllBytes("sound/snake.wav"));
                                SoundPlayer boss1 = new SoundPlayer(file1);
                                boss1.Play();
                                bossSound1 = false;
                            }
                            BossHead1 = BOSS(Boss1, ref bossDirection1, map, SnakeHead, ConsoleColor.DarkRed);
                        }
                        /* The 2nd BOSS */
                        if (Environment.TickCount - mapStart - pauseTime > 40000 && level > 10)       // apprears in 40sec after level 10
                        {
                            if (bossSound2)
                            {
                                MemoryStream file2 = new MemoryStream(File.ReadAllBytes("sound/snake.wav"));
                                SoundPlayer boss2 = new SoundPlayer(file2);
                                boss2.Play();
                                bossSound2 = false;
                            }
                            BossHead2 = BOSS(Boss2, ref bossDirection2, map, SnakeHead, ConsoleColor.DarkCyan);
                        }
                    }

                    /* Food */
                    {
                        /* Snake - Behaviour With Food */
                        if (SnakeHead[0] == food.col && SnakeHead[1] == food.row)
                        {
                            try
                            {
                                using (MemoryStream pickup = new MemoryStream(File.ReadAllBytes("sound/food.wav")))
                                {
                                    SoundPlayer effect = new SoundPlayer(pickup);
                                    effect.Play();
                                }
                            }
                            catch
                            {
                                Console.Beep(100, 50);
                            }
                            scores += 100;
                            sleepTime -= 0.1;
                            Snake.Add(SnakeHead);
                            food = GenerateObject(map, Snake);
                        }
                        else
                        {
                            int[] last = Snake.ElementAt(0);

                            Snake.RemoveAt(0);     //That removes the end of the tail (1st element of the List)

                            Console.SetCursorPosition(last[0], last[1]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        PrintObject(food, '☻', ConsoleColor.Green);
                    }

                    /* Bonus Food */
                    {
                        if ((Environment.TickCount - mapStart - pauseTime) / 1000 == 20 ||
                            (Environment.TickCount - mapStart - pauseTime) / 1000 == 40 ||
                            (Environment.TickCount - mapStart - pauseTime) / 1000 == 60)
                        {
                            if ((lifes == 5) && (isBonusFood == false))
                            {
                                bonusFood = GenerateObject(map, Snake);
                                PrintObject(bonusFood, '♣', ConsoleColor.Cyan);
                                isBonusFood = true;
                            }
                        }

                        if ((Environment.TickCount - mapStart - pauseTime) / 1000 == (20 + bonusFoodTime) ||
                            (Environment.TickCount - mapStart - pauseTime) / 1000 == (40 + bonusFoodTime) ||
                            (Environment.TickCount - mapStart - pauseTime) / 1000 == (60 + bonusFoodTime))
                        {
                            Console.SetCursorPosition(bonusFood.col, bonusFood.row);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            bonusFood.col = 0;
                            bonusFood.row = 1;
                            Console.ResetColor();
                            isBonusFood = false;
                        }

                        if (SnakeHead[0] == bonusFood.col && SnakeHead[1] == bonusFood.row)
                        {
                            try
                            {
                                using (MemoryStream pickup = new MemoryStream(File.ReadAllBytes("sound/food-bonus.wav")))
                                {
                                    SoundPlayer effect = new SoundPlayer(pickup);
                                    effect.Play();
                                }

                            }
                            catch
                            {
                                Console.Beep(100, 50);
                            }
                            scores += 500;
                            sleepTime -= 0.2;
                            Snake.Add(SnakeHead);
                            Snake.Add(SnakeHead);
                            Snake.Add(SnakeHead);
                            bonusFood.col = 0;
                            bonusFood.row = 1;
                            isBonusFood = false;
                        }
                    }

                    /* Bonus Life */
                    {
                        /* Bonus Life schedule */
                        if (Environment.TickCount - lastLifeTime >= lifeTime && countLifes < 5 * maxLifes - 1)
                        {
                            if (countLifes % 5 == 1)
                            {
                                Console.SetCursorPosition(life.col, life.row);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                Console.ResetColor();
                                life.col = 0;
                                life.row = 1;
                                isBonusLifePrinted = false;
                            }
                            else
                            {
                                life = GenerateObject(map, Snake);
                                isBonusLifePrinted = false;
                            }
                            lastLifeTime = Environment.TickCount;
                            countLifes++;
                        }

                        /* Snake - Behaviour With Life */
                        if (SnakeHead[0] == life.col && SnakeHead[1] == life.row && isBonusLifePrinted == true)
                        {
                            try
                            {
                                using (MemoryStream pickup = new MemoryStream(File.ReadAllBytes("sound/life.wav")))
                                {
                                    SoundPlayer effect = new SoundPlayer(pickup);
                                    effect.Play();
                                }
                            }
                            catch
                            {
                                Console.Beep(100, 50);
                            }
                            if (lifes < 5)
                            {
                                lifes++;
                                bonusLife = false;
                            }
                            isBonusLifePrinted = false;
                        }

                        /* Life Print */
                        if (lifes != 5 && bonusLife == true && countLifes % 5 == 1 && countLifes < 5 * maxLifes - 1)
                        {
                            PrintObject(life, '♥', ConsoleColor.Red);
                            isBonusLifePrinted = true;
                        }
                    }

                    Thread.Sleep((int)sleepTime);   //sleeping time (in ms)
                    nextLevel = true;
                }

                if (nextLevel)
                {
                    level++;
                    bonusLife = false;
                }
            }
        }

        /* Sets the width and the height of the Console */
        static void WindowSize()
        {
            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 34;
        }

        /* The 1st welcome page in the game */
        static void WelcomeScreen()
        {
            MemoryStream background = new MemoryStream(File.ReadAllBytes("sound/intro.wav"));
            SoundPlayer music = new SoundPlayer(background);
            music.Play();
            Console.BackgroundColor = ConsoleColor.Black;                   // background color
            Console.ForegroundColor = ConsoleColor.Green;                   // foreground color
            Console.Clear();

            Console.SetCursorPosition(21, 6);
            Console.WriteLine(@"             _________              __                    ");
            Console.SetCursorPosition(21, 7);
            Console.WriteLine(@"            /   _____/ ____ _____  |  | __ ____           ");
            Console.SetCursorPosition(21, 8);
            Console.WriteLine(@"            \_____  \ /    \\__  \ |  |/ // __ \          ");
            Console.SetCursorPosition(21, 9);
            Console.WriteLine(@"            /        \   |  \/ __ \|    <\  ___/          ");
            Console.SetCursorPosition(21, 10);
            Console.WriteLine(@"           /_______  /___|  (____  /__|_ \\___ \          ");
            Console.SetCursorPosition(21, 11);
            Console.WriteLine(@"                   \/     \/     \/     \/    \/          ");
            Console.SetCursorPosition(21, 12);
            Console.WriteLine(@"___________.__             ________                       ");
            Console.SetCursorPosition(21, 13);
            Console.WriteLine(@"\__    ___/|  |__   ____  /  _____/_____    _____   ____  ");
            Console.SetCursorPosition(21, 14);
            Console.WriteLine(@"  |    |   |  |  \_/ __ \/   \  ___\__  \  /     \_/ __ \ ");
            Console.SetCursorPosition(21, 15);
            Console.WriteLine(@"  |    |   |   Y  \  ___/\    \_\  \/ __ \|  Y Y  \  ___/ ");
            Console.SetCursorPosition(21, 16);
            Console.WriteLine(@"  |____|   |___|  /\___ \ \______  (____  /__|_|  /\___ \ ");
            Console.SetCursorPosition(21, 17);
            Console.WriteLine(@"                \/     \/        \/     \/      \/     \/ ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(85, 32);
            Console.WriteLine("Created By:");
            Console.SetCursorPosition(80, 33);
            Console.WriteLine("\"Eek! the Cat\" TeAm");
            Console.ResetColor();

            try
            {
                StreamReader reader = new StreamReader("maps/map " + 1.ToString().PadLeft(2, '0') + ".txt");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(31, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Snake Name :  ");
                Console.SetCursorPosition(45, 22);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(min 1 letter - max 10 letters)");

                Console.SetCursorPosition(45, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                snakeName = ReadString(10);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(31, 24);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Difficulty :  ");
                Console.SetCursorPosition(45, 26);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(Type \"1\" for Easy, \"2\" for Medium, \"3\" for Hard)");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 24);
                string difficultInput = ReadString(1);
                long difficult;
                Console.ResetColor();

                while (!long.TryParse(difficultInput, out difficult) || difficult == 0 || difficult > 3 || difficult < 1)
                {
                    try
                    {
                        Console.SetCursorPosition(45, 24);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(new string(' ', 150));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(45, 24);
                        difficultInput = ReadString(1);
                        Console.ResetColor();
                    }
                    catch (Exception) { }
                }

                switch (difficult)
                {
                    case 1: sleepTime = 110; difficulty = "Easy"; lifeTime = 10000; bonusFoodTime = 10; break;
                    case 2: sleepTime = 90; difficulty = "Medium"; lifeTime = 8000; bonusFoodTime = 8; break;
                    case 3: sleepTime = 70; difficulty = "Hard"; lifeTime = 6000; bonusFoodTime = 6; break;
                    default: break;
                }
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(35, 23);
                Console.WriteLine("Sorry But You don't have Maps :(");
                Console.SetCursorPosition(99, 33);
                Console.ResetColor();

                Console.Beep(500, 200);
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            music.Stop();
            background.Close();
        }

        /* Reads string to given length */
        static string ReadString(byte limit)
        {
            string str = string.Empty;
            while (true)
            {
                char c = Console.ReadKey(true).KeyChar;
                if (c == '\r') break;
                if (c == '\b')
                {
                    if (str != "")
                    {
                        str = str.Substring(0, str.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (str.Length < limit)          // limit of digits
                {
                    Console.Write(c);
                    str += c;
                }
            }
            Console.WriteLine();
            return str;
        }

        /* Countdown timer screen used between levels */
        static void StartCountDown(bool nextLevel, int level)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.SetCursorPosition(99, 33);
            Thread.Sleep(600);

            for (int i = 3; i >= 0; i--)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();

                int height = 0;
                if (nextLevel)
                {
                    height = 7;
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (level == 1)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__     ____ ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   |");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   |");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   |");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___|");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/             ");
                    }
                    if (level == 2)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__    ________  ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   \_____  \ ");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    /  ____/ ");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__ /       \ ");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ \_______ \");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/               \/");
                    }
                    if (level == 3)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__    ________  ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   \_____  \ ");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |     _(__  < ");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  /       \");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ /______  /");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/              \/ ");
                    }
                    if (level == 4)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__       _____  ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |     /  |  | ");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    /   |  |_");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__ /    ^   /");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ \____   | ");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/            |__| ");
                    }
                    if (level == 5)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__     .________");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |    |   ____/");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |____  \ ");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  /       \");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ /______  /");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/              \/ ");
                    }
                    if (level == 6)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__      ________");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |    /  _____/");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |   /   __  \ ");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__ \  |__\  \");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  \_____  /");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/              \/ ");
                    }
                    if (level == 7)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__    _________ ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   \______  \");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |       /    /");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__    /    / ");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/   /____/  ");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/                 ");
                    }
                    if (level == 8)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__      ______  ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |    /  __  \ ");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    >      < ");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__ /   --   \");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ \______  /");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/              \/ ");
                    }
                    if (level == 9)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine(@".____                      .__     ________ ");
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /   __   \");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |   \____    /");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__    /    / ");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/   /____/  ");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine(@"        \/   \/          \/                 ");
                    }
                    if (level == 10)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ___________   ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   \   _  \  ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   /  /_\  \ ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   \  \_/   \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___|\_____  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                   \/ ");
                    }
                    if (level == 11)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____ ____ ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   /_   |");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   ||   |");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   ||   |");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___||___|");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                  ");
                    }
                    if (level == 12)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____________  ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   \_____  \ ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   |/  ____/ ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   /       \ ");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___\_______ \");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                    \/");
                    }
                    if (level == 13)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____________  ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   \_____  \ ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   | _(__  < ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   |/       \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___/______  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                   \/ ");
                    }
                    if (level == 14)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____   _____  ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   | /  |  | ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   |/   |  |_");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   /    ^   /");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___\____   | ");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                 |__| ");
                    }
                    if (level == 15)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____ .________");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   ||   ____/");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   ||____  \ ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   |/       \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___/______  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                   \/ ");
                    }
                    if (level == 16)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____  ________");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   |/  _____/");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   /   __  \ ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   \  |__\  \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___|\_____  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                   \/ ");
                    }
                    if (level == 17)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     _____________ ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   \______  \");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   |   /    /");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   |  /    / ");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___| /____/  ");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                      ");
                    }
                    if (level == 18)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____  ______  ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   |/  __  \ ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   |>      < ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   /   --   \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___\______  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                   \/ ");
                    }
                    if (level == 19)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__     ____ ________ ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   /_   /   __   \");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    |   \____    /");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__  |   |  /    / ");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/  |___| /____/  ");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/                      ");
                    }
                    if (level == 20)
                    {
                        Console.SetCursorPosition(26, 9);
                        Console.WriteLine(@".____                      .__    _______________   ");
                        Console.SetCursorPosition(26, 10);
                        Console.WriteLine(@"|    |    _______  __ ____ |  |   \_____  \   _  \  ");
                        Console.SetCursorPosition(26, 11);
                        Console.WriteLine(@"|    |  _/ __ \  \/ // __ \|  |    /  ____/  /_\  \ ");
                        Console.SetCursorPosition(26, 12);
                        Console.WriteLine(@"|    |__\  ___/\   /\  ___/|  |__ /       \  \_/   \");
                        Console.SetCursorPosition(26, 13);
                        Console.WriteLine(@"|_______ \___  >\_/  \___  >____/ \_______ \_____  /");
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine(@"        \/   \/          \/               \/     \/ ");
                    }

                    Console.SetCursorPosition(99, 33);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(1000);
                }

                Console.SetCursorPosition(99, 33);
                if (!nextLevel) Thread.Sleep(800);
                if (i == 3)
                {
                    try
                    {
                        using (MemoryStream tick = new MemoryStream(File.ReadAllBytes("sound/tick.wav")))
                        {
                            SoundPlayer ticks = new SoundPlayer(tick);
                            ticks.Play();
                        }
                    }
                    catch { Console.Beep(100, 250); }

                    Console.SetCursorPosition(45, 10 + height);
                    Console.WriteLine(@"________  ");
                    Console.SetCursorPosition(45, 11 + height);
                    Console.WriteLine(@"\_____  \ ");
                    Console.SetCursorPosition(45, 12 + height);
                    Console.WriteLine(@"  _(__  < ");
                    Console.SetCursorPosition(45, 13 + height);
                    Console.WriteLine(@" /       \");
                    Console.SetCursorPosition(45, 14 + height);
                    Console.WriteLine(@"/______  /");
                    Console.SetCursorPosition(45, 15 + height);
                    Console.WriteLine(@"       \/ ");
                }
                if (i == 2)
                {
                    try
                    {
                        using (MemoryStream tick = new MemoryStream(File.ReadAllBytes("sound/tick.wav")))
                        {
                            SoundPlayer ticks = new SoundPlayer(tick);
                            ticks.Play();
                        }
                    }
                    catch { Console.Beep(200, 250); }

                    Console.SetCursorPosition(45, 10 + height);
                    Console.WriteLine(@"________  ");
                    Console.SetCursorPosition(45, 11 + height);
                    Console.WriteLine(@"\_____  \ ");
                    Console.SetCursorPosition(45, 12 + height);
                    Console.WriteLine(@" /  ____/ ");
                    Console.SetCursorPosition(45, 13 + height);
                    Console.WriteLine(@"/       \ ");
                    Console.SetCursorPosition(45, 14 + height);
                    Console.WriteLine(@"\_______ \");
                    Console.SetCursorPosition(45, 15 + height);
                    Console.WriteLine(@"        \/");
                }
                if (i == 1)
                {
                    try
                    {
                        using (MemoryStream tick = new MemoryStream(File.ReadAllBytes("sound/tick.wav")))
                        {
                            SoundPlayer ticks = new SoundPlayer(tick);
                            ticks.Play();
                        }
                    }
                    catch { Console.Beep(300, 250); }

                    Console.SetCursorPosition(45, 10 + height);
                    Console.WriteLine(@" ____ ");
                    Console.SetCursorPosition(45, 11 + height);
                    Console.WriteLine(@"/_   |");
                    Console.SetCursorPosition(45, 12 + height);
                    Console.WriteLine(@" |   |");
                    Console.SetCursorPosition(45, 13 + height);
                    Console.WriteLine(@" |   |");
                    Console.SetCursorPosition(45, 14 + height);
                    Console.WriteLine(@" |___|");
                }
                if (i == 0)
                {
                    try
                    {
                        using (MemoryStream tick = new MemoryStream(File.ReadAllBytes("sound/tick.wav")))
                        {
                            SoundPlayer ticks = new SoundPlayer(tick);
                            ticks.Play();
                        }
                    }
                    catch { Console.Beep(400, 250); }

                    Console.SetCursorPosition(30, 10 + height);
                    Console.WriteLine(@"           __                        __   ");
                    Console.SetCursorPosition(30, 11 + height);
                    Console.WriteLine(@"  ______ _/  |_  _____    _______  _/  |_ ");
                    Console.SetCursorPosition(30, 12 + height);
                    Console.WriteLine(@" /  ___/ \   __\ \__  \   \_  __ \ \   __\");
                    Console.SetCursorPosition(30, 13 + height);
                    Console.WriteLine(@" \___ \   |  |    / __ \_  |  | \/  |  |  ");
                    Console.SetCursorPosition(30, 14 + height);
                    Console.WriteLine(@"/____  >  |__|   (____  /  |__|     |__|  ");
                    Console.SetCursorPosition(30, 15 + height);
                    Console.WriteLine(@"     \/               \/                  ");
                }
                Thread.Sleep(500);
            }
            Thread.Sleep(600);
            Console.Clear();
            Console.ResetColor();
        }

        /* Prints different map for each one level */
        static void MapVisualiser(string map)
        {
            StreamReader reader = new StreamReader(map);
            using (reader)
            {
                string line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(line);
                }
            }
        }

        /* Start position of the snake */
        static List<int[]> StartSnake(int snakeLenght, int x, int y)        // snakeLenght has to be even number!
        {
            List<int[]> Snake = new List<int[]>();
            for (int i = 0; i <= snakeLenght - 1; i++)
            {
                Snake.Add(new int[] { x + i, y });
            }
            return Snake;
        }

        /* That change "movingDirection" value so that set the course of Snake */
        static int SnakeMove(int movingDirection)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            if (Console.KeyAvailable)
            {
                /* User input moving Key */
                ConsoleKeyInfo UserInput = Console.ReadKey();

                while (Console.KeyAvailable) Console.ReadKey();             // for fluent moving

                /* Change moving direction */
                switch (UserInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (movingDirection != 1) movingDirection = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (movingDirection != 0) movingDirection = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (movingDirection != 3) movingDirection = 2;
                        break;
                    case ConsoleKey.UpArrow:
                        if (movingDirection != 2) movingDirection = 3;
                        break;
                    case ConsoleKey.Spacebar:
                        int pauseStart = Environment.TickCount;
                        Console.ReadKey();
                        pauseTime += Environment.TickCount - pauseStart;
                        break;
                    default:
                        break;
                }
            }
            return movingDirection;
        }

        /* That print the elements of our Snake */
        static void PrintSnake(List<int[]> Snake, ConsoleColor color)
        {
            for (int i = 0; i < Snake.Count; i++)
            {
                Console.SetCursorPosition(Snake.ElementAt(i)[0], Snake.ElementAt(i)[1]);
                if (i == Snake.Count - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.ForegroundColor = color;
                    Console.BackgroundColor = color;
                }
                Console.Write("██");
                Console.ResetColor();
            }
        }

        /* Generate random position of some object */
        static ObjectCordinates GenerateObject(string map, List<int[]> Snake)
        {
            ObjectCordinates obj;

            /* Generates a new object if coordinates are the same like these of the Snake or the wall */
            do
            {
                obj = new ObjectCordinates(Generator.Next(0, Console.WindowWidth - 2), Generator.Next(1, Console.WindowHeight));
                if (obj.col % 2 == 0) obj.col += 1;
            }
            while (Snake.Any(x => x.SequenceEqual(new int[] { obj.col, obj.row })) || OverWallCheck(map, new int[] { obj.col, obj.row }));
            return obj;
        }

        /* Prints some generated object */
        static void PrintObject(ObjectCordinates obj, char sym, ConsoleColor col)
        {
            Console.SetCursorPosition(obj.col, obj.row);
            Console.ForegroundColor = col;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(sym);
            Console.ResetColor();
        }

        /* Moves the snake to opposite side of the screen */
        static void BorderCheck(int[] head)
        {
            if (head[0] < 0) head[0] = Console.WindowWidth - 3;
            if (head[0] >= Console.WindowWidth - 1) head[0] = 1;
            if (head[1] < 1) head[1] = Console.WindowHeight - 1;
            if (head[1] >= Console.WindowHeight) head[1] = 1;
        }

        /* If some element is over the wall */
        static bool OverWallCheck(string map, int[] head)
        {
            BorderCheck(head);
            StreamReader reader = new StreamReader(map);
            using (reader)
            {
                string line = "";
                int textFileRow = 0;
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (textFileRow == head[1] && line[head[0]] != ' ')
                    {
                        return true;
                    }
                    textFileRow++;
                }
            }
            return false;
        }

        /* Bar on 1st line in the game with some values about the current level */
        static void Bar(string name, int scores, int mapStart, byte level, int levelTime, int lifes)
        {
            Console.SetCursorPosition(0, 0);
            BarField(name, "Name: ", ConsoleColor.Green, 7);
            BarField(scores, "Score: ", ConsoleColor.Green, 6);
            BarField((levelTime - (Environment.TickCount - mapStart - pauseTime)) / 1000, "Next map in: ", ConsoleColor.Green, 4);
            BarField(level, " Level: ", ConsoleColor.Green, 5);
            BarField(new string('♥', lifes), " Lives: ", ConsoleColor.Red, 5);
        }

        /* Used in the bar for each one value */
        static void BarField(dynamic variable, string text, ConsoleColor color, byte n)
        {
            int space = n - variable.ToString().Length / 2;
            int equalizer = 0;
            if (variable.ToString().Length % 2 != 0)
            {
                equalizer = 1;
            }

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string(' ', space) + text);

            Console.ForegroundColor = color;
            Console.Write(variable + new string(' ', space - equalizer));

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("█");
            Console.ResetColor();
        }

        /* Creates another bad snake (The boss)*/
        static int[] BOSS(List<int[]> Boss, ref int bossDirection, string map, int[] SnakeHead, ConsoleColor color)
        {
            int[] BossHead;

            /* Boss Snake */
            {
                BossHead = new int[] { Boss.Last()[0] + 2 * Directions[bossDirection, 0], Boss.Last()[1] + Directions[bossDirection, 1] };

                bossDirection = BossMove(Boss, bossDirection, map, SnakeHead, BossHead);

                BorderCheck(BossHead);
                Boss.Add(BossHead);
                PrintSnake(Boss, color);
                Console.SetCursorPosition(Boss.ElementAt(0)[0], Boss.ElementAt(0)[1]);
                Boss.RemoveAt(0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.ResetColor();
            }
            return BossHead;
        }

        /* Logic for movement of some Boss snake */
        static int BossMove(List<int[]> Boss, int direction, string map, int[] SnakeHead, int[] BossHead)
        {
            if (OverWallCheck(map, BossHead))
            {
                switch (direction)
                {
                    case 0:
                        BossHead[0] -= 2; BossHead[1] -= 1; direction = 3;
                        if (OverWallCheck(map, BossHead))
                        {
                            BossHead[1] += 2; direction = 2;
                        }
                        break;
                    case 1:
                        BossHead[0] += 2; BossHead[1] -= 1; direction = 3;
                        if (OverWallCheck(map, BossHead))
                        {
                            BossHead[1] += 2; direction = 2;
                        }
                        break;
                    case 2:
                        BossHead[1] -= 1; BossHead[0] -= 2; direction = 1;
                        if (OverWallCheck(map, BossHead))
                        {
                            BossHead[0] += 4; direction = 0;
                        }
                        break;
                    case 3:
                        BossHead[1] += 1; BossHead[0] -= 2; direction = 1;
                        if (OverWallCheck(map, BossHead))
                        {
                            BossHead[0] += 4; direction = 0;
                        }
                        break;
                    default: break;
                }
            }
            else
            {
                BossTurning(Boss, direction, BossHead);             // is the Boos behind our Snake 

                int tempDir = direction;

                /*  Generates directoin for BossSnake
                 *    
                 *        0     - position of our Snake
                 *        1-8   - position of BossSnake
                 * 
                 *       ┌─────────┬─────┬─────────┐
                 *       │         │     │         │
                 *       │    1 >  │  5  │    2    │
                 *       │         │  v  │    v    │
                 *       ├─────────┼─────┼─────────┤
                 *       │    6  > │  0  │  < 7    │
                 *       ├─────────┼─────┼─────────┤
                 *       │    ^    │  ^  │         │
                 *       │    3    │  8  │  < 4    │
                 *       │         │     │         │
                 *       └─────────┴─────┴─────────┘
                 */

                if (BossHead[0] > SnakeHead[0])
                {
                    if (BossHead[1] < SnakeHead[1])
                    {
                        if (direction != 3)
                        {
                            direction = 2;                      // Quadrant 2: take direction 2 (down)
                        }
                    }
                    else                                        // Quadrant 4 & 7: take direction 1 (left)
                    {
                        if (direction != 0)
                        {
                            direction = 1;
                        }
                        else
                        {
                            direction = 3;
                        }
                    }
                }
                else if (BossHead[0] < SnakeHead[0])
                {
                    if (BossHead[1] > SnakeHead[1])
                    {
                        if (direction != 2)
                        {
                            direction = 3;                      // Quadrant 3: take direction 3 (up)
                        }
                    }
                    else                                        // Quadrant 1 & 6: take direction 0 (right)
                    {
                        if (direction != 1)
                        {
                            direction = 0;
                        }
                        else
                        {
                            direction = 2;
                        }
                    }
                }
                else
                {
                    if (BossHead[1] < SnakeHead[1])             // Quadrant 5: take direction 2 (down)
                    {
                        if (direction != 3)
                        {
                            direction = 2;
                        }
                        else
                        {
                            direction = 1;
                        }
                    }
                    else if (BossHead[1] > SnakeHead[1])        // Quadrant 8: take direction 3 (up)
                    {
                        if (direction != 2)
                        {
                            direction = 3;
                        }
                        else
                        {
                            direction = 0;
                        }
                    }
                }

                if (OverWallCheck(map, new int[] { Boss.Last()[0] + 2 * Directions[direction, 0],
                                                   Boss.Last()[1] + Directions[direction, 1] }))
                {
                    return tempDir;
                }
                else
                {
                    return direction;
                }
            }
            return direction;
        }

        /* How Boss snake to turn back */
        static void BossTurning(List<int[]> snake, int direction, int[] head)
        {
            if (snake.Any(x => x.SequenceEqual(head)))
            {
                switch (direction)
                {
                    case 0:
                        head[0] -= 2; head[1] -= 1; direction = 3;
                        if (snake.Any(x => x.SequenceEqual(head)))
                        {
                            head[1] += 2; direction = 2;
                        }
                        break;
                    case 1:
                        head[0] += 2; head[1] -= 1; direction = 3;
                        if (snake.Any(x => x.SequenceEqual(head)))
                        {
                            head[1] += 2; direction = 2;
                        }
                        break;
                    case 2:
                        head[1] -= 1; head[0] -= 2; direction = 1;
                        if (snake.Any(x => x.SequenceEqual(head)))
                        {
                            head[0] += 4; direction = 0;
                        }
                        break;
                    case 3:
                        head[1] += 1; head[0] -= 2; direction = 1;
                        if (snake.Any(x => x.SequenceEqual(head)))
                        {
                            head[0] += 4; direction = 0;
                        }
                        break;
                    default: break;
                }
            }
        }

        /* Final screen if we loose the game */
        static void GameOverScreen(DateTime gameStart, int totalScores, string snakeName)
        {
            DateTime gameEnd = DateTime.Now;
            using (MemoryStream music = new MemoryStream(File.ReadAllBytes("sound/gameover.wav")))
            {
                snd = new SoundPlayer(music);
                snd.Play();
            }
            Thread.Sleep(1000);                                 // sleep for 1 second when we die

            ScoresRecord(gameStart, totalScores, snakeName, gameEnd);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(22, 8);
            Console.WriteLine(@"  ________                           _____                     ");
            Console.SetCursorPosition(22, 9);
            Console.WriteLine(@" /  _____/_____    _____   ____     /  _  \___  __ ___________ ");
            Console.SetCursorPosition(22, 10);
            Console.WriteLine(@"/   \  ___\__  \  /     \_/ __ \   /  /|   \  \/ // __ \_  __ \");
            Console.SetCursorPosition(22, 11);
            Console.WriteLine(@"\    \_\  \/ __ \|  Y Y  \  ___/  /  /_|    \   /\  ___/|  | \/");
            Console.SetCursorPosition(22, 12);
            Console.WriteLine(@" \______  (____  /__|_|  /\___ \  \_______  /\_/  \___ \|__|   ");
            Console.SetCursorPosition(22, 13);
            Console.WriteLine(@"        \/     \/      \/     \/          \/          \/       ");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(31, 18);
            Console.WriteLine("Your play time: {0:mm} minutes and {0:ss} seconds", gameEnd - gameStart, gameEnd - gameStart);
            Console.SetCursorPosition(31, 20);
            Console.WriteLine("Scores: {0} Points", totalScores.ToString());

            Console.SetCursorPosition(38, 25);
            Console.WriteLine("Press Any Key for Exit");
            Console.SetCursorPosition(99, 33);
            Console.ResetColor();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Environment.Exit(0);
                }
            }
        }

        /* Final screen if we win the game */
        static void YouWinScreen(string snakeName, DateTime gameStart, int totalScores)
        {
            DateTime gameEnd = DateTime.Now;
            using (MemoryStream music = new MemoryStream(File.ReadAllBytes("sound/intro.wav")))
            {
                snd = new SoundPlayer(music);
                snd.Play();
            }
            ScoresRecord(gameStart, totalScores, snakeName, gameEnd);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(22, 8);
            Console.WriteLine(@"_____.___.               __      __.__         ._. ._. ._.");
            Console.SetCursorPosition(22, 9);
            Console.WriteLine(@"\__  |   | ____  __ __  /  \    /  \__| ____   | | | | | |");
            Console.SetCursorPosition(22, 10);
            Console.WriteLine(@" /   |   |/  _ \|  |  \ \   \/\/   /  |/    \  | | | | | |");
            Console.SetCursorPosition(22, 11);
            Console.WriteLine(@" \____   (  <_> )  |  /  \        /|  |   |  \  \|  \|  \|");
            Console.SetCursorPosition(22, 12);
            Console.WriteLine(@" / ______|\____/|____/    \__/\  / |__|___|  /  __  __  __");
            Console.SetCursorPosition(22, 13);
            Console.WriteLine(@" \/                            \/          \/   \/  \/  \/");

            Console.SetCursorPosition(31, 18);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Your play time: {0:mm} minutes and {0:ss} seconds", gameEnd - gameStart, gameEnd - gameStart);
            Console.SetCursorPosition(31, 20);
            Console.WriteLine("Scores: {0} Points", totalScores.ToString());

            Console.SetCursorPosition(38, 25);
            Console.WriteLine("Press Any Key for Exit");
            Console.SetCursorPosition(99, 33);
            Console.ResetColor();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Environment.Exit(0);
                }
            }
        }

        /* Save the result from the game in statistics file */
        static void ScoresRecord(DateTime gameStart, int totalScores, string snakeName, DateTime gameEnd)
        {
            string rankListName = "";

            switch (difficulty)
            {
                case "Easy": rankListName = "RankList - Easy.txt"; break;
                case "Medium": rankListName = "RankList - Medium.txt"; break;
                case "Hard": rankListName = "RankList - Hard.txt"; break;
                default: break;
            }

            StreamWriter curentGameResultWriter = new StreamWriter(rankListName, true);
            using (curentGameResultWriter)
            {
                curentGameResultWriter.WriteLine("{0} - {1} - {2}", totalScores, gameEnd - gameStart, snakeName);
            }
        }
    }
}