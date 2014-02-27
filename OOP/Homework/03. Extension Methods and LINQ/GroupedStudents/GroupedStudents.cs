// Task 18: Create a program that extracts all students grouped by GroupName
//          and then prints them to the console. Use LINQ.
//
// Task 19: Rewrite the previous using extension methods.

using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupedStudents
{
    class Program
    {
        static void Main()
        {
            // Create a list of student
            List<Student> students = new List<Student>()
            {
                new Student("Petar Petrov", "Group1"),
                new Student("Ivan Ivanov", "Group2"),
                new Student("Maria Ivanova", "Group3"),
                new Student("George Stoyanov", "Group1"),
                new Student("Petya Petrova", "Group2")
            };

            // Print all students
            Console.WriteLine("All students:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.ResetColor();

            // Extracts and print all students grouped by GroupName (by Linq)
            Console.WriteLine("\nGrouped students (by Linq):");
            Print(from s in students group s by s.GroupName into g select g);

            // Extracts and print all students grouped by GroupName (by Lambda)
            Console.WriteLine("\nGrouped students (by Lambda):");
            Print(students.GroupBy(m => m.GroupName));
        }

        // Print some group of students
        private static void Print(IEnumerable<IGrouping<string, Student>> groupedStudents1)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var group in groupedStudents1)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group) Console.WriteLine(student);
            }
            Console.ResetColor();
        }
    }
}