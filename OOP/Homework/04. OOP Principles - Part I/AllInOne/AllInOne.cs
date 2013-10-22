using System;
using System.Threading;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.WindowHeight = 34;
        InOut("Welcome!");
        while (true)
        {
            Console.Clear();
            Contents();
            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                try
                {
                    if (key.Key == ConsoleKey.D1) School.Program.Main();
                    else if (key.Key == ConsoleKey.D2) People.Program.Main();
                    else if (key.Key == ConsoleKey.D3) Animals.Program.Main();
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        InOut("Goodbye!");
                        Environment.Exit(0);
                    }
                    else break;

                    TextButton("\n\nThis was the end of the program.\nPress ", "Enter");
                    TextButton(" to try again or ", "Esc");
                    TextButton(" to go to Main Menu . . .", null);

                    ConsoleKeyInfo k = Console.ReadKey();
                    while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape)
                    {
                        Console.Write("\b \b");
                        k = Console.ReadKey();
                    }
                    if (k.Key == ConsoleKey.Escape) break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n\nYou made something wrong!\nPress any key to try again . . .");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }

    static void Contents()
    {
        TextButton("\n\n   Homework 4. OOP Principles - Part I\n", null);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: In a given school there are classes of students. Each class has a set of teachers.
              Each teacher  teaches a set  of disciplines. Students have  name and  unique class
              number. Classes  have unique text identifier. Teachers have name. Disciplines have
              name, number of lectures and  number of exercises. Both teachers and  students are
              people. Students, classes, teachers and disciplines could have optional comments.

              Your task is  to identify  the classes (in terms of OOP)  and their attributes and
              operations, encapsulate  their fields, define the class hierarchy and create class
              diagram with Visual Studio. 

      Task 2: Define abstract  class Human  with first and last name. Define  new class  Student
              which is derived from Human and has new field – grade. Define class Worker derived
              from Human with property  WeekSalary and WorkHoursPerDay and method MoneyPerHour()
              that returns money  earned by  hour by the worker.  Define the proper constructors
              and properties for this  hierarchy. Initialize a list of 10 students and sort them
              by grade in ascending order (use LINQ or OrderBy() extension method). Initialize a
              list of 10 workers and sort them by money per hour in descending order.  Merge the
              lists and sort them by first name and last name.
                
      Task 3: Create a hierarchy  Dog, Frog, Cat, Kitten, Tomcat  and define useful constructors
              and  methods.  Dogs, frogs  and cats are  Animals. All animals  can produce  sound
              (specified by the ISound interface). Kittens and tomcats are cats. All animals are
              described by age, name and sex. Kittens can be only female and tomcats can be only
              male.  Each animal produces a specific sound. Create  arrays of different kinds of
              animals and calculate the average age of each kind of animal using a static method.
                         ");
        Console.ResetColor();
        TextButton("   Please, select a task number from ", "1");
        TextButton(" to ", "3");
        TextButton(" or press ", "ESC");
        TextButton(" to exit... ", null);
    }

    private static void TextButton(string text, string key)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(text);
        if (key != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
        }
        Console.ResetColor();
    }

    static void InOut(string text)
    {
        Console.SetCursorPosition(47, 10);
        Console.Write(text);
        Console.SetCursorPosition(99, 33);
        Thread.Sleep(2000);
    }
}