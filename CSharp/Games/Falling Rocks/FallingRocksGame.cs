//Task 11*: Implement the "Falling Rocks" game in the text console.
//          A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
//          A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
//          Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
//          Ensure a constant game speed by Thread.Sleep(150). Implement collision detection and scoring system.

using System;
using System.Collections.Generic;
using System.Threading;

struct Object                                                                   // creates a variable type with name 'Object'
{
    public int x;                                                               // x coordinate of the object
    public int y;                                                               // y coordinate of the object
    public int w;                                                               // the width of the object
    public string str;                                                          // the symbol of the object
    public ConsoleColor col;                                                    // the color of the object
}

class FallingRocksGame
{
    static int level = 1;                                                       // level counting
    static int lives = 5;                                                       // lives counting
    static int speed = 10;                                                      // speed counting
    static int wall_width1 = 0;                                                 // width of the left wall
    static int wall_width2 = 0;                                                 // width of the right wall
    static int bigrock_width = 0;                                               // size of big rocks
    static int t = 0;                                                           // global game timer
    static int t_level = 0;                                                     // timer for each level
    static int diff = 0;                                                        // level of difficulty
    static int diff_temp1 = 0;                                                  // 1st temp help variable for diff
    static int diff_temp2 = 0;                                                  // 2nd temp help variable for diff

    /* Group of symbols for the rocks */
    static string[] TypeRocks = new string[] { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "-" };

    /* Generator of numbers */
    static Random RandomGenerator = new Random();

    /* Lists with objects */
    static List<Object> RocksList = new List<Object>();
    static List<Object> BigRocksList = new List<Object>();
    static List<Object> WallList1 = new List<Object>();
    static List<Object> WallList2 = new List<Object>();
    static List<Object> BonusLifeList = new List<Object>();
    static List<Object> BonusClearList = new List<Object>();

