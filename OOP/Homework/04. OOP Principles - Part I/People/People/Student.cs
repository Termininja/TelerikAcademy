using System;
using System.Collections.Generic;

namespace People
{
    class Student : Human
    {
        // Property
        public int Grade { get; set; }

        // Constructor
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        // Print some list of students
        public static void Print(List<Student> list)
        {
            Console.WriteLine("┌──────────────────────┬───────┐");
            Console.WriteLine("│ {0,-21}│ {1,5} │", "Students", "Grade");
            Console.WriteLine("├──────────────────────┼───────┤");
            foreach (Student student in list)
            {
                TableColumn("{0,-21}", student, ConsoleColor.White);
                TableColumn("{0,5} ", student.Grade, ConsoleColor.Green);
                Console.WriteLine("│");
            }
            Console.WriteLine("└──────────────────────┴───────┘");
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}