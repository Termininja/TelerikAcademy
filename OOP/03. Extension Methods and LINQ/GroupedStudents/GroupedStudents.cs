/* 
 * Problem 18. Grouped by GroupNumber:
 *      Create a program that extracts all students grouped by GroupNumber
 *      and then prints them to the console. Use LINQ.
 * 
 * Problem 19. Grouped by GroupName extensions:
 *      Rewrite the previous using extension methods.
 */

namespace GroupedStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // Creates a list of student
            var students = new List<Student>()
            {
                new Student("Petar Petrov", "Group1"),
                new Student("Ivan Ivanov", "Group2"),
                new Student("Maria Ivanova", "Group3"),
                new Student("George Stoyanov", "Group1"),
                new Student("Petya Petrova", "Group2")
            };

            // Prints all students
            Console.WriteLine("All students:");
            Console.ForegroundColor = ConsoleColor.Gray;
            students.ForEach(m => Console.WriteLine(m));
            Console.ResetColor();

            // Extracts and print all students grouped by GroupName (by Linq)
            Console.WriteLine("\nGrouped students (by Linq):");
            Print(from s in students group s by s.GroupName into g select g);

            // Extracts and print all students grouped by GroupName (by Lambda)
            Console.WriteLine("\nGrouped students (by Lambda):");
            Print(students.GroupBy(m => m.GroupName));
        }

        // Prints some group of students
        private static void Print(IEnumerable<IGrouping<string, Student>> groupedStudents1)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            groupedStudents1.ToList().ForEach(m => Console.WriteLine("{0}\n{1}", m.Key, string.Join("\n", m)));
            Console.ResetColor();
        }
    }
}