    static void WindowSize()                                                    // sets the width and the height of the console
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
    }

    /* Print some object */
    static void PrintObject(int x, int y, string str, ConsoleColor col = ConsoleColor.Gray)
    {
        if (x < 0)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = 0;
        }
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = col;
        Console.Write(str);
    }

    /* Print some text and symbol information */
    static void PrintString(int x, int y, string str, ConsoleColor col = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = col;
        Console.Write(str);
    }

    static void CreateRocks()
    {
        Object NewRock = new Object();                                          // create one rock object
        NewRock.col = ConsoleColor.White;                                       // set the color of the object
        NewRock.x = RandomGenerator.Next(0, Console.WindowWidth);               // generate number between (0) and (Console.WindowWidth - 1)
        NewRock.y = -1;                                                         // because before to be displayed the object, we y++ 
        NewRock.str = TypeRocks[RandomGenerator.Next(11)];                      // takes different symbol from TypeRocks[]
        if (!(NewRock.x <= wall_width1 + 1 || NewRock.x >= Console.WindowWidth - wall_width2 - 1))
        {
            RocksList.Add(NewRock);                                             // the rock object will enter in the RocksList  
        }
    }

    static void CreateBigRocks()
    {
        bigrock_width = RandomGenerator.Next(5, 16);

        /* To create one big rock we create 4 rows of sub-objects */
        Object BigRock1 = new Object();                                         // creates the 1st big rock sub-object
        BigRock1.col = ConsoleColor.Black;
        BigRock1.x = RandomGenerator.Next(0, Console.WindowWidth - (bigrock_width + 2));
        BigRock1.y = -1;                                                        // because before to be displayed the object, we y++ 
        BigRock1.w = bigrock_width;
        BigRock1.str = new string('☼', bigrock_width);

        Object BigRock2 = BigRock1;                                             // creates the 2nd big rock sub-object
        BigRock2.x = BigRock1.x - 1;
        BigRock2.y = 0;                                                         // the 2nd sub-object is under the 1st
        BigRock2.str = new string('‡', bigrock_width + 2);

        Object BigRock3 = BigRock2;                                             // creates the 3rd big rock sub-object
        BigRock3.y = 1;                                                         // the 3rd sub-object is under the 2nd

        Object BigRock4 = BigRock1;                                             // creates the 4th big rock sub-object
        BigRock4.y = 2;                                                         // the 4th sub-object is under the 3rd

        /* Adds all sub-objects in the BigRocksList */
        BigRocksList.Add(BigRock1);
        BigRocksList.Add(BigRock2);
        BigRocksList.Add(BigRock3);
        BigRocksList.Add(BigRock4);
    }

    static void CreateLeftSideWall()                                            // creates one moving wall on the left side of the game
    {
        Object NewBrick1 = new Object();                                        // creates a new brick object for the left wall
        NewBrick1.col = ConsoleColor.Black;
        NewBrick1.x = 0;
        NewBrick1.y = -1;
        NewBrick1.w = wall_width1;
        NewBrick1.str = new string('#', wall_width1);
        WallList1.Add(NewBrick1);                                               // adds the current brick in the left wall (each brick is one row)
    }

    static void CreateRightSideWall()                                           // creates one moving wall on the right side of the game
    {
        Object NewBrick2 = new Object();                                        // creates a new brick object for the right wall
        NewBrick2.col = ConsoleColor.Black;
        NewBrick2.x = Console.WindowWidth - wall_width2 - 1;
        NewBrick2.y = -1;
        NewBrick2.w = wall_width2;
        NewBrick2.str = new string('#', wall_width2);
        WallList2.Add(NewBrick2);                                               // adds the current brick in the right wall
    }

    /* Creates one bonus object which gives a life */
    static void CreateBonusLife()
    {
        Object BonusLife = new Object();
        BonusLife.col = ConsoleColor.Red;
        BonusLife.x = RandomGenerator.Next(0, Console.WindowWidth);
        BonusLife.y = -1;
        BonusLife.str = "♥";
        if (!(BonusLife.x <= wall_width1 + 1 || BonusLife.x >= Console.WindowWidth - wall_width2 - 1))
        {
            BonusLifeList.Add(BonusLife);                                       // adds this object in the BonusLifeList
        }
    }

    /* Creates a second bonus object which clears the rocks */
    static void CreateBonusClear()
    {
        Object BonusClear = new Object();
        BonusClear.col = ConsoleColor.Yellow;
        BonusClear.x = RandomGenerator.Next(0, Console.WindowWidth);
        BonusClear.y = -1;
        BonusClear.str = "♦";
        if (!(BonusClear.x <= wall_width1 + 1 || BonusClear.x >= Console.WindowWidth - wall_width2 - 1))
        {
            BonusClearList.Add(BonusClear);                                     // adds this object in the BonusClearList
        }
    }

    /* Sets a different difficulty for different level */
    static void LevelDifficulty()
    {
        if (t % 2 == 0)                                                         // creates one sub-timer
        {
            diff_temp1++;
        }
        if (t % 3 == 0)                                                         // creates a second sub-timer
        {
            t_level++;
        }
        if (t_level == 100)                                                     // we use the 2nd sub-timer to measure the time in each level
        {
            t_level = 0;                                                        // each level is 100 't_level' units, so we make it zero when its over 
            level++;                                                            // increase the level by 1
            if (level <= 10 || speed < 100)                                      // increase the speed by 10 (max 100)
            {
                speed += 10;
            }
        }

        /* Schedule for big rocks*/
        if ((t <= 600 && t >= 60) || (level < 8 && level >= 5) || level >= 12 && level <= 30)      // big rocks takes part only in these levels
        {
            if ((level >= 2 && level < 5) || level == 7 || level >= 13)            // more difficulty for these levels
            {
                diff = diff_temp1;
            }
            else if (level < 2 || (level >= 5 && level < 7) || level > 11 && level <= 13)
            {
                diff = t_level;
            }

            if (t_level % 20 == 0 && diff_temp2 != diff)
            {
                CreateBigRocks();
            }
        }

        /* Schedule for walls, "life" and "clear" bonuses*/
        if (level >= 3)
        {
            if (level >= 5 && level < 8)                                         // in these levels the bonuses are less
            {
                if (t % 80 == 0 && t_level >= 30)
                {
                    CreateBonusLife();
                    CreateBonusClear();
                }
            }
            else if (level < 5 || level >= 8 && level <= 11)                      // in these levels we have more bonuses
            {
                if (t % 40 == 0 && t_level >= 30)
                {
                    CreateBonusLife();
                    CreateBonusClear();
                }
            }
            else if (level > 11)                                                // after lv-12 we need a lot of bonuses because of speed
            {
                if (t % 10 == 0 && t_level >= 10)
                {
                    CreateBonusLife();
                    if (level <= 20)                                            // no more clear bonuses after lv-20
                    {
                        CreateBonusClear();
                    }
                }
            }

            wall_width1 += RandomGenerator.Next(-1, 2);                             // the width of the wall will be different with -1, 0 or 1
            wall_width2 += RandomGenerator.Next(-1, 2);                             // 2nd generator for the right wall
            if (level < 12 || level >= 24)
            {
                if (level <= 10 || level >= 24)
                {
                    if ((level >= 5 && level < 8) || (level >= 24 && level < 30))
                    {
                        if (Console.WindowWidth - (wall_width1 + wall_width2) <= 50)    // from lv-5 to lv-7 the gap between the walls is ~ 50
                        {
                            wall_width1--;
                            wall_width2--;
                        }
                        if (wall_width1 <= 0)
                        {
                            wall_width1 = 0;
                        }
                        if (wall_width2 <= 0)
                        {
                            wall_width2 = 0;
                        }
                    }
                    else
                    {
                        if (t >= 600)                                                   // this increases the width of the left wall when the base timer is 600
                        {
                            if (wall_width1 < 30)
                            {
                                wall_width1++;
                            }
                        }
                        if (t >= 500)
                        {
                            if (wall_width2 < 40)
                            {
                                wall_width2++;
                            }
                        }
                        else
                        {
                            if (wall_width1 < 10)
                            {
                                wall_width1++;
                            }
                            if (wall_width2 < 10)
                            {
                                wall_width2++;
                            }
                        }
                        if (level < 30)
                        {
                            if (Console.WindowWidth - (wall_width1 + wall_width2) <= 6)     // the gap between the walls will be ~ 6
                            {
                                wall_width1--;
                                wall_width2--;
                            }
                        }
                        else
                        {
                            if (Console.WindowWidth - (wall_width1 + wall_width2) <= 20)     // the gap between the walls will be ~ 20
                            {
                                wall_width1--;
                                wall_width2--;
                            }
                        }
                    }
                }
                else
                {
                    wall_width1--;
                    wall_width2--;
                    if (wall_width1 <= 0)                                               // the width of the left wall can't be negative
                    {
                        wall_width1 = 0;
                    }
                    if (wall_width2 <= 0)                                               // the width of the right wall can't be negative
                    {
                        wall_width2 = 0;
                    }
                }
                CreateLeftSideWall();
                CreateRightSideWall();
            }
        }

        /* The rocks are created in the whole time */
        CreateRocks();
    }

    /* Displaying all created objects*/
    static void DisplayObjects()
    {
        foreach (Object rock in RocksList)
        {
            PrintObject(rock.x, rock.y, rock.str, rock.col);
        }
        foreach (Object bigrock in BigRocksList)
        {
            PrintObject(bigrock.x, bigrock.y, bigrock.str, bigrock.col);
        }
        foreach (Object bonus_life in BonusLifeList)
        {
            PrintObject(bonus_life.x, bonus_life.y, bonus_life.str, bonus_life.col);
        }
        foreach (Object bonus_clear in BonusClearList)
        {
            PrintObject(bonus_clear.x, bonus_clear.y, bonus_clear.str, bonus_clear.col);
        }
        foreach (Object bricks1 in WallList1)
        {
            PrintObject(bricks1.x, bricks1.y, bricks1.str, bricks1.col);
        }
        foreach (Object bricks2 in WallList2)
        {
            PrintObject(bricks2.x, bricks2.y, bricks2.str, bricks2.col);
        }
    }

    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        WindowSize();

        /* Create a dwarf */
        Object Dwarf = new Object();
        Dwarf.x = Console.WindowWidth / 2;                                      // default x coordinate for dwarf
        Dwarf.y = Console.WindowHeight - 1;                                     // default y coordinate for dwarf
        Dwarf.str = "(0)";                                                      // symbol for the dwarf
        Dwarf.col = ConsoleColor.Yellow;                                        // color for the dwarf

        while (true)
        {
            bool hitted = false;                                                // if the dwarf is hitted by some object
            t++;                                                                // global base timer
            LevelDifficulty();

            /* Key activity */
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                while (Console.KeyAvailable) Console.ReadKey();                 // for fluent moving of the dwarf
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Dwarf.x > 0)
                    {
                        Dwarf.x--;                                              // moves the dwarf to left
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Dwarf.x < Console.WindowWidth - 2)
                    {
                        Dwarf.x++;                                              // moves the dwarf to right
                    }
                }
                else if (key.Key == ConsoleKey.Spacebar)                        // pause the game with <Spacebar>
                {
                    Console.ReadKey();
                }
            }

            /* This function move and clear the rock objects */
            for (int i = 0; i < RocksList.Count; i++)
            {
                Object old_rock = RocksList[i];
                Object new_rock = new Object();
                new_rock.x = old_rock.x;
                new_rock.y = old_rock.y + 1;
                new_rock.str = old_rock.str;
                new_rock.col = old_rock.col;
                if (new_rock.y < Console.WindowHeight)
                {
                    RocksList.Insert(i, new_rock);
                }
                else
                {
                    i = -1;
                }
                RocksList.Remove(old_rock);

                if (old_rock.y + 1 == Dwarf.y && (old_rock.x >= Dwarf.x && old_rock.x <= Dwarf.x + Dwarf.str.Length - 1))
                {
                    hitted = true;
                    goto hitted;
                }
            }

            /* This function move and clear the bonus "life" objects */
            for (int bl = 0; bl < BonusLifeList.Count; bl++)
            {
                Object old_bonus_life = BonusLifeList[bl];
                Object new_bonus_life = new Object();
                new_bonus_life.x = old_bonus_life.x;
                new_bonus_life.y = old_bonus_life.y + 1;
                new_bonus_life.str = old_bonus_life.str;
                new_bonus_life.col = old_bonus_life.col;
                new_bonus_life.w = old_bonus_life.w;
                if (new_bonus_life.y < Console.WindowHeight)
                {
                    BonusLifeList.Insert(bl, new_bonus_life);
                }
                else
                {
                    bl = -1;
                }
                BonusLifeList.Remove(old_bonus_life);
                if (old_bonus_life.y + 1 == Dwarf.y && (old_bonus_life.x >= Dwarf.x && old_bonus_life.x <= Dwarf.x + Dwarf.str.Length - 1))
                {
                    if (lives < 5)
                    {
                        lives++;
                    }
                }
            }

            /* This function move and clear the bonus "clear" objects */
            for (int bc = 0; bc < BonusClearList.Count; bc++)
            {
                Object old_bonus_clear = BonusClearList[bc];
                Object new_bonus_clear = new Object();
                new_bonus_clear.x = old_bonus_clear.x;
                new_bonus_clear.y = old_bonus_clear.y + 1;
                new_bonus_clear.str = old_bonus_clear.str;
                new_bonus_clear.col = old_bonus_clear.col;
                new_bonus_clear.w = old_bonus_clear.w;
                if (new_bonus_clear.y < Console.WindowHeight)
                {
                    BonusClearList.Insert(bc, new_bonus_clear);
                }
                else
                {
                    bc = -1;
                }
                BonusClearList.Remove(old_bonus_clear);
                if (old_bonus_clear.y + 1 == Dwarf.y && (old_bonus_clear.x >= Dwarf.x && old_bonus_clear.x <= Dwarf.x + Dwarf.str.Length - 1))
                {
                    RocksList.Clear();
                    BonusLifeList.Clear();
                    BonusClearList.Clear();
                    if (speed > 80)
                    {
                        speed -= 10;
                    }
                }
            }

            /* This function move and clear the big rock objects */
            if (diff_temp2 != t_level)
            {
                diff_temp2 = t_level;
                for (int m = 0; m < BigRocksList.Count; m++)
                {
                    Object old_bigrock = BigRocksList[m];
                    Object new_bigrock = new Object();
                    new_bigrock.x = old_bigrock.x;
                    new_bigrock.y = old_bigrock.y + 1;
                    new_bigrock.str = old_bigrock.str;
                    new_bigrock.col = old_bigrock.col;
                    new_bigrock.w = old_bigrock.w;
                    if (new_bigrock.y < Console.WindowHeight)
                    {
                        BigRocksList.Insert(m, new_bigrock);
                    }
                    else
                    {
                        m = -1;
                    }
                    BigRocksList.Remove(old_bigrock);
                    if (old_bigrock.y + 1 == Dwarf.y && ((Dwarf.x >= old_bigrock.x && Dwarf.x < old_bigrock.x + old_bigrock.w) || (Dwarf.x + Dwarf.str.Length > old_bigrock.x && Dwarf.x + Dwarf.str.Length < old_bigrock.x + old_bigrock.w)))
                    {
                        hitted = true;
                        goto hitted;
                    }
                }
            }

            /* This function move and clear the objects from the left wall */
            for (int j = 0; j < WallList1.Count; j++)
            {
                Object old_brick1 = WallList1[j];
                Object new_brick1 = new Object();
                new_brick1.x = old_brick1.x;
                new_brick1.y = old_brick1.y + 1;
                new_brick1.str = old_brick1.str;
                new_brick1.col = old_brick1.col;
                new_brick1.w = old_brick1.w;
                if (new_brick1.y < Console.WindowHeight)
                {
                    WallList1.Insert(j, new_brick1);
                }
                else
                {
                    j = -1;
                }
                WallList1.Remove(old_brick1);
                if (old_brick1.y + 1 == Dwarf.y && old_brick1.w > Dwarf.x)
                {
                    hitted = true;
                    goto hitted;
                }
            }

            /* This function move and clear the objects from the right wall */
            for (int k = 0; k < WallList2.Count; k++)
            {
                Object old_brick2 = WallList2[k];
                Object new_brick2 = new Object();
                new_brick2.x = old_brick2.x;
                new_brick2.y = old_brick2.y + 1;
                new_brick2.str = old_brick2.str;
                new_brick2.col = old_brick2.col;
                new_brick2.w = old_brick2.w;
                if (new_brick2.y < Console.WindowHeight)
                {
                    WallList2.Insert(k, new_brick2);
                }
                else
                {
                    k = -1;
                }
                WallList2.Remove(old_brick2);
                if (old_brick2.y + 1 == Dwarf.y && Dwarf.x + Dwarf.str.Length > Console.WindowWidth - old_brick2.w - 1)
                {
                    hitted = true;
                    goto hitted;
                }
            }

            Console.Clear();
            DisplayObjects();

        /* If the dwarf is hitted by some object */
        hitted:
            if (hitted)
            {
                t_level = 0;                                                // reset the sub-timer for the level
                t = 200 * (level - 1);                                      // reset the basic timer to the current level
                lives--;                                                    // decrease the lives
                RocksList.Clear();
                BigRocksList.Clear();
                WallList1.Clear();
                WallList2.Clear();
                BonusLifeList.Clear();
                BonusClearList.Clear();
                wall_width1 = wall_width2 = 0;                              // reset the width of the walls
                PrintObject(Dwarf.x + Dwarf.str.Length / 2, Dwarf.y, "X", ConsoleColor.Red);
                if (lives <= 0)                                             // when the player is killed
                {
                    PrintString(46, 15, "Game Over!", ConsoleColor.Red);
                    PrintString(41, 17, "Press <Enter> to exit", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
                }
                Console.ReadKey();
            }
            else
            {
                PrintObject(Dwarf.x, Dwarf.y, Dwarf.str, Dwarf.col);         // the dwarf is printed only if it is not hitted
            }

            /* Statistic information about the game*/
            PrintString(2, 1, "Level: " + level, ConsoleColor.White);
            PrintString(12, 1, "(" + (99 - t_level) + ")", ConsoleColor.White);
            PrintString(2, 2, "Speed: " + speed, ConsoleColor.White);
            PrintString(86, 1, "Lives: ", ConsoleColor.White);
            PrintString(93, 1, new string('♥', lives), ConsoleColor.Red);

            Thread.Sleep(110 - speed);                                      // sleep in this point for (110 - speed) ms
        }
    }
}