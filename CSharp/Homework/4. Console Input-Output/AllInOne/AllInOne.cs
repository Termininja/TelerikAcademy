//This program presents the all 11 tasks from homework 4

using System;
using System.Collections.Generic;
using System.Threading;

struct Object                                                                       // creates a variable type with name 'Object'
{
    public int x;                                                                   // x coordinate of the object
    public int y;                                                                   // y coordinate of the object
    public int w;                                                                   // the width of the object
    public string str;                                                              // the symbol of the object
    public ConsoleColor col;                                                        // the color of the object
}

class AllTasks
{

    /*                       *
     *   Start of Task 11    *
     *                       *
     *        Methods        *
     *                       */

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
        if (!(NewRock.x <= wall_width1 + 1 | NewRock.x >= Console.WindowWidth - wall_width2 - 1))
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
        if (!(BonusLife.x <= wall_width1 + 1 | BonusLife.x >= Console.WindowWidth - wall_width2 - 1))
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
        if (!(BonusClear.x <= wall_width1 + 1 | BonusClear.x >= Console.WindowWidth - wall_width2 - 1))
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
            if (level <= 10 | speed < 100)                                      // increase the speed by 10 (max 100)
            {
                speed += 10;
            }
        }

        /* Schedule for big rocks*/
        if ((t <= 600 & t >= 60) | (level < 8 & level >= 5) | level >= 12 & level <= 30)      // big rocks takes part only in these levels
        {
            if ((level >= 2 & level < 5) | level == 7 | level >= 13)            // more difficulty for these levels
            {
                diff = diff_temp1;
            }
            else if (level < 2 | (level >= 5 & level < 7) | level > 11 & level <= 13)
            {
                diff = t_level;
            }

            if (t_level % 20 == 0 & diff_temp2 != diff)
            {
                CreateBigRocks();
            }
        }

        /* Schedule for walls, "life" and "clear" bonuses*/
        if (level >= 3)
        {
            if (level >= 5 & level < 8)                                         // in these levels the bonuses are less
            {
                if (t % 80 == 0 & t_level >= 30)
                {
                    CreateBonusLife();
                    CreateBonusClear();
                }
            }
            else if (level < 5 | level >= 8 & level <= 11)                      // in these levels we have more bonuses
            {
                if (t % 40 == 0 & t_level >= 30)
                {
                    CreateBonusLife();
                    CreateBonusClear();
                }
            }
            else if (level > 11)                                                // after lv-12 we need a lot of bonuses because of speed
            {
                if (t % 10 == 0 & t_level >= 10)
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
            if (level < 12 | level >= 24)
            {
                if (level <= 10 | level >= 24)
                {
                    if ((level >= 5 & level < 8) | (level >= 24 & level < 30))
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

   /*                       *
    *     End of Task 11    *
    *                       *
    *        Methods        *
    *                       */

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        dynamic task = null;                                                        // user's choice variable
        goto charging;                                                              // if we start now → go to 'charging' point
    home:                                                                           // marking home point
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;                        // change the font color
            Console.WriteLine("\n   Homework 4. Console Input/Output");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
      Task 1: Write a program that reads 3 integer numbers from the console and prints their sum.
      Task 2: Write a program that reads the radius of a circle and prints its perimeter and area.
      Task 3: A company has name, address, phone №, fax №, web site and manager. The manager has
              first name, last name, age and a phone №. Write a program that reads the information
              about a company and its manager and prints them on the console.
      Task 4: Write a program that reads two positive integer numbers and prints how many numbers
              exist between them such that the remainder of the division by 5 is 0 (inclusive).
      Task 5: Write a program that gets two numbers from the console and prints the greater of
              them. Don’t use if statements.
      Task 6: Write a program that reads the coefficients a, b and c of a quadratic equation
              ax2+bx+c=0 and solves it (prints its real roots).
      Task 7: Write a program that gets a number n and after that gets more n numbers and
              calculates and prints their sum.
      Task 8: Write a program that reads an integer number n from the console and prints all the
              numbers in the interval [1..n], each on a single line.
      Task 9: Write a program to print the first 100 members of the sequence of Fibonacci:
              0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
     Task 10: Write a program to calculate the sum (with accuracy 0.001): 1 + 1/2 - 1/3 + 1/4...
     Task 11: ""Falling Rocks"" game in the text console. A small dwarf stays at the bottom of the
              screen and can move left and right (by the arrows keys). A number of rocks of
              different sizes and forms constantly fall down and you need to avoid a crash. Rocks
              are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate
              density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
              Implement collision detection and scoring system.
                         ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("   To start some program, please enter a task number from 1 to 14 or type \"exit\" to exit: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            task = Console.ReadLine();                                              // select which task number (1 - 11) to show
            Console.Clear();

            /*Start of Task 1*/
            if (task == "1")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)
                {
                    /* Table */
                    Console.WriteLine(@"Please, write 3 integer numbers:

   Number 1    │
   Number 2    │
   Number 3    │
   ────────────┼───────────────
   Sum         │");

                    int num1, num2, num3 = 0;
                    try
                    {
                        Console.CursorTop = 2;                                              // move the cursor to position 2 from the top
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorLeft = 17;                                            // move the cursor to position 17 from the left
                        num1 = int.Parse(Console.ReadLine());                               // read the 1st number
                        Console.CursorLeft = 17;
                        num2 = int.Parse(Console.ReadLine());                               // read the 2nd number
                        Console.CursorLeft = 17;
                        num3 = int.Parse(Console.ReadLine());                               // read the 3rd number

                        Console.CursorTop = 6;
                        Console.CursorLeft = 17;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(num1 + num2 + num3);                              // the result from the sum

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n\nPress Enter to continue, or X to exit . . .");
                    key:
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                        {
                            break;
                        }
                        else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                        {
                            Console.Write("\b \b");                                         // clear the wrong keys from the console
                            goto key;
                        }
                        Console.ResetColor();
                        Console.Clear();
                    }
                    catch (Exception)                                                       // this rows below will be executed if there are some errors
                    {
                        Console.CursorTop = 6;
                        Console.CursorLeft = 17;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error!");                                        // this message will be shown when there is some error
                        Console.ReadKey();                                                  // you will continue if you press any Key
                        Console.Clear();
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 2*/
            if (task == "2")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)
                {
                    Console.Write("Please, enter the radius of the circle: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("r = ");
                    string str = Console.ReadLine();
                    Console.ResetColor();
                    double radius = 0;
                    if (double.TryParse(str, out radius) & radius > 0)
                    {
                        Console.Write("\nThe perimeter of the circle is:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Math.Round(2 * Math.PI * radius, 2));
                        Console.ResetColor();

                        Console.Write("\nThe area of the circle is:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Math.Round(Math.PI * Math.Pow(radius, 2), 2));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");                        // this message will be shown when there is some error
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nPress Enter to continue, or X to exit . . .");
                key:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                    {
                        break;
                    }
                    else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                    {
                        Console.Write("\b \b");                                         // clear the wrong keys from the console
                        goto key;
                    }
                    Console.ResetColor();
                    Console.Clear();
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 3*/
            if (task == "3")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)
                {
                    /* Table */
                    Console.WriteLine(@"
   Information     │ Read                  │ Print
  ─────────────────┼───────────────────────┼───────────────────────
   Company         │                       │
    Name:          │                       │
    Adress:        │                       │
    Phone number:  │                       │
    Fax number:    │                       │
    Web site:      │                       │
  ─────────────────┼───────────────────────┼───────────────────────
   Manager         │                       │
    First name:    │                       │
    Last name:     │                       │
    Age:           │                       │
    Phone number:  │                       │");

                    try
                    {
                        string str;
                        Console.CursorTop = 4;
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.CursorLeft = 21;
                        string CompanyName = Console.ReadLine();                                // read a company name

                        Console.CursorLeft = 21;
                        string CompanyAdress = Console.ReadLine();                               // read a company address

                        Console.CursorLeft = 21;
                        str = Console.ReadLine();                                               // read a company phone number
                        ulong CompanyPhone = ulong.Parse(str);                                  // extract the number from the string
                        byte count1 = 0;
                        foreach (char a in str)                                                 // count a digits in the phone number
                        {
                            if (char.IsDigit(a))
                            {
                                count1++;
                            }
                        }

                        Console.CursorLeft = 21;
                        str = Console.ReadLine();                                               // read a company fax number
                        ulong CompanyFax = ulong.Parse(str);                                    // extract the number from the string
                        byte count2 = 0;
                        foreach (char a in str)                                                 // count a digits in the fax number
                        {
                            if (char.IsDigit(a))
                            {
                                count2++;
                            }
                        }

                        Console.CursorLeft = 21;
                        string WebSite = Console.ReadLine();                                    // read the name of web site

                        Console.WriteLine("\n");

                        Console.CursorLeft = 21;
                        string FirstName = Console.ReadLine();                                  // read the manager's first name

                        Console.CursorLeft = 21;
                        string LastName = Console.ReadLine();                                   // read the manager's last name

                        Console.CursorLeft = 21;
                        str = Console.ReadLine();                                               // read the manager's age
                        byte Age = byte.Parse(str);                                             // extract the age from the string

                        Console.CursorLeft = 21;
                        str = Console.ReadLine();                                               // read a manager's phone number
                        ulong ManagerPhone = ulong.Parse(str);                                  // extract the manager's phone number from the string
                        byte count3 = 0;
                        foreach (char a in str)                                                 // count a digits in the manager's phone number
                        {
                            if (char.IsDigit(a))
                            {
                                count3++;
                            }
                        }

                        Console.ResetColor();
                        Console.Write("\nPress any key to print the result. . .");
                        Console.ReadKey();                                                      // we have to press any key to continue

                        /* Print the results */
                        Console.CursorTop = 4;
                        Console.CursorLeft = 57;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = 45;
                        Console.WriteLine(CompanyName);
                        Console.CursorLeft = 45;
                        Console.WriteLine(CompanyAdress);
                        Console.CursorLeft = 45;
                        Console.WriteLine(CompanyPhone.ToString().PadLeft(count1, '0'));
                        Console.CursorLeft = 45;
                        Console.WriteLine(CompanyFax.ToString().PadLeft(count2, '0'));
                        Console.CursorLeft = 45;
                        Console.WriteLine(WebSite);
                        Console.WriteLine("\n");
                        Console.CursorLeft = 45;
                        Console.WriteLine(FirstName);
                        Console.CursorLeft = 45;
                        Console.WriteLine(LastName);
                        Console.CursorLeft = 45;
                        Console.WriteLine(Age);
                        Console.CursorLeft = 45;
                        Console.WriteLine(ManagerPhone.ToString().PadLeft(count3, '0'));
                        Console.WriteLine("\n");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n\nPress Enter to continue, or X to exit . . .");
                    key:
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.X)                                            // you will exit if you press "X"
                        {
                            break;
                        }
                        else if (key.Key != ConsoleKey.Enter)                                   // you will continue only when you press "Enter"
                        {
                            Console.Write("\b \b");                                             // clear the wrong keys from the console
                            goto key;
                        }
                        Console.ResetColor();
                        Console.Clear();
                    }
                    catch (Exception)                                                           // this rows below will be executed if there are some errors
                    {
                        Console.CursorTop = 17;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Something's wrong!");                                    // this message will be shown when there is some error
                        Console.ReadKey();                                                      // you will continue if you press any Key
                        Console.Clear();
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 4*/
            if (task == "4")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)
                {
                    try
                    {
                        Console.Write("Please, write two positive integer numbers: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorTop = 2;
                        Console.CursorLeft = 7;
                        uint num1 = uint.Parse(Console.ReadLine());                         // read the 1st number 'num1'
                        Console.CursorTop = 2;
                        Console.CursorLeft = 27;
                        uint num2 = uint.Parse(Console.ReadLine());                         // read the 2nd number 'num2'
                        Console.ResetColor();

                        bool print = false;                                                 // to print or not all 'p' numbers
                        uint min = num1;                                                    // by default 'num1' is the minimum number
                        uint max = num2;

                        if (num1 > num2)                                                    // compare the two numbers; if num1 > num2 they will be replaced
                        {
                            min = num2;
                            max = num1;
                        }
                    print:
                        uint p = 0;
                        for (uint i = min; i <= max; i++)                                   // we take only the numbers between num1 and num2
                        {
                            if (i % 5 == 0)
                            {
                                p++;                                                        // here we count how many numbers are devided by 5
                                if (print)
                                {
                                    System.Threading.Thread.Sleep(50);                      // the program will sleep for 50ms
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(i);
                                    Console.ResetColor();
                                    Console.Write(", ");
                                }
                            }
                        }
                        if (print)
                        {
                            Console.Write("\b\b ");                                         // delete the last comma
                        }
                        else
                        {
                            Console.Write("\nBetween {0} and {1} exists ", min, max);       // this prnt the result
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(p);
                            Console.ResetColor();
                            Console.Write(" numbers which can be divided by 5 with remainder of 0");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n\nPress Enter to continue, X to exit, or P to see all them . . .");
                    key:
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                        {
                            break;
                        }
                        if (key.Key == ConsoleKey.P)                                        // all 'p' numbers will be printed if you press "P"
                        {
                            Console.ResetColor();
                            Console.Write("\n\nThe numbers are: ");
                            print = true;
                            goto print;
                        }
                        else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                        {
                            Console.Write("\b \b");                                         // clear the wrong keys from the console
                            goto key;
                        }
                        Console.ResetColor();
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.CursorTop = 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something's wrong!");                            // this message will be shown when there is some error
                        Console.ReadKey();                                                  // you will continue if you press any Key
                        Console.Clear();
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 5*/
            if (task == "5")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                bool end = false;                                                               // we don't want to finish now
                while (true)                                                                    // repeat continuously
                {
                    try                                                                         // check for errors
                    {
                        if (end == false)
                        {
                            Console.Write("Please, write two numbers: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.CursorTop = 2;
                            Console.CursorLeft = 7;
                            decimal num1 = decimal.Parse(Console.ReadLine());                   // read the 1st number 'num1'
                            Console.CursorTop = 2;
                            Console.CursorLeft = 27;
                            decimal num2 = decimal.Parse(Console.ReadLine());                   // read the 2nd number 'num2'
                            Console.ResetColor();

                            decimal zerocheck = 1 / (num1 - num2);                              // checks whether num1 = num2
                            Console.Write("\nThe greater of these two number is: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Math.Max(num1, num2));                                // result from the comparison
                            end = true;                                                         // we finished
                        }
                        else                                                                    // if we finished
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
                        key:
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                            {
                                break;
                            }
                            else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                            {
                                Console.Write("\b \b");                                         // clear the wrong keys from the console
                                goto key;
                            }
                            end = false;                                                        // if we don't want to exit
                            Console.ResetColor();
                            Console.Clear();
                        }
                    }
                    catch (DivideByZeroException)                                               // for all cases when zerocheck = 1/0
                    {
                        Console.CursorTop = 4;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("The two numbers are equal!");
                        end = true;
                    }
                    catch (OverflowException)                                                   // for all cases when num1 or num2 is too big
                    {
                        Console.CursorTop = 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("The number is too big!");
                        end = true;
                    }
                    catch (Exception)                                                           // for all other cases the error message will be shown
                    {
                        Console.CursorTop = 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("This is not a number!");
                        end = true;
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 6*/
            if (task == "6")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                bool end = false;                                                               // we don't want to finish now
                while (true)                                                                    // repeat continuously
                {
                    try                                                                         // check for errors
                    {
                        if (end == false)
                        {
                            Console.Write("Please, enter the coefficient: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("a = ");
                            double a = double.Parse(Console.ReadLine());                        // read the 1st coefficient 'a'
                            Console.ResetColor();

                            Console.Write("Please, enter the coefficient: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("b = ");
                            double b = double.Parse(Console.ReadLine());                        // read the 2nd coefficient 'b'
                            Console.ResetColor();

                            Console.Write("Please, enter the coefficient: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("c = ");
                            double c = double.Parse(Console.ReadLine());                        // read the 3rd coefficient 'c'
                            Console.ResetColor();

                            double D = Math.Pow(b, 2) - 4 * a * c;                              // the discriminant of quadratic equation

                            if (D < 0)                                                          // if we don't have real roots
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nThe quadratic equation doesn't have real roots!");
                                Console.ResetColor();
                            }
                            else if (D == 0)                                                    // if we have only one real root 'x'
                            {
                                double x = -b / 2 * a;
                                Console.WriteLine("\nThe quadratic equation has only one real root:\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t     -b");
                                Console.WriteLine("\tx = ───── = {0}", Math.Round(x, 2));
                                Console.WriteLine("\t     2.a");
                                Console.ResetColor();
                            }
                            else                                                                // if we have two real roots 'x1' and 'x2'
                            {
                                double x1 = (-b + Math.Sqrt(D)) / 2 * a;
                                double x2 = (-b - Math.Sqrt(D)) / 2 * a;
                                Console.WriteLine("\nThe quadratic equation has two real roots:\n");
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("\t      -b + √D");
                                Console.WriteLine("\tx1 = ───────── = {0}", Math.Round(x1, 2));
                                Console.WriteLine("\t        2.a\n");

                                Console.WriteLine("\t      -b - √D");
                                Console.WriteLine("\tx2 = ───────── = {0}", Math.Round(x2, 2));
                                Console.WriteLine("\t        2.a");

                                Console.ResetColor();
                            }
                            end = true;                                                         // we finished
                        }
                        else                                                                    // if we finished
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
                        key:
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                            {
                                break;
                            }
                            else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                            {
                                Console.Write("\b \b");                                         // clear the wrong keys from the console
                                goto key;
                            }
                            end = false;                                                        // if we don't want to exit
                            Console.ResetColor();
                            Console.Clear();
                        }
                    }
                    catch (OverflowException)                                                   // for all cases when some of the coefficients is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe number is too big!");
                        end = true;
                    }
                    catch (Exception)                                                           // in all other cases the error message will be shown
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis is not a number!");
                        end = true;
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 7*/
            if (task == "7")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                bool end = false;                                                               // we don't want to finish now
                while (true)                                                                    // repeat continuously
                {
                    try                                                                         // check for errors
                    {
                        if (end == false)
                        {
                            Console.WriteLine("How many numbers you want to sum?");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\n   n = ");
                            int n = int.Parse(Console.ReadLine());                              // reads how many numbers 'n' we will sum
                            Console.ResetColor();

                            string str = Convert.ToString(n);
                            byte count = 0;
                            foreach (char a in str)                                             // counts how many digits there are in the 'n'
                            {
                                if (char.IsDigit(a))
                                {
                                    count++;
                                }
                            }

                            if (n > 0)                                                          // we can sum only positive number 'n' of numbers
                            {
                                Console.WriteLine("\nPlease, enter {0} numbers:", n);
                                decimal sum = 0;                                                // the sum in beginnig is 0
                                byte w = 0;                                                     // from this depends the width where will be placed the number
                                byte h = 0;                                                     // from this depends the height where will be placed the number
                                for (int i = 1; i <= n; i++)                                    // we start to enter 'n' numbers
                                {
                                    w++;
                                    if (w == 1)                                                 // here is the 1st column
                                    {
                                        Console.CursorTop = 6 + h;
                                        Console.CursorLeft = 3;
                                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));       // we reserve 'count' digits for each one number
                                    }
                                    else if (w == 2)                                            // here is the 2nd column
                                    {
                                        Console.CursorTop = 6 + h;
                                        Console.CursorLeft = 30;
                                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                                    }
                                    else if (w == 3)                                            // here is the 3rd column
                                    {
                                        Console.CursorTop = 6 + h;
                                        Console.CursorLeft = 57;
                                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(count, '0'));
                                        w = 0;
                                        h++;
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    decimal number = decimal.Parse(Console.ReadLine());         // from here we read each one number
                                    Console.ResetColor();
                                    sum = sum + number;                                         // this is the current sum
                                }
                                Console.Write("\nThe sum of all numbers is: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(Math.Round(sum, 2));                          // this is the sum at the end
                                Console.ResetColor();
                            }
                            else                                                                // when the number 'n' is not positive
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nThe number has to be positive!");
                                Console.ResetColor();
                            }
                            end = true;                                                         // we finished
                        }
                        else                                                                    // if we finished
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
                        key:
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                            {
                                break;
                            }
                            else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                            {
                                Console.Write("\b \b");                                         // clear the wrong keys from the console
                                goto key;
                            }
                            end = false;                                                        // if we don't want to exit
                            Console.ResetColor();
                            Console.Clear();
                        }
                    }
                    catch (OverflowException)                                                   // for all cases when some number is too big
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe number is too big!");
                        end = true;
                    }
                    catch (Exception)                                                           // in all other cases the error message will be shown
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis is not a number!");
                        end = true;
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 8*/
            if (task == "8")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)                                                                // repeat continuously
                {
                hm:
                    Console.Write("Please, write some positive integer number: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("n = ");
                    int n = 0;
                    if (int.TryParse(Console.ReadLine(), out n))                            // reads some integer number 'n'
                    {
                        Console.ResetColor();
                        if (n > 0)                                                          // when the number 'n' is positive
                        {
                            Console.WriteLine("\nAll numbers in the interval [1..{0}] are: ", n);
                            for (int i = 1; i <= n; i++)
                            {
                                System.Threading.Thread.Sleep(100);                         // the program will sleep for 100ms
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(i);                                       // this prints the all numbers
                                Console.ResetColor();
                            }
                        }
                        else                                                                // when the number 'n' is a negative or 0
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The number is not positive!\n");
                            Console.ResetColor();
                            goto hm;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\nPress Enter to continue, or X to exit . . .");     // what we want to do
                    key:
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                        {
                            break;
                        }
                        else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                        {
                            Console.Write("\b \b");                                         // clear the wrong keys from the console
                            goto key;
                        }
                        Console.ResetColor();
                        Console.Clear();
                    }
                    else                                                                    // if the number is not integer
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This is not an integer number!\n");
                        Console.ResetColor();
                    }
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 9*/
            if (task == "9")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)                                                            // repeat continuously
                {
                    Console.Write("The first 100 members of the sequence of Fibonacci are: ");
                    decimal prev = 0;                                                     // the prvious member of the sequence
                    decimal curr = 0;                                                     // the current member of the sequence
                    decimal next = 1;                                                     // the next member of the sequence
                    for (int i = 1; i <= 100; i++)
                    {
                        System.Threading.Thread.Sleep(100);                             // the program will sleep for 100ms
                        prev = curr;
                        curr = next;
                        next = prev + curr;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(prev);                                            // this prints the all members of the sequence 
                        Console.ResetColor();
                        Console.Write(", ");
                    }
                    Console.Write("\b\b ");                                             // delete the last comma

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
                key:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                    {
                        break;
                    }
                    else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                    {
                        Console.Write("\b \b");                                         // clear the wrong keys from the console
                        goto key;
                    }
                    Console.ResetColor();
                    Console.Clear();
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 10*/
            if (task == "10")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

                while (true)
                {
                    decimal S = 1;                                                      // the first member of the sequence is 1
                    decimal S_curr = 0;                                                 // the current sum
                    for (decimal i = 2; ; i++)                                          // to count from 2 to infinity
                    {
                        System.Threading.Thread.Sleep(30);                              // the program will sleep for 30ms
                        if (i % 2 == 0)
                        {
                            S_curr = 1 / i;                                             // here are all even 'i'
                        }
                        else
                        {
                            S_curr = -1 / i;                                            // here are all odd 'i'
                        }
                        if (Math.Abs(S_curr) < 0.001m)                                  // program will stop when the current sum < 0.001
                        {
                            break;
                        }
                        S += S_curr;                                                    // the final sum of the sequence

                        Console.CursorTop = 1;
                        Console.Write("    Member: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(i);
                        Console.ResetColor();

                        Console.CursorTop = 2;
                        Console.Write("  Accuracy: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Math.Round(Math.Abs(S_curr), 5));
                        Console.ResetColor();

                        Console.CursorTop = 3;
                        Console.Write("       Sum: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Math.Round(S, 5));
                        Console.ResetColor();
                    }
                    Console.Write("\nThe final sum is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Math.Round(S, 3));
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nPress Enter to continue, or X to exit . . .");   // what we want to do
                key:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
                    {
                        break;
                    }
                    else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
                    {
                        Console.Write("\b \b");                                         // clear the wrong keys from the console
                        goto key;
                    }
                    Console.ResetColor();
                    Console.Clear();
                }

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            /*Start of Task 11*/
            if (task == "11")
            {
                Console.ResetColor();
                Console.Clear();

                /*Start of the program*/

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

                        if (old_rock.y + 1 == Dwarf.y & (old_rock.x >= Dwarf.x & old_rock.x <= Dwarf.x + Dwarf.str.Length - 1))
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
                        if (old_bonus_life.y + 1 == Dwarf.y & (old_bonus_life.x >= Dwarf.x & old_bonus_life.x <= Dwarf.x + Dwarf.str.Length - 1))
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
                        if (old_bonus_clear.y + 1 == Dwarf.y & (old_bonus_clear.x >= Dwarf.x & old_bonus_clear.x <= Dwarf.x + Dwarf.str.Length - 1))
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
                            if (old_bigrock.y + 1 == Dwarf.y & ((Dwarf.x >= old_bigrock.x & Dwarf.x < old_bigrock.x + old_bigrock.w) | (Dwarf.x + Dwarf.str.Length > old_bigrock.x & Dwarf.x + Dwarf.str.Length < old_bigrock.x + old_bigrock.w)))
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
                        if (old_brick1.y + 1 == Dwarf.y & old_brick1.w > Dwarf.x)
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
                        if (old_brick2.y + 1 == Dwarf.y & Dwarf.x + Dwarf.str.Length > Console.WindowWidth - old_brick2.w - 1)
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
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
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

                /*End of the program*/

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nYou exited from the task program.\nPress any key to go in the main menu . . .");
                Console.ReadKey();
                Console.Clear();
            }

            if (task == "exit")                                 // to exit of the basic program you have to press "exit"
            {
                goto charging;
            }
        }
    charging:                                                   // marking of "charging" point
        for (int i = 0; i <= 2000; i++)                         // you will exit (if you typed "exit") or load (by default), after 2k units 
        {
            if (i == 2000)
            {
                if (task != "exit")                             // if you didn't type "exit" → go to 'home' point
                {
                    Console.Clear();
                    goto home;
                }
                Environment.Exit(0);                            // exit from the console
            }
            else                                                // progress bar page
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (task != "exit")                             // if we enter
                {
                    Console.CursorTop = 10; Console.CursorLeft = 46; Console.WriteLine("Welcome!");
                }
                else                                            // if we exit
                {
                    Console.CursorTop = 10; Console.CursorLeft = 46; Console.WriteLine("Goodbye!");
                }
                Console.ResetColor();

                /*Progress bar*/
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.CursorTop = 12; Console.CursorLeft = 10;
                Console.WriteLine("┌" + new string('─', 78) + "┐");
                Console.CursorTop = 13; Console.CursorLeft = 10; Console.Write("│");
                Console.Write(new string('█', Math.Abs(i) / 25));                                                          // bar
                Console.CursorTop = 13; Console.CursorLeft = 89; Console.Write("│");
                Console.CursorTop = 14; Console.CursorLeft = 10;
                Console.WriteLine("└" + new string('─', 78) + "┘");
                Console.CursorTop = 15; Console.CursorLeft = 44; Console.Write(Math.Abs(i * 5) / 100 + " % to ");          // percentage counter
                if (task != "exit")
                {
                    Console.WriteLine("load");
                }
                else
                {
                    Console.WriteLine("go out");
                }
            }
        }

    }
}