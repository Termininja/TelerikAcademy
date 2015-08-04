/* 
 * Problem 3. Animal hierarchy:
 *      Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
 *      Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
 *      Kittens and tomcats are cats. All animals are described by age, name and sex.
 *      Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
 *      
 *      Create arrays of different kinds of animals and calculate the average age of each kind
 *      of animal using a static method (you may use LINQ).
 */

namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Frog> frogs = new List<Frog>();
        private static List<Dog> dogs = new List<Dog>();
        private static List<Cat> cats = new List<Cat>();

        public static void Main()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.CursorTop = 0;
                {
                    PrintMenu('F', "Add some Frog");
                    PrintMenu('D', "Add some Dog");
                    PrintMenu('T', "Add some Tomcat");
                    PrintMenu('K', "Add some Kitten\n");
                    PrintMenu('P', "Print the list of animals");
                    PrintMenu('Q', "Quit\n");

                    Console.Write(" ");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F:
                            AddAnimal<Frog>();
                            break;
                        case ConsoleKey.D:
                            AddAnimal<Dog>();
                            break;
                        case ConsoleKey.T:
                            AddAnimal<Tomcat>();
                            break;
                        case ConsoleKey.K:
                            AddAnimal<Kitten>();
                            break;
                        case ConsoleKey.P:
                            PrintTable();
                            break;
                        case ConsoleKey.Q:
                            Console.Write("\b \b");
                            return;
                        default: Console.WriteLine("\b \b↑");
                            continue;
                    }

                    Console.Clear();
                }
            }
        }

        private static string Read(string text)
        {
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        private static void AddAnimal<T>()
        {
            Console.Write("\r");
            var name = String.Empty;
            while (true)
            {
                try
                {
                    // Read the animal's name
                    if (name == String.Empty)
                    {
                        name = Read(String.Format("{0}'s name: ", typeof(T).Name));
                        if (name.Length < 2 || name.Length > 10)
                        {
                            name = String.Empty;
                            throw new ArgumentException("The name has to be from 2 to 10 characters in length!");
                        }
                    }

                    // Read the animal's age
                    var age = byte.Parse(Read(String.Format("{0}'s age: ", name)));

                    // Read the sex of the animal
                    dynamic animal = null;
                    if (typeof(T) == typeof(Tomcat) || typeof(T) == typeof(Kitten))
                    {
                        animal = (T)Activator.CreateInstance(typeof(T), name, age);
                        cats.Add(animal);
                    }
                    else
                    {
                        Console.Write("{0}'s sex (m/f): ", name);
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            var sex = Sex.Female;
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.M:
                                    Console.WriteLine("ale");
                                    sex = Sex.Male;
                                    break;
                                case ConsoleKey.F:
                                    Console.WriteLine("emale");
                                    sex = Sex.Female;
                                    break;
                                default: Console.Write("\b \b");
                                    continue;
                            }

                            animal = (T)Activator.CreateInstance(typeof(T), name, age, sex);
                            if (typeof(T) == typeof(Frog)) frogs.Add(animal);
                            else dogs.Add(animal);

                            Console.ResetColor();
                            break;
                        }
                    }

                    animal.Sound();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nA new {0} was added to the list of animals", char.ToLower(typeof(T).Name[0]) + typeof(T).Name.Substring(1));
                    Console.ResetColor();
                    Console.CursorVisible = true;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();

                    return;
                }
                catch (Exception e)
                {
                    PrintErrorMessage(e);
                }
            }
        }

        private static void PrintMenu(char key, string text)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.WriteLine("]: {0}", text);
        }

        private static void PrintErrorMessage(Exception e, string error = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e == null ? error : e.Message);
            Console.ResetColor();
        }

        private static void PrintTable()
        {
            if (frogs.Count == 0 && dogs.Count == 0 && cats.Count == 0)
            {
                PrintErrorMessage(null, "\rThe list of animals is empty!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                LineOfTable("  ╔", new string('═', 27), "╗", ConsoleColor.Cyan);
                LineOfTable("  ║          ", "ANIMALS", "║", ConsoleColor.White);
                PrintAnimal<Frog>(frogs);
                PrintAnimal<Dog>(dogs);

                if (cats.Count > 0)
                {
                    LineOfTable("  ╟", new string('─', 27), "╢", ConsoleColor.Cyan);
                    LineOfTable("  ║ ", "Cats:", "║", ConsoleColor.White);
                    PrintCat<Tomcat>();
                    PrintCat<Kitten>();
                    PrintAverageAge<Cat>(cats);
                }

                LineOfTable("  ╚", new string('═', 27), "╝", ConsoleColor.Cyan);
            }
            Console.CursorVisible = true;
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void PrintAnimal<T>(List<T> animals) where T : Animal
        {
            if (animals.Count > 0)
            {
                LineOfTable("  ╟", new string('─', 27), "╢", ConsoleColor.Cyan);
                LineOfTable("  ║ ", typeof(T).Name + "s:", "║", ConsoleColor.White);

                foreach (var animal in animals)
                {
                    LineOfTable("  ║    ", animal.Name + " (" + animal.Age + ":" + ((animal.Sex == Sex.Male) ? "m)" : "f)"), "║", ConsoleColor.Gray);
                }

                PrintAverageAge<T>(animals);
            }
        }

        private static void PrintCat<T>() where T : Cat
        {
            if (cats.Any(cat => cat is T))
            {
                LineOfTable("  ║    ", typeof(T).Name + "s:", "║", ConsoleColor.White);
                foreach (var cat in cats)
                {
                    if (cat is T)
                    {
                        LineOfTable("  ║       ", cat.Name + " (" + cat.Age + ")", "║", ConsoleColor.Gray);
                    }
                }
            }
        }

        private static void PrintAverageAge<T>(List<T> animals) where T : Animal
        {
            LineOfTable("  ║ ", new string('─', 25), "║", ConsoleColor.DarkCyan);
            LineOfTable("  ║ ", String.Format("Average age: {0:F1}", Animal.AverageAge<T>(animals)), "║", ConsoleColor.DarkCyan);
        }

        private static void LineOfTable(string left, string text, string right, ConsoleColor color)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(left);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (right.Length == 1) Console.CursorLeft = 30;
            Console.WriteLine(right);
            Console.ResetColor();
        }
    }
}