/* Task 03.
 * Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
 * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
 * Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female
 * and tomcats can be only male. Each animal produces a specific sound. Create arrays of different kinds
 * of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
 */

using System;

namespace Animals
{
    public class Program
    {
        public static void Main()
        {
            // Create arrays of different kinds of animals
            Frog[] frogs = new Frog[100];
            Dog[] dogs = new Dog[100];
            Cat[] cats = new Cat[100];

            byte frogCount = 0;
            byte dogCount = 0;
            byte catCount = 0;

            bool exit = false;
            while (!exit)
            {
                Console.CursorTop = 0;
                {
                    // The menu
                    Menu('F', "Add some Frog");
                    Menu('D', "Add some Dog");
                    Menu('T', "Add some Tomcat");
                    Menu('K', "Add some Kitten\n");

                    Menu('P', "Print the list of animals");
                    Menu('Q', "Quit\n");
                    Console.Write(" ");

                    // Our choice
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F: frogCount = AddAnimal("Frog", frogs, frogCount); break;
                        case ConsoleKey.D: dogCount = AddAnimal("Dog", dogs, dogCount); break;
                        case ConsoleKey.T: catCount = AddAnimal("Tomcat", cats, catCount); break;
                        case ConsoleKey.K: catCount = AddAnimal("Kitten", cats, catCount); break;
                        case ConsoleKey.P: PrintTable(frogs, dogs, cats); break;
                        case ConsoleKey.Q: exit = true; Console.Write("\b \b"); continue;
                        default: Console.WriteLine("\b \b↑"); continue;
                    }
                    Console.Clear();
                }
            }
        }

        // Print some line from the menu
        private static void Menu(char key, string text)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.WriteLine("]: {0}", text);
        }

        // Ask for something and read the information about it
        private static string Read(string text)
        {
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        // Read information about some animal
        private static byte AddAnimal<T>(string kind, T[] animals, byte count) where T : ISound
        {
            Console.Write("\r");
            string name = String.Empty;
            bool isName = false;
            while (true)
            {
                try
                {
                    // Read the animal's name
                    if (!isName)
                    {
                        name = Read(String.Format("{0}'s name: ", kind));
                        if (name.Length < 2) throw new ArgumentException("The name is too short!");
                        if (name.Length > 10) throw new ArgumentException("The name is too long!");
                        isName = true;
                    }

                    // Read the animal's age
                    byte age = byte.Parse(Read(String.Format("{0}'s age: ", name)));

                    // Read the sex of the animal
                    if (kind == "Tomcat")
                    {
                        animals[count] = (T)Activator.CreateInstance(typeof(T), name, (byte)age, Sex.Male);
                        animals[count].Sound(Sex.Male);
                    }
                    else if (kind == "Kitten")
                    {
                        animals[count] = (T)Activator.CreateInstance(typeof(T), name, (byte)age, Sex.Female);
                        animals[count].Sound(Sex.Female);
                    }
                    else
                    {
                        Console.Write("{0}'s sex (m/f): ", name);
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.M:
                                    animals[count] = (T)Activator.CreateInstance(typeof(T), name, (byte)age, Sex.Male);
                                    Console.Write("ale");
                                    animals[count].Sound(Sex.Male);
                                    break;
                                case ConsoleKey.F:
                                    animals[count] = (T)Activator.CreateInstance(typeof(T), name, (byte)age, Sex.Female);
                                    Console.Write("emale");
                                    animals[count].Sound(Sex.Female);
                                    break;
                                default: Console.Write("\b \b"); continue;
                            }
                            Console.ResetColor();
                            break;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\nA new {0} is added to the list of animals", char.ToLower(kind[0]) + kind.Substring(1));
                    Console.ResetColor();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    count++;
                    return count;
                }
                catch (Exception e) { Error(e); }
            }
        }

        // Print the whole list of animals in one table
        private static void PrintTable(Frog[] frogs, Dog[] dogs, Cat[] cats)
        {
            if (frogs[0] == null && dogs[0] == null && cats[0] == null)
            {
                Error(new Exception("\rThe list of animals is empty!"));
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                LineOfTable("  ╔", new string('═', 27), "╗", ConsoleColor.Cyan);
                LineOfTable("  ║          ", "ANIMALS", "║", ConsoleColor.White);
                PrintAnimal(frogs, "Frogs:");
                PrintAnimal(dogs, "Dogs:");

                if (cats[0] != null)
                {
                    LineOfTable("  ╟", new string('─', 27), "╢", ConsoleColor.Cyan);
                    LineOfTable("  ║ ", "Cats:", "║", ConsoleColor.White);
                    PrintCat(cats, "Tomcats:", Sex.Male);
                    PrintCat(cats, "Kittens:", Sex.Female);
                    PrintAverageAge(cats);
                }
                LineOfTable("  ╚", new string('═', 27), "╝", ConsoleColor.Cyan);
            }
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Print one row from the table
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

        // Print some animal from the list
        private static void PrintAnimal(Animal[] animals, string name)
        {
            if (animals[0] != null)
            {
                LineOfTable("  ╟", new string('─', 27), "╢", ConsoleColor.Cyan);
                LineOfTable("  ║ ", name, "║", ConsoleColor.White);

                foreach (Animal a in animals)
                {
                    if (a != null)
                    {
                        LineOfTable("  ║    ", a.Name + " (" + a.Age + ":" + ((a.Sex == Sex.Male) ? "m)" : "f)"), "║", ConsoleColor.Gray);
                    }
                }
                PrintAverageAge(animals);
            }
        }

        // Print some cat from the list
        private static void PrintCat(Cat[] cats, string kind, Sex sex)
        {
            bool isSex = false;
            foreach (Cat cat in cats) if (cat != null && cat.Sex == sex) isSex = true;
            if (isSex)
            {
                LineOfTable("  ║    ", kind, "║", ConsoleColor.White);
                foreach (var cat in cats)
                {
                    if (cat != null && cat.Sex == sex)
                    {
                        LineOfTable("  ║       ", cat.Name + " (" + cat.Age + ")", "║", ConsoleColor.Gray);
                    }
                }
            }
        }

        // Print the average age of each kind of animal 
        private static void PrintAverageAge(Animal[] animal)
        {
            LineOfTable("  ║ ", new string('─', 25), "║", ConsoleColor.DarkCyan);
            LineOfTable("  ║ ", String.Format("Average age: {0:F1}", Animal.AverageAge(animal)), "║", ConsoleColor.DarkCyan);
        }

        // Print some error message
        private static void Error(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
    }
}