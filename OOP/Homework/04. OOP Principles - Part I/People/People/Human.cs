using System;
using System.Collections.Generic;

namespace People
{
    abstract class Human
    {
        // Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Constructor
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Print some list of humans
        public static void Print(List<Human> list)
        {
            Console.WriteLine("┌────────────┬────────────┐");
            Console.WriteLine("│ {0,-11}│ {1,-10} │", "First Name", "Last Name");
            Console.WriteLine("├────────────┼────────────┤");
            foreach (Human item in list)
            {
                TableColumn("{0,-11}", item.FirstName, ConsoleColor.White);
                TableColumn("{0,-10} ", item.LastName, ConsoleColor.White);
                Console.WriteLine("│");
            }
            Console.WriteLine("└────────────┴────────────┘");
        }

        protected static void TableColumn(string format, dynamic student, ConsoleColor color)
        {
            Console.Write("│ ");
            Console.ForegroundColor = color;
            Console.Write(format, student);
            Console.ResetColor();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